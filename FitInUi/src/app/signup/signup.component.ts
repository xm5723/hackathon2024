import { Component, inject } from '@angular/core';
import { AngularFireAuthModule } from '@angular/fire/compat/auth';
import { AuthService } from './../auth/auth.service'; 
// import { firebaseConfig } from './../login/firebase-config';
// import { AngularFireModule } from '@angular/fire/compat'
// import { provideFirebaseApp, initializeApp } from '@angular/fire/app';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgIf } from '@angular/common';

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


  constructor() {}

  onSubmit() {
    if (this.signupForm.valid) {
      const { email, password } = this.signupForm.value;
      this.authService.signUp(email ?? "", password ?? "")
        .then(response => {
          this.successMessage = 'Signup successful!';
          this.errorMessage = '';
          // navigate to main page
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
