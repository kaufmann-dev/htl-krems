<html>
<head>

</head>
<body>
    <div class="container">
        <h1>Some items to delete</h1>
        <div class="flex-container">
            <div><h4>Item 1</h4><i class="bi bi-trash"></i></div>
            <div><h4>Item 2</h4><i class="bi bi-trash"></i></div>
            <div><h4>Item 3</h4><i class="bi bi-trash"></i></div>
            <div><h4>Item 4</h4><i class="bi bi-trash"></i></div>
            <div><h4>Item 5</h4><i class="bi bi-trash"></i></div>
            <div><h4>Item 6</h4><i class="bi bi-trash"></i></div>
            <div><h4>Item 7</h4><i class="bi bi-trash"></i></div>
            <div><h4>Item 8</h4><i class="bi bi-trash"></i></div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <script>
        $(
            $(".bi-trash").click(function (){
                let item = $(this).parent();
                let id = item.find("h4").html().split(" ")[1];
                console.log(id);
                $.ajax({
                    type:"delete",
                    url:"http://htl.boxtree.at/medw4/api/random.php",
                    data: {id:id},
                    statusCode: {
                        200: function (){
                            console.log("Alles ok!");
                            item.remove(item);
                        },
                        404: function (){
                            console.log("Funktioniert nicht.");
                        }
                    }
                })
            })
        )
    </script>
</body>
</html>

<!--
    
$.ajax({
    type: "get",
    url: "http://htl.boxtree.at/medw4/api/students.php",
    data: {students:null},
    success: function(response){
        console.log(response);
        response.forEach(function(json){
            let s = "<tr>";
            s += "<td>" + json.id + "</td>";
            s += "<td>" + json.firstname + "</td>";
            s += "<td>" + json.lastname + "</td>";
            s += "<td>" + json.dob + "</td>";
            s += "<td><img src='https://img.icons8.com/ios-glyphs/30/000000/filled-trash.png'>";
            s += "<img src=''></td>";
        })
    }
});

$('.bi').click(function () {
    let Itemid = this.id;
    $.ajax({
        url: 'http://htl.boxtree.at/medw4/api/random.php?id='+Itemid,
        statusCode: {
            404: function () {
                alert("Löschen funktionierte nicht");
            },
            200: function() {
                $('#'+Itemid).parent().remove();
            }
        }
    });
});

-->