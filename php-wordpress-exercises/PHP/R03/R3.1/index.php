<!DOCTYPE html>
<html>
    <head>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css">
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>R3.1</title>
    </head>
    <body>
        <div class="container my-3">
            <h1 class="display-3">Strompreisvergelich</h1>
            <form class="form" action="" method="POST">
            <div class="mb-3">
                <label class="form-label">kWh/Jahr</label>
                <input name="kwh" type="number" class="form-control">
            </div>
            <button type="submit" class="btn btn-primary">Jetzt vergelichen</button>
            </form>
            <?php if(isset($_POST["kwh"])){ ?>
                
                <?php
                    $servername = "localhost";
                    $username = "root";
                    $password = "";
                    $dbname = "medt5";

                    try {
                        $conn = new PDO("mysql:host=$servername", $username, $password);
                        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
                        
                        $conn->exec("CREATE DATABASE IF NOT EXISTS $dbname");
                        $conn->exec("USE $dbname");
                        $conn->exec("DROP TABLE IF EXISTS providers");

                        $conn->exec("CREATE TABLE providers (
                            id INT(6) AUTO_INCREMENT PRIMARY KEY,
                            title VARCHAR(30) NOT NULL,
                            price_1 DECIMAL(5,2) NOT NULL,
                            price_2 DECIMAL(5,2) NOT NULL,
                            price_3 DECIMAL(5,2) NOT NULL
                            );");

                        $conn->exec("INSERT INTO providers (title, price_1, price_2, price_3)
                        VALUES
                            ('Unsere Wasserkraft',10.23,9.9,9.35),
                            ('Energie NÖ',10.4,10.2,7.9),
                            ('Maxi Energy',10.49,9.9,9.45);");

                        $sth = $conn->prepare("SELECT * FROM providers");
                        $sth->execute();
                        $result = $sth->fetchAll(\PDO::FETCH_ASSOC);
                    } catch(PDOException $e) {
                        exit("Exception: " . $e->getMessage());
                    }
                ?>
                <h1 class="display-3">3 Angebote</h1>
                <table class="table table-striped">
                    <thead>
                        <th>Anbieter</th>
                        <th>Tarif</th>
                        <th>Jahrespreis</th>
                    </thead>
                    <tbody>
                    <?php 
                        foreach($result as $provider){
                            echo"<tr>";
                                echo"<td>".$provider["title"]."</td>";
                                if($_POST["kwh"]<=1000){
                                    echo"<td>Preis 1</td>";
                                    echo"<td>€ ". round($_POST["kwh"]*$provider["price_1"]/100,2) ."</td>";
                                } else if($_POST["kwh"]<=3000){
                                    echo"<td>Preis 2</td>";
                                    echo"<td>€ ". round($_POST["kwh"]*$provider["price_2"]/100,2) ."</td>";
                                } else {
                                    echo"<td>Preis 3</td>";
                                    echo"<td>€ ". round($_POST["kwh"]*$provider["price_3"]/100,2) ."</td>";
                                }
                            echo"</tr>";
                        }
                    ?>
                    </tbody>
                </table>
            <?php } ?>
        </div>
        
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"></script>
    </body>
</html>