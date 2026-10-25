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

call gds.betweenness.stream("mygraph")
YIELD nodeId, score
RETURN gds.util.asNode(nodeId).name AS name, score
ORDER BY name ASC





// -- --------------------------------------------------------------------------------- --
// -- 2.Beispiel) CQL Abfrage (30.Punkte)
// -- --------------------------------------------------------------------------------- --
// Vergleichen Sie die ersten 10 Bezirke mit den meisten Stationen, mit den den ersten
// 10 Bezirken die von meisten Linien gekreuzt werden. Welche Stationen liegen in
// beiden Mengen?

// Ausgabe: ["Landstraße", ....]







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



"as answer;


// 2) Nennen Sie die Kategorien der Neo4J GDS Bibliothek. Erklären Sie deren Einsatzschwerpunkt.
// Finden Sie 2 Paare von Algorithmen, aus unterschiedlichen Kategorien, die ähnliche Metriken
// berechnen. Diskutieren Sie Ihre Wahl.

return"



"as answer;


// 3) Nennen Sie die 3 Graphalgorithmen für die das Kantengewicht keinen Einfluss auf die
//    Berechnung des Ergebnisses hat.

return"



"as answer;