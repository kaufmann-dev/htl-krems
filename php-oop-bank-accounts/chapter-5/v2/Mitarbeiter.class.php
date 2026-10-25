<?php
require_once("Person.class.php");
class Mitarbeiter extends Person
{
  private $personalnr = 0;
 
  public function __construct(string $vorname, string $nachname, int $alter, string $geschlecht, string $adresse, int $personalnr) {
	  parent :: __construct($vorname, $nachname, $alter, $geschlecht, $adresse);
  
  $this -> setPersonalnr($personalnr);
  }
  
      public function setPersonalnr(string $personalnr){
    $this -> personalnr = $personalnr;
  }
  public function getPersonalnr(): string{
    return $this -> personalnr;
  }

  public function __destruct() {
		echo "<br />Objekt mit der Superklasse " . get_parent_class($this) ." wird gel&ouml;scht...";
  }

}
?>
