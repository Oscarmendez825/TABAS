import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private Auth:AuthService,private router:Router) { }

  ngOnInit(): void {
  }
  loginUser(event: { preventDefault: () => void; target: any; }){

    event.preventDefault()
    const target= event.target
    const cedula= target.querySelector("#cedula").value
    const password= target.querySelector("#password").value

    if (password=="aldo" && cedula=="123"){
      window.alert("Hola mundo")
      this.router.navigate(["home"])
      this.Auth.setLoggedIn(true)
    }else{
      window.alert("XD")
    }
    console.log(cedula,password)
  }
}
