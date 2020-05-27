export interface IApplicant {
    name?: string | undefined;
    familyName?: string | undefined;
    address?: string | undefined;
    countryOfOrigin?: string | undefined;
    emailAddress?: string | undefined;
    age?: number;
    hired?: boolean | undefined;
    id?: number;
}

export class Applicant implements IApplicant {
    name?: string | undefined;
    familyName?: string | undefined;
    address?: string | undefined;
    countryOfOrigin?: string | undefined;
    emailAddress?: string | undefined;
    age?: number;
    hired?: boolean | undefined;
    id?: number;
}
