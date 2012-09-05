using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Facilities;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using Castle.MicroKernel.Registration;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Automapping;
using System.IO;

public class PersistenceFacility : AbstractFacility
{
    protected override void Init()
    {
        var config = BuildDatabaseConfiguration();

        Kernel.Register(
            Component.For<ISessionFactory>()
                .UsingFactoryMethod(_ => config.BuildSessionFactory()),
            Component.For<ISession>()
                .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
                .LifestylePerWebRequest()
            );
    }
    protected virtual IPersistenceConfigurer SetupDatabase()
    {
        //
        //Config for SQLite

        return SQLiteConfiguration.Standard.UsingFile(Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data"), "mvc3.db"));

        //
        //Config for MSSQL

        //return MsSqlConfiguration.MsSql2008
        //    .ConnectionString(x => x.FromConnectionStringWithKey("dbMVC3"))
        //    .ShowSql();
    }

    private Configuration BuildDatabaseConfiguration()
    {
        //
        //Config for SQLite

        return Fluently.Configure()
            .Database(SetupDatabase)
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Person>())
            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
            .BuildConfiguration();

        //
        //Config for MSSQL

        //return Fluently.Configure()
        //   .Database(SetupDatabase)
        //   .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Person>())
        //    /*.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true)) <-- This makes the database new with every restart of application*/
        //   .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
        //   .BuildConfiguration();
    }
}
