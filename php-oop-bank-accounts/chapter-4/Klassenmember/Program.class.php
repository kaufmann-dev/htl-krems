<?php
require_once("Person.class.php");
class Program
{
	public function __construct(){
		$this -> main();
	}
  public function main(){
	  echo Person :: $firma . ", " . Person :: ORT;

	  Person :: ausgeben(42);
	  $p = new Person();
	  echo "<br />" . $p -> name;
  }
}
new Program();
?>
