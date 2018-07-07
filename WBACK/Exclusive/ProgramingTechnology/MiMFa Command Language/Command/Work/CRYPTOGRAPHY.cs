using System;
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
    public class CRYPTOGRAPHY : CommandBase
    {
        public override string description => "Encrypt and decrypt all cases";
        public override string aliasname => "crypt";
        public override string structure =>
                name
                + " "
                + "\"MethodName\" "
                + MCLTools.SplitSign
                + "\"Key\" "
                + MCLTools.SplitSign
                + "\"PlainText\" "
                + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 3;

        public CRYPTOGRAPHY() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _decrypt = false;
        public bool _encrypt = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool D
        {
            get { return _decrypt; }
            set
            {
                //if (_)  = value;
                //else
                _decrypt = value;
            }
        }
        public virtual bool E
        {
            get { return _encrypt; }
            set
            {
                //if (_)  = value;
                //else
                _encrypt = value;
            }
        }
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
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public static string method { get; set; }
        public static string key { get; set; }
        public static int d { get; set; } = 0;
        public static int n { get; set; } = 0;

        public override object EXECUTE(params object[] po)
        {
            if (po != null)
                if (po.Length == 1) return cryp.GetHashString(po[0] + "");
                else return echo(po);
            return po;
        }

        private static Security.MiMFa_Cryptography cryp = new Security.MiMFa_Cryptography();
        public override object execute(object obj, int index, int length)
        {
            if (method == "rsa" && index == 1)
                d = Convert.ToInt32(obj);
            else if (method == "rsa" && index == 2)
                n = Convert.ToInt32(obj);
            else if (index == 0)
                method = (obj + "").Trim().ToLower();
            else if (index == 1&& length > 2)
                key = (obj + "").Trim().ToLower();
            else switch (method)
                {
                    case "caesar":
                        if (_decrypt && !_encrypt) return cryp.CaesarCiphertoPlain(obj + "", int.Parse(key));
                        else return cryp.CaesarPlaintoCipher(obj + "", int.Parse(key));
                    case "ecb":
                        if (_decrypt && !_encrypt) return cryp.ECBCiphertoPlain(obj + "", key);
                        else return cryp.ECBPlaintoCipher(obj + "", key);
                    case "mcbac":
                        if (_decrypt && !_encrypt) return cryp.MCBACCiphertoPlain(obj + "", int.Parse(key));
                        else return cryp.MCBACPlaintoCipher(obj + "", int.Parse(key));
                    case "rsa":
                        if (_decrypt && !_encrypt)
                            return cryp.RSACiphertoPlain(Convert.ToInt32(obj), d, n);
                        else
                        {
                            if (d == 0)
                            {
                                int[] rsa = cryp.RSAGetKeys();
                                return new object[]{"e = " + rsa[0] + ", d = " + rsa[1] + ", n = " + rsa[2] , cryp.RSAPlaintoCipher(Convert.ToInt32(obj), rsa[0], rsa[2])};
                            }
                            else return cryp.RSAPlaintoCipher(Convert.ToInt32(obj), d, n);
                        }
                    case "nta":
                        return MiMFa_Convert.ToAlphabet(Convert.ToInt32(obj));
                }
                
            return Null;
        }

        #endregion
    }
}
