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




//*   1.2 Finden Sie jene 10 Stationen die am stärksten frequentiert werden.
//    Geben Sie für jede Line aus, wieviele der gesuchten Stationen jene anfährt.
//    Ordnen Sie das Ergebnis absteigend nach der Zahl der Hubstationen.




//*   1.3 Finden Sie jene 10 Stationen, die als wichtigste Knotenpunkte im Netz identifiziert werden können. Wie weit sind die Knotenpunkte im Durchschnitt voneinander entfernt?




//!   2. GDS - Graph Data Science
//    Berechnen Sie eine Liste der 20 am stärksten frequentierten Stationen im Wiener Verkehrsnetz.
//    Geben Sie für jeden Bezirk an wieviele der angegebenen Stationen im entsprechendem
//    Bezirk liegen. Sortieren Sie die Ausgabe sortiert nach der Zahl absteigend.




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












