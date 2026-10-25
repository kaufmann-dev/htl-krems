//!  1. Pathfinding

//*   1.1 Über welche Knoten führt der kürzeste Weg von der Seestadt nach Heiligenstadt.
//    Beschränken Sie sich auf die UBahn als Transportmittel.
//    Knoten: s:Station
//    Kanten:
//    Ausgabe:
//    [s.name, ..., s_n.name]

match p = shortestPath((:Station{name:"Seestadt"})-[:SUBWAY*]->(:Station{name:"Heiligenstadt"}))
return nodes(p);


//*   1.2 Aufgrund eines Rohrbruchs ist es nicht möglich die Station Schottenring anzufahren. Berechnen Sie eine alternative kürzeste Route von Heiligenstadt in die Seestadt.
//    Knoten: s:Station
//    Kanten:
//    Ausgabe:
//    [s.name, ..., s_n.name]

match p = shortestPath((:Station{name:"Heiligenstadt"})-[:SUBWAY*]->(:Station{name:"Seestadt"}))
WHERE NONE(x IN NODES(p) WHERE x.name = "Schottenring")
return p;


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

match p = shortestPath((:Station{name:"Seestadt"})-[*]->(:Station{name:"Heiligenstadt"}))
return nodes(p);


//!  3. Pathfinding

//*   3.1 Finden Sie alle U-Bahnstationen die maximal 10 Minuten vom Karlsplatz entfernt sind.
//    Knoten: :Station
//    Kanten: :SUBWAY
//    Ausgabe:
//    "Karlsplatz", ["Stephansplatz", "Kettenbrückengasse", "Stadtpark", ...]

match p = shortestPath((l:Station)-[:SUBWAY*]->(:Station{name:"Karlsplatz"}))
where l.name <> "Karlsplatz"
with reduce(i=0.0, len in relationships(p) | i+len.time)/60 as part, l
where part <= 10
return l.name as station, round(part,1) as minutes;