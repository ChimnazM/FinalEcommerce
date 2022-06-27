$(document).ready(function () {
    "use strict";

    var menuActive = false;
    var header = $('.header');
    setHeader();
    initCustomDropdown();
    initPageMenu();

    function setHeader() {

        if (window.innerWidth > 991 && menuActive) {
            closeMenu();
        }
    }

    function initCustomDropdown() {
        if ($('.custom_dropdown_placeholder').length && $('.custom_list').length) {
            var placeholder = $('.custom_dropdown_placeholder');
            var list = $('.custom_list');
        }

        placeholder.on('click', function (ev) {
            if (list.hasClass('active')) {
                list.removeClass('active');
            }
            else {
                list.addClass('active');
            }

            $(document).one('click', function closeForm(e) {
                if ($(e.target).hasClass('clc')) {
                    $(document).one('click', closeForm);
                }
                else {
                    list.removeClass('active');
                }
            });

        });

        $('.custom_list a').on('click', function (ev) {
            ev.preventDefault();
            var index = $(this).parent().index();

            placeholder.text($(this).text()).css('opacity', '1');

            if (list.hasClass('active')) {
                list.removeClass('active');
            }
            else {
                list.addClass('active');
            }
        });


        $('select').on('change', function (e) {
            placeholder.text(this.value);

            $(this).animate({ width: placeholder.width() + 'px' });
        });
    }

    /*
    
    4. Init Page Menu
    
    */

    /////Preloader
    $(window).on("load", function (e) {
        //e.preventDefault();
        $(".loader-container").fadeOut(1000);
    });

    if (window.location.pathname == '/') {
        //Focus automatically top search input first

        $("input.header_search_input").focus();

    }

    //If webp not allewed by browser change href
    //if (!$.browser.chrome) {

    //    $(".tab-icon").attr("href", "");
    //}

    function initPageMenu() {
        if ($('.page_menu').length && $('.page_menu_content').length) {
            var menu = $('.page_menu');
            var menuContent = $('.page_menu_content');
            var menuTrigger = $('.menu_trigger');

            //Open / close page menu
            menuTrigger.on('click', function () {
                if (!menuActive) {
                    openMenu();
                }
                else {
                    closeMenu();
                }
            });

           
        }
    }

    function openMenu() {
        var menu = $('.page_menu');
        var menuContent = $('.page_menu_content');
        TweenMax.set(menuContent, { height: "auto" });
        TweenMax.from(menuContent, 0.3, { height: 0 });
        menuActive = true;
    }

    function closeMenu() {
        var menu = $('.page_menu');
        var menuContent = $('.page_menu_content');
        TweenMax.to(menuContent, 0.3, { height: 0 });
        menuActive = false;
    }

    //CUSTOM JS



    ///Add to cart Toast
    $(".add-to-card-index-btn").click(function (e) {
        e.preventDefault();
        //get product name
        let ul = $(this).parent().parent();
        let name = ul.parents("div.item").find("h5").children().text();


        //Get product type id and quantity
        var TypeId = $(this).data("id");
        var Quantity = $(this).data("quantity");

        //console.log(TypeId);
        //console.log(Quantity);

        if (TypeId == undefined || Quantity == undefined) {
            toastr.error('This product was not added cart list..', { timeOut: 3000 });
        }
        else {

            $.ajax({

                url: "/shop/addToCart/",
                type: "get",
                dataType: "json",

                data: { typeId: TypeId, quantity: Quantity },
                success: function (response) {

                    if (response != -404) {

                        //cart toast counter
                        $(".cart_count span").text(response);

                        $(".cart_price").change();



                        //if success show popups
                        $(".toast-content .added-prd-name").text(name);
                        $(".add-to-card-toast").fadeIn().delay(2000).fadeOut(500);
                        $(".add-to-card-toast .cart_count").fadeIn().delay(2000).fadeOut();
                    }
                    else {
                        toastr.info('Already exist in the cart', name, { timeOut: 3000 });
                    }


                },
                error: function (response) {

                    console.log("error: " + response);
                }

            });

        }

    });


    $(".cart_price").on("change", function (e) {
        e.preventDefault();

        $.ajax({

            url: "/shop/getToCartSum/",
            type: "get",
            dataType: "json",

            //data: { typeId: TypeId, quantity: Quantity },
            success: function (response) {
                var sum = response.toFixed(2);
                //cart toast counter
                $(".cart_price").text("$" + sum);
            },
            error: function (response) {

                console.log("error: " + response);
            }

        });


    });



    //Add to cart Detail Toast
    $(".add-to-card-detail-btn").click(function (e) {
        //
        var name = $(".prd-toast-name").text();

        var quantity = $(".number-spinner").val();
        var productId = $(this).data("productid");
        var colorId = $(".detail-prd-color span.active").data("colorid");
        var sizeId = $(".detail-prd-size ul li.active").data("sizeid");
        var typeId = $(this).data("typeid");

        //console.log(typeId);

        if (colorId == undefined || sizeId == undefined) {
            toastr.error('Please, select color and size.', { timeOut: 3000 });
        }
        else {
            $.ajax({

                url: "/shop/addToCart/",
                type: "get",
                dataType: "json",

                data: { typeId: typeId, quantity: quantity },
                success: function (response) {

                    //location.reload();

                    if (response != -404 && response != 404) {
                        //cart toast counter
                        $(".cart_count span").text(response);


                        //if success show popups
                        $(".toast-content .prd-toast-name").text(name);
                        $(".add-to-card-toast").fadeIn().delay(2000).fadeOut(500);
                        $(".add-to-card-toast .cart_count").fadeIn().delay(2000).fadeOut();

                        CalculateAddToCartSum();

                    }
                    else {
                        toastr.error('This product already exist in the cart', { timeOut: 3000 });
                    }

                    

                },
                error: function (response) {

                    console.log("error: " + response);
                }

            });

        }

    });

    function CalculateAddToCartSum() {
        $.ajax({

            url: "/shop/getToCartSum/",
            type: "get",
            dataType: "json",

            //data: { typeId: TypeId, quantity: Quantity },
            success: function (response) {
                var sum = response.toFixed(2);
                //cart toast counter
                $(".cart_price").text("$" + sum);
            },
            error: function (response) {

                console.log("error: " + response);
            }

        });
    };

    ///Add to cart from Wishlist
    $(".add-to-cart-from-wish").click(function (e) {
        e.preventDefault();
        //get product name
        var name = $(this).data("name");

        //Get product type id and quantity
        var TypeId = $(this).data("id");
        var Quantity = 1;

        //this
        var removeBtn = $(this).parent().find("a.wish-delete-btn");


        if (TypeId == undefined || Quantity == undefined) {

            toastr.error('Please, select color and size.', { timeOut: 3000 });
        }
        else {

            $.ajax({

                url: "/shop/addToCart/",
                type: "get",
                dataType: "json",

                data: { typeId: TypeId, quantity: Quantity },
                success: function (response) {

                    if (response != -404) {
                        $(".cart_count span").text(response);

                        $(".cart_price").change();

                        //Remove this wish item from wishlist
                        removeBtn.click();


                        //if success show popups
                        $(".toast-content .added-prd-name").text(name);
                        $(".add-to-card-toast").fadeIn().delay(2000).fadeOut(500);
                        $(".add-to-card-toast .cart_count").fadeIn().delay(2000).fadeOut();
                    }
                    else {
                        toastr.info('Already exist in the cart', name, { timeOut: 3000 });
                    }
                    //cart toast counter


                },
                error: function (response) {

                    console.log("error: " + response);
                }

            });

        }

    });


    ///Add to wishlist Toast
    $(".add-to-wishlist-index-btn").click(function () {

        let ul = $(this).parent().parent();
        let name = ul.parents("div.item").find("h5").children().text();

        var TypeId = $(this).data("id");

        if (TypeId == undefined) {

            toastr.error('This product was not added to the wish list', { timeOut: 3000 });
        }
        else {

            $.ajax({

                url: "/shop/addToWish/",
                type: "get",
                dataType: "json",

                data: { typeId: TypeId },
                success: function (response) {

                    //console.log(response);
                    //location.reload();

                    if (response == -404) {


                        toastr.info('Already exist in the wish list', name, { timeOut: 3000 });

                    }
                    else if (response == 404) {
                        toastr.error('This product was not added to the wish list', { timeOut: 3000 });
                    }
                    else {
                        //cart toast counter
                        $(".wishlist_count").text(response);


                        //if success show popups
                        let name = ul.parents("div.item").find("h5").children().text();
                        $(".wish-toast-content .added-prd-name").text(name);
                        $(".add-to-wish-toast").fadeIn().delay(2000).fadeOut(500);
                    }


                },
                error: function (response) {

                    console.log("error: " + response);
                }

            });

        }
    });

    ///Add to wishlist Detail Toast
    $(".add-to-wishlist-detail-btn").click(function (e) {
        //
        var name = $(".prd-toast-name").text();

        var productId = $(this).data("productid");
        var colorId = $(".detail-prd-color span.active").data("colorid");
        var sizeId = $(".detail-prd-size ul li.active").data("sizeid");
        var typeId = $(this).data("typeid");

        if (colorId == undefined || sizeId == undefined) {
            toastr.error('Please, select color and size.', { timeOut: 3000 });
        }
        else {

            $.ajax({

                url: "/shop/addToWish/",
                type: "get",
                dataType: "json",

                data: { typeId: typeId },
                success: function (response) {

                    //console.log(response);
                    //location.reload();

                    //cart toast counter
                    $(".wishlist_count").text(response);

                    $(".wish-toast-content .added-prd-name").text(name);
                    $(".add-to-wish-toast").fadeIn().delay(2000).fadeOut(500);

                },
                error: function (response) {

                    console.log("error: " + response);
                }

            });

        }

    });



    //Get add to cart item's count
    $.ajax({

        url: "/shop/getToCartCount/",
        type: "get",
        dataType: "json",

        //data: { typeId: TypeId, quantity: Quantity },
        success: function (response) {

            //cart toast counter
            $(".cart_count span").text(response);
        },
        error: function (response) {

            console.log("error: " + response);
        }

    });

    //Get add to cart item's sum
    $.ajax({

        url: "/shop/getToCartSum/",
        type: "get",
        dataType: "json",

        //data: { typeId: TypeId, quantity: Quantity },
        success: function (response) {
            var sum = response.toFixed(2);
            //cart toast counter
            $(".cart_price").text("$" + sum);
        },
        error: function (response) {

            console.log("error: " + response);
        }

    });

    //Get wishlist item's count
    $.ajax({

        url: "/shop/getToWishCount/",
        type: "get",
        dataType: "json",

        //data: { typeId: TypeId, quantity: Quantity },
        success: function (response) {

            //cart toast counter
            $(".wishlist_count").text(response);
        },
        error: function (response) {

            console.log("error: " + response);
        }

    });



    $(".menu_burger_inner").click(function () {
        $(this).toggleClass("open");

    });



    $(window).scroll(function () {
        if ($("#isOpen").hasClass("open") != true) {
            if ($(document).scrollTop() >= 100) {
                $(".fixed-nav").addClass("animate__animated animate__fadeInDown");
                $(".fixed-nav").css({ "position": "fixed", "z-index": "98", "background-color": "#fff", "opacity": "0.9" });
                if ($(window).width() < 992) {
                    $(".header_search").addClass("d-none");
                }
                $(".top_bar").addClass("d-none");
                $(".main_nav").addClass("d-none");
                $(".page_menu").addClass("d-none");
                $(".header_main").css({ "padding-bottom": "15px" });



            } else {
                $(".fixed-nav").css({ "position": "relative", "z-index": "1", "background-color": "#fff", "opacity": "1" });
                // if($(window).width() < 992){
                //     $(".header_search").removeClass( "d-none" );
                // }
                $(".header_search").removeClass("d-none");

                $(".top_bar").removeClass("d-none");
                $(".main_nav").removeClass("d-none");
                $(".page_menu").removeClass("d-none");
                $(".header_main").css({ "padding-bottom": "0" });
                $(".fixed-nav").removeClass("animate__animated animate__fadeInDown");



            }
        };


    });


    //  Do something with Carousel
    $('#carouselExampleControls').on('slide.bs.carousel', function () {
        // do something…
    })


    $('.cards-links ul li').click(function () {
        // store anything commonly called in variables to speed up your code
        const $this = $(this);
        const $link = $this.children();
        $('.cards-links .nav-link').removeClass('active');
        $link.addClass('active');
        const linkItem = $this.data("filter");


        //console.log(linkItem);


        if ($(".card-items .card").hasClass(linkItem)) {
            const $items = $(".card-items");

            //   opacity off and on
            $('.card-items .card').addClass('anime-Opacity');




            console.log($items);

            $items.children('div:not(.' + linkItem + ')').hide();
            //   show all elements that do share ourClass
            $items.children('div.' + linkItem).show();
        }

    });


    $(".owl-carousel").owlCarousel({

        // loop: true,
        navigation: false,
        navigationText: false,
        pagination: false,
        goToFirst: true,
        autoWidth: true,

        // Responsive
        responsive: true,
        items: 4,
        itemsDesktop: [1300, 4],
        itemsDesktopSmall: [1299, 3],
        itemsTablet: [768, 2],
        itemsMobile: [479, 1]

    });

    $("#owl-prev").click(function () {
        var owl = $("#owl-demo").data('owlCarousel');
        owl.prev();
    });

    $("#owl-next").click(function () {
        var owl = $("#owl-demo").data('owlCarousel');
        owl.next();
    });

    // testimonial carousel

    $(".owl-stage").owlCarousel({
        //Basic Speeds
        slideSpeed: 200,
        paginationSpeed: 800,

        //Autoplay
        autoPlay: true,
        goToFirst: true,
        goToFirstSpeed: 1000,

        // loop: true,
        navigation: false,
        navigationText: false,
        pagination: false,
        goToFirst: true,
        autoWidth: true,

        // Responsive
        responsive: true,
        items: 2,
        itemsDesktop: [1300, 2],
        itemsDesktopSmall: [1299, 2],
        itemsTablet: [768, 2],
        itemsMobile: [767, 1]

    });

    $("#testimonial-prev").click(function () {
        var owl = $(".owl-stage").data('owlCarousel');
        owl.prev();
    });

    $("#testimonial-next").click(function () {
        var owl = $(".owl-stage").data('owlCarousel');
        owl.next();
    });

    // partners carousel
    $(".partner-imagebox").owlCarousel({
        //Basic Speeds
        slideSpeed: 200,

        //Autoplay
        autoPlay: 10000,
        goToFirst: true,
        goToFirstSpeed: 1000,

        loop: true,
        navigation: false,
        navigationText: false,
        pagination: false,
        goToFirst: true,
        autoWidth: true,


        // Responsive
        responsive: true,
        items: 5,
        itemsDesktop: [1199, 4],
        itemsDesktopSmall: [768, 4],
        itemsTablet: [767, 3],
        itemsMobile: [534, 2]

    });

    //Shop pages sidebar control
    //open
    $("#filter-btn").click(function () {
        $('#mobile-filter-menu').removeClass('d-none');
    });
    //close
    $("#filter-close").click(function () {
        $('#mobile-filter-menu').addClass('d-none');
    });

    //Details counter

    //increase

    $(".spinner-prev").click(function () {
        var prev = parseInt($(".spinner input").val());
        //console.log(prev);
        if (prev == 1) {
            $(".spinner input").val('1');

        }
        else {
            var prevVal = prev - 1;
            $(".spinner input").val(prevVal);
            $(".add-to-card-detail-btn").data("quantity", prevVal);

        }
    });


    // //decrease

    $(".spinner-next").click(function () {
        var next = parseInt($(".spinner input").val());
        var max = parseInt($(".spinner input").attr('max'));
        if (next >= max) {
            $(".spinner input").val(max);
            $(".add-to-card-detail-btn").data("quantity", max);

        }
        else {
            var nextVal = next + 1;
            $(".spinner input").val(nextVal);
            $(".add-to-card-detail-btn").data("quantity", nextVal);

        }

    });

    //input's limite
    $(".number-spinner").on("keyup", function () {
        var inputValue = parseInt($(".spinner input").val());
        var max = parseInt($(".spinner input").attr('max'));

        if (inputValue >= max) {
            $(".number-spinner").val(max);
            $(".add-to-card-detail-btn").data("quantity", max);

        }
        else if (inputValue < 1) {
            $(".number-spinner").val("1");
            $(".add-to-card-detail-btn").data("quantity", 1);

        }
    });


    $(".number-spinner").focusout(function () {
        var stringValue = $(".spinner input").val();

        if (stringValue == "") {
            $(".spinner input").val(1);
        }

    });





    //on pressed on input not reacting (details)
    $(".number-spinner").keypress(function (e) {

        if (e.keyCode == 13) {
            e.preventDefault();
            return false;
        }
    });


    ///Detail's tab button control

    //On description Off review
    $("#desc").click(function () {

        if (!$(this).hasClass("active")) {
            $(this).addClass("active");
            $("#review").removeClass("active");
            $(".reviews").addClass("d-none");
            $(".write-comment").addClass("d-none");
            $(".description").removeClass("d-none");
        }
    });

    //On review Off description

    $("#review").click(function () {

        if (!$(this).hasClass("active")) {
            $(this).addClass("active");
            $("#desc").removeClass("active");
            $(".description").addClass("d-none");
            $(".reviews").removeClass("d-none");
            $(".write-comment").removeClass("d-none");
        }
    });



    ///Comment stars control

    $("#s1").click(function () {
        $('.comment-stars .fas').removeClass("fas").addClass("far");
        $("#s1 .fa-star").removeClass("far").addClass("fas");
        $("#comment-star").val(1);

    });

    $("#s2").click(function () {
        $('.comment-stars .fas').removeClass("fas").addClass("far");
        $("#s1 .fa-star").removeClass("far").addClass("fas");
        $("#s2 .fa-star").removeClass("far").addClass("fas");
        $("#comment-star").val(2);

    });

    $("#s3").click(function () {
        $('.comment-stars .fas').removeClass("fas").addClass("far");
        $("#s1 .fa-star").removeClass("far").addClass("fas");
        $("#s2 .fa-star").removeClass("far").addClass("fas");
        $("#s3 .fa-star").removeClass("far").addClass("fas");
        $("#comment-star").val(3);

    });

    $("#s4").click(function () {
        $('.comment-stars .fas').removeClass("fas").addClass("far");
        $("#s1 .fa-star").removeClass("far").addClass("fas");
        $("#s2 .fa-star").removeClass("far").addClass("fas");
        $("#s3 .fa-star").removeClass("far").addClass("fas");
        $("#s4 .fa-star").removeClass("far").addClass("fas");
        $("#comment-star").val(4);
    });

    $("#s5").click(function () {
        $('.comment-stars .fas').removeClass("fas").addClass("far");
        $("#s1 .fa-star").removeClass("far").addClass("fas");
        $("#s2 .fa-star").removeClass("far").addClass("fas");
        $("#s3 .fa-star").removeClass("far").addClass("fas");
        $("#s4 .fa-star").removeClass("far").addClass("fas");
        $("#s5 .fa-star").removeClass("far").addClass("fas");
        $("#comment-star").val(5);
    });

    //Default image Detail
    $(".imgBox img").attr("src", $(".mini-image-box li:first-child img").attr("src"));
    //Get default product color
    var defaultPrdColor = $('.mini-image-box li:first-child img').data("img-color");

    //Set default color to button
    if (defaultPrdColor == "white") {
        $('.detail-prd-color').find('.' + defaultPrdColor).children().css({ "opacity": "1", "color": "black" });
    }
    else {
        $('.detail-prd-color').find('.' + defaultPrdColor).children().css({ "opacity": "1" });
    }

    //find default color button Id
    var thisButton = $('.detail-prd-color').find('.' + defaultPrdColor);
    var thisButtonId = thisButton.data("colorid");
    var thisPrdId = thisButton.data("productid");

    $.ajax({

        url: "/shop/getSizesByColor/",
        type: "get",
        dataType: "json",

        data: { productId: thisPrdId, colorId: thisButtonId },
        success: function (response) {

            //reset all sizes 
            $('.detail-prd-size ul li').addClass("not-allowed").addClass("d-none").css({ "cursor": "not-allowed" });


            //set only current sizes
            for (var i = 0; i < response.length; i++) {

                var activeSizeId = response[i];

                var currentSize = $('.detail-prd-size ul ').find('#' + activeSizeId).removeClass("not-allowed").removeClass("d-none").css({ "cursor": "pointer" });

            }

            $('.detail-prd-size ul li.active').click();



        },
        error: function (response) {

            console.log("error: " + response);
        }

    });


    //add to cart Colors to Sizes default
    $('.add-prd-color').each(function () {

        var colorId = $(this).find("span.active").data("colorid");
        var productId = $(this).find("span.active").data("productid");


        var This = $(this);

        $.ajax({

            url: "/shop/getSizesByColor/",
            type: "get",
            dataType: "json",

            data: { productId: productId, colorId: colorId },
            success: function (response) {

                //reset all sizes 
                //This.next().find("li").addClass("d-none");

                ////set only current sizes
                for (var i = 0; i < response.length; i++) {

                    var activeSizeId = response[i];
                    This.next().find('#' + activeSizeId).removeClass("d-none");
                }


            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

    });

    //default gelen renge active classi elave et
    $('.detail-prd-color').find('.' + defaultPrdColor).addClass("active");;

    $(".mini-img").click(function () {
        var value = $(this).attr("src");
        $(".imgBox img").attr("src", value);

        var btnBox = $(`.detail-prd-color`);

        var classValue = '.' + $(this).data("img-color");
        var btn = btnBox.find(classValue);

        var color = $(this).data("img-color");

        $(".detail-prd-color span i").css({ "opacity": "0" });


        if (color == "white") {
            btn.children().css({ "opacity": "1", "color": "black" });
        }
        else {
            btn.children().css({ "opacity": "1" });
        }

        $('.nested-image-box').izoomify({
            url: value,
            magnify: 1.7

        });
    });

    ///Change pictures by color control - Detail
    $('.detail-prd-color span:not(.not-allowed)').click(function () {
        $(".detail-prd-color span i").css({ "opacity": "0" });
        var color = $(this).data("btn-color");


        //hansi reng click olunursa ona active classi elave olunur
        $(".detail-prd-color span").removeClass("active");
        $(this).addClass("active");

        if (color == "white") {
            $(this).find("i").css({ "opacity": "1", "color": "black" });
        }
        $(this).find("i").css({ "opacity": "1" });


        var currentImage = $(`[data-img-color="${color}"]`);
        var currentImageSrc = currentImage.attr("src");
        $(".imgBox img").attr("src", currentImageSrc);

        $('.nested-image-box').izoomify({
            url: currentImageSrc,
            magnify: 1.7

        });

        let colorId = parseInt($(this).data("colorid"));
        let productId = parseInt($(this).data("productid"));


        $.ajax({

            url: "/shop/getSizesByColor/",
            type: "get",
            dataType: "json",

            data: { productId: productId, colorId: colorId },
            success: function (response) {

                //reset all sizes 
                $('.detail-prd-size ul li').removeClass("active").addClass("not-allowed").addClass("d-none").css({ "cursor": "not-allowed" });


                //set only current sizes
                for (var i = 0; i < response.length; i++) {

                    var activeSizeId = response[i];

                    var currentSize = $('.detail-prd-size ul ').find('#' + activeSizeId).removeClass("not-allowed").removeClass("d-none").css({ "cursor": "pointer" });

                    //if (i == 0) {
                    //    currentSize.click();
                    //}
                }

                ////Click firstorDefault Size button
                $('.detail-prd-size ul li:not(.d-none)').first().click();
            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

    })

    ///Change detail product size
    $('.detail-prd-size ul li:not(.not-allowed)').click(function () {
        $('.detail-prd-size ul li').removeClass("active");
        $(this).addClass("active");

        let sizeId = parseInt($(this).data("sizeid"));
        let colorId = parseInt($(".detail-prd-color span.active").data("colorid"));
        let productId = parseInt($(this).data("productid"));



        $.ajax({

            url: "/shop/getPriceByType/",
            type: "get",
            dataType: "json",

            data: { colorId: colorId, sizeId: sizeId, productId: productId },
            success: function (response) {

                //type id
                var typeId = response.typeId;
                $(".add-to-card-detail-btn").data("typeid", typeId);
                $(".add-to-wishlist-detail-btn").data("typeid", typeId);


                //yuvarlaqi tapmaq
                var price = response.price + "";
                var discountprice = response.discountPrice + "";

                //price
                var resultstring1 = price.split('.');
                var fistPartprice = resultstring1[0];
                var secondPartprice = resultstring1[1];

                if (secondPartprice == undefined) {
                    var newPrice = price + ".00";
                } else {
                    var newPrice = price;
                }

                //discountprice
                var resultstring2 = discountprice.split('.');
                var fistPartdiscountprice = resultstring2[0];
                var secondPartdiscountprice = resultstring2[1];

                if (secondPartdiscountprice == undefined) {
                    var newDiscountPrice = discountprice + ".00";
                } else {
                    var newDiscountPrice = discountprice;
                }

                if (response.isDiscount == true) {

                    let oldP = '<span class="old-price"> $' + newPrice + '</span>';
                    let newP = '<span class="new-price"> $' + newDiscountPrice + '</span>';
                    let ul = $(".price");

                    ul.empty();
                    ul.append(oldP);
                    ul.append(newP);

                } else {

                    let newP = '<span class="new-price"> $' + newPrice + '</span>';
                    let ul = $(".price");

                    ul.empty();
                    ul.append(newP);
                }


                let input = $(".number-spinner");

                $(input).attr({
                    "max": response.quantity,
                    "min": 1
                });

                var inputValue = parseInt($(input).val());
                var maxValue = parseInt($(input).attr('max'));

                if (inputValue > maxValue) {
                    input.val(maxValue);
                };

                //console.log(response.quantity);

            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

        //if (parseInt(quantity) > 0) {

        //    if (deadline == "True") {
        //        $('.old-price').removeClass("d-none");
        //        $('.old-price').text("$" + price);

        //        if (parseFloat(discount) > 0)
        //        {
        //            $('.new-price').text("$" + discount);
        //        }
        //        else
        //        {
        //            $('.new-price').text("$" + price);
        //            $('.old-price').addClass("d-none");
        //        }

        //    }
        //    else {
        //        $('.old-price').addClass("d-none");
        //        $('.new-price').text("$" + price);
        //    }
        //}
        //else {
        //    $('.old-price').addClass("d-none");
        //}


    })



    $(".mini-image-box").owlCarousel({
        //Basic Speeds
        slideSpeed: 200,
        paginationSpeed: 800,

        //Autoplay
        //  autoPlay : true,
        //  goToFirst : true,
        //  goToFirstSpeed : 1000,

        loop: true,
        navigation: false,
        navigationText: false,
        pagination: false,
        goToFirst: true,
        autoWidth: true,
        // Responsive
        responsive: true,
        items: 4,
        itemsDesktop: [1199, 4],
        itemsDesktopSmall: [991, 3],
        itemsTablet: [767, 4],
        itemsMobile: [455, 3]

    });

    $("#detail-prev").click(function () {
        var owl = $(".mini-image-box").data('owlCarousel');
        owl.prev();
    });

    $("#detail-next").click(function () {
        var owl = $(".mini-image-box").data('owlCarousel');
        owl.next();
    });


    ///Details zoom image
    $('.nested-image-box').izoomify({
        url: $(".imgBox img").attr("src"),
        magnify: 1.7

    });


    /// Share plugins for details

    /* 
    
    https://api.whatsapp.com/send?text=[post-title] [post-url]
    
    
    https://www.facebook.com/sharer.php?u=[post-url]
    
    
    https://twitter.com/share?url=[post-url]&text=[post-title]&via=[via]&hashtags=[hashtags]
    
    https://pinterest.com/pin/create/bookmarklet/?media=[post-img]&url=[post-url]&is_video=[is_video]&description=[post-title]
    
    https://www.linkedin.com/shareArticle?url=[post-url]&title=[post-title]
    
    https://www.tumblr.com/share/link?url=[post-url]&name=[post-title]&description=[post-desc]
    
    
    
    */



    const facebookBtn = $(".facebook-btn");
    const twitterBtn = $(".twitter-btn");
    const pinterestBtn = $(".pinterest-btn");
    const linkedinBtn = $(".linkedin-btn");
    const tumblrBtn = $(".tumblr-btn");



    let pinterestImg = encodeURI($(".nested-image-box img").attr("src"));
    let postUrl = encodeURI(window.location.href);
    let postTitle = encodeURI($(".product-title").text());

    facebookBtn.attr("href", `https://www.facebook.com/sharer.php?u=${postUrl}`);
    twitterBtn.attr("href", `https://twitter.com/share?url=${postUrl}&text=${postTitle}`);
    pinterestBtn.attr("href", `https://pinterest.com/pin/create/bookmarklet/?media=${pinterestImg}&url=${postUrl}&description=${postTitle}`);
    linkedinBtn.attr("href", `https://www.linkedin.com/shareArticle?url=${postUrl}&title=${postTitle}`);
    tumblrBtn.attr("href", `https://www.tumblr.com/share/link?url=${postUrl}&name=${postTitle}`);



    ///Scroll top button
    $(window).scroll(function () {

        if ($(this).scrollTop() > 70 && $(this).width() > 991) {
            $(".scroll-top-btn").fadeIn();
        }
        else {
            $(".scroll-top-btn").fadeOut();
        }

    });


    $(".scroll-top-btn").click(function () {

        $('html, body').animate({ scrollTop: 0 }, 800);
    });

    if ($(window).width() < 991) {
        $(".scroll-top-btn").fadeOut();
    }

    //Mobile and tablet menu width control
    $(window).resize(function () {
        var width = $(window).width();
        if (width > 991) {
            //$(".menu_trigger_container ml-auto").fadeOut();
            $(".page_menu_content").css({ "display": "none" });
        } else {
            //$(".menu_trigger_container ml-auto").fadeIn();
            if ($("#isOpen").hasClass("open")) {
                $(".page_menu_content").css({ "display": "block"});
            }
            else {
                $(".page_menu_content").css({ "display": "block", "height": "0" });
            }

        }
    });


    ///Profile button active control
    $(".profile-btn").mouseenter(function () {
        $(".profile-dropdown").fadeIn();
        $(".profile-btn").addClass("active");

        $(".profile-dropdown").mouseleave(function () {
            $(".profile-dropdown").fadeOut();
            $(".profile-btn").removeClass("active");

        })

        $(".top_bar").mouseleave(function () {
            $(".profile-dropdown").fadeOut();
            $(".profile-btn").removeClass("active");
        })

    })



    $(".profile-btn").click(function () {
        $(".profile-dropdown").fadeIn();
        $(".profile-btn").addClass("active");
    });



    //Add to cart delete item
    $(".add-cart-delete-btn").click(function (e) {
        e.preventDefault();
        
        var typeId = parseInt($(this).data("typeid"));

        $.ajax({

            url: "/shop/RemoveFromCart/",
            type: "get",
            dataType: "json",

            data: { id: typeId },
            success: function (response) {
                console.log(response);
                if (response == 200) {
                    location.reload();
                }

            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

    });

    //Wishlist delete item
    $(".wish-delete-btn").click(function (e) {
        e.preventDefault();

        var typeId = parseInt($(this).data("typeid"));
        var itemBox = $(this).parent().parent();

        $.ajax({

            url: "/shop/RemoveFromWish/",
            type: "get",
            dataType: "json",

            data: { id: typeId },
            success: function (response) {
                if (response == 200) {
                    itemBox.remove();
                    GetWishCount();

                } else {
                    location.reload();
                }

            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

    });
    //get wish clunt
    function GetWishCount() {
        $.ajax({

            url: "/shop/getToWishCount/",
            type: "get",
            dataType: "json",

            //data: { typeId: TypeId, quantity: Quantity },
            success: function (response) {

                //cart toast counter
                $(".wishlist_count").text(response);
            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

    };

    //Add to cart spinner

    //decrease
    $(".spinner-next-cart").click(function () {
        var oldValue = parseInt($(this).prev().val());
        var maxValue = parseInt($(this).data("max"));
        if (oldValue < maxValue) {
            var newValue = oldValue + 1;
            $(this).prev().val(newValue);

            var input = $(this).prev();
            $(input).change();

        }

    });

    //increase
    $(".spinner-prev-cart").click(function () {
        var oldValue = parseInt($(this).next().val());

        if (oldValue > 1) {
            var newValue = oldValue - 1;
            $(this).next().val(newValue);

            var input = $(this).next();
            $(input).change();
        }

    });

    //Add to cart input's limite
    $(".number-spinner-cart").on("keyup", function (e) {
        e.preventDefault();
        var inputValue = parseInt($(this).val());
        var maxValue = parseInt($(this).next().data("max"));
        if (inputValue > maxValue) {
            $(this).val(maxValue);
        }
        if (inputValue < 0) {
            $(this).val(1);
        }

        //add change function
        $(this).change();
    });


    //on pressed on input not reacting (add to cart)
    $(".number-spinner-cart").keypress(function (e) {

        if (e.keyCode == 13) {
            e.preventDefault();
            return false;
        }
    });


    $(".number-spinner-cart").on("change", function (e) {
        e.preventDefault();

        
        var price = parseFloat($(this).data("price"));
        var quantity = parseInt($(this).val());
        var typeId = parseInt($(this).data("typeid"));

        

        //total box
        var oldValue = $(this).parent().parent().parent().next().find("strong");
        

        //for checking empty value
        var stringValue = $(this).val();

        if (quantity != null && quantity > 0 && stringValue != "") {

            //ajax
            $.ajax({

                url: "/shop/UpdateCart/",
                type: "get",
                dataType: "json",

                data: {
                    id: typeId,
                    quantity: quantity
                },
                success: function (response) {

                    console.log(response);

                },
                error: function (response) {

                    console.log("error: " + response);
                }

            });





            
            oldValue.empty();
            var total = parseFloat(price * quantity).toFixed(2);
            oldValue.text("$" + total);

            var sum = 0;
            $('.add-prd-total').each(function () {
                var prdTotal = parseFloat($(this).children().text().slice(1, $(this).children().text().length));
                sum += prdTotal;
            });

            //console.log(sum.toFixed(2));

            $("#subtotal").text("$" + sum.toFixed(2));

            if (sum < 100) {
                $("#tax").text("$" + (sum * 18 / 100).toFixed(2));
                $("#orderTotal").text("$" + (sum + (sum * 18 / 100)).toFixed(2)); 
            }
            else {
                $("#tax").text("$0.00");
                $("#orderTotal").text("$" + sum.toFixed(2)); 
                $(".cart_price").text("$" + sum.toFixed(2)); 
            }

            
        }

    });

    $(".number-spinner-cart").focusout(function (e) {
        //for checking empty value
        var stringValue = $(this).val();
        var intValue = parseInt($(this).val());

        if (stringValue == "") {
            $(this).val(1);
            $(this).change();
        }
        if (intValue < 1) {
            $(this).val(1);
            $(this).change();
        }
    });

    //Add to cart color change
    $(".add-prd-color span:not(.active)").click(function (e) {
        e.preventDefault();

        var typeId = parseInt($(this).data("typeid"));
        var colorId = parseInt($(this).data("colorid"));
        var quantity = $(this).parent().parent().parent().parent().parent().find(".number-spinner-cart").val();

        var parseQuantity = parseInt(quantity);

        console.log(parseQuantity);


        $.ajax({

            url: "/shop/UpdateColorCart/",
            type: "get",
            dataType: "json",

            data: {
                typeId: typeId,
                colorId: colorId,
                quantity: parseQuantity,
            },
            success: function (response) {

                if (response == 404) {
                    alert("error")
                }
                else {
                    location.reload();
                }

            },
            error: function (response) {

                console.log("error: " + response);
            }

        });


    });

    $(".add-prd-size ul li:not(.active)").click(function (e) {
        e.preventDefault();

        var sizeId = parseInt($(this).data("sizeid"));
        var typeId = parseInt($(this).data("typeid"));
        var quantity = $(this).parent().parent().parent().parent().parent().parent().find(".number-spinner-cart").val();
        var parseQuantity = parseInt(quantity);
        //console.log(parseQuantity);

        var This = $(this);

        $.ajax({

            url: "/shop/UpdateSizeCart/",
            type: "get",
            dataType: "json",

            data: {
                typeId: typeId,
                sizeId: sizeId,
                quantity: parseQuantity,
            },
            success: function (response) {

                if (response == 404) {
                    alert("error")
                }
                else {
                    location.reload();
                }
                console.log(response)

            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

    });

    $("#selectlistitems option:first").prop('disabled', true);

    $("#product-sort").on("change", function () {
        $("#sort-btn").click();
    });

    $("#subscribe-form").submit(function (e) {
        e.preventDefault();

        var email = $("#subscribe-input").val();

        var pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;

        if (email == "") {
            toastr.error('Please, input your email address.', { timeOut: 3000 });
        }
        else if (!pattern.test(email)) {
            toastr.error('Not a valid e-mail address.', { timeOut: 3000 });
        }
        else {
            $.ajax({

                url: "/contact/addSubscribe/",
                type: "get",
                dataType: "json",

                data: { email: email },
                success: function (response) {
                    if (response == 200) {
                        //success
                        toastr.success('Now you are our subscriber, Thank you!', { timeOut: 3000 });

                    }
                    else if (response == 505) {
                        //error
                        toastr.info('You are already subscribed us', { timeOut: 3000 });
                    }
                    else {
                        //error
                        toastr.error('Please, input your email address.', { timeOut: 3000 });
                    }
                },
                error: function (response) {

                    console.log("error: " + response);
                }

            });

        }

    });

    $(".change-picture-btn").click(function (e) {
        e.preventDefault();

        $(".hidden-img-input").click();


    });

    $('#selectlistitems').on('change', function () {

        var countryId = parseInt(this.value);

        //Old Shipping Price
        var oldText = $("#shipping-price").text();
        var oldVal = parseFloat(oldText.substr(1));

        //Old Subtotal
        var subText = $(".checkout-subtotal").text();
        var subtotal = parseFloat(subText.substr(1));

        $.ajax({

            url: "/shop/getShippingPrice/",
            type: "get",
            dataType: "json",

            data: { countryId: countryId },
            success: function (response) {


                if (oldText != "Free") {

                    var resetSub = subtotal - oldVal;
                    $(".checkout-subtotal").text("$" + resetSub.toFixed(2));
                    subtotal = resetSub;
                }


                if (parseFloat(response) > 0) {

                    var price = parseFloat(response);
                    $("#shipping-price").text("$" + price.toFixed(2));
                    var sumSubAndShipping = price + subtotal;
                    $(".checkout-subtotal").text("$" + sumSubAndShipping.toFixed(2));

                } else {
                    $("#shipping-price").text("Free");
                }

            },
            error: function (response) {

                console.log("error: " + response);
            }

        });


    });

    $('#showpassword').on('change', function () {

        if ($(this).prop('checked') === true) {
            $('#password').attr('type', 'text');
            $('#confirmPassword').attr('type', 'text');
        } else {
            $('#password').attr('type', 'password');
            $('#confirmPassword').attr('type', 'password');
        }
    });

    
});













