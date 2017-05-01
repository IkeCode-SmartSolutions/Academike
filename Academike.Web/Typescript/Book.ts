/// <reference path="_references.ts" />

module Academike {

    export class Book extends Base implements ICRUDView {
        apiRelativeBasePath: string = '/book';

        constructor() {
            super();
            var a = $("");
        }
    }

}