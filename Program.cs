using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace maxcar_goldtax
{

    class Program
    {
        static readonly Uri _baseUrl = new Uri("http://localhost:8256/");

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]   //找子窗体   
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]   //用于发送信息给窗体   
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        [DllImport("User32.dll", EntryPoint = "ShowWindow")]   //
        private static extern bool ShowWindow(IntPtr hWnd, int type);

        static void Main(string[] args)
        {

            HttpSelfHostServer server = null;
            try
            {
                // 配置一个自宿主 http 服务
                HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(_baseUrl);

                // 配置 http 服务的路由
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

                config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

                // 创建 http 服务
                server = new HttpSelfHostServer(config);

                // 开始监听
                server.OpenAsync().Wait();

                // 停止监听
                // server.CloseAsync().Wait(); 

                Console.Title = "隐藏控制台";
                IntPtr ParenthWnd = new IntPtr(0);
                ParenthWnd = FindWindow(null, "隐藏控制台");
                //隐藏本dos窗体, 0: 后台执行；1:正常启动；2:最小化到任务栏；3:最大化
                ShowWindow(ParenthWnd, 0);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
    }
}
