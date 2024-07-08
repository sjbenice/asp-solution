using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BusinessLayer.Pages
{
	public class SampleReceiveListDB : DBBase<SampleReceiveList, List<SampleReceiveList>, long>
	{
        public override List<SampleReceiveList> GetAll()
        {
            List<SampleReceiveList> sampleList = ((IQueryable<SampleReceiveList>)dbContext.SampleReceiveList.AsNoTracking()).OrderByDescending((SampleReceiveList x) => x.SampleID).ToList();
            List<SampleReceiveList> newSampleList = new List<SampleReceiveList>();
            if (sampleList.Count > 0)
            {
                var lst = dbContext.Database.SqlQuery<SqlQueryModels.SampleReceiveListReportNumbers>(@"
                with z as(select sr.SampleID,ReportNumber from SampleReceiveTestList srt
                inner join SampleReceiveList sr on srt.FKSampleID=sr.SampleID
                where ReportNumber is not null
                )
                select distinct SampleID,STUFF((SELECT distinct ', ' + cast(ReportNumber as nvarchar(15))
                           FROM z z1
                           WHERE z.SampleID=z1.SampleID
                          FOR XML PATH('')), 1, 2, '') ReportNumber
                from z
                ").ToList();

                //                var lst = dbContext.Database.SqlQuery<SqlQueryModels.SampleReceiveListReportNumbers>(@"
                //WITH z AS (
                //    SELECT sr.SampleID, ReportNumber
                //    FROM SampleReceiveTestList srt
                //    INNER JOIN SampleReceiveList sr ON srt.FKSampleID = sr.SampleID
                //    WHERE ReportNumber IS NOT NULL
                //)
                //SELECT SampleID, STRING_AGG(CONVERT(NVARCHAR(15), ReportNumber), ', ') WITHIN GROUP (ORDER BY ReportNumber) AS ReportNumber
                //FROM z
                //GROUP BY SampleID;
                //").ToList();

                var _lst = (from a in sampleList
                            join b in lst
                            on a.SampleID equals b.SampleID into combinedObj
                            from subObject in combinedObj.DefaultIfEmpty()
                            select ((Func<SampleReceiveList>)(() =>
                            {
                                a.ReportNumber = ((subObject == null) ? a.ReportNumber : subObject.ReportNumber);
                                return a;
                            }))()).ToList();
                //sampleList.ForEach(x =>
                //{
                //    x.ReportNumber = lst.Where(y => y.SampleID == x.SampleID).FirstOrDefault()?.ReportNumber ?? x.ReportNumber;
                //});
                //return sampleList;
                return _lst;

                /*List<SampleReceiveTestList> testLists = dbContext.SampleReceiveTestList.ToList();                                
                foreach (SampleReceiveList sr in sampleList)
                {
                    
                    List<SampleReceiveTestList> testList = testLists.Where(t => t.FKSampleID == sr.SampleID).ToList();
                    if (testList.Count > 0)
                    {
                        List<string> list = new List<string>();
                        foreach (SampleReceiveTestList rt in testList)
                        {
                            if (rt.ReportNumber.HasValue)
                                list.Add(rt.ReportNumber.Value.ToString());
                        }
                        sr.ReportNumber = string.Join(", ", list);
                        newSampleList.Add(sr);
                    }
                    else
                        newSampleList.Add(sr);
                }*/
            }

            return newSampleList;
        }

		public override SampleReceiveList GetByID(long id)
		{
			return ((IQueryable<SampleReceiveList>)dbContext.SampleReceiveList).FirstOrDefault((SampleReceiveList j) => j.SampleID == id);
		}

		public override bool Insert(SampleReceiveList entity, out string message)
		{
			message = "";
			try
			{
                string[] pdfFiles = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Uploaded/SampleReceive"), entity.SampleNo + "-R*.pdf")
                            .Select(Path.GetFileName)
                  .ToArray();
                entity.RevisionNumber = pdfFiles.Count() + 1;

                var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(entity);

                if (!System.ComponentModel.DataAnnotations.Validator.TryValidateObject(entity, validationContext, validationResults, true))
                {
                    // Entity validation failed, handle the validation results
                    foreach (var validationResult in validationResults)
                    {
                        // Log or handle the validation error
                        Console.WriteLine(validationResult.ErrorMessage);
                    }
                }
                //entity.RevisionNumber++;
                var state = dbContext.Entry(entity).State;
                if (dbContext.Entry(entity).State != EntityState.Detached)
                {
                    dbContext.Entry(entity).State = EntityState.Detached;
                }

                dbContext.SampleReceiveList.Add(entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
                    if (entity.FKRSSMasterId.HasValue)
					{
						RSSMaster byID = new RSSMasterDB().GetByID(entity.FKRSSMasterId.Value);
						byID.IsSampled = true;
						new RSSMasterDB().Update(byID);
					}

                    Tuple<bool, string> status = new ExcelGroupHandlingCLS().GenerateXlsBySampleID(entity.SampleID);
                    if (!status.Item1)
					{
						throw new Exception("Sample Receive Added Sucessfully ,but Workform Excel Faild, Please Add Information Link In Service Information Page \n" + status.Item2);
					}

                    HttpContext context = HttpContext.Current;
                    context.Session["SampleID"] = entity.SampleID;

                    return true;
				}
				message = "InsertError";
				return false;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				return false;
			}
		}

		public override bool Update(SampleReceiveList entity, out string message)
		{
			message = "";
			try
			{
                //entity.RevisionNumber++;
                
                string[] pdfFiles = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Uploaded/SampleReceive"), entity.SampleNo + "-R*.pdf")
                                   .Select(Path.GetFileName)
                                   .ToArray();
                entity.RevisionNumber = pdfFiles.Count() + 1;

                SampleReceiveList byID = GetByID(entity.SampleID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<SampleReceiveList>(byID);
				val.State = (EntityState)16;
				val.CurrentValues.SetValues((object)entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					new ExcelGroupHandlingCLS().GenerateXlsBySampleID(entity.SampleID);
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

		public override bool Delete(SampleReceiveList entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<SampleReceiveList>(entity).State = (EntityState)8;
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					if (entity.FKRSSMasterId.HasValue)
					{
						RSSMaster byID = new RSSMasterDB().GetByID(entity.FKRSSMasterId.Value);
						byID.IsSampled = false;
						new RSSMasterDB().Update(byID);
					}
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

		public bool Insert(SampleReceiveList entity)
		{
			string message = "";
			object obj = HttpContext.Current.Session["SampleReceiveTestList"];
			object obj2 = HttpContext.Current.Session["SampleMaterialCustomFieldList"];
			object obj3 = HttpContext.Current.Session["SampleMaterialTableCustomFieldList"];
			if (obj != null)
			{
				List<SampleReceiveTestList> list = obj as List<SampleReceiveTestList>;
				if (list.Count > 0)
				{
                    if (entity.FKJobOrderMasterID > 0)
                    {
                        JobOrderMaster jobOrderMaster  = new JobOrderMasterDB().GetByID((long)entity.FKJobOrderMasterID);
                        if (jobOrderMaster != null)
                        {
                            if (jobOrderMaster.StatusID == 1)
                            {
                                foreach (SampleReceiveTestList sampleReceiveTestList in list)
                                {
                                    TestReporting testReporting = new TestReporting();
                                    testReporting.FKSampleReceiveTestID = sampleReceiveTestList.SampleReceiveTestID;
                                    sampleReceiveTestList.TestReportings.Add(testReporting);
                                }
                            }
                        }
                    }

                    entity.SampleReceiveTestList = list;
				}
			}
			if (obj2 != null)
			{
				List<SampleReceiveMaterialCustomField> list2 = obj2 as List<SampleReceiveMaterialCustomField>;
				if (list2.Count > 0)
				{
					entity.SampleReceiveMaterialCustomField = list2;
				}
			}
			if (obj3 != null)
			{
				List<SampleReceiveMaterialTableCustomField> list3 = obj3 as List<SampleReceiveMaterialTableCustomField>;
				if (list3.Count > 0)
				{
					entity.SampleReceiveMaterialTableCustomField = list3;
				}
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(SampleReceiveList entity)
		{
			string message = "";
            object obj2= HttpContext.Current.Session["SampleReceiveTestList"];

            new SampleReceiveTestListDB().UpdateDetailsFromSession(entity.SampleID);
			new SampleReceiveMaterialTableCustomFieldDB().UpdateDetailsFromSession(entity.SampleID);

            object obj = HttpContext.Current.Session["SampleReceiveTestList"];

            if (obj2 != null)
            {
                List<SampleReceiveTestList> list = obj2 as List<SampleReceiveTestList>;
                if (list.Count > 0)
                {
                    if (entity.FKJobOrderMasterID > 0)
                    {
                        JobOrderMaster jobOrderMaster = new JobOrderMasterDB().GetByID((long)entity.FKJobOrderMasterID);
                        if (jobOrderMaster != null)
                        {
                            if (jobOrderMaster.StatusID == 1)
                            {
                                foreach (SampleReceiveTestList sampleReceiveTestList in list)
                                {
                                    TestReporting testReporting = new TestReporting();
                                    var rs = dbContext.TestReportings.Where(x => x.FKSampleReceiveTestID == sampleReceiveTestList.SampleReceiveTestID).ToList();
                                    if (rs != null && rs.Count > 0)
                                    {

                                    }
                                    else
                                    {


                                        testReporting.FKSampleReceiveTestID = sampleReceiveTestList.SampleReceiveTestID;
                                        sampleReceiveTestList.TestReportings.Add(testReporting);
                                        if (sampleReceiveTestList.ReportNumber > 0)
                                        {
                                            dbContext.TestReportings.Add(testReporting);
                                            dbContext.SaveChanges();
                                        }

                                    }
                                }
                            }
                        }
                    }

                    entity.SampleReceiveTestList = list;
                }
            }

            if (Update(entity, out message))
			{
				return true;
			}

			throw new Exception(message);
		}

		public bool Delete(SampleReceiveList entity)
		{
			string message = "";
			List<SampleReceiveTestList> byMasterID = new SampleReceiveTestListDB().GetByMasterID(entity.SampleID);
			foreach (SampleReceiveTestList item in byMasterID)
			{
				List<SampleReceiveTestInvoice> byMasterID2 = new SampleReceiveTestInvoiceDB().GetByMasterID(item.SampleReceiveTestID);
				if (byMasterID2.Count > 0)
				{
					throw new Exception("Can't delete,already invoiced");
				}
			}
			foreach (SampleReceiveTestList item2 in byMasterID)
			{
				new SampleReceiveTestListDB().Delete(item2.SampleReceiveTestID, out message);
			}
			List<SampleReceiveMaterialCustomField> bySampleId = new SampleReceiveMaterialCustomFieldDB().GetBySampleId(entity.SampleID);
			foreach (SampleReceiveMaterialCustomField item3 in bySampleId)
			{
				new SampleReceiveMaterialCustomFieldDB().Delete(item3.SampleReceiveCFLinkID, out message);
			}
			List<SampleReceiveMaterialTableCustomField> bySampleId2 = new SampleReceiveMaterialTableCustomFieldDB().GetBySampleId(entity.SampleID);
			foreach (SampleReceiveMaterialTableCustomField item4 in bySampleId2)
			{
				new SampleReceiveMaterialTableCustomFieldDB().Delete(item4.SampleReceiveTCFLinkID, out message);
			}
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public string GetNewSerial()
		{
			string maxSampleNumber = GetMaxSampleNumber();
			if (maxSampleNumber != null)
			{
                return maxSampleNumber;
            }
			return "1";
		}

		private string GetMaxSampleNumber()
		{
			long? num = ((IQueryable<SampleReceiveList>)dbContext.SampleReceiveList).Max((Expression<Func<SampleReceiveList, long?>>)((SampleReceiveList entity) => entity.SampleID));
			if (num.HasValue)
			{
				string text = GetByID(num.Value).SampleNo;
				if (text == null)
				{
					text = "0";
				}
                else if (!text.Contains("S-"))
                    text = "S-15000";
                else
                {
                    string[] splittedSampleNo = text.Split('-');
                    int sampleNo = Convert.ToInt32(splittedSampleNo[1]) + 1;
                    text = "S-" + sampleNo;
                }
                return text;
			}
			return "0";
		}

        public bool IsInvoiced(long sampleid)
        {
            int count = dbContext.Database.SqlQuery<int>($@"
select COUNT(d.InvoiceId) totalinvoices from SampleReceiveList a
inner join SampleReceiveTestList b on a.SampleID=b.FKSampleID
inner join SampleReceiveTestInvoice c on c.FkSampleReceiveTestID=b.SampleReceiveTestID
inner join Invoice d on d.InvoiceId = c.FkInvoiceId
where (d.IsDeleted is null or d.IsDeleted=0) and a.SampleID={sampleid}
").First();
            if (count >= 1)
                return true;
            else
                return false;
        }

		public List<SampleReceiveList> GetByJobOrderID(long id)
		{
			return (from j in (IQueryable<SampleReceiveList>)dbContext.SampleReceiveList
				where j.FKJobOrderMasterID == (long?)id
				select j into x
				orderby x.SampleID descending
				select x).ToList();
		}

		public List<SampleReceiveList> GetByRssMasterID(long RssMasterID)
		{
			return ((IQueryable<SampleReceiveList>)dbContext.SampleReceiveList).Where((SampleReceiveList j) => j.FKRSSMasterId == (long?)RssMasterID).ToList();
		}

		public ViewN_OFUnPaidBills GetNOfUnpaidBills(long JOMasterID)
		{
			ViewN_OFUnPaidBills viewN_OFUnPaidBills = ((IQueryable<ViewN_OFUnPaidBills>)dbContext.ViewN_OFUnPaidBills).Where((ViewN_OFUnPaidBills j) => j.JobOrderMasterID == JOMasterID).FirstOrDefault();
			if (viewN_OFUnPaidBills == null)
			{
				viewN_OFUnPaidBills = new ViewN_OFUnPaidBills();
			}
			return viewN_OFUnPaidBills;
		}
	}
}
