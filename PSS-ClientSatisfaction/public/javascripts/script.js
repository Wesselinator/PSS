function displayIndividual() {
    var dropDown = document.getElementById("dropdownSelectClient");

    while (dropDown.length > 0) {
        dropDown.remove(0);
    }

    var iOptions = ["1", "3", "5"]; //here is where the database information is going to go in

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

function displayType() {
    var dropDown = document.getElementById("dropdownFollowUpType");

    var tOptions = ["69", "420", "469"];// here is where the database information is going to go in

    var select = document.createElement("option");
    select.textContent = "Please Select";
    select.value = "Please Select";
    dropDown.append(select);

    for (var i = 0; i < tOptions.length; i++) {
        var opt = tOptions[i];
        var createElement = document.createElement("option");
        createElement.textContent = opt;
        createElement.value = opt;
        dropDown.append(createElement);
    }
}

window.onload = function () {
    displayType();
}

var today;
function getCurrentDate() {
    today = new Date();
    document.getElementById("addedDate").remove();
}

function getSpecifiedDate() {
    var addDateComponent = document.getElementById("addComp");
    var specificDate = document.createElement("input");
    specificDate.setAttribute("type", "date");
    specificDate.setAttribute("size", "10");
    specificDate.setAttribute("maxlength", "10");
    specificDate.setAttribute("class", "inputbars");
    specificDate.setAttribute("id", "addedDate")
    addDateComponent.appendChild(specificDate);
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

    //var title = document.getElementById().innerText;
    //var Type = document.getElementById().innerText;
    //var description = document.getElementById().innerText;
    //var 

    alert(today);
}
