// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {

    //int menu = 1;
    $("#drop_menu_button_desktop").on("click", function () {
        $("#drop_menu_desktop").slideToggle("fast");
        //$if (menu != 0) {
        //    menu = 1
        //$("#drop_profile_desktop").slideToggle("medium");
        //}
    });
    $("#drop_profile_button_desktop").on("click", function () {
        $("#drop_profile_desktop").slideToggle("fast");
        //$if (menu != 1) {
        //    menu = 0;
        //$("#drop_menu_desktop").slideToggle("medium");
        //}
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

    $("#cookie_yes").on("click", function (){
        $("#cookie_modal").hide("slow");
    });


    $("#cookie_no").on("click", function () {
        $("#cookie_modal").hide("medium");
    });
});