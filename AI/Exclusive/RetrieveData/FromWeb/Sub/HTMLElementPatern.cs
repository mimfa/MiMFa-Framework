using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.General;
using MiMFa_Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Exclusive.RetrieveData.FromWeb
{
    [Serializable]
    public struct HTMLElementPatern
    {
        public MiMFa_Similarity ElementSimilarity { get; set; } 
        public MiMFa_Usage Usage { get; set; }
        public MiMFa_LinkJob LinkJob { get; set; }
        public MiMFa_XMLElementItems ElementItems { get; set; }
        public string DestinationPath { get; set; }
        public string AttributeName { get; set; } 
        public string ChildName { get; set; } 
        public MiMFa_TableValuePositionType TableValuePositionType { get; set; }
        public string ColName { get; set; } 
        public MiMFa_Boolean All { get; set; }
        public MiMFa_XMLElement SampleHTMLElement { get; set; }

        public HTMLElementPatern(HTMLElementPatern patern)
        {
            SampleHTMLElement = patern.SampleHTMLElement;
            ElementSimilarity = patern.ElementSimilarity;
            All = patern.All;
            Usage = patern.Usage;
            LinkJob = patern.LinkJob;
            ElementItems = patern.ElementItems;
            DestinationPath = patern.DestinationPath;
            AttributeName = patern.AttributeName;
            ChildName = patern.ChildName;
            ColName = patern.ColName;
            TableValuePositionType = patern.TableValuePositionType;
        }

        public HTMLElementPatern(
            MiMFa_XMLElement sampleHTMLElement,
            MiMFa_Boolean all = MiMFa_Boolean.False,
            MiMFa_Similarity elementSimilarity = MiMFa_Similarity.Null,
            MiMFa_Usage usage = MiMFa_Usage.Null,
            MiMFa_LinkJob linkJob = MiMFa_LinkJob.Null,
            string destinationPath = "",
            MiMFa_XMLElementItems elementItems = MiMFa_XMLElementItems.Null,
            string childName = "",
            string attrName = "",
            MiMFa_TableValuePositionType tableValuePositionType = MiMFa_TableValuePositionType.Null,
            string colName = null)
        {
            SampleHTMLElement = sampleHTMLElement;
            ElementSimilarity = elementSimilarity;
            All = all;
            Usage = usage;
            LinkJob = linkJob;
            ElementItems = elementItems;
            if(string.IsNullOrEmpty(destinationPath))
                DestinationPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else DestinationPath = destinationPath;
            AttributeName = attrName;
            ChildName = childName;
            ColName = colName;
            TableValuePositionType = tableValuePositionType;
        }
    }
}
