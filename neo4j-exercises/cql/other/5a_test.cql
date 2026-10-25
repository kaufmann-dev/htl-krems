// -- --------------------------------------------------------------------------------- --
// -- 1.Beispiel) CQL Abfrage (40.Punkte)
// -- --------------------------------------------------------------------------------- --

// Vergleichen Sie die 10 am stärksten frequentierten Stationen des Wiener Verkehrsverbundes mit den 10 Wiener Stationen, die die meisten Verbindungen haben. Geben Sie jene Stationen aus, die sowohl zu den am stärksten Frequentierten als auch zu jenen mit den meisten Verbindungen, zu rechnen sind.

// Ausgabe: ["Karlsplazt", ....]

CALL gds.graph.project.cypher(
   "mygraph",
   "MATCH(s:Station) RETURN id(s) as id, labels(s) as labels",
   "MATCH(s1:Station)-[r:SUBWAY]->(s2:Station)
   RETURN id(s1) as source,
          id(s2) as target,
          type(r) as type,
          coalesce(r.length, 0) as distance,
          coalesce(r.duration,0) as duration",
          {
              validateRelationships: false
          } 
)

call gds.degree.stream("mygraph")
yield nodeId, score
with gds.util.asNode(nodeId).name as name, score
order by score desc
with collect(name)[0..10] as names1
call gds.betweenness.stream("mygraph")
yield nodeId, score
with gds.util.asNode(nodeId).name as name, score, names1
order by score desc
with collect(name)[0..10] as names, names1
return apoc.coll.intersection(names, names1)





// -- --------------------------------------------------------------------------------- --
// -- 2.Beispiel) CQL Abfrage (30.Punkte)
// -- --------------------------------------------------------------------------------- --
// Vergleichen Sie die ersten 10 Bezirke mit den meisten Stationen, mit den den ersten
// 10 Bezirken die von meisten Linien gekreuzt werden. Welche Stationen liegen in
// beiden Mengen?

// Ausgabe: ["Landstraße", ....]

Match (s)-[r]-(s2)
with s.district as district, size(collect(distinct r.code)) as sizes
order by sizes desc
with collect(district)[0..10] as collect1
Match (s)-[r]-(s2)
with s.district as district, size(collect(distinct s.name)) as sizes, collect1
order by sizes desc
with collect(district)[0..10] as collect, collect1
return apoc.coll.intersection(collect, collect1)





// -- --------------------------------------------------------------------------------- --
// -- 3.Beispiel) Graphentheorie (30.Punkte)
// -- --------------------------------------------------------------------------------- --
// 1) Ein Handelsreisender stellt in Wien an mehrere Stationen Waren zu. Erklären Sie
//    theoretisch angelehnt an Cypher in welcher Abfolge er die Stationen anfahren soll,
//    um die benötigte Zeit zu minimieren.

//    Hinweis: Abstrahieren Sie eine Klauselbezogene Beschreibung einer CQL Abfrage

//    z.B.: 1) Lege einen virtuellen Graphen für das Wiener Verkehrsnetz an.
//          2) Erstelle eine Liste mit allen gewünschten Stationen
//          3) Iteriere über die Liste ...

return"

Pro Station hol ich mir den Knoten
Perumutationen ausrechnen der Stations Knoten
Pairs aus der Perumutationen bilden
unwind auf pairs
call: source target auf die paare
return: die totalcosts summieren und gleichzeitig auf die pairs groupieren
order by: sortieren nach der summe

"as answer;


// 2) Nennen Sie die Kategorien der Neo4J GDS Bibliothek. Erklären Sie deren Einsatzschwerpunkt.
// Finden Sie 2 Paare von Algorithmen aus unterschiedlichen Kategorien, die ähnliche Metriken
// berechnen. Diskutieren Sie Ihre Wahl.

return"

Path finding, Centrality, Community, Similiarity

Triangle Count, Degree Centrality
Bei beiden werden die ein und ausgehenden Knoten stark berücksichtigt.
Bei triangle die dreiecke also ein und ausgehende.
beim degree alle verbindungen.

"as answer;


// 3) Nennen Sie die 3 Graphalgorithmen für die das Kantengewicht keinen Einfluss auf die
//    Berechnung des Ergebnisses hat.

return"

Möglich bei Source Target wenn relationshipWeightProperty ist null
Page rank
betweenness centrality

"as answer;