$("#sectionHome").click(function () {
    $('html,body').animate({
        scrollTop: $("#sectionTouchPad").offset().top
    },
    'slow');
});

$("#amountButton").click(function () {
    $('html,body').animate({
        scrollTop: $("#sectionResult").offset().top
    },
        'slow');
});

$("#backArrow").click(function () {
    $('html,body').animate({
        scrollTop: $("#sectionTouchPad").offset().top
    },
        'slow');
});

// TODO : See why scroll not fired
// $("#appHome").on('scroll', function () {
//    $('html,body').animate({
//        scrollTop: $("#appTouchPad").offset().top
//    },
//        'slow');
//});