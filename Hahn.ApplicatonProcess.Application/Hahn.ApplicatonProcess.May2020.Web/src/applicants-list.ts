import {autoinject} from 'aurelia-framework';
import { I18N } from 'aurelia-i18n';
import { ApplicantsApi } from 'applicants.api';
import { DialogService } from 'aurelia-dialog';
import { ConfirmationDialog } from 'confirmation-dialog';
import { ErrorDialogModel, ErrorDialog } from 'error-dialog';

@autoinject
export class ApplicantsList {
  public heading: string = '';
  public applicants: any[] = [];

  constructor(private applicantsApi: ApplicantsApi, private i18n: I18N, private dialogService: DialogService) {
  }

  async activate(): Promise<void> {
    this.heading = this.i18n.tr('applicants.list.title');
    this.applicants = await this.applicantsApi.getAll();
  }

  public async delete(id: number) {
    console.log(`Selected applicant ${id}`);
    this.dialogService.open({ viewModel: ConfirmationDialog, model: this.i18n.tr('general.deleteConfirmation'), lock: false }).whenClosed(response => {
      if (!response.wasCancelled) {
        try {
          this.applicantsApi.delete(id).then(response => this.applicantsApi.getAll().then(applicants => this.applicants = applicants));
        } catch(e) {
          const errors = [];
          Object.keys(e.errors).forEach(key => {
            errors.push(e.errors[key]);
          });
          const errorDialog: ErrorDialogModel = new ErrorDialogModel();
          errorDialog.title = this.i18n.tr('general.errorSave');
          errorDialog.errors = errors;
          this.dialogService.open({ viewModel: ErrorDialog, model: errorDialog, lock: false });
        }
      }
    });
  }
}
