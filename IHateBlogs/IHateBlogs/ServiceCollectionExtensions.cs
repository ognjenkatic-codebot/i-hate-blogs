﻿using IHateBlogs.Application.Common.Util;

namespace IHateBlogs
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            var openAiConfig = configuration.GetSection("OpenAi").Get<OpenAiConfiguration>() ?? throw new Exception("Could not read OpenAi config");

            services.AddSingleton(openAiConfig);

            return services;
        }
    }
}