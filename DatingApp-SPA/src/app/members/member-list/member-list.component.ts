import { Component, OnInit } from '@angular/core';
import { UserService } from '../../_services/user.service';
import { AlertifyService } from '../../_services/alertify.service';
import { User } from '../../_model/user';
import { ActivatedRoute } from '@angular/router';
import { Pagination, PaginatedResult } from '../../_model/pagination';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
users: User[];
pagination: Pagination;
page: number;
  constructor(private userService: UserService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
   // this.loadUsers();
   this.route.data.subscribe(data => {
     this.users = data['user'].result;
     this.pagination = data['user'].pagination;
   });
  }
  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadUsers();
  }
  loadUsers() {
    this.userService.getUsers(this.pagination.currentPage, this.pagination.itemsPerPage).
      subscribe((res: PaginatedResult< User[]>) => {
        this.users = res.result;
        this.pagination = res.pagination;
    }, error => {
        this.alertify.error(error);
    });
  }
}
