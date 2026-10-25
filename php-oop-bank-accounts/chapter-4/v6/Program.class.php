<?php
require_once("Kunde.class.php");
class Program
{
	public function __construct(){
		$this -> main();
	}
  private function main(){
	  $kunde = new Kunde("Hans", "Dampf", 42, "Mann", "12345 Irgendwo, Irgendeinestrasse 42", new Konto(floatval("1023.34"), "Sparbuch"));
	  // $kunde ->__construct ("Otto", "Dort", 23, "Mann", "12346 Irgendwas, Irgendeineanderestrasse 4711", new Konto(floatval("4023.34"), "Sparbuch"));

	  var_dump($kunde);
	
	  
  }
}
$main = new Program();

?>
