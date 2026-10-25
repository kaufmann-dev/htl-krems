CALL gds.graph.drop('viennatraffic') YIELD graphName;

CALL gds.graph.project.cypher(
    "viennatraffic",
    "MATCH  (s:Station)
    RETURN id(s) as id,
            labels(s) as labels",
    "MATCH (s:Station)-[r:EXPRESSWAY|TRAIN|TRAM|SUBWAY|TRAMWAY|REGIONAL_EXPRESS]->(t:Station)
    RETURN
        id(s) as source,
        id(t) as target,
        type(r) as type,
        coalesce(r.length, 0) as length,
        coalesce(r.time,0) as time
    "
);

//!   1. Pathfinding

//*   1.1 Über welche Knoten führt der kürzeste Weg von der Seestadt nach Heiligenstadt.
//    Beschränken Sie sich auf die UBahn als Transportmittel.
//    Knoten: s:Station
//    Kanten:
//    Ausgabe: [s.name, ..., s_n.name]

// Varitante 1
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
RETURN [id in nodeIds | gds.util.asNode(id).name];

// Varitante 2
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
RETURN gds.util.asNodes(nodeIds);


//*   1.2 Aufgrund eines Rohrbruchs ist es nicht möglich die Station Schottenring anzufahren. Berechnen Sie eine alternative kürzeste Route von Heiligenstadt in die Seestadt.
//    Knoten: s:Station
//    Kanten:
//    Ausgabe: [s.name, ..., s_n.name]

CALL gds.graph.project.cypher(
    "viennatraffic2",
    "MATCH (s:Station) WHERE s.name <> 'Schottenring'
    RETURN id(s) AS id, labels(s) as labels",
    "MATCH (s:Station)-[r:SUBWAY|EXPRESSWAY|TRAM|TRAIN]->(t:Station)
    RETURN id(s) as source,
        id(t) as target,
        type(r) as type,
        coalesce(r.time,0) as time",
    {validateRelationships:false}
);

MATCH (s1:Station{name:"Seestadt"})
MATCH (s2:Station{name:"Heiligenstadt"})
CALL gds.shortestPath.dijkstra.stream(
    "viennatraffic2", {
        sourceNode: s1,
        targetNode: s2,
        relationshipWeightProperty : "length",
        relationshipTypes : ["SUBWAY", "EXPRESSWAY", "TRAM", "TRAIN"]
    }
)
YIELD nodeIds
RETURN [id in nodeIds | gds.util.asNode(id).name];

CALL gds.graph.drop('viennatraffic2') YIELD graphName;


//!   2. Beispiel) Pathfinding

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
        relationshipTypes :
            ["SUBWAY", "EXPRESSWAY", "TRAM", "TRAIN"]
    }
)
YIELD nodeIds
UNWIND apoc.coll.pairsMin([id in nodeIds | gds.util.asNode(id)]) AS data
WITH data[0] as current, data[1] as next
MATCH (current)-[r]->(next)
RETURN current.name AS source,
    next.name AS target,
    type(r) as TYPE,
    r.code as CODE,
    r.length as LENGTH;


//!   3. Pathfinding

//*   3.1 Finden Sie alle U-Bahnstationen die maximal 10 Minuten vom Karlsplatz entfernt sind.
//    Knoten: :Station
//    Kanten: :SUBWAY
//    Ausgabe:   "Karlsplatz", ["Stephansplatz", "Kettenbrückengasse", "Stadtpark", ...]

MATCH (s:Station{name:"Karlsplatz"})
CALL gds.allShortestPaths.dijkstra.stream(
    "viennatraffic2",{
        sourceNode : s,
        relationshipWeightProperty : "time",
        relationshipTypes : ["SUBWAY"]
    }
)
YIELD index, sourceNode, targetNode, totalCost, path
WHERE totalCost/60 <= 10.0 and gds.util.asNode(targetNode).name <> "Karlsplatz"
WITH gds.util.asNode(sourceNode) as source,
    gds.util.asNode(targetNode) as target
RETURN source.name, collect (DISTINCT target.name);

