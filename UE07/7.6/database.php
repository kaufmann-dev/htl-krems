<?php
    $pdo = new PDO('mysql:host=localhost; dbname=ue7oop;charset=utf8','hombo','CHANGE_ME');
    $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
?>