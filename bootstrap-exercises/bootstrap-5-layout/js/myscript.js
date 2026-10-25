$(document).ready(function () {
    var fontsize = 16;
    UpdateFontSize();
    $('#font-size-decrease').click(function (){
        if(fontsize > 1){
            fontsize--;
            UpdateFontSize();
        }
    });
    $('#font-size-increase').click(function (){
        fontsize++;
        UpdateFontSize();
    });
    function UpdateFontSize(){
        $('#dummy-text').css('font-size', fontsize + 'px');
        $('#font-size-display').text('Font-size: ' + fontsize + 'px');
    }

    var counter1 = 0;
    var counter2 = 0;
    UpdateCounters();
    $('#counter1').click(function (){
        counter1++;
        UpdateCounters();
    })

    $('#counter2').click(function (){
        counter2++;
        UpdateCounters();
    })
    function UpdateCounters(){
        $('#counter1').text(counter1);
        $('#counter2').text(counter2);
    }
});