const _strApiUrl = "CreateAccount.aspx";

const txtfirstName = $("#txtfirstName").focus();
const txtlastName = $("#txtlastName");
const txtbirthdayDate = $("#txtbirthdayDate");
const rdb_gender = $("#rdb_gender");
const txtemailAddress = $("#txtemailAddress");
const txtphoneNumber = $("#txtphoneNumber");
const lbldemo = $("#lbldemo");
const txtbalance = $("#txtbalance");

const _btnSubmit = $("#btnSubmit");



_btnSubmit.click(function (e) {
    try {
        submitData();
    } catch (error) {
        showError(error);
    }
});


function submitData() {
    let param = {
        "_fname": txtfirstName.val(),
        "_lname": txtlastName.val(),
        "_bod": txtbirthdayDate.val(),
        "_Gender": rdb_gender.val(),
        "_email": txtemailAddress.val(),
        "_phone": txtphoneNumber.val(),
        "_accountid": lbldemo.val(),
        "_balanceamount": txtbalance.val(),

    };

}