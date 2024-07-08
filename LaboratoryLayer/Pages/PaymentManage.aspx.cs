using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using DevExpress.Web;
using System.Linq;
using BusinessLayer.Pages;



namespace LaboratoryLayer.Pages
{
	// Token: 0x02000023 RID: 35
	public class PaymentManage : Page
	{
        // Token: 0x060000EB RID: 235 RVA: 0x00002AC5 File Offset: 0x00000CC5
        protected void GdvPendingAdvancedPayment_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            ASPxWebControl.RedirectOnCallback("PaymentInfo.aspx?id=" + e.KeyValue.ToString());
        }

        // Token: 0x0600012E RID: 302 RVA: 0x0000B030 File Offset: 0x00009230
        protected void Page_Load(object sender, EventArgs e)
		{
            var roleLinks = new UserRolesDB().GetAllOptionsForUser(int.Parse(this.Session["UserId"].ToString()));
            if (roleLinks.Any(c => c.LinksEName == "Payment Manage" && c.OptionEName == "View"))
            {
                this.GdvWaitingApprovalAdvancedPayment.Visible = true;
            }
            else
            {
                this.GdvWaitingApprovalAdvancedPayment.Visible = false;
            }
            List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/PaymentManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
            if (!Page.IsPostBack)
            {
                GdvPendingPayment.Columns[0].Visible = false;
            }
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00007324 File Offset: 0x00005524
		protected void GdvSampleReceiveList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00002D2E File Offset: 0x00000F2E
		protected void btnAddNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("PaymentInfo.aspx");
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00002D40 File Offset: 0x00000F40
		protected void GdvPaymentHistory_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("PaymentInfo.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00002D5C File Offset: 0x00000F5C
		protected void GdvPaymentHistory_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.lblView.Text == "false" && e.ButtonID == "btnView")
			{
				e.Enabled = false;
			}
            if (e.ButtonID == "btnDeleteSR" && e.VisibleIndex >= 0)
            {
                var val = ((ASPxGridView)sender).GetRowValues(e.VisibleIndex, "IsDeleted");
                if (this.lblDelete.Text == "false" || (val != null && val.ToString().ToLower().Equals("true")))
                    e.Visible = DevExpress.Utils.DefaultBoolean.False;
            }
        }

