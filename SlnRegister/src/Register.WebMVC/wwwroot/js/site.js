// Modal do DELETE
$(document).ready(() => {
    console.log("Cadastro Hospitalar - Script Loaded")
    getDataTable('#table-person');
});

liveToastMessage = (message, origin) => {
    $('#toast-body').html(message);
    $('#toast-origin').html(origin);
    $('#toast-time').html(new Date().toLocaleTimeString('pt-BR', {
        hour12: false,
        hour: "numeric",
        minute: "numeric"
    }));

    const toastLiveMessage = $('#liveToast');
    const toast = new bootstrap.Toast(toastLiveMessage);
    toast.show();
}

msgModalMessage = (message, callback) => {
    $('#modal-body').html(message);
    $('#btnModalCallback').click(() => callback());
    $('#msgModal').modal('show');
}

closeModalMessage = () => {
    $('#msgModal').modal('hide');
}

/* Paginação */

function getDataTable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}
