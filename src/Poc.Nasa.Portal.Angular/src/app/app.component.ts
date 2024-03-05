import { Component } from '@angular/core';
import { PictureOfTheDayService } from './services/pictureoftheday.service';
import { PictureOfTheDay } from './models/pictureoftheday.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})

export class AppComponent {
  title = 'Poc.Nasa.Portal.Angular';
  //picturesOfTheDay = {} as PicturesOfTheDay;
  picturesOfTheDay = new Observable<PictureOfTheDay[]>();

  private _pictureOfTheDayService: PictureOfTheDayService;

  constructor(pictureOfTheDayService: PictureOfTheDayService){
    this._pictureOfTheDayService = pictureOfTheDayService;
    this.getPictureOfTheDay();
  }

  // getPictureOfTheDay(){
  //   this._pictureOfTheDayService.GetPictures()
  //     .subscribe(pictures => this.picturesOfTheDay = pictures)
  // }

  getPictureOfTheDay(){
    this.picturesOfTheDay = this._pictureOfTheDayService.GetPictures();
    //console.log(this.picturesOfTheDay[0])
  }
}
