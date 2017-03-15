using System;
using System.Reflection;
using GitVersionTest.Integration;

// version 6.0.0 -beta

namespace GitVersionTest.ConApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var interactor = new Interactor();
// call Add

// call Mul

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.ToString().StartsWith("GitVersion") == false)
                    continue;

                ShowAsseblyInfos(assembly);
                Console.WriteLine("");
//                ShowGitVersionInformations(assembly);
            }
            Console.WriteLine("Press any key to continue... ");
            Console.ReadLine();
        }

        public static void ShowAsseblyInfos(Assembly assy)
        {
            var thisAssemName = assy.GetName();
            var ver = thisAssemName.Version;

            Console.WriteLine("Assembly name           : {0}", thisAssemName.Name);
            Console.WriteLine("Assembly version        : {0}", ver);

            // Iterate through the attributes for the assembly.
            foreach (var attr in Attribute.GetCustomAttributes(assy))
            {
                var type = attr.GetType();

                // Check for the AssemblyTitle attribute.
                if (type == typeof(AssemblyTitleAttribute))
                    Console.WriteLine("Title is                : {0}", ((AssemblyTitleAttribute) attr).Title);
                else if (type == typeof(AssemblyDescriptionAttribute))
                    Console.WriteLine("Description is          : {0}",
                        ((AssemblyDescriptionAttribute) attr).Description);
                else if (type == typeof(AssemblyCompanyAttribute))
                    Console.WriteLine("Company is              : {0}", ((AssemblyCompanyAttribute) attr).Company);
                else if (type == typeof(AssemblyFileVersionAttribute))
                    Console.WriteLine("File version is         : {0}", ((AssemblyFileVersionAttribute) attr).Version);
                else if (type == typeof(AssemblyInformationalVersionAttribute))
                    Console.WriteLine("Informational version is: {0}",
                        ((AssemblyInformationalVersionAttribute) attr).InformationalVersion);
            }
        }

        public static void ShowGitVersionInformations(Assembly assy)
        {
            Console.WriteLine("*** GitVersionInformations ***");
            try
            {
                var assemblyName = assy.GetName().Name;
                var gitVersionInformationType = assy.GetType(assemblyName + ".GitVersionInformation");
                var fields = gitVersionInformationType.GetFields();
                foreach (var field in fields)
                    Console.WriteLine("{0}: {1}", field.Name, field.GetValue(null));
            }
            catch (Exception)
            {
                Console.WriteLine("FEHLER: GitVersionInformations können nicht gelesen werden.");
            }
        }
    }
}