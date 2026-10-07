import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { map, take } from 'rxjs';
import { AuthSessionService } from '../services/auth-session.service';

export const authGuard: CanActivateFn = () => {
  const router = inject(Router);
  return inject(AuthSessionService).isAuthenticated$.pipe(
    take(1),
    map((isAuthenticated) => isAuthenticated || router.createUrlTree(['/login']))
  );
};

export const guestGuard: CanActivateFn = () => {
  const router = inject(Router);
  return inject(AuthSessionService).isAuthenticated$.pipe(
    take(1),
    map((isAuthenticated) => !isAuthenticated || router.createUrlTree(['/']))
  );
};
