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
  $servername = "localhost";
  $username = "hombo";
  $password = "CHANGE_ME";
  $dbname = "guestbook";

  $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);

  $sql = "SELECT * FROM articles ORDER BY CREATION_DATE";
  $result = $conn->query($sql);

  $limit = 2;
  if (isset($_GET["number"])) {
    if (!(empty($_GET["number"]))) {
      $limit = $_GET["number"];
    }
  }
  ?>
  <nav class="navbar navbar-expand-sm bg-light navbar-light">
    <div class="container-fluid">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link active" href="index.php">Überblick</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="create.php">Beitrag erstellen</a>
        </li>
      </ul>
    </div>
  </nav>
  <div class="container">
    <div class="row mt-5">
      <?php
      $count = 0;
      foreach ($result->fetchAll() as $k => $v) {
        if ($limit == $count) {
          break;
        }
        $count++;
      ?>
        <div class="col-sm-12 mt-3 pt-2 pb-2" id="<?php echo $v["ARTICLE_ID"]; ?>" style="background-color: lightgrey;">
          <h4><?php echo $v["USERNAME"]; ?>, am <?php echo $v["CREATION_DATE"]; ?></h4>
          <p><?php echo $v["MESSAGE"]; ?></p>
          <button type="button" class="delete" value="<?php echo $v["ARTICLE_ID"]; ?>">Delete</button>
        </div>
      <?php
      }
      ?>
    </div>
  </div>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
  <script>
    $(document).ready(function() {
      $(".delete").click(function() {
        let id = $(this).attr("value");
        $.post("delete.php", {
          id: id
        }, function(result) {
          $("#" + id).remove();
        });
      });
    });
  </script>
</body>

</html>
<!--
  $email = test_input($_POST["email"]);
  if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
    $emailErr = "Invalid email format";
  }
-->