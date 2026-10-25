$(document).ready(function() {
	$('h1').click(function() {
		$(this).parent().find('.wrapper').toggle();
	});
	$('button.del').click(function() {
		$(this).parent().remove();
	});
});