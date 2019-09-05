function AddProduct(id) {
        $.ajax({
            type: "POST",
            url: "Products/AddProductInCart/" + id,
            success: function(data) {
                var value = $("#amount").text();
                value = parseInt(value) + 1;
                $("#amount").html(value);
                localStorage.setItem("CartAmount", value);
            },
            error: function () {
                document.location.href = "/Identity/Account/Login";

            }
        });
}

function SetCartAmount() {
    var value = localStorage.getItem("CartAmount");

    if (value !== null) {
        $("#amount").html(value);
    }
}

function RemoveCartProduct() {

    var value = $("#amount").text();
    value = parseInt(value) - 1;
    $("#amount").html(value);
    localStorage.setItem("CartAmount", value);
    }


function ClearCartProduct() {

    $("#amount").html(0);
    localStorage.setItem("CartAmount", 0);
}


