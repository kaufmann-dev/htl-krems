<?php

class Konto
{
  public $kontostand = 0;
  public $kontotyp = "";

  public function einzahlen(float $betrag){
    $kontostand += $betrag;
  }

  public function auszahlen(float $betrag){
    $kontostand -= $betrag;

  }

}
?>
