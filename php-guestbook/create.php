<!DOCTYPE html>
<html lang="en">
<head>
  <title>Bootstrap Example</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
<?php

function test_input($data) {
    $data = trim($data);
    $data = stripslashes($data);
    $data = htmlspecialchars($data);
    return $data;
}


$servername = "localhost";
$username = "hombo";
$password = "CHANGE_ME";
$dbname = "guestbook";

try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $name = $email = $date = $text = "";
    if (isset($_POST["username"]) && $_POST["email"] && $_POST["text"]){
        if(!(empty($_POST["username"]) && empty($_POST["email"]) && empty($_POST["text"]))){
            $name = test_input($_POST["username"]);
            $email = test_input($_POST["email"]);
            $text = test_input($_POST["text"]);

            if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
                return;
            }

            $stmt = $conn->prepare("INSERT INTO articles (USERNAME, EMAIL, CREATION_DATE, MESSAGE)
            VALUES (:username, :email, CURRENT_TIMESTAMP(), :messagetext)");

            $stmt->bindParam(':username', $name);
            $stmt->bindParam(':email', $email);
            $stmt->bindParam(':messagetext', $text);

            $stmt->execute();

        }

    }

} catch(PDOException $e) {
  echo $sql . "<br>" . $e->getMessage();
}

$conn = null;
?>
<nav class="navbar navbar-expand-sm bg-light navbar-light">
  <div class="container-fluid">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" href="index.php">Überblick</a>
      </li>
     <li class="nav-item">
        <a class="nav-link active" href="create.php">Beitrag erstellen</a>
      </li>
    </ul>
  </div>
</nav>
<div class="container">
    <form action="create.php" method="post">
        <div class="mb-3 mt-3">
            <label for="username" class="form-label">Name:</label>
            <input type="text" class="form-control" id="username" name="username" required>
        </div>
        <div class="mb-3 mt-3">
            <label for="email" class="form-label">Email:</label>
            <input type="email" class="form-control" id="email" name="email" required>
        </div>
        <label for="text">Nachricht:</label>
        <textarea class="form-control" rows="5" id="text" name="text" required></textarea>
        <button type="submit" class="btn btn-primary mt-3">Speichern</button>
    </form>
</div>

</body>
</html>