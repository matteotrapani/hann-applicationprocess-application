export class ApplicantPostRequest implements IApplicantPostRequest {
    name?: string | undefined;
    familyName?: string | undefined;
    address?: string | undefined;
    countryOfOrigin?: string | undefined;
    emailAddress?: string | undefined;
    age?: number;
    hired?: boolean | undefined;

    constructor(data?: IApplicantPostRequest) {
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
        }
    }

    static fromJS(data: any): ApplicantPostRequest {
        data = typeof data === 'object' ? data : {};
        let result = new ApplicantPostRequest();
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
        return data; 
    }
}

export interface IApplicantPostRequest {
    name?: string | undefined;
    familyName?: string | undefined;
    address?: string | undefined;
    countryOfOrigin?: string | undefined;
    emailAddress?: string | undefined;
    age?: number;
    hired?: boolean | undefined;
}