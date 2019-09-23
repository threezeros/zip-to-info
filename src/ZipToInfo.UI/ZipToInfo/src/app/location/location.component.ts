import { Component, OnInit } from '@angular/core';

import { ZipInfo } from './models/ZipInfo';
import { LocationService } from '../location.service';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.scss']
})
export class LocationComponent implements OnInit {
  constructor(private locationService: LocationService) { }

  locationInfo: ZipInfo = {
    cityName: '',
    timeZone: '',
    zipCode: ''
  };

  ngOnInit(): void {
  }

  onSubmit(zipCode: string, invalid: boolean): void {
    if (invalid) { return; }
    this.locationService.getZipInfo(zipCode)
      .subscribe(info => this.locationInfo = info);
  }
}
