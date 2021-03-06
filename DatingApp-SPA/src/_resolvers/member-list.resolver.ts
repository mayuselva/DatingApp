import {Injectable} from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { User } from '../app/_model/user';
import { UserService } from '../app/_services/user.service';
import { AlertifyService } from '../app/_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()

export class MemberListResolver implements Resolve<User[]> {

    pageNumber = 1;
    pageSize = 3;

    constructor(private userService: UserService,
         private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<User[]> {
        return this.userService.getUsers(this.pageNumber, this.pageSize).pipe(
            catchError(error => {
                this.alertify.error('Problem in retrieving data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
