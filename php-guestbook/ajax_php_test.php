<?php
$server = "localhost";
$username = "root";
$password = "";

$db = new PDO("mysql:host=$server;dbname=Lib4You_30092022", $username, $password);
$hum = $db->prepare("USE Lib4You_30092022;");
$hum->execute();
$hom = $db->prepare("SELECT isbn, title, year, edition, description, likes from books");
$hom->execute();
$hig=$hom->fetchAll();

if(isset($_POST["newlikes"])&&isset($_POST["newisbn"])){
    $likes = $_POST["newlikes"];
    $isbn = $_POST["newisbn"];
    $ham = $db->prepare("update books set likes = $likes where isbn = $isbn);");
    $ham->execute();
}

?>
<!doctype html>
<html lang="en">
<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet"
          integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">

    <title>Prüfung</title>
</head>
<?php

?>

<body class="container">
    <h1>Verfügbare Bücher</h1>
    <table class="table">
        <thead>
        <tr>
            <th>Titel</th>
            <th>Jahr</th>
            <th>Auflage</th>
            <th>Aktion</th>
        </tr>
        </thead>
        <tbody>
        <?php

        foreach ($hig as $row){
            echo"<tr>";
            echo"<td><form method='POST'><input type='hidden' name='isbn' value='".$row["isbn"]."'><input class='btn btn-link' type='submit' value='".$row["title"]."'></form></td>";
            echo"<td>".$row["year"]."</td>";
            echo"<td>".$row["edition"]."</td>";
            echo"<td><button class='btn btn-sm btn-primary likebtn me-2'>Like</button><span class='likeout'>".$row["likes"]."</span></td>";
            echo"</tr>";
        }
        ?>
        </tbody>
    </table>
    <?php
    if(isset($_POST["isbn"])){
        foreach ($hig as $row){
            if($row["isbn"] == $_POST["isbn"]){
                ?>
                <div class="card">
                    <div class="card-header">
                        Buch
                    </div>
                    <div class="card-body">
                        <h5 class="card-title"><?php echo $row["title"]; ?></h5>
                        <p class="card-text"><?php echo $row["description"]; ?></p>
                    </div>
                </div>
                <?php
            }
        }
    }
    ?>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.6.1.min.js" integrity="sha256-o88AwQnZB+VDvE9tvIXrMQaPlFFSUTR+nldQm1LuPXQ=" crossorigin="anonymous"></script>
    <script>
        $(document).ready(function (){
            $('.likebtn').click(function (){
                var likes = Number($(this).parent().find('.likeout').text())+1;
                $(this).parent().find('.likeout').text(likes);
                $.ajax({
                    url: "index.php",
                    type: "post",
                    data: likes,
                    success: function (response) {
                        console.log(response);
                    },
                    error: function(jqXHR, textStatus, errorThrown) {
                        console.log(textStatus, errorThrown);
                    }
                });
            });

        });
    </script>
</body>
</html>
