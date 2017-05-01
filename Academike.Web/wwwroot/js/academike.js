var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
/// <reference path="../node_modules/@types/jquery/index.d.ts" /> 
var Academike;
(function (Academike) {
    var Base = (function () {
        function Base() {
            this.apiSettings.baseUrl = 'http://localhost:13378/api';
        }
        return Base;
    }());
    Academike.Base = Base;
})(Academike || (Academike = {}));
/// <reference path="_references.ts" />
var Academike;
(function (Academike) {
    var Book = (function (_super) {
        __extends(Book, _super);
        function Book() {
            var _this = _super.call(this) || this;
            _this.apiRelativeBasePath = '/book';
            var a = $("");
            return _this;
        }
        return Book;
    }(Academike.Base));
    Academike.Book = Book;
})(Academike || (Academike = {}));
//# sourceMappingURL=academike.js.map