		// Token: 0x06000133 RID: 307 RVA: 0x0000B198 File Offset: 0x00009398
		protected void GdvPaymentHistory_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x06000134 RID: 308 RVA: 0x00002D8E File Offset: 0x00000F8E
		protected void GdvPaymentHistory_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvPaymentHistory.JSProperties["cpFilter"] = this.GdvPaymentHistory.FilterExpression;
		}

		// Token: 0x04000170 RID: 368
		protected HtmlGenericControl ultitle;

		// Token: 0x04000171 RID: 369
		protected ASPxLabel lblView;

		// Token: 0x04000172 RID: 370
		protected ASPxLabel lblEdite;
        protected GridViewCommandColumnCustomButton btnApproveImage1;

        // Token: 0x04000173 RID: 371
        protected ASPxLabel lblDelete;

		// Token: 0x04000174 RID: 372
		protected ASPxLabel lblAdd;

		// Token: 0x04000175 RID: 373
		protected ASPxButton btnAddNew;

		// Token: 0x04000176 RID: 374
		protected ASPxButton btnPrint;

		// Token: 0x04000177 RID: 375
		protected ASPxGridView GdvPendingPayment;

		// Token: 0x04000178 RID: 376
		protected GridViewCommandColumnCustomButton btnConvert;

		// Token: 0x04000179 RID: 377
		protected ASPxGridView GdvPaymentHistory;

		// Token: 0x0400017A RID: 378
		protected GridViewCommandColumnCustomButton btnView;

		// Token: 0x0400017B RID: 379
		protected ObjectDataSource CustomersListDS;

		// Token: 0x0400017C RID: 380
		protected ObjectDataSource PaymentHistoryDS;

		// Token: 0x0400017D RID: 381
		protected ObjectDataSource PendingPaymentDS;

		// Token: 0x0400017E RID: 382
		protected ObjectDataSource JobOrderDS;

        // Token: 0x04000259 RID: 601
        protected ASPxMemo txtDeleteReason;

        // Token: 0x04000260 RID: 602
        protected ASPxTextBox sid;

        // Token: 0x04000261 RID: 603
        protected ASPxPopupControl popupDelete;

        protected ASPxGridView GdvWaitingApprovalAdvancedPayment;
       
        protected void btnSaveDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeleteReason.Text))
                return;
            if (string.IsNullOrWhiteSpace(sid.Text) || sid.Text == "0")
                return;

            var service = new BusinessLayer.Pages.PaymentMasterDB();
            var obj = service.GetByID(Convert.ToInt64(sid.Text));
            if (obj != null)
            {
                obj.IsDeleted = true;
                obj.ReasonForDelete = txtDeleteReason.Text;
                service.Update(obj);
                txtDeleteReason.Text = "";
                //popupDelete.ShowOnPageLoad = false;
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }


        protected void GdvWaitingApprovalAdvancedPayment_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
            var roleLinks = new UserRolesDB().GetAllOptionsForUser(int.Parse(this.Session["UserId"].ToString()));
            if (!roleLinks.Any(c => c.LinksEName.Trim() == "Approve waiting for approval payment") && e.ButtonID == "btnApproveImage1")
            {
                e.Enabled = false;
                //this.btnApproveImage.Enabled = false;
            }
        }

        protected void GdvWaitingApprovalAdvancedPayment_CustomButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            if (this.lblEdite.Text == "false" && e.ButtonType == ColumnCommandButtonType.Edit)
            {
                e.Enabled = false;
                ////this.btnApproveImage.Enabled = false;

            }
        }
        protected void GdvPendingAdvancedPayment_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
           var roleLinks = new UserRolesDB().GetAllOptionsForUser(int.Parse(this.Session["UserId"].ToString()));
            if (!roleLinks.Any(c => c.LinksEName.Trim() == "Pending Advanced Paymnet") && e.ButtonID == "btnConvert1")
            {
                e.Enabled = false;
                //this.btnApproveImage.Enabled = false;
            }
        }

        protected void GdvPendingAdvancedPayment_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            if (this.lblEdite.Text == "false" && e.ButtonType == ColumnCommandButtonType.Edit)
            {
                e.Enabled = false;
            }
        }

        protected void GdvPendingPayment_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
            if (this.lblEdite.Text == "false" && e.ButtonID == "btnConvert")
            {
                e.Enabled = false;
            }
        }

        protected void GdvPendingPayment_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            if (this.lblEdite.Text == "false" && e.ButtonType == ColumnCommandButtonType.Edit)
            {
                e.Enabled = false;
            }
        }

        protected void GdvWaitingApprovalAdvancedPayment_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            ASPxWebControl.RedirectOnCallback("PaymentInfo.aspx?id=" + e.KeyValue.ToString() + "_CanApprove");
        }

        protected void cbApprove_CheckedChanged(object sender, EventArgs e)
        {
            ASPxCheckBox editInvoiceDetails = (ASPxCheckBox)sender;
            var id =((GridViewDataItemTemplateContainer)editInvoiceDetails.Parent).KeyValue;

            //List<object> keyValues = editInvoiceDetails.GetSelectedFieldValues("GdvWaitingApprovalAdvancedPayment");
            PaymentMaster masterEntity = new PaymentMasterDB().GetByID(int.Parse(id.ToString()));
            masterEntity.IsApproved = true;
            masterEntity.IsRemoved = false;
            masterEntity.ReferenceNumber = new PaymentMasterDB().GetNewSerial();
            if (masterEntity.ReferenceNumber < 5501)
                masterEntity.ReferenceNumber = 5501;
            new PaymentMasterDB().Update(masterEntity);
            base.Response.Redirect("PaymentManage.aspx");
        }

        //protected void btnApproveImage_Click(object sender, EventArgs e)
        //{
        //    ASPxButton editInvoiceDetails = (ASPxButton)sender;
        //    var id = ((GridViewDataItemTemplateContainer)editInvoiceDetails.Parent).KeyValue;
        //    base.Response.Redirect("PaymentInfo.aspx?id=" + id + "_CanApprove");

        //    //List<object> keyValues = editInvoiceDetails.GetSelectedFieldValues("GdvWaitingApprovalAdvancedPayment");
        //    //PaymentMaster masterEntity = new PaymentMasterDB().GetByID(int.Parse(id.ToString()));
        //    //masterEntity.IsApproved = true;
        //    //masterEntity.IsRemoved = false;
        //    //masterEntity.ReferenceNumber = new PaymentMasterDB().GetNewSerial();
        //    //int refnum = 0;
        //    //if (int.TryParse(masterEntity.ReferenceNumber, out refnum))
        //    //{
        //    //    if (refnum < 5501)
        //    //        masterEntity.ReferenceNumber = "5501";
        //    //}
        //    //new PaymentMasterDB().Update(masterEntity);
        //    //base.Response.Redirect("PaymentManage.aspx");
        //}
    }
}
