import { Injectable, SkipSelf } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { InternRating } from '../models/internratingModel';
import { InternRatingResponse } from '../models/internratingresponseModel';

@Injectable()
export class RatingService
{
 
  constructor(private http: HttpClient) {  
     }

     private internServiceUrl= environment.apiUrl;

   

    getInternRating(internRating:InternRating): Observable<InternRatingResponse>
    {
      const headers = new HttpHeaders({ 'Content-Type': 'application/json'}); 
        
        return this.http.post<InternRatingResponse>(this.internServiceUrl+'getinternrating/', internRating, { headers: headers })  
        .pipe(  
            catchError(this.handleError)  
          ); 

        
    }

    assignInternRating(internRating:InternRating): Observable<boolean>
    {
      const headers = new HttpHeaders({ 'Content-Type': 'application/json'}); 
        
        return this.http.post<boolean>(this.internServiceUrl+'Rating', internRating, { headers: headers })  
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