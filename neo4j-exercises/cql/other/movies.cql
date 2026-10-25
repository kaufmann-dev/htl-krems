// ####################################################################
// alle movies mit tom cruise als actor
// --------------------------------------------------------------------

	match(p:Person{name:"Tom Cruise"})-[ACTED_IN]->(m:Movie)
	return m.title;

// ____________________________________________________________________
// Geben Sie alle Filme in ein array
// --------------------------------------------------------------------

	match(p:Person{name:"Tom Cruise"})-[r:ACTED_IN]->(m:Movie)
	return collect(m.title) as movies;



// ####################################################################
// alle filme wo produzent und director die gleiche person sind
// --------------------------------------------------------------------

	match (p:Person)-[:DIRECTED]->(m:Movie)<-[:PRODUCED]-(p)
	return m.title;



// ####################################################################
// finden sie alle schauspieler die an mehreren filmen
// mitgeholfen haben
// --------------------------------------------------------------------

	match (p:Person)-[:ACTED_IN]->(y:Movie)
	match (p)-[:ACTED_IN]->(x:Movie)
	where x<>y
	return p.name;



// ####################################################################
// berechnet für jeden film wie viele darsteller mitspielen
// ausgabe schauspieler und movies
// --------------------------------------------------------------------

  	match (p:Person)-[:ACTED_IN]->(m:Movie)
  	return m.title, count(p) as actors;

// ____________________________________________________________________
// ohne count
// --------------------------------------------------------------------

	match (p:Person)-[:ACTED_IN]->(m:Movie)
	return m.title,
	       reduce(i=0, person in collect(1) | i + person);

	match (p:Person)-[:ACTED_IN]->(m:Movie)
	return m.title, size((collect(p))) as actors;