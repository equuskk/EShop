
function AddProduct(id) {

        $.ajax({
            type: 'POST',
            url: 'Products/AddProductInCart/' + id,
            success: function(data) {
                var value = $("#amount").text();
                value = parseInt(value) + 1;
                $('#amount').html(value);
            }
        });
};

