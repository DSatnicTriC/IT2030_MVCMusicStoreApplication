$(".RemoveLink").click(function() {
    var id = $(this).attr("data-id");
    $.post("/ShoppingCart/RemoveFromCart", { "id": id }, function(data) {
        // Popuplate elements in my view with data from the controller
        $("#update-message").text(data.Message);
        $("#cart-total").text(data.CartTotal);
        $("#item-count-" + data.DeleteId).text(data.ItemCount);
        if (data.ItemCount < 1) {
            $("#record-" + data.DeleteId).fadeOut(); //hide a row if count is 0
        }
    });
});