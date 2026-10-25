WITH [
    ["Obersdorfstraße", 1220, "Donaustadt", "Wien", "Trondheimgasse", 212201, "Donaustadt","Wien", "U1", 1.6, 118],
    ["Trondheimgasse", 1220, "Donaustadt","Wien", "Kapellenweg", 1220, "Donaustadt","Wien", "U1", 1.8, 126],
    ["Kapellenweg", 1220, "Donaustadt","Wien", "Donauspital", 1220, "Donaustadt","Wien", "U1", 1.1, 83],
    ["Donauspital", 1220, "Donaustadt","Wien", "Hardegasse", 1220, "Donaustadt","Wien", "U1", 0.9, 100],
    ["Hardegasse",1220, "Donaustadt","Wien", "Langobardenstraße", 1220, "Donaustadt","Wien","U1", 1.5, 111],
    ["Langobardenstraße",1220, "Donaustadt","Wien", "Konstanziagasse",1220, "Donaustadt","Wien", "U1", 1.3, 95],
    ["Konstanziagasse",1220, "Donaustadt","Wien", "Erzherzog-Karl-Straße",1220, "Donaustadt","Wien", "U1", 1.2, 88],
    ["Erzherzog-Karl-Straße",1220, "Donaustadt","Wien", "Polgarstraße", 1220, "Donaustadt","Wien", "U1", 1.8, 121],
    ["Polgarstraße", 1220, "Donaustadt","Wien","Donaustadtstraße",1220, "Donaustadt","Wien", "U1", 2.9, 185],
    ["Donaustadtstraße",1220, "Donaustadt","Wien", "Arminenstraße",1220, "Donaustadt","Wien", "U1", 1.1, 77],
    ["Arminenstraße",1220, "Donaustadt", "Wien","Kagraner Brücke",1220, "Donaustadt","Wien", "U1", 1.3, 89],
    ["Kagraner Brücke",1220, "Donaustadt","Wien", "Donauzentrum", 1220, "Donaustadt","Wien", "U1", 1.1, 79],
    ["Donauzentrum", 1220, "Donaustadt","Wien","Kagran", 1220, "Donaustadt","Wien","U1", 1.8, 123],
    ["Kagran", 1220, "Donaustadt","Wien","Prandaugasse",1220, "Donaustadt","Wien", "U1", 1.2, 86],
    ["Prandaugasse",1220, "Donaustadt","Wien", "Josef-Baumann-Gasse",1220, "Donaustadt","Wien", "U1", 2.0, 146],
    ["Josef-Baumann-Gasse", 1220, "Donaustadt","Wien","Carminweg",1210, "Floridsdorf","Wien", "U1", 1.7, 120],
    ["Carminweg",1210, "Floridsdorf","Wien", "Fultonstraße",1210, "Floridsdorf","Wien", "U1", 1.3, 99],
    ["Fultonstraße",1210, "Floridsdorf","Wien", "Hoßplatz",1210, "Floridsdorf","Wien", "U1", 2.5, 166],
    ["Hoßplatz",1210, "Floridsdorf","Wien", "Floridsdorf",1210, "Floridsdorf","Wien", "U1", 1.8, 131]
] as data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s);