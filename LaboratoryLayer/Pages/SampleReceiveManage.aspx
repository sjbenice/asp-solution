<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="SampleReceiveManage.aspx.cs" Inherits="LaboratoryLayer.Pages.SampleReceiveManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
     <script>
         function handleButtonClick(s, e) {
             if (e.buttonID == 'btnDeleteSR') {
                 popupDelete.Show();
                 var key = s.GetRowKey(e.visibleIndex);
                 sid.SetValue(key);
             }

             if (e.buttonID == 'btnActivateSR') {
                 popupActivate.Show();
                 var key = s.GetRowKey(e.visibleIndex);
                 sid.SetValue(key);
             }

             if (e.buttonID == 'btnDownloadExcel') {
                 var key = s.GetRowKey(e.visibleIndex);
                 OnMoreInfoClick('SampleReceiveReportVersion.aspx?id=' + key);
             }
             if (e.buttonID == 'btnAttachSR') {
                 var key = s.GetRowKey(e.visibleIndex);
                 //"" + Eval("TestReportingID")
                 OnMoreInfoClick('../Pages/AttachmentsReport.aspx?TransTypeID=22222&TransID=' + key);
             }
         }
         function OnMoreInfoClick(contentUrl) {
             clientPopupControl.SetContentUrl(contentUrl);
             clientPopupControl.Show();
         }

         function PrintReport() {
             window.open('ReportViwer.aspx?source=SampleReceiptReport&id=0&Filter=' + gridSampleReceiveList.cpFilter, '_blank');
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
            <li class="active" id="menulink">Sample Receive List</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Sample Receive List</h1>
        <dx:ASPxLabel id="lblError" runat="server" ForeColor="Red" Text="dd"></dx:ASPxLabel>
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
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="New Sample Receive" CssClass="btn btn-round btn-primary fa fa-plus"
                 runat="server" OnClick="btnAddNew_Click">
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
        <dx:ASPxGridView runat="server" ID="GdvSampleReceiveList" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridSampleReceiveList"
            OnCustomCallback="GdvSampleReceiveList_CustomCallback"
            DataSourceID="SampleReceiveListDS" KeyFieldName="SampleID" OnCellEditorInitialize="GdvSampleReceiveList_CellEditorInitialize" OnCustomButtonInitialize="GdvSampleReceiveList_CustomButtonInitialize" OnCommandButtonInitialize="GdvSampleReceiveList_CommandButtonInitialize" Settings-ShowFilterBar="Visible" Settings-ShowFilterRow="True" Settings-ShowFilterRowMenu="True" Settings-ShowFilterRowMenuLikeItem="True">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="SampleNo" Caption="Sample No" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ReportNumber" Caption="Report Number" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="ReceiveDate" Caption="Date" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy"></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                 <dx:GridViewDataComboBoxColumn FieldName="FKCustomerID" Caption="Customer" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
               <dx:GridViewDataComboBoxColumn FieldName="FKProjectID" Caption="Project" VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS">
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                <%--<dx:GridViewDataCheckColumn FieldName="IsLocked" Caption="Inactive" Width="100" VisibleIndex="1" CellStyle-HorizontalAlign="Center">
                </dx:GridViewDataCheckColumn>--%>

                <dx:GridViewCommandColumn VisibleIndex="4" ButtonType="Default" Width="100"  
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
                    <CustomButtons>
                         <dx:GridViewCommandColumnCustomButton ID="btnDownloadExcel" Text=" ">
                            <Styles>
                                <Style Font-Size="Medium" CssClass="fa fa-print"></Style>
                            </Styles>
                        </dx:GridViewCommandColumnCustomButton>

                        <dx:GridViewCommandColumnCustomButton ID="btnDeleteSR" Text=" ">
                            <Styles>
                                <Style Font-Size="Medium" CssClass="fa fa-trash"></Style>
                            </Styles>
                        </dx:GridViewCommandColumnCustomButton>

                         <dx:GridViewCommandColumnCustomButton ID="btnActivateSR" Text=" ">
                            <Styles>
                                <Style Font-Size="Medium" CssClass="fa fa-toggle-on"></Style>
                            </Styles>
                        </dx:GridViewCommandColumnCustomButton>
                        <dx:GridViewCommandColumnCustomButton ID="btnAttachSR" Text=" ">
                            <Styles>
                                <Style Font-Size="Medium" CssClass="fa fa-paperclip"></Style>
                            </Styles>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
            </Columns>
            <ClientSideEvents CustomButtonClick="handleButtonClick" />

             <%--<ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnDownloadExcel') {window.location=('DownloadFiles.aspx?id=' + key);}}" />--%>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <SettingsPager PageSize="20"></SettingsPager>

            <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
        <dx:ASPxTextBox ID="sid" runat="server" ClientInstanceName="sid" ClientVisible="false" Text="0"></dx:ASPxTextBox>
    </div>

    <div>
        <dx:ASPxPopupControl ID="popupDelete" runat="server" CloseAction="CloseButton" 
            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" AllowDragging="False" PopupAnimationType="Slide"
            ShowFooter="True" Width="510px" HeaderText="Reason For Delete" ShowCloseButton="false" 
            HeaderStyle-BackColor="SteelBlue" HeaderStyle-ForeColor="White" ClientInstanceName="popupDelete">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                    <div class="divrow">
                      
                        <dx:ASPxMemo ID="txtDeleteReason" runat="server" Height="250" ClientInstanceName="txtDeleteReason" Width="100%" ClientVisible="true" Text=""></dx:ASPxMemo>
                                                
                    </div>
                   
                </dx:PopupControlContentControl>
            </ContentCollection>
            <FooterTemplate>
                <div style="display: table; margin: 6px 6px 6px auto;">
                    <div style="float:left">
                        <dx:ASPxButton ID="btnSaveDelete" AutoPostBack="true" runat="server" OnClick="btnSaveDelete_Click" Text="Save" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-save">
                            <ClientSideEvents Click="function(s, e) {if(txtDeleteReason.GetText()==''){alert('Please provide delete reason');  e.processOnServer = false; return;} }" />
                        </dx:ASPxButton>
                    </div>
                    <div style="float:left;margin-left:5px;">
                        <dx:ASPxButton ID="btnCancelDelete" runat="server" Text="Cancel" CssClass="btn btn-round btn-primary glyphicon glyphicon-remove">
                            <ClientSideEvents Click="function(s, e) {txtDeleteReason.SetText(''); popupDelete.Hide(); }" />
                        </dx:ASPxButton>
                    </div>
                </div>
            </FooterTemplate>
            <%--<ClientSideEvents PopUp="function(s, e) { popTestLists.PerformCallback(); }" />--%>
        </dx:ASPxPopupControl>
    </div>

    <div>
         <dx:ASPxPopupControl ID="popupControl" runat="server" ClientInstanceName="clientPopupControl" CloseAction="CloseButton" Height="500px" Modal="True" Width="500px" 
                              PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Select Report Revesion To Download"
                            AllowDragging="true" PopupAnimationType="Slide" ShowCloseButton="true" HeaderStyle-BackColor="SteelBlue"
                             HeaderStyle-ForeColor="White" >
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                      <div class="divrow">
                                                                  
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </div>

    <div>
        <dx:ASPxPopupControl ID="popupActivate" runat="server" CloseAction="CloseButton" 
            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" AllowDragging="False" PopupAnimationType="Slide"
            ShowFooter="True" Width="510px" HeaderText="Do you really want to reactivate?" ShowCloseButton="false" HeaderStyle-BackColor="SteelBlue"
             HeaderStyle-ForeColor="White" ClientInstanceName="popupActivate">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                    <div class="divrow">
                                                                  
                    </div>
                   
                </dx:PopupControlContentControl>
            </ContentCollection>
            <FooterTemplate>
                <div style="display: table; margin: 6px 6px 6px auto;">
                    <div style="float:left">
                        <dx:ASPxButton ID="btnSaveActivate" AutoPostBack="true" runat="server" OnClick="btnSaveActivate_Click" Text="Save" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-save">                            
                        </dx:ASPxButton>
                    </div>
                    <div style="float:left;margin-left:5px;">
                        <dx:ASPxButton ID="btnCancelActivate" runat="server" Text="Cancel" CssClass="btn btn-round btn-primary glyphicon glyphicon-remove">
                            <ClientSideEvents Click="function(s, e) { popupActivate.Hide(); }" />
                        </dx:ASPxButton>
                    </div>
                </div>
            </FooterTemplate>
            <%--<ClientSideEvents PopUp="function(s, e) { popTestLists.PerformCallback(); }" />--%>
        </dx:ASPxPopupControl>
    </div>

        <asp:ObjectDataSource ID="CustomersListDS" runat="server" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ProjectsListDS" runat="server" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="SampleReceiveListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.SampleReceiveListDB"
        SelectMethod="GetAll" DeleteMethod="Delete"   DataObjectTypeName="BusinessLayer.SampleReceiveList" ></asp:ObjectDataSource>
</asp:Content>
