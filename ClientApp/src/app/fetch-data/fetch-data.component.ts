import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

/*
 THIS COMPONENT IS PART of the boiler-plate code, when you create a fresh ASP .NET core app
that's wired to an Angular Front-end application
THIS ARTIFACT is vestigial structure of the project & have been left behind for the sake of studying the structure
For this studio this component and the code is inoperative vis-a-vis the DATABASE & the FRONT-END Angular application
 */

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
