using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Service;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.Tools.Pickup
{
    public class MiMFa_StrongParenthesisPickup : MiMFa_Pickup
    {
        public MiMFa_StrongParenthesisPickup() : base(
            "" + "STRPRNTS" + ""/*(Alt + 900) text (Alt + 900)*/
            , StartSignStrongParenthesis
            , EndSignStrongParenthesis
            , true)
        { }    
    }
}
