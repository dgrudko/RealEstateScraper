using Assessment.Res.App.Actions;
using Assessment.Res.Application.Contracts.Fetchers;
using Assessment.Res.Application.Fetchers;
using Assessment.Res.Core.AgentAnalysis;
using Assessment.Res.Core.Agents;
using Assessment.Res.Core.Contracts.AgentAnalysis;
using Assessment.Res.Core.Contracts.Agents;
using Assessment.Res.Core.Contracts.Funda;
using Assessment.Res.Core.Contracts.Offers;
using Assessment.Res.Core.Contracts.Scraper;
using Assessment.Res.Core.Scraper;
using Assessment.Res.Infrastructure.Database;
using Assessment.Res.Infrastructure.Database.Repositories;
using Assessment.Res.Infrastructure.ThirdPartyApis.Vendors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using System;
using System.IO;
using System.Net.Http;

namespace Assessment.Res.App.Configs
{
    internal class Bootstrapper
    {
        public static ServiceProvider GetServiceProvider()
        {
            var configuration = GetConfiguration();
            
            var services = new ServiceCollection();

            services.AddTransient<ResWindowsService>();
            services.AddTransient<FundaFetcherAction>();


            var retryPolicy = GetRetryPolicy();
            services.AddHttpClient("funda").AddPolicyHandler(retryPolicy);
            services.AddTransient<IFundaConnector, FundaConnector>();
            services.AddTransient<IFundaService, FundaService>();

            services.AddTransient<IAgentAnalysisService, AgentAnalysisService>();
            services.AddTransient<IAgentsService, AgentsService>();
            services.AddTransient<IScraperManager, ScraperManager>(); 

            services.AddTransient<IFundaFetcherUseCase, FundaFetcherUseCase>();

            services.AddDbContext<RealEstateScraperDbContext>();
            services.AddTransient<IAgentsRepository, AgentsRepository>();
            services.AddTransient<IOffersRepository, OffersRepository>();
            services.AddTransient<IAgentAggregatedInfoRepository, AgentAggregatedInfoRepository>();

            services.Configure<FundaApiConfig>(configuration.GetSection("FundaApiConfig"));
            services.AddSingleton(provider =>
            {
                return provider.GetRequiredService<IOptions<FundaApiConfig>>().Value;
            });

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }

        private static IConfigurationRoot GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration;
        }

        private static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return Policy.Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(response => response.IsSuccessStatusCode == false)
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(20)
                });
        }
    }
}
