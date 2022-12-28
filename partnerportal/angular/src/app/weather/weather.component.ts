import { Component } from '@angular/core';
import { WeatherForecastClient, WeatherForecast } from '../web-api-client';

@Component({
  selector: 'weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss']
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(private client: WeatherForecastClient) {
    client.get().subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  title = 'Partner Portal - Weather';
}
