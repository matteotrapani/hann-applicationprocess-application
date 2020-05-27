import {autoinject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import { IApplicant, ApplicantsApi } from 'applicantsApi';

@autoinject
export class ApplicantsList {
  public heading: string = 'Applicants';
  public applicants: any[] = [];

  constructor(private applicantsApi: ApplicantsApi) {
  }

  async activate(): Promise<void> {
    this.applicants = await this.applicantsApi.getAll();
  }

  select(applicant: IApplicant) {}
}
