$(document).ready(function () {
    const respToken = localStorage.getItem('tokenChoriRey');
    if (respToken == null) {
        location.href = "login.html";
    }
});


