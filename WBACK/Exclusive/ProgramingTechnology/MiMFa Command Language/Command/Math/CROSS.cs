using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.Model;
using MiMFa_Framework.General;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class CROSS : CommandBase
    {
        public override string description => "Find Cross passes values";
        public override string structure =>
            name
            + " "
            + "graph "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public CROSS() : base()
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
        public override bool IsCrudeInput { get; set; } = false;
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD

        public override object EXECUTE(params object[] po)
        {
            if (po != null && po.Length > 0)
                return CrossPasses(po.First());
            return Null;
        }

        public MiMFa_Matrix<double> CrossPasses(dynamic graph)
        {
            int length = graph.Count;
            MiMFa_Matrix<double> path = new MiMFa_Matrix<double>(length,0);

            for (int k = 0; k < length; k++)
                for (int i = 0; i < length; i++)
                    for (int j = 0; j < length; j++)
                        if (i == j 
                            ||(
                            graph[i][k] < INF.inf &&
                            graph[k][j] < INF.inf)
                            || (
                            path[i][k] == 1 &&
                            path[k][j] == 1
                            ))
                            path[i][j] = 1;
            return path;
        }
        #endregion
    }
}
