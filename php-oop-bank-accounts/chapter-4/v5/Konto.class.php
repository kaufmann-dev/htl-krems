<?php

class Konto
{
  private $kontostand = 0;
  private $kontotyp = "";

  public function einzahlen(float $betrag){
    $this -> kontostand += $betrag;
  }

  public function auszahlen(float $betrag){
      $this ->kontostand -= $betrag;

  }

  public function setKontotyp(string $kontotyp){
    $this -> kontotyp = $kontotyp;

  }
  public function getKontotyp(): string{
    return $this -> kontotyp;

  }
  public function getKontostand(): float{
    return $this -> kontostand;

  }

}
?>
