using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using Manager.Infra.Data.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

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

            Console.WriteLine("Iniciando envio de email...");

            //string urlAnexo = "E:/Projetos/Manager/Docs/Tarefas.txt";


            EnviarEmail("Consultas da api", "Encontra-se no arquivo em anexo as consultar do sistema",
                        "willianmz.wn@gmail.com");

            #region CRIACAO DE TICKETS
            //Console.WriteLine("Iniciando teste de criação de tickets, aguarde...");

            //Console.WriteLine("Conectando a base de dados...");
            //var optBuilder = new DbContextOptionsBuilder<ManagerContext>();
            //optBuilder.UseLazyLoadingProxies();
            //optBuilder.UseMySql("Server=localhost;userid=root;password=;database=ManagerDB",
            //    m => m.MigrationsAssembly("Manager.Infra.Data").MaxBatchSize(100)
            //);

            //try
            //{
            //    using(var database = new ManagerContext(optBuilder.Options))
            //    {
            //        IRepositorioCategoria repositorioCategoria = new RepositorioCategoria(database);
            //        IRepositorioProjeto repositorioProjeto = new RepositorioProjeto(database);
            //        IRepositorioUsuario repositorioUsuario = new RepositorioUsuario(database);
            //        IRepositorioTicket repositorioTicket = new RepositorioTicket(database);

            //        Usuario usuario = repositorioUsuario.CarregarObjetoPeloID(1);
            //        Categoria categoria = repositorioCategoria.CarregarObjetoPeloID(4);
            //        Projeto projeto = repositorioProjeto.CarregarObjetoPeloID(1);

            //        Ticket ticket = new Ticket("teste","teste", usuario, projeto, categoria);
            //        repositorioTicket.Adicionar(ticket);

            //        database.SaveChanges();

            //        Console.WriteLine("Ticket criado com sucesso!");

            //    }

            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine("Ocorreu um erro! Detalhes: " + ex.Message);
            //    Console.WriteLine("Pressione enter para continuar");
            //    Console.ReadKey();
            //}

            #endregion

        }

        private static void EnviarEmail(string titulo, string corpo, string destinatario)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress("willianmazzorana@hotmail.com","Manager Tickets");
            Console.WriteLine("Remetente: " +email.From);
            email.To.Add(new MailAddress(destinatario));
            Console.WriteLine("Destinatario: "+email.To);
            //cópia oculta
            email.CC.Add(new MailAddress("willian.mz@outlook.com.br"));
            Console.WriteLine("Enviar cópia para: "+email.CC);

            email.Subject = titulo;
            Console.WriteLine("Titulo: "+titulo);
            email.Body = corpo;
            Console.WriteLine("Corpo: "+corpo);
            email.IsBodyHtml = false;

            //teste de anexo
           //MemoryStream ms = new MemoryStream(anexo.file)

            try
            {
                using (var smtp = new SmtpClient())
                {
                    smtp.Host = "smtp-mail.outlook.com";
                    Console.WriteLine("Host: " + smtp.Host);
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("willianmazzorana@hotmail.com", "wn2020willian");

                    smtp.Send(email);
                }

                Console.WriteLine("Email enviado");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
