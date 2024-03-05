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
            'track-id': '517924ad-be37-4a12-a80e-40837cb7b1bf'
        });
    }

    GetPictures(): Observable<PictureOfTheDay[]> {
        return this._httpClient.get<PictureOfTheDay[]>(
            this._nasaApiBaseUrl + '/info', { headers: this.createHeader()}
        )
    }
}