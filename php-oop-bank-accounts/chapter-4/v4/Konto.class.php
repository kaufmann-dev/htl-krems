<?php

class Konto
{
  private $kontostand = 0;
  private $kontotyp = "";

  public function einzahlen(float $betrag){
    $kontostand += $betrag;
  }

  public function auszahlen(float $betrag){
    $kontostand -= $betrag;

  }

  public function setKontotyp(string $kontotyp){
    $this -> kontotyp = $kontotyp;

  }


}
?>
