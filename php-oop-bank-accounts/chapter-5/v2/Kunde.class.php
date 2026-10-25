<?php
require_once("Person.class.php");
require_once("Konto.class.php");
 
class Kunde extends Person
{
  private $konto = null;

   public function __construct(string $vorname, string $nachname, int $alter, string $geschlecht, string $adresse, Konto $konto) {
    parent :: __construct($vorname, $nachname, $alter, $geschlecht, $adresse);
  //  parent :: __construct();
    $this -> konto = $konto;
  }
  
  public function getKonto(): Konto{
    return $this -> konto;
  }

  public function __destruct() {
		echo "<br />Objekt mit der Superklasse " . get_parent_class($this) ." wird gel&ouml;scht...";
  }

}
?>
