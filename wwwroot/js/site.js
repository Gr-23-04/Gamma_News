// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {


    var last_scroll = 0;
    var desk_menu = 0;
    var prof_menu = 0;
    var cookie_choice = sessionStorage;
 
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

    $(window).on('load', function () {

            sessionStorage.getItem('cookie_choice');

        if (cookie_choice != 'true') {
            $("#cookie_modal").show("medium");
            sessionStorage.setItem('cookie_choice', 'true');
            
        }
        
    });

    $("#cookie_yes").on("click", function (){
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