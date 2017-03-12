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

            // Iterate through the attributes for the assembly.
            foreach (Attribute attr in Attribute.GetCustomAttributes(assy))
            {
                var type = attr.GetType();

                // Check for the AssemblyTitle attribute.
                if (type == typeof(AssemblyTitleAttribute))
                    Console.WriteLine("Assembly title is \"{0}\".", ((AssemblyTitleAttribute) attr).Title);

                // Check for the AssemblyDescription attribute.
                else if (type == typeof(AssemblyDescriptionAttribute))
                    Console.WriteLine("Assembly description is \"{0}\".",
                        ((AssemblyDescriptionAttribute) attr).Description);

                // Check for the AssemblyCompany attribute.
                else if (type == typeof(AssemblyCompanyAttribute))
                    Console.WriteLine("Assembly company is {0}.", ((AssemblyCompanyAttribute) attr).Company);

                else if (type == typeof(AssemblyVersionAttribute))
                    Console.WriteLine("Assembly version is {0}.", ((AssemblyVersionAttribute) attr).Version);
                else if (type == typeof(AssemblyFileVersionAttribute))
                    Console.WriteLine("Assembly file version is {0}.", ((AssemblyFileVersionAttribute) attr).Version);
                else if (type == typeof(AssemblyInformationalVersionAttribute))
                    Console.WriteLine("Assembly informational version is {0}.",
                        ((AssemblyInformationalVersionAttribute) attr).InformationalVersion);
            }

            var assemblyName = assy.GetName().Name;
            var gitVersionInformationType = assy.GetType(assemblyName + ".GitVersionInformation");
            var fields = gitVersionInformationType.GetFields();

            foreach (var field in fields)
            {
                Console.WriteLine(string.Format("{0}: {1}", field.Name, field.GetValue(null)));
            }

            Console.WriteLine("Press any key to continue... ");
            Console.ReadLine();
        }
    }
}
