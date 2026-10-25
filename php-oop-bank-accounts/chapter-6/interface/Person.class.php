<?php 
require_once ("Metainfos.interface.php"); 
require_once ("Verhaltensweisen.interface.php"); 
class Person implements Metainfos, 
	Verhaltensweisen { 
	public function telefonieren(){
		echo "Mit Kunden telefonieren.<br />";
	}
	public function chatten(){
		echo "Mit Kunden chatten.<br />";
	} 
} 
?> 
