import {autoinject} from 'aurelia-framework';
import { ApplicantsApi } from 'applicantsApi';
import { I18N } from 'aurelia-i18n';
import { ValidationController, ValidationRules } from 'aurelia-validation';
import { BootstrapFormRenderer } from 'utils/bootstrap-form-renderer';

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

  constructor(private applicantsApi: ApplicantsApi, private i18n: I18N, private validationController: ValidationController) {
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
  }

  async activate(): Promise<void> {
    this.heading = this.i18n.tr('applicants.add.title');
  }

  public submit() {
    this.validationController.validate();
    alert(`
      name: ${this.name}
      familyName: ${this.familyName}
      address: ${this.address}
      countryOfOrigin: ${this.countryOfOrigin}
      emailAddress: ${this.emailAddress}
      age: ${this.age}
      hired: ${this.hired}
    `);
  }
}
