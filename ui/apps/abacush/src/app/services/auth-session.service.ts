import { Injectable, inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthSessionService {
  private readonly auth = inject(AuthService);

  readonly isAuthenticated$ = this.auth.isAuthenticated$;
  readonly user$ = this.auth.user$;

  login(): void {
    this.auth.loginWithRedirect({
      authorizationParams: {
        audience: environment.auth0.audience,
        scope: environment.auth0.scope,
      },
    });
  }

  logout(): void {
    this.auth.logout({ logoutParams: { returnTo: `${window.location.origin}/login` } });
  }
}
