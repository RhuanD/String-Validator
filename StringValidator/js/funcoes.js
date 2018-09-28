$(document).ready(function () {
    $(document).on('click', '#submit',function (e) {
        e.preventDefault();
        var string = $('#Validar').val();
        if ($.trim(string) == "") {
            alert("Escreva algo, por favor, senão este algoritmo não tem sentido.");
            return false;
        } else {
            $.ajax({
                type: 'POST',
                url: '../WebServices/StringService.asmx/ValidadorString',
                data: JSON.stringify({ validar: string }),
                contentType: "application/json; charset=utf-8",
                success: function (ret) {
                    alert(ret.d);
                },
                error: function (status, error, e) {
                    console.log(error);
                    console.log(status);
                    console.log(e);
                    alert("Erro ao fazer a verificação. Contate os desenvolvedores!");
                }
            });
        }
    });
});