$(document).ready(function() {
	$('.col').hide();
	$('.h').click(function() {
		if ($(this).parent().find('.col').is(":visible")) {
			$(this).parent().find('.col').hide();
		}
		else {
			$(this).parent().find('.col').show();
		}
	});
});