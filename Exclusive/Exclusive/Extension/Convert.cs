using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiMFa_Framework.Exclusive.Extension
{
    public class MiMFa_Convert
    {
        public MiMFa_Convert()
        {
            Licenses.ActivateMemoryPatching();
        }

        public void ToPDF(string srcAddress, string destAddress, bool forceOpen = true)
        {
            To(srcAddress,destAddress, Aspose.Words.SaveFormat.Pdf,forceOpen);
        }
        public void ToDoc(string srcAddress, string destAddress, bool forceOpen = true)
        {
            To(srcAddress,destAddress, Aspose.Words.SaveFormat.Doc,forceOpen);
        }
        public void ToDocx(string srcAddress, string destAddress, bool forceOpen = true)
        {
            To(srcAddress,destAddress, Aspose.Words.SaveFormat.Docx,forceOpen);
        }
        public void ToXps(string srcAddress, string destAddress, bool forceOpen = true)
        {
            To(srcAddress,destAddress, Aspose.Words.SaveFormat.Xps,forceOpen);
        }
        public void ToImage(string srcAddress, string destAddress, bool forceOpen = true)
        {
            var ext = System.IO.Path.GetExtension(destAddress).ToLower();
            switch (ext)
            {
                case ".png":
                    To(srcAddress, destAddress, Aspose.Words.SaveFormat.Png, forceOpen);
                    break;
                case ".bmp":
                    To(srcAddress, destAddress, Aspose.Words.SaveFormat.Bmp, forceOpen);
                    break;
                case ".tif":
                case ".tiff":
                    To(srcAddress, destAddress, Aspose.Words.SaveFormat.Tiff, forceOpen);
                    break;
                case ".gif":
                    To(srcAddress, destAddress, Aspose.Words.SaveFormat.Gif, forceOpen);
                    break;
                case ".emf":
                    To(srcAddress, destAddress, Aspose.Words.SaveFormat.Emf, forceOpen);
                    break;
                default:
                    To(srcAddress, destAddress, Aspose.Words.SaveFormat.Jpeg, forceOpen);
                    break;
            }
        }

        public void To(string srcAddress, string destAddress, Aspose.Words.SaveFormat format, bool forceOpen = true)
        {
            if (forceOpen)
            {
                Aspose.Words.Document doc = new Aspose.Words.Document(srcAddress);
                doc.Save(destAddress, format);
                General.MiMFa_Process.Run(destAddress);
            }
            else
            {
                System.Threading.Thread th = new System.Threading.Thread(() =>
                {
                    Aspose.Words.Document doc = new Aspose.Words.Document(srcAddress);
                    doc.Save(destAddress, format);
                });
                th.IsBackground = true;
                th.SetApartmentState(System.Threading.ApartmentState.STA);
                th.Start();
            }
        }

        public static string StringToAtributeName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
