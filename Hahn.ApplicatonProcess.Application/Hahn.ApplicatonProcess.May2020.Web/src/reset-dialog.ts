import {autoinject} from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@autoinject
export class ResetDialog {
    constructor(private dialogController: DialogController) {}
}