var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Learnike;
(function (Learnike) {
    var Base = (function () {
        function Base() {
            this.apiSettings.baseUrl = 'http://localhost:13378/api';
        }
        return Base;
    }());
    Learnike.Base = Base;
})(Learnike || (Learnike = {}));
var Learnike;
(function (Learnike) {
    var Book = (function (_super) {
        __extends(Book, _super);
        function Book() {
            var _this = _super.call(this) || this;
            _this.apiRelativeBasePath = '/book';
            return _this;
        }
        return Book;
    }(Learnike.Base));
    Learnike.Book = Book;
})(Learnike || (Learnike = {}));
//# sourceMappingURL=learnike.js.map