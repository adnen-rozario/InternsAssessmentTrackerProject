import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

export enum NotifcationType
{
    info,
    warning,
    success,
    error
}
export enum Position 
{
    topRight = 'toast-top-right',
    topLeft = 'toast-top-left',
    bottomRight = 'toast-bottom-right',
    bottomLeft= 'toast-bottom-left',
}
@Injectable()
export class NotificationService  
{
   
    constructor(private notificationService: ToastrService) 
    { 
    }
    public show(title: string, message: string, type:NotifcationType, positionClass: Position)
     {
         if(type==NotifcationType.info)
         {
            this.notificationService.info(message, title, { positionClass });
         }
         else if(type==NotifcationType.error)
         {
            this.notificationService.error(message, title, { positionClass });
         }
         else if(type==NotifcationType.success)
         {
            this.notificationService.success(message, title, { positionClass });
         }
         else if(type==NotifcationType.warning)
         {
            this.notificationService.warning(message, title, { positionClass });
         }
       
    }
  
  
}
