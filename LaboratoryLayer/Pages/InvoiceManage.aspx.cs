using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace LaboratoryLayer.Pages
{
	// Token: 0x02000025 RID: 37
	public class InvoiceManage : Page
	{
		// Token: 0x0600014E RID: 334 RVA: 0x0000BF84 File Offset: 0x0000A184
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/InvoiceManage.aspx", long.Parse(this.Session["UserId"].ToString()));
			foreach (UserLinkOptionsView userLinkOptionsView in allOptionsForLink)
			{
				if (userLinkOptionsView.OptionEName == "Add")
				{
					this.lblAdd.Text = "True";
				}
				if (userLinkOptionsView.OptionEName == "Edit")
				{
					this.lblEdite.Text = "True";
				}
				if (userLinkOptionsView.OptionEName == "Delete")
				{
					this.lblDelete.Text = "True";
				}
				if (userLinkOptionsView.OptionEName == "View")
				{
					this.lblView.Text = "True";
				}
			}
			if (this.lblView.Text == "false")
			{
				this.btnPrint.Enabled = false;
				this.btnPrint.ToolTip = "You  dont have Permission to Print";
			}
			if (this.lblAdd.Text == "false")
			{
				this.btnAddNew.Enabled = false;
				this.btnAddNew.ToolTip = "You  dont have Permission to Add";
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvSampleReceiveList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00002EA6 File Offset: 0x000010A6
		protected void btnAddNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("CustomerInvoice.aspx");
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00002EB8 File Offset: 0x000010B8
		protected void GdvInvoice_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("CustomerInvoice.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00002ED4 File Offset: 0x000010D4
		protected void GdvInvoice_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.lblView.Text == "false" && e.ButtonID == "btnView")
			{
				e.Enabled = true;
			}
            if (e.ButtonID == "btnDeleteSR" && e.VisibleIndex >= 0)
            {
                var val = ((ASPxGridView)sender).GetRowValues(e.VisibleIndex, "IsDeleted");
                if (this.lblDelete.Text == "false" || (val != null && val.ToString().ToLower().Equals("true")))
                    e.Visible = DevExpress.Utils.DefaultBoolean.False;
            }
            if (e.ButtonID == "btnActivateSR" && e.VisibleIndex >= 0)
            {
                e.Visible = DevExpress.Utils.DefaultBoolean.False;
                //var val = ((ASPxGridView)sender).GetRowValues(e.VisibleIndex, "IsDeleted");
                //if (this.lblDelete.Text == "false")
                //    e.Visible = DevExpress.Utils.DefaultBoolean.False;
                //else if (val != null && val.ToString().ToLower().Equals("true"))
                //    e.Visible = DevExpress.Utils.DefaultBoolean.True;
                //else
                //{
                //    e.Visible = DevExpress.Utils.DefaultBoolean.False;
                //}
            }
        }

		// Token: 0x06000153 RID: 339 RVA: 0x0000C0EC File Offset: 0x0000A2EC
		protected void GdvInvoice_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
		{
			if (this.lblEdite.Text == "false" && e.ButtonType == ColumnCommandButtonType.Edit)
			{
				e.Visible = false;
			}
            else if (this.lblDelete.Text != "false" && e.ButtonType == ColumnCommandButtonType.Edit && e.VisibleIndex >= 0)
            {
                var val = ((ASPxGridView)sender).GetRowValues(e.VisibleIndex, "IsDeleted");
                if (val != null && val.ToString().ToLower().Equals("true"))
                    e.Visible = false;
                else
                {
                    e.Visible = true;
                }
            }
            if (this.lblDelete.Text == "false" && e.ButtonType == ColumnCommandButtonType.Delete)
			{
				e.Visible = false;
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00002F06 File Offset: 0x00001106
		protected void GdvInvoice_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvInvoice.JSProperties["cpFilter"] = this.GdvInvoice.FilterExpression;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000C148 File Offset: 0x0000A348
		protected void GdvInvoice_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = "SaveError";
			}
			if (e.Exception.InnerException.Message == "This Invoice Linked With payment ")
			{
				e.ErrorText = "This Invoice Linked With payment ";
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000C19C File Offset: 0x0000A39C
		protected void GdvInvoice_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
		{
			string resourceKey = "";
			int num = Convert.ToInt32(e.Keys[this.GdvInvoice.KeyFieldName].ToString());
			Invoice byID = new InvoiceDB().GetByID((long)num);
			if (byID != null)
			{
				if (new InvoiceDB().Delete(byID))
				{
					this.GdvInvoice.DataBind();
					e.Cancel = true;
					return;
				}
				e.Cancel = true;
				string value = base.GetGlobalResourceObject("GLobalMessages", resourceKey).ToString().Replace("{0}", base.GetLocalResourceObject("ErrorTitle").ToString());
				((ASPxGridView)sender).JSProperties["cpDeleteError"] = value;
			}
		}

		// Token: 0x040001C3 RID: 451
		protected HtmlGenericControl ultitle;

		// Token: 0x040001C4 RID: 452
		protected ASPxLabel lblView;

		// Token: 0x040001C5 RID: 453
		protected ASPxLabel lblEdite;

		// Token: 0x040001C6 RID: 454
		protected ASPxLabel lblDelete;

		// Token: 0x040001C7 RID: 455
		protected ASPxLabel lblAdd;

		// Token: 0x040001C8 RID: 456
		protected ASPxButton btnAddNew;

		// Token: 0x040001C9 RID: 457
		protected ASPxButton btnPrint;

		// Token: 0x040001CA RID: 458
		protected ASPxGridView GdvPendingInvoice;

		// Token: 0x040001CB RID: 459
		protected GridViewCommandColumnCustomButton btnConvert;

		// Token: 0x040001CC RID: 460
		protected ASPxGridView GdvIdelService;

		// Token: 0x040001CD RID: 461
		protected ASPxGridView GdvInvoice;

		// Token: 0x040001CE RID: 462
		protected GridViewCommandColumnCustomButton btnView;

		// Token: 0x040001CF RID: 463
		protected ObjectDataSource CustomersListDS;

		// Token: 0x040001D0 RID: 464
		protected ObjectDataSource ProjectsListDS;

		// Token: 0x040001D1 RID: 465
		protected ObjectDataSource InvoiceDS;

		// Token: 0x040001D2 RID: 466
		protected ObjectDataSource PendingInvoiceDS;

		// Token: 0x040001D3 RID: 467
		protected ObjectDataSource IdelServiceDS;

		// Token: 0x040001D4 RID: 468
		protected ObjectDataSource JobOrderDS;

        // Token: 0x04000259 RID: 601
        protected ASPxMemo txtDeleteReason;

        // Token: 0x04000260 RID: 602
        protected ASPxTextBox sid;

        // Token: 0x04000261 RID: 603
        protected ASPxPopupControl popupDelete;

        // Token: 0x04000262 RID: 604
        protected ASPxPopupControl popupActivate;

        protected void btnSaveDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeleteReason.Text))
                return;
            if (string.IsNullOrWhiteSpace(sid.Text) || sid.Text == "0")
                return;

            var service = new BusinessLayer.Pages.InvoiceDB();
            var obj = service.GetByID(Convert.ToInt64(sid.Text));
            if (obj != null)
            {
                var service1 = new SampleReceiveTestListDB();
                foreach (var item in obj.SampleReceiveTestInvoice)
                {
                    var obj1 = service1.GetByID(item.FkSampleReceiveTestID);
                    if (obj1 != null)
                    {
                        obj1.IsApproved = false;
                        obj1.IsInvoiced = false;
                        service1.Update(obj1);
                    }
                }
                obj.IsDeleted = true;
                obj.ReasonForDelete = txtDeleteReason.Text;
                service.Update(obj);

                txtDeleteReason.Text = "";
                //popupDelete.ShowOnPageLoad = false;
                var delink = new BusinessLayer.Pages.PaymentDetailsDB();
                if (delink != null)
                {
                    List<PaymentDetails> paymentDetailsList = delink.GetByInvoiceID(Convert.ToInt64(sid.Text));
                    //List<PaymentDetails> paymentDetailsList1 = delink.GetByInvoiceID(Convert.ToInt64(paymentDetailsList.));

                    foreach (var paymentDetail in paymentDetailsList)
                    {
                        // Process each paymentDetail
                        string message;
                        bool deleteResult = delink.Delete(paymentDetail, out message);

                        if (deleteResult)
                        {
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine($"Failed to delete entity. Error message: {message}");
                        }
                        List<PaymentDetails> paymentid = delink.GetInByPayId(Convert.ToInt64(paymentDetail.FKPaymentID));
                        foreach (var paymentDetail1 in paymentid)
                        {
                            // Process each paymentDetail
                            string message1;
                            bool deleteResult1 = delink.Delete(paymentDetail1, out message1);

                            if (deleteResult1)
                            {
                                Console.WriteLine(message1);
                            }
                            else
                            {
                                Console.WriteLine($"Failed to delete entity. Error message: {message1}");
                            }
                        }
                    }
                }

                string Deletemessage;
                int num = Convert.ToInt32(obj.InvoiceId.ToString());
                Invoice byID = new InvoiceDB().GetByID((long)num);
                if (byID != null)
                {
                    if (new InvoiceDB().Delete(byID))
                    {
                        //Deletemessage = true;
                        Console.WriteLine(Deletemessage = "Deleted");
                        //return;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to delete entity. Error message: {Deletemessage = "Error"}");
                        //return;
                    }
                }

                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
        
        protected void btnSaveActivate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sid.Text) || sid.Text == "0")
                return;

            var service = new BusinessLayer.Pages.InvoiceDB();
            var obj = service.GetByID(Convert.ToInt64(sid.Text));
            if (obj != null)
            {
                obj.IsDeleted = false;
                obj.ReasonForDelete = "";
                service.Update(obj);
                //popupActivate.ShowOnPageLoad = false;
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
    }
}
