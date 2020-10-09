using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Manager.Negocio.Commands.Documentos
{
    public class AdicionarDocumentoRequest : IRequest<Response>
    {
        [Required(ErrorMessage ="Título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage ="Informe o caminho do arquivo")]
        public string URL { get; set; }
        [Required(ErrorMessage ="Informe a qual projeto este documento pertence")]
        public string Projeto { get; set; }
    }
}
