export class ApplicantPostRequest implements IApplicantPostRequest {
    name?: string | undefined;
    familyName?: string | undefined;
    address?: string | undefined;
    countryOfOrigin?: string | undefined;
    emailAddress?: string | undefined;
    age: number;
    hired?: boolean | undefined;
}

export interface IApplicantPostRequest {
    name?: string | undefined;
    familyName?: string | undefined;
    address?: string | undefined;
    countryOfOrigin?: string | undefined;
    emailAddress?: string | undefined;
    age: number;
    hired?: boolean | undefined;
}