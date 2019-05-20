import {Injectable} from '@angular/core';
import { Resolve, Router } from '@angular/router';
import { User } from '../app/_model/user';
import { UserService } from '../app/_services/user.service';
import { AlertifyService } from '../app/_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../app/_services/auth.service';

@Injectable()

export class MemberEditResolver implements Resolve<User> {

    constructor(private userService: UserService, private authService: AuthService,
         private router: Router, private alertify: AlertifyService) {}

    resolve(): Observable<User> {
        return this.userService.getUser(this.authService.decodedToken.nameid).pipe(
            catchError(error => {
                this.alertify.error('Problem in retrieving data');
                this.router.navigate(['/members']);
                return of(null);
            })
        );
    }
}
