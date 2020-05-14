using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SBAdmin.Core;
using SBAdmin.Core.Models;
using SBAdmin.Core.Services;
using SBAdmin.Data;
using SBAdmin.Services.Services;

namespace SBAdmin.Api
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
            services.AddControllers();


            services.AddDbContext<HRDbContext>();

            //services.AddDbContext<HRDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("HRDBConnection"));
            //});

            services.AddTransient<HRDbContext>();
            //services.AddTransient<IRepository<ClientData>, ClientRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            //CreateInitialDatabase();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static void CreateInitialDatabase()
        {
            using (var context = new HRDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Create the initial Data
                Guid id = Guid.Parse("d9742d91-dc17-4be7-a715-55cc9d231c55");
                Employee emp = new Employee()
                {
                    EmployeeID = id,
                    EmployeeName = "Mohamed Taha",
                    Birthdate = new DateTime(1982, 6, 1),
                    HiringDate = new DateTime(2010, 6, 1),
                    Gender = true,
                    Mobile = "66130236",
                    ProfilePicture = id.ToString() + ".jpg",
                    Email = "mtaha@pp.gov.qa",
                    EmployeeAddress = new List<EmployeeAddress>() { 
                    new EmployeeAddress() {
                        EmployeeID = id,
                        RecordID = Guid.NewGuid(),
                        AddressLine1 = "Bin Dinar st.",
                        AddressLine2 = "Building # 11",
                        City = "Al-Sadd",
                        CountryID = "QA",
                        ContactName = "Mohamed Taha" },
                    new EmployeeAddress() {
                        EmployeeID = id,
                        RecordID = Guid.NewGuid(),
                        AddressLine1 = "Ain Khaled",
                        AddressLine2 = "Building # 7",
                        City = "Doha",
                        CountryID = "QA",
                        ContactName = "Mohamed Taha"} }
                };

                //var repo = new EmployeeRepository(context);
                //repo.Add(emp);
                context.Employee.Add(emp);

                Department dep = new Department() { DepartmentID = Guid.NewGuid(), DepartmentName = "IT department" };
                context.Department.Add(dep);


                context.SaveChanges();

            }
        }
    }
}