<?php
require_once("Kunde.class.php");
class Program
{
	public function __construct(){
		$this -> main();
	}

	function __destruct() {
			echo "<br />Objekt wird gel&ouml;scht...";
	}


  private function main(){
	  $kunde = new Kunde("Hans", "Dampf", 42, "Mann", "12345 Irgendwo, Irgendeinestrasse 42", new Konto(floatval("1023.34"), "Sparbuch"));

	  var_dump($kunde);
	
	  
  }
}
new Program();

?>
