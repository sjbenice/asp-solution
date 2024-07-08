using BusinessLayer.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.SqlQueryModels
{
    //class SubcontractorService
    //{
    //}
    public class SubcontractorService
    {
        private SubcontractorsListDB subcontractorsListDB = new SubcontractorsListDB();

        public List<SubcontractorsList> GetSubcontractorsByStatus()
        {
            return subcontractorsListDB.GetSubcontractorsByStatus();
        }
    }

}
