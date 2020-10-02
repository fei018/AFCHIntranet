using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AFCHIntranet.Models.Services
{
    public class HostEnvHelper
    { 
        public HostEnvHelper(IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            Configuration = configuration;

            HttpContext = contextAccessor.HttpContext;
        }

        public HttpContext HttpContext { get; }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// 获取 appconfig.json 配置文件
        /// </summary>
        public static string AppConfig => Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "AppConfig", "appconfig.json");

        /// <summary>
        /// 数据库链接字符串
        /// </summary>
        public static string ConnectionString => GetConfigValue("ConnectionStrings", "AFCHIntranetDb");

        /// <summary>
        /// 获取 配置文件节点的值
        /// </summary>
        public static string GetConfigValue(string sectionName, string nodeName)
        {
            using var file = File.OpenRead(AppConfig);
            using var json = JsonDocument.Parse(file);
            var element = json.RootElement;
            var value = element.GetProperty(sectionName).GetProperty(nodeName).GetString();
            return value;
        }
    }
}
