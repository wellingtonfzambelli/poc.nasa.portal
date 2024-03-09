import { Component, OnInit } from '@angular/core';
import { PictureOfTheDay } from '../../models/pictureoftheday.model';
import { PictureOfTheDayService } from '../../services/pictureoftheday.service';
import { Observable, filter, map } from 'rxjs';

@Component({
  selector: 'app-pictureoftheday',
  templateUrl: './pictureoftheday.component.html',
  styleUrl: './pictureoftheday.component.scss'
})

export class PictureofthedayComponent implements OnInit {
  public picturesOfTheDay = new Observable<PictureOfTheDay[]>();
  public pictureOfTheDayFilter = new Observable<PictureOfTheDay[]>();
  private _pictureOfTheDayService: PictureOfTheDayService;

  constructor(pictureOfTheDayService: PictureOfTheDayService){
    this._pictureOfTheDayService = pictureOfTheDayService;
  }

  ngOnInit(): void {
    this.getPictureOfTheDay();
  }

  getPictureOfTheDay(){
    this.picturesOfTheDay = this._pictureOfTheDayService.GetPictures();
    this.pictureOfTheDayFilter = this.picturesOfTheDay;
  }

  search(event: Event){
    const target = event.target as HTMLInputElement;
    const value = target.value.toLocaleLowerCase();

    this.picturesOfTheDay = this.pictureOfTheDayFilter.pipe(
      map(arr => arr.filter(f => f.title.toLocaleLowerCase().includes(value)))
    );
  }
}