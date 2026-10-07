import { Component, inject } from '@angular/core';
import { AuthSessionService } from '../../services/auth-session.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.html',
})
export class Login {
  private readonly session = inject(AuthSessionService);

  protected login(): void {
    this.session.login();
  }
}
