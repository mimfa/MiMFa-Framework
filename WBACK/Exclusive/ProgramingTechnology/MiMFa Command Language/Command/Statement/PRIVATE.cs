﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class PRIVATE : CommandBase
    {
        public override string description => "Closed space for operations";
        public override string structure =>
             name
             + " "
             + MCLTools.StartSignCollection
            + " "
             + MCLTools.EndSignCollection
             + MCLTools.SignFinish;
        public override int structureindex => structure.Length -2;

        public PRIVATE() : base()
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
        public override bool IsSwichable { get; set; } = false;
        public override bool IsSSwichable { get; set; } = false;
        public override bool IsCrudeInput { get; set; } = true;
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            MCL.PushAccess(Collection.MiMFa_ProgrammingAccessibility.Private);
            object obj = MCL.Parser(po[0].ToString());
            MCL.PopAccess();
            return obj;
        }
        #endregion
    }
}
