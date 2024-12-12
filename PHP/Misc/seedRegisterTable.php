<?php
require_once 'vendor/autoload.php';

$NUM_OF_REGISTRATIONS = 50;

$servername = "localhost";
$username = "@TODO";
$password = "@TODO";

// Create connection
try {
    $conn = new PDO("mysql:host=$servername;dbname=@TODO", $username, $password);
    // set the PDO error mode to exception
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch (PDOException $e) {
    echo "Connection failed: " . $e->getMessage();
}

$faker = Faker\Factory::create();
for ($i = 0; $i < $NUM_OF_REGISTRATIONS; $i++) {
    $conn->query("INSERT INTO wp_medw5_registrations (firstname, lastname, mail, newsletter) VALUES (\"$faker->firstname\", \"$faker->lastname\", \"$faker->email\", \"$faker->boolean()\")");
}
