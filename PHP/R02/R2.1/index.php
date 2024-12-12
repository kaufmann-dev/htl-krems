<!DOCTYPE html>
<html>
    <head>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css">
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>R1.1</title>
    </head>
    <body>
        <div class="container my-3">
            <h1 class="display-1">Aktuelle Beiträge</h1>
            <div class="row">
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
                        $conn->exec("DROP TABLE IF EXISTS news");

                        $conn->exec("CREATE TABLE news (
                            id INT(6) AUTO_INCREMENT PRIMARY KEY,
                            title VARCHAR(30) NOT NULL,
                            published VARCHAR(20) NOT NULL,
                            content TEXT NOT NULL,
                            link VARCHAR(50) NOT NULL
                            );");

                        $conn->exec("INSERT INTO news (title, published, content, link)
                        VALUES
                            ('WE HAVE A DREAM!','12. August 2022','„Ich wünsche dir und mir, dass dein Traum für dich und diese Welt in Erfüllung geht.“','https://www.htlkrems.ac.at/2022/08/12/we-have-a-dream/'),
                            ('PICKNICK UND NERVENKITZEL IN WIEN','3. August 2022','Die 4AHIT im Escaperoom!','https://www.htlkrems.ac.at/2022/08/03/picknick-und-nervenkitzel-in-wien/'),
                            ('SURFKURS IN PODERSDORF – 2AHIT','3. August 2022','Die 2AHIT surfte in der letzten Schulwoche nicht im WWW sondern am Neusiedlersee!','https://www.htlkrems.ac.at/2022/08/03/surfkurs-in-podersdorf-2ahit/')
                        ;");

                        $sth = $conn->prepare("SELECT * FROM news");
                        $sth->execute();
                        $result = $sth->fetchAll(\PDO::FETCH_ASSOC);
                    } catch(PDOException $e) {
                        exit("Exception: " . $e->getMessage());
                    }
                ?>
                <?php 
                    foreach($result as $news){
                        ?>
                            <div class="col-12 col-sm-6 col-md-4 mb-3">
                                <div class="card h-100">
                                    <div class="card-body">
                                        <h5 class="card-title">
                                            <?php echo $news["title"]; ?>
                                        </h5>
                                        <h6 class="card-subtitle mb-2 text-muted">
                                            <?php echo $news["published"]; ?>
                                        </h6>
                                        <p class="card-text">
                                            <?php echo $news["content"]; ?>
                                        </p>
                                        <a href="<?php echo $news["link"]; ?>" class="btn btn-primary">Zum Artikel</a>
                                    </div>
                                </div>
                            </div>
                        <?php
                    }
                ?>
            </div>
        </div>
        
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"></script>
    </body>
</html>