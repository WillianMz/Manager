using Flunt.Validations;
using Manager.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Manager.Domain.Entidades
{
    public class Ticket : EntidadeBase
    {
        private readonly List<Nota> _notas;
        private readonly List<Anexo> _anexos;

        //Para o EFCore
        protected Ticket() { }

        public Ticket(string titulo, string descricao, Usuario criador, Projeto projeto, Categoria categoria)
        {
            Titulo = titulo?.Trim().ToUpper();
            Descricao = descricao?.Trim().ToUpper();
            Criador = criador;
            Projeto = projeto;
            Categoria = categoria;
            StatusAtual = StatusEnum.Aberto;
            PrioridadeAtual = PrioridadeEnum.Normal;
            DataAbertura = DateTime.Now;

            _notas = new List<Nota>();
            _anexos = new List<Anexo>();            

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(titulo,"Titulo","Informe um titulo para o ticket")
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe a descrição do Ticket")
                .IsNotNull(criador, "Usuario", "Identifique o usuário criador do ticket")
                .IsNotNull(projeto, "Projeto", "Informe o projeto relacionado a este ticket")
                .IsNotNull(categoria, "Categoria", "Informe a categoria")
            );
        }

        public int Id { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public StatusEnum StatusAtual { get; private set; }
        public PrioridadeEnum PrioridadeAtual { get; private set; }
        public DateTime? DataFechamento { get; private set; }
        public string Solucao { get; private set; }
        public int Tempo { get; private set; }
        public DateTime? DataCancelamento { get; private set; }
        public string MotivoCancelamento { get; private set; }        

        //public virtual Status Status { get; private set; }
        //public virtual Prioridade Prioridade { get; private set; }        

        #region RELACIONAMENTOS

        public int CriadorId { get; private set; }  
        public virtual Usuario Criador { get; private set; }
        public int ProjetoId { get; private set; }
        public virtual Projeto Projeto { get; private set; }
        public int CategoriaId { get; private set; }
        public virtual Categoria Categoria { get; private set; }
        public int? UsuarioFechamentoId { get; private set; }
        public virtual Usuario UsuarioFechamento { get; private set; }
        public int? UsuarioCancelamentoId { get; private set; }
        public virtual Usuario UsuarioCancelamento { get; private set; }

        #endregion

        public virtual IReadOnlyCollection<Anexo> Anexos => _anexos;
        public virtual IReadOnlyCollection<Nota> Notas => _notas;        


        //METODOS
        public void Editar(string titulo, string descricao, Categoria categoria )
        {
            Titulo = titulo?.Trim().ToUpper();
            Descricao = descricao?.Trim().ToUpper();            
            Categoria = categoria;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(titulo,"Titulo","Informe o titulo do ticket")
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe a descrição do Ticket")                
                .IsNotNull(categoria, "Categoria", "Informe a categoria")
            );
        }

        public void Cancelar(string motivoCancelamento, Usuario usuarioQueCancelou)
        {
            MotivoCancelamento = motivoCancelamento?.Trim().ToUpper();
            UsuarioCancelamento = usuarioQueCancelou;
            DataCancelamento = DateTime.Now;

            if(StatusAtual != StatusEnum.Cancelado)
                StatusAtual = StatusEnum.Cancelado;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(motivoCancelamento,"Motivo de Cancelamento","Informe o motivo por estar cancelando este ticket")
                .IsNotNull(usuarioQueCancelou,"Usuario","Identifique o usuário que esta cancelando este ticket")
            );
        }

        public void Finalizar(string solucao, Usuario usuarioFinalizador)
        {
            Solucao = solucao?.Trim().ToUpper();
            DataFechamento = DateTime.Now;
            UsuarioFechamento = usuarioFinalizador;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(solucao,"Solução","Descreva a solução aplicada")
                .IsNotNull(usuarioFinalizador,"Usuario","Informe o usuário que finalizou o ticket")
            );

            if(StatusAtual == StatusEnum.Cancelado)
                AddNotification("Finalizar", "Não é possível finalizar um ticket cancelado");
            else
                StatusAtual = StatusEnum.Concluido;
        }

        public void AlterarPrioridade(PrioridadeEnum prioridadeEnum)
        {
            if ((StatusAtual == StatusEnum.Concluido) | (StatusAtual == StatusEnum.Cancelado) )
                AddNotification("Status", "Não é possível alterar a prioridade de um ticket concluído ou cancelado");
            else
                PrioridadeAtual = prioridadeEnum;
        }

        public void AlterarStatus(StatusEnum statusEnum)
        {
            StatusAtual = statusEnum;
        }

        public void AdicionarNota(Nota nota)
        {
            if (nota.Valid)
                _notas.Add(nota);
            else
                AddNotification("Nota", "A nota adicionada é invalida");
        }        

        public void AdicionarAnexo(Anexo anexo)
        {
            //List<Anexo> _anexos = new List<Anexo>();
            if (anexo.Valid)
                _anexos.Add(anexo);
            else
                AddNotification("Anexo", "O anexo adicionado é invalido");
        }

        public void ExcluirNota(Nota nota)
        {
            _notas.Remove(nota);
        }

        public void ExcluirAnexo(Anexo anexo)
        {
            _anexos.Remove(anexo);
        }

    }
}