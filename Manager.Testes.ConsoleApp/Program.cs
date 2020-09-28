using Castle.Core.Internal;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Interfaces.Repositorios.Base;
using Manager.Infra.Data.Context;
using Manager.Infra.Data.Repositorios;
using Manager.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Manager.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {           

            Console.WriteLine("2020 © WN Tecnologia");
            Console.WriteLine("Manager Teste - v1.0 | 2020-09-16");            
            Console.WriteLine("");
            Console.WriteLine("Iniciando...");
            Console.WriteLine("");
            Console.WriteLine("Pressione enter para continuar!");
            Console.ReadKey();

            Console.WriteLine("Conectando a base de dados, aguarde...");
            var optBuilder = new DbContextOptionsBuilder<ManagerContext>();
            optBuilder.UseLazyLoadingProxies();
            optBuilder.UseMySql("Server=localhost;userid=root;password=;database=ManagerDB", m => m.MigrationsAssembly("Manager.Infra.Data").MaxBatchSize(100));


            try
            {
                using (var database = new ManagerContext(optBuilder.Options))
                {
                    IRepositorioCategoria _repo = new RepositorioCategoria(database);                    

                    Console.WriteLine("Processando............");

                    //CategoriaNegocio cn = new CategoriaNegocio(_repo);
                    //var lista = cn.ListarCategorias();

                    //foreach(Categoria c in lista)
                    //{
                    //    Console.WriteLine(Convert.ToString(c.Id) + " - " + c.Nome);
                    //}

                    #region ADICIONAR CATEGORIA

                    //TESTE PARA ADICIONAR NOVAS CATEGORIAS A BASE DE DADOS - ok
                    //Console.WriteLine("Digite o nome da categoria: ");
                    //var catg = Console.ReadLine();

                    ////if (catg != string.Empty)
                    ////{
                    //    Categoria c1 = new Categoria(catg);

                    //    var existe = _repo.ExisteEntidade(c1);

                    //    if (existe == false)
                    //    {
                    //        Console.WriteLine("Nome da categoria: " + c1.Nome);
                    //        _repo.Adicionar(c1);
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("Já existe uma categoria com este nome! \n " +
                    //            "Não sera possível criar uma nova categoria com o mesmo nome! Verifique e tente novamente!");
                    //    }

                    //}
                    //else
                    //{
                    //    Console.WriteLine("Nome da categoria não pode ser vazio!");
                    //    return;
                    //}

                    //ADICIONAR LISTA DE CATEGORIAS - ok
                    //Console.WriteLine("Criando lista de categorias...");
                    //Categoria c2 = new Categoria("Categoria 2");
                    //Categoria c3 = new Categoria("Categoria 3");
                    //Categoria c4 = new Categoria("Categoria 4");
                    //Categoria c5 = new Categoria("Categoria 5");

                    //List<Categoria> categorias = new List<Categoria>() { c2, c3, c4, c5 };                   

                    //Console.WriteLine("Listas de categorias criada com sucesso!");
                    //_repo.AdicionarLista(categorias);
                    //Console.WriteLine("Listas de categorias adicionada a base de dados!");

                    //Console.WriteLine("-------------------------------------------");

                    #endregion

                    #region REMOVER CATEGORIA

                    //TESTE PARA REMOVER CATEGORIAS DA BASE DE DADOS - ok
                    //Console.WriteLine("Teste de remover categoria");
                    //Console.WriteLine("Informe o Id:");
                    //var ID = Console.ReadLine();

                    //Categoria categoria = new Categoria();
                    //categoria = _repo.CarregarObjetoPeloID(int.Parse(ID));

                    //if (categoria != null)
                    //{
                    //    Console.WriteLine("Categoria a ser removida da base de dados: \n" + categoria.Id + " - " + categoria.Nome);
                    //    Console.WriteLine("Pressione Enter para continuar");
                    //    Console.ReadLine();
                    //    Console.WriteLine("Removendo categoria, aguarde...");
                    //    _repo.Remover(categoria);
                    //    Console.WriteLine("Categoria removida com sucesso!");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Nenhuma categoria foi encontrada com o Id: " + ID);
                    //}

                    //REMOVER LISTA DE CATEGORIAS - esta OK
                    ////List<Categoria> listaRemover = new List<Categoria>();
                    ////Categoria categoria1 = new Categoria();
                    ////Categoria categoria2 = new Categoria();
                    ////Categoria categoria3 = new Categoria();
                    ////Categoria categoria4 = new Categoria();

                    ////categoria1 = _repo.CarregarObjetoPeloID(1);
                    ////categoria2 = _repo.CarregarObjetoPeloID(2);
                    ////categoria3 = _repo.CarregarObjetoPeloID(3);
                    ////categoria4 = _repo.CarregarObjetoPeloID(4);

                    ////listaRemover.Add(categoria1);
                    ////listaRemover.Add(categoria2);
                    ////listaRemover.Add(categoria3);
                    ////listaRemover.Add(categoria4);

                    ////_repo.RemoverLista(listaRemover);

                    Console.WriteLine("-------------------------------------------");

                    #endregion


                    #region PROJETOS
                    ////ADICIONAR PROJETO

                    Console.WriteLine("");
                    Console.WriteLine("CRIANDO PROJETO PARA TESTE");

                    try
                    {
                        Projeto projeto = new Projeto("Manager Chamados");
                        projeto.AdicionarRelease(new Release("teste", "v1.0.0", projeto));
                        //projeto.Releases.Add(new Release("", "v.1.2", projeto));
                        //projeto.Documentos.Add(new Documento("Caso de uso","Diagrama com as especificação de casos de uso do sistema", projeto));

                        IRepositorioProjeto repositorioProjeto = new RepositorioProjeto(database);
                        //repositorioProjeto.Adicionar(projeto);

                        //Documento doc = new Documento("Diagrama de classes2", "teste", projeto);
                        //                        Release rel = new Release("Teste release2", "teste", projeto);
                        repositorioProjeto.Adicionar(projeto);
                        //projeto.Documentos.Add(doc);
                        //negocio.SalvarProjeto(projeto, doc, rel);
                        //negocio.SalvarProjeto(projeto, null, null);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    #endregion

                    #region LISTAGEMS

                    //ORDEM CRESCENTE
                    //Console.WriteLine("");
                    //Console.WriteLine("Listagem por ordem Crescente");

                    //var crescente = _repo.ListarNomeEmOrdemCrescente();

                    //foreach (Categoria c in crescente)
                    //{
                    //    Console.WriteLine(Convert.ToString(c.Id) + " - " + c.Nome);
                    //}

                    //Console.WriteLine("-------------------------------------------");

                    ////ORDEM DECRESCENTE
                    //Console.WriteLine("");
                    //Console.WriteLine("Listagem por ordem Decrescente");

                    //var decrescente = _repo.ListarNomeEmOrdemDecrescente();

                    //foreach (Categoria c in decrescente)
                    //{
                    //    Console.WriteLine(Convert.ToString(c.Id) + " - " + c.Nome);
                    //}

                    //Console.WriteLine("Fim das listagens Crescente e Decrescente");
                    //Console.WriteLine("-------------------------------------------");

                    #endregion

                    #region PROCURAR CATEGORIA POR NOME
                    //PROCURA CATEGORIA PELO NOME INFORMADO
                    //Console.WriteLine("");
                    //Console.WriteLine("Informe um nome para procurar categorias: ");
                    //var nome = Console.ReadLine();

                    //if(nome != null)
                    //{
                    //    var categoriasPorNome = _repo.ListarPorNome(nome.ToUpper());

                    //    foreach(Categoria c in categoriasPorNome)
                    //    {
                    //        Console.WriteLine(Convert.ToString(c.Id) + " - " + c.Nome);
                    //    }
                    //}

                    //Console.WriteLine("-------------------------------------------");

                    #endregion

                    //var lista2 = cn.ListarCategorias();

                    //foreach (Categoria c in lista2)
                    //{
                    //    Console.WriteLine(Convert.ToString(c.Id) + " - " + c.Nome);
                    //}

                    //Console.WriteLine("-------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro. Mais detalhes: " + ex.Message);
                Console.ReadKey();
            }

            Console.WriteLine("Pressione Enter para finalizar o programa.");
            Console.ReadKey();

        }
    }
}
