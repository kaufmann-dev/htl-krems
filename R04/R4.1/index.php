<?php
    $students = [
        [0, "Martin Bauer", "True"],
        [1, "Josef Dorfer", "True"],
        [2, "Caro Feiersinger", "True"],
        [3, "Clemens Waldhör", "False"],
        [4, "Anita Felsner", "True"],
        [5, "Susanne Korn", "True"],
        [6, "Wolfgang Gartner", "True"],
        [7, "Tom Turbo", "True"],
        [8, "Daniel Maier", "True"],
        [9, "Lukas Fellner", "True"],
        [10, "Benedikt Huber", "True"],
        [11, "Anton Polster", "True"],
        [12, "Sandra Pomassel", "True"],
        [13, "Willi Zauner", "True"],
        [14, "Mario Durnwalder", "True"],
        [15, "Martin Thurner", "True"],
        [16, "Markus Sommer", "True"],
        [17, "Gerald Widhalm", "True"],
        [18, "Martina Fasching", "True"],
        [19, "Johanna Schiebel", "True"],
        [20, "Julia Wagner", "True"],
        [21, "Egon Braunschweig", "True"]
    ];
?>

<!DOCTYPE html>
<html>
    <head>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css">
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
        <link rel="stylesheet" type="text/css" href="https://csshake.surge.sh/csshake.min.css">
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>R4.1</title>
        <style>
            .student-container:hover{
                cursor: pointer;
                background: #f7f7f7;
                user-select: none;
            }
            #output-container {
                background: rgba(0,0,0,0.5);
            }
            #output-container div {
                width: fit-content;
                min-width: 400px;
            }
        </style>
    </head>
    <body>
        <div class="container my-3">
            <h1 class="display-3 d-inline-block mb-3">5BHIT</h1>
            <button class="btn btn-primary mb-3 d-inline-block float-end" id="randomize-btn">Randomize</button>
            
            <div class="row row-cols-1 row-cols-sm-2 row-cols-lg-4 row-cols-xl-4 row-cols-xxl-6" id="present-container">
                <?php
                    foreach($students as $student){
                        if($student[2] == "True") {
                            echo"<div class='col mb-3'><div class='h-100 border text-center rounded p-3 student-container shake-freeze' id='".$student[0]."'>".$student[1]." #".$student[0]."<br><span class='mt-2 d-inline-block'>";
                            echo"<i class='bi bi-check-circle-fill text-success'></i>";
                            echo"</span></div></div>";
                        }
                    }
                    
                ?>
            </div>

            <h1 class="display-5 mb-3">Absent</h1>
            
            <div class="row row-cols-1 row-cols-sm-2 row-cols-lg-4 row-cols-xl-4 row-cols-xxl-6" id="absent-container">
                <?php
                    foreach($students as $student){
                        if($student[2] == "False") {
                            echo"<div class='col mb-3'><div class='h-100 border text-center rounded p-3 student-container shake-freeze' id='".$student[0]."'>".$student[1]." #".$student[0]."<br><span class='mt-2 d-inline-block'>";
                            echo"<i class='bi bi-x-circle-fill text-danger'></i>";
                            echo"</span></div></div>";
                        }
                    }
                ?>
            </div>

            <div id="output-container" class="position-absolute bottom-0 end-0 top-0 start-0">
            <div class="card text-center position-absolute top-50 start-50 translate-middle">
                <div class="card-header">
                    Randomizer
                </div>
                <div class="card-body">
                    <h5 class="card-title">Schüler</h5>
                    <h1 class="card-text mb-3 text-primary" id="output-text"></h1>
                    <button class="btn btn-dark" id="output-close">Schließen</button>
                </div>
                <div class="card-footer text-muted"></div>
            </div>
        </div>
        
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"></script>
        <script src="https://code.jquery.com/jquery-3.6.1.min.js" integrity="sha256-o88AwQnZB+VDvE9tvIXrMQaPlFFSUTR+nldQm1LuPXQ=" crossorigin="anonymous"></script>
        <script>
            $(document).ready(function() {
                $('#output-container').hide();
                $('#randomize-btn').click(function() {
                    $('.student-container').each(function() {
                        $(this).addClass('shake-constant shake-chunk');
                        $(this).removeClass('shake-freeze');
                    });
                    setTimeout(function() {
                        $('.student-container').each(function() {
                            $(this).addClass('shake-freeze');
                            $(this).removeClass('shake-constant shake-chunk');
                        });
                        $('#output-container').show();
                        $('#output-text').text("<?php echo array_filter($students, function($value) {return $value[2] == 'True';})[array_rand(array_filter($students, function($value) {return $value[2] == 'True';}), 1)][1]; ?>");
                    }, 3000);
                });
                $('#output-close').click(function() {
                    $('#output-container').hide();
                });
                $('.student-container').click(function() {
                    $('#randomize-btn').prop("disabled",true);
                    if($(this).find("span i").hasClass("text-danger")) {
                        $(this).find("span").html("<i class='bi bi-check-circle-fill text-success'></i>");
                        $('#present-container').append($(this).parent());
                    } else {
                        $(this).find("span").html("<i class='bi bi-x-circle-fill text-danger'></i>");
                        $('#absent-container').append($(this).parent());
                    }
                });
            });
        </script>
    </body>
</html>