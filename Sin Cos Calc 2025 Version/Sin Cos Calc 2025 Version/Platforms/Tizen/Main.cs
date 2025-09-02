using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Sin_Cos_Calc_2025_Version
{
    internal class Program : MauiApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
