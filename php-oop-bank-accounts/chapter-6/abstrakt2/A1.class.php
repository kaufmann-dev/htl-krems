<?php
  abstract class A1{
    public function einzahlen(float $betrag){
     echo "Sie haben $betrag EUR eingezahlt.";
  }

  public abstract function auszahlen(float $betrag);
   
  }
?>