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
?>