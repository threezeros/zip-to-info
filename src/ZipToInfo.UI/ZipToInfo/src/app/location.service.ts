import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { SettingsService } from './settings.service';
import { ZipInfo } from './location/models/ZipInfo';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor(private settingsService: SettingsService, private http: HttpClient) {
    // haven't figured out why (yet), but the settings service isn't being injected... below web call is hard coded for now...
  }

  getZipInfo(zipCode: string): Observable<ZipInfo> {

    const url = `http://localhost:5000/api/zipInfo/${zipCode}/json`;
    return this.http.get<ZipInfo>(url);
  }
}
