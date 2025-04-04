<?php
    class Car {
        public $horsePower=0;
        public function drive(){
            echo "Das Auto hat ".$this->horsePower." PS<br>";
        }
    }
    $vw = new Car();
    $vw->drive();

    $mbw=new Car();
    $mbw->horsePower=200;
    $mbw->drive();

    $diau=new Car();
    $diau->horsePower=200;
    $diau->drive();
?>

