"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var LojaCarrinhoCompras = /** @class */ (function () {
    function LojaCarrinhoCompras() {
        this.campeonatos = [];
    }
    LojaCarrinhoCompras.prototype.adicionar = function (campeonato) {
        var campeonatoLocalStorage = localStorage.getItem("campeonatoStorage");
        if (!campeonatoLocalStorage) {
            this.campeonatos.push(campeonato);
        }
        else {
            this.campeonatos = JSON.parse(campeonatoLocalStorage);
            this.campeonatos.push(campeonato);
        }
        localStorage.setItem("campeonatoStorage", JSON.stringify(this.campeonatos));
    };
    LojaCarrinhoCompras.prototype.obterCampeonatos = function () {
        var campeonatoLocalStorage = localStorage.getItem("campeonatoStorage");
        if (campeonatoLocalStorage) {
            return JSON.parse(campeonatoLocalStorage);
        }
    };
    LojaCarrinhoCompras.prototype.removerCampeonato = function (campeonato) {
    };
    return LojaCarrinhoCompras;
}());
exports.LojaCarrinhoCompras = LojaCarrinhoCompras;
//# sourceMappingURL=loja.carrinho.component.js.map