// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function SetLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            $("#Punch_Latitude").val(position.coords.latitude);
            $("#Punch_Longitude").val(position.coords.longitude);
        });
    }
    else {
        alert("Your Browser or Computer doesn't appear to support location please check all settings to allow your location to be used");
    }
};