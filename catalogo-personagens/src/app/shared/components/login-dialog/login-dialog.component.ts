import { Component } from "@angular/core";
import { UsuarioLogin } from "../../models/usuario";
import { AuthService } from "src/app/core/auth/auth.service";
import { MatDialogRef } from "@angular/material/dialog";

@Component({
  selector: 'shared-login-dialog',
  templateUrl: 'login-dialog.component.html',
})
export class LoginDialogComponent {
  usuarioLogin: UsuarioLogin = { usuario: '', senha: '' };
  constructor(
    private _auth: AuthService,
    private _dialogSelf: MatDialogRef<LoginDialogComponent>) { }

  ngOnInit() { }

  login() {
    this._auth.login(this.usuarioLogin).add(() => this._dialogSelf.close());
    //TODO: Melhorar tratativa, no caso de falha de login fecha o modal, mas o erro deverá ser tratado
  }
}
