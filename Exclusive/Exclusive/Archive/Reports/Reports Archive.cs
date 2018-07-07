﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Exclusive.DateAndTime;
using MiMFa_Framework.Exclusive.ProgramingTechnology.DataBase;
using MiMFa_Framework.Service;
using MiMFa_Framework.Configuration;
using MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage;

namespace MiMFa_Framework.Exclusive.Archive.Reports
{
    [Serializable]
    public class MiMFa_ReportsArchive
    {
        public Framework.Model_Format_Layer.Execute.Archive Archive;
        public Framework.Model_Format_Layer.Execute.ReportStyles ReportStyles;
        public static double ReportCounter = 1;
        public Address Address = new Address();

        public MiMFa_ReportsArchive(MiMFa_SQLite msql)
        {
            Archive = new Framework.Model_Format_Layer.Execute.Archive(msql);
            ReportStyles = new Framework.Model_Format_Layer.Execute.ReportStyles(msql);
            CreateTable();
        }

        private void CreateTable()
        {
            Archive.Create();
            ReportStyles.Create();
        }
        public Report GetDefaultReportArchive(string condition = "",string reportStylePath = null, string reportName = "Reports Archive", int limit = -1, int offset = -1)
        {
            Report report = new Report();
            ReportStyle reportstyle = new ReportStyle();
            if (string.IsNullOrEmpty(reportStylePath)) reportStylePath = Address.ReportStyleArchivePath;
            MiMFa_IOService.OpenDeserializeFile(reportStylePath, ref reportstyle);
            Report[] lr = GetReportList(condition, limit, offset);
            //MiMFaReportLanguage MRL = new MiMFaReportLanguage();
            report.Name = reportName;
            report.Style = reportstyle;
            report.Type = typeof(Report);
            report.ObjectArray = lr;
            //report.HTML = MRL.CompileToHTML(report);
            return report;
        }

        public ReportStyle GetReportStyle(double rsID)
        {
          return  ReportStyles.Select(" WHERE RSID = " + rsID.ToString() + " ;").First();
        }

        public Report Store<T>(string reportSubject, string report, ReportStyle reportStyle, T extra, Type type, MiMFa_Accessibility accessablity = MiMFa_Accessibility.User, string creatorName = "Unknown")
        {
            Report NewReport = new Report();
            NewReport.ID = ReportCounter++;
            NewReport.Name = reportSubject;
            NewReport.Type = type;
            NewReport.AccessDate = Default.Date;
            NewReport.AccessTime = Default.Time;
            NewReport.Accessablity = accessablity;
            NewReport.HTML = report;
            NewReport.Extra = extra;
            NewReport.CreatorName = creatorName;
            NewReport.Style = reportStyle;

            return Store(NewReport);
        }
        public Report Store(Report report)
        {
            Archive.Insert(report);
            return report;
        }

        public Report GetReport(string condition)
        {
            var lr = Archive.Select(condition);
            if (lr.Length > 0) return lr[0];
            return null;
        }
        public Report GetReport(double reportID)
        {
            return GetReport(" WHERE ID = " + reportID);
        }

