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
    public partial class DefaultPartTakingButtonPack : ButtonPack
    {
        #region CategoryAttribute
        [CategoryAttribute()]

        public event EventHandler NextAction;
        public event EventHandler BackAction;
        public event EventHandler MenuAction;
        public event EventHandler DoneAction;
        public event EventHandler ResetAction;

        public string NextText
        {
            get { return btn_Next.Text; }
            set { btn_Next.Text = value; }
        }
        public string BackText
        {
            get { return btn_Back.Text; }
            set { btn_Back.Text = value; }
        }
        public string MenuText
        {
            get { return btn_Menu.Text; }
            set { btn_Menu.Text = value; }
        }
        public string DoneText
        {
            get { return btn_Done.Text; }
            set { btn_Done.Text = value; }
        }
        public string ReFreshText
        {
            get { return btn_Reset.Text; }
            set { btn_Reset.Text = value; }
        }
        public Color ButtonBackColor
        {
            get { return btn_Done.BackColor; }
            set
            {
                btn_Done.BackColor =
                  btn_Menu.BackColor =
                  btn_Reset.BackColor =
                  btn_Back.BackColor  = 
                  btn_Next.BackColor = value;
            }
        }
        public Color ButtonForeColor
        {
            get { return btn_Done.ForeColor; }
            set
            {
                btn_Done.ForeColor =
                  btn_Menu.ForeColor =
                  btn_Reset.ForeColor =
                  btn_Back.ForeColor =
                  btn_Next.ForeColor = value;
            }
        }
        public FlatStyle ButtonFlatStyle
        {
            get { return btn_Done.FlatStyle; }
            set
            {
                btn_Done.FlatStyle =
         btn_Menu.FlatStyle =
                  btn_Reset.FlatStyle =
                  btn_Back.FlatStyle =
                  btn_Next.FlatStyle = value;
            }
        }

        #endregion

        public DefaultPartTakingButtonPack()
        {
            InitializeComponent();
            Refresh();
        }

        public override void Refresh()
        {
            btn_Next.Visible = NextAction != null;
            btn_Back.Visible = BackAction != null;
            btn_Menu.Visible = MenuAction != null;
            btn_Done.Visible = DoneAction != null;
            btn_Reset.Visible = ResetAction != null;
            base.Refresh();
        }
        public void SetButtons(EventHandler nextAction = null, EventHandler backAction = null, EventHandler doneAction = null, EventHandler resetAction = null, EventHandler menuAction = null)
        {
            NextAction = nextAction;
            BackAction = backAction;
            DoneAction = doneAction;
            ResetAction = resetAction;
            MenuAction = menuAction;
            Refresh();
        }
        public void SetButtons(ButtonAction ba)
        {
            SetButtons(ba.Next, ba.Back, ba.Apply, ba.Reset, ba.Menu);
        }

        #region Private

        private void btn_Done_Click(object sender, EventArgs e)
        {
            DoneAction(sender,e);
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            this.ParentForm.Refresh();
            ResetAction(sender, e);
        }
        private void btn_Menu_Click(object sender, EventArgs e)
        {
            MenuAction(sender, e);
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            BackAction(sender, e);
        }
        private void btn_Next_Click(object sender, EventArgs e)
        {
            NextAction(sender, e);
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
           if(Movable) base.FormMove_MouseDown(sender, e);
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
