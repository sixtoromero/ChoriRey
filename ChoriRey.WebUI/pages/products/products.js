var token = '';
var otProducts;

$(document).ready(function () {        
    ConfigTableCustomer();
    const respToken = localStorage.getItem('tokenChoriRey');
    if (respToken == null) {
        location.href = "../../login.html";
    } else {
        token = respToken;
        getProductos();
    }
});

function ConfigTableCustomer() {    
    var dtData = []; otProducts = $('#tblProducts').dataTable({
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

function getProductos() {
    var settings = {
        "url": "http://localhost:63842/API/Productos/GetAllAsync",
        "method": "GET",
        "timeout": 0,
        "headers": {
          "Authorization": "Bearer " + token
        },
      };
      
      $.ajax(settings).done(function (response) {
                
        if (response.IsSuccess && response.Data.length > 0) {
            otProducts.fnClearTable();
            for (var x = 0; x < response.Data.length; x++) {
                                
                var Actions = '<div class="row"><div class="col-6"><a href="#" class="fa fa-floppy-o" onclick="updateProducts(' + "'" + response.Data[x].IdProducto + "'" + ')"></a></div><div class="col6"><a href="#" class="fa fa-trash-o" onclick="removeProducts(' + "'" + response.Data[x].IdProducto + "'" + ', ' + "'" + response.Data[x].NombreProducto  + "'" + ')"></a></div></div>'
                
                otProducts.fnAddData
                (
                    [response.Data[x].IdProducto, response.Data[x].CodProducto, response.Data[x].NombreProducto, response.Data[x].CodigoBarras, response.Data[x].Porcentaje_IVA, response.Data[x].Precio_Unitario, response.Data[x].Estado, Actions]
                );
            }
        } else {
            Swal.fire('No se encontraron registros');
        }
    }).fail(function (jqXHR, textStatus) {
        Swal.fire('No se encontraron registros');
    });
}

function removeProducts(IdProduct, Productos) {

    Swal.fire({
        title: 'Está seguro de desactivar el registro?',
        text: "El producto " + Productos + " se procede a desactivar.! ",
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

function updateProducts(idProducto) {

}