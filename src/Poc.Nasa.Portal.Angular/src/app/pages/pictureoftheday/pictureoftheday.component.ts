import { Component, OnInit } from '@angular/core';
import { PictureOfTheDay } from '../../models/pictureoftheday.model';
import { PictureOfTheDayService } from '../../services/pictureoftheday.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-pictureoftheday',
  templateUrl: './pictureoftheday.component.html',
  styleUrl: './pictureoftheday.component.scss'
})

export class PictureofthedayComponent implements OnInit {
  public picturesOfTheDay = new Observable<PictureOfTheDay[]>();
  private _pictureOfTheDayService: PictureOfTheDayService;

  constructor(pictureOfTheDayService: PictureOfTheDayService){
    this._pictureOfTheDayService = pictureOfTheDayService;
  }

  ngOnInit(): void {
    this.getPictureOfTheDay();
  }

  // getPictureOfTheDay(){
  //   this._pictureOfTheDayService.GetPictures()
  //     .subscribe(pictures => this.picturesOfTheDay = pictures)
  // }

  // getPictureOfTheDays(){
  //   this._pictureOfTheDayService.GetPictures().subscribe(data => {
  //     const picutres = data;

  //     picutres.map((item) => {
  //       item.date = new Date(item.date!).toLocaleDateString('pt-BR');
  //     })

  //     this.picturesOfTheDay = picutres;
  // });

  getPictureOfTheDay(){
    this.picturesOfTheDay = this._pictureOfTheDayService.GetPictures();
  }
}