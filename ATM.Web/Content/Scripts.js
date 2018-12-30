function input(e) {
    var NumInput = document.getElementById("credit-card-number");
    if (NumInput.value.length < 16) {
        NumInput.value +=  e.value;
    }
}

function del() {
    var NumInput = document.getElementById("credit-card-number");
    NumInput.value = NumInput.value.substr(0, NumInput.value.length - 1);
}

function clr() {
    var NumInput = document.getElementById("credit-card-number");
    NumInput.value = "";
}

function maskCreditCard() {
    console.log("kakoka")
    var x = value.replace(/\D/g, '').match(/(\d{0,4})(\d{0,4})(\d{0,4})(\d{0,4})/);
    value = !x[2] ? x[1] : '-' + x[1] + '-' + x[2] + (x[3] ? '-' + x[3] : '');
    console.log(value);
}

//var el = document.getElementById('credit-card-number')
//el.addEventListener('input', function (e) {
//    var x = e.target.value.replace(/\D/g, '').match(/(\d{0,4})(\d{0,4})(\d{0,4})(\d{0,4})/);
//    e.target.value = !x[2] ? x[1] : '-' + x[1] + '-' + x[2] + (x[3] ? '-' + x[3] : '');
//});