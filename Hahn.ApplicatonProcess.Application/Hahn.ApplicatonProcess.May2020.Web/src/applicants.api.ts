import { autoinject } from 'aurelia-framework';
import { HttpClient, RequestInit, json } from 'aurelia-fetch-client';
import { Applicant, IApplicant } from 'models/applicant';
import { ApplicantPostRequest } from 'models/applicantPostRequest';

@autoinject
export class ApplicantsApi {
    constructor(private baseUrl: string, private httpClient: HttpClient) {
    }

    private jsonIntReplacer: (key: string, value: any) => number = (key, value) => {
        return key === "age" ? +value : value;
    }

    public async getAll(): Promise<Applicant[]> {
        const response = await this.httpClient.fetch(this.baseUrl + '/api/Applicant');
        return await response.json();
    }

    public async post(body: ApplicantPostRequest): Promise<string> {
        const response = await this.httpClient.post(this.baseUrl + '/api/Applicant', json(body, this.jsonIntReplacer));
        if (response.status === 201) {
            return await response.text();
        } else if (response.status === 400) {
            const error = await response.json();
            return throwException("Bad Request", response.status, '', response.headers, error);
        } else if (response.status !== 200 && response.status !== 204) {
            const error = await response.json();
            return throwException("Bad Request", response.status, '', response.headers, error);
        }
        return Promise.resolve<string>(<any>null);
    }

    public async getById(id: number): Promise<Applicant> {
        const response = await this.httpClient.fetch(this.baseUrl + `/api/Applicant/${id}`);
        return await response.json();
    }

    public async put(id: number, body: Applicant): Promise<void> {
        const response = await this.httpClient.put(this.baseUrl + `/api/Applicant/${id}`, json(body, this.jsonIntReplacer));
        if (response.status === 204) {
            return;
        } else if (response.status === 400) {
            const error = await response.json();
            return throwException("Bad Request", response.status, '', response.headers, error);
        } else if (response.status !== 200 && response.status !== 204) {
            const error = await response.json();
            return throwException("Bad Request", response.status, '', response.headers, error);
        }
    }

    public async delete(id: number): Promise<void> {
        const response = await this.httpClient.delete(this.baseUrl + `/api/Applicant/${id}`);
        if (response.status === 204) {
            return;
        } else if (response.status === 400) {
            const error = await response.json();
            return throwException("Bad Request", response.status, '', response.headers, error);
        } else if (response.status !== 200 && response.status !== 204) {
            const error = await response.json();
            return throwException("Bad Request", response.status, '', response.headers, error);
        }
    }
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}