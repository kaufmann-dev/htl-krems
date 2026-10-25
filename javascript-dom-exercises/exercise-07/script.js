// Add content to table
$(document).ready(function(){
	$("table").append(
		"<tr><td>Horst</td><td>Völker</td><td>12.02.2001</td><td><button>DEL</button></td></tr>" +
		"<tr><td>Alexander</td><td>Treber</td><td>01.11.2002</td><td><button>DEL</button></td></tr>" +
		"<tr><td>Mark</td><td>Schwarz</td><td>25.02.2001</td><td><button>DEL</button></td></tr>" +
		"<tr><td>Christopher</td><td>Pretz</td><td>04.05.2001</td><td><button>DEL</button></td></tr>" +
		"<tr><td>Florian</td><td>Singer</td><td>30.09.2001</td><td><button>DEL</button></td></tr>"
	);
});

// Delete line
$(document).ready(function(){
	$("button").click(function(){
		$(this).parent().parent().remove();
	});
});