using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using System.Windows.Forms;
using System.Windows.Documents;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class CLEAN : CommandBase
    {
        public override string description => "Clear screen";
        public override string aliasname => "cls";
        public CLEAN() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        #endregion

        #region Environment Variable => PROPERTY (Any Type & get;)
        #endregion

        #region Allowances
        public override bool IsInternal { get; set; } = true;
        public override bool IsCommand { get; set; } = true;
        public override bool IsSurface { get; set; } = true;
        public override bool IsApplication { get; set; } = false;
        public override bool IsStatic { get; set; } = false;
        public override bool IsSwichable { get; set; } = true;
        public override bool IsSSwichable { get; set; } = true;
        public override bool IsCrudeInput { get; set; } = false;
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = false;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            if (MCL.UserInterface != null)
            {
                if (MCL.UserInterface is WebBrowser) ((WebBrowser)MCL.UserInterface).DocumentText = "";
                else if (MCL.UserInterface is TextBox) ((TextBox)MCL.UserInterface).Clear();
                else if (MCL.UserInterface is RichTextBox) ((RichTextBox)MCL.UserInterface).Clear();
                else if (MCL.UserInterface is Control) ((Control)MCL.UserInterface).Text = "";
                else if (MCL.UserInterface is System.Windows.Controls.WebBrowser)
                {
                    var bbb = new WPF.Service.WebBrowserService();
                    bbb.Clear(MCL.UserInterface);
                }
                else if (MCL.UserInterface is System.Windows.Controls.TextBox) ((System.Windows.Controls.TextBox)MCL.UserInterface).Clear();
                else if (MCL.UserInterface is System.Windows.Controls.RichTextBox)
                {
                    var rrr = new WPF.Service.RichTextBoxService();
                    var rtb = (System.Windows.Controls.RichTextBox)MCL.UserInterface;
                    rrr.Clear(ref rtb);
                }
            }
            else Console.Clear();
            return Null;
        }

        public override object execute(object obj,int index, int length)
        {
            return Null;
        }
        #endregion
    }
}
