﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.Model;
using System.IO;
using MiMFa_Framework.General;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class PASTE : CommandBase
    {
        public override string description => "Paste the special stored object by copy command";
        public override string aliasname => "pt";
        public override string structure =>
             name
             + " "
             + "\""
             + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "\\MyFile "+name.ToLower() + ".ext"
             + "\" "
             + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public PASTE() : base()
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
        public override bool IsNotNullInput { get; set; } = false;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            return COPY.source;
        }
        #endregion
    }
}
