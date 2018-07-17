import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { VehicleService } from '../../services/vehicleservice.service'
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';

@Component({
  selector: 'fetchcar',
  templateUrl: './fetchcar.component.html',
  providers: [VehicleService]
})

export class FetchCarComponent {
  public carList: CarData[];

  constructor(public http: Http, private _router: Router, private _vehicleService: VehicleService) {
    this.getCars();
  }

  getCars() {
    this._vehicleService.getCars().subscribe(
      data => this.carList = data
    )
  }
  
}

interface CarData {
  id: number;
  make: string;
  model: string;
  engine: string;
  bodytype: string;
  doors: string;
  wheels: string;
}  
