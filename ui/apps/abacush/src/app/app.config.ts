import {
  ApplicationConfig,
  provideBrowserGlobalErrorListeners,
  importProvidersFrom,
} from '@angular/core';
import {
  HTTP_INTERCEPTORS,
  provideHttpClient,
  withInterceptorsFromDi,
} from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { AuthHttpInterceptor, AuthModule } from '@auth0/auth0-angular';
import { appRoutes } from './app.routes';
import { environment } from '../environments/environment';

const apiBaseUrl = environment.apiBaseUrl.replace(/\/$/, '');

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideHttpClient(withInterceptorsFromDi()),
    provideRouter(appRoutes),
    importProvidersFrom(
      AuthModule.forRoot({
        domain: environment.auth0.domain,
        clientId: environment.auth0.clientId,
        authorizationParams: {
          redirect_uri: window.location.origin,
          audience: environment.auth0.audience,
          scope: environment.auth0.scope,
        },
        httpInterceptor: {
          allowedList: [
            {
              uri: `${apiBaseUrl}/api/*`,
              tokenOptions: {
                authorizationParams: {
                  audience: environment.auth0.audience,
                  scope: environment.auth0.scope,
                },
              },
            },
          ],
        },
        cacheLocation: 'localstorage',
        useRefreshTokens: true,
      })
    ),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthHttpInterceptor,
      multi: true,
    },
  ],
};
