<?php
require_once("SuperK.class.php");
class SubK extends SuperK
{
  public $z = 42;	
  public function ausgabe(){
    echo "<hr />Methode der Subklasse<hr />";

  }
}
?>
