﻿var chegadas = [];
var tamanhos = [];
var prioridades = [];
var contador = 1;

function adicionarLinha() {
    const validado = validarCamposInput();

    if (!validado) {
        return;
    }

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
}

function validarCamposInput() {
    const chegada = $("#Chegada").val();
    const tamanho = $("#Tamanho").val();
    const prioridade = $("#Prioridade").val();

    if (chegada == '' || tamanho == '' || prioridade == '') {
        ExibirErro("Preencha os campos corretamente");
        return false;
    }

    return true;
}

function ExibirErro(mensagem) {
    jSuites.notification({
        error: 1,
        name: 'Erro',
        message: mensagem,
    });
}

function ExibirInformacao(mensagem) {
    jSuites.notification({
        name: 'Info',
        message: mensagem,
    });
}

function calcular() {
    var model = {
        chegadas: [1, 2],
        tamanhos: [1, 2],
        prioridades: [1, 2]
    };

    $.ajax({
        url: $("#urlCalcular").val(),
        type: "POST",
        data: model,
        dataType: "json"
    });
}