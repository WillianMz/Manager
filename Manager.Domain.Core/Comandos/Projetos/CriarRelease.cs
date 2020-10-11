using MediatR;
using System;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class CriarRelease : IRequest<Response>
    {
        public CriarRelease(string nome, string descricao, string versao, int idProjeto, int idUsuario, DateTime dataLiberacao)
        {
            Nome = nome;
            Descricao = descricao;
            Versao = versao;
            ProjetoId = idProjeto;
            UsuarioId = idUsuario;
            DataLiberacao = dataLiberacao;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Versao { get; set; }
        public int ProjetoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataLiberacao { get; set; }
    }
}
