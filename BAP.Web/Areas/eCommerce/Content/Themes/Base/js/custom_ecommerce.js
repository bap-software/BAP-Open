/*=============================== Custom JavaScript for eCommerce ====================================*/
function addToWishlist(id, url, note) {
    url += "?productId=" + id;
    $.post(url).always(function () {
        $('#wishlist').load('/eCommerce/Products/WishlistCount');
        alert(note);
    });
}

function quickAddToCart(e, id, count, token, url) {
    var tkn = localStorage.getItem('token');
    if (!tkn) {
        tkn = token;
        localStorage.setItem('token', token);
    }
    e.stopPropagation();
    url += "?productId=" + id;
    url += "&count=" + count;
    url += "&token=" + tkn;
    $.post(url).always(function(result) {
        if (result.status == 'success') {
            localStorage.setItem('token', result.newToken);
        }
        $('#smalldetails').load('/eCommerce/ShoppingCarts/SmallDetails', function() {
            $('#wishlistpopup').modal('hide');
            $('#wishlist').load('/eCommerce/Products/WishlistCount', function() {
                if (!$('.dropdown-toggle').parent().hasClass('open')) {
                    $('.dropdown-toggle').dropdown('toggle');
                }
                else {
                    var new_position = $('.dropdown-toggle').offset();
                    $('html, body').stop().animate({ scrollTop: new_position.top }, 200);
                }
            });
        });
    });
}