<?php 

include_once ("Person.class.php"); 

class Program { 
	public function __construct() { 
		echo Person::VORNAME."<hr />"; 
		echo Metainfos::NACHNAME."<hr />"; 
		$mensch = new Person(); 
		$mensch -> chatten(); 
		$mensch -> telefonieren(); 
	} 
} 
new Program(); 
?> 
