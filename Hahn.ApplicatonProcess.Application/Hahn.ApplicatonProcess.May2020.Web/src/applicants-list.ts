import {autoinject} from 'aurelia-framework';
import { IApplicant, ApplicantsApi } from 'applicantsApi';
import { I18N } from 'aurelia-i18n';

@autoinject
export class ApplicantsList {
  public heading: string = '';
  public applicants: any[] = [];

  constructor(private applicantsApi: ApplicantsApi, private i18n: I18N) {
  }

  async activate(): Promise<void> {
    this.heading = this.i18n.tr('applicants.list.title');
    this.applicants = await this.applicantsApi.getAll();
  }

  select(applicant: IApplicant) {
    console.log(`Selected applicant ${applicant.name}`);
  }
}
