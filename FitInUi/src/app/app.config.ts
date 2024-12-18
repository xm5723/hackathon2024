import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideAuth, getAuth } from '@angular/fire/auth';
import { provideFirebaseApp, initializeApp } from '@angular/fire/app';
import { firebaseConfig } from './auth/firebase-config';
import { provideHttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';


export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideAuth(() => getAuth()),
    provideHttpClient(),
    provideFirebaseApp(() => initializeApp(firebaseConfig)),
  ]};

