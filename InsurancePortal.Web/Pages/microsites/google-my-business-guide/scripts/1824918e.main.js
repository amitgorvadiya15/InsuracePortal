"use strict";!function(){$(function(){$(".no").on("click",function(a){a.preventDefault();var b="No"===$(this).text()?"Hide Links":"No";$(this).text(b).parents(".card").toggleClass("active")});var a=$("#embed");$(".embedLink,.close").on("click",function(b){b.preventDefault(),a.hasClass("visible")?a.animate({bottom:"-200px"},"slow").fadeOut({queue:!1}).removeClass("visible"):a.animate({bottom:"0px"},"slow").fadeIn({queue:!1}).addClass("visible")})})}();