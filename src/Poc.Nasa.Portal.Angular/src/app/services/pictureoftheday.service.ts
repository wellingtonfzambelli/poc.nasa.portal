import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { PictureOfTheDay } from "../models/pictureoftheday.model";
import { Observable } from "rxjs";


@Injectable({
    providedIn: 'root'
})

export class PictureOfTheDayService{
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
            'track-id': this.generateUUID()
        });
    }

    GetPictures(): Observable<PictureOfTheDay[]> {
        return this._httpClient.get<PictureOfTheDay[]>(
            this._nasaApiBaseUrl + '/info', { headers: this.createHeader()}
        )
    }

    generateUUID() {
        var d = new Date().getTime();//Timestamp
        var d2 = ((typeof performance !== 'undefined') && performance.now && (performance.now()*1000)) || 0;//Time in microseconds since page-load or 0 if unsupported
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
            var r = Math.random() * 16;//random number between 0 and 16
            if(d > 0){//Use timestamp until depleted
                r = (d + r)%16 | 0;
                d = Math.floor(d/16);
            } else {//Use microseconds since page-load if supported
                r = (d2 + r)%16 | 0;
                d2 = Math.floor(d2/16);
            }
            return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
    }
}