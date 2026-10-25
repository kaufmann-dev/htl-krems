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

match (s:Station)-[u:SUBWAY{code:"U4"}]->(:Station)
with s.name as name, count(u) as ccount
where ccount = 1
return name;


//*  2.2 Finden Sie für jede U-Bahnlinie die beiden Endstationen.
//   Knoten: s:Station
//   Kanten: SUBWAY
//   Ausgabe: s.name

match (s:Station)-[u:SUBWAY]->(:Station)
with distinct u.code as code, count(u) as ccount,  s.name as name
where ccount = 1
return code, collect(name);


//*  2.3 Geben Sie alle U-Bahn Linien aus für die alle Teilstrecken eine Länge von mindestens 10 haben.
//   Knoten: Station
//   Kanten: r:SUBWAY
//   Ausgabe: r.code

match (s:Station)-[u:SUBWAY]->(:Station)
with distinct u.code as code, collect(u.time) as coll
where none(x in coll where x < 10)
return code;


//!  3. Komplexe Cypher Abfragen

//*  3.1 Auf der U2 kommt es aufgrund von Bauarbeiten zu Verzögerungen. Gehen Sie davon aus dass die UBahn für die Teilstrecke von Rathaus nach Seestadt um 40% länger braucht. Geben Sie an wieviele Minuten die UBahn für 1 Durchfahrt braucht.
//   Hinweis: Verwenden Sie die shortestPath Funktion um bei der Angabe zweier Knoten einen der kürzesten Pfade zwischen den Knoten zu berechnen.
//   z. B.:
MATCH p = shortestPath((:Station)-[:SUBWAY*]->(:Station))
RETURN p;
//   Knoten: :Station
//   Kanten: :SUBWAY
//   Ausgabe: timeSpend

match (s:Station)-[u:SUBWAY]-(:Station)
match p1 = shortestPath((:Station{name:"Seestadt"})-[:SUBWAY*]->(:Station{name:"Rathaus"}))
match p2 = shortestPath((:Station{name:"Rathaus"})-[:SUBWAY*]->(:Station{name:"Karlsplatz"}))
return distinct reduce(i=0.0, j in relationships(p1) | i+j.time * 1.4) + reduce(i=0.0, j in relationships(p2) | i+j.time) as timeSpent;


//!   4. Komplexe Abfragen

//*   4.1 Finden Sie alle U-Bahnlinien die keine Teilroute haben die länger ist als 2
//    Knoten: Station
//    Kanten: s:SUBWAY
//    Ausgabe: s.code

match (s:Station)-[u:SUBWAY]->(:Station)
with distinct u.code as code, collect(u.length) as coll
where none(x in coll where x > 2)
return code;


// 5. - apoc Abfragen: siehe exercise_5 - APOC