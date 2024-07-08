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
	// Token: 0x0200001E RID: 30
	public class RssManage : Page
	{
		// Token: 0x06000106 RID: 262 RVA: 0x00009BF4 File Offset: 0x00007DF4
		protected void Page_Load(object sender, EventArgs e)
		{
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/RssManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
			else
			{
				this.btnPrint.Enabled = true;
			}
			if (this.lblAdd.Text == "false")
			{
				this.btnAddNew.Enabled = false;
				this.btnAddNew.ToolTip = "You  dont have Permission to Add";
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00009D68 File Offset: 0x00007F68
		protected void GdvRSS_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText == "SaveError")
			{
				e.ErrorText = "SaveError";
			}
			if (e.Exception.InnerException.Message == "Can't delete,already Used")
			{
				e.ErrorText = "Can't delete,already Used";
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00002BB3 File Offset: 0x00000DB3
		protected void btnAddNew_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("RssInfo.aspx");
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00002BC5 File Offset: 0x00000DC5
		protected void GdvRSS_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			ASPxWebControl.RedirectOnCallback("RssInfo.aspx?id=" + e.KeyValue.ToString());
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00002071 File Offset: 0x00000271
		protected void GdvRSS_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
            if (e.ButtonID == "btnDeleteR" && e.VisibleIndex >= 0)
            {
                var val = ((ASPxGridView)sender).GetRowValues(e.VisibleIndex, "IsSampled");
                if (this.lblDelete.Text == "false" || (val != null && val.ToString().ToLower().Equals("true")))
                    e.Visible = DevExpress.Utils.DefaultBoolean.False;
            }
        }

        protected void btnSaveDelete_Click(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;
            if (string.IsNullOrWhiteSpace(txtDeleteReason.Text))
                return;
            if (string.IsNullOrWhiteSpace(sid.Text) || sid.Text == "0")
                return;
            var rssMasterDB = new BusinessLayer.Pages.RSSMasterDB();
            RSSMaster byID = rssMasterDB.GetByID(long.Parse(sid.Text));
            //byID.IsSampled = true;
            //byID.IsDeleted = true;
            //byID.ReasonForDelete = txtDeleteReason.Text;
            string outmsg = "";
            rssMasterDB.RemoveRSS(byID, txtDeleteReason.Text,out outmsg);

            ConvertFile.AttachDeletionReasonAndDeleteSampleReceive(Server.MapPath("~/Uploaded/RSSReceive"), byID.RSSNumber, txtDeleteReason.Text);

            txtDeleteReason.Text = "";
            Session["labelText"] = "";
            Response.Redirect(Page.Request.Url.ToString(), true);
            //var service = new BusinessLayer.Pages.SampleReceiveListDB();
            //var obj = service.GetByID(Convert.ToInt64(sid.Text));
            //if (obj != null)
            //{
            //    if (!service.IsInvoiced(obj.SampleID))
            //    {
            //        obj.IsDeleted = true;
            //        obj.ReasonForDelete = txtDeleteReason.Text;
            //        service.Update(obj);

            //        //popupDelete.ShowOnPageLoad = false;

            //        ConvertFile.AttachDeletionReasonAndDeleteSampleReceive(Server.MapPath("~/Uploaded/SampleReceive"), obj.SampleNo, txtDeleteReason.Text);

            //        txtDeleteReason.Text = "";
            //        Session["labelText"] = "";
            //        lblError.Text = "";
            //        Response.Redirect(Page.Request.Url.ToString(), true);
            //    }
            //    else
            //    {
            //        Session["labelText"] = $"Sample # {obj.SampleNo} is linked with invoice(s)";
            //        Page.Response.Redirect(Page.Request.Url.ToString(), true);
            //    }
            //}
        }
        protected void GdvRSS_BeforeGetCallbackResult(object sender, EventArgs e)
        {
            this.GdvRSS.JSProperties["cpFilter"] = this.GdvRSS.FilterExpression;
        }
        // Token: 0x0600010B RID: 267 RVA: 0x00009DBC File Offset: 0x00007FBC
        protected void GdvRSS_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
		{
			if (this.lblEdite.Text == "false" && e.ButtonType == ColumnCommandButtonType.Edit)
			{
				e.Enabled = false;
			}
			if (this.lblDelete.Text == "false" && e.ButtonType == ColumnCommandButtonType.Delete)
			{
				e.Enabled = false;
			}
            // 

          
        }

		// Token: 0x04000121 RID: 289
		protected HtmlGenericControl ultitle;

		// Token: 0x04000122 RID: 290
		protected ASPxLabel lblView;

		// Token: 0x04000123 RID: 291
		protected ASPxLabel lblEdite;

		// Token: 0x04000124 RID: 292
		protected ASPxLabel lblDelete;

		// Token: 0x04000125 RID: 293
		protected ASPxLabel lblAdd;
        protected ASPxMemo txtDeleteReason;

        // Token: 0x04000126 RID: 294
        protected ASPxButton btnAddNew;

		// Token: 0x04000127 RID: 295
		protected ASPxButton btnPrint;
        protected ASPxTextBox sid;
        // Token: 0x04000128 RID: 296
        protected ASPxGridView GdvRSS;

		// Token: 0x04000129 RID: 297
		protected GridViewCommandColumnCustomButton btnprintR;

		// Token: 0x0400012A RID: 298
		protected ObjectDataSource RSSMasterDS;

		// Token: 0x0400012B RID: 299
		protected ObjectDataSource JobOrderDS;
	}
}
