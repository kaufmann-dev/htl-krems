<?php
require_once("Konto.class.php");
class Kunde
{
  public $vorname = "";
  public $nachname = "";
  public $alter = 0;
  public $geschlecht = "";
  public $adresse = "";
  public $konto = null;
 
  public function __construct(string $vorname, string $nachname, int $alter, string $geschlecht, string $adresse, Konto $konto) {
  $this -> vorname = $vorname;
  $this -> nachname = $nachname;
  $this -> alter = $alter;
  $this -> geschlecht = $geschlecht;
  $this -> adresse = $adresse;
  $this -> konto = $konto;
  
  
 
  }

?>
