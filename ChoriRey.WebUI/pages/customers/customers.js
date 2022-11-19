var token = '';
var otCustomer;

$(document).ready(function () {        
    ConfigTableCustomer();
    const respToken = localStorage.getItem('tokenChoriRey');
    if (respToken == null) {
        location.href = "../../login.html";
    } else {
        token = respToken;
        getClientes();
    }
});

function ConfigTableCustomer() {    
    var dtData = []; otCustomer = $('#tblCustomers').dataTable({
        'aaData': dtData,
        "sPaginationType": "full_numbers",
        "sPageButton": "paginate_button",
        "sPageButtonActive": "paginate_active",
        "sPageButtonStaticDisabled": "paginate_buttond",
        "iDisplayLength": 10,
        "bAutoWidth": false,
        "aoColumns": [{ "sWidth": "10%" }, { "sWidth": "20%" }, { "sWidth": "35%" }, { "sWidth": "35%" }, { "sWidth": "35%" }, { "sWidth": "20%" }, { "sWidth": "30%" }, { "sWidth": "20%" }],
        "oLanguage": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sInfo": "Mostrando desde _START_ hasta _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando desde 0 hasta 0 de 0 registros",
            "sInfoFiltered": "(filtrado de _MAX_ registros en total)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "<",
                "sPrevious": "<<",
                "sNext": ">>",
                "sLast": ">"
            }
        }
    });
}

function getClientes() {
    var settings = {
        "url": "http://localhost:63842/API/Clientes/GetAllAsync",
        "method": "GET",
        "timeout": 0,
        "headers": {
          "Authorization": "Bearer " + token
        },
      };
      
      $.ajax(settings).done(function (response) {
                
        if (response.IsSuccess && response.Data.length > 0) {
            otCustomer.fnClearTable();
            for (var x = 0; x < response.Data.length; x++) {
                
                //var FechaInicio = moment((data[x].FechaInicio.match(/\d+/)[0] * 1)).format('LLL');
                //var Actions = "<center><input type='checkbox' name='chk_" + data[x].VisitaId + "' onclick='hdCheckAprobar(" + data[x].VisitaId + ");'  /></center>";

                var Actions = '<div class="row"><div class="col-6"><a href="#" class="fa fa-floppy-o" onclick="removeUser(' + "'" + response.Data[x].IdUsuario + "'" + ')"></a></div><div class="col6"><a href="#" class="fa fa-trash-o" onclick="removeUser(' + "'" + response.Data[x].IdUsuario + "'" + ', ' + "'" + response.Data[x].Nombres  + " " + response.Data[x].Apellidos + "'" + ')"></a></div></div>'
                
                
                otCustomer.fnAddData
                (
                    [response.Data[x].IdCliente, response.Data[x].Nombres, response.Data[x].Apellidos, response.Data[x].Direccion, response.Data[x].Telefono, response.Data[x].Correo == 1 ? 'Activo' : 'Inactivo', response.Data[x].Estado, Actions]
                );
            }
        } else {
            Swal.fire('No se encontraron registros');
        }
    }).fail(function (jqXHR, textStatus) {
        Swal.fire('No se encontraron registros');
    });
}

function removeUser(IdUser, Cliente) {

    Swal.fire({
        title: 'Está seguro de desactivar el registro?',
        text: "El cliente " + Cliente + " se procede a desactivar.! ",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Si, eliminar!',
        cancelButtonText: 'Cancelar',
      }).then((result) => {
        if (result.isConfirmed) {
          Swal.fire(
            'Deleted!',
            'Your file has been deleted.',
            'success'
          )
        }
      });
}