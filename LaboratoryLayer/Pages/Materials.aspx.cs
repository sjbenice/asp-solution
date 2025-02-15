﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace LaboratoryLayer.Pages
{
	// Token: 0x02000041 RID: 65
	public partial class Materials : Page
	{
        // Token: 0x060002A0 RID: 672 RVA: 0x00017480 File Offset: 0x00015680
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.Session["MaterialsDetailsTestsList"] = null;
                this.Session["FKMaterialDetailsID"] = null;
                this.Session["FKMaterialTypeID"] = null;
                this.Session["TestsList"] = null;
            }
            List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/Materials.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060002A1 RID: 673 RVA: 0x00017614 File Offset: 0x00015814
		protected void GdvMaterialsList_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
		{
			if (e.ErrorText != "SaveError")
			{
				e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; \n Message:" + e.Exception.InnerException.Message));
			}
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00017674 File Offset: 0x00015874
		protected void GdvMaterialsList_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["MaterialName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtName")).Text;
			e.NewValues["FKMaterialTypeID"] = ((ASPxComboBox)aspxGridView.FindEditFormTemplateControl("cmbFKMaterialTypeID")).Value;
			e.NewValues["MaterialDescription"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtMaterialDescription")).Text;
			e.NewValues["MaterialUse"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtMaterialUse")).Text;
			e.NewValues["StandardSpecs"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtStandardSpecs")).Text;
			e.NewValues["StandardNumber"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtStandardNumber")).Text;
			e.NewValues["IsLocked"] = ((ASPxCheckBox)aspxGridView.FindEditFormTemplateControl("IsLocked")).Checked;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00017790 File Offset: 0x00015990
		protected void GdvMaterialsList_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			ASPxGridView aspxGridView = sender as ASPxGridView;
			e.NewValues["MaterialName"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtName")).Text;
			e.NewValues["FKMaterialTypeID"] = ((ASPxComboBox)aspxGridView.FindEditFormTemplateControl("cmbFKMaterialTypeID")).Value;
			e.NewValues["MaterialDescription"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtMaterialDescription")).Text;
			e.NewValues["MaterialUse"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtMaterialUse")).Text;
			e.NewValues["StandardSpecs"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtStandardSpecs")).Text;
			e.NewValues["StandardNumber"] = ((ASPxTextBox)aspxGridView.FindEditFormTemplateControl("txtStandardNumber")).Text;
			e.NewValues["IsLocked"] = ((ASPxCheckBox)aspxGridView.FindEditFormTemplateControl("IsLocked")).Checked;
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000382C File Offset: 0x00001A2C
		protected void GdvMaterialTestList_BeforePerformDataSelect(object sender, EventArgs e)
		{
			this.Session["FKMaterialDetailsID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
		}

        // Token: 0x060002A5 RID: 677 RVA: 0x000178AC File Offset: 0x00015AAC
        protected void lstTests_DataBound(object sender, EventArgs e)
		{
			ASPxCheckBoxList aspxCheckBoxList = (ASPxCheckBoxList)sender;
			List<MaterialsDetailsTests> source = this.MaterialsDetailsTestsDS.Select() as List<MaterialsDetailsTests>;
			List<int> list = (from x in source
			select x.FKTestID).ToList<int>();
			for (int i = 0; i < aspxCheckBoxList.Items.Count; i++)
			{
				aspxCheckBoxList.Items[i].Selected = list.Contains((int)aspxCheckBoxList.Items[i].Value);
			}
		}

        // Token: 0x060002A6 RID: 678 RVA: 0x00017940 File Offset: 0x00015B40
        protected void GdvLabTestsList_DataBound(object sender, EventArgs e)
        {
            if (this.GdvLabTestsList.IsCallback)
            {
                List<object> selectedFieldValues = this.GdvLabTestsList.GetSelectedFieldValues(new string[]
                {
                    "TestID"
                });

                foreach (object num in selectedFieldValues)
                {
                    this.GdvLabTestsList.Selection.SelectRowByKey(num);
                }
            }
            else
            {
                List<MaterialsDetailsTests> source = this.MaterialsDetailsTestsDS.Select() as List<MaterialsDetailsTests>;
                List<int> list = (from x in source
                                  select x.FKTestID).ToList<int>();
                foreach (int num in list)
                {
                    this.GdvLabTestsList.Selection.SelectRowByKey(num);
                }
            }
        }

        // Token: 0x060002A7 RID: 679 RVA: 0x000179D8 File Offset: 0x00015BD8
        protected void MaterialsDetailsTestsDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
            int fkmaterialDetailsID = Convert.ToInt32(this.Session["FKMaterialDetailsID"]);
            this.GdvLabTestsList.UpdateEdit();
            List<object> selectedFieldValues = this.GdvLabTestsList.GetSelectedFieldValues(new string[]
			{
				"TestID"
            });

            List<string> keys = new List<string>();
            keys.Add("TestID");
            keys.Add("FkGroupId");

            List<TestsList> obj = this.Session["TestsList"] as List<TestsList>;
            List<object> selected = new List<object>();
            foreach(object key in selectedFieldValues)
            {
                List<object> datas = new List<object>();
                datas.Add(key);
                object groupIDVal = null;
                int keyInt = (int)key;
                var testID = this.GdvLabTestsList.GetRowValuesByKeyValue(keyInt, "TestID");
                if (testID == null)
                {
                    if (obj != null)
                    {
                        TestsList test = obj.Where(o => o.TestID == keyInt).FirstOrDefault();
                        if (test != null)
                            groupIDVal = test.FkGroupId;
                    }
                }
                else
                {
                    var groupID = this.GdvLabTestsList.GetRowValuesByKeyValue(keyInt, "FkGroupId");
                    groupIDVal = groupID;
                }

                datas.Add(groupIDVal);
                selected.Add(datas.ToArray());
            }

            List<MaterialsDetailsTests> list = new List<MaterialsDetailsTests>();
			foreach (object[] value in selected)
			{
                int? grpID = null;
                if (value[1] != null)
                    grpID = Convert.ToInt32(value[1]);

                list.Add(new MaterialsDetailsTests
				{
					FKMaterialDetailsID = fkmaterialDetailsID,
					FKTestID = Convert.ToInt32(value[0]),
                    FKGroupID = grpID
                });
			}
			if (list.Count == 0)
			{
                list.Add(new MaterialsDetailsTests
                {
                    FKMaterialDetailsID = fkmaterialDetailsID,
                    FKTestID = 0,
                    FKGroupID = null
				});
			}
			e.InputParameters["entityList"] = list;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00003849 File Offset: 0x00001A49
		protected void btnUpdate_Click(object sender, EventArgs e)
		{
            this.MaterialsDetailsTestsDS.Update();
        }

		// Token: 0x060002A9 RID: 681 RVA: 0x00017AB8 File Offset: 0x00015CB8
		protected void MaterialsDetailsTestsDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.popTestLists.ShowOnPageLoad = false;
			ASPxGridView aspxGridView = this.GdvMaterialsList.FindEditFormTemplateControl("GdvMaterialTestList") as ASPxGridView;
			aspxGridView.DataBind();
        }

		// Token: 0x060002AA RID: 682 RVA: 0x00017AF0 File Offset: 0x00015CF0
		protected void PanEditForm_Init(object sender, EventArgs e)
		{
			Panel panel = (Panel)sender;
			GridViewEditFormTemplateContainer gridViewEditFormTemplateContainer = panel.NamingContainer as GridViewEditFormTemplateContainer;
			this.Session["FKMaterialDetailsID"] = gridViewEditFormTemplateContainer.KeyValue;

            if (gridViewEditFormTemplateContainer.DataItem != null && DataBinder.Eval(gridViewEditFormTemplateContainer.DataItem, "FKMaterialTypeID") != null)
            {
                int fkMaterialTypeID = (int)DataBinder.Eval(gridViewEditFormTemplateContainer.DataItem, "FKMaterialTypeID");
                this.Session["FKMaterialTypeID"] = fkMaterialTypeID;
            }
        }

        protected void GdvLabTestsList_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "FkGroupId")
                return;
            
            ASPxComboBox aspxComboBox = (ASPxComboBox)e.Editor;
            aspxComboBox.ClientInstanceName = "ReportGroupEditor";
        }

        // Token: 0x060002AB RID: 683 RVA: 0x00003857 File Offset: 0x00001A57
        protected void GdvMaterialsList_RowUpdated(object sender, ASPxDataUpdatedEventArgs e)
		{
			this.Session["MaterialsDetailsTestsList"] = null;
			this.Session["FKMaterialDetailsID"] = null;
            this.Session["TestsList"] = null;
        }

		// Token: 0x060002AC RID: 684 RVA: 0x0000387B File Offset: 0x00001A7B
		protected void popTestLists_WindowCallback(object source, PopupWindowCallbackArgs e)
		{
            object fkMaterialTypeIDVal = ((ASPxComboBox)GdvMaterialsList.FindEditFormTemplateControl("cmbFKMaterialTypeID")).Value;
            if (fkMaterialTypeIDVal != null)
            {
                int fkMaterialTypeID = Convert.ToInt32(fkMaterialTypeIDVal);
                this.Session["FKMaterialTypeID"] = fkMaterialTypeID;
            }

            this.Session["TestsList"] = null;
            this.lstTests.DataBind();
			this.GdvLabTestsList.Selection.UnselectAll();
			this.GdvLabTestsList.DataBind();
        }

		// Token: 0x060002AD RID: 685 RVA: 0x00003857 File Offset: 0x00001A57
		protected void GdvMaterialsList_RowInserted(object sender, ASPxDataInsertedEventArgs e)
		{
			this.Session["MaterialsDetailsTestsList"] = null;
			this.Session["FKMaterialDetailsID"] = null;
            this.Session["TestsList"] = null;
        }

		// Token: 0x060002AE RID: 686 RVA: 0x00017B28 File Offset: 0x00015D28
		protected void GdvMaterialsList_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
		{
			if (this.lblEdite.Text == "false" && e.ButtonType == ColumnCommandButtonType.Edit)
			{
				e.Enabled = false;
			}
			if (this.lblDelete.Text == "false" && e.ButtonType == ColumnCommandButtonType.Delete)
			{
				e.Enabled = false;
			}
			if (this.lblAdd.Text == "false" && e.ButtonType == ColumnCommandButtonType.New)
			{
				e.Enabled = false;
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x000038A3 File Offset: 0x00001AA3
		protected void GdvMaterialsList_BeforeGetCallbackResult(object sender, EventArgs e)
		{
			this.GdvMaterialsList.JSProperties["cpFilter"] = this.GdvMaterialsList.FilterExpression;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x000038C5 File Offset: 0x00001AC5
		protected void GdvMaterialsList_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.lblView.Text == "false" && e.ButtonID == "btnView")
			{
				e.Enabled = false;
			}
		}

		// Token: 0x04000444 RID: 1092
		protected GridViewCommandColumnCustomButton btnView;
    }
}
