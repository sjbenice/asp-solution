using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class ViewLateReportListDB : DBBase<ViewLateReport, List<ViewLateReport>, int>
	{
        public override bool Delete(ViewLateReport entity, out string message)
        {
            throw new NotImplementedException();
        }

        public override List<ViewLateReport> GetAll()
		{
			return ((IEnumerable<ViewLateReport>)dbContext.AccreditionList).ToList();
		}

        public override ViewLateReport GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Insert(ViewLateReport entity, out string message)
        {
            throw new NotImplementedException();
        }

        public override bool Update(ViewLateReport entity, out string message)
        {
            throw new NotImplementedException();
        }
    }
}
