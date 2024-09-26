import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit { 

  users$?: Observable<User[]>;
  constructor(private userservice: UserService) {
   
    
  }

  ngOnInit(): void {
    this.users$ = this.userservice.getUsers();
  }
}
