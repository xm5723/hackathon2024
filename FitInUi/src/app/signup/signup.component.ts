import { Component, inject } from '@angular/core';
import { AngularFireAuthModule } from '@angular/fire/compat/auth';
import { AuthService } from './../auth/auth.service'; 
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgIf } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [ AngularFireAuthModule, ReactiveFormsModule, NgIf],
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  // Inject FormBuilder and AuthService
  authService = inject(AuthService);
  fb = inject(FormBuilder);

  signupForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
  });

  successMessage: string = '';
  errorMessage: string = '';
  passwordVisible: boolean = false;


  constructor(private router: Router) {}

  togglePasswordVisibility() {
    this.passwordVisible = !this.passwordVisible;
  }
  
  onSubmit() {
    if (this.signupForm.valid) {
      const { email, password } = this.signupForm.value;
      this.authService.signUp(email ?? "", password ?? "")
        .then(response => {
          this.successMessage = 'Signup successful!\nRedirecting to Login...';
          this.errorMessage = '';
          setTimeout(() => {
            this.router.navigate(['/login']); // Adjust the route if necessary
          }, 2000); // Wait for 2 seconds before redirecting
        })
        .catch(error => {
          this.errorMessage = error.message;
          this.successMessage = '';
        });
    } else {
      this.errorMessage = 'Please fill out all fields correctly.';
    }
  }
}
