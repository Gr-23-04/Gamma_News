// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function() {
    $("#dropdown_menu_button_desktop").click(function () {
        $("#menu_drop_desktop").slideToggle("fast");
    });
    $("#dropdown_menu_button_mobile").click(function () {
        $("#menu_drop_mobile").slideToggle("fast");
    });
    $("#close_menu_button_mobile").click(function () {
        $("close_menu_mobile").slideToggle("fast");
    });

});