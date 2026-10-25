<?php 
if(isset($_POST["id"])){
    $id = $_POST["id"];
    echo "HURENSHON ". $id;
    $servername = "localhost";
    $username = "hombo";
    $password = "CHANGE_ME";
    $dbname = "guestbook";


    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);

    $stmt = $conn->prepare("DELETE FROM articles WHERE ARTICLE_ID = :id");

    $stmt->bindParam(':id', $id);
    $stmt->execute();
}
?>