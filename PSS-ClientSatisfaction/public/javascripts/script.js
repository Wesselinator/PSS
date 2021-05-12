
function showMessage() {
    alert("Henlo");
}

var individualClient = document.getElementById("IndividualClient");
var businessClient = document.getElementById("BusinessClient");

var iOptions = ["1", "3", "5"];
var bOprions = ["2", "4", "6"];

var dropDown = document.getElementById("dropdownSelectClient");

for (var i = 0; i < iOptions.length; i++) {
    var opt = iOptions[i];
    var createElement = document.createElement("option")
    createElement.textContent = opt;
    createElement.value = opt;
    //dropDown.append(createElement);
}

//curl - X POST "http://localhost:3000/testconn"