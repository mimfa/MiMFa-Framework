using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiMFa_Framework.Component.WinForm.TabPage;
using MiMFa_Framework.Component.WinForm;

namespace MiMFa_Framework.Component.WinForm.ButtonPack
{
    public partial class DefaultSettingButtonPack : ButtonPack
    {
        #region CategoryAttribute
        [CategoryAttribute()]

        public event EventHandler DoneAction;
        public event EventHandler ResetAction;


        public string ApplyText
        {
            get { return btn_Apply.Text; }
            set { btn_Apply.Text = value; }
        }
        public string DoneText
        {
            get { return btn_Done.Text; }
            set { btn_Done.Text = value; }
        }
        public string RefreshText
        {
            get { return btn_Reset.Text; }
            set { btn_Reset.Text = value; }
        }
        public string CancelText
        {
            get { return btn_Cancel.Text; }
            set { btn_Cancel.Text = value; }
        }
        public Color ButtonBackColor
        {
            get { return btn_Done.BackColor; }
            set { btn_Done.BackColor =
                    btn_Apply.BackColor =
                    btn_Reset.BackColor =
                    btn_Cancel.BackColor = value; }
        }
        public Color ButtonForeColor
        {
            get { return btn_Done.ForeColor; }
            set
            {
                btn_Done.ForeColor =
                  btn_Apply.ForeColor =
                  btn_Reset.ForeColor =
                  btn_Cancel.ForeColor = value;
            }
        }
        public FlatStyle ButtonFlatStyle
        {
            get { return btn_Done.FlatStyle; }
            set
            {
                btn_Done.FlatStyle =
                  btn_Apply.FlatStyle =
                  btn_Reset.FlatStyle =
                  btn_Cancel.FlatStyle = value;
            }
        }
        public DefaultSettingButtonPack()
        {
            InitializeComponent();
            btn_Done.Visible = btn_Apply.Visible = DoneAction != null;
            btn_Reset.Visible = ResetAction != null;
            this.Dock = DockStyle.Bottom;
        }
        public bool ShowApply { get; set; } = true;
        public bool ShowDone { get; set; } = true;
        public bool ShowRefresh { get; set; } = true;
        public bool ShowCancel
        {
            get { return btn_Cancel.Visible; }
            set { btn_Cancel.Visible = value; }
        }

        public void SetButtons(EventHandler doneAction = null, EventHandler resetAction = null)
        {
            this.Refresh();
            DoneAction = doneAction;
            ResetAction = resetAction;
            bool ap = DoneAction != null;
            bool re = ResetAction != null;
            btn_Done.Visible = ap && ShowDone;
            btn_Apply.Visible = ap && ShowApply;
            btn_Reset.Visible = re && ShowRefresh;
        }
        public void SetButtons(ButtonAction ba)
        {
            DoneAction = ba.Apply;
            ResetAction = ba.Reset;
            bool ap = DoneAction != null;
            bool re = ResetAction != null;
            btn_Done.Visible = ap && ShowDone;
            btn_Apply.Visible = ap && ShowApply;
            btn_Reset.Visible = re && ShowRefresh;
            Refresh();
        }
        #endregion

        #region Private

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            DoneAction(sender,e);
        }
        private void btn_Done_Click(object sender, EventArgs e)
        {
            btn_Apply_Click(sender, e);
            Exit_Click(sender, e);
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            this.ParentForm.Refresh();
            ResetAction(sender, e);
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
