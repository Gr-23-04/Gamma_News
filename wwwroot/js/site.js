// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {


    var last_scroll = 0;
    var desk_menu = 0;
    var prof_menu = 0;
    var cookie_choice = sessionStorage.getItem('cookie_choice');
    var local_cookie_choice = localStorage.getItem('local_cookie_choice');


    var swiper = new Swiper(".mySwiper", {
        loop: true,
        spaceBetween: -10,
        slidesPerView: 3,
        watchSlidesProgress: true,
    });
    var swiper2 = new Swiper(".mySwiper2", {
        loop: true,
        spaceBetween: 32,
        thumbs: {
            swiper: swiper,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
    });
   
            var swiper = new Swiper(".teamswiper", {
                slidesPerView: 1,
            spaceBetween: 32,
            centeredSlides: false,
            slidesPerGroupSkip: 1,
            grabCursor: true,
            loop: true,
            keyboard: {
                enabled: true,
            },
            breakpoints: {
                769: {
                slidesPerView: 2,
            slidesPerGroup: 1,
                },
            },
            navigation: {
                nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
            },
            scrollbar: {
                el: ".swiper-scrollbar",
            },
            pagination: {
                el: ".swiper-pagination",
            type: "fraction",
            },
        });
 
 
    $("#drop_menu_button_desktop").on("click", function() {
        if (prof_menu % 2 === 1 ){
            prof_menu++;
          
        $("#drop_menu_desktop").slideToggle("fast");
        $("#drop_profile_desktop").slideToggle("fast");
            desk_menu++;
   
        }
        else
        {
            desk_menu++;
      
        $("#drop_menu_desktop").slideToggle("fast");
        }
    });
    $("#drop_profile_button_desktop").on("click", function () {
        if (desk_menu % 2 === 1 ){
            desk_menu++;
       
        $("#drop_profile_desktop").slideToggle("fast");
        $("#drop_menu_desktop").slideToggle("fast");
            prof_menu++;
       
        }
        else
        {
            prof_menu++;
         
        $("#drop_profile_desktop").slideToggle("fast");
        }
    });

    $("#menu_button_mobile").on("click", function () {
        $("#menu_mobile").slideToggle("medium");
    });

    $("#drop_menu_button_mobile").on("click", function () {
        $("#drop_menu_mobile").slideToggle("medium");
    });

    $("#open_menu_button_mobile").on("click", function () {
        $("#open_menu_mobile").slideToggle("medium");
    });

    $("#drop_weather_container").on("click", function () {
        $("#weather_container").slideToggle("medium");
    });

    $(window).on("load", function() {

        cookie_choice = sessionStorage.getItem('cookie_choice');
        local_cookie_choice = localStorage.getItem('local_cookie_choice');

        if (cookie_choice === 'true' || local_cookie_choice === 'true') {
            $("#cookie_modal").hide();

        }
        else {
            
            $("#cookie_modal").show();
            sessionStorage.setItem('cookie_choice', 'true');
        };
        
    });

    $("#cookie_yes").on("click", function (){
        local_cookie_choice = localStorage.setItem('local_cookie_choice', 'true');
        $("#cookie_modal").hide("medium");
    });

    $("#cookie_no").on("click", function () {
        $("#cookie_modal").hide("medium");
    });

    $(window).on("scroll", function() {
        var this_scroll = $(this).scrollTop();
        if (last_scroll < this_scroll) {
            $("#main_menu").slideUp("fast");
        }
        else {
            
            $("#main_menu").slideDown("fast");
        }
        last_scroll = this_scroll;
    });

});