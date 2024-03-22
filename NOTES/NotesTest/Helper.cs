using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NOTES.Data.Domain;
using NOTES.Repositories.Abstract;
using NOTES.Repositories.Implementation;
using NotesTest.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesTest
{
    public static class Helper
    {
        public static IServiceProvider Provider()
        {
            var services = new ServiceCollection();

            services.AddTransient<INotesCRUDService, NotesCRUDService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            return services.BuildServiceProvider();
        }

        public static T GetRequiredService<T>()
        {
            IServiceProvider provider = Provider();

            return provider.GetRequiredService<T>();
        }
    }
}
