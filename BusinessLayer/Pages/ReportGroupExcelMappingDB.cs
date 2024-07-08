using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using DevExpress.Spreadsheet;

namespace BusinessLayer.Pages
{
	public class ReportGroupExcelMappingDB : DBBase<ReportGroupExcelMapping, List<ReportGroupExcelMapping>, int>
	{
		public override List<ReportGroupExcelMapping> GetAll()
		{
			return ((IEnumerable<ReportGroupExcelMapping>)dbContext.ReportGroupExcelMappings).ToList();
		}

		public override ReportGroupExcelMapping GetByID(int id)
		{
			return ((IQueryable<ReportGroupExcelMapping>)dbContext.ReportGroupExcelMappings).FirstOrDefault((ReportGroupExcelMapping j) => j.ReportGroupColMapID == id);
		}

		public override bool Insert(ReportGroupExcelMapping entity, out string message)
		{
			message = "";
			try
			{
				dbContext.ReportGroupExcelMappings.Add(entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
					return true;
				
				message = "InsertError";
				return false;
			}
			catch (Exception)
			{
				message = "InsertError";
				return false;
			}
		}

		public override bool Update(ReportGroupExcelMapping entity, out string message)
		{
			message = "";
			try
			{
				ReportGroupExcelMapping byID = GetByID(entity.ReportGroupColMapID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<ReportGroupExcelMapping>(byID);
				val.State = (EntityState)16;
				val.CurrentValues.SetValues((object)entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
					return true;
				
				message = "UpdateError";
				return false;
			}
			catch (Exception)
			{
				message = "";
				return false;
			}
		}

		public override bool Delete(ReportGroupExcelMapping entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<ReportGroupExcelMapping>(entity).State = (EntityState)8;
				if (((DbContext)dbContext).SaveChanges() > 0)
					return true;
				
				message = "DeleteError";
				return false;
			}
			catch (Exception)
			{
				message = "DeleteError";
				return false;
			}
		}

		public List<ExcelMappingFieldList> GetFieldList()
		{
			return ((IEnumerable<ExcelMappingFieldList>)dbContext.ExcelMappingFieldList).ToList();
		}

        public List<ViewReportGroupExcelCellFieldMapping> GetFieldCellMappingListByGroupID(int GroupID)
        {
            return ((IQueryable<ViewReportGroupExcelCellFieldMapping>)dbContext.ViewReportGroupExcelCellFieldMappings).Where((ViewReportGroupExcelCellFieldMapping x) => x.FKGroupID == GroupID || (int?)x.FKGroupID == null).ToList();
        }

        public List<ViewReportGroupExcelCellFieldMapping> GetMappingListByMasterIDWithSession(int masterId, bool IsReport)
        {
            if (masterId > 0)
            {
                return (from x in GetFieldCellMappingListByGroupID(masterId)
                        where x.IsForReport == IsReport
                        select x).ToList();
            }

            object obj = HttpContext.Current.Session["ReportGroupExcelMappingList"];
            if (obj == null)
            {
                obj = GetFieldCellMappingListByGroupID(masterId);
                HttpContext.Current.Session["ReportGroupExcelMappingList"] = obj;
            }

            return ((List<ViewReportGroupExcelCellFieldMapping>)obj).Where((ViewReportGroupExcelCellFieldMapping x) => x.IsForReport == IsReport).ToList();
        }

        public bool UpdateMappingWithSession(ViewReportGroupExcelCellFieldMapping entity)
        {
            if (entity.FKGroupID == 0)
            {
                object obj = HttpContext.Current.Session["ReportGroupExcelMappingList"];
                List<ViewReportGroupExcelCellFieldMapping> list = ((obj == null) ? GetFieldCellMappingListByGroupID(entity.FKGroupID) : (obj as List<ViewReportGroupExcelCellFieldMapping>));
                ViewReportGroupExcelCellFieldMapping viewReportGroupExcelCellFieldMapping = list.First((ViewReportGroupExcelCellFieldMapping x) => x.ExcelMappingFieldId == entity.ExcelMappingFieldId && x.IsForReport == entity.IsForReport);
                viewReportGroupExcelCellFieldMapping.ExcelCell = entity.ExcelCell;
                HttpContext.Current.Session["ReportGroupExcelMappingList"] = list;
                return true;
            }

            ReportGroupExcelMapping reportGroupExcelMapping = ((IQueryable<ReportGroupExcelMapping>)dbContext.ReportGroupExcelMappings).FirstOrDefault((ReportGroupExcelMapping x) => x.FKGroupID == entity.FKGroupID && x.IsForReport == entity.IsForReport && x.FieldName == entity.FieldName);
            if (reportGroupExcelMapping != null)
                reportGroupExcelMapping.ExcelCell = entity.ExcelCell;
            else
            {
                reportGroupExcelMapping = new ReportGroupExcelMapping();
                reportGroupExcelMapping.FKGroupID = entity.FKGroupID;
                reportGroupExcelMapping.IsForReport = entity.IsForReport;
                reportGroupExcelMapping.FieldName = GetFieldNameById(entity.ExcelMappingFieldId);
                reportGroupExcelMapping.ExcelCell = entity.ExcelCell;
                dbContext.ReportGroupExcelMappings.Add(reportGroupExcelMapping);
            }
            return ((DbContext)dbContext).SaveChanges() > 0;
        }

        private string GetFieldNameById(int id)
		{
			return ((IQueryable<ExcelMappingFieldList>)dbContext.ExcelMappingFieldList).FirstOrDefault((ExcelMappingFieldList x) => x.ExcelMappingFieldId == id).FieldName;
		}

		public bool UpdateMapping(ViewReportGroupExcelCellFieldMapping entity)
		{
			return true;
		}

		public bool CheckValidateWorkbookCell(string Cell, int FKGroupID, string WorkFormFileName, string WorkFormWorksheet)
		{
			if (FKGroupID > 0)
			{
				ReportGroup byID = new ReportGroupDB().GetByID(FKGroupID);
				Workbook val = new Workbook();
				string text = HttpContext.Current.Server.MapPath("~/Uploaded/ReportGroupInfo/" + byID.WorkFormFileName);
				val.LoadDocument(text, DocumentFormat.Xlsx);
				Worksheet val2 = val.Worksheets[byID.WorkFormWorksheet];
				string text2 = Convert.ToString(((Range)val2.Cells[Cell]).Value);
				if ((text2 == null || text2 == "") && !((Formatting)val2.Cells[Cell]).Protection.Locked)
					return true;
				
				return false;
			}

			Workbook val3 = new Workbook();
			string text3 = HttpContext.Current.Server.MapPath("~/Uploaded/ReportGroupInfo/" + WorkFormFileName);
			val3.LoadDocument(text3, DocumentFormat.Xlsx);
			Worksheet val4 = val3.Worksheets[WorkFormWorksheet];
			string text4 = Convert.ToString(((Range)val4.Cells[Cell]).Value);
			if ((text4 == null || text4 == "") && !((Formatting)val4.Cells[Cell]).Protection.Locked)
				return true;
			
			return false;
		}

		public bool CheckValidateReportCell(string Cell, int FKGroupID, string ReportFileName, string ReportWorksheet)
		{
			if (FKGroupID > 0)
			{
                ReportGroup byID = new ReportGroupDB().GetByID(FKGroupID);
				Workbook val = new Workbook();
				string text = HttpContext.Current.Server.MapPath("~/Uploaded/ReportGroupInfo/" + byID.ReportFileName);
				val.LoadDocument(text, DocumentFormat.Xlsx);
				Worksheet val2 = val.Worksheets[byID.ReportWorksheet];
				string text2 = Convert.ToString(((Range)val2.Cells[Cell]).Value);
				if ((text2 == null || text2 == "") && !((Formatting)val2.Cells[Cell]).Protection.Locked)
					return true;
				
				return false;
			}

			Workbook val3 = new Workbook();
			string text3 = HttpContext.Current.Server.MapPath("~/Uploaded/ReportGroupInfo/" + ReportFileName);
			val3.LoadDocument(text3, DocumentFormat.Xlsx);
			Worksheet val4 = val3.Worksheets[ReportWorksheet];
			string text4 = Convert.ToString(((Range)val4.Cells[Cell]).Value);
			if ((text4 == null || text4 == "") && !((Formatting)val4.Cells[Cell]).Protection.Locked)
				return true;
			
			return false;
		}

		public ReportGroupExcelMapping GetFieldCellMappingListByGroupIDAndFieldName(long FKGroupID, bool IsForReport, string FieldName)
		{
			return ((IQueryable<ReportGroupExcelMapping>)dbContext.ReportGroupExcelMappings).FirstOrDefault((ReportGroupExcelMapping x) => (long)x.FKGroupID == FKGroupID && x.IsForReport == IsForReport && x.FieldName == FieldName);
		}
	}
}
