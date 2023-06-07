function createProduct() {
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
        id = document.getElementById('productId').innerText;
    } catch (error) {
        id = 0;
    }

    const data = {
        Id: id,
        Name: document.getElementById("inName").value,
        PricePerUnit: document.getElementById("inPrice").value,
        Description: document.getElementById("inDesc").value,
        Stock: document.getElementById("inStock").value,
        Image: image
    };

    sendProductData(data);
}

function sendProductData(data) {
    if (data.Id == 0) {
        var url = "/Home/CreateProduct";
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            success: function (data) {
                location.reload();
            },
            error: function (data) {
                alert("Error: Product not added");
            }
        });
    } else {
        var url = "/Home/UpdateProduct";
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            success: function (data) {
                location.reload();
            },
            error: function (data) {
                alert("Error: Product not edited");
            }
        });
    }
}

function fillData() {
    const name = document.getElementById('productName').innerText;
    const desc = document.getElementById('productDesc').innerText;
    const price = document.getElementById('productPrice').innerText.substring(1);
    const stock = document.getElementById('productStock').innerText;

    document.getElementById('inName').value = name;
    document.getElementById('inDesc').value = desc;
    document.getElementById('inPrice').value = price;
    document.getElementById('inStock').value = stock;

}