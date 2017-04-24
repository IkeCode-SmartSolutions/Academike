module Learnike {

    export interface ICRUDView {
        apiRelativeBasePath: string;
    }

    export interface ApiSettings {
        baseUrl: string;
    }

    export class Base {
        protected apiSettings: ApiSettings;

        constructor() {
            this.apiSettings.baseUrl = 'http://localhost:13378/api';
        }
    }

}