        public List<Report> GetReportList(DataTable dt)
        {
            List<Report> lr = new List<Report>();
            for (int i = 0; i < dt.Rows.Count; i++)
                try
                {
                    Report newReport = new Report();
                    try { newReport.ID = double.Parse(dt.Rows[i]["ID"].ToString()); } catch { }
                    try { newReport.Name = dt.Rows[i]["Name"].ToString(); } catch { }
                    try { newReport.Address = dt.Rows[i]["Address"].ToString(); } catch { }
                    try { newReport.HTML = dt.Rows[i]["HTML"].ToString(); } catch { }
                    try { newReport.RSID = double.Parse(dt.Rows[i]["RSID"].ToString()); } catch { }
                    try { newReport.Style = (ReportStyle)MiMFa_IOService.Deserialize((byte[]) dt.Rows[i]["Style"]); } catch { }
                    try { newReport.Type = (Type)MiMFa_IOService.Deserialize((byte[])dt.Rows[i]["Type"]); } catch{ }
                    try { newReport.ObjectArray = (object[])MiMFa_IOService.Deserialize((byte[])dt.Rows[i]["ObjectArray"]); } catch { }
                    try { newReport.CreatorName = dt.Rows[i]["CreatorName"].ToString(); } catch { }
                    try { newReport.CreateDate = (MiMFa_Date)MiMFa_IOService.Deserialize((byte[])dt.Rows[i]["CreateDate"]); } catch { }
                    try { newReport.CreateTime = (MiMFa_Time)MiMFa_IOService.Deserialize((byte[])dt.Rows[i]["CreateTime"]); } catch { }
                    try { newReport.Accessablity = (MiMFa_Accessibility)MiMFa_IOService.Deserialize((byte[])dt.Rows[i]["Accessablity"]); } catch { }
                    try { newReport.AccessDate = (MiMFa_Date)MiMFa_IOService.Deserialize((byte[])dt.Rows[i]["AccessDate"]); } catch { }
                    try { newReport.AccessTime = (MiMFa_Time)MiMFa_IOService.Deserialize((byte[])dt.Rows[i]["AccessTime"]); } catch { }
                    try { newReport.Extra = MiMFa_IOService.Deserialize((byte[])dt.Rows[i]["Extra"]); } catch { }
                    //object[] itemArray = dt.Rows[i].ItemArray;
                    //newReport.ID = double.Parse(itemArray[0].ToString());
                    //newReport.Name = itemArray[1].ToString();
                    //newReport.Address = itemArray[2].ToString();
                    //newReport.HTML = itemArray[3].ToString();
                    //newReport.RSID = double.Parse(itemArray[4].ToString());
                    //newReport.Style = (ReportStyle)itemArray[5];
                    //newReport.Type = (Type)itemArray[6];
                    //newReport.ObjectArray = (object[])itemArray[7];
                    //newReport.CreatorName = itemArray[8].ToString();
                    //newReport.CreateDate = (MiMFa_Date)itemArray[9];
                    //newReport.CreateTime = (MiMFa_Time)itemArray[10];
                    //newReport.Accessablity = (MiMFa_Accessablity)itemArray[11];
                    //newReport.AccessDate = (MiMFa_Date)itemArray[12];
                    //newReport.AccessTime = (MiMFa_Time)itemArray[13];
                    //newReport.Extra = itemArray[14];
                    lr.Add(newReport);
                }
                catch { }
            return lr;
        }
        public Report[] GetReportList(string condition, int limit = -1, int offset = -1)
        {
            DataTable dt = GetReportTable(condition, limit, offset);
            return Archive.DataTableToArray(dt);
        }
        public List<Report> GetReportList(string condition, SQLiteParameter[] parameters, int limit = -1, int offset = -1)
        {
            DataTable dt = GetReportTable(condition, parameters, limit, offset);
            return GetReportList(dt);
        }
        public DataTable GetReportTable(string condition, SQLiteParameter[] parameters, int limit = -1, int offset = -1)
        {
            string query = condition;
            if (limit > -1) query += " LIMIT " + limit;
            if (offset > -1) query += " OFFSET " + offset;
            return  Archive.GetDataTable(query);
        }
        public DataTable GetReportTable(string condition, int limit = -1, int offset = -1)
        {
            return GetReportTable(condition,GetReportParameter(),limit,offset);
        }

        public void Delete(string condition)
        {
            Archive.Delete( condition);
        }
        public void RemoveReport(params double[] reportIDs)
        {
            string or = " or ";
            string condition = " ";
            foreach (var item in reportIDs)
                condition += item + or;
            Archive.MSQL.Execute("DELETE FROM " + Archive.TableName + " WHERE ID = " + condition + ";", MiMFa_ExecuteType.ExecuteNonQuery);
        }

