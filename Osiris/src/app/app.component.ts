import { Component } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Constants } from './config/constants';
import { Vehicle } from './interfaces/vehicle';
import { VehicleServiceService } from './services/vehicle-service.service';

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Osiris';

  constructor(service: VehicleServiceService) {
    this.LoadVehicles(service);
  }

  ngOnInit() {
    console.log(this.title);
  }

  LoadVehicles(service: VehicleServiceService) {
    service.getVehicles()
      .subscribe((data: any) => {
        debugger;
      });
  }
}


