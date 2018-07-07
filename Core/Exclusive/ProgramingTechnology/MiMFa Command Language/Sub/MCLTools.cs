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
using MiMFa_Framework.Exclusive.ProgramingTechnology.Tools;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage
{
    public class MCLTools : MiMFa_ProviderTools
    {
        #region MRL Dictionary 
        public static string StartSignFirstCommandTag { get; } = "#<{";
        public static string StartSignCommandTag { get; } = "#{";
        public static string StartSignLastCommandTag { get; } = "#>{";
        public static string EndSignCommandTag { get; } = "}#";
        public static string StartSignIndex { get; } = "[";
        public static string EndSignIndex { get; } = "]";
        public static string StartSignAllSwitchValue { get; } = StartSignStrong;
        public static string EndSignAllSwitchValue { get; } = EndSignStrong;
        public static string SignCharacterSwitch { get; } = "-";
        public static string SignCharacterSSwitch { get; } = StartSignStrong + SignCharacterSwitch ;
        public static string SignNot { get; } = "!";
        public static string SignTransfer { get; } = ":";
        public static string SignMultiSlice { get; } = ".";
        public static string SignFinish { get; } = ";";
        public static string SignPointer { get; } = "->";
        #endregion

        #region Tools
        #endregion
    }
}
