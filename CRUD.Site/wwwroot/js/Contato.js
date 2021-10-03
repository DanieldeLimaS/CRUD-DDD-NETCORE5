function add_anti_forgery_token(data) {
    data.__RequestVerificationToken = $('[name=__RequestVerificationToken]').val();
    return data;
}
function pesquisaAjax() {
    $.ajax({
        url: '/Contato/Pesquisar',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: {
            'pesquisa': $('#pesquisa').val(),
        },
        success: function (response) {
            var table = $('#tabelaPesquisa').find('tbody');
            table.empty();
            if (response.value.dados.length > 0);
            {
                for (i = 0; i < response.value.dados.length; i++) {
                    table.append(CriaLinhaPesquisa(response.value.dados[i]));
                }

            }
        },
        error: function (dados) {
            alert(dados.erro);
        }
    })

}

function CriaLinhaPesquisa(item) {
    var ret = `<tr data-id="${item.con_id}">
               <td>${item.con_nome}</td>;
               <td>${new Date(item.con_dtNasc).toLocaleDateString()}</td>`;
    if (item.con_ativo == true) {
        ret += `<td><div class="badge badge-success">Ativo</div></td>`;
    }
    else {
        ret += `<td><div class="badge badge-danger">Inativo</div></td>`;
    }
    ret += `<td>${item.car_nome} </td>
               <td>
                 <a href="/Contato/Editar/${item.con_id}" class="btn btn-dark" style="color:white">Editar</a>
                 <input type="button" data-value="${item.con_id}" id="btn_excluir"  class="btn btn-danger" value="Excluír"/>
           </td>`;
    return ret;
}

$(document).ready(function () {
    pesquisaAjax();
    $(document)

        .on('click', "#btn_excluir", function () {
            var btn = $(this),
                tr = btn.closest('tr'),
                url = '/Contato/Delete',
                id = tr.attr('data-id')
            param = { 'id': id };
            Swal.fire({
                title: 'Tem certeza que deseja excluir?',
                text: "Após a exclusão, não será possivel recuperar informações desse usuário no futuro.",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sim, excluir!',
                cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {

                    $.post(url, add_anti_forgery_token(param), function (response) {
                        if (response.value.op == true) {
                            tr.remove();
                            Swal.fire(
                                'Excluído!',
                                response.msg,
                                'success'
                            )

                        }
                        else {
                            Swal.fire(
                                'Erro!',
                                response.msg,
                                'error'
                            )
                        }
                    })
                        .fail(function () {

                            Swal('Aviso', 'Não foi possível excluir. Tente novamente em instantes.', 'warning');
                        });

                }
            })

        })
        .on('keyup', '#pesquisa', function () {
           
                pesquisaAjax();
            
        })

})