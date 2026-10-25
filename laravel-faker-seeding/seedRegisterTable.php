<?php
require_once 'vendor/autoload.php';

if(isset($_GET["amount"])){
    $NUM_OF_REGISTRATIONS = $_GET["amount"];
} else{
    $NUM_OF_REGISTRATIONS = 0;
}

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "med05_ue01_02";
$table = "wp_medw5_registrations";

try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch (PDOException $e) {
    echo "Connection failed: " . $e->getMessage();
}

$faker = Faker\Factory::create();
for ($i = 0; $i < $NUM_OF_REGISTRATIONS; $i++) {
    $conn->query("INSERT INTO $table (firstname, lastname, mail, newsletter) VALUES (\"$faker->firstname\", \"$faker->lastname\", \"$faker->email\", \"$faker->boolean()\")");
}
