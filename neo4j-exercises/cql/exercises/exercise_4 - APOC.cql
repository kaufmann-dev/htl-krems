//!   0. APOC Abfragen

//*   0.1 Ermitteln Sie für jede Station den Knotengrad und speichern Sie ihn in einer Property degree.

MATCH (s:Station)
WITH s as station, apoc.node.degree(s) as degree
CALL apoc.create.setProperty(station, "degree", degree)
YIELD node
RETURN node;


//*   0.2 Finden Sie für die U4 die Station mit den meisten Anbindungen

MATCH (n:Station)-[r:SUBWAY{code:"U4"}]->(:Station)
WITH r.code as code, apoc.coll.max(collect(n.degree)) as value
MATCH (n:Station)-[r:SUBWAY{code:"U4"}]->(:Station)
WHERE n.degree = value
RETURN distinct n.name;


//!  1. Cypher Abfragen, APOC Funktionen

//*  1.1 Wieviele Bezirke sind für das Wiener Verkehrsnetz abgebildet?

match (s:Station{state:"Wien"})
return count(distinct s.plz);


//*  1.2 Vergleichen Sie die Wiener Bezirke enthalten im Graphen mit folgender Liste. Welche der im Graphen gegebenen Bezirke finden sich nicht in der Liste?
//   ["Innere Stadt", "Leopoldstadt", "Landstraße", "Wieden", "Margareten", "Mariahilf",
//    "Neubau", "Josefstadt", "Alsergrund", "Simmering", "Meidling",
//    "Hietzing", "Penzing", "Rudolfsheim-Fünfhaus", "Ottakring", "Währing",
//    "Döbling", "Brigittenau", "Floridsdorf", "Donaustadt", "Liesing", "Shibuya", "Shinjuku"]

// Stimmen nicht überein
WITH ["Innere Stadt", "Leopoldstadt", "Landstraße", "Wieden", "Margareten", "Mariahilf", "Neubau", "Josefstadt", "Alsergrund", "Simmering", "Meidling", "Hietzing", "Penzing", "Rudolfsheim-Fünfhaus", "Ottakring", "Währing", "Döbling", "Brigittenau", "Floridsdorf", "Donaustadt", "Liesing", "Shibuya", "Shinjuku"] as data
MATCH (s:Station{state:"Wien"})
WITH collect(distinct s.district) as districts, data
return apoc.coll.disjunction(data, districts);

// Nicht in der Liste
WITH ["Innere Stadt", "Leopoldstadt", "Landstraße", "Wieden", "Margareten", "Mariahilf", "Neubau", "Josefstadt", "Alsergrund", "Simmering", "Meidling", "Hietzing", "Penzing", "Rudolfsheim-Fünfhaus", "Ottakring", "Währing", "Döbling", "Brigittenau", "Floridsdorf", "Donaustadt", "Liesing", "Shibuya", "Shinjuku"] as data
MATCH (s:Station{state:"Wien"})
WITH collect(distinct s.district) as districts, data
return apoc.coll.subtract(districts, data);

// Nicht im Graphen Version 1
WITH ["Innere Stadt", "Leopoldstadt", "Landstraße", "Wieden", "Margareten", "Mariahilf", "Neubau", "Josefstadt", "Alsergrund", "Simmering", "Meidling", "Hietzing", "Penzing", "Rudolfsheim-Fünfhaus", "Ottakring", "Währing", "Döbling", "Brigittenau", "Floridsdorf", "Donaustadt", "Liesing", "Shibuya", "Shinjuku"] as data
MATCH (s:Station{state:"Wien"})
WITH collect(distinct s.district) as districts, data
return apoc.coll.subtract(data, districts);

