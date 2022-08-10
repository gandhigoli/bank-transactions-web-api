const _strpagename = "CreateAccount.aspx";

//const _divModalMessage = $("#divModalMessage").modal("hide");
const _txtfirstName = $("#txtfirstName").focus();
const _txtlastName = $("#txtlastName");
const _txtbirthdayDate = $("#txtbirthdayDate");
const _rdb_gender = $("#rdb_gender");
const _txtemailAddress = $("#txtemailAddress");
const _txtphoneNumber = $("#txtphoneNumber");
const _lbldemo = $("#lbldemo");
const _txtbalance = $("#txtbalance");

const _btnSubmit = $("#btnSubmit");
const _btnclear = $("#btnclear");
const _strApiUrl = "http://localhost:59272/api/values";

// Span controls for display Error message(Validation)
const _spnfirstName = $("#spnfirstName");
const _spnlastName = $("#spnlastName");
const _spnbirthdayDate = $("#spnbirthdayDate");
const _spnemail = $("#spnemail");
const _spnphonenumber = $("#spnphonenumber");
const _spnaccountid = $("#spnaccountid");
const _spnbalance = $("#spnbalance");


_btnclear.click(function (e) {
    try {
        Cleardata();
    } catch (error) {
        console.log(error);
    }
});

_btnSubmit.click(function (e) {
    try {
        submitData();
    } catch (error) {
        console.log(error);
    }
});

function submitData() {
    var val = true;
    if (_txtfirstName.val() == null || _txtfirstName.val() == "") {
        _spnfirstName.text('Required');
        val = false;
    }
    else {
        _spnfirstName.text("");
    }
    if (_txtlastName.val() == null || _txtlastName.val() == "") {
        _spnlastName.text('Required');
        val = false;
    }
    else {
        _spnlastName.text("");
    }
    if (_txtbirthdayDate.val() == null || _txtbirthdayDate.val() == "") {
        _spnbirthdayDate.text('Required');
        val = false;
    }
    else {
        _spnbirthdayDate.text("");
    }
    if (_txtemailAddress.val() == null || _txtemailAddress.val() == "") {
        _spnemail.text('Required');
        val = false;
    }
    else {
        _spnemail.text("");
    }
    if (_txtphoneNumber.val() == null || _txtphoneNumber.val() == "") {
        _spnphonenumber.text('Required');
        val = false;
    }
    else {
         _spnphonenumber.text("");
    }
    if (_lbldemo.text() == null || _lbldemo.text() == "") {
        _spnaccountid.text('Required');
        val = false;
    }
    else {
         _spnaccountid.text("");
    }
    if (_txtbalance.val() == null || _txtbalance.val() == "") {
        _spnbalance.text('Required');
        val = false;
    }
    else {
         _spnbalance.text("");
    }
    if (val) {
        let param = {
            "_fname": _txtfirstName.val(),
            "_lname": _txtlastName.val(),
            "_bod": _txtbirthdayDate.val(),
            "_Gender": _rdb_gender.val(),
            "_email": _txtemailAddress.val(),
            "_phone": _txtphoneNumber.val(),
            "_accountid": _lbldemo.text(),
            "_balanceamount": _txtbalance.val()
        };
        PostData("http://localhost:59272/api/values/Insert_CustomerInfo", param, function (pData) {
            try {
                Cleardata();
                alert(pData);
                console.log(pData);
            } catch (e) {
                alert('Transaction fail.--->' + e);
                console.log(e);
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

function IsFunction(functionToCheck) {
    return functionToCheck && {}.toString.call(functionToCheck) === '[object Function]';
}

function Cleardata() {

    _txtfirstName.val("");
    _txtlastName.val("");
    _txtbirthdayDate.val("");
    _txtemailAddress.val("");
    _txtphoneNumber.val("");
    _txtbalance.val("");
    _lbldemo.text("");


    _spnfirstName.text("");
    _spnlastName.text("");
    _spnbirthdayDate.text("");
    _spnemail.text("");
    _spnphonenumber.text("");
    _spnbalance.text("");
    _spnaccountid.text("");

}
