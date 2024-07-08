using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.SqlQueryModels
{
    public class TestReporting
    {
        public long TestReportingID { get; set; }
        public long FKSampleReceiveTestID { get; set; }
        public int StatusID { get; set; }
        public int RevisionNo { get; set; }
        public bool IsRevised { get; set; }
        public string SampleNumber { get; set; }
        public int FKProjectID { get; set; }
        public int FKTestID { get; set; }
        public int FKCustomerID { get; set; }
        public int ReportNumber { get; set; }
        
        public int TestRequiredTime { get; set; }
        public DateTime SampleReceivedDate { get; set; }

        public string WorkFormFileName { get; set; }
        public DateTime? TestEndingDate { get; set; }
        public DateTime? ReportingDate{ get; set; }
        public DateTime? EnteredDate { get; set; }
        public DateTime? CheckedDate { get; set; }
        public DateTime? SuggestedTestingDate { get; set; }
        public string LabName { get; set; }
        public string TestName { get; set; }
        public string CustomerName { get; set; }

        public string StandardNumber { get; set; }

    }
}
