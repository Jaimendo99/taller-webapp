function fillData() {
    const name = document.getElementById('clientName').innerText;
    const email = document.getElementById('clientEmail').innerText;
    const phone = document.getElementById('clientPhone').innerText;

    document.getElementById("inName").value = name;
    document.getElementById("inEmail").value = email;
    document.getElementById("inPhone").value = phone;

}


function getImageData() {
    const fileInput = document.getElementById("inputGroupFile04");

    if (fileInput.value == '') {
        dfImage = document.getElementsByClassName('img-client')[0].src;
        defultImg = dfImage.split(",")[1];
        getFormData(defultImg);
    }

    const file = fileInput.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);

    reader.onload = function () {
        const imageReader = reader.result;
        let image = imageReader.split(",")[1];
        getFormData(image);
    };
}



function getFormData(image) {

    try {
        id = document.getElementById('clientId').innerText;
    } catch (error) {
        id = 0;
    }

        const data = {
            Id: id,
            Name: document.getElementById("inName").value,
            Email: document.getElementById("inEmail").value,
            PhoneNumber: document.getElementById("inPhone").value,
            Image: image
        };

        sendClientData(data);
};


function sendClientData(data) {
    if (data.Id != 0) {
        var url = "/Home/UpdateClient";
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            success: function (data) {
                location.reload();
            },
            error: function (data) {
                alert("Error: Client not edited");
            }
        });
    }
    else {
        var url = "/Home/CreateClient";
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            success: function (data) {
                location.reload();
            },
            error: function (data) {
                alert("Error: Client not added");
            }
        });
    }
}


