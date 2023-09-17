document.addEventListener("DOMContentLoaded", function (event) {
    trocarTipo();
    validarEnvio();
    validarResultado();
});

var chegadas = [];
var tamanhos = [];
var prioridades = [];
var contador = 1;

function adicionarLinha() {
    const validado = validarCamposInput();

    if (!validado) {
        return;
    }

    document.getElementById("Chegada").disabled = false;

    var tabela = document.getElementById("tabela").getElementsByTagName('tbody')[0];
    var chegada = document.getElementById("Chegada").value;
    var tempo = document.getElementById("Tamanho").value;
    var prioridade = document.getElementById("Prioridade").value;

    // Adicionar uma nova linha à tabela
    var newRow = tabela.insertRow(tabela.rows.length);
    var cell0 = newRow.insertCell(0);
    var cell1 = newRow.insertCell(1);
    var cell2 = newRow.insertCell(2);
    var cell3 = newRow.insertCell(3);

    cell0.innerHTML = `P${contador}`;
    cell1.innerHTML = chegada;
    cell2.innerHTML = tempo;
    cell3.innerHTML = prioridade;

    adicionarInputHidden(chegada, "chegadas");
    adicionarInputHidden(tempo, "tamanhos");
    adicionarInputHidden(prioridade, "prioridades");

    // Adicionar os dados às listas
    chegadas.push(chegada);
    tamanhos.push(tempo);
    prioridades.push(prioridade);

    // Limpar os campos de entrada
    document.getElementById("Chegada").value = "";
    document.getElementById("Tamanho").value = "";
    document.getElementById("Prioridade").value = "";

    $("#dados").removeClass('d-none');
    contador++;

    document.getElementById("Chegada").focus();
}

function limparDados() {
    chegadas = [];
    tamanhos = [];
    prioridades = [];

    var tabela = document.getElementById("tabela").getElementsByTagName('tbody')[0];
    tabela.innerHTML = "";
}

function validarCamposInput() {
    const chegada = $("#Chegada").val();
    const tamanho = $("#Tamanho").val();
    const prioridade = $("#Prioridade").val();

    if (chegada == '' || tamanho == '' || prioridade == '') {
        exibirErro("Preencha os campos corretamente");
        return false;
    }

    return true;
}

function adicionarInputHidden(valor, nome) {
    var inputHidden = document.createElement("input");
    inputHidden.type = "hidden";
    inputHidden.name = nome;
    inputHidden.value = valor;

    var container = document.getElementById("inputsHiddenContainer");
    container.appendChild(inputHidden);
}

function exibirErro(mensagem) {
    jSuites.notification({
        error: 1,
        name: 'Erro',
        message: mensagem,
    });
}

function exibirInformacao(mensagem) {
    jSuites.notification({
        name: 'Info',
        message: mensagem,
    });
}

function trocarTipo() {
    const select = $("#Tipo");
    const tipo = select.val();
    console.log(tipo);
    let tipoHidden = $("#TipoHidden");

    select.on('change', function () {
        $("#select-integracao").prop("disabled", false);
        tipoHidden.val(select.val());
        console.log(tipoHidden.val());
    })
}

function validarEnvio() {
    $("#form").submit(function (e) {
        var tamanhoLista = tamanhos.length;

        if (tamanhoLista < 5) {
            e.preventDefault();
            exibirErro("Adicione no mínimo 5 processos!");
        }
        else if ($("#TipoHidden").val() == '0') {
            e.preventDefault();
            exibirErro("Selecione uma opção de escalonamento!");
        }
    });
}

function validarResultado() {
    var sucesso = $("#sucesso").val();
    var mensagem = $("#mensagem").val();

    if (sucesso !=  undefined && mensagem != undefined) {
        if (sucesso == 'true') {
            exibirInformacao(mensagem);
        }
        else {
            exibirErro(mensagem);
        }
    }
}