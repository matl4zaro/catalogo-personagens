import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginDialogComponent } from 'src/app/shared/components/login-dialog/login-dialog.component';

@Component({
  selector: 'home-inicial',
  templateUrl: 'inicial.component.html'
})

export class InicialComponent {
  constructor(public dialog: MatDialog) {}

  openDialog() {
    const dialogRef = this.dialog.open(LoginDialogComponent);

    dialogRef
      .afterClosed()
      .subscribe(() => {});
  }

}