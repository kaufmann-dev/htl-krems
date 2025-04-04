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

    class SuperCar extends Car {
        public function drive()
        {
            echo "Ein SuperCar kann fliegen.";
        }
    }

    $vw = new SuperCar(500);
    $vw->drive();
?>

