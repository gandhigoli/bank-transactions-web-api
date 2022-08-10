const _strApiUrl = "TransferMoney.aspx";

const _fromaccountnumber = $("#txtfromaccountnumber").focus();
const _fromaccountname = $("#txtfromaccountname");
const _fromaccountcurrentbalance = $("#lblfromaccountcurrentbalance");
const _destinationAccount = $("#txtDestinationAccount");
const _depositamount = $("#txtdepositamount");

const btnTransforMoney = $("#btnTransforMoney");
const _btnFromAccount = $("#btnFromAccount");
const _btnclear = $("#btnclear");

const spnfromaccountnumber = $("#spnfromaccountnumber");
const spnfromaccountcurrentbalance = $("#spnfromaccountcurrentbalance");
const spnDestinationAccount = $("#spnDestinationAccount");
const spndepositamount = $("#spndepositamount");

_btnclear.click(function (e) {
    try {
        Cleardata();
    } catch (error) {
        console.log(error);
    }
});

_btnFromAccount.click(function (e) {
    try {
        GetAccInfoData();
    } catch (error) {
        console.log(error);
    }
});

function GetAccInfoData() {
    var _inputval = _fromaccountnumber.val();
    if (_inputval != null && _inputval!= "")
    {
        spnfromaccountnumber.text('');
        GetData("http://localhost:59272/api/values/GetCustomerInfor?AccNo=" + _inputval, function (pData) {
            try {
                if (pData == null) {
                    return;
                }
                else {
                    if (pData.hasOwnProperty("Table")) {
                        _fromaccountname.text(pData.Table[0].Fname);
                        _fromaccountcurrentbalance.text(pData.Table[0].AccountBalance);
                    }
                }
                console.log(pData);
            } catch (e) {
                console.log(e);
            }
        });
    }
    else {
        spnfromaccountnumber.text('Required');
    }
}

function GetData(pStrUrl, pOnComplete, pOnError) {
    if ((pStrUrl || '') === '' || !IsFunction(pOnComplete)) {
        return;
    }
    $.get(pStrUrl, function (pData) {
        pOnComplete(pData);
    }, 'json').fail(function (xhr, textStatus, errorThrown) {
        if (IsFunction(pOnError)) {
            pOnError(xhr.responseText);
        } else {
            alert(xhr.responseText);
        }
    });
    //  ShowLoading();
}

btnTransforMoney.click(function (e) {
    try {
        //alert('hi');
        submitData();
    } catch (error) {
        //showError(error);
        console.log(error);
        alert(error);
    }
});

function submitData() {
    var val = true;
    if (_fromaccountnumber.val() == null || _fromaccountnumber.val() == "") {
        spnfromaccountnumber.text('Required');
        val = false;
    }
    else {
        spnfromaccountnumber.text('');
    }
    if (_destinationAccount.val() == null || _destinationAccount.val() == "") {
        spnDestinationAccount.text('Required');
        val = false;
    }
    else {
        spnDestinationAccount.text('');
    }
    if (_depositamount.val() == null || _depositamount.val() == "") {
        spndepositamount.text('Required');
        val = false;
    }
    else {
        if (_depositamount.val() <= 0) {
            spndepositamount.text('Deposit amount not less than 0');
            val = false;
        }
        else {
            spndepositamount.text('');
        }
    }
    if ((_fromaccountcurrentbalance.text() || "") === "") {       
        spnfromaccountcurrentbalance.text('Required');
        val = false;
    }
    else {
        var val1 = parseInt( _fromaccountcurrentbalance.text());
        if (val1<=0) {
            spnfromaccountcurrentbalance.text('Balance not less than 0.');
            val = false;
        }
        else {
            spnfromaccountcurrentbalance.text('');
        }
    }

    var _currentbal = parseInt(_fromaccountcurrentbalance.text());
    var _depositbal = parseInt(_depositamount.val());

    if (_currentbal < _depositbal) {
        val = false;
        $("#_depositamount").focus();
        var _dep = "0";
        _depositamount.text(_dep);
        alert('Key-in Transfer Amount is greater/less than the main balance.');
    }
    if (val) {
        let param = {
            "_fromaccountnumber": _fromaccountnumber.val(),
            "_fromaccountname": _fromaccountname.text(),//.val(),
            "_fromaccountcurrentbalance": _fromaccountcurrentbalance.text(),//.val(),
            "_destinationAccount": _destinationAccount.val(),
            "_depositamount": _depositamount.val()
        };
        PostData("http://localhost:59272/api/TransferMoney/Insert_TransferMoneyAmount", param, function (pData) {
            try {
                Cleardata();
                console.log(pData);
                alert(pData);
            } catch (e) {
                console.log(e);
                alert('Transaction fail.--->' + e);
            }
        });
    }
}

function Cleardata() {

    _fromaccountnumber.val("");
    _fromaccountname.text("");
    _fromaccountcurrentbalance.text("");
    _destinationAccount.val("");
    _depositamount.val("");
    spnfromaccountcurrentbalance.text('');
    spnDestinationAccount.text('');
    spndepositamount.text('');
    spnDestinationAccount.text('');
    spnfromaccountnumber.text('');
}

function PostData(pStrUrl, objParam, pOnComplete, pOnError) {
    if (!objParam || (pStrUrl || '') === '' || !IsFunction(pOnComplete)) {
        return;
    }
    $.post(pStrUrl, objParam, function (pData) {
        pOnComplete(pData);
    }, 'json').fail(function (xhr, textStatus, errorThrown) {
        if (IsFunction(pOnError)) {
            pOnError(xhr.responseText);
        } else {
            alert(xhr.responseText);
        }
    });
    //  ShowLoading();
}

function IsFunction(functionToCheck) {
    return functionToCheck && {}.toString.call(functionToCheck) === '[object Function]';
}