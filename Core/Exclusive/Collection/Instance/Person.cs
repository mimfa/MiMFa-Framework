using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Exclusive.DateAndTime;
using MiMFa_Framework.General;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiMFa_Framework.Exclusive.Collection.Instance
{
    [Serializable]
    public class MiMFa_Person : MiMFa_Instance
    {
        public virtual Image Image { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FatherName { get; set; }
        public virtual MiMFa_Sex Gender { get; set; } = MiMFa_Sex.Null;
        public virtual MiMFa_Date BirthDate { get; set; } = new MiMFa_Date();
        public virtual MiMFa_Marital Marital { get; set; } = MiMFa_Marital.Null;
        public virtual int NumberOfChildren { get; set; } = 0;
        public virtual MiMFa_EducationalDegree EducationalDegree { get; set; }
        public virtual string NID { get; set; }
        public virtual string PID { get; set; }
        public virtual string JobTitle { get; set; }
        public virtual string InsuranceID { get; set; }
        public virtual string MobileNumber { get; set; }
        public virtual string HomePhoneNumber { get; set; }
        public virtual string HomeAddress { get; set; }
        public virtual string OfficePhoneNumber { get; set; }
        public virtual string OfficeAddress { get; set; }
        public virtual string FaxNumber { get; set; }
        public virtual string Email { get; set; }

        public MiMFa_Person(bool incrementID = true) : base(incrementID) { }
    }
}
