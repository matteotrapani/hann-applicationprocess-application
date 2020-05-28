import {autoinject, inject, NewInstance, computedFrom} from 'aurelia-framework';
import { I18N } from 'aurelia-i18n';
import { ValidationController, ValidationRules, ValidateEvent, validateTrigger } from 'aurelia-validation';
import { BootstrapFormRenderer } from 'utils/bootstrap-form-renderer';
import { ApplicantPostRequest } from 'models/applicantPostRequest';
import { ApplicantsApi, ApiException } from 'applicants.api';
import {DialogService} from 'aurelia-dialog';
import { ErrorDialog, ErrorDialogModel } from 'error-dialog';
import {Router} from 'aurelia-router';
import { ConfirmationDialog } from 'confirmation-dialog';

@autoinject
export class ApplicantsAdd {
  public heading: string = '';

  public name: string;
  public familyName: string;
  public address: string;
  public countryOfOrigin: string;
  public emailAddress: string;
  public age: number;
  public hired: boolean;
  public isFormValid: boolean = false;

  constructor(
    private applicantsApi: ApplicantsApi, 
    private i18n: I18N, 
    @inject(NewInstance.of(ValidationController)) private validationController: ValidationController, 
    private dialogService: DialogService,
    private router: Router
  ) {
    ValidationRules
    .ensure((m: ApplicantsAdd) => m.name).displayName(this.i18n.tr('applicants.name')).required().minLength(5)
    .ensure((m: ApplicantsAdd) => m.familyName).displayName(this.i18n.tr('applicants.familyName')).required().minLength(5)
    .ensure((m: ApplicantsAdd) => m.address).displayName(this.i18n.tr('applicants.address')).required().minLength(10)
    .ensure((m: ApplicantsAdd) => m.countryOfOrigin).displayName(this.i18n.tr('applicants.countryOfOrigin')).required().minLength(2)
    .ensure((m: ApplicantsAdd) => m.emailAddress).displayName(this.i18n.tr('applicants.emailAddress')).required().email()
    .ensure((m: ApplicantsAdd) => m.age).displayName(this.i18n.tr('applicants.age')).required().min(20).max(60)
    .on(this);

    const bootstrapFormRenderer = new BootstrapFormRenderer();
    this.validationController.addRenderer(bootstrapFormRenderer);
    this.validationController.subscribe(event => this.checkFormIsValid(event))
    this.validationController.validate();
  }

  async activate(): Promise<void> {
    this.heading = this.i18n.tr('applicants.add.title');
  }

  private checkFormIsValid(event: ValidateEvent): void {
    this.isFormValid = event.type !== 'reset' && event.results.every(r => r.valid);
  }

  public async submit() {
    const validation = await this.validationController.validate();
    if (!validation.valid)
      return;
    var applicant = new ApplicantPostRequest();
    applicant.name = this.name;
    applicant.familyName = this.familyName;
    applicant.address = this.address;
    applicant.countryOfOrigin = this.countryOfOrigin;
    applicant.emailAddress = this.emailAddress;
    applicant.age = this.age | 0;
    applicant.hired = this.hired;

    try {
      await this.applicantsApi.post(applicant);
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
  
  @computedFrom('name', 'familyName', 'address', 'countryOfOrigin', 'emailAddress', 'age', 'hired')
  get areFieldsAllEmpty(): boolean {
    return !this.name && !this.familyName && !this.address && !this.countryOfOrigin && !this.emailAddress && !this.age && !this.hired;
  }

  public resetFields() {
    this.dialogService.open({ viewModel: ConfirmationDialog, model: this.i18n.tr('general.resetConfirmation'), lock: false }).whenClosed(response => {
      if (!response.wasCancelled) {
        this.name = '';
        this.familyName = '';
        this.address = '';
        this.countryOfOrigin = '';
        this.emailAddress = '';
        this.age = null;
        this.hired = null;
        this.validationController.reset();
      }
    });
  }
}
