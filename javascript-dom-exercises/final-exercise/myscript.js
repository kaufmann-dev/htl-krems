$(document).ready(function(){
	alert("Note: You need an internet connection for the jQuery CDN to work.")
	$('#add').click(function(){
		let text = document.getElementById('input').value;
		let name =  document.createTextNode(text);
		let li = document.createElement('LI');
		li.appendChild(name);
		document.getElementById('list').appendChild(li);
	});
	$('#list').on('click', 'li', function(){
		if ($(this).hasClass('durchgestrichen')) {
			$(this).remove();
		}
		else {
			$(this).addClass('durchgestrichen');
		}
	});
});