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

//!   1. GDS - Graph Data Science

//*   1.1 Die Stadt Wien wurde als Austragungsort für ein zukünftiges sportliches Großereignis ausgewählt.
//    Identifizieren Sie alle Stationen, die heuristisch gesehen am stärksten frequentiert werden.

CALL gds.betweenness.stream("viennatraffic")
YIELD nodeId, score
RETURN gds.util.asNode(nodeId).name as STATION, score as SCORE
ORDER BY SCORE DESC;


//*   1.2 Finden Sie jene 10 Stationen die am stärksten frequentiert werden.
//    Geben Sie für jede Line aus, wieviele der gesuchten Stationen jene anfährt.
//    Ordnen Sie das Ergebnis absteigend nach der Zahl der Hubstationen.

CALL gds.betweenness.stream("viennatraffic")
YIELD nodeId, score
WITH gds.util.asNode(nodeId) as STATION, score as SCORE
ORDER BY SCORE DESC
WITH collect(STATION.name)[0..10] as STATIONS
MATCH (s:Station)-[r:TRAM|SUBWAY|TRAIN|TRAM|EXPRESSWAY]-(t:Station)
WITH r.code as CODE, collect(s.name) as HUBS, STATIONS
RETURN CODE, reduce(i = 0, s in apoc.coll.intersection(HUBS, STATIONS)| i + 1) AS JUNCTIONS
ORDER BY JUNCTIONS DESC;


//*   1.3 Finden Sie jene 10 Stationen, die als wichtigste Knotenpunkte im Netz identifiziert werden können. Wie weit sind die Knotenpunkte im Durchschnitt voneinander entfernt?

CALL gds.degree.stream("viennatraffic")
YIELD nodeId, score
WITH gds.util.asNode(nodeId) AS NODE, score AS SCORE
ORDER BY SCORE DESC
WITH apoc.coll.combinations(collect(NODE)[1..10], 2) as ROUTES
UNWIND ROUTES AS route
WITH route as route
CALL gds.shortestPath.dijkstra.stream(
    "viennatraffic", {
        sourceNode: route[0],
        targetNode: route[1],
        relationshipWeightProperty :"length"
    }
)
YIELD totalCost
RETURN avg(totalCost) as AVERAGE_DISTANCE;


//!   2. GDS - Graph Data Science
//    Berechnen Sie eine Liste der 20 am stärksten frequentierten Stationen im Wiener Verkehrsnetz.
//    Geben Sie für jeden Bezirk an wieviele der angegebenen Stationen im entsprechendem
//    Bezirk liegen. Sortieren Sie die Ausgabe sortiert nach der Zahl absteigend.

CALL gds.betweenness.stream("viennatraffic")
YIELD nodeId, score
WITH  gds.util.asNode(nodeId).name as name, score as score
ORDER BY score desc limit 20
WITH collect (name) AS CRITICAL_STATIONS
MATCH (s:Station)-[r:SUBWAY|EXPRESSWAY|TRAMWAY|REGIONAL_EXPRESS]->(t:Station)
WITH s.district as DISTRICT, collect(DISTINCT s.name) as DISTRICT_STATIONS, CRITICAL_STATIONS as CRITICAL_STATIONS
RETURN DISTRICT, size(apoc.coll.intersection(DISTRICT_STATIONS, CRITICAL_STATIONS)) as CRITICAL_AMOUNT
ORDER BY CRITICAL_AMOUNT DESC;


//!   3. GDS - Graph Data Science (Maturalevel)
//    Für eine Stadtrundfahrt in Wien möchte eine Touristengruppe die folgenden Orte besuchen, die sich in der Nähe folgender Stationen befinden. Finden Sie eine kürzeste Route die alle gewünschten Punkte miteinander verbindet.
//    Stationen: Wien Hauptbahnhof, Praterstern, Rathaus, Karlsplatz

//*   3.1 Berechnenen Sie alle möglichen Permutationen der Elemente des folgenden Arrays. Jedes Element im Array kommt nur einmal vor.
//    z.B.:
//    [1,4,5,7] -> [[1,4,5,7],[1,5,4,7],[1,7,5,4], [7,5,4,1], ....]
//    Hinweis: Folgende Funktionen könnten hilfreich sein:
//             - apoc.coll.combinations
//             - apoc.coll.disjunction
//             - apoc.coll.flatten
//             - apoc.coll.insert




//*   3.2 Berechnen Sie für alle möglichen Permutationen der Stationenliste die Länge der Strecke. Sortieren Sie das Ergebnis nach den Kosten aufsteigend.
//    Ausgabe:
//      1 - [["Heiligenstadt", "Längenfeldgasse"], ["Längenfeldgasse", "Westbahnhof"], ["Westbahnhof", "Volkstheater"], ["Volkstheater", "Spittelau"], ["Spittelau", "Karlsplatz"]] , 65.38
//      2 - [["Praterstern", "Karlsplatz"], ["Karlsplatz", "Rathaus"], ["Rathaus", "Wien Hauptbahnhof"]], 16.72
//    Lösung:
//      1 - [["Heiligenstadt", "Spittelau"], ["Spittelau", "Längenfeldgasse"], ["Längenfeldgasse", "Westbahnhof"], ["Westbahnhof", "Volkstheater"], ["Volkstheater", "Karlsplatz"]] 18.8
//      2 - [["Praterstern", "Rathaus"], ["Rathaus", "Karlsplatz"], ["Karlsplatz", "Wien Hauptbahnhof"]], 14.76

MATCH (s1:Station{name:"Wien Hauptbahnhof"})
MATCH (s2:Station{name:"Praterstern"})
MATCH (s3:Station{name:"Karlsplatz"})
MATCH (s4:Station{name:"Rathaus"})
WITH [s1,s2,s3,s4] as data
UNWIND range(1, size(data)) as i
WITH collect(data) as data1, data as data
UNWIND [i in apoc.coll.combinations(apoc.coll.flatten(data1),size(data)) where apoc.coll.containsAll(i, data)] as route
with distinct route
with apoc.coll.pairsMin(route) as pairs
    unwind pairs as pair
    CALL gds.shortestPath.dijkstra.stream(
        "viennatraffic", {
        sourceNode : pair[0],
        targetNode : pair[1],
        relationshipWeightProperty : "length"
        }
    )
    YIELD sourceNode, totalCost
RETURN [route in pairs| [s in route|s.name]], reduce(i = 0.0, cost in collect(totalCost)| i + cost) as cost
ORDER BY cost asc;










