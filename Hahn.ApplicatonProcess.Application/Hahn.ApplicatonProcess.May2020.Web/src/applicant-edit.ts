import {autoinject, inject, NewInstance} from 'aurelia-framework';
import { I18N } from 'aurelia-i18n';
import { ValidationController, ValidationRules, ValidateEvent, validateTrigger } from 'aurelia-validation';
import { BootstrapFormRenderer } from 'utils/bootstrap-form-renderer';
import { ApplicantsApi } from 'applicants.api';
import {DialogService} from 'aurelia-dialog';
import { ErrorDialog, ErrorDialogModel } from 'error-dialog';
import {Router} from 'aurelia-router';
import { Applicant } from 'models/applicant';

@autoinject
export class ApplicantEdit {
  public heading: string = '';

  public id: number = 0;

  public name: string;
  public familyName: string;
  public address: string;
  public countryOfOrigin: string;
  public emailAddress: string;
  public age: number;
  public hired: boolean;
  public isFormValid: boolean = true;

  constructor(
    private applicantsApi: ApplicantsApi, 
    private i18n: I18N, 
    @inject(NewInstance.of(ValidationController)) private validationController: ValidationController, 
    private dialogService: DialogService,
    private router: Router
  ) {
    ValidationRules
    .ensure((m: ApplicantEdit) => m.name).displayName(this.i18n.tr('applicants.name')).required().minLength(5)
    .ensure((m: ApplicantEdit) => m.familyName).displayName(this.i18n.tr('applicants.familyName')).required().minLength(5)
    .ensure((m: ApplicantEdit) => m.address).displayName(this.i18n.tr('applicants.address')).required().minLength(10)
    .ensure((m: ApplicantEdit) => m.countryOfOrigin).displayName(this.i18n.tr('applicants.countryOfOrigin')).required().minLength(2)
    .ensure((m: ApplicantEdit) => m.emailAddress).displayName(this.i18n.tr('applicants.emailAddress')).required().email()
    .ensure((m: ApplicantEdit) => m.age).displayName(this.i18n.tr('applicants.age')).required().min(20).max(60)
    .on(this);

    const bootstrapFormRenderer = new BootstrapFormRenderer();
    this.validationController.addRenderer(bootstrapFormRenderer);
    this.validationController.subscribe(event => this.checkFormIsValid(event))
    this.validationController.validate();
  }

  async activate(params): Promise<void> {
    this.heading = this.i18n.tr('applicants.edit.title') + ' ' + params.id;
    this.id = params.id;
    const applicant = await this.applicantsApi.getById(this.id);
    this.name = applicant.name;
    this.familyName = applicant.familyName;
    this.address = applicant.address;
    this.countryOfOrigin = applicant.countryOfOrigin;
    this.emailAddress = applicant.emailAddress;
    this.age = applicant.age;
    this.hired = applicant.hired;
  }

  private checkFormIsValid(event: ValidateEvent): void {
    this.isFormValid = event.results.every(r => r.valid);
  }

  public async submit() {
    await this.validationController.validate();
    var applicant = new Applicant();
    applicant.id = this.id;
    applicant.name = this.name;
    applicant.familyName = this.familyName;
    applicant.address = this.address;
    applicant.countryOfOrigin = this.countryOfOrigin;
    applicant.emailAddress = this.emailAddress;
    applicant.age = this.age;
    applicant.hired = this.hired;

    try {
      await this.applicantsApi.put(this.id, applicant);
      this.router.navigate('applicants')
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
}
