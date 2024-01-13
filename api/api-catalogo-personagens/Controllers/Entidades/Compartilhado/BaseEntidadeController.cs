using Interfaces.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace api_catalogo_personagens.Controllers.Entidades.Compartilhado;

public class BaseEntidadeController<T> : ControllerBase where T : class
{
    protected readonly IOperacaoBasicaServico<T> _operacaoBasica;

    public BaseEntidadeController(
        IOperacaoBasicaServico<T> operacaoBasica
    )
    {
        _operacaoBasica = operacaoBasica;
    }

    [HttpPost("Cadastrar")]
    public IActionResult Cadastrar([FromBody] T entidade)
    {
        try
        {
            var retorno = _operacaoBasica.Cadastrar(entidade);
            return Ok(new { retorno });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost("CadastrarListagem")]
    public IActionResult CadastrarListagem([FromBody] List<T> entidades)
    {
        try
        {
            var retorno = _operacaoBasica.CadastrarListagem(entidades);

            return Ok(new { retorno });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost("Atualizar")]
    public IActionResult Atualizar([FromBody] T entidade)
    {
        try
        {
            var resultado = _operacaoBasica.Atualizar(entidade);

            return Ok(new { resultado });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpDelete("Excluir")]
    public IActionResult Excluir([FromQuery] T entidade)
    {
        try
        {
            var resultado = _operacaoBasica.Excluir(entidade);

            return Ok(new { resultado });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpDelete("ExcluirPorId")]
    public IActionResult ExcluirPorId([FromQuery] int entidadeId)
    {
        try
        {
            var resultado = _operacaoBasica.ExcluirPorId(entidadeId);

            return Ok(new { resultado });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("ObterTodos")]
    public IActionResult ObterTodos()
    {
        try
        {
            var lista = _operacaoBasica.ObterTodos();

            return Ok(lista);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("ObterPorId")]
    public IActionResult ObterPorId(int entidadeId)
    {
        try
        {
            var retorno = _operacaoBasica.ObterPorId(entidadeId);

            return Ok(retorno);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }


}

