//!  1. MATCH Klausel

//*  1.1 Welche U-Bahn Linien fahren in Wien

//   Knoten: :Station
//   Kanten: r:SUBWAY
//   Ausgabe: r.code

match(:Station{state:"Wien"})-[r:SUBWAY]->(:Station)
return distinct r.code;


//*  1.2 Geben Sie alle Stationen der U4 bzw. U6 aus
//   Knoten: t:Station
//   Kanten: :SUBWAY
//   Ausgabe: t.name

match(r:Station)-[s:SUBWAY]-(:Station)
where s.code = "U4" OR s.code = "U6"
return distinct r.name;


//*  1.3 Geben Sie alle Stationen aus, die von der U2 und der U4 angefahren werden.
//   Knoten: t:Station
//   Kanten: :SUBWAY
//   Ausgabe: t.name

match(:Station)-[:SUBWAY{code:"U2"}]-(r:Station)-[:SUBWAY{code:"U4"}]-(:Station)
return distinct r.name;


//*  1.4 Welche Stationen sind bis zu 2 Haltestellen von Spittelau entfernt?
//   Hinweis: Spittelau selbst sollte nicht im Ergebnis enthalten sein.
//   Knoten: t:Station
//   Kanten:
//   Ausgabe: t.name

match (r:Station)-[:SUBWAY*2]-(:Station{name:"Spittelau"})
where r.name <> "Spittelau"
return distinct r.name;


//!  2. Aggregatfunktionen

//*  2.1 Geben Sie für jede U-Bahn Linie die Anzahl der Stationen aus.
//   Knoten: s:Station
//   Kanten: r:SUBWAY
//   Ausgabe: r.code, count(s)

match (:Station)-[s:SUBWAY]-(r:Station)
return distinct s.code, count(distinct r);


//*  2.2 Geben Sie für jede U-Bahn Linie die Länge der Strecke aus.
//   Geben Sie zusätzlich an wie lange es dauert von einem Ende der U Bahn bis zum anderen Ende der U Bahn zu fahren und wieder zurück.
//   Knoten: :Stationmaximal
//   Kanten: r:SUBWAY

match (:Station)-[u:SUBWAY]-(:Station)
return
    distinct u.code,
    round(sum(u.time)/60, 1) as HinUndZurückInMin,
    round(reduce(i=0,length in collect(u.length)|i+length)/2, 1) as StreckenlängeInKM;




//!  3. WITH

//*  3.1 Geben Sie für jede U4 Station die Anzahl der Anbindungen an.
//   Knoten: s:Station
//   Kanten: :SUBWAY
//   Ausgabe: s.name, CONNECTIONS

match (x:Station)-[]-(s:Station)-[:SUBWAY{code:"U4"}]-(:Station)
return s.name, count(distinct x) as Connections;


//*  3.2 Welche U4 Station liegt auf den meisten U-Bahnlinien.
//   Knoten: s:Station
//   Kanten: :SUBWAY
//   Ausgabe: s.name

match(:Station)-[u:SUBWAY]-(s:Station)-[:SUBWAY{code:"U4"}]-(:Station)
with s.name as name, count(distinct u.code) as anbindungen
with max(anbindungen) as maxx
match(:Station)-[u:SUBWAY]-(s:Station)-[:SUBWAY{code:"U4"}]-(:Station)
with s.name as name, count(distinct u.code) as anbindungen, maxx
where anbindungen = maxx
return name, anbindungen;


//*  3.3 Welche der U-Bahn Linien hat die längste Gesamtstrecke?
//   Knoten: s:Station, m:Metroline
//   Kanten: CONNECTED, CONTAINS

match
    (:Station)-[c:SUBWAY]-(u:Station)
with
	distinct c.code as code,
	sum(c.length)/2 as strecke
with
    max(strecke) as maxx
match
    (:Station)-[c:SUBWAY]-(u:Station)
with
	distinct c.code as code,
	sum(c.length)/2 as strecke, maxx
where
    strecke = maxx
return
    code,
    strecke;