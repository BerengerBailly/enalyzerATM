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
        //Clean the result section
        $("#result_SummaryNotes").empty();
        $("#result_SummaryBigCoin").empty();
        $("#result_SummarySmallCoin").empty();
    });
});

/*Amount handling*/
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
            //TODO Use modal to display message
        }
    }

    //Submit button opacity
    if (amount.text().length > 0) {
        $("#touchPad_SubmitButton").addClass("touchPad_Active");
    } else {
        $("#touchPad_SubmitButton").removeClass("touchPad_Active");
    }

}

/* Ajax Call on submit and result display*/
$("#touchPad_SubmitButton").click(function () {
    //Ajax call
    var amount = $('#touchPad_AmountInput');
    if (amount.text().length > 0) {
        $.ajax({
            type: 'POST',
            url: '/Home/GetAtmChange',
            data: {
                amount: amount.text(), currencyName: "GBP"
            },
            cache: true,
            success: function (result) {
                DisplayResult(result);
            },
            error: function () {
                //TODO Modal error
                alert("An error occured during the process. Please retry or contact your administrator");
            }
        });
    }    
});
function DisplayResult(result) {
    //Add notes, coin and amount
    $("#result_AmountInput").text(result.displayAmount);
    $.each(result.listMoney, function (index, moneyVM) {
        //Get money container
        var moneyContainer = GetMoneyContainer(moneyVM);
        //Fill the right money type
        if (moneyVM.DisplayMoney.Type == 0) {
            //Display in notes
            $("#result_SummaryNotes").append(moneyContainer);
        }
        else if (moneyVM.DisplayMoney.Type == 1 && moneyVM.DisplayMoney.Size > 20) {
            //Display in big coin
            $("#result_SummaryBigCoin").append(moneyContainer);
        }
        else if (moneyVM.DisplayMoney.Type == 1 && moneyVM.DisplayMoney.Size <= 20) {
            //Display in small coin
            $("#result_SummarySmallCoin").append(moneyContainer);
        }
    });

    //Then display the section
    $("#sectionResult").show();
    $("#sectionTouchPad").slideUp("slow", function () {

        $("#sectionTouchPad").fadeOut("slow");
    });
}
//Return a money container
function GetMoneyContainer(moneyVM) {
    var container = "<div class='moneyContainer'>";
    container += "<div class='moneySymbol'><div class='"+ moneyVM.DisplayMoney.Symbol + "'></div></div>";
    container += "<div class='moneyNumAndAmount'>" + moneyVM.Number + " X " + moneyVM.DisplayMoney.Amount + "</div>";
    container += "</div>";

    return container;
}