// Nicht im Graphen Version 2
WITH ["Innere Stadt", "Leopoldstadt", "Landstraße", "Wieden", "Margareten", "Mariahilf", "Neubau", "Josefstadt", "Alsergrund", "Simmering", "Meidling", "Hietzing", "Penzing", "Rudolfsheim-Fünfhaus", "Ottakring", "Währing", "Döbling", "Brigittenau", "Floridsdorf", "Donaustadt", "Liesing", "Shibuya", "Shinjuku"] as data
MATCH (s:Station{state:"Wien"})
WITH apoc.coll.intersection(collect(distinct s.district), data) as districts, data
return apoc.coll.disjunction(data, districts);


//*  1.3 Geben Sie für folgende Wiener Bezirke die Zahl an Stationen an.
//    ["Innere Stadt", "Leopoldstadt", "Landstraße", "Wieden", "Margareten", "Mariahilf", "Döbling", "Brigittenau", "Floridsdorf", "Donaustadt", "Liesing"]
//   Ausgabe:  [{"item": "Floridsdorf","count": 6}, {"item": "Donaustadt","count": 16}, ...]

WITH ["Innere Stadt", "Leopoldstadt", "Landstraße", "Wieden", "Margareten", "Mariahilf", "Döbling", "Brigittenau", "Floridsdorf", "Donaustadt", "Liesing"] as data
MATCH (s:Station{state:"Wien"})
WITH collect(s.district) as districts, data as data
RETURN apoc.coll.frequencies([d in districts where apoc.coll.contains(data, d)]);


//!   2. Cypher Abfragen, APOC Funktionen

//*   2.1 Berechnenen Sie alle möglichen Permutationen der Elemente des folgenden Arrays.
//    Hinweis: Sie können davon ausgehen dass jedes Element im Array nur einmal vorkommt.
//    z.B.: [1,4,5,7] -> [[1,4,5,7],[1,5,4,7],[1,7,5,4], [7,5,4,1], ....]

WITH [1,4,5,7] as data
UNWIND range(1, size(data)) as i
WITH collect(data) as data1, data
UNWIND [i in apoc.coll.combinations(apoc.coll.flatten(data1),size(data)) where apoc.coll.containsAll(i, data)] as row
RETURN distinct row;


//!  3. Cypher Abfragen, APOC Funktionen

//*  3.1 Folgende Stationen stellen die 20 wichtigsten Knotenpunkte im Wiener Verkehrsnetz dar. Geben Sie für jeden Bezirk an wieviele der angegebenen Stationen im entsprechendem Bezirk liegen. Sortieren Sie die Ausgabe sortiert nach der Zahl absteigend.
//   ["Wien Hauptbahnhof", "Wien Meidling", "Praterstern", "Heiligenstadt", "Handelskai", "Matzleinsdorfer Platz", "Volkstheater", "Westbahnhof", "Michelbeuern AKH", "Traisengasse", "Karlsplatz", "Floridsdorf", "Staglgasse", "Mariahilfer Straße, Geibelgasse", "Rennweg", "Schottenring", "Rustengasse", "Quartier Belvedere", "Rathaus", "Wien Mitte"]

WITH ["Wien Hauptbahnhof", "Wien Meidling", "Praterstern", "Heiligenstadt", "Handelskai", "Matzleinsdorfer  Platz", "Volkstheater", "Westbahnhof", "Michelbeuern AKH", "Traisengasse", "Karlsplatz", "Floridsdorf", "Staglgasse", "Mariahilfer Straße, Geibelgasse", "Rennweg", "Schottenring", "Rustengasse", "Quartier Belvedere", "Rathaus", "Wien Mitte"] AS data
MATCH (s:Station)-[r:SUBWAY|EXPRESSWAY|TRAMWAY|REGIONAL_EXPRESS]->(t:Station)
WITH s.district as DISTRICT, collect(DISTINCT s.name) as DISTRICT_STATIONS, data as CRITICAL_STATIONS
RETURN DISTRICT, size(apoc.coll.intersection(DISTRICT_STATIONS, CRITICAL_STATIONS)) as CRITICAL_AMOUNT
ORDER BY CRITICAL_AMOUNT DESC;