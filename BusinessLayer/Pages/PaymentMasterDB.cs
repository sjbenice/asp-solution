using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BusinessLayer.Pages
{
    public class PaymentMasterDB : DBBase<PaymentMaster, List<PaymentMaster>, long>
    {
        public override List<PaymentMaster> GetAll()
        {
            return (from x in (IQueryable<PaymentMaster>)dbContext.PaymentMaster
                    orderby x.PaymentDate descending
                    orderby x.PaymentID descending
                    select x).ToList();
        }

        public override PaymentMaster GetByID(long id)
        {
            return ((IQueryable<PaymentMaster>)dbContext.PaymentMaster).FirstOrDefault((PaymentMaster j) => j.PaymentID == id);
        }

        public override bool Insert(PaymentMaster entity, out string message)
        {
            message = "";
            try
            {
                dbContext.PaymentMaster.Add(entity);
                if (((DbContext)dbContext).SaveChanges() > 0)
                {
                    new SampleReceiveTestListDB().UpdateInvoiceedFromSession();
                    new WorkOrderListDB().UpdateInvoiceedFromSession();
                    HttpContext context = HttpContext.Current;
                    context.Session["PaymentID"] = entity.PaymentID;
                    return true;
                }
                message = "InsertError";
                return false;
            }
            catch (Exception)
            {
                message = "InsertError";
                return false;
            }
        }

        public override bool Update(PaymentMaster entity, out string message)
        {
            message = "";
            try
            {
                PaymentMaster byID = GetByID(entity.PaymentID);
                DbEntityEntry val = ((DbContext)dbContext).Entry<PaymentMaster>(byID);
                val.State = (EntityState)16;
                val.CurrentValues.SetValues((object)entity);
                if (((DbContext)dbContext).SaveChanges() > 0)
                {
                    //UpdateIsApproved(byID, bool isApproved);
                    return true;
                }
                message = "UpdateError";
                return false;
            }
            catch (Exception)
            {
                message = "";
                return false;
            }
        }
        //public bool UpdateIsApproved(long paymentID, bool isApproved)
        //{
        //    try
        //    {

        //        PaymentMaster paymentMaster = GetByID(paymentID);
        //        if (paymentMaster != null)
        //        {
        //            paymentMaster.IsApproved = isApproved;
        //            dbContext.SaveChanges();
        //            return true;
        //        }
        //        return false; // PaymentMaster with the given ID was not found
        //    }
        //    catch (Exception)
        //    {
        //        return false; // Handle exceptions and return false if an error occurs
        //    }
        //}

        public override bool Delete(PaymentMaster entity, out string message)
        {
            message = "";
            try
            {
                ((DbContext)dbContext).Entry<PaymentMaster>(entity).State = (EntityState)8;
                if (((DbContext)dbContext).SaveChanges() > 0)
                {
                    return true;
                }
                message = "DeleteError";
                return false;
            }
            catch (Exception)
            {
                message = "DeleteError";
                return false;
            }
        }

        public bool UpdateWithDetails(PaymentMaster entity, List<PaymentDetails> PaymentDetailsList, out string message)
        {
            message = "";
            try
            {
                PaymentMaster byID = GetByID(entity.PaymentID);
                DbEntityEntry val = ((DbContext)dbContext).Entry<PaymentMaster>(byID);
                val.State = (EntityState)16;
                val.CurrentValues.SetValues((object)entity);
                foreach (PaymentDetails PaymentDetails in PaymentDetailsList)
                {
                    PaymentDetails.FKPaymentID = entity.PaymentID;
                    new PaymentDetailsDB().Insert(PaymentDetails);
                }
                if (((DbContext)dbContext).SaveChanges() > 0)
                {
                    return true;
                }
                message = "UpdateError";
                return false;
            }
            catch (Exception)
            {
                message = "";
                return false;
            }
        }

        public bool Insert(PaymentMaster entity)
        {
            string message = "";
            object obj = HttpContext.Current.Session["InvoiceSelectedSession"];
            if (obj != null)
            {
                List<ViewInvoicesBalance> list = obj as List<ViewInvoicesBalance>;
                List<PaymentDetails> list2 = new List<PaymentDetails>();
                if (list.Count > 0)
                {
                    foreach (ViewInvoicesBalance item in list)
                    {
                        PaymentDetails paymentDetails = new PaymentDetails();
                        paymentDetails.FKInvoiceId = item.InvoiceId;
                        paymentDetails.PaidAmount = item.PaidAmount;
                        paymentDetails.PaymentDetID = list2.Count + 1;
                        list2.Add(paymentDetails);
                    }
                }
                entity.PaymentDetails = list2;
            }
            if (Insert(entity, out message))
            {
                return true;
            }
            throw new Exception(message);
        }

        public bool Update(PaymentMaster entity)
        {
            string message = "";
            if (Update(entity, out message))
            {
                return true;
            }
            throw new Exception(message);
        }

        public bool Delete(PaymentMaster entity)
        {
            string message = "";
            List<PaymentDetails> byMasterID = new PaymentDetailsDB().GetByMasterID(entity.PaymentID);
            foreach (PaymentDetails item in byMasterID)
            {
                new PaymentDetailsDB().Delete(item.PaymentDetID, out message);
            }
            if (Delete(entity, out message))
            {
                return true;
            }
            throw new Exception(message);
        }

        public List<ViewPendingPayment> GetAllPendingPayment()
        {
            //return ((IQueryable<ViewPendingPayment>)dbContext.ViewPendingPayment).Include("PaymentMaster").Where((ViewPendingPayment x) => x.TotalPendingAmount != null && x.TotalPendingAmount != (decimal?)0m &&
            //          x.IsApproved == true && x.IsRemoved == false).ToList();

            var Ids = dbContext.PaymentMaster.Where(x => x.IsApproved == true && x.IsRemoved == false).Select(x => x.FKJobOrderMasterID);

            var ans = (from VP in dbContext.ViewPendingPayment
                       where VP.TotalPendingAmount != null && VP.TotalPendingAmount != (decimal?)0m && Ids.Contains(VP.JobOrderMasterID)
                       select VP).ToList();
            return ans;

        }

        public List<PaymentMaster> GetAllPendingAvancedPayment()
        {
            return (from x in (IQueryable<PaymentMaster>)dbContext.PaymentMaster
                    where x.PaymentType == 1 && x.PaymentDetails.Count <= 0
                   
                    orderby x.PaymentDate descending
                    orderby x.PaymentID descending
                    select x).ToList();
        }

        public decimal? GetAllPendingAvancedPaymentAmountForJobOrder(long FKJobOrderMasterID)
        {
            return ((IEnumerable<SPPendingAdvancedPayment_Result>)dbContext.SPPendingAdvancedPayment(FKJobOrderMasterID)).Select((SPPendingAdvancedPayment_Result x) => x.PaymentAmount).FirstOrDefault();
        }

        public List<PaymentMaster> GetAllAdvancesPayment()
        {
            return (from x in (IQueryable<PaymentMaster>)dbContext.PaymentMaster
                    where x.PaymentType == 1 && x.PaymentDetails.Count > 0
                    orderby x.PaymentDate descending
                    orderby x.PaymentID descending
                    select x).ToList();
        }

        public List<PaymentMaster> GetAllAgainstInvoicePayment()
        {
            return (from x in (IQueryable<PaymentMaster>)dbContext.PaymentMaster
                        //where x.PaymentType == 0 && x.PaymentDetails.Count > 0
                    where x.IsApproved == true && x.IsRemoved == false
                    orderby x.ReferenceNumber descending
                    orderby x.PaymentDate descending
                    orderby x.PaymentID descending
                    //select x).ToList();
                    select x).ToList().OrderByDescending(o => o.ReferenceNumber)
                        .ThenByDescending(x => x.PaymentDate)
                        .ThenByDescending(x => x.PaymentID).ToList(); ;
        }
        public List<PaymentMaster> GetAllAgainstInvoiceAllNonApprovedAvancedPayment()
        {
            return (from x in (IQueryable<PaymentMaster>)dbContext.PaymentMaster
                    where /*(x.PaymentType == 0 || x.PaymentType == 1) &&*/
                    x.IsApproved == false && x.IsRemoved == false &&
                    x.PaymentDetails.Count <= 0
                    && (x.IsDeleted == null || x.IsDeleted == false)
                    orderby x.PaymentDate descending
                    orderby x.PaymentID descending
                    select x).ToList();
        }
        public int CountAllNonApprovedAvancedPayment()
        {
            return (from x in (IQueryable<PaymentMaster>)dbContext.PaymentMaster
                    where /*(x.PaymentType == 0 || x.PaymentType == 1) &&*/
                    x.IsApproved == false && x.IsRemoved == false &&
                    x.PaymentDetails.Count <= 0
                    && (x.IsDeleted == null || x.IsDeleted == false)
                    orderby x.PaymentDate descending
                    orderby x.PaymentID descending
                    select x).Count();
        }
        public List<PaymentMaster> GetAllAgainstInvoiceAllPendingAvancedPayment()
        {
            return (from x in (IQueryable<PaymentMaster>)dbContext.PaymentMaster
                    where /*(x.PaymentType == 0 || x.PaymentType == 1) &&*/
                    x.IsApproved == true && x.IsRemoved == false &&
                    x.PaymentDetails.Count <= 0
                    && (x.IsDeleted == null || x.IsDeleted == false)
                    orderby x.PaymentDate descending
                    orderby x.PaymentID descending
                    select x).ToList().OrderByDescending(o => (o.ReferenceNumber))
                        .ThenByDescending(x => x.PaymentDate)
                        .ThenByDescending(x => x.PaymentID).ToList(); ;
        }

        public long GetNewSerial()
        {
            var maxPaymentNo = GetMaxPaymentNo();
            return ((maxPaymentNo) + 1);
        }

        private long GetMaxPaymentNo()
        {
            //var maxAgeRecord = people.OrderByDescending(p => int.Parse(p.Age)).FirstOrDefault();
           //long? num = ((IQueryable<PaymentMaster>)dbContext.PaymentMaster).Max((Expression<Func<PaymentMaster, long?>>)((PaymentMaster entity) => entity.PaymentID));
           //long? num = ((IQueryable<PaymentMaster>)dbContext.PaymentMaster).OrderByDescending(x => x.PaymentID).Where(x => x.ReferenceNumber != "0").Max((Expression<Func<PaymentMaster, long?>>)((PaymentMaster entity) => entity.PaymentID));
            var num = ((IQueryable<PaymentMaster>)dbContext.PaymentMaster).ToList().OrderByDescending(x => x.ReferenceNumber).Where(x => x.ReferenceNumber != 0).Select(c => c.PaymentID).FirstOrDefault();

            if (num != 0)
            {

                var text = GetByID(num).ReferenceNumber;
                if (text == null)
                {
                    text = 0;
                }
                return text;
            }
            return 0;
        }
    }
}
