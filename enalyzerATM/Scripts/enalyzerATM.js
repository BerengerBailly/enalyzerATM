$(document).ready(function () {
    $("#sectionTouchPad").hide();
    $("#sectionResult").hide();
})


/*Navigate through section*/
$("#sectionHome").click(function () {
    $("#sectionTouchPad").show();
    $("#sectionHome").slideUp("slow", function () {
        
        $("#sectionHome").fadeOut("slow");
    });
});
$("#result_BackArrow").click(function () {;
    $("#sectionTouchPad").slideDown("slow", function () {
        $("#sectionResult").fadeOut("slow");
    });
});
$(".touchPad_Touch").click(function () {
    addAmount(this);
});
function addAmount(touchNum) {
    var amount = $('#touchPad_AmountInput');

    //Add, erase or show warning message
    if (touchNum.id == 'touchPad_Erase' && amount.text().length > 0) {
        amount.text(amount.text().slice(0, -1));
    } else if (touchNum.id != 'touchPad_Erase') {
        var newAmount = amount.text() + touchNum.value;
        if (newAmount < 999999999) {
            amount.text(newAmount);
        } else {
            alert('maximum amount reached');
            //raise modal warning
        }
    }

    //Submit button opacity
    if (amount.text().length > 0) {
        $("#touchPad_SubmitButton").addClass("touchPad_Active");
    } else {
        $("#touchPad_SubmitButton").removeClass("touchPad_Active");
    }

}


$("#touchPad_SubmitButton").click(function () {
    //Ajax call
    var amount = $('#touchPad_AmountInput');
    if (amount.text().length > 0) {
        $.ajax({
            type: 'POST',
            url: '/Home/GetAtmChange',
            data: { amount: amount.text()
            },
            cache: true,
            success: function (result) {
                DisplayResult(result);
            }
        });
    }    
});

function DisplayResult() {
    //Add notes, coin and amount


    //Then display the section
    $("#sectionResult").show();
    $("#sectionTouchPad").slideUp("slow", function () {

        $("#sectionTouchPad").fadeOut("slow");
    });
}