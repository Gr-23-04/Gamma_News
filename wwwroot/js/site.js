// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function() {
        //int menu = 1;
    $("#drop_menu_button_desktop").click(function () {
        $("#drop_menu_desktop").slideToggle("medium");
        //$if (menu != 0) {
        //    menu = 1
        //$("#drop_profile_desktop").slideToggle("medium");
        //}
    });
    $("#drop_profile_button_desktop").click(function () {
        $("#drop_profile_desktop").slideToggle("medium");
        //$if (menu != 1) {
        //    menu = 0;
        //$("#drop_menu_desktop").slideToggle("medium");
        //}
    });
    $("#menu_button_mobile").click(function () {
        $("#menu_mobile").slideToggle("medium");
    });
    $("#drop_menu_button_mobile").click(function () {
        $("#drop_menu_mobile").slideToggle("medium");
    });
    $("#open_menu_button_mobile").click(function () {
        $("#open_menu_mobile").slideToggle("medium");
    });
    $("#drop_weather_container").click(function () {
        $("#weather_cpntainer").slideToggle("medium");
    });

});