const { type } = require("os");

var id;

function displayIndividual() {
    var dropDown = document.getElementById("dropdownSelectClient");

    while (dropDown.length > 0) {
        dropDown.remove(0);
    }

    var iOptions = ["1", "3", "5"]; //here is where the database information is going to go in

    id = iOptions[0];

    var select = document.createElement("option");
    select.textContent = "Please Select";
    select.value = "Please Select";
    dropDown.append(select);

    for (var i = 0; i < iOptions.length; i++) {
        var opt = iOptions[i];
        var createElement = document.createElement("option")
        createElement.textContent = opt;
        createElement.value = opt;
        dropDown.append(createElement);
    }
}

function displayBusiness() {
    var dropDown = document.getElementById("dropdownSelectClient");

    while (dropDown.length > 0) {
        dropDown.remove(0);
    }

    var bOptions = ["2", "4", "6"];//here is where the database infromation is going to go in

    id = iOptions[0];

    var select = document.createElement("option");
    select.textContent = "Please Select";
    select.value = "Please Select";
    dropDown.append(select);

    for (var i = 0; i < bOptions.length; i++) {
        var opt = bOptions[i];
        var createElement = document.createElement("option")
        createElement.textContent = opt;
        createElement.value = opt;
        dropDown.append(createElement);
    }
}

var today;
function getCurrentDate() {
    today = new Date();
    document.getElementById("addedDate").remove();
}

var specified;
function getSpecifiedDate() {
    var addDateComponent = document.getElementById("addComp");
    var specificDate = document.createElement("input");
    specificDate.setAttribute("type", "date");
    specificDate.setAttribute("size", "10");
    specificDate.setAttribute("maxlength", "10");
    specificDate.setAttribute("class", "inputbars");
    specificDate.setAttribute("id", "addedDate")
    addDateComponent.appendChild(specificDate);

    specified = document.getElementById("addedDate").value;
}

function Submit() {
    //var individualClient = document.getElementById("IndividualClient");
    //var client;
    //if (individualClient.checked = true) {
    //    client = document.getElementById("IndividualClient").innerText;
    //}
    //else {
    //    client = document.getElementById("BusinessClient").innerText;
    //}

    //var title;
    //if (document.getElementById("FollowUpText").value == null) {
    //    alert("Please fill in all the fields");
    //} else {
    //    title = document.getElementById("FollowUpText").value;
    //}

    //var Type;
    //if (document.getElementById("dropdownFollowUpType").value == null || document.getElementById("dropdownFollowUpType").value == "Please Select") {
    //    alert("Please fill in all the fields");
    //} else {
    //    Type = document.getElementById("dropdownFollowUpType").value;
    //}

    //var description;
    //if (document.getElementById("FollowUpDescriptionText").value == null) {
    //    alert("Please fill in all the fields");
    //} else {
    //    description = document.getElementById("FollowUpDescriptionText").value;
    //}

    //var dateReceived;
    //if (document.getElementById(CurrentDateTime).checked = true) {
    //    dateReceived = today;
    //} else {
    //    dateReceived = document.getElementById("addedDate").value;
    //}

    //var dateProcessed = document.getElementById("DateTimeText").value;

    //var isIssueResolved;
    //if (document.getElementById("IsResolved").checked = true) {
    //    isIssueResolved = 1;
    //} else {
    //    isIssueResolved = 0;
    //}

    //var satisfaction
    //if (document.getElementById("edtSatisfactionLvl").value == null) {
    //    alert("Please fill in all the fields");
    //} else {
    //    satisfaction = document.getElementById("edtSatisfactionLvl").value;
    //}

    //var arrSubmission = [id, title, type, description, dateReceived, dateProcessed, isIssueResolved, satisfaction];

    //alert(arrSubmission[0]);
}