        public List<Report> GetReportListByID(double id, int limit = -1, int offset = -1)
        {
            return GetReportList(GetReportTable(" WHERE ID = @ID", new SQLiteParameter[] { new SQLiteParameter("@ID", id) }, limit, offset));
        }
        public List<Report> GetReportListBySubject(string reportSubject, int limit = -1, int offset = -1)
        {
            return GetReportList(GetReportTable(" WHERE Name = \"" + reportSubject + "\"", limit, offset));
        }
        public List<Report> GetReportListByType(Type type, int limit = -1, int offset = -1)
        {
            return GetReportList(GetReportTable(" WHERE Type =" + type, new SQLiteParameter[] { new SQLiteParameter("@Type", type)}, limit, offset));
        }
        public List<Report> GetReportListByStyle(double reportStyleID, int limit = -1, int offset = -1)
        {
            return GetReportList(GetReportTable(" WHERE RSID = @RSID",new SQLiteParameter[] { new SQLiteParameter("@RSID", reportStyleID) },limit,offset));
        }
        public List<Report> GetReportListByCreatorName(string creatorName, int limit = -1, int offset = -1)
        {
            return GetReportList(GetReportTable(" WHERE CreatorName = \"" + creatorName + "\"", limit, offset));
        }
        public List<Report> GetReportListByCreateDate(MiMFa_Date fromThisCreateDate,MiMFa_Date toThisCreateDate, int limit = -1, int offset = -1)
        {
            List<Report> lr = GetReportList(GetReportTable("", limit, offset));
            List<int> li = new List<int>();
            for (int i = 0; i < lr.Count; i++)
                if (!lr[i].CreateDate.IsBetween(fromThisCreateDate, toThisCreateDate)) li.Add(i);
            for (int i = li.Count - 1; i >= 0; i--)
                lr.RemoveAt(li[i]);
            return lr;
        }
        public List<Report> GetReportListByAccessablity(MiMFa_Accessibility accessablity, int limit = -1, int offset = -1)
        {
            return GetReportList(GetReportTable(" WHERE Accessablity = @Accessablity", new SQLiteParameter[] { new SQLiteParameter("@Accessablity", accessablity) }, limit, offset));
        }
        public List<Report> GetReportListByAccessDate(MiMFa_Date fromThisAccessDate, MiMFa_Date toThisAccessDate, int limit = -1, int offset = -1)
        {
            List<Report> lr = GetReportList(GetReportTable("", limit, offset));
            List<int> li = new List<int>();
            for (int i = 0; i < lr.Count; i++)
                if (!lr[i].AccessDate.IsBetween(fromThisAccessDate, toThisAccessDate)) li.Add(i);
            for (int i = li.Count - 1; i >= 0; i--)
                lr.RemoveAt(li[i]);
            return lr;
        }

        private SQLiteParameter[] GetReportStyleParameter(ReportStyle reportStyle = null)
        {
            ReportStyle rs;
            if (reportStyle == null) rs = new ReportStyle();
            else rs = reportStyle;
            return new SQLiteParameter[]{
                    new SQLiteParameter("@RSID",rs.RSID),
                    new SQLiteParameter("@Style",MiMFa_IOService.Serialize(rs))
                };
        }
        private SQLiteParameter[] GetReportParameter(Report report = null)
        {
            Report r;
            if (report == null) r = new Report();
            else r = report;
            return new SQLiteParameter[] {
                    new SQLiteParameter("@ID", r.ID),
                    new SQLiteParameter("@Name", r.Name),
                    new SQLiteParameter("@Address", r.Address),
                    new SQLiteParameter("@HTML",r.HTML),
                    new SQLiteParameter("@RSID", r.RSID),
                    new SQLiteParameter("@Style", MiMFa_IOService.Serialize(r.Style)),
                    new SQLiteParameter("@Type", MiMFa_IOService.Serialize(r.Type)),
                    new SQLiteParameter("@ObjectArray", MiMFa_IOService.Serialize(r.ObjectArray)),
                    new SQLiteParameter("@CreatorName", r.CreatorName),
                    new SQLiteParameter("@CreateDate", MiMFa_IOService.Serialize(r.CreateDate)),
                    new SQLiteParameter("@CreateTime", MiMFa_IOService.Serialize(r.CreateTime)),
                    new SQLiteParameter("@Accessablity", MiMFa_IOService.Serialize(r.Accessablity)),
                    new SQLiteParameter("@AccessDate",MiMFa_IOService.Serialize( r.AccessDate)),
                    new SQLiteParameter("@AccessTime", MiMFa_IOService.Serialize(r.AccessTime)),
                    new SQLiteParameter("@Extra", MiMFa_IOService.Serialize(r.Extra))};
        }
    }
}
