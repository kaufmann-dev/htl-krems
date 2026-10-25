//!   1. Pathfinding

//*   1.1 Über welche Knoten führt der kürzeste Weg von der Seestadt nach Heiligenstadt.
//    Beschränken Sie sich auf die UBahn als Transportmittel.
//    Knoten: s:Station
//    Kanten:
//    Ausgabe: [s.name, ..., s_n.name]




//*   1.2 Aufgrund eines Rohrbruchs ist es nicht möglich die Station Schottenring anzufahren. Berechnen Sie eine alternative kürzeste Route von Heiligenstadt in die Seestadt.
//    Knoten: s:Station
//    Kanten:
//    Ausgabe: [s.name, ..., s_n.name]

CALL gds.graph.drop('viennatraffico') YIELD graphName;
CALL gds.graph.project.cypher(
    "viennatraffico",
    "MATCH (s:Station) WHERE s.name <> 'Schottenring'
    RETURN id(s) AS id, labels(s) as labels",
    "MATCH (s:Station)-[r:SUBWAY|EXPRESSWAY|TRAM|TRAIN]->(t:Station)
    RETURN id(s) as source,
        id(t) as target,
        type(r) as type,
        coalesce(r.time,0) as time",
    {validateRelationships:false}
);



//!   2. Pathfinding

//*   2.1 Über welche Knoten führt der kürzeste Weg von der Seestadt nach Heiligenstadt.
//    Knoten: :Station
//    Kanten: :SUBWAY, :EXPRESSWAY, :TRAM, :TRAIN
//    Ausgabe:
//    [
//       {source: "Heiligenstadt", target: "Spittelau", type: "SUBWAY", code: "U4"},
//       {source: "Spittelau",     target: "Friedensbrücke", type: "SUBWAY", code: "U4"}
//       ...
//    ]

MATCH (s1:Station{name:"Seestadt"})
MATCH (s2:Station{name:"Heiligenstadt"})
CALL gds.shortestPath.dijkstra.stream(
    "viennatraffic", {
        sourceNode: s1,
        targetNode: s2,
        relationshipWeightProperty : "time",
        relationshipTypes : ["SUBWAY"]
    }
)
YIELD nodeIds
unwind nodeIds as bru
with
    gds.util.asNode(bru) as source,
    gds.util.asNode(bru+1) as target
match (source)-[u]->(target)
with source, target, u.code as code, type(u) as type
return
    source.name as source,
    target.name as target,
    type,
    code
;


//!   3. Pathfinding

//*   3.1 Finden Sie alle U-Bahnstationen die maximal 10 Minuten vom Karlsplatz entfernt sind.
//    Knoten: :Station
//    Kanten: :SUBWAY
//    Ausgabe:   "Karlsplatz", ["Stephansplatz", "Kettenbrückengasse", "Stadtpark", ...]

match (source:Station{name:"Karlsplatz"})
CALL gds.allShortestPaths.dijkstra.stream("viennatrafic",{
    sourceNode: source,
    relationshipWeightProperty: "length"
})
YIELD sourceNode, targetNode, nodeIds
RETURN
    index,
    gds.util.asNode(sourceNode).name AS source,
    gds.util.asNode(targetNode).name AS target,
    totalCost,
    [nodeId IN nodeIds | gds.util.asNode(nodeId).name] AS nodeNames,
    costs,
    nodes(path) as path
ORDER BY index;
