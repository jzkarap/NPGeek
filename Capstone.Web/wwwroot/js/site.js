// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const button = document.querySelector(".temperature");
const temp = document.querySelector(".temperature");

onclick.button = function convertTemp() {
    temp.InnerText = (parseInt(temp.InnerText) - 32) / 1.8;
}
