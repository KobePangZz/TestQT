﻿using System;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.Config
{
    /// <summary>
    /// 配置跨域（CORS）
    /// </summary>
    public static class CorsSetup
    {
        public static void AddCorsSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddCors(c =>
            {
                if (!AppSettingsConstVars.CorsEnableAllIPs)
                {
                    c.AddPolicy(AppSettingsConstVars.CorsPolicyName, policy =>
                        {
                            policy.WithOrigins(AppSettingsConstVars.CorsIPs.Split(','));
                            policy.AllowAnyHeader();//Ensures that the policy allows any header.
                            policy.AllowAnyMethod();
                            policy.AllowCredentials();
                        });
                }
                else
                {
                    //允许任意跨域请求
                    c.AddPolicy(AppSettingsConstVars.CorsPolicyName, policy =>
                        {
                            policy.SetIsOriginAllowed((host) => true)
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials();
                        });
                }
            });
        }
    }
}
