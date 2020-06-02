using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.CQRS.AutoMapper;
using BookStore.CQRS.Bus;
using BookStore.CQRS.CommandHandler;
using BookStore.CQRS.Commands;
using BookStore.CQRS.EntityFramework.Books;
using BookStore.CQRS.Events;
using BookStore.CQRS.Notifications;
using BookStore.CQRS.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation;
using FluentValidation.AspNetCore;
using BookStore.CQRS.ViewModel.FluentValidationConfig;

namespace BookStore.CQRS.WebHost
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
            services.AddDbContext<BookContext>(options =>
            {
                options.UseInMemoryDatabase("bookContext");
            });

            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddMediatR(typeof(Startup));
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<IBookAppService, BookAppService>();
            services.AddScoped<DbContext, BookContext>();

            #region �ɿ���ҵ���߼�ƥ�䣬һ�������һ�������ߡ�
            services.AddScoped<IRequestHandler<AddBookCommand, bool>, BookCommandHandler>();
            #endregion
            #region �¼�
            services.AddScoped<INotificationHandler<AddBookEvent>, AddBookEventHandler>();
            #endregion

            #region ֪ͨ��
            services.AddScoped<INotificationHandler<Notification>, NotificationHandler>();
            #endregion
            services.AddControllersWithViews();

            #region ��֤��
            services.AddControllers()
                    .ConfigureApiBehaviorOptions(setup =>
                    {
                        setup.InvalidModelStateResponseFactory = context =>
                        {
                            var problemDetails = new ValidationProblemDetails(context.ModelState)
                            {
                                Type = "http://www.baidu.com",
                                Title = "���ݷ�����",
                                Status = StatusCodes.Status422UnprocessableEntity,
                                Detail = "��鿴��ص��ĵ�",
                                Instance = context.HttpContext.Request.Path
                            };

                            problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);
                            return new UnprocessableEntityObjectResult(problemDetails)
                            {
                                ContentTypes = { MediaTypeNames.Application.Json }
                            };
                        };
                    })
                    .AddFluentValidation(config =>
                    {
                        config.RegisterValidatorsFromAssembly(typeof(AutoMapperConfig).Assembly);

                        // �����֤��
                        config.RunDefaultMvcValidationAfterFluentValidationExecutes = true;
                    });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
