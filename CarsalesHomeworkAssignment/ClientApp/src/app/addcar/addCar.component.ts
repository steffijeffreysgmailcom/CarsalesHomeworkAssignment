import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchCarComponent } from '../fetchcar/fetchcar.component';
import { VehicleService } from '../../services/vehicleservice.service';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';



@Component({
  selector: 'createcar',
  templateUrl: './AddCar.component.html',
  providers: [VehicleService]
})

export class CreateCarComponent implements OnInit {
  carForm: FormGroup;
  title: string = "Create";
  id: number;
  errorMessage: any;

  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _vehicleService: VehicleService, private _router: Router) {
    if (this._avRoute.snapshot.params["id"]) {
      this.id = this._avRoute.snapshot.params["id"];
    }

    this.carForm = this._fb.group({
      id: 0,
      make: ['', [Validators.required]],
      model: ['', [Validators.required]],
      engine: ['', [Validators.required]],
      bodytype: ['', [Validators.required]],
      wheels: ['', [Validators.required]],
      doors: ['', [Validators.required]],
    })
  }

  ngOnInit() {
    if (this.id > 0) {
      this.title = "Edit";
      this._vehicleService.getCarById(this.id)
        .subscribe(resp => this.carForm.setValue(resp)
          , error => this.errorMessage = error);
    }
  }

  save() {

    if (!this.carForm.valid) {
      return;
    }

    if (this.title == "Create") {
      this._vehicleService.createCar(this.carForm.value)
        .subscribe((data) => {
          this._router.navigate(['/fetchcar']);
        }, error => this.errorMessage = error)
    }
    else if (this.title == "Edit") {
      this._vehicleService.updateCar(this.carForm.value)
        .subscribe((data) => {
          this._router.navigate(['/fetch-car']);
        }, error => this.errorMessage = error)
    }
  }

  cancel() {
    this._router.navigate(['/fetchcar']);
  }

  get model() { return this.carForm.get('model'); }
  get make() { return this.carForm.get('make'); }
  get engine() { return this.carForm.get('engine'); }
  get bodytype() { return this.carForm.get('bodytype'); }
  get doors() { return this.carForm.get('doors'); }
  get wheels() { return this.carForm.get('wheels'); }
}  
