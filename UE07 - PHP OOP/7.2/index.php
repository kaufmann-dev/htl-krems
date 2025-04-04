<?php
    class Car {
        private $horsePower = 0;
        function __construct($horsepower)
        {
            $this->horsePower=$horsepower;
        }
        public function drive(){
            echo "Das Auto hat ".$this->horsePower." PS<br>";
        }
    }

    $vw = new Car(0);
    $vw->drive();

    $mbw=new Car(125);
    $mbw->drive();

    $diau=new Car(250);
    $diau->drive();
?>

