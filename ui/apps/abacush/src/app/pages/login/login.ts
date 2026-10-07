import { Component, inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.html',
})
export class Login {
  private readonly auth = inject(AuthService);

  protected login(): void {
    this.auth.loginWithRedirect({
      authorizationParams: {
        audience: environment.auth0.audience,
        scope: environment.auth0.scope,
      },
    });
  }
}
