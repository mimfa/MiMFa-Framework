using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.DecisionMachine
{
    public interface ISolver
    {
        string Name { get; }
        int Priority { get; set; }

        Inference Solver(object p, object[] conditions);
    }
}