using Flunt.Validations;
using Manager.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Manager.Domain.Entidades
{
    public class Ticket : EntidadeBase
    {
        private List<Nota> _notas;
        private List<Anexo> _anexos;

        //Para o EFCore
        protected Ticket() { }

        public Ticket(string descricao, Usuario usuario, Projeto projeto, Categoria categoria)
        {
            Descricao = descricao?.Trim().ToUpper();
            Usuario = usuario;
            Projeto = projeto;
            Categoria = categoria;

            StatusAtual = StatusEnum.Aberto;
            PrioridadeAtual = PrioridadeEnum.Normal;

            _notas = new List<Nota>();
            _anexos = new List<Anexo>();

            DataAbertura = DateTime.Now;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe a descrição do Ticket")
                .IsNotNull(usuario, "Usuario", "Identifique o usuário criador do ticket")
                .IsNotNull(projeto, "Projeto", "Informe o projeto relacionado a este ticket")
                .IsNotNull(categoria, "Categoria", "Informe a categoria")
            );

        }

        public int Id { get; private set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public int Tempo { get; set; }
        public string Descricao { get; set; }
        public string Solucao { get; set; }             
        public virtual Status Status { get; set; }
        public virtual Prioridade Prioridade { get; set; }

        public StatusEnum StatusAtual { get; private set; }
        public PrioridadeEnum PrioridadeAtual { get; private set; }

        #region RELACIONAMENTOS

        //relacionamentos
        public int UsuarioId { get; set; }  
        public virtual Usuario Usuario { get; set; }
        public int ProjetoId { get; set; }
        public virtual Projeto Projeto { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        #endregion

        public virtual IReadOnlyCollection<Anexo> Anexos => _anexos;
        public virtual IReadOnlyCollection<Nota> Notas => _notas;        


        //METODOS
        public void Editar(string descricao, Usuario usuario, Categoria categoria )
        {
            Descricao = descricao?.Trim().ToUpper();
            Usuario = usuario;
            Categoria = categoria;

            if (usuario.Id != Usuario.Id)
                AddNotification("Usuario", "Somento o usuário criador do ticket pode edita-lo!");

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe a descrição do Ticket")
                .IsNotNull(usuario, "Usuario", "Identifique o usuário criador do ticket")
                .IsNotNull(categoria, "Categoria", "Informe a categoria")
            );
        }

        public void Cancelar()
        {
            if(StatusAtual != StatusEnum.Cancelado)
                StatusAtual = StatusEnum.Cancelado;
        }

        public void Finalizar(string solucao)
        {
            Solucao = solucao?.Trim().ToUpper();
            DataFechamento = DateTime.Now;

            if (string.IsNullOrEmpty(solucao))
                AddNotification("Solucao", "Descreva a solução aplicada neste ticket");

            if(StatusAtual == StatusEnum.Cancelado)
                AddNotification("Finalizar", "Não é possível finalizar um ticket cancelado");
            else
                StatusAtual = StatusEnum.Concluido;
        }

        public void AlterarPrioridade(PrioridadeEnum prioridadeEnum)
        {
            if ((StatusAtual == StatusEnum.Concluido) | (StatusAtual == StatusEnum.Cancelado) )
            {
                AddNotification("Status", "Não é possível alterar a prioridade de um ticket concluído ou cancelado");
            }
            else
            {
                PrioridadeAtual = prioridadeEnum;
            }            
        }

        public void AdicionarNota(Nota nota)
        {
            if(nota.Valid)
            {
                _notas.Add(nota);
            }
            else
            {
                AddNotification("Nota", "A nota adicionada é invalida");
            }
        }        

        public void AdicionarAnexo(Anexo anexo)
        {
            if (anexo.Valid)
            {
                _anexos.Add(anexo);
            }
            else
            {
                AddNotification("Anexo", "O anexo adicionado é invalido");
            }
        }

    }
}