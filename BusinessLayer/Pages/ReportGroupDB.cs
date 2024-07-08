using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BusinessLayer.Pages
{
	public class ReportGroupDB : DBBase<ReportGroup, List<ReportGroup>, int>
	{
		public override List<ReportGroup> GetAll()
		{
			return ((IEnumerable<ReportGroup>)dbContext.ReportGroup).ToList();
		}

		public override ReportGroup GetByID(int id)
		{
			return ((IQueryable<ReportGroup>)dbContext.ReportGroup).FirstOrDefault((ReportGroup j) => j.GroupID == id);
		}
        
        public override bool Insert(ReportGroup entity, out string message)
		{
			message = "";
			try
			{
				dbContext.ReportGroup.Add(entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
                    HttpContext context = HttpContext.Current;
                    context.Session["ReportGroupID"]= entity.GroupID;
                    

                    return true;
				}
				message = "InsertError";
				return false;
			}
			catch (Exception ex)
			{
				message = "InsertError";
				return false;
			}
		}

		public override bool Update(ReportGroup entity, out string message)
		{
			message = "";
			try
			{
				ReportGroup byID = GetByID(entity.GroupID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<ReportGroup>(byID);
				val.State = (EntityState)16;
				val.CurrentValues.SetValues((object)entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					return true;
				}
				message = "UpdateError";
				return false;
			}
			catch (Exception ex)
			{
				message = "";
				return false;
			}
		}

		public override bool Delete(ReportGroup entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<ReportGroup>(entity).State = (EntityState)8;
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					return true;
				}
				message = "DeleteError";
				return false;
			}
			catch (Exception ex)
			{
				message = "DeleteError";
				return false;
			}
		}

		public bool Insert(ReportGroup entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(ReportGroup entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(ReportGroup entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public string GetNewSerial()
		{
			string maxGroupNumber = GetMaxGroupNumber();
            int newVal = 0;
            int.TryParse(maxGroupNumber, out newVal);
            newVal = newVal + 1;
            string str = newVal.ToString();
			return str = "0" + str;
		}

		private string GetMaxGroupNumber()
		{
			int? num = ((IQueryable<ReportGroup>)dbContext.ReportGroup).Max((Expression<Func<ReportGroup, int?>>)((ReportGroup entity) => entity.GroupID));
			if (num.HasValue)
			{
				string text = GetByID(num.Value).GroupNumber;
				if (text == null)
				{
					text = "0";
				}
				return text;
			}
			return "0";
		}

        public List<string> GetWorkformWorksheetList()
        {
            object obj = HttpContext.Current.Session["WorkformWorksheetList"];
            if (obj == null)
            {
                obj = new List<string>();
            }
            return obj as List<string>;
        }

        public List<string> GetReportWorksheetList()
        {
            object obj = HttpContext.Current.Session["ReportWorksheetList"];
            if (obj == null)
            {
                obj = new List<string>();
            }
            return obj as List<string>;
        }

        public IQueryable<ReportGroup> GetByMaterialTypeID(int FKMaterialTypeID)
        {
            IQueryable<ReportGroup> reportGroups = dbContext.ReportGroup.Where(x=> x.FKMaterialTypeID == FKMaterialTypeID);
            return reportGroups;
        }
    }
}
