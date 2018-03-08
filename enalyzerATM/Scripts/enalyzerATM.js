/*Document ready*/
$(document).ready(function () {
    $(".touchPad_Touch").hover(function () {
        $(this).stop().animate({ opacity: "0.3" }, 'slow');
    },
        function () {
            $(this).stop().animate({ opacity: "1" }, 'slow');
        });

    $("#touchPad_AmountInput").focus();
});


/*Navigate through section*/
$("#sectionHome").click(function () {
    $('html,body').animate({
        scrollTop: $("#sectionTouchPad").offset().top
    },
    'slow');
});
$("#touchPad_SubmitButton").click(function () {
    $('html,body').animate({
        scrollTop: $("#sectionResult").offset().top
    },
        'slow');
});
$("#result_BackArrow").click(function () {
    $('html,body').animate({
        scrollTop: $("#sectionTouchPad").offset().top
    },
        'slow');
});

/*//Get
var bla = $('#txt_name').val();

//Set
$('#txt_name').val(bla);
*/

/*Add amount to input and resize*/
function addAmount(touchNum) {
    var amount = $('#touchPad_AmountInput');
    amount.val(amount.val() + touchNum.value);
    var size = (amount.val().length > 2) ? amount.val().length : 2;
    amount.style.width = ((amount.val().length + 1) * 80) + 'px';;
}