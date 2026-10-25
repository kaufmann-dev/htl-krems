WITH [
    ["Leopoldau", 21, "Floridsdorf", "Wien", "Großfeldsiedlung", 21, "Floridsdorf","Wien", "U1", 1.8, 125],
    ["Großfeldsiedlung", 21, "Floridsdorf","Wien", "Aderklaaer Straße", 21, "Floridsdorf","Wien", "U1", 0.8, 58],
    ["Aderklaaer Straße", 21, "Floridsdorf","Wien", "Rennbahnweg", 22, "Donaustadt","Wien", "U1", 0.8, 55],
    ["Rennbahnweg", 22, "Donaustadt","Wien", "Kagraner Platz", 22, "Donaustadt","Wien", "U1", 2.2, 153],
    ["Kagraner Platz",22, "Donaustadt","Wien", "Kagran", 22, "Donaustadt","Wien","U1", 0.2, 24],
    ["Kagran",22, "Donaustadt","Wien", "Alte Donau",22, "Donaustadt","Wien", "U1", 1, 43],
    ["Alte Donau",22, "Donaustadt","Wien", "Kaisermühlen-VIC",22, "Donaustadt","Wien", "U1", 1.4, 107],
    ["Kaisermühlen-VIC",22, "Donaustadt","Wien", "Donauinsel", 2, "Leopoldstadt","Wien", "U1", 1.2, 54],
    ["Donauinsel", 2, "Leopoldstadt","Wien","Vorgartenstraße",2, "Leopoldstadt","Wien", "U1", 2.1, 123],
    ["Vorgartenstraße",2, "Leopoldstadt","Wien", "Praterstern",2, "Leopoldstadt","Wien", "U1", 1.1, 67],
    ["Praterstern",2, "Leopoldstadt", "Wien","Nestroyplatz",2, "Leopoldstadt","Wien", "U1", 1.1, 64],
    ["Nestroyplatz",2, "Leopoldstadt","Wien", "Schwedenplatz", 1, "Innere Stadt","Wien", "U1", 1.2, 71],
    ["Schwedenplatz", 1, "Innere Stadt","Wien","Stephansplatz", 1, "Innere Stadt","Wien","U1", 1.14, 52],
    ["Stephansplatz", 1, "Innere Stadt","Wien","Karlsplatz",1, "Innere Stadt","Wien", "U1", 2.02, 112],
    ["Karlsplatz",1, "Innere Stadt","Wien", "Taubstummengasse",4, "Wieden","Wien", "U1", 2.2, 132],
    ["Taubstummengasse", 4, "Wieden","Wien","Wien Hauptbahnhof",4, "Wieden","Wien", "U1", 1.86, 86],
    ["Wien Hauptbahnhof",4, "Wieden","Wien", "Keplerplatz",10, "Favoriten","Wien", "U1", 1.99, 99],
    ["Keplerplatz",10, "Favoriten","Wien", "Reumannplatz",10, "Favoriten","Wien", "U1", 1.87, 100],
    ["Reumannplatz",10, "Favoriten","Wien", "Troststraße",10, "Favoriten","Wien", "U1", 2.05, 120],
    ["Troststraße",10, "Favoriten","Wien", "Altes Landgut",10, "Favoriten","Wien", "U1", 1.55, 67],
    ["Altes Landgut",10, "Favoriten","Wien", "Alaudagasse",10, "Favoriten","Wien", "U1", 1.6, 86],
    ["Alaudagasse",10, "Favoriten","Wien", "Neulaa",10, "Favoriten","Wien", "U1", 1.9, 125],
    ["Neulaa",10, "Favoriten","Wien", "Oberlaa",10, "Favoriten","Wien", "U1", 2.2, 142]
] as data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s);