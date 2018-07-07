using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiMFa_Framework.Exclusive.Animate;

namespace MiMFa_Framework.Component.WinForm.ButtonPack
{
    public partial class SimplyCloseTopBorder : ButtonPack
    {
        public SimplyCloseTopBorder()
        {
            InitializeComponent();
            LABEL = this.l_Title;
            this.Dock = DockStyle.Top;
        }

        #region Private Region

        private void ButtonPack_CloseBorderTop_Load(object sender, EventArgs e)
        {
            FORMMOVE.MainControl = this.ParentForm;
            l_Title.Text = FORMMOVE.MainControl.Text;
        }
        protected override void Exit_Click(object sender, EventArgs e)
        {
            base.Exit_Click(sender, e);
        }
        protected override void WindowsState_Click(object sender, EventArgs e)
        {
            base.WindowsState_Click(sender, e);
        }
        protected override void Minimize_Click(object sender, EventArgs e)
        {
            base.Minimize_Click(sender, e);
        }
        protected override void FormMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (Movable) base.FormMove_MouseDown(sender, e);
        }
        protected override void FormMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (Movable) base.FormMove_MouseMove(sender, e);
        }
        protected override void FormMove_MouseUp(object sender, MouseEventArgs e)
        {
            if (Movable) base.FormMove_MouseUp(sender, e);
        }
        protected override void FormMove_MouseLeave(object sender, EventArgs e)
        {
            if (Movable) base.FormMove_MouseLeave(sender, e);
        }
        protected override void Hilight_MouseEnter(object sender, EventArgs e)
        {
            base.Hilight_MouseEnter(sender, e);
        }
        protected override void Hilight_MouseLeave(object sender, EventArgs e)
        {
            base.Hilight_MouseLeave(sender, e);
        }

        #endregion

    }
}
