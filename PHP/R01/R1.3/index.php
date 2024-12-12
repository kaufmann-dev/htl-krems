<!DOCTYPE html>
<html>
    <head>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css">
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>R1.3</title>
    </head>
    <body>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Project name</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item">
                    <a class="nav-link" aria-current="page" href="#">Home</a>
                    </li>
                    <li class="nav-item">
                    <a class="nav-link" href="#">About</a>
                    </li>
                </ul>
                </div>
            </div>
        </nav>
        <div class="container my-3">
            <?php
                $var = [
                    (object) ['title' => 'Apfel', 'desc' => "Ein Apfel ist sehr gesund!"],
                    (object) ['title' => 'IDE', 'desc' => "Damit kann man Programmieren lernen!"]
                ];
                foreach($var as $elem){
                    echo"<div class='rounded border mb-3'><div class='bg-light p-2'>".$elem->title."</div><div class='p-2'>".$elem->desc."</div></div>";
                }
                echo"<div class='bg-light rounded border p-2'><pre>";
                var_dump($var);
                echo"</pre></div>";
            ?>
        </div>
        
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"></script>
    </body>
</html>