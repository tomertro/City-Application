import { concat, fromEvent, Observable, throwError } from 'rxjs';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Store } from '../city.store';
import { City } from '../Model/city';
import { debounceTime, distinctUntilChanged, map, switchMap } from 'rxjs/operators';


@Component({
  selector: 'app-city-search',
  templateUrl: './city-search.component.html',
  styleUrls: ['./city-search.component.css']
})
export class CitySearchComponent implements OnInit,AfterViewInit {
  cities:Array<City>;  
  @ViewChild('searchCity',{static:true}) searchInput:ElementRef;

  constructor(private store:Store) { 
   
  }
 hasItems():boolean{
   if(this.cities === undefined) return false;
   return this.cities.length > 0
 }
  ngAfterViewInit(): void {
     fromEvent<any>(this.searchInput.nativeElement,'keyup').pipe(
     map(event=> event.target.value),
     debounceTime(700),
     distinctUntilChanged(),
     switchMap(c=>this.store.getCities(c)),      
   ).subscribe(c=>{    
    this.cities = c
   }
     );
 
 
  }

  ngOnInit(): void {
    
  }



}
