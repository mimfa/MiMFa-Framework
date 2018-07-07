using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiMFa_Framework.Network;

namespace MiMFa_Framework.Component.WinForm.Browser
{
    public class Browser : WinForm
    {
        #region Field

        private Uri _URL = new Uri(Config.Url);

        #endregion

        #region Property
        [CategoryAttribute()]
        
        public virtual Uri URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        #endregion

        #region Function



        #endregion

        #region Target



        #endregion
    }
}
