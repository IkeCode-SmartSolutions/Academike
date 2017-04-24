module Learnike {

    export class Book extends Base implements ICRUDView {
        apiRelativeBasePath: string = '/book';

        constructor() {
            super();
        }
    }

}