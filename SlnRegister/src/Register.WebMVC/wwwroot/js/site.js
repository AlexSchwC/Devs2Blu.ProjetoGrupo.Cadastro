// Modal do DELETE
$(document).ready(() => {
    console.log("Cadastro Hospitalar - Script Loaded")
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