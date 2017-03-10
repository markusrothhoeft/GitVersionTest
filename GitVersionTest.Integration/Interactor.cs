using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitVersionTest.Logic;

namespace GitVersionTest.Integration
{
    public class Interactor
    {
        public string GetAssemblyInfo()
        {
            var logic = new AssemblyInfoHandler();
            return logic.GetAssemblyVersion();
        }
    }
}
