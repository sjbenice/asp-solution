using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace LaboratoryLayer.Admin
{
	// Token: 0x02000007 RID: 7
	public class Users : Page
	{
        public const int TransactionTypeID = 33333;

        // Token: 0x17000034 RID: 52
        // (get) Token: 0x060000A7 RID: 167 RVA: 0x000073E0 File Offset: 0x000055E0
        // (set) Token: 0x060000A8 RID: 168 RVA: 0x0000279C File Offset: 0x0000099C
        public long TransactionID
        {
            get
            {
                if (this.Session[this._attachTransIDSessionString] != null)
                {
                    return long.Parse(this.Session[this._attachTransIDSessionString].ToString());
                }
                return long.Parse(lblUserId.Text);
            }
            set
            {
                this.Session[this._attachTransIDSessionString] = value.ToString();
                this.lblTransID.Text = value.ToString();
            }
        }

        // Token: 0x0600003B RID: 59 RVA: 0x00005CA4 File Offset: 0x00003EA4
        protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.LoadRoles();
				if (Convert.ToInt32(base.Request["Id"]) != 0)
				{
					this.lblUserId.Text = base.Request["Id"];
					this.DisplayData(Convert.ToInt32(base.Request["Id"]));
                    FilContents.Visible = true;

                    AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                    this.lblTransTypeID.Text = TransactionTypeID.ToString();
                    this.TransactionID = long.Parse(lblUserId.Text);
                    this.gdvfiles.DataBind();
                }
            }
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005D0C File Offset: 0x00003F0C
		protected void btnSave_Click(object sender, EventArgs e)
		{
			new UsersDB();
			new RolesDB();
			string text = "";
			bool flag = true;
			try
			{
				bool flag2 = false;
				for (int i = 0; i < this.chBoxRoles.Items.Count; i++)
				{
					if (this.chBoxRoles.Items[i].Selected)
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					this.LblError.Text = "Select Roles";
					return;
				}
				UsersDB usersDB = new UsersDB();
				ADMUsers admusers = new ADMUsers();
				if (Convert.ToInt32(base.Request["id"]) != 0)
				{
					admusers = usersDB.GetByID(Convert.ToInt32(base.Request["id"]));
				}
				admusers.Code = this.txtCode.Text;
				admusers.EName = this.txtEnglishName.Text;
				admusers.AName = this.txtArabicName.Text;
				admusers.Address = this.txtAddress.Text;
				admusers.Tel = this.txtPhone.Text;
				admusers.Fax = this.txtFax.Text;
				admusers.Mobile = this.txtMobile.Text;
                if (this.dtExpiryDate.Value != null)
                    admusers.ExpiryDate = (DateTime)this.dtExpiryDate.Value;
                admusers.Remark = this.txtRemark.Text;
                admusers.IsActive = new bool?(!this.ChkIsInActive.Checked);

                if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()) && Convert.ToInt32(base.Request["id"]) == 0)
                {
                    this.LblError.Text = "Enter Password Please!";
                    return;
                }
                if (this.txtPassword.Text != "")
                {
                    admusers.Password = CryptoHelper.Encrypt(this.txtPassword.Text, "act123");
                }
				UserRolesDB userRolesDB = new UserRolesDB();
                if (Convert.ToInt32(base.Request["id"]) != 0)
                {
                    if (!usersDB.Update(admusers, out text))
                    {
                        this.LblError.Text = "Error in updating!";
                        return;
                    }
                    else
                    {
                        AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                        if (Session["UserSignature"] != null)
                        {
                            AttachedFiles attachedFiles = (AttachedFiles)Session["UserSignature"];
                            attachedFiles.FKTransID = Convert.ToInt32(base.Request["id"]);
                            attachedFiles.FKTransTypeID = TransactionTypeID;
                            attachedFilesDB.Insert(attachedFiles);
                        }
                    }

                    if (!userRolesDB.DeleteAllUserRoles(admusers.UserID))
                    {
                        this.LblError.Text = "Error in configuring roles";
                        return;
                    }
                }
                else 
                {
                    int userId = usersDB.Insert(admusers, out text);
                    if (userId <= 0)
                    {
                        this.LblError.Text = "Error in saving!";
                        return;
                    }
                    else
                    {
                        AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                        if (Session["UserSignature"] != null)
                        {
                            AttachedFiles attachedFiles = (AttachedFiles)Session["UserSignature"];
                            attachedFiles.FKTransID = userId;
                            attachedFiles.FKTransTypeID = TransactionTypeID;
                            attachedFilesDB.Insert(attachedFiles);
                        }
                    }
                }
                
				for (int j = 0; j < this.chBoxRoles.Items.Count; j++)
				{
					if (this.chBoxRoles.Items[j].Selected && !userRolesDB.Insert(new ADMUserRoles
					{
						FKUserID = admusers.UserID,
						FKRoleID = int.Parse(this.chBoxRoles.Items[j].Value.ToString())
					}, out text))
					{
						this.LblError.Text = "Error in saving roles";
						flag = false;
					}
				}
			}
			catch
			{
				this.LblError.Text = "Error in saving!";
			}
			if (flag)
			{
				base.Response.Redirect("UsersManage.aspx");
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002212 File Offset: 0x00000412
		protected void btnCancel_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("UsersManage.aspx");
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002224 File Offset: 0x00000424
		private void LoadRoles()
		{
			this.chBoxRoles.DataSource = new RolesDB().GetAll();
			this.chBoxRoles.DataBind();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005FEC File Offset: 0x000041EC
		private void DisplayData(int id)
		{
			ADMUsers byID = new UsersDB().GetByID(id);
			this.txtCode.Text = byID.Code;
			this.txtEnglishName.Text = byID.EName;
			this.txtArabicName.Text = byID.AName;
			this.txtAddress.Text = byID.Address;
			this.txtPhone.Text = byID.Tel;
			this.txtFax.Text = byID.Fax;
			this.txtMobile.Text = byID.Mobile;
            this.dtExpiryDate.Value = byID.ExpiryDate;
            this.txtRemark.Text = byID.Remark;
            //this.txtPassword.Text = CryptoHelper.Decrypt(byID.Password, "act123");
			if (byID.IsActive != null)
			{
				this.ChkIsInActive.Checked = !byID.IsActive.Value;
			}

			List<ADMUserRoles> byUserId = new UserRolesDB().GetByUserId(byID.UserID);
			for (int i = 0; i < byUserId.Count; i++)
			{
				for (int j = 0; j < this.chBoxRoles.Items.Count; j++)
				{
					if (int.Parse(this.chBoxRoles.Items[j].Value.ToString()) == byUserId[i].FKRoleID)
					{
						this.chBoxRoles.Items[j].Selected = true;
					}
				}
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002246 File Offset: 0x00000446
		protected void GdvADMUserSettings_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			e.NewValues["FKUserID"] = Convert.ToInt32(base.Request["Id"]);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002272 File Offset: 0x00000472
		protected void GdvADMUserSettings_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			e.NewValues["FKUserID"] = Convert.ToInt32(base.Request["Id"]);
		}

        // Token: 0x060000AF RID: 175 RVA: 0x00007638 File Offset: 0x00005838
        protected void UploadControl_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            int userId = Convert.ToInt32(base.Request["id"]);
            string fileName = e.UploadedFile.FileName;
            string fileSize = (e.UploadedFile.ContentLength / 1024L).ToString() + " KB";
            byte[] fileBytes = e.UploadedFile.FileBytes;

            AttachedFiles attachedFiles = new AttachedFiles();
            attachedFiles.FileContent = fileBytes;
            attachedFiles.FileExtention = Path.GetExtension(e.UploadedFile.FileName);
            attachedFiles.FileName = fileName;
            attachedFiles.FileSize = fileSize;
            attachedFiles.FileUrl = "";
            attachedFiles.IsUrl = false;
            attachedFiles.CreatedDate = DateTime.Now;

            if (userId == 0 && attachedFiles != null)
            {
                Session["UserSignature"] = attachedFiles;
            }
            else
            {
                AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                if (attachedFiles != null)
                {
                    attachedFiles.FKTransID = userId;
                    attachedFiles.FKTransTypeID = TransactionTypeID;

                    AttachedFiles existingAttachedFiles = attachedFilesDB.GetAttachment(userId, TransactionTypeID);
                    if (existingAttachedFiles != null)
                    {
                        attachedFiles.FileID = existingAttachedFiles.FileID;
                        attachedFilesDB.Update(attachedFiles);
                    }
                    else
                        attachedFilesDB.Insert(attachedFiles);

                    this.gdvfiles.DataBind();
                    e.CallbackData = fileName + "|" + fileSize;
                }
            }
        }

        protected void gdvfiles_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            (sender as ASPxGridView).DataBind();
        }

        // Token: 0x060000B1 RID: 177 RVA: 0x00007744 File Offset: 0x00005944
        protected void gdvfiles_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandName == "download")
            {
                AttachedFiles attachedFiles = new AttachedFiles();
                int num = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
                object commandSource = e.CommandSource;
                AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                attachedFiles = attachedFilesDB.GetByID((long)num);
                if (attachedFiles != null)
                {
                    string fileUrl = attachedFiles.FileUrl;
                    string str = attachedFiles.FileName.Replace(" ", "_");
                    byte[] fileContent = attachedFiles.FileContent;
                    base.Response.Clear();
                    base.Response.ClearHeaders();
                    base.Response.AddHeader("Content-Type", "Application/octet-stream");
                    base.Response.AddHeader("Content-Length", fileContent.Length.ToString());
                    base.Response.AddHeader("Content-Disposition", "attachment;   filename=" + str);
                    base.Response.BinaryWrite(fileContent);
                    base.Response.Flush();
                    base.Response.End();
                }
            }
            else if (e.CommandArgs.CommandName == "delete")
            {
                AttachedFiles attachedFiles = new AttachedFiles();
                int num = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
                object commandSource = e.CommandSource;
                AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                attachedFiles = attachedFilesDB.GetByID((long)num);
                if (attachedFiles != null)
                {
                    bool result = attachedFilesDB.Delete(attachedFiles);
                    this.Session[this._attachTransIDSessionString] = null;
                    this.gdvfiles.DataBind();
                }
            }
        }

        // Token: 0x04000022 RID: 34
        protected HtmlGenericControl ultitle;

		// Token: 0x04000023 RID: 35
		protected ASPxLabel lblUserId;

		// Token: 0x04000024 RID: 36
		protected ASPxButton btnSave;

		// Token: 0x04000025 RID: 37
		protected ASPxButton btnCancel;

		// Token: 0x04000026 RID: 38
		protected ASPxLabel LblError;

		// Token: 0x04000027 RID: 39
		protected ASPxValidationSummary ASPxValidationSummary1;

		// Token: 0x04000028 RID: 40
		protected ASPxLabel lblDate;

		// Token: 0x04000029 RID: 41
		protected ASPxTextBox txtCode;

		// Token: 0x0400002A RID: 42
		protected ASPxLabel lblNotes;

		// Token: 0x0400002B RID: 43
		protected ASPxTextBox txtEnglishName;

		// Token: 0x0400002C RID: 44
		protected ASPxLabel ASPxLabel6;

		// Token: 0x0400002D RID: 45
		protected ASPxTextBox txtArabicName;

		// Token: 0x0400002E RID: 46
		protected ASPxLabel ASPxLabel1;

		// Token: 0x0400002F RID: 47
		protected ASPxTextBox txtAddress;

		// Token: 0x04000030 RID: 48
		protected ASPxLabel ASPxLabel7;

		// Token: 0x04000031 RID: 49
		protected ASPxTextBox txtPhone;

		// Token: 0x04000032 RID: 50
		protected ASPxLabel ASPxLabel2;

		// Token: 0x04000033 RID: 51
		protected ASPxTextBox txtFax;

		// Token: 0x04000034 RID: 52
		protected ASPxLabel ASPxLabel8;

		// Token: 0x04000035 RID: 53
		protected ASPxTextBox txtMobile;

        protected ASPxDateEdit dtExpiryDate;

        protected ASPxTextBox txtRemark;

        // Token: 0x04000036 RID: 54
        protected ASPxLabel ASPxLabel3;

		// Token: 0x04000037 RID: 55
		protected ASPxTextBox txtPassword;

		// Token: 0x04000038 RID: 56
		protected ASPxLabel ASPxLabel4;

		// Token: 0x04000039 RID: 57
		protected ASPxCheckBox ChkIsInActive;

		// Token: 0x0400003A RID: 58
		protected ASPxLabel ASPxLabel5;

		// Token: 0x0400003C RID: 60
		protected ASPxLabel lblRole;

		// Token: 0x0400003D RID: 61
		protected ASPxCheckBoxList chBoxRoles;

		// Token: 0x0400003E RID: 62
		protected ASPxGridView GdvADMUserSettings;

		// Token: 0x0400003F RID: 63
		protected ObjectDataSource ADMUserSettingsDS;

		// Token: 0x04000040 RID: 64
		protected ObjectDataSource SettingsNameDS;

        // Token: 0x0400008E RID: 142
        protected ASPxUploadControl UploadControl;

        // Token: 0x04000091 RID: 145
        protected ASPxRoundPanel FilContents;

        // Token: 0x04000092 RID: 146
        protected ASPxGridView gdvfiles;

        // Token: 0x0400008F RID: 143
        protected ASPxLabel AllowedFileExtensionsLabel;

        // Token: 0x04000090 RID: 144
        protected ASPxLabel MaxFileSizeLabel;

        // Token: 0x0400008A RID: 138
        protected HtmlGenericControl divmsg;

        // Token: 0x04000084 RID: 132
        private string _attachTransIDSessionString = "_appattachTransID";

        // Token: 0x04000087 RID: 135
        protected ASPxLabel lblTransID;

        // Token: 0x04000088 RID: 136
        protected ASPxLabel lblTransTypeID;
    }
}
