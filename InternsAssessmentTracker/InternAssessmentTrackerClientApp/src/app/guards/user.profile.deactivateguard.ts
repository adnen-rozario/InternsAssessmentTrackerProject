// import { Observable } from "rxjs/Observable";  
// import { Injectable } from '@angular/core';
// import { CanDeactivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router/router";  
  
// export interface CanComponentDeactivate {  
  
//     canDeactivate:() => Observable<boolean>| Promise<boolean> | boolean;  
// }  
// @Injectable() 
// export class UserProfileDeactivateGuard implements CanDeactivate<CanComponentDeactivate>
// {  
  
//     canDeactivate(component: CanComponentDeactivate,  
//         currentRoute : ActivatedRouteSnapshot,  
//         state : RouterStateSnapshot,  
//         next? : RouterStateSnapshot) : Observable<boolean>| Promise<boolean> | boolean
//         {  
//             return component.canDeactivate();  
//          }  
// }  