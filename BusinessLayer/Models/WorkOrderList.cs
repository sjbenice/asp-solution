using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public partial class WorkOrderList
    {
        public long FKJobOrderMasterID { get; set; }
        public int RowStatus { get; set; }
        public decimal? DueAmount { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsChecked { get; set; }
        public bool IsApproved { get; set; }
        public bool IsInvoiced { get; set; }
    }
    public partial class JobOrderDetails
    {
        public int RowStatus { get; set; }
        public int Status { get; set; }
    }
    public partial class SampleReceiveTestList
    {
        public int RowStatus { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsSelected { get; set; }
        public decimal MinQty { get; set; }
        public int? FKGroupID { get; set; }
    }
    public partial class TestReporting
    {
 
        public string SampleNumber { get; set; }
        public int FKProjectID { get; set; }
        public int FKTestID { get; set; }
        public int FKCustomerID { get; set; }
        public int ReportNumber { get; set; }
        public string FileUrl { get; set; }
        public string StandardNumber { get; set; }
        public string CustomerName { get; set; }
        public string TestName { get; set; }
        public int TestRequiredTime { get; set; }

        public string LabName { get; set; }
        public DateTime SampleReceivedDate { get; set; }
        public bool Revised
        {
            get
            {
                bool isRevised = !IsRevised;
                return isRevised;
            }
        }
    }
    public partial class SampleReceiveMaterialTableCustomField
    {
        public int RowStatus { get; set; }

       
    }
    public partial class ValidityListDetails
    {
        public string Status { get; set; }
      
    }
    public partial class QuotationWorkOrderList
    {
        public long FKQuotationMasterID { get; set; }
        public int RowStatus { get; set; }

        
    }
    public partial class SampleReceiveList
    {
       
        public string ReportNumber { get; set; }
       
        
        

       
    }
    public partial class SampleReceiveMaterialCustomField
    {
        public int RowStatus { get; set; }


    }
    public partial class RSSDetails
    {
        public bool IsEnabled { get; set; }
        public bool IsSelected { get; set; }

        
    }
    public partial class PriceUnitList
    {
        public decimal MinimumPrice { get; set; }
        public decimal DefaultPrice { get; set; }
    }
   

   
}

