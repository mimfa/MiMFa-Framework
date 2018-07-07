using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiMFa_Framework.Exclusive.Animate;
using MiMFa_Framework.General;

namespace MiMFa_Framework.Component.WinForm.ButtonPack
{
   public class ButtonPack : WinForm
    {
        #region Field

        protected Label LABEL = new Label();

        #endregion

        #region Property
        [CategoryAttribute()]
        public virtual bool Movable { get; set; } = true;
        public virtual string Title
        {
            get { return LABEL.Text; }
            set { LABEL.Text = value; }
        }

        #endregion 
        
        #region Function



        #endregion

        #region Target

        protected virtual void Exit_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        protected virtual void WindowsState_Click(object sender, EventArgs e)
        {
            MiMFa_ButtonAction.WindowsState(this.ParentForm);
        }
        protected virtual void Minimize_Click(object sender, EventArgs e)
        {
            MiMFa_ButtonAction.Minimize(this.ParentForm);
        }

        #endregion 

    }
}
