import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/auth/auth.service';
import { UsuarioLogin } from 'src/app/shared/models/usuario';

@Component({
  selector: 'home-inicial',
  templateUrl: 'inicial.component.html'
})

export class InicialComponent implements OnInit {
  usuarioLogin: UsuarioLogin = { usuario: '', senha: '' };
  constructor(private _auth: AuthService) { }

  ngOnInit() { }

  login() {

    this._auth.login(this.usuarioLogin);
  }
}