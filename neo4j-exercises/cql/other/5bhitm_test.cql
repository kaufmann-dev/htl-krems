with [
    ["A", "B", 50],
    ["A", "C", 50],
    ["A", "D", 100],
    ["B", "D", 40],
    ["C", "D", 40],
    ["C", "E", 40],
    ["D", "E", 30],
    ["D", "F", 80],
    ["E", "F", 40]
] as data
unwind data as row
merge (:Station{name:"A"})
merge (:Station{name:"B"})
merge (:Station{name:"C"})
merge (:Station{name:"D"})
merge (:Station{name:"E"})
merge (:Station{name:"F"})
merge (:Station{name: row[0]})-[:SUBWAY{source: row[0], target: row[1], distance: row[2]}] - (:Station{name: row[1]});

match (s:Station{name:"A"})
match (s2:Station{name:"F"})
call gds.shortestPath.dijkstra.stream("viennastation", {
    sourceNode: s,
    targetNode: s2,
    relationshipWeightProperty: "distance"
})
yiel path
return path;


1)
match (s:Station)-[u:SUBWAY|EXPRESSWAY]->(:Station)
with DISTINCT s.district as district, count(u) as cc
with collect(cc) as cc
with apoc.coll.max(cc) as maxx
match (s:Station)-[u:SUBWAY|EXPRESSWAY]->(:Station)
with DISTINCT s.district as district, count(u) as cc, maxx
where cc = maxx
return district;

match(s:Station)-[:SUBWAY|EXPRESSWAY|TRAMWAYREGIONAL_EXPRESS]->(x:Station)
with s.name as name, count(x) as stations
order by stations desc
limit 5
with collect (name) as stations
match(s:Station)-[u:SUBWAY|EXPRESSWAY|TRAMWAYREGIONAL_EXPRESS]->(x:Station)
with s.district as name, stations, collect(x.name) as cc
with apoc.coll.intersection(cc, stations) as inters, name
where size(inters) > 0
return name, inters;

match(s:Station)-[:SUBWAY|EXPRESSWAY|TRAMWAYREGIONAL_EXPRESS]->(x:Station)
with s.name as name, collect(x) as stations
order by size(stations) desc
limit 5
with collect (name) as stations
match(s:Station)-[u:SUBWAY|EXPRESSWAY|TRAMWAYREGIONAL_EXPRESS]->(x:Station)
with s.district as district, collect(x.name) as cc, stations
with district, cc, stations
with district, apoc.coll.intersection(stations, cc) as lole
return district, lole;

match(s:Station)-[:SUBWAY|EXPRESSWAY|TRAMWAYREGIONAL_EXPRESS]->(x:Station)
with s.name as name, count(x) as stations
order by stations desc
limit 5
with collect (name) as stations
match(s:Station)-[u:SUBWAY|EXPRESSWAY|TRAMWAYREGIONAL_EXPRESS]->(x:Station)
with s.district as name, stations, collect(x.name) as cc
with apoc.coll.intersection(cc, stations) as inters, name
where size(inters) > 0
with name as h1
match (s:Station)-[u:SUBWAY|EXPRESSWAY]->(:Station)
with DISTINCT s.district as district, count(u) as cc, h1
with collect(cc) as cc, h1
with apoc.coll.max(cc) as maxx, h1
match (s:Station)-[u:SUBWAY|EXPRESSWAY]->(:Station)
with DISTINCT s.district as district, count(u) as cc, maxx, h1
where cc = maxx
with district as h2, h1
return apoc.coll.duplicates(collect(h1)+ collect(h2));