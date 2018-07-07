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
    public class FSP : CommandBase
    {
        public override string description => "Find shortest paths values";
        public override string structure =>
            name
            + " "
            + "graph "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public FSP() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _distance = false;
        public bool _path = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool D
        {
            get { return _distance; }
            set {
                //if (_) _event = value;
                //else
                _distance = value;
            }
        }
        public virtual bool P
        {
            get { return _path; }
            set {
                //if (_) _event = value;
                //else
                    _path = value;
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
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD

        public override object EXECUTE(params object[] po)
        {
            if (po != null && po.Length > 0)
            {
                MiMFa_Matrix<double>[] res = FloydWarshall(po.First());
                if ((_distance && _path) || (d && p)) return res;
                if (_distance || d) return res[0];
                if (_path ||  p) return res[1];
                return res;
            }
            return Null;
        }

        public MiMFa_Matrix<double>[] FloydWarshall(dynamic graph)
        {
            int length = graph.Count;
            MiMFa_Matrix<double> dist = new MiMFa_Matrix<double>(length,0);
            MiMFa_Matrix<double> path = new MiMFa_Matrix<double>(length,0);

            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    if (i == j)
                    {
                        path[i][j] = INF.inf;
                        dist[i][j] = 0;
                    }
                    else if (graph[i][j] == 0
                         || graph[i][j] >= INF.inf
                         || graph[i][j] <= -INF.inf)
                    {
                        path[i][j] = INF.inf;
                        dist[i][j] = INF.inf;
                    }
                    else
                    {
                        path[i][j] = i + 1;
                        dist[i][j] = graph[i][j];
                    }
            double n = INF.inf;
            for (int k = 0; k < length; k++)
                for (int i = 0; i < length; i++)
                    for (int j = 0; j < length; j++)
                        if (i != j && dist[i][j] > (n = dist[i][k] + dist[k][j]))
                        {
                            dist[i][j] = n;
                            path[i][j] = k + 1;
                        }
            return new MiMFa_Matrix<double>[] { dist, path};
        }
        #endregion
    }
}
