import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() {}

  private loggedInStatus=false

  setLoggedIn(value:boolean){
    this.loggedInStatus=value
  }

  get isLoggedIn(){
    return this.loggedInStatus
  }
  getUserDetails(username: any,password: any){
    //post API
  }
}
