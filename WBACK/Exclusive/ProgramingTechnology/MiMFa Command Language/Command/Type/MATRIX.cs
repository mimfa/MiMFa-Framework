using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.Model;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class MATRIX : CommandBase
    {
        public override string description => "Create a matrix from datas";
        public override string structure =>
            name
            + " "
            + "row1 "
            + MCLTools.SplitSign
            + "row2 "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public MATRIX() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _sorted = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool S
        {
            get { return _sorted; }
            set
            {
                //if (_)  = value;
                //else
                _sorted = value;
            }
        }
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
        public override bool IsCrudeInput { get; set; } = false;
        public override bool IsNotNullInput { get; set; } = false;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            MiMFa_Matrix<object> lo = new MiMFa_Matrix<object>();
            if (po != null)
            {
                for (int i = 0; i < po.Length; i++)
                    if (po[i] == null) lo.Add(new MiMFa_List<object>());
                    else if (po[i] is MiMFa_List<object>) lo.Add((MiMFa_List<object>)po[i]);
                    else if (po[i].GetType().Name.EndsWith("[]")) lo.AddRow((object[])po[i]);
                    else lo.AddRow(po[i]);
            }
            if (_sorted) lo.Sort();
            return lo;
        }

        #endregion
    }
}
