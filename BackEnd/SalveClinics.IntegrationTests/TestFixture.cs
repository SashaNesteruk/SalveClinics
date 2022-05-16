using AutoFixture;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalveClinics.Context;
using SalveClinics.Models;
using SalveClinics.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SalveClinics.IntegrationTests
{
    public class TestFixture:IDisposable
    {
        public HttpClient Client { get; }

        public List<Clinic> Clinics;
        public List<Patient> Patients;
        public Fixture Fixture { get; }

        private TestServer _server;

        public TestFixture()
        {
            Fixture = new Fixture();

            _server = new TestServer(new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .ConfigureTestServices(services =>
                {
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                             typeof(DbContextOptions<ApplicationContext>));

                    services.Remove(descriptor);

                    services.AddDbContext<ApplicationContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                        options.EnableSensitiveDataLogging();
                    });

                    var sp = services.BuildServiceProvider();

                    using var scope = sp.CreateScope();
                    var scopedServices = scope.ServiceProvider;
                    var dbContext = scopedServices.GetRequiredService<ApplicationContext>();
                    var repository = scopedServices.GetRequiredService<IClinicRepository>();
                    dbContext.Database.EnsureCreated();
                    dbContext.Clinics.AddRange(DatabaseSeeder.SeedClinics(".//TestFeedData//clinics.csv"));
                    dbContext.Patients.AddRange(DatabaseSeeder.SeedPatients(".//TestFeedData//patients-1.csv"));
                    dbContext.SaveChanges();
                    dbContext.Patients.AddRange(DatabaseSeeder.SeedPatients(".//TestFeedData//patients-2.csv"));
                    dbContext.SaveChanges();
                    Clinics = dbContext.Clinics.ToList();
                    Patients = dbContext.Patients.ToList();
                })
            );

            Client = _server.CreateClient();

        }

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }

    [CollectionDefinition("Clinic collection")]
    public class ClinicCollection : ICollectionFixture<TestFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
