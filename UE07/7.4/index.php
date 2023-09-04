<?php
    require "car.php";
    require "supercar.php";

    $vw = new SuperCar(500);
    $vw->drive();

    $mbw=new Car(125);
    $mbw->drive();
?>