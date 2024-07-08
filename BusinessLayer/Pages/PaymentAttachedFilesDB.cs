using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Transactions;
using System.Web;

namespace BusinessLayer.Pages
{
    public class PaymentAttachedFilesDB : DBBase<PaymentAttachedFile, List<PaymentAttachedFile>, long>
    {

        public override List<PaymentAttachedFile> GetAll()
        {
            return ((IEnumerable<PaymentAttachedFile>)dbContext.PaymentAttachedFiles).ToList();
        }

        public override PaymentAttachedFile GetByID(long id)
        {
            return ((IQueryable<PaymentAttachedFile>)dbContext.PaymentAttachedFiles).FirstOrDefault((PaymentAttachedFile j) => j.FileID == id);
        }

        public List<PaymentAttachedFile> GetByPaymentID(long id)
        {
            return ((IEnumerable<PaymentAttachedFile>)dbContext.PaymentAttachedFiles.Where(x=>x.FKPaymentID == id)).ToList();
        }

        public override bool Insert(PaymentAttachedFile entity, out string message)
        {
            message = "";
            try
            {
                dbContext.PaymentAttachedFiles.Add(entity);
                if (((DbContext)dbContext).SaveChanges() > 0)
                {
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
        public bool Insert(PaymentAttachedFile entity)
        {
            string message = "";
            if (Insert(entity, out message))
            {
                return true;
            }
            throw new Exception(message);
        }

        public bool Update(PaymentAttachedFile entity)
        {
            string message = "";
            if (Update(entity, out message))
            {
                return true;
            }
            throw new Exception(message);
        }
        public override bool Update(PaymentAttachedFile entity, out string message)
        {
            message = "";
            bool result;
            try
            {
                PaymentAttachedFile byID = this.GetByID(entity.FileID);
                DbEntityEntry dbEntityEntry = this.dbContext.Entry<PaymentAttachedFile>(byID);
                dbEntityEntry.State = EntityState.Modified;
                dbEntityEntry.CurrentValues.SetValues(entity);
                if (this.dbContext.SaveChanges() > 0)
                {
                    result = true;
                }
                else
                {
                    message = "UpdateError";
                    result = false;
                }
            }
            catch (Exception)
            {
                message = "";
                result = false;
            }
            return result;
        }


        public bool Delete(PaymentAttachedFile entity)
        {
            string message = "";
            if (Delete(entity, out message))
            {
                return true;
            }
            throw new Exception(message);
        }

        public override bool Delete(PaymentAttachedFile entity, out string message)
        {
            message = "";
            bool result;
            try
            {
                this.dbContext.Entry<PaymentAttachedFile>(entity).State = EntityState.Deleted;
                if (this.dbContext.SaveChanges() > 0)
                {
                    result = true;
                }
                else
                {
                    message = "DeleteError";
                    result = false;
                }
            }
            catch (Exception)
            {
                message = "DeleteError";
                result = false;
            }
            return result;
        }

    }
}
