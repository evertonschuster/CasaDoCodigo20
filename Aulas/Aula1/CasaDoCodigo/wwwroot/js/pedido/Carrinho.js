class Carrinho {
    AdicionarItemCarrinho(btn) {
        var item = this.GetItemCarrinho(btn);
        item.Quantidade++;

        this.UpdateQuantidade(item);
    }

    RemoverItemCarrinho(btn) {
        var item = this.GetItemCarrinho(btn);
        item.Quantidade--;

        this.UpdateQuantidade(item);
    }

    AtualizarItemCarrinho(input) {
        
        var item = this.GetItemCarrinho(input);
        this.UpdateQuantidade(item);
    }

    UpdateQuantidade(data) {
        let token = $("[name=__RequestVerificationToken]").val();
        let headers = {};
        headers["RequestVerificationToken"] = token;

        //o AJAX precissa de algum atributos para funcionar
        //URL           : o Endereco do metodo (controller/metodo)
        //TYPE          : Tipo de requisicao HTTP
        //contentType   : formato dos dados JSON
        //DATA          : os Dados
        $.ajax({
            url: "/Pedido/UpdateQuantidade",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            headers: headers                //token de validacao para a controller
        }).done(function (response) {
            carrinho.AtualizaFormularioCarrinho(response)
        }
        );
    }

    AtualizaFormularioCarrinho(response) {

        console.log(response);

        var listItem = $("[rowItem]");
        var itensPedido = response.itens;
        var rowItem = listItem[0].cloneNode(true);
        var grid = $("[grid]");
        listItem.remove();

        //atualiza a grid
        for (var i in itensPedido) {
            var item = itensPedido[i];
            $(rowItem).find("img").attr("src", "/images/produtos/large_" + item.produto.codigo + ".jpg")
            $(rowItem).find("[nome]").html(item.produto.nome);
            $(rowItem).find("[preco]").html("R$ " + item.produto.preco.toFixed(2));
            $(rowItem).find("input").val(item.quantidade);
            $(rowItem).find("[subtotal]").html((item.quantidade * item.produto.preco).toFixed(2));
            $(rowItem).find("[codigoItem]").attr("codigoItem", item.produto.codigo)

            grid.after(rowItem.cloneNode(true));
        }

        //atualiza os valors gerais da compra
        $("[numero-itens]").html(" Total: " + response.totalItens + " itens");
        $("[total]").html(response.totalCompra.toFixed(2))
    }

    GetItemCarrinho(btn) {

        var linhaProduto = $(btn).parents("[codigoItem]");
        var codigoProduto = $(linhaProduto).attr("codigoItem");

        var quantidade = $(linhaProduto).find("input").val();

        return {
            Produto: { Codigo: codigoProduto },
            Quantidade: quantidade
        };

    }
}


var carrinho = new Carrinho();