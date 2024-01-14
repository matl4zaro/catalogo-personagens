export interface Usuario {
  usuarioId: number;
  login: string;
  senha: string;
  usuarioNome: string;
  criadoEm: Date;
}

export interface UsuarioLogin {
  usuario: string;
  senha: string;
}

export interface UsuarioLogado {
  token: string;
}
