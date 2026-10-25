$(document).ready(function(){
	var player = 1;
	$(".small").click(function(){
		if (player === 1 && $(this).hasClass("unused")) {
			$(this).append("X");
			this.style.background = "#CFC";
			player = 2;
			$(this).removeClass("unused");
			//CheckWin(this);
		}
		if (player === 2 && $(this).hasClass("unused")) {
			$(this).append("O");
			this.style.background = "#FCC";
			player = 1;
			$(this).removeClass("unused");
			//CheckWin(this);
		}
	});
});

/*function CheckWin(a){
	if($(a).hasClass("one")){
		if ($(a).text() == $($(".two")).text() && $(a).text() == $($(".three")).text()) {
			alert("Sie haben gewonnen!");
		}
	}
	if($(this).hasClass("two")){
		if () {
			alert("Sie haben gewonnen!");
		}
	}
	if($(this).hasClass("three")){
		if () {
			alert("Sie haben gewonnen!");
		}
	}
	if($(this).hasClass("four")){
		if () {
			alert("Sie haben gewonnen!");
		}
	}
	if($(this).hasClass("five")){
		if () {
			alert("Sie haben gewonnen!");
		}
	}
	if($(this).hasClass("six")){
		if () {
			alert("Sie haben gewonnen!");
		}
	}
	if($(this).hasClass("seven")){
		if () {
			alert("Sie haben gewonnen!");
		}
	}
	if($(this).hasClass("eight")){
		if () {
			alert("Sie haben gewonnen!");
		}
	}
	if($(this).hasClass("nine")){
		if () {
			alert("Sie haben gewonnen!");
		}
	}
}*/