//this is an unused approach. changes made where will not effect anything
async function Submit() {
    var form = document.getElementById("MainForm");
    var formData = new FormData(form);
    

    var xhr = new XMLHttpRequest();
    xhr.open("POST", '/feedback', true);

    //Send the proper header information along with the request
    //xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.setRequestHeader("content-ype", "multipart/form-data");

    xhr.onreadystatechange = function () { // Call a function when the state changes.
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
            elert("fuck");
        }
    }

    xhr.send(formData);
}

//becuase we built it with pug. the template will already include the newest and we don't have to refresh it
//this is unused and unfinished
function getclients() {
    var xhr = new XMLHttpRequest();
    xmlHttp.open("GET", "/clients", false); // false for synchronous request
    xmlHttp.send(null);

    let json = xmlHttp.responseText;

    var cbxGroups = JSON.parse(json);

    //no populate combobox
}

function confirm() {
    alert("Followup succesfully submitted!!!");
}
