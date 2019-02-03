using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.DAO;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CasaDoCodigo
{ 
    public class Startup
    {
        public Startup(IConfiguration configuration)
        { 
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDistributedMemoryCache();   //adicionar session
            services.AddSession();                  //adicionar session

            string connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<LojaContexto>(options => options.UseSqlServer(connectionString));

            //services.AddTransient<IDataService, DataService>();
            //services.AddTransient<IProdutoRepository, ProdutoRepository>();
            //services.AddTransient<IPedidoRepository, PedidoRepository>();
            //services.AddTransient<ICadastroRepository, CadastroRepository>();
            //services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, LojaContexto lojaContexto)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();   //poem para rodar a session


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pedido}/{action=Carrossel}/{id?}");
            });

        }
    }


}
