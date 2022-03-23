import { Component, OnInit } from '@angular/core';
import { observable, Observable } from 'rxjs';
import { isEmpty } from 'rxjs/operators';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit 
{
  model:any = {}
  currentUser$: Observable<User>;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void 
  {
    this.currentUser$ = this.accountService.currentUser$;
  }

  login()
  {
    this.accountService.login(this.model).subscribe(response => 
    {
      console.log(response);
    }, error => 
    {
      console.log(error);
    })
  }

  logout()
  {
    this.accountService.logout();
  }
}
