using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AFCHIntranet.Models.Services;
using AFCHIntranet.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.Unicode;
using AFCHIntranet.Models.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace AFCHIntranet
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
            //���� Policy
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("EditAccount", policy => policy.RequireRole(LoginUserRole.Administrator));
                opt.AddPolicy("DeleteElder", policy => policy.RequireRole(LoginUserRole.Administrator, LoginUserRole.PowerUser));
            }).AddAuthentication();

            // ���� Policy
            services.AddRazorPages()
                    .AddRazorPagesOptions(opt =>
                    {
                        opt.Conventions.AuthorizePage("/Index");

                        // ���� /Elder Ȩ��
                        opt.Conventions.AuthorizeFolder("/Elder");
                        // ɾ������ Ȩ��
                        opt.Conventions.AuthorizePage("/Elder/IndexDelete", "DeleteElder");

                        // �༭ ��¼�˻� Ȩ��
                        opt.Conventions.AuthorizeFolder("/Account", "EditAccount");

                        
                    });

            //������֤cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = new PathString("/Login/Index");
                        options.AccessDeniedPath = new PathString("/AccessDenied");
                        options.LogoutPath = new PathString("/Login/Index");
                    });

            services.AddDbContextPool<AFCHIntranetDB>(
                opt =>
                {
                    //opt.UseSqlServer(Configuration.GetConnectionString("AFCHIntranetDb"), b => b.MigrationsAssembly("AFCHIntranet"));
                    opt.UseSqlServer(HostEnvHelper.ConnectionString, b => b.MigrationsAssembly("AFCHIntranet"));
                });

            //���htmlʱ ������ ����, ����
            services.AddSingleton(System.Text.Encodings.Web.HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs }));

            //ע�� HttpContext ������
            services.AddHttpContextAccessor();

            services.AddScoped<ElderService>();
            services.AddScoped<HostEnvHelper>();
            services.AddScoped<LoginService>();
            services.AddScoped<StaffService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //}
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            //�����֤
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
