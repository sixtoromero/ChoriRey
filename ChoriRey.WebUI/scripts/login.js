$(document).ready(function () {    
    localStorage.removeItem('tokenChoriRey');
});

function iniciarSesion() 
{        
    var settings = {
        "url": "http://localhost:63842/API/Usuarios/GetLoginAsync",
        "method": "POST",
        "timeout": 0,
        "headers": {
          "Content-Type": "application/json"
        },
        "data": JSON.stringify({
          "Usuario": $("#txtUsuario").val(),
          "Clave": $("#txtClave").val()
        }),
      };
      
      $.ajax(settings).done(function (response) {    
        if (response.IsSuccess) {
            localStorage.setItem('tokenChoriRey', response.Data.Token);
            location.href ="index.html";
        }else{
            Swal.fire('Usuario o clave incorrectos');
        }
        //console.log(response);
    }).fail(function (jqXHR, textStatus) {
        Swal.fire('Usuario o clave incorrectos');
    });
}



