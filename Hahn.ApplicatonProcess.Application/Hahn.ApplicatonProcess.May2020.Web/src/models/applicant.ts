import {ValidationRules} from 'aurelia-validation';

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

    constructor(data?: IApplicant) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.name = _data["name"];
            this.familyName = _data["familyName"];
            this.address = _data["address"];
            this.countryOfOrigin = _data["countryOfOrigin"];
            this.emailAddress = _data["emailAddress"];
            this.age = _data["age"];
            this.hired = _data["hired"];
            this.id = _data["id"];
        }
    }

    static fromJS(data: any): Applicant {
        data = typeof data === 'object' ? data : {};
        let result = new Applicant();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["familyName"] = this.familyName;
        data["address"] = this.address;
        data["countryOfOrigin"] = this.countryOfOrigin;
        data["emailAddress"] = this.emailAddress;
        data["age"] = this.age;
        data["hired"] = this.hired;
        data["id"] = this.id;
        return data; 
    }
}
