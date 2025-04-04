<?php
    function autoload($className){
        if(file_exists("./{$className}.php")){
            require "./{$className}.php";
        }
    }
    spl_autoload_register('autoload');

    $vw = new SuperCar(500);
    $vw->drive();

    $mbw=new Car(125);
    $mbw->drive();
?>