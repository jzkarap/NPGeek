// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var slideIndex = 1;
showSlides(slideIndex);

// Next/previous controls
function plusSlides(n) {
    showSlides(slideIndex += n);
}

// Thumbnail image controls
function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
}

//function eraseCookie(name) {
//    createCookie(name, "", -1);
//}

//function getPreference() {

//    var preference = readCookie("temp");
//    if (preference == "c") {
//        document.getElementById("conversion-unit").innerHTML = "°F | <strong>°C</strong>";

//        var elements = document.getElementsByClassName("temperature");

//        for (var i = 0; i < elements.length; i++) {
//            var tempstring = elements[i].innerHTML;
//            var temperature = (parseInt(tempstring) - 32) * (5 / 9);
//            elements[i].innerHTML = Math.round(temperature) + 'ºC';
//        }
//    }
//    if (preference == "f") {
//        document.getElementById("conversion-unit").innerHTML = "<strong>°F</strong> | °C";

//        var elements = document.getElementsByClassName("temperature");

//        for (var i = 0; i < elements.length; i++) {
//            var tempstring = elements[i].innerHTML;
//            var temperature = parseInt(tempstring);
//            elements[i].innerHTML = Math.round(temperature) + 'ºF';
//        }
//    }
//}

//function setPreference() {
//    var preference = readCookie("temp");
//    if (preference == "f") {
//        eraseCookie("temp");
//        createCookie("temp", "c");

//        document.getElementById("preferencebutton").innerHTML = "°F | <strong>°C</strong>";
//        var elements = document.getElementsByClassName("temperature");

//        for (var i = 0; i < elements.length; i++) {
//            var tempstring = elements[i].innerHTML;
//            tempstring = tempstring.substring(0, tempstring.length - 2);
//            var temperature = (parseInt(tempstring) - 32) * (5 / 9);
//            elements[i].innerHTML = Math.round(temperature) + 'ºC';
//        }
//    }
//    if (preference == "c") {
//        eraseCookie("temp");
//        createCookie("temp", "f");


//        document.getElementById("preferencebutton").innerHTML = "Change to Celcius";
//        var elements = document.getElementsByClassName("temperature");

//        for (var i = 0; i < elements.length; i++) {
//            var tempstring = elements[i].innerHTML;
//            tempstring = tempstring.substring(0, tempstring.length - 2);
//            var temperature = parseInt(tempstring) * (9 / 5) + 32;
//            elements[i].innerHTML = Math.round(temperature) + 'ºF';
//        }
//    }
//}
function createCookie(name, value) {
    document.cookie = name + "=" + value;
}


function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function convert() {

    if ("units" === "F") {
        document.getElementById("temp_switch").innerHTML = "°F | <strong>°C</strong>";

        var elements = document.getElementsByClassName("temp");

        for (var i = 0; i < elements.length; i++) {
            var tempstring = elements[i].innerHTML;
            tempstring = tempstring.substring(0, tempstring.length - 2);
            var temperature = ((parseInt(tempstring) - 32) / 1.8);
            elements[i].innerHTML = Math.round(temperature) + 'ºC';
        }
    }

    
}

