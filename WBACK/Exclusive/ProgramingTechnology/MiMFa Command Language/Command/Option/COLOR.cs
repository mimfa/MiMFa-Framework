using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using System.Windows.Forms;
using System.Drawing;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class COLOR : CommandBase
    {
        public override string description => "Change screen colors";
        public override string structure =>
            name
            + " "
            + "foreColor "
            + MCLTools.SplitSign
            + "backColor "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public COLOR() : base()
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
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            echo(po);
            if (_print)
                if (MCL.UserInterface != null)
                    try
                    {
                        Control con = (Control)MCL.UserInterface;
                        return print(new object[] { con.ForeColor, con.BackColor });
                    }
                    catch { }
                else
                {
                    return print(new object[] { Console.ForegroundColor, Console.BackgroundColor });
                }
            return Null;
        }

        public override object execute(object obj,int index, int length)
        {
            switch (index)
            {
                case 0:
                    if (MCL.UserInterface != null)
                        ((Control)MCL.UserInterface).ForeColor = Color.FromName(obj.ToString());
                    else
                        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), obj.ToString(), true);
                    break;
                case 1:
                    if (MCL.UserInterface != null)
                        ((Control)MCL.UserInterface).BackColor = Color.FromName(obj.ToString());
                    else
                        Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), obj.ToString(), true);
                    break;
            }
            return Null;
        }
        #endregion
    }
}
