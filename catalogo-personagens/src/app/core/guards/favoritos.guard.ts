// auth.guard.ts

import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { LoginDialogComponent } from 'src/app/shared/components/login-dialog/login-dialog.component';

@Injectable({
    providedIn: 'root',
})
export class FavoritosGuard implements CanActivate {
  constructor(
    private _auth: AuthService, private _dialog: MatDialog) { }

  canActivate(): boolean {
    if (this._auth.verificarLogin()) {
      return true;
    }
    this._abrilLoginDialog();
    return false;
  }

  private _abrilLoginDialog() {
    const dialogRef = this._dialog.open(LoginDialogComponent);

    dialogRef
      .afterClosed()
      .subscribe(() => {});
  }
}
