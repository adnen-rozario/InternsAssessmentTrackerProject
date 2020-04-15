import { Injectable, SkipSelf } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { Intern } from '../models/internModel';
import { environment } from '../../environments/environment';

@Injectable()
export class InternService
{
 
  constructor(private http: HttpClient) {  
     }

     private internServiceUrl= environment.apiUrl+'Intern/';

    addIntern(intern: Intern): Observable<Intern>
    {
        
        const headers = new HttpHeaders({ 'Content-Type': 'application/json'}); 
        return this.http.post<Intern>(this.internServiceUrl, intern, { headers: headers })  
        .pipe(  
            catchError(this.handleError)  
          ); 

        
    }

    getIntern(): Observable<Intern[]>
    {
        
        return this.http.get<Intern[]>(this.internServiceUrl)  
        .pipe(  
            catchError(this.handleError)  
          ); 

        
    }

    getInternDashboard(): Observable<Intern[]>
    {
        
        return this.http.get<Intern[]>(environment.apiUrl+"interndashboard")  
        .pipe(  
            catchError(this.handleError)  
          ); 

        
    }


    private handleError(err) 
{  
  
    let errorMessage: string;  
    if (err.error instanceof ErrorEvent) 
    {  
      errorMessage = `An error occurred: ${err.error.message}`;  
    } else {  
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;  
    }  
    console.error(err);  
    return throwError(errorMessage);  
  } 
}