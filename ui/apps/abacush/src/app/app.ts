import { HttpClient } from '@angular/common/http';
import { AsyncPipe, JsonPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { RouterOutlet } from '@angular/router';
import { environment } from '../environments/environment';

@Component({
  imports: [AsyncPipe, JsonPipe, RouterOutlet],
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  private readonly auth = inject(AuthService);
  private readonly httpClient = inject(HttpClient);

  protected readonly title = 'Abacush';
  protected readonly user$ = this.auth.user$;
  protected readonly isAuthenticated$ = this.auth.isAuthenticated$;

  protected apiResponse: unknown = null;
  protected apiError: string | null = null;

  protected login(): void {
    this.auth.loginWithRedirect({
      authorizationParams: {
        audience: environment.auth0.audience,
        scope: environment.auth0.scope,
      },
    });
  }

  protected logout(): void {
    this.auth.logout({
      logoutParams: {
        returnTo: window.location.origin,
      },
    });
  }

  protected callProtectedApi(): void {
    this.apiError = null;
    this.httpClient
      .get<unknown>(`${environment.apiBaseUrl}/api/auth/me`)
      .subscribe({
        next: (response) => {
          this.apiResponse = response;
        },
        error: () => {
          this.apiResponse = null;
          this.apiError =
            'Could not call the protected API. Confirm Auth0 values and API URL configuration.';
        },
      });
  }
}
