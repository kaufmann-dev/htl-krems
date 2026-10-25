//!  1. Pathfinding

//*   1.1 Über welche Knoten führt der kürzeste Weg von der Seestadt nach Heiligenstadt.
//    Beschränken Sie sich auf die UBahn als Transportmittel.
//    Knoten: s:Station
//    Kanten:
//    Ausgabe:
//    [s.name, ..., s_n.name]

match (s1:Station{name:"Seestadt"})
match (s2:Station{name:"Heiligenstadt"})
CALL gds.shortestPath.dijkstra.stream("viennatraffic", {
    sourceNode : s1,
    targetNode : s2,
    relationshipWeightProperty: "length",
    relationshipTypes : ["SUBWAY"]
})
YIELD path
RETURN
    [x in nodes(path) | x.name];


//*   1.2 Aufgrund eines Rohrbruchs ist es nicht möglich die Station Schottenring anzufahren. Berechnen Sie eine alternative kürzeste Route von Heiligenstadt in die Seestadt.
//    Knoten: s:Station
//    Kanten:
//    Ausgabe:
//    [s.name, ..., s_n.name]

CALL gds.graph.project.cypher("viennatraffica",
"
    MATCH (s:Station)
    where s.name <> 'Schottenring'
    RETURN
        id(s) as id,
        labels(s) as labels
",
"
    MATCH (s:Station)-[r:EXPRESSWAY|TRAIN|TRAM|SUBWAY|TRAMWAY|REGIONAL_EXPRESS]->(t:Station)
    RETURN
        id(s) as source,
        id(t) as target,
        type(r) as type,
        coalesce(r.length, 0) as length,
        coalesce(r.time,0) as time
",
    {validateRelationships:false}
);
match (s1:Station{name:"Seestadt"})
match (s2:Station{name:"Heiligenstadt"})
CALL gds.shortestPath.dijkstra.stream("viennatraffica", {
    sourceNode : s1,
    targetNode : s2,
    relationshipWeightProperty: "length",
    relationshipTypes : ["SUBWAY"]
})
YIELD path
RETURN
    [x in nodes(path) | x.name];
CALL gds.graph.drop('viennatraffic');

//!  2. Pathfinding

//*   2.1 Über welche Knoten führt der kürzeste Weg von der Seestadt nach Heiligenstadt.
//    Knoten: :Station
//    Kanten: :SUBWAY, :EXPRESSWAY, :TRAM, :TRAIN
//      Ausgabe:
//      [
//         {source: "Heiligenstadt", target: "Spittelau", type: "SUBWAY", code: "U4"},
//         {source: "Spittelau",     target: "Friedensbrücke", type: "SUBWAY", code: "U4"},
//         ...
//      ]




//!  3. Pathfinding

//*   3.1 Finden Sie alle U-Bahnstationen die maximal 10 Minuten vom Karlsplatz entfernt sind.
//    Knoten: :Station
//    Kanten: :SUBWAY
//    Ausgabe:
//    "Karlsplatz", ["Stephansplatz", "Kettenbrückengasse", "Stadtpark", ...]



