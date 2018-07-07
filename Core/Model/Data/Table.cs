using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Exclusive.Collection.Instance;
using MiMFa_Framework.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Model
{
    [Serializable]
    public class MiMFa_Table 
    {
        public MiMFa_Table()
        {
        }
        public MiMFa_Table(DataTable dt)
        {
            MainTable = dt;
        }
        public MiMFa_Table(IEnumerable<DataRow> collection)
        {
            DataRow[] dra = collection.ToArray();
            if (dra.Length > 0)
            {
                UpdateColumnsNumber(dra[0].ItemArray.Length,false);
                for (int i = 1; i < dra.Length; i++)
                    MainTable.Rows.Add(dra[i].ItemArray);
            }
        }
        public MiMFa_Table(string name,string description = "")
        {
            Name = name;
            Description = description;
            MainTable = new DataTable();
            MainTable.Columns.Add(IDColumnName,typeof(string));
            MainTable.Rows.Add(IDColumnLabel);
            AliasName = GetNewAliasName();
            MainTable.TableName = name;
            MetaAttributesTable = null;
            MetaColumnsTable = null;
        }
        public MiMFa_Table(string name,string description, string aliasName, DataTable mainTable, DataTable attrTable, DataTable labelTable)
        {
            Name = Name;
            Description = description;
            AliasName = aliasName;
            MainTable = mainTable;
            MetaAttributesTable = attrTable;
            MetaColumnsTable = labelTable;
        }

        public override string ToString()
        {
            return Instance.Name;
        }

        public static string Extention => ".mdt";
        public static string ColumnPrefix => "Col";
        public static string IDColumnName => "ID";
        public static string IDColumnLabel => ".";
        public static string ItemsSplitterID => ".ItemsSplitter";
        public static string SubItemsSplitterID => ".SubItemsSplitter";
        public MiMFa_ObjectDetail Instance { get; set; } = new MiMFa_ObjectDetail();
        public string Name
        {
            get { return Instance.Name; }
            set { Instance.Name = value; }
        }
        public string AliasName
        {
            get { return Instance.AliasName; }
            set { Instance.AliasName = value; }
        }
        public string Description
        {
            get { return Instance.Description; }
            set { Instance.Description = value; }
        }
        public string Detail
        {
            get { return Instance.Detail; }
            set { Instance.Detail = value; }
        }
        public object Extra
        {
            get { return Instance.Extra; }
            set { Instance.Extra = value; }
        }
        public  double ID
        {
            get { return Instance.ID; }
            set { Instance.ID = value; }
        }
        public  string UID
        {
            get { return Instance.UID; }
            set { Instance.UID = value; }
        }
        public string[] ColumnsLabel
        {
            get
            {
                return GetStringRow(0);
            }
            set
            {
                UpdateColumnsNumber(value.Length,true);
                if (MainTable.Rows.Count < 1) AddRow(value);
                else MainTable.Rows[0].ItemArray = value;
            }
        }
        public string[] ColumnsID
        {
            get
            {
                string[] stra = new string[MainTable.Columns.Count];
                for (int i = 0; i < MainTable.Columns.Count; i++)
                    stra[i] = MainTable.Columns[i].ColumnName;
                return stra;
            }
            set
            {
                UpdateColumnsNumber(value.Length,true);
                for (int i = 0; i < value.Length; i++)
                    MainTable.Columns[i].ColumnName = value[i];
            }
        }
        public DataColumnCollection Columns
        {
            get { return MainTable.Columns; }
            set
            {
                MainTable.Columns.Clear();
                foreach (DataColumn item in value)
                    MainTable.Columns.Add(item);
            }
        }
        public DataRowCollection Rows
        {
            get { return MainTable.Rows; }
            set
            {
                MainTable.Rows.Clear();
                foreach (DataColumn item in value)
                    MainTable.Rows.Add(item);
            }
        }
        public int ColumnsCount
        {
            get { return MainTable.Columns.Count; }
            set
            {
               UpdateColumnsNumber(value,true);
            }
        }
        public int RowsCount
        {
            get { return MainTable.Rows.Count; }
            set
            {
                UpdateRowsNumber(value, true);
            }
        }
        public DataTable MainTable { get; set; } = new DataTable();
        public DataTable MetaAttributesTable { get; set; } = null;
        public DataTable MetaColumnsTable { get; set; } = null;
        public List<MiMFa_Table> SubTables { get; set; } = new List<MiMFa_Table>();
        public string FindColumnIDByKeyWord(string name)
        {
            name = ColumnPrefix + "_" + MiMFa_Framework.Service.MiMFa_StringService.CompressedText(MiMFa_Convert.ToCancatedName(name, true), 20, "") + "_";
            return ColumnsID.ToList().Find((id)=>id.StartsWith(name));
        }
        public string FindColumnIDByLabel(string label)
        {
            int ind = FindColumnIndexByLabel(label);
            if (ind < 0) return null;
            return MainTable.Columns[ind].ColumnName;
        }
        public int FindColumnIndexByLabel(string label)
        {
            if (MainTable.Rows.Count < 1) return -1;
            for (int i = 0; i < MainTable.Columns.Count; i++)
                if ((MainTable.Rows[0][i] + "") == label) return i;
            return -1;
        }
        public DataColumn FindColumnByLabel(string label)
        {
            int ind = FindColumnIndexByLabel(label);
            if(ind < 0) return null;
            return MainTable.Columns[ind];
        }
        public List<string> FindColumnIDsByKeyWord(string name)
        {
            name = ColumnPrefix + "_" + MiMFa_Framework.Service.MiMFa_StringService.CompressedText(MiMFa_Convert.ToCancatedName(name, true), 20, "") + "_";
            return ColumnsID.ToList().FindAll((id) => id.StartsWith(name));
        }
        public List<string> FindColumnIDsByLabel(string label)
        {
            List<string> lc = new List<string>();
            List<int> li = FindColumnIndecesByLabel(label);
            foreach (var item in li)
                lc.Add(MainTable.Columns[item].ColumnName);
            return lc;
        }
        public List<int> FindColumnIndecesByLabel(string label)
        {
            List<int> li = new List<int>();
            if (MainTable.Rows.Count < 1) return li;
            for (int i = 0; i < MainTable.Columns.Count; i++)
                if ((MainTable.Rows[0][i] + "") == label) li.Add(i);
            return li;
        }
        public List<DataColumn> FindColumnsByLabel(string label)
        {
            List<DataColumn> lc = new List<DataColumn>();
            List<int> li = FindColumnIndecesByLabel(label);
            foreach (var item in li)
                lc.Add(MainTable.Columns[item]);
            return lc;
        }
        public string GetNewRowID()
        {
            return string.Join(IDColumnLabel, DateTime.Now.Ticks , MainTable.Rows.Count);
        }
        public string GetNewRowID(int count)
        {
            return string.Join(IDColumnLabel, DateTime.Now.Ticks , count);
        }
        public string GetNewColumnName()
        {
           return CreateColumnName("", MainTable.Columns.Count);
        }
        public string GetNewColumnName(int index)
        {
           return CreateColumnName("",index );
        }
        public string GetNewColumnName(string name)
        {
           return CreateColumnName(name, MainTable.Columns.Count);
        }
        public static string CreateNewRowID(string fromThisID,string toThisID)
        {
            long n1 = 1;
            double n2 = 1;
            long s1 = 0;
            double s2 = 0;
            long e1 = 999999999999999999;
            double e2 = 999999999999999999;
            try
            {
                string[] ma = MiMFa_Framework.Service.MiMFa_StringService.FirstFindAndSplit(fromThisID, IDColumnLabel);
                s1 = Convert.ToInt64(ma.First());
                s2 = Convert.ToDouble(ma.Last());
            }
            catch { }
            try
            {
                string[] ma = MiMFa_Framework.Service.MiMFa_StringService.FirstFindAndSplit(toThisID, IDColumnLabel);
                e1 = Convert.ToInt64(ma.First());
                e2 = Convert.ToDouble(ma.Last());
            }
            catch { }
            if (s1 > e1)
            {
                if (s1 > e1 + 1) n1 = s1 - 1;
                else
                {
                    n1 = s1;
                    if (s2 > e2 + 1) n2 = s2 - 1;
                    else n2 = s2 - 0.00000000000001;
                }
            }
            else if (s1 < e1)
            {
                if (s1 < e1 - 1) n1 = s1 + 1;
                else
                {
                    n1 = s1;
                    if (s2 < e2 - 1) n2 = s2 + 1;
                    else n2 = s2 + 1;
                }
            }
            else
            {
                n1 = s1;
                if (s2 > e2 + 0.00000000000001) n2 = s2 - 0.00000000000001;
                else if (s2 < e2 - 1) n2 = s2 + 1;
                else n1 = DateTime.Now.Ticks;
            }
            return n1 + IDColumnLabel + n2;
        }
        public static string CreateColumnName(int index)
        {
           return CreateColumnName("",index + 1);
        }
        public static string CreateColumnName(string name,int index)
        {
            return ColumnPrefix + "_" + MiMFa_Framework.Service.MiMFa_StringService.CompressedText(MiMFa_Convert.ToCancatedName(name, true),20,"") + "_" + index;
        }

        public static MiMFa_Table AddInTable(MiMFa_Table mainDT, object str, string colName, MiMFa_TableValuePositionType put)
        {
            switch (put)
            {
                case MiMFa_TableValuePositionType.NextRowCell:
                    mainDT.AddRowSafe();
                    if (string.IsNullOrWhiteSpace(colName)) mainDT.AddInLastRowCellSafe(str);
                    else mainDT.AddInLastRowCellSafe(str, colName);
                    break;
                case MiMFa_TableValuePositionType.Null:
                case MiMFa_TableValuePositionType.NextColumnCell:
                    if (string.IsNullOrWhiteSpace(colName)) mainDT.AddInLastRowCellSafe(str);
                    else mainDT.AddInLastRowCellSafe(str, colName);
                    break;
                case MiMFa_TableValuePositionType.NextSubCell:
                    if (string.IsNullOrWhiteSpace(colName)) mainDT.AppendInLastRowCellSafe(str);
                    else mainDT.AppendInLastRowCellSafe(str, colName);
                    break;
            }
            return mainDT;
        }
        public static MiMFa_Table ConcatTable(MiMFa_Table mainDT, MiMFa_Table dt)
        {
            if (dt == null) return mainDT;
            if (mainDT == null) return dt;
            for (int i = 1; i < dt.MainTable.Rows.Count; i++)
            {
                mainDT.AddRowSafe();
                for (int j = 0; j < dt.MainTable.Columns.Count; j++)
                    mainDT.AddInLastRowCellSafe(dt.MainTable.Rows[i][j], dt.MainTable.Rows[0][j] + "");
            }
            return mainDT;
        }
        public static MiMFa_Table Transpose(MiMFa_Table dt, bool toRight = true)
        {
            MiMFa_Table mdt = new MiMFa_Table();
            if (toRight)
                for (int i = 0; i < dt.MainTable.Rows.Count; i++)
                        mdt.AddColumnSafe(i, dt.MainTable.Rows[i].ItemArray);
            else for (int i = dt.MainTable.Rows.Count - 1; i >= 0; i--)
                    mdt.AddColumnSafe(i, dt.MainTable.Rows[i].ItemArray.Reverse());
            return mdt;
        }

        public void UpdateRowsNumber(int count,bool allowRemove = false)
        {
            if (MainTable.Rows.Count == count) return;
            if (allowRemove && MainTable.Rows.Count > count)
                for (int i = MainTable.Rows.Count - 1; i >= count; i--)
                    try
                    {
                        MainTable.Rows.RemoveAt(i);
                    }
                    catch { }
            else
            {
                for (int i = MainTable.Rows.Count; i < count; i++)
                    try
                    {
                        AddRowSafe();
                    }
                    catch { }
            }
        }
        public void UpdateColumnsNumber(int count,bool allowRemove = false)
        {
            if (MainTable.Columns.Count == count) return;
            if (allowRemove && MainTable.Columns.Count > count)
                for (int i = MainTable.Columns.Count - 1; i >= count; i--)
                    try
                    {
                        MainTable.Columns.RemoveAt(i);
                    }
                    catch { }
            else
            {
                for (int i = MainTable.Columns.Count; i < count; i++)
                    try
                    {
                        AddColumnSafe(i);
                    }
                    catch { }
            }
        }
        public void UpdateColumnsLabel(object[] labels,bool allowRemove = false)
        {
            UpdateColumnsNumber(labels.Length,allowRemove);
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < labels.Length; i++)
                AddToDic(ref dic, MiMFa_Framework.Service.MiMFa_StringService.CompressedText(MiMFa_Convert.ToCancatedName(labels[i]+"", true), 20, ""), 1);
            int j = 0;
            foreach (var item in dic.Keys)
                try { MainTable.Columns[j++].ColumnName = item; } catch { }
        }
        public void UpdateColumnsLabel(bool allowRemove = false)
        {
            UpdateColumnsLabel(
                (MainTable.Rows.Count > 0) ?
                MainTable.Rows[0].ItemArray :
                new object[MainTable.Columns.Count],allowRemove);
        }
        public int AddToDic(ref Dictionary<string, int> dic, string item,int d)
        {
            string name = ColumnPrefix + "_" + item + "_" + d;
            try
            {
                dic.Add(name, d);
                return d;
            }
            catch
            {
                d = ++dic[name];
                return AddToDic(ref dic,item, d);
            }
        }
        public string[] GetStringRow(int index)
        {
            if (MainTable.Rows.Count <= index) return new string[0];
            string[] ls = new string[MainTable.Rows[index].ItemArray.Length];
            for (int i = index; i < MainTable.Rows[index].ItemArray.Length; i++)
                ls[i] = MainTable.Rows[index].ItemArray[i] + "";
            return ls;
        }
        public DataRow AppendInLastRowCellSafe(object str)
        {
            if (MainTable.Columns.Count < 1) AddColumnSafe();
            if (MainTable.Rows.Count < 1) AddRowSafe();
            if (MainTable.Rows.Count < 2) return AddRowSafe(new object[] { str });
            for (int i = MainTable.Columns.Count - 1; i >= 0; i--)
                if(MainTable.Rows[MainTable.Rows.Count - 1][i] + "" != "")
                {
                    MainTable.Rows[MainTable.Rows.Count - 1][i] = MainTable.Rows[MainTable.Rows.Count - 1][i] + "" + str;
                    return MainTable.Rows[MainTable.Rows.Count - 1];
                }
            MainTable.Rows[MainTable.Rows.Count - 1][0] = str;
            return MainTable.Rows[MainTable.Rows.Count - 1];
        }
        public DataRow AppendInLastRowCellSafe(object str,string colName)
        {
            if (MainTable.Columns.Count < 1) AddColumnSafe(colName);
            if (MainTable.Rows.Count < 2) return AddRowSafe(new object[] { str });
            string cn = FindColumnIDByLabel(colName);
            try { MainTable.Rows[MainTable.Rows.Count - 1][cn] = MainTable.Rows[MainTable.Rows.Count - 1][cn] + "" + str ; }
            catch {
                var dc = AddColumnSafe(colName);
                MainTable.Rows[MainTable.Rows.Count - 1][dc.ColumnName] = str;
            }
            return MainTable.Rows[MainTable.Rows.Count - 1];
        }
        public DataRow AppendInLastRowCellSafe(object str, int index)
        {
            if (MainTable.Columns.Count < 1) AddColumnSafe();
            if (MainTable.Rows.Count < 1) AddRowSafe();
            if (MainTable.Rows.Count < 2) return AddRowSafe(new object[] { str });
            try { MainTable.Rows[MainTable.Rows.Count - 1][index] = MainTable.Rows[MainTable.Rows.Count - 1][index] + "" + str; }
            catch {
                AddColumnSafe(index);
                MainTable.Rows[MainTable.Rows.Count - 1][index] = str;
            }
            return MainTable.Rows[MainTable.Rows.Count - 1];
        }
        public DataRow AddInLastRowCellSafe(object obj)
        {
            if (MainTable.Columns.Count < 1) AddColumnSafe();
            if (MainTable.Rows.Count < 1) AddRowSafe();
            if (MainTable.Rows.Count < 2) return AddRowSafe(new object[] { obj });
            for (int i = MainTable.Columns.Count - 1; i >= 0; i--)
                if (MainTable.Rows[MainTable.Rows.Count - 1][i] + "" != "" )
                {
                    i++;
                    if (i >= MainTable.Columns.Count) AddColumnSafe();
                    MainTable.Rows[MainTable.Rows.Count - 1][i] = obj;
                    return MainTable.Rows[MainTable.Rows.Count - 1];
                }
            MainTable.Rows[MainTable.Rows.Count - 1][0] = obj;
            return MainTable.Rows[MainTable.Rows.Count - 1];
        }
        public DataRow AddInLastRowCellSafe(object obj, string colName)
        {
            if (MainTable.Columns.Count < 1) AddColumnSafe(colName);
            if (MainTable.Rows.Count < 2) return AddRowSafe(new object[] { obj });
            List<string> cns = FindColumnIDsByLabel(colName);
            bool geted = false;
            if (cns.Count > 0)
                foreach (var cn in cns)
                    if (geted = string.IsNullOrWhiteSpace(MainTable.Rows[MainTable.Rows.Count - 1][cn] + ""))
                    {
                        MainTable.Rows[MainTable.Rows.Count - 1][cn] = obj;
                        break;
                    }
            if(!geted)
            {
                var dc = AddColumnSafe(colName);
                MainTable.Rows[MainTable.Rows.Count - 1][dc.ColumnName] = obj;
            }
            return MainTable.Rows[MainTable.Rows.Count - 1];
        }
        public DataRow AddInLastRowCellSafe(object obj, int index)
        {
            if (MainTable.Columns.Count < 1) AddColumnSafe();
            if (MainTable.Rows.Count < 1) AddRowSafe();
            if (MainTable.Rows.Count < 2) return AddRowSafe(new object[] { obj });
            try { MainTable.Rows[MainTable.Rows.Count - 1][index] = obj; }
            catch
            {
                AddColumnSafe(index);
                MainTable.Rows[MainTable.Rows.Count - 1][index] = obj;
            }
            return MainTable.Rows[MainTable.Rows.Count - 1];
        }
        public DataRow AddInCellSafe(object obj, int rowIndex,int columnIndex)
        {
            if (MainTable.Columns.Count < 1) AddColumnSafe();
            if (MainTable.Rows.Count < 1) AddRowSafe();
            try { MainTable.Rows[rowIndex][columnIndex] = obj; }
            catch
            {
                UpdateColumnsNumber(columnIndex+1,false);
                int i = MainTable.Rows.Count-1;
                for (; i < rowIndex; i++)
                    MainTable.Rows.Add();
                MainTable.Rows[rowIndex][columnIndex] = obj;
            }
            return MainTable.Rows[rowIndex];
        }
        public DataRow AddCellSafe(params object[] values)
        {
            if (MainTable.Rows.Count < 1) return AddRowSafe(values);
            List<object> lo = MainTable.Rows[MainTable.Rows.Count - 1].ItemArray.ToList();
            for (int i = lo.Count - 1; i >= 0; i--)
                if (lo != null) break;
                else lo.RemoveAt(i);
            lo.AddRange(values);
            MainTable.Rows.RemoveAt(MainTable.Rows.Count - 1);
            return AddRowSafe(lo.ToArray());
        }
        public DataRow AddRowSafe(params object[] values)
        {
            UpdateColumnsNumber(values.Length,false);
            return MainTable.Rows.Add(values);
        }
        public DataRow AddRow(params object[] values)
        {
           return MainTable.Rows.Add(values);
        }
        public DataColumn AddColumnSafe()
        {
            return AddColumn(GetNewColumnName());
        }
        public DataColumn AddColumnSafe(int colIndex, params object[] values)
        {
            UpdateColumnsNumber(colIndex + 1, false);
            for (int i = 0; i < values.Length; i++)
                AddInCellSafe(values[i],i, colIndex);
            return this.MainTable.Columns[colIndex];
        }
        public DataColumn AddColumnSafe(int index, string label = "")
        {
           return AddColumn(GetNewColumnName(index),label);
        }
        public DataColumn AddColumnSafe(string label)
        {
            return AddColumn(GetNewColumnName(label),label);
        }
        public DataColumn AddColumn(string name,string label = "")
        {
            DataColumn dc = MainTable.Columns.Add(name, typeof(object));
            if (MainTable.Rows.Count < 1) AddRowSafe();
            MainTable.Rows[0][dc.ColumnName] = label;
            return dc;
        }
        public MiMFa_Table AddInTable(string str, string colName, MiMFa_TableValuePositionType put)
        {
            return AddInTable(this,str,colName,put);
        }

        public void SetColumnsLabel(string name, string key)
        {
            throw new NotImplementedException();
        }

        public MiMFa_Table ConcatTable(MiMFa_Table dt)
        {
            return ConcatTable(this,dt);
        }

        public MiMFa_Table Transpose(bool toRight)
        {
            return Transpose(this, toRight);
        }

        public string GetNewAliasName()
        {
            return GetNewAliasName(Name);
        }
        public static string GetNewAliasName(string name)
        {
           return "Table_" + MiMFa_Framework.Service.MiMFa_StringService.CompressedText(MiMFa_Convert.ToCancatedName(name,true),10,"") + "_" + (DateTime.Now.Ticks + "").Substring(10);
        }

        public Dictionary<string, string> GetColumnsIDLabelDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (MainTable.Columns.Count > 0)
            if (MainTable.Rows.Count < 1)
                    for (int i = 0; i < MainTable.Columns.Count; i++)
                        try
                        {
                            dic.Add(MainTable.Columns[i].ColumnName,"");
                        }
                        catch { }
                else
                for (int i = 0; i < MainTable.Columns.Count; i++)
                    try
                    {
                        dic.Add(MainTable.Columns[i].ColumnName, MainTable.Rows[0][i] + "");
                    }
                    catch { }
            return dic;
        }

        public Dictionary<string, KeyValuePair<string, object>> GetFieldSampleLabels()
        {
            Dictionary<string, KeyValuePair<string, object>> dic = new Dictionary<string, KeyValuePair<string, object>>();
            if (MainTable.Columns.Count > 0)
                if (MainTable.Rows.Count < 1)
                    for (int i = 0; i < MainTable.Columns.Count; i++)
                        try
                        {
                            //if (Columns[i].ColumnName == IDColumnName) continue;
                            dic.Add(MainTable.Columns[i].ColumnName, new KeyValuePair<string, object>("", ""));
                        }
                        catch { }
                else for (int i = 0; i < MainTable.Columns.Count; i++)
                        try
                        {
                            //if (Columns[i].ColumnName == IDColumnName) continue;
                            object val = null;
                            for (int r = 1; r < MainTable.Rows.Count; r++)
                                if ((val = MainTable.Rows[r][i]) != null) break;
                            dic.Add(MainTable.Columns[i].ColumnName, new KeyValuePair<string, object>(MainTable.Rows[0][i] + "", val));
                        }
                        catch { }
            return dic;
        }
        public DataTable GetStandardDataTable()
        {
            if (MainTable.Rows.Count < 1 || MainTable.Columns.Count < 1) return MainTable;
            DataTable dt = MainTable;
            dt.TableName = Name;
            //for (int i = 0; i < dt.Columns.Count; i++)
            //    try { dt.Columns[i].ColumnName = dt.Rows[0][i] + ""; } catch { dt.Columns[i].ColumnName = GetNewColumnName(i); }
            //dt.Rows.RemoveAt(0);
            return dt;
        }
    }
}
