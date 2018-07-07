using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiMFa_Framework.Model;

namespace MiMFa_Framework.Component.WinForm.Diagram
{
    public partial class Percent : WinForm
    {
        #region CategoryAttribute
        [CategoryAttribute()]

        public event EventHandler ValueChanged;
        private MiMFa_Percent _Value = new MiMFa_Percent();
        public MiMFa_Percent ReallyValue { get; internal set; }
        public MiMFa_Percent Value
        {
            get {
                try
                {
                    return _Value;
                }
                finally
                {
                    Value = _Value;
                }
            }
            set
            {
                ReallyValue = new MiMFa_Percent(value.Negative,value.None, value.Positive);
                _Value = value;
                Change();
                if (ValueChanged != null) ValueChanged(this, EventArgs.Empty);
            }
        }

        #endregion

        public Percent()
        {
            InitializeComponent();
        }
        private void Change()
        {
            if (_Value.Positive > 100) _Value.Positive = 100;
            if (_Value.Negative < -100) _Value.Negative = -100;
            decimal unit = Convert.ToDecimal((p_TrueSide_Exam.Size.Width - 1) / 100d);
            int _fValue = Convert.ToInt32(Math.Ceiling(_Value.Negative * unit));
            int _tValue = Convert.ToInt32(Math.Ceiling(_Value.Positive * unit));

            l_True_Exam.Text = Math.Round(_Value.Positive,3).ToString();
            l_True_Exam.Width = Math.Abs(_tValue);
            l_False_Exam.Text = Math.Round(_Value.Negative, 3).ToString();
            l_False_Exam.Width = Math.Abs(_fValue);

            l_True_Exam.Refresh();
            l_False_Exam.Refresh();
            TOOLTIP.SetToolTip(l_True_Exam, l_True_Exam.Text);
            TOOLTIP.SetToolTip(l_False_Exam, l_False_Exam.Text);
        }
        private void Percent_Resize(object sender, EventArgs e)
        {
            Change();
        }

        #region Private Region

    }
        #endregion
}
