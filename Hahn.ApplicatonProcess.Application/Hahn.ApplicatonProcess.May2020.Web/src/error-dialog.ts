import {autoinject} from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@autoinject
export class ErrorDialog {
    public errors: string[] = [];
    public title: string = '';

    constructor(private dialogController: DialogController) {}

    activate(model: ErrorDialogModel) {
        this.title = model.title;
        this.errors = [];
        if (Array.isArray(model.errors))
            this.errors.push(...model.errors);
        else
           this.errors.push(model.errors);
    }
}

export interface IErrorDialogModel {
    title: string;
    errors: string[] | string
}
export class ErrorDialogModel implements IErrorDialogModel {
    title: string;
    errors: string | string[];

    constructor() {
        this.errors = [];
    }
}