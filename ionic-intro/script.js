var p1score = 0;
var p2score = 0;
document.getElementById('clickbtn').addEventListener('click', function() {
    var p1 = Math.floor(Math.random() * (6 - 1 + 1) + 1);
    var p2 = Math.floor(Math.random() * (6 - 1 + 1) + 1);

    if(p1 > p2) {
        p1score++;
        document.getElementById('p1').innerHTML = p1score + " wins";
        document.getElementById('result').innerHTML = '<p>Player 1 rolled '+p1+'<br>Player 2 rolled '+p2+'</p><h1>Player 1 wins!</h1>';
    } else if(p1 < p2) {
        p2score++;
        document.getElementById('p2').innerHTML = p2score + " wins";
        document.getElementById('result').innerHTML = '<p>Player 1 rolled '+p1+'<br>Player 2 rolled '+p2+'</p><h1>Player 2 wins!</h1>';
    } else {
        document.getElementById('result').innerHTML = '<p>Player 1 rolled '+p1+'<br>Player 2 rolled '+p2+'</p><h1>It\'s a tie!</h1>';
    }
});