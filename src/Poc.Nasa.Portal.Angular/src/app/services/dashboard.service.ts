import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { Observable } from "rxjs";
import { Dashboard } from "../models/dashboard.model";
import Utils from "../shared/utils";

@Injectable({
    providedIn: 'root'
})

export class DashboardService{
    private _httpClient: HttpClient
    private _nasaApiBaseUrl = environment.nasaApiBaseURL;

    constructor(httpClient: HttpClient){
        this._httpClient = httpClient;
    }

    createHeader() {
        return new HttpHeaders(
        {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Access-Control-Allow-Headers': 'Content-Type',
            'track-id': Utils.generateUUID()
        });
    }

    GetDashboard(): Observable<Dashboard> {
        return this._httpClient.get<Dashboard>(
            this._nasaApiBaseUrl + '/dashboard', { headers: this.createHeader()}
        )
    }
}