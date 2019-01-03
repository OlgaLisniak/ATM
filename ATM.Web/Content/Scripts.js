function input(e) {
    var numInput = document.getElementsByClassName("enter-number")[0];
    if (numInput.value.length < numInput.maxLength) {
        numInput.value +=  e.value;
    }
    maskCreditCard();
}

function del() {
    var numInput = document.getElementsByClassName("enter-number")[0];
    numInput.value = numInput.value.substr(0, numInput.value.length - 1);
}

function clr() {
    var numInput = document.getElementsByClassName("enter-number")[0];
    numInput.value = "";
}

function maskCreditCard() {
    var valueInput = document.getElementById("credit-card-number").value;
    var x = valueInput.replace(/\D/g, '').match(/(\d{0,4})(\d{0,4})(\d{0,4})(\d{0,4})/);
    value = !x[2] ? x[1] : '' + x[1] + '-' + x[2] + '-' + x[3] + (x[4] ? '-' + x[4] : '');
    document.getElementById("credit-card-number").value = value;
}