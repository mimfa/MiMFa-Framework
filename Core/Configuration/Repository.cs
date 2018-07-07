using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage;
using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Exclusive.ProgramingTechnology.DataBase;

namespace MiMFa_Framework.Configuration
{
    public class Repository
    {
        private MiMFa_SQLite MSQL = new MiMFa_SQLite();
        public Address Address = new Address();

        public Repository()
        {
            string Create = @"CREATE TABLE IF NOT EXIST ";
            string DicCol = @" ([Key] TEXT PRIMARY KEY NOT NULL, [Value] NONE);";
            MSQL.Start(Address.MSQLPath);
            MSQL.Execute(Create + Address.PathTableName + DicCol, MiMFa_ExecuteType.ExecuteNonQuery);
            MSQL.Execute(Create + Address.UrlTableName + DicCol, MiMFa_ExecuteType.ExecuteNonQuery);
        }
        public string GetPath(string key)
        {
            return MSQL.GetValue(Address.PathTableName, key).ToString();
        }
        public void SetPath(string key, string value)
        {
            MSQL.SetValue(Address.PathTableName, key, value);
        }
        public string GetUrl(string key)
        {
            return MSQL.GetValue(Address.UrlTableName, key).ToString();
        }
        public void SetUrl(string key, string value)
        {
            MSQL.SetValue(Address.UrlTableName, key, value);
        }
    }
}
