import { Injectable } from "@angular/core";  
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, CanActivateChild ,UrlTree} from "@angular/router";  
import { AdalService } from "adal-angular4";
import{Observable} from 'rxjs'
  
@Injectable()  
export class AuthenticationGuard implements CanActivate 
{  
      
constructor(private authService: AdalService)
{

}  
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        return this.authService.userInfo.authenticated;
    }

// canActivateChild(route: ActivatedRouteSnapshot,state: RouterStateSnapshot): Observable<boolean|UrlTree>|Promise<boolean|UrlTree>|boolean|UrlTree 
// {
//     return this.authService.userInfo.authenticated;
// }
}  