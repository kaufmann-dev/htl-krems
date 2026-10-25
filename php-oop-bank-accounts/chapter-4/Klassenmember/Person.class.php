<?php
class Person {
  public static $firma = "Schaffe + Schaffe";
  public $name = "Hans";
  public const ORT = "Irgendwo";
  
  public static function ausgeben(int $wert){
    echo "<hr />Der Wert ist $wert";
  }
}
?>
