using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GitVersionTest.Integration;
using System.Reflection;
using System.Threading;

//[assembly: AssemblyVersionAttribute("2.0.1")]

namespace GitVersionTest.ConApp
{

    class Program
    {
        static void Main(string[] args)
        {

            var interactor = new Interactor();

            Assembly assy = typeof(Program).Assembly;

            AssemblyName thisAssemName = assy.GetName();
            Version ver = thisAssemName.Version;

            Console.WriteLine("This is version {0} of {1}.\n", ver, thisAssemName.Name);

            // Iterate through the attributes for the assembly.
            foreach (Attribute attr in Attribute.GetCustomAttributes(assy))
            {
                var type = attr.GetType();

                // Check for the AssemblyTitle attribute.
                if (type == typeof(AssemblyTitleAttribute))
                    Console.WriteLine("Title is                : \"{0}\"", ((AssemblyTitleAttribute) attr).Title);
                else if (type == typeof(AssemblyDescriptionAttribute))
                    Console.WriteLine("Description is          : \"{0}\"",
                        ((AssemblyDescriptionAttribute) attr).Description);
                else if (type == typeof(AssemblyCompanyAttribute))
                    Console.WriteLine("Company is              : {0}", ((AssemblyCompanyAttribute) attr).Company);
                else if (type == typeof(AssemblyFileVersionAttribute))
                    Console.WriteLine("File version is         : {0}", ((AssemblyFileVersionAttribute) attr).Version);
                else if (type == typeof(AssemblyInformationalVersionAttribute))
                    Console.WriteLine("Informational version is: {0}",
                        ((AssemblyInformationalVersionAttribute) attr).InformationalVersion);
            }

            Console.WriteLine("");
            Console.WriteLine("*** GitVersionInformations ***");
            try
            {
                var assemblyName = assy.GetName().Name;
                var gitVersionInformationType = assy.GetType(assemblyName + ".GitVersionInformation");
                var fields = gitVersionInformationType.GetFields();
                foreach (var field in fields)
                {
                    Console.WriteLine(string.Format("{0}: {1}", field.Name, field.GetValue(null)));
                }

            }
            catch (Exception)
            {
                Console.WriteLine("FEHLER: GitVersionInformations können nicht gelesen werden.");
            }

            Console.WriteLine("Press any key to continue... ");
            Console.ReadLine();
        }
    }
}


