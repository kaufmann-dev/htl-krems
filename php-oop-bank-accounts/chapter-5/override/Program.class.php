<?php
require_once("SubK.class.php");
class Program
{
	public function __construct(){
		$this -> main();
	}

  private function main(){
	 $obj = new SubK();
	 $obj -> ausgabe("test");
	echo $obj -> z;
  }
}
new Program();
?>
