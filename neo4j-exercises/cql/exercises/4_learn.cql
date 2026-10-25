//!   0. APOC Abfragen

//*   0.1 Ermitteln Sie für jede Station den Knotengrad und speichern Sie sie ihn in einer Property degree.

MATCH(s:Station)
with s, apoc.node.degree(s) as degree
CALL apoc.create.setProperty(s, "degree", degree)
YIELD node
RETURN node;


//*   0.2 Finden Sie für die U4 die Station mit den meisten Anbindungen

match(:Station)-[u:SUBWAY{code:"U4"}]-(s:Station)-[]->(x:Station)
with distinct s.name as name, count(x) as cc
with collect(cc) as coll
with apoc.coll.max(coll) as maxx
match(:Station)-[u:SUBWAY{code:"U4"}]-(s:Station)-[]->(x:Station)
with distinct s.name as name, count(x) as cc, maxx
where cc = maxx
return name;


//!  1. Cypher Abfragen, APOC Funktionen

//*  1.1 Wieviele Bezirke sind für das Wiener Verkehrsnetz abgebildet?

match (s:Station{state:"Wien"})
return count(distinct s.plz);


//*  1.2 Vergleichen Sie die Wiener Bezirke enthalten im Graphen mit folgender Liste. Welche der im Graphen gegebenen Bezirke finden sich nicht in der Liste?
//   ["Innere Stadt", "Leopoldstadt", "Landstraße", "Wieden", "Margareten", "Mariahilf", "Neubau", "Josefstadt", "Alsergrund", "Simmering", "Meidling", "Hietzing", "Penzing", "Rudolfsheim-Fünfhaus", "Ottakring", "Währing", "Döbling", "Brigittenau", "Floridsdorf", "Donaustadt", "Liesing", "Shibuya", "Shinjuku"]




//*  1.3 Geben Sie für folgende Wiener Bezirke die Zahl an Stationen an.
//    ["Innere Stadt", "Leopoldstadt", "Landstraße", "Wieden", "Margareten", "Mariahilf", "Döbling", "Brigittenau", "Floridsdorf", "Donaustadt", "Liesing"]
//   Ausgabe:  [{"item": "Floridsdorf","count": 6}, {"item": "Donaustadt","count": 16}, ...]




//!   2. Cypher Abfragen, APOC Funktionen

//*   2.1 Berechnenen Sie alle möglichen Permutationen der Elemente des folgenden Arrays.
//    Hinweis: Sie können davon ausgehen dass jedes Element im Array nur einmal vorkommt.
//    z.B.: [1,4,5,7] -> [[1,4,5,7],[1,5,4,7],[1,7,5,4], [7,5,4,1], ....]





//!  3. Cypher Abfragen, APOC Funktionen

//*  3.1 Folgende Stationen stellen die 20 wichtigsten Knotenpunkte im Wiener Verkehrsnetz dar. Geben Sie für jeden Bezirk an wieviele der angegebenen Stationen im entsprechendem Bezirk liegen. Sortieren Sie die Ausgabe sortiert nach der Zahl absteigend.
//   ["Wien Hauptbahnhof", "Wien Meidling", "Praterstern", "Heiligenstadt", "Handelskai", "Matzleinsdorfer Platz", "Volkstheater", "Westbahnhof", "Michelbeuern AKH", "Traisengasse", "Karlsplatz", "Floridsdorf", "Staglgasse", "Mariahilfer Straße, Geibelgasse", "Rennweg", "Schottenring", "Rustengasse", "Quartier Belvedere", "Rathaus", "Wien Mitte"]

