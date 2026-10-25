<?php
require_once("Kunde.class.php");
require_once("Mitarbeiter.class.php");


class Program
{
	public function __construct(){
		$this -> main();
	}

  private function main(){
	  $konto1 = new Konto(floatval("1023.34"), "Sparbuch");
	  $kunde1 = new Kunde("Hans", "Dampf", 42, "Mann", "12345 Irgendwo, Irgendeinestrasse 42", $konto1);
	  $kunde1 -> geschaeftsvorfall();
	  $mitarbeiter1 = new Mitarbeiter("Fred", "Feuerstein", 41, "Mann", "666 Steinhausen, Steinstrasse 42", 4711);
      $mitarbeiter1 -> kontaktwunsch();
  }
}
new Program();
?>
