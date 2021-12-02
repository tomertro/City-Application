import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { City } from './Model/city';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  private readonly _baseUrl = environment.serverUrl;
  constructor(private http: HttpClient) { 

  }

  getCities(name:string): Observable<Array<City>>{        
    const api = this._baseUrl + 'city'
    const body = new HttpParams()
    .set('name', name); 
    const result = this.http.get<Array<City>>(api,{params:body});
    return result;       
  }
}
