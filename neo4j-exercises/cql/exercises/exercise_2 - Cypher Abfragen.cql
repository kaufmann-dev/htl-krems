//!  1. Einfache Cypher Abfragen

//*  1.1 Schreiben Sie Ihre Verkehrslinie auf folgende Syntax um:
WITH [
    // START, END, DISTANCE
    ["A", "B", 10], ["A", "C", 33], ["A", "D", 35],
    ["C", "D", 28], ["B", "C", 20], ["C", "E", 6],
    ["D", "E", 40]
] AS nested
UNWIND nested AS row
MERGE (n:City {name: row[0]})
MERGE (m:City {name: row[1]})
MERGE (n)-[r:ROAD {distance: row[2]}]->(m);

//   Siehe tram.cql


//!  2. Einfache Cypher Abfragen

//*  2.1 Finden Sie die beiden Endstationen der U2.
//   Knoten: s:Station
//   Kanten: SUBWAY
//   Ausgabe: s.name

match (s:Station)-[u:SUBWAY{code:"U2"}]-(:Station)
with count(u) as ccount, s.name as name
where ccount = 2
return name;


//*  2.2 Finden Sie für jede U-Bahnlinie die beiden Endstationen.
//   Knoten: s:Station
//   Kanten: SUBWAY
//   Ausgabe: s.name

match (s:Station)-[u:SUBWAY]-(:Station)
with distinct u.code as code, count(u) as ccount, s.name as name
where ccount = 2
return code, collect(name) as Endstationen
order by code asc;


//*  2.3 Geben Sie alle U-Bahn Linien aus für die alle Teilstrecken eine Länge von mindestens 10 haben.
//   Knoten: Station
//   Kanten: r:SUBWAY
//   Ausgabe: r.code

match (:Station)-[u:SUBWAY]-(:Station)
with u.code as code, sum(u.length)/2 as len
where len > 10
return code, len;


//!  3. Komplexe Cypher Abfragen

//*  3.1 Auf der U2 kommt es aufgrund von Bauarbeiten zu Verzögerungen. Gehen Sie davon aus dass die UBahn für die Teilstrecke von Rathaus nach Seestadt um 40% länger braucht. Geben Sie an wieviele Minuten die UBahn für 1 Durchfahrt braucht.
//   Hinweis: Verwenden Sie die shortestPath Funktion um bei der Angabe zweier Knoten einen der kürzesten Pfade zwischen den Knoten zu berechnen.
//   z. B.:
MATCH p = shortestPath((:Station)-[:SUBWAY*]->(:Station))
RETURN p;
//   Knoten: :Station
//   Kanten: :SUBWAY
//   Ausgabe: timeSpend

match
    p = shortestPath((:Station{name:"Seestadt"})-[:SUBWAY*]->(:Station{name:"Rathaus"}))
with
    reduce(i = 0.0, time in [r in relationships(p) | r.time * 1.4] | i + time) as part1
match
    p2 = shortestPath((:Station{name:"Rathaus"})-[:SUBWAY*]->(:Station{name:"Karlsplatz"}))
with
    reduce(i = 0.0, route in relationships(p2)                     | i + route.time) as part2,
    part1
return
    (part1 + part2)/60 as timeSpent;

//!   4. Komplexe Abfragen

//*   4.1 Finden Sie alle U-Bahnlinien die keine Teilroute haben die länger ist als 2
//    Knoten: Station
//    Kanten: s:SUBWAY
//    Ausgabe: s.code

MATCH (:Station)-[r:SUBWAY]-(:Station)
WITH  r.code as code, collect(r) as routes
WHERE all(r in routes where r.length < 2)
RETURN code;


// 5. - apoc Abfragen: siehe exercise_5 - APOC