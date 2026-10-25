<?php

$data=[ ["Energie NÖ", "xyz", 745], ["Maxi Energie", "xyz", 750], ["Unsere Wasserkraft", "xyz", 741] ];

usort($data, function($a, $b) {
    return $a[2] <=> $b[2];
});

var_dump($data);

//Spaceship Operator ab PHP 7: https://www.tutorialspoint.com/php7/php7_spaceship_operator.htm