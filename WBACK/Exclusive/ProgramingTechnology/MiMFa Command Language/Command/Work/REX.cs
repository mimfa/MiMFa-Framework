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
    public class REX : CommandBase
    {
        public override string description => "Work with Regular Expressions";
        public override string aliasname => "regularx";
        public override string structure =>
            name
            + " "
            + "text "
            + MCLTools.SplitSign
            + "patern "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 7;

        public REX() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _escape = false;
        public bool _ismatch = false;
        public bool _match = false;
        public bool _matches = false;
        public bool _replace = false;
        public bool _split = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool E
        {
            get { return _escape; }
            set
            {
                _escape = value;
            }
        }
        public virtual bool I
        {
            get { return _ismatch; }
            set
            {
                    _ismatch = value;
            }
        }
        public virtual bool M
        {
            get { return _match; }
            set
            {
                if (_) _matches = value;
                else
                    _match = value;
            }
        }
        public virtual bool R
        {
            get { return _replace; }
            set
            {
                    _replace = value;
            }
        }
        public virtual bool S
        {
            get { return _split; }
            set
            {
                _split = value;
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
            if (po == null) return Null;
            string inp = "", pat = "", repment = "";
            System.Text.RegularExpressions.RegexOptions ro = System.Text.RegularExpressions.RegexOptions.None;
            TimeSpan ts = new TimeSpan();
            int i = 0;
            if (po.Length > i) inp = po[i++] + "";
            if (po.Length > i) pat = po[i++] + "";
            if (_replace && po.Length > i) pat = po[i++] + "";
            if (po.Length > i) try { ro = (System.Text.RegularExpressions.RegexOptions)Enum.Parse(typeof(System.Text.RegularExpressions.RegexOptions), po[i++] + ""); } catch { }
            if (po.Length > i) try { ts = new TimeSpan(Convert.ToInt64(po[i++] + "")); } catch { }
            if (_match)
                if (!string.IsNullOrEmpty(pat) && ro != System.Text.RegularExpressions.RegexOptions.None)
                    return System.Text.RegularExpressions.Regex.Match(inp, pat, ro, ts);
                else return System.Text.RegularExpressions.Regex.Match(inp, pat);
            if(_matches)
                if (!string.IsNullOrEmpty(pat) && ro != System.Text.RegularExpressions.RegexOptions.None)
                    return System.Text.RegularExpressions.Regex.Matches(inp, pat, ro, ts);
                else return System.Text.RegularExpressions.Regex.Matches(inp, pat);
            if (_ismatch)
                if (!string.IsNullOrEmpty(pat) && ro != System.Text.RegularExpressions.RegexOptions.None)
                    return System.Text.RegularExpressions.Regex.IsMatch(inp, pat, ro, ts);
                else return System.Text.RegularExpressions.Regex.IsMatch(inp, pat);
            if (_escape)
                    return System.Text.RegularExpressions.Regex.Escape(inp);
            if (_replace)
                if (ro != System.Text.RegularExpressions.RegexOptions.None)
                    return System.Text.RegularExpressions.Regex.Replace(inp, pat, repment, ro, ts);
                else return System.Text.RegularExpressions.Regex.Replace(inp, pat, repment);
            if (_split)
                if (ro != System.Text.RegularExpressions.RegexOptions.None)
                    return System.Text.RegularExpressions.Regex.Split(inp, pat, ro, ts);
                else return System.Text.RegularExpressions.Regex.Split(inp, pat);
            return new System.Text.RegularExpressions.Regex(pat, ro, ts);
        }

        #endregion
    }
}
