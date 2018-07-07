using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage;
using MiMFa_Framework.Exclusive.ProgramingTechnology.NaturalLanguage;
using System.Threading;

namespace MCL_Console
{
    class Program
    {
        static MiMFa_CommandLanguage MCL = new MiMFa_CommandLanguage(MiMFa_Framework.Exclusive.Display.MiMFa_DisplayType.Text);
        //static MiMFa_NaturalLanguage MNL = new MiMFa_NaturalLanguage();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.OpenStandardInput();
            Console.WriteLine("{0} {1} {2}", MCL.Name + " Console User Interfaces", "Version", MCL.Version.ToString());
            string s = "";
            for (;;)
            {
                s = Console.ReadLine();
                s = MCL.Compile(s, "", "", null);
                if (!string.IsNullOrEmpty(s))
                {
                    string[] sa = s.Split(new string[] { MCL.Display.BreakSign }, StringSplitOptions.None);
                    foreach (var item in sa)
                        Console.WriteLine(item);
                }
            }
            //AsyncCallback callback = (a) =>
            //{
            //    string str = a.AsyncState + "";
            //    if(!string.IsNullOrEmpty(str)) Console.WriteLine(str);
            //};
            //WaitHandle waitHandler = new EventWaitHandle(true, EventResetMode.AutoReset);
            //for (;;) MNL.Compile(Console.ReadLine(), callback, waitHandler);
        }
    }
}
