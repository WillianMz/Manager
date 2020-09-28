using Manager.Domain.Entidades;
using Manager.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace Manager.Infra.Data.Repositorios
{
    internal static class Repositorios
    {
        internal static Dictionary<Type, object> Repositories { get; set; }

        //private static readonly ManagerContext manager;

        static Repositorios()
        {
            //Repositories = new Dictionary<Type, object>();
            //Repositories.Add(typeof(Categoria), new RepositorioCategoria(manager));
        }
    }
}
