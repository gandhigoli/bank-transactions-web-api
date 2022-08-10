const _strApiUrl = "Deposit.aspx";

const _enterAccNo = $("#txtenteraccountnumber").focus();
const _currentAccName = $("#txtname");
const _currentAccBalance = $("#lblcurrentbalance");
const _modetype = $("#ddlmode");
const _depositamount = $("#txtdepositamount");

const _btnSubmit = $("#btnsubmit");
const _btnclear = $("#btnclear");
const _btngetAccountinformationdata = $("#btngetAccountinformationdata");

// Validation controls
const _spnenteraccountnumber = $("#spnenteraccountnumber");
const _spnmode = $("#spnmode");
const _spndepositamount = $("#spndepositamount");

_btngetAccountinformationdata.click(function (e) {
    try {
        if (_enterAccNo.val() == null || _enterAccNo.val() == "") {
            _spnenteraccountnumber.text('Required');
        }
        else {
            _spnenteraccountnumber.text('');
            GetAccInfoData();
        }
    } catch (error) {
        //showError(error);
        console.log(error);
    }
});

function GetAccInfoData() {
    GetData("http://localhost:59272/api/values/GetCustomerInfor?AccNo=" + _enterAccNo.val(), function (pData) {
        try {
            if (pData == null) {
                return;
            }
            else {
                if (pData.hasOwnProperty("Table")) {
                    _currentAccName.text(pData.Table[0].Fname);
                    _currentAccBalance.text(pData.Table[0].AccountBalance);
                }
            }
            console.log(pData);
        } catch (e) {
            console.log(e);
        }
    });
}

_btnclear.click(function (e) {
    try {
        Cleardata();
    } catch (error) {
        // showError(error);
        console.log(error);
    }
});

_btnSubmit.click(function (e) {
    try {
        submitData();
    } catch (error) {
        alert(error);
        console.log(error);
    }
});

function submitData() {
    var val = true;
    if (_enterAccNo.val() == null || _enterAccNo.val() == "") {
        _spnenteraccountnumber.text('Required');
        val = false;
    }
    else {
        _spnenteraccountnumber.text('');
    }
    if (_modetype.val() == null || _modetype.val() == "" || _modetype.val() == -1) {
        _spnmode.text('Required');
        val = false;
    }
    else {
        _spnmode.text('');
    }
    if (_depositamount.val() == null || _depositamount.val() == "") {
        _spndepositamount.text('Required');
        val = false;
    }
    else {
        _spndepositamount.text('');
    }

    if (val) {
        let param = {
            "_enterAccNo": _enterAccNo.val(),
            "_currentAccName": _currentAccName.text(),
            "_currentAccBalance": _currentAccBalance.text(),
            "_modetype": _modetype.val(),
            "_depositamount": _depositamount.val()
        };
        PostData("http://localhost:59272/api/Deposit/InsertDeposit", param, function (pData) {
            try {
                alert(pData);
                Cleardata();
                console.log(pData);
            } catch (e) {
                console.log(e);
                alert('Transaction fail.--->' + e);
            }
        });
    }
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

function IsFunction(functionToCheck) {
    return functionToCheck && {}.toString.call(functionToCheck) === '[object Function]';
}

function Cleardata() {
    _enterAccNo.val("");
    _currentAccName.text("");
    _currentAccBalance.text("");
    _depositamount.val("");
    _modetype.val("-1");
}
