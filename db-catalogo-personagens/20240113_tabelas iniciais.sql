CREATE TABLE [Personagem] (
  [PersonagemId] int PRIMARY KEY,
  [Nome] nvarchar(255),
  [Descricao] nvarchar(255),
  [ThumbnailUrl] nvarchar(255),
  [Modificado] datetime,
  [SincronizadoEm] datetime
)
GO

CREATE TABLE [Usuario] (
  [UsuarioId] int PRIMARY KEY IDENTITY(1, 1),
  [Login] nvarchar(255),
  [Senha] nvarchar(255),
  [Usuario] nvarchar(255),
  [CriadodoEm] datetime
)
GO

CREATE TABLE [PersonagemFavoritoUsuario] (
  [UsuarioId] int,
  [PersonagemId] int,
  [FavoritadoEm] datetime
)
GO

ALTER TABLE [PersonagemFavoritoUsuario] ADD FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([UsuarioId])
GO

ALTER TABLE [PersonagemFavoritoUsuario] ADD FOREIGN KEY ([PersonagemId]) REFERENCES [Personagem] ([PersonagemId])
GO
