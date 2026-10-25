$(document).ready(function() {
	console.log("document loaded");

	$('h1').click(function() {
		console.log("h1 clicked");

		$(this).parent().find('.wrapper').toggle();
	});
});