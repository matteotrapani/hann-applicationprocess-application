import {autoinject} from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@autoinject
export class ConfirmationDialog {
    public title: string;
    constructor(private dialogController: DialogController) {}

    activate(title: string) {
        this.title = title;
    }
}