import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { AuthService } from '@auth0/auth0-angular';
import { of } from 'rxjs';
import { describe, expect, it, vi } from 'vitest';
import { App } from './app';
import { environment } from '../environments/environment';

describe('App', () => {
  it('creates in an Angular injection context', () => {
    const authServiceMock = {
      user$: of(null),
      isAuthenticated$: of(false),
      loginWithRedirect: vi.fn(),
      logout: vi.fn(),
    };
    const httpClientMock = {
      get: vi.fn(),
    };

    TestBed.configureTestingModule({
      providers: [
        { provide: AuthService, useValue: authServiceMock },
        { provide: HttpClient, useValue: httpClientMock },
      ],
    });

    const app = TestBed.runInInjectionContext(() => new App());

    expect(app).toBeTruthy();
  });

  it('delegates login with Auth0 audience/scope from environment', () => {
    const authServiceMock = {
      user$: of(null),
      isAuthenticated$: of(false),
      loginWithRedirect: vi.fn(),
      logout: vi.fn(),
    };
    const httpClientMock = {
      get: vi.fn(),
    };

    TestBed.configureTestingModule({
      providers: [
        { provide: AuthService, useValue: authServiceMock },
        { provide: HttpClient, useValue: httpClientMock },
      ],
    });

    const app = TestBed.runInInjectionContext(() => new App());

    (app as any).login();

    expect(authServiceMock.loginWithRedirect).toHaveBeenCalledWith({
      authorizationParams: {
        audience: environment.auth0.audience,
        scope: environment.auth0.scope,
      },
    });
  });
});
