//!  1. MATCH Klausel

//*  1.1 Welche U-Bahn Linien fahren in Wien

//   Knoten: :Station
//   Kanten: r:SUBWAY
//   Ausgabe: r.code

match (:Station{state:"Wien"})-[u:SUBWAY]-(:Station)
return distinct u.code;


//*  1.2 Geben Sie alle Stationen der U4 bzw. U6 aus
//   Knoten: t:Station
//   Kanten: :SUBWAY
//   Ausgabe: t.name

match (s:Station)-[u:SUBWAY]-(:Station)
where u.code in ["U4", "U6"]
return distinct s.name;


//*  1.3 Geben Sie alle Stationen aus, die von der U2 und der U4 angefahren werden.
//   Knoten: t:Station
//   Kanten: :SUBWAY
//   Ausgabe: t.name

match (:Station)-[:SUBWAY{code:"U2"}]-(:Station)-[:SUBWAY]-(s:Station)-[:SUBWAY{code:"U4"}]-(:Station)
return distinct s.name;


//*  1.4 Welche Stationen sind bis zu 2 Haltestellen von Spittelau entfernt?
//   Hinweis: Spittelau selbst sollte nicht im Ergebnis enthalten sein.
//   Knoten: t:Station
//   Kanten:
//   Ausgabe: t.name

match (s:Station)-[*2]-(:Station{name:"Spittelau"})
where s.name <> "Spittelau"
return distinct s.name;


//!  2. Aggregatfunktionen

//*  2.1 Geben Sie für jede U-Bahn Linie die Anzahl der Stationen aus.
//   Knoten: s:Station
//   Kanten: r:SUBWAY
//   Ausgabe: r.code, count(s)

match (s:Station)-[u:SUBWAY]-(:Station)
return u.code, count(distinct s);



//*  2.2 Geben Sie für jede U-Bahn Linie die Länge der Strecke aus.
//   Geben Sie zusätzlich an wie lange es dauert von einem nde der U Bahn bis zum anderen Ende der U Bahn zu fahren und wieder zurück.
//   Knoten: :Stationmaximal
//   Kanten: r:SUBWAY

match (:Station)-[u:SUBWAY]->(:Station)
return distinct u.code, sum(u.length);


//!  3. WITH

//*  3.1 Geben Sie für jede U4 Station die Anzahl der Anbindungen an.
//   Knoten: s:Station
//   Kanten: :SUBWAY
//   Ausgabe: s.name, CONNECTIONS

match (s2:Station)<-[]-(s:Station)-[u:SUBWAY{code: "U4"}]-(:Station)
return distinct s.name, count(s2);


//*  3.2 Welche U4 Station liegt auf den meisten U-Bahnlinien.
//   Knoten: s:Station
//   Kanten: :SUBWAY
//   Ausgabe: s.name

match(:Station)-[:SUBWAY{code:"U4"}]-(s:Station)-[u:SUBWAY]-(:Station)
with distinct s.name as name, count(distinct u.code) as bre
with max(bre) as maxx
match(:Station)-[:SUBWAY{code:"U4"}]-(s:Station)-[u:SUBWAY]-(:Station)
with distinct s.name as name, count(distinct u.code) as bre, maxx
where bre = maxx
return name;


//*  3.3 Welche der U-Bahn Linien hat die längste Gesamtstrecke?
//   Knoten: s:Station, m:Metroline
//   Kanten: CONNECTED, CONTAINS

match (:Station)-[u:SUBWAY]->(s:Station)
with distinct u.code as code, sum(u.length) as summ
with max(summ) as maxx
match (:Station)-[u:SUBWAY]->(s:Station)
with distinct u.code as code, sum(u.length) as summ, maxx
where summ = maxx
return code;