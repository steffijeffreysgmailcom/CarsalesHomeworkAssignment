import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class VehicleService {
  myAppUrl: string = "";

  constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }


  getCars() {
    return this._http.get(this.myAppUrl + 'api/Vehicle/Index')
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  getCarById(id: number) {
    return this._http.get(this.myAppUrl + "api/Vehicle/CarDetails/" + id)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  createCar(car) {
    return this._http.post(this.myAppUrl + 'api/Vehicle/CreateCar', car)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  updateCar(car) {
    return this._http.put(this.myAppUrl + 'api/Vehicle/EditCar', car)
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }
  

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}  
