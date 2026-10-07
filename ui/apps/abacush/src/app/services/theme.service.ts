import { Injectable, signal } from '@angular/core';

const STORAGE_KEY = 'abacush-theme';

@Injectable({ providedIn: 'root' })
export class ThemeService {
  readonly isDark = signal(this.initial());

  constructor() {
    this.apply();
  }

  toggle(): void {
    this.isDark.update((v) => !v);
    localStorage.setItem(STORAGE_KEY, this.isDark() ? 'dark' : 'light');
    this.apply();
  }

  private initial(): boolean {
    const stored = localStorage.getItem(STORAGE_KEY);
    return stored ? stored === 'dark' : window.matchMedia('(prefers-color-scheme: dark)').matches;
  }

  private apply(): void {
    document.documentElement.classList.toggle('dark', this.isDark());
  }
}
