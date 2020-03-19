"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var LojaCarrinhoCompras = /** @class */ (function () {
    function LojaCarrinhoCompras() {
    }
    LojaCarrinhoCompras.prototype.participar = function (campeonato) {
        this.campeonato = campeonato;
        sessionStorage.setItem("campeonatoStorage", JSON.stringify(this.campeonato));
    };
    LojaCarrinhoCompras.prototype.obterCampeonato = function () {
        var campeonatoLocalStorage = sessionStorage.getItem("campeonatoStorage");
        if (campeonatoLocalStorage) {
            return JSON.parse(campeonatoLocalStorage);
        }
        else {
            this.router.navigate(['/loja-pesquisa']);
        }
    };
    LojaCarrinhoCompras.prototype.removerCampeonato = function (campeonato) {
    };
    return LojaCarrinhoCompras;
}());
exports.LojaCarrinhoCompras = LojaCarrinhoCompras;
//# sourceMappingURL=loja.carrinho.component.js.map