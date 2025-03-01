// Copyright 2020 New Relic, Inc. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics;
using System.IO;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MemcachedTestApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSingleton<IBlogPostService, BlogPostService>();
            builder.Services.AddEnyimMemcached(options => options.AddServer("memcached-server", 11211));

            // listen to any ip on port 80 for http
            IPEndPoint ipEndPointHttp = new IPEndPoint(IPAddress.Any, 80);
            builder.WebHost.UseUrls($"http://{ipEndPointHttp}");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseAuthorization();
            app.MapControllers();

            await app.StartAsync();

            CreatePidFile();

            await app.WaitForShutdownAsync();
        }

        public static void CreatePidFile()
        {
            var pidFileNameAndPath = Path.Combine(Environment.GetEnvironmentVariable("NEW_RELIC_LOG_DIRECTORY"), "containerizedapp.pid");
            var pid = Environment.ProcessId;
            using var file = File.CreateText(pidFileNameAndPath);
            file.WriteLine(pid);
        }
    }
}
