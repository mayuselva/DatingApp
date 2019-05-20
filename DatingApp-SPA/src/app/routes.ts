import {Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {MemberListComponent} from './members/member-list/member-list.component';
import {MessagesComponent} from './messages/messages.component';
import {ListsComponent} from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailsComponent } from './members/member-details/member-details.component';
import { MemberDetailResolver } from '../_resolvers/member-detail.resolver';
import {MemberListResolver} from '../_resolvers/member-list.resolver';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberEditResolver } from '../_resolvers/member-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';

export const appRoutes: Routes = [
    { path: '' , component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'members' , component: MemberListComponent, resolve: {user: MemberListResolver}},
            { path: 'members/:id' , component: MemberDetailsComponent, resolve : {users: MemberDetailResolver}},
            { path: 'member/edit' , component: MemberEditComponent,
                 resolve : {edituser : MemberEditResolver}, canDeactivate: [PreventUnsavedChanges]},
            { path: 'message' , component: MessagesComponent},
            { path: 'list' , component: ListsComponent},
        ]
    },
    { path: '**' , redirectTo: '', pathMatch: 'full'},
];
