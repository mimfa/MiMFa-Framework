﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiMFa_Framework.Exclusive.Animate;
using MiMFa_Framework.Exclusive.Effect;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;

namespace MiMFa_Framework.Component.WinForm.ButtonPack
{
    public partial class StandardTopBorder : ButtonPack
    {
        #region CategoryAttribute
        [CategoryAttribute()]

        public event EventHandler HelpClick = null;

        public string TitleText
        {
            get { return l_Text.Text; }
            set { l_Text.Text = value; }
        }
        public bool ShowIcon
        {
            get
            {
                return pb_Logo.Visible;
            }
            set
            {
                pb_Logo.Visible = value;
            }
        }


        #endregion

        public StandardTopBorder()
        {
            InitializeComponent();
            LABEL = this.ButtonLabel;
            if (!LockState && HelpClick == null) pb_Help.Visible = false;
            else pb_Help.Visible = true;
            this.Dock = DockStyle.Top;
        }

        #region Private Region

        private void StandardTopBorder_Load(object sender, EventArgs e)
        {
            pb_Logo.Image = this.ParentForm.Icon.ToBitmap();
            FORMMOVE.MainControl = this.ParentForm;
            if (!LockState && string.IsNullOrEmpty(ButtonLabel.Text) && this.ParentForm != null)
            {
                ButtonLabel.Font = l_Text.Font;
                ButtonLabel.Text = this.ParentForm.CompanyName + " " + this.ParentForm.ProductName + " v" + this.ParentForm.ProductVersion;
                ButtonLabel.Refresh(); 
            }
            if (!LockState && string.IsNullOrEmpty(l_Text.Text) && this.ParentForm != null) l_Text.Text = this.ParentForm.Text;
        }
        private void pb_Help_Click(object sender, EventArgs e)
        {
            if (HelpClick != null) HelpClick(sender, e);
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
            if (((Control)sender).Name == pb_Exit.Name) p_btn.BackgroundImage = p_Light.BackgroundImage = Properties.Resources.BackRed;
            else p_btn.BackgroundImage = p_Light.BackgroundImage = Properties.Resources.MiMFa_shapH;
        }
        protected override void Hilight_MouseLeave(object sender, EventArgs e)
        {
            base.Hilight_MouseLeave(sender, e);
            p_btn.BackgroundImage = p_Light.BackgroundImage = null;
        }

        #endregion





    }
}
