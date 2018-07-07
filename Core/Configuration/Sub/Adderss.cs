using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Configuration
{
    public class Address : MiMFa_Framework.Config
    {
        public string MSQLPath;
        public string PathTableName = "Path";
        public string UrlTableName = "Url";

        public Address() : base()
        {
        }
        public override void DefaultValues()
        {
            base.DefaultValues();
            MSQLPath = ThisDirectory + @"Configuration.db";
        }
    }
}
