using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using System.Data;
using MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class HELP : CommandBase
    {
        public override string description => "Show all command help and guide";
        public override string aliasname => "doc";
        public override string structure =>
            name
            + " "
            + "command "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;
        public HELP() : base()
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
        public override bool IsSurface { get; set; } = false;
        public override bool IsApplication { get; set; } = false;
        public override bool IsStatic { get; set; } = false;
        public override bool IsSwichable { get; set; } = true;
        public override bool IsSSwichable { get; set; } = true;
        public override bool IsCrudeInput { get; set; } = true;
        public override bool IsNotNullInput { get; set; } = false;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            if (po.Length == 0 || po[0].ToString() == "") return all();
            return echo(po);
        }
        public override object execute(object obj, int index, int length)
        {
            if (obj == null) return Null;
            CommandBase ac = MCL.GetCommand(obj.ToString());
            if (ac == null) return Null;
            return ac.help();
        }
        public virtual object all()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Command"));
            dt.Columns.Add(new DataColumn("Descriptions"));
            dt.Columns.Add(new DataColumn("HelpLink",typeof(EventPack)));
           var cd =  Get.CommandsList();
            foreach (var item in cd)
                dt.Rows.Add(item.name + " / " + item.aliasname,
                    item.description + ".\t Structure: " + item.structure,
                    new EventPack()
                    {
                        Before = "",
                        Name = "data-click",
                        Target = "HELP " + item.name,
                        After = "",
                    });
            return dt;
        }
        #endregion
    }
}
