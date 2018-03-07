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
