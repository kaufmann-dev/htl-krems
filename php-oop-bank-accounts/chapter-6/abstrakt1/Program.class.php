<?php
require_once("A1.class.php");
class Program
{
	public function __construct(){
		$this -> main();
	}

  public function main(){
	  new A1();
  }
}
new Program();
?>
