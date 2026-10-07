import { AsyncPipe } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { ThemeService } from '../../theme.service';

@Component({
  imports: [AsyncPipe],
  selector: 'app-home',
  templateUrl: './home.html',
})
export class Home {
  private readonly auth = inject(AuthService);
  protected readonly theme = inject(ThemeService);

  protected readonly user$ = this.auth.user$;
  protected readonly menuOpen = signal(false);

  protected readonly navItems = ['Dashboard', 'Apps', 'Pages', 'Customers', 'Reports', 'Settings'];

  protected readonly tiles = [
    { label: 'Employees', value: '96', bg: 'bg-indigo-50 dark:bg-indigo-500/10', text: 'text-indigo-600' },
    { label: 'Clients', value: '3,650', bg: 'bg-amber-50 dark:bg-amber-500/10', text: 'text-amber-600' },
    { label: 'Projects', value: '356', bg: 'bg-rose-50 dark:bg-rose-500/10', text: 'text-rose-600' },
    { label: 'Events', value: '696', bg: 'bg-sky-50 dark:bg-sky-500/10', text: 'text-sky-600' },
    { label: 'Payroll', value: '$96k', bg: 'bg-emerald-50 dark:bg-emerald-500/10', text: 'text-emerald-600' },
    { label: 'Reports', value: '59', bg: 'bg-violet-50 dark:bg-violet-500/10', text: 'text-violet-600' },
  ];

  protected readonly months = [
    { name: '16/08', value: 40 },
    { name: '17/08', value: 55 },
    { name: '18/08', value: 35 },
    { name: '19/08', value: 70 },
    { name: '20/08', value: 60 },
    { name: '21/08', value: 85 },
    { name: '22/08', value: 75 },
  ];

  protected readonly products = [
    { name: 'MaterialPro', amount: '$23,568', share: '55%' },
    { name: 'Flexy Admin', amount: '$23,568', share: '20%' },
    { name: 'Ample Admin', amount: '$12,400', share: '14%' },
  ];

  protected readonly performers = [
    { name: 'Sunil Joshi', project: 'Elite Admin', budget: '$3.9k', status: 'Paid' },
    { name: 'Andrew McDownland', project: 'Real Homes', budget: '$24.5k', status: 'Pending' },
    { name: 'Christopher Jamil', project: 'MedicalPro', budget: '$12.8k', status: 'Paid' },
    { name: 'Nirav Joshi', project: 'Hosting Press', budget: '$2.4k', status: 'Failed' },
  ];
  protected statusClass(status: string): string {
    switch (status) {
      case 'Paid':
        return 'bg-emerald-100 text-emerald-700';
      case 'Pending':
        return 'bg-amber-100 text-amber-700';
      default:
        return 'bg-rose-100 text-rose-700';
    }
  }

  protected logout(): void {
    this.auth.logout({ logoutParams: { returnTo: window.location.origin + '/login' } });
  }
}
