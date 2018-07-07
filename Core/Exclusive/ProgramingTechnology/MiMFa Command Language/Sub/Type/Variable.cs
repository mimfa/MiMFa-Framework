using MiMFa_Framework.Exclusive.Collection;
using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage
{
    [Serializable]
    public class Variable
    {
        public Accessibility Access = new Accessibility();
        public string Name;
        public dynamic Value = null;

        public override string ToString()
        {
            return Name + " = " + Value + "";
        }
    }
}
