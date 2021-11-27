import { Jwtresponse } from './../shared/jwtresponse';
import { AuthService } from './../shared/auth.service';

import { Login } from './../shared/Login';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  //declaring variables
  loginForm: FormGroup;
  isSubmitted: boolean = false;
  loginUser: Login = new Login();
  error = '';
  jwtResponse: any = new Jwtresponse();
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    //FormGroup
    this.loginForm = this.formBuilder.group({
      UserName: ['', [Validators.required, Validators.minLength(2)]],
      Password: ['', [Validators.required]],
    });
  }

  //get controls
  get formControls() {
    return this.loginForm.controls;
  }

  //login verify credntials
  loginCredentials() {
    this.isSubmitted = true;
    console.log(this.loginForm.value);

    //invalid
    if (this.loginForm.invalid) return;

    //valid
    if (this.loginForm.valid) {
      this.authService.loginVerify(this.loginForm.value).subscribe(
        (data) => {
          console.log(data);
          this.jwtResponse = data;
          sessionStorage.setItem('jwtToken', this.jwtResponse.Token);
          //Check the role--based on TRoleIdit redirect to the respective component
          if (this.jwtResponse.RoleId === 2) {
            //logged as Adminitiain
            console.log('Manager');

            //storing in localStorage/sessionStorage
            localStorage.setItem('username', this.jwtResponse.username);
            localStorage.setItem(
              'ACCESS_ROLE',
              this.jwtResponse.RoleId.toString()
            );
            sessionStorage.setItem('username', this.jwtResponse.username);
            this.router.navigateByUrl('/manager');
          } else if (this.jwtResponse.RoleId === 2) {
            //logged as Manager
            console.log('HR');
          } else if (this.jwtResponse.RoleId === 3) {
            //logged as Administrator
            console.log('Software Engineer');
          } else if (this.jwtResponse.RoleId === 1) {
            //logged as Administrator
            console.log('Administrator');
            //storing in localStorage/sessionStorage
            localStorage.setItem('username', this.jwtResponse.username);
            localStorage.setItem(
              'ACCESS_ROLE',
              this.jwtResponse.RoleId.toString()
            );
            sessionStorage.setItem('username', this.jwtResponse.username);
            this.router.navigateByUrl('/admin');
          } else {
            this.error =
              'Sorry! not allowed to access ... Invalid authorization';
          }
        },
        (error) => {
          this.error = 'Invalid username or password';
        }
      );
    }
  }

  //LoginVerify Test

  loginVerifyTest() {
    if (this.loginForm.valid) {
      this.authService.getUserByPassword(this.loginForm.value).subscribe(
        (data) => {
          console.log(data);
        },

        (error) => {
          console.log(error);
        }
      );
    }
  }
}
