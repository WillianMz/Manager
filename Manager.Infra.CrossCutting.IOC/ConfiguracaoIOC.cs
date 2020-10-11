using Autofac;
using AutoMapper;
using Manager.Application.AutoMapper;

namespace Manager.Infra.CrossCutting.IOC
{
    public class ConfiguracaoIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.Register(conf => new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProfile());
            }));

            #endregion
        }
    }
}
