using Autofac;
using Autofac.Integration.Mvc;
using BookRepository.Controllers;
using BookRepository.Database;
using BookRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookRepository.Web
{

    public static class AutofacConfig
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Entities.BookRepository>().As<IBookRepository>();
            builder.RegisterType<Entities.GenreRepository>().As<IGenreRepository>();
            builder.RegisterType<BooksController>();
            builder.RegisterType<GenresController>();
            builder.RegisterType<HomeController>();
            builder.RegisterType<BookRepsitoryFromLocalDb>().As<IBookRepositoryDb>();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


    }
}