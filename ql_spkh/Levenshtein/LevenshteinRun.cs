using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Autofac;

namespace ql_spkh.Levenshtein
{
    [ExcludeFromCodeCoverage]
    public static class LevenshteinRun
    {
        private static IContainer Container()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UnicodeNormalizer>().As<IUnicodeNormalizer>();
            builder.RegisterType<Levenshtein>().As<ILevenshtein>();
            return builder.Build();
        }
        public static string timeRun = "";
        public static string run(string chuoi1, string chuoi2)
        {
            try
            {
                var levenshtein = Container().Resolve<ILevenshtein>();

                var startTime = DateTime.Now;
                var percentage = levenshtein.Distance(chuoi1, chuoi2);
                var stopTime = DateTime.Now;
                var duration = stopTime - startTime;

                string rs = percentage.ToString(); timeRun =  duration.ToString();

                return rs;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
