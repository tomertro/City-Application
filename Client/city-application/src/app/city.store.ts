import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";

import {delayWhen, filter, map, retryWhen, shareReplay, tap, withLatestFrom} from 'rxjs/operators';
import { CityService } from "./city.service";
import { City } from "./Model/city";
@Injectable({
    providedIn: 'root'
  })

export class Store{

    private subject = new BehaviorSubject<Array<City>>([]);
    observer:Observable<Array<City>>;

    constructor(private service :CityService){        
        this.observer = this.subject.asObservable();
        //this.subject.next({});
    }

    
    getCities(name:string):Observable<Array<City>>{          
        if(!name.replace(/\s/g, '').length|| name === undefined) 
        {
            this.subject.next([]);
            return  this.observer;      
        }
            
        this.service.getCities(name).subscribe(c=> 
            {              
                this.subject.next(c)  ;                           
            }
            );            
            return this.observer;   
        
    }
}