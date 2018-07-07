using System;
using System.Collections.Generic;
using MiMFa_Framework.Exclusive.DateAndTime;
using System.Drawing;

namespace MiMFa_Framework.Exclusive.Collection.Instance
{
    [Serializable]
    public class MiMFa_Book : MiMFa_Instance
    {
        public virtual string Subject { get; set; }
        public virtual List<MiMFa_Person> AuthorPersons { get; set; } = new List<MiMFa_Person>();
        public virtual string Comment { get; set; }
        public virtual Image Image { get; set; }
        public virtual string Publisher { get; set; }
        public virtual MiMFa_Date PublishDate { get; set; } = new MiMFa_Date();
        public virtual decimal Edition { get; set; } = 1;
        public virtual decimal Cover { get; set; } = 1;
        public virtual decimal NumberOfCover { get; set; } = 1;
        public virtual decimal NumberOfSection { get; set; }
        public virtual decimal NumberOfPage { get; set; }
        public virtual string ISBN { get; set; }
        public virtual decimal Price { get; set; }

        public virtual object File { get; set; }
        public virtual string Path { get; set; }

        public MiMFa_Book(bool incrementID = true) : base(incrementID) { }
    }
}
