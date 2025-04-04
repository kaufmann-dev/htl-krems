<?php
    require "car.php";

    class SuperCar extends Car {
        public function drive()
        {
            echo "Ein SuperCar kann fliegen.";
        }
    }
?>