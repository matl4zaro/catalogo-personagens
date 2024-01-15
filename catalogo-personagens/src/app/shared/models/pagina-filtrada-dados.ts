export interface PaginaFiltradaDados<T> {
  dados: T[];
  totalRegistros: number;
  pagina: number;
  registrosPorPagina: number;
}
