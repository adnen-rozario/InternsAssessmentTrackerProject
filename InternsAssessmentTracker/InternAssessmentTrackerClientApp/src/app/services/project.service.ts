import { Injectable, SkipSelf } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { Intern } from '../models/internModel';
import { environment } from '../../environments/environment';
import { KeyValue } from '../models/keyvalueModel';
import { Project } from '../models/projectModel';
import { AssignProject } from '../models/assignprojectModel';

@Injectable()
export class ProjectService
{
 
  constructor(private http: HttpClient) {  
     }

     private projectServiceUrl= environment.apiUrl+'Project';
     private technologyServiceUrl= environment.apiUrl+'Technologies/';

    

    getTechnologies(): Observable<KeyValue[]>
    {
        
        return this.http.get<KeyValue[]>(this.technologyServiceUrl)  
        .pipe(  
            catchError(this.handleError)  
          ); 

        
    }

    addProject(projectDetails:Project): Observable<boolean>
    {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json'}); 
        
        return this.http.post<boolean>(this.projectServiceUrl, projectDetails, { headers: headers })  
        .pipe(  
            catchError(this.handleError)  
          ); 

    }

    getProject(): Observable<Project[]>
    {
        
        return this.http.get<Project[]>(this.projectServiceUrl)  
        .pipe(  
            catchError(this.handleError)  
          ); 

    }

    getProjectNames(): Observable<KeyValue[]>
    {        
        return this.http.get<KeyValue[]>(this.projectServiceUrl+'names')        
        .pipe(  
            catchError(this.handleError)  
          ); 

    }

    assignProject(assignDetails:AssignProject): Observable<boolean>
    {        
      const headers = new HttpHeaders({ 'Content-Type': 'application/json'}); 

        return this.http.post<boolean>(this.projectServiceUrl+'assign', assignDetails, { headers: headers })        
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