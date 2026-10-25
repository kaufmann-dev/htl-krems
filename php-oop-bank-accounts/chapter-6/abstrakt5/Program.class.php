<?php 
include_once ("Person.class.php"); 

class Program { 
	public function __construct() { 
		Person::alarm(); 
		echo Person::VERSION; 
	} 
}
new Program();
?>