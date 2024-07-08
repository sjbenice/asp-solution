using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using DevExpress.Web;

namespace LaboratoryLayer.Pages
{
	// Token: 0x0200002D RID: 45
	public class SampleReceiveManage : Page
	{
		// Token: 0x0600018E RID: 398 RVA: 0x0000E380 File Offset: 0x0000C580
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/SampleReceiveManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
            if (Session["labelText"] != null)
            {
                lblError.Text = Session["labelText"].ToString();
                Session["labelText"] = "";
            }
            else
                lblError.Text = "";
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

		// Token: 0x0600018F RID: 399 RVA: 0x0000E4E8 File Offset: 0x0000C6E8
		protected void GdvSampleReceiveList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.Exception.InnerException.Message != "Can't delete,already invoiced")
			{
				e.ErrorText = "Can't delete,already invoiced";
			}
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00003012 File Offset: 0x00001212
		protected void btnAddNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("SampleReceive.aspx");
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00003024 File Offset: 0x00001224
		protected void GdvSampleReceiveList_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("SampleReceive.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00003040 File Offset: 0x00001240
		protected void GdvSampleReceiveList_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.lblView.Text == "false" && e.ButtonID == "btnView")
			{
				e.Enabled = false;
			}
            if (this.lblView.Text == "false" && e.ButtonID == "btnAttachSR")
            {
                e.Enabled = false;
            }


            if (e.ButtonID == "btnDeleteSR" && e.VisibleIndex >= 0)
            {
                var val = ((ASPxGridView)sender).GetRowValues(e.VisibleIndex, "IsDeleted");
                if (this.lblDelete.Text == "false" || (val != null && val.ToString().ToLower().Equals("true")))
                    e.Visible = DevExpress.Utils.DefaultBoolean.False;
            }
            if (e.ButtonID == "btnActivateSR" && e.VisibleIndex >= 0)
            {
                var val = ((ASPxGridView)sender).GetRowValues(e.VisibleIndex, "IsDeleted");
                if (this.lblDelete.Text == "false")
                    e.Visible = DevExpress.Utils.DefaultBoolean.False;
                else if (val != null && val.ToString().ToLower().Equals("true"))
                    e.Visible = DevExpress.Utils.DefaultBoolean.True;
                else
                {
                    e.Visible = DevExpress.Utils.DefaultBoolean.False;
                }
            }
        }

		// Token: 0x06000193 RID: 403 RVA: 0x0000E570 File Offset: 0x0000C770
		protected void GdvSampleReceiveList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
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

		// Token: 0x0400024D RID: 589
		protected HtmlGenericControl ultitle;

		// Token: 0x0400024E RID: 590
		protected ASPxLabel lblView;

		// Token: 0x0400024F RID: 591
		protected ASPxLabel lblEdite;

		// Token: 0x04000250 RID: 592
		protected ASPxLabel lblDelete;

		// Token: 0x04000251 RID: 593
		protected ASPxLabel lblAdd;

		// Token: 0x04000252 RID: 594
		protected ASPxButton btnAddNew;

		// Token: 0x04000253 RID: 595
		protected ASPxButton btnPrint;

		// Token: 0x04000254 RID: 596
		protected ASPxGridView GdvSampleReceiveList;

		// Token: 0x04000255 RID: 597
		protected GridViewCommandColumnCustomButton btnDownloadExcel;

		// Token: 0x04000256 RID: 598
		protected ObjectDataSource CustomersListDS;

		// Token: 0x04000257 RID: 599
		protected ObjectDataSource ProjectsListDS;

		// Token: 0x04000258 RID: 600
		protected ObjectDataSource SampleReceiveListDS;

        // Token: 0x04000259 RID: 601
        protected ASPxMemo txtDeleteReason;

        // Token: 0x04000260 RID: 602
        protected ASPxTextBox sid;

        // Token: 0x04000261 RID: 603
        protected ASPxPopupControl popupDelete;

        // Token: 0x04000262 RID: 604
        protected ASPxPopupControl popupActivate;

        // Token: 0x04000263 RID: 605
        protected ASPxLabel lblError;

        protected ASPxGridView ASPxGridViewPopup;
        protected ASPxPopupControl popupControl;

        protected void GdvSampleReceiveList_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {

        }

        protected void btnSaveDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeleteReason.Text))
                return;
            if (string.IsNullOrWhiteSpace(sid.Text) || sid.Text == "0")
                return;

            var service = new BusinessLayer.Pages.SampleReceiveListDB();            
            var obj = service.GetByID(Convert.ToInt64(sid.Text));
            if (obj != null)
            {
                if (!service.IsInvoiced(obj.SampleID))
                {
                    obj.IsDeleted = true;
                    obj.ReasonForDelete = txtDeleteReason.Text;
                    service.Update(obj);

                    //popupDelete.ShowOnPageLoad = false;

                    ConvertFile.AttachDeletionReasonAndDeleteSampleReceive(Server.MapPath("~/Uploaded/SampleReceive"),obj.SampleNo, txtDeleteReason.Text);
                 
                    txtDeleteReason.Text = "";
                    Session["labelText"] = "";
                    lblError.Text = "";
                    base.Response.Redirect("SampleReceiveManage.aspx",true);
                    // Page.Response.Redirect(Page.Request.Url.ToString(), true);  
                }
                else
                {
                    Session["labelText"] = $"Sample # {obj.SampleNo} is linked with invoice(s)";
                    base.Response.Redirect("SampleReceiveManage.aspx", true);

                    // Page.Response.Redirect(Page.Request.Url.ToString(), true);                                        
                }
            }
        }

        protected void btnSaveActivate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sid.Text) || sid.Text == "0")
                return;
            Session["labelText"] = "";
            var service = new BusinessLayer.Pages.SampleReceiveListDB();
            var obj = service.GetByID(Convert.ToInt64(sid.Text));
            if (obj != null)
            {
                obj.IsDeleted = false;
                obj.ReasonForDelete = "";
                service.Update(obj);
                //popupActivate.ShowOnPageLoad = false;
                // Page.Response.Redirect(Page.Request.Url.ToString(), true);
                base.Response.Redirect("SampleReceiveManage.aspx", true);

            }
        }
    }
}
