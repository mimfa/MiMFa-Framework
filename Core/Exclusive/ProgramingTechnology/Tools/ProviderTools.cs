using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using MiMFa_Framework.Exclusive.DateAndTime;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Exclusive.ProgramingTechnology.Tools.Pickup;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.Tools
{
    public class MiMFa_ProviderTools
    {
        #region Sign
        public static string StartSignStrong => "$";
        public static string EndSignStrong => "$";
        public static char SplitSign { get; } = ',';
        public static string StartSignCollection { get; } = "{";
        public static string EndSignCollection { get; } = "}";
        public static string StartSignParenthesis { get; } = "(";
        public static string EndSignParenthesis { get; } = ")";
        public static string StartSignStrongCollection { get; } = StartSignStrong + StartSignCollection;
        public static string EndSignStrongCollection { get; } = EndSignCollection + EndSignStrong;
        public static string StartSignStrongParenthesis { get; } = StartSignStrong + StartSignParenthesis;
        public static string EndSignStrongParenthesis { get; } = EndSignParenthesis + EndSignStrong;
        public static string StartSignString { get; } = '"'.ToString();
        public static string EndSignString { get; } = '"'.ToString();
        public static string StartSignStrongString { get; } = StartSignStrong + StartSignString;
        public static string EndSignStrongString { get; } = EndSignString + EndSignStrong;
        public static string StartSignComment { get; } = "/<";
        public static string EndSignComment { get; } = ">/";
        #endregion

        #region Tools
        public static MiMFa_StrongParenthesisPickup StrongParenthesisPU { get; } = new MiMFa_StrongParenthesisPickup();
        public static MiMFa_ParenthesisPickup ParenthesisPU { get; } = new MiMFa_ParenthesisPickup();
        public static MiMFa_StrongCollectionPickup StrongCollectionPU { get; } = new MiMFa_StrongCollectionPickup();
        public static MiMFa_CollectionPickup CollectionPU { get; } = new MiMFa_CollectionPickup();
        public static MiMFa_StrongStringPickup StrongStringPU { get; } = new MiMFa_StrongStringPickup();
        public static MiMFa_StringPickup StringPU { get; } = new MiMFa_StringPickup();
        public static MiMFa_CommentProvider CommentPU { get; } = new MiMFa_CommentProvider();
        #endregion

        public static string Normalization(string code, bool withpickup = false)
        {
            if (code == null) return null;
            code = code.Replace('\t', ' ')
                .Replace('\n', ' ')
                .Replace('\r', ' ');
            if (withpickup)
            {
                code = CommentPU.Replace(code, "");
                code = StrongStringPU.RePick(code);
                code = StringPU.RePick(code);
                code = StrongParenthesisPU.RePick(code);
                code = ParenthesisPU.RePick(code);
                code = StrongCollectionPU.RePick(code);
                code = CollectionPU.RePick(code);
            }
            return code;
        }

    }
}
