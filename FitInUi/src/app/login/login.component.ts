// import { Component } from '@angular/core';
// import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
// import { HttpClient, HttpClientModule } from '@angular/common/http';
// import { CommonModule } from '@angular/common';
// import { Router } from '@angular/router';

// @Component({
//   selector: 'app-login',
//   standalone: true,
//   imports: [CommonModule, ReactiveFormsModule, HttpClientModule],
//   templateUrl: './login.component.html',
//   styleUrls: ['./login.component.css'],
// })
// export class LoginComponent {
//   loginForm: FormGroup;
//   message: string | null = null;

//   private apiEndpoint = 'https://localhost:5185/api/login';

//   constructor(private fb: FormBuilder, private http: HttpClient, private router: Router) {
//     this.loginForm = this.fb.group({
//       username: ['', [Validators.required]],
//       password: ['', [Validators.required]],
//     });
//   }

//   onSubmit(): void {
//     if (this.loginForm.valid) {
//       const { username, password } = this.loginForm.value;

//       this.http.post(this.apiEndpoint, { username, password }).subscribe(
//         (response: any) => {
//           this.message = `Login successful: Welcome, ${response.username}!`;
//           this.router.navigate(['/dashboard']);
//         },
//         (error) => {
//           this.message = error.error?.message || 'Login failed. Please try again.';
//         }
//       );
//     }
//   }

//   goToRegister(): void {
//     this.router.navigate(['/register']);
//   }
// }


import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { initializeApp } from 'firebase/app';
import { getAuth, signInWithEmailAndPassword } from 'firebase/auth';
import { firebaseConfig } from './firebase-config';  // Import Firebase config
import { NgIf } from '@angular/common';

// Initialize Firebase app
const app = initializeApp(firebaseConfig);
const auth = getAuth(app);

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [ReactiveFormsModule, NgIf]
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMessage: string = '';

  constructor(private router: Router, private fb: FormBuilder) {
    // Create a reactive form with email and password controls
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  // Getter for easy access to form fields in the template
  get email() {
    return this.loginForm.get('email');
  }

  get password() {
    return this.loginForm.get('password');
  }

  login() {
    if (this.loginForm.invalid) {
      alert('Login Not Success!');
      return; // Don't proceed if form is invalid
    }

    alert('Login successful!');

    const { email, password } = this.loginForm.value;

    signInWithEmailAndPassword(auth, email, password)
      .then((userCredential) => {
      //Navigate to homepage
      })
      .catch((error) => {
        // Handle login error
        console.error('Login error: ', error);
        this.errorMessage = error.message;
      });
  }
}
