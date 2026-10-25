<?php
require_once("Kunde.class.php");
require_once("Mitarbeiter.class.php");


class Program
{
	public function __construct(){
		$this -> main();
	}

	function __destruct() {
			echo "<br />Objekt wird gel&ouml;scht...";
	}

  private function main(){
	  $konto1 = new Konto(floatval("1023.34"), "Sparbuch");
	  $kunde1 = new Kunde("Hans", "Dampf", 42, "Mann", "12345 Irgendwo, Irgendeinestrasse 42", $konto1);
	  $mitarbeiter1 = new Mitarbeiter("Fred", "Feuerstein", 41, "Mann", "666 Steinhausen, Steinstrasse 42", 4711);
	  var_dump($kunde1);
	  var_dump($mitarbeiter1);
  }
}
new Program();
?>
