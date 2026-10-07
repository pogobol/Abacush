import { TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { of } from 'rxjs';
import { describe, expect, it, vi } from 'vitest';
import { App } from './app';
import { Login } from './pages/login/login';
import { environment } from '../environments/environment';

describe('App', () => {
  it('creates', () => {
    TestBed.configureTestingModule({ providers: [provideRouter([])] });
    expect(TestBed.createComponent(App).componentInstance).toBeTruthy();
  });
});

describe('Login', () => {
  it('delegates login with Auth0 audience/scope from environment', () => {
    const authServiceMock = {
      user$: of(null),
      isAuthenticated$: of(false),
      loginWithRedirect: vi.fn(),
      logout: vi.fn(),
    };
    TestBed.configureTestingModule({
      providers: [{ provide: AuthService, useValue: authServiceMock }],
    });

    const login = TestBed.runInInjectionContext(() => new Login());
    (login as any).login();

    expect(authServiceMock.loginWithRedirect).toHaveBeenCalledWith({
      authorizationParams: {
        audience: environment.auth0.audience,
        scope: environment.auth0.scope,
      },
    });
  });
});
