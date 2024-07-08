<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ReportGroup.aspx.cs" Inherits="LaboratoryLayer.Pages.ReportGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function PrintReport() {

            window.open('ReportViwer.aspx?source=ServiceGroupList&id=0&Filter=' + gridServiceGroupList.cpFilter);

        }

        function handleButtonClick(s, e) {

            if (e.buttonID == 'btnView') { var key = s.GetRowKey(e.visibleIndex); window.open('ReportViwer.aspx?source=Projects_Information&id=' + key); }


            if (e.buttonID == 'btnAttachSR') {
                var key = s.GetRowKey(e.visibleIndex);
                //"" + Eval("TestReportingID")
                OnMoreInfoClick('../Pages/AttachmentsReport.aspx?TransTypeID=88888&TransID=' + key);
            }
        }
        function OnMoreInfoClick(contentUrl) {
            clientPopupControl.SetContentUrl(contentUrl);
            clientPopupControl.Show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PagePath" runat="server">
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb" runat="server" id="ultitle">
            <li>
                <i class="ace-icon fa fa-home home-icon"></i>
                <a href="../Default.aspx">Home</a>
            </li>
            <li><a id="menu1" href="#">Setup</a></li>
            <li class="active" id="menulink">Reports Grouping</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Reports Grouping</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

    </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New Report Group" CssClass="btn btn-round btn-primary fa fa-plus" runat="server" OnClick="btnAddNew_Click">
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
                <ClientSideEvents click="PrintReport"/>
            </dx:ASPxButton>
        </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvServiceGroupList" AutoGenerateColumns="false" Width="100%" OnInitNewRow="GdvServiceGroupList_InitNewRow" OnBeforeGetCallbackResult="GdvServiceGroupList_BeforeGetCallbackResult" OnCommandButtonInitialize="GdvServiceGroupList_CommandButtonInitialize"
            ClientInstanceName="gridServiceGroupList" DataSourceID="ServiceGroupDS" KeyFieldName="GroupID" OnCellEditorInitialize="GdvServiceGroupList_CellEditorInitialize">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="GroupNumber" Caption="Code" Width="10%" VisibleIndex="1" ReadOnly="true" CellStyle-HorizontalAlign="Left">
                    <Settings AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="GroupName" Caption="Group Name" Width="35%" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesTextEdit>
                        <ValidationSettings Display="Dynamic" ValidateOnLeave="true" CausesValidation="true" ValidationGroup="editForm">
                            <RequiredField IsRequired="true" ErrorText="Enter Name" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                    <Settings AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataComboBoxColumn FieldName="FKMaterialTypeID" Caption="Service Section" Width="40%" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="MaterialTypeID" TextField="MaterialName" DataSourceID="MaterialsTypesDS">
                        <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="true" ErrorText="Select Service Section" />
                        </ValidationSettings>
                    </PropertiesComboBox>
                    <Settings AutoFilterCondition="Contains" />
                </dx:GridViewDataComboBoxColumn>

                <dx:GridViewCommandColumn VisibleIndex="4" ButtonType="Default" Width="5%"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                     <CustomButtons>
                        
                         <dx:GridViewCommandColumnCustomButton ID="btnAttachSR" Text=" ">
                            <Styles>
                                <Style Font-Size="Medium" CssClass="fa fa-paperclip"></Style>
                            </Styles>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                <CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove" />
                <UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <Styles>
                <Header BackColor="SteelBlue" ForeColor="White"></Header>
            </Styles>
                        <ClientSideEvents CustomButtonClick="handleButtonClick" />

        </dx:ASPxGridView>
    </div>
    <dx:ASPxPopupControl ID="popupControl" runat="server" ClientInstanceName="clientPopupControl" CloseAction="CloseButton" Height="500px" Modal="True" Width="500px" 
                              PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Attachments"
                            AllowDragging="true" PopupAnimationType="Slide" ShowCloseButton="true" HeaderStyle-BackColor="SteelBlue"
                             HeaderStyle-ForeColor="White" >
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                      <div class="divrow">
                                                                  
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    <asp:ObjectDataSource ID="ServiceGroupDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ReportGroupDB"
        SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.ReportGroup">
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="MaterialsTypesDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsTypesDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsTypes">
    </asp:ObjectDataSource>
</asp:Content>
