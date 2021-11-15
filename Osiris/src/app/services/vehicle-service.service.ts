import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../config/constants';

@Injectable({
  providedIn: 'root'
})
export class VehicleServiceService {

  constructor(private http: HttpClient) { }
  // This is usually put in a config file.
  url = Constants.API_ENDPOINT;

  public getVehicles() {
    return this.http.get(this.url + "/all");
  }

  public searchVehicles(phrase: string) {
    this.url = this.url + "/search/" + phrase; 
    return this.http.get(this.url);
  }
}
