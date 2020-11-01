using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using Manager.Infra.Data.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;

namespace Manager.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("ManagerTickets");
            Console.WriteLine("Versão 1.0.0");
            Console.WriteLine("");            
            Console.WriteLine("Pressione enter para continuar");
            Console.ReadKey();
            Console.WriteLine("Iniciando teste de criação de tickets, aguarde...");

            Console.WriteLine("Conectando a base de dados...");
            var optBuilder = new DbContextOptionsBuilder<ManagerContext>();
            optBuilder.UseLazyLoadingProxies();
            optBuilder.UseMySql("Server=localhost;userid=root;password=;database=ManagerDB",
                m => m.MigrationsAssembly("Manager.Infra.Data").MaxBatchSize(100)
            );

            try
            {
                using(var database = new ManagerContext(optBuilder.Options))
                {
                    IRepositorioCategoria repositorioCategoria = new RepositorioCategoria(database);
                    IRepositorioProjeto repositorioProjeto = new RepositorioProjeto(database);
                    IRepositorioUsuario repositorioUsuario = new RepositorioUsuario(database);
                    IRepositorioTicket repositorioTicket = new RepositorioTicket(database);

                    Usuario usuario = repositorioUsuario.CarregarObjetoPeloID(1);
                    Categoria categoria = repositorioCategoria.CarregarObjetoPeloID(4);
                    Projeto projeto = repositorioProjeto.CarregarObjetoPeloID(1);

                    Ticket ticket = new Ticket("teste","teste", usuario, projeto, categoria);
                    repositorioTicket.Adicionar(ticket);

                    database.SaveChanges();

                    Console.WriteLine("Ticket criado com sucesso!");

                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Ocorreu um erro! Detalhes: " + ex.Message);
                Console.WriteLine("Pressione enter para continuar");
                Console.ReadKey();
            }

        }
    }
}
