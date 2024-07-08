<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="PaymentManage.aspx.cs" Inherits="LaboratoryLayer.Pages.PaymentManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>


        function handleButtonClick(s, e) 
        {

            if (e.buttonID == 'btnDeleteSR') { popupDelete.Show(); var key = s.GetRowKey(e.visibleIndex); sid.SetValue(key); }
            if (e.buttonID == 'btnView1') { var key = s.GetRowKey(e.visibleIndex); window.open('ReportViwer.aspx?source=Invoicee&id=' + key, 'Invoicee'); }

            
            if (e.buttonID == 'btnAttachSR') {
                var key = s.GetRowKey(e.visibleIndex);
                //"" + Eval("TestReportingID")
                OnMoreInfoClick('../Pages/AttachmentsReport.aspx?TransTypeID=66666&TransID=' + key);
            }
        }
        function PrintReport() {
            //window.open('ReportViwer.aspx?source=InvoiceList&id=0&Filter=' + gridInvoice.cpFilter, '_blank');
            window.open('ReportViwer.aspx?source=PaymentManage', '_blank');

        }
        function OnMoreInfoClick(contentUrl) {
            clientPopupControl.SetContentUrl(contentUrl);
            clientPopupControl.Show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PagePath" runat="server">
    <div class="breadcrumbs" id="breadcrumbs">
        +
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb" runat="server" id="ultitle">
            <li>
                <i class="ace-icon fa fa-home home-icon"></i>
                <a href="../Default.aspx">Home</a>
            </li>
            <li><a id="menu1" href="#">Setup</a></li>
            <li class="active" id="menulink"> Payment Manage</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Payment Manage</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server"> 
    
        <div class="btn-group" role="group" aria-label="First group" >
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew"  Text="New Payment" CssClass="btn btn-round btn-primary fa fa-plus" runat="server" OnClick="btnAddNew_Click">
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
                                <ClientSideEvents click="PrintReport"/>
            </dx:ASPxButton>
        </div>
         <div class="row" style="height: 10px"></div>

    
        <div id="lblApproved" runat="server">
            <h5>Waiting for Approval Payment</h5>
        </div>
    
    
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvWaitingApprovalAdvancedPayment" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridWaitingApprovalAdvancedPayment"
            DataSourceID="ObjectDataSource7" KeyFieldName="PaymentID" OnCustomButtonInitialize="GdvWaitingApprovalAdvancedPayment_CustomButtonInitialize" OnCommandButtonInitialize="GdvPendingAdvancedPayment_CommandButtonInitialize" OnCellEditorInitialize="GdvWaitingApprovalAdvancedPayment_CellEditorInitialize">
             <ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnApproveImage1') {window.location=('PaymentInfo.aspx?id=' + key + '_CanApprove');}}" />
            <Columns>
                 <%--<dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Default" Width="6%"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>--%>
                <dx:GridViewCommandColumn VisibleIndex="0" Caption="Approve" Width="5%">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnApproveImage1" Text=" ">
                            <Image Url="../images/kisspng-check-mark-2.png" Width="22" Height="22" ToolTip="Approve" ></Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                <%--====================--%>
                <%-- <dx:GridViewDataTextColumn Caption="Approve" VisibleIndex="0" Width="3%">  
                    <DataItemTemplate>  
                       
                   <dx:ASPxButton ID="btnApproveImage" runat="server" Border-BorderStyle="None" AutoPostBack="false" OnClick="btnApproveImage_Click">
                       <HoverStyle BackColor="Transparent"></HoverStyle>     
                       <Image Url="../images/kisspng-check-mark-2.png" Width="22" Height="22" ToolTip="Approve" ></Image>
                    </dx:ASPxButton> 
                  
                    </DataItemTemplate>  
                 </dx:GridViewDataTextColumn>  --%>
                <%--========================--%>
                <%--<dx:GridViewDataTextColumn FieldName="ReferenceNumber" Caption="Payment No" VisibleIndex="1" CellStyle-HorizontalAlign="Left" Width="10%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>--%>
                 <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderMasterID" Caption="Job Order No" VisibleIndex="1" Width="30%" CellStyle-HorizontalAlign="Left">
                                                <PropertiesComboBox ValueField="JobOrderMasterID" TextField="JobOrderNumber" DataSourceID="JobOrderDS" ValueType="System.Int64">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="60" />
                                                        <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />
                                                    </Columns>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />

                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                 <dx:GridViewDataDateColumn FieldName="PaymentDate" Caption="Date" VisibleIndex="2" CellStyle-HorizontalAlign="Left" Width="10%">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy"></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
               <dx:GridViewDataTextColumn FieldName="PaymentAmount" Caption="Payment Amount" VisibleIndex="4" CellStyle-HorizontalAlign="Left" Width="10%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn VisibleIndex="9" ButtonType="Default" Width="6%"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>
                 <dx:GridViewDataTextColumn FieldName="ReceivedBy" Caption="Received By" VisibleIndex="8" CellStyle-HorizontalAlign="Left" Width="8%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible"/>
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True"  ColumnResizeMode="NextColumn"/>
            <SettingsPager AlwaysShowPager="true" PageSize="10"></SettingsPager>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>
 
    <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PaymentMasterDB"
        SelectMethod="GetAllAdvancesPayment" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.PaymentMaster" ></asp:ObjectDataSource>

     <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
       DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveViewJobOrder"></asp:ObjectDataSource>

     <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PaymentMasterDB"
        SelectMethod="GetAllAgainstInvoiceAllNonApprovedAvancedPayment" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.PaymentMaster" ></asp:ObjectDataSource>

        <div>
         <dx:ASPxLabel ID="ASPxLabel1" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="ASPxLabel2" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="ASPxLabel3" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

    </div>







    <div>
        <h5>Pending Advanced Payment</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingAdvancedPayment" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPendingAdvancedPayment"
            DataSourceID="PaymentHistoryDS1" KeyFieldName="PaymentID" OnCustomButtonInitialize="GdvPendingAdvancedPayment_CustomButtonInitialize" OnCommandButtonInitialize="GdvPendingAdvancedPayment_CommandButtonInitialize" OnCellEditorInitialize="GdvPendingAdvancedPayment_CellEditorInitialize">
             <ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnConvert1') {window.location=('PaymentInfo.aspx?id=' + key);}}" />
            <Columns>
                 <dx:GridViewCommandColumn VisibleIndex="0" Caption="Convert" Width="5%">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnConvert1" Text=" ">
                            <Image Url="../images/kisspng-check-mark-2.png" Width="22" Height="22" ToolTip="Approve" ></Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="ReferenceNumber" Caption="Payment No" VisibleIndex="1" CellStyle-HorizontalAlign="Left" Width="10%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                 <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderMasterID" Caption="Job Order No" VisibleIndex="1" Width="30%" CellStyle-HorizontalAlign="Left">
                                                <PropertiesComboBox ValueField="JobOrderMasterID" TextField="JobOrderNumber" DataSourceID="JobOrderDS" ValueType="System.Int64">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="60" />
                                                        <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />
                                                    </Columns>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />

                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
                 <dx:GridViewDataDateColumn FieldName="PaymentDate" Caption="Date" VisibleIndex="2" CellStyle-HorizontalAlign="Left" Width="10%">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy"></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
               <dx:GridViewDataTextColumn FieldName="PaymentAmount" Caption="Payment Amount" VisibleIndex="4" CellStyle-HorizontalAlign="Left" Width="10%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn VisibleIndex="9" ButtonType="Default" Width="6%"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>
                 <dx:GridViewDataTextColumn FieldName="ReceivedBy" Caption="Received By" VisibleIndex="8" CellStyle-HorizontalAlign="Left" Width="8%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible"/>
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True"  ColumnResizeMode="NextColumn"/>
            <SettingsPager AlwaysShowPager="true" PageSize="10"></SettingsPager>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>

    <%--<div>
        <h5>Pending Advanced Payment </h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="ASPxGridView1" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPaymentHistory" OnBeforeGetCallbackResult="GdvPaymentHistory_BeforeGetCallbackResult"
            DataSourceID="PaymentHistoryDS" KeyFieldName="PaymentID" OnCellEditorInitialize="GdvPaymentHistory_CellEditorInitialize" OnCustomButtonInitialize="GdvPaymentHistory_CustomButtonInitialize" OnCommandButtonInitialize="GdvPaymentHistory_CommandButtonInitialize">
            <Columns>
               
                <dx:GridViewDataTextColumn FieldName="ReferenceNumber" Caption="Payment No" VisibleIndex="1" CellStyle-HorizontalAlign="Left" Width="10%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="PaymentDate" Caption="Date" VisibleIndex="2" CellStyle-HorizontalAlign="Left" Width="10%">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy"></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderMasterID" Caption="Job Order No" VisibleIndex="1" Width="250" CellStyle-HorizontalAlign="Left">
                                                <PropertiesComboBox ValueField="JobOrderMasterID" TextFormatString="{0} - {1} - {2} " DataSourceID="JobOrderDS" ValueType="System.Int64">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="60" />
                                                        <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />

                                                    </Columns>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />

                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
               <dx:GridViewDataTextColumn FieldName="PaymentAmount" Caption="Payment Amount" VisibleIndex="4" CellStyle-HorizontalAlign="Left" Width="10%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               
                <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" VisibleIndex="5" CellStyle-HorizontalAlign="Left" Width="40%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn VisibleIndex="6" ButtonType="Default" Width="80"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
                   <CustomButtons> // already commented --Start Line
                         <dx:GridViewCommandColumnCustomButton ID="btnView" Text=" " Image-ToolTip="" >
                         <Image Url="../images/vision-clipart-1-eye-8.png" Width="22" Height="22" ToolTip="View" ></Image>

                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons> // already commented --End Line
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
            <SettingsPager AlwaysShowPager="true" PageSize="10"></SettingsPager>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>--%>


        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>
 
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PaymentMasterDB"
        SelectMethod="GetAllAdvancesPayment" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.PaymentMaster" ></asp:ObjectDataSource>

     <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
       DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveViewJobOrder"></asp:ObjectDataSource>

     <asp:ObjectDataSource ID="PendingAvancedPaymentDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PaymentMasterDB"
        SelectMethod="GetAllPendingAvancedPayment" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.PaymentMaster" ></asp:ObjectDataSource>

        <div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

    </div>
     
     <div>
        <h5>Not Paid Invoice</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingPayment" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPendingPayment"
            DataSourceID="PendingPaymentDS" KeyFieldName="JobOrderMasterID" OnCustomButtonInitialize="GdvPendingPayment_CustomButtonInitialize" OnCommandButtonInitialize="GdvPendingPayment_CommandButtonInitialize">
             <ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnConvert') {window.location=('PaymentInfo.aspx?id=' + key + '&mode=Convert');}}" />
            <Columns>
                 <dx:GridViewCommandColumn VisibleIndex="0" Caption="Convert" Width="55">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnConvert" Text=" ">
                            <Image Url="../images/kisspng-check-mark-2.png" Width="22" Height="22" ToolTip="Approve" ></Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                 <dx:GridViewDataTextColumn FieldName="JobOrderNumber" Caption="Job Order No" VisibleIndex="1" CellStyle-HorizontalAlign="Left" Width="10%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Customer" VisibleIndex="1" CellStyle-HorizontalAlign="Left" Width="50%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               <dx:GridViewDataTextColumn FieldName="No_of_PendingPayment" Caption="No of PendingPayment" VisibleIndex="2" CellStyle-HorizontalAlign="Left" Width="20%"> 
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               <dx:GridViewDataTextColumn FieldName="TotalPendingAmount" Caption="Total Pending Amount" VisibleIndex="3" CellStyle-HorizontalAlign="Left" Width="20%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               
                 <dx:GridViewCommandColumn VisibleIndex="6" ButtonType="Default" Width="8%"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True"  VerticalScrollBarMode="Visible"/>
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True"  ColumnResizeMode="NextColumn"/>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
    </div>
    <div class="row" style="height: 10px"></div>

    

    <div>
        <h5>Payment History</h5>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPaymentHistory" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPaymentHistory" OnBeforeGetCallbackResult="GdvPaymentHistory_BeforeGetCallbackResult"
            DataSourceID="PaymentHistoryDS" KeyFieldName="PaymentID" OnCellEditorInitialize="GdvPaymentHistory_CellEditorInitialize" OnCustomButtonInitialize="GdvPaymentHistory_CustomButtonInitialize" OnCommandButtonInitialize="GdvPaymentHistory_CommandButtonInitialize">
             <ClientSideEvents CustomButtonClick="handleButtonClick" />
            <Columns>
               
                <dx:GridViewDataTextColumn FieldName="ReferenceNumber" Caption="Payment No" VisibleIndex="1" CellStyle-HorizontalAlign="Left" Width="10%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="PaymentDate" Caption="Date" VisibleIndex="2" CellStyle-HorizontalAlign="Left" Width="10%">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy"></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                  <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderMasterID" Caption="Job Order No" VisibleIndex="1" CellStyle-HorizontalAlign="Left" Width="30%">
                                                <PropertiesComboBox ValueField="JobOrderMasterID" TextField="JobOrderNumber" DataSourceID="JobOrderDS" ValueType="System.Int64">
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="60" />
                                                        <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                                                        <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />
                                                        
                                                    </Columns>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />

                                             <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataComboBoxColumn>
               <dx:GridViewDataTextColumn FieldName="PaymentAmount" Caption="Payment Amount" VisibleIndex="4" CellStyle-HorizontalAlign="Left" Width="10%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
               
                <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" VisibleIndex="5" CellStyle-HorizontalAlign="Left" Width="40%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn VisibleIndex="9" ButtonType="Default" Width="8%"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
                    <CustomButtons>
                         <dx:GridViewCommandColumnCustomButton ID="btnView1" Text=" " Image-ToolTip="" >
                         <Image Url="../images/vision-clipart-1-eye-8.png" Width="22" Height="22" ToolTip="View" ></Image>

                        </dx:GridViewCommandColumnCustomButton>

                        <dx:GridViewCommandColumnCustomButton ID="btnDeleteSR" Text=" ">
                            <Styles>
                                <Style Font-Size="Medium" CssClass="fa fa-trash"></Style>
                            </Styles>
                        </dx:GridViewCommandColumnCustomButton>
 <dx:GridViewCommandColumnCustomButton ID="btnAttachSR" Text=" ">
                            <Styles>
                                <Style Font-Size="Medium" CssClass="fa fa-paperclip"></Style>
                            </Styles>
                        </dx:GridViewCommandColumnCustomButton>

                    </CustomButtons>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="ReceivedBy" Caption="Received By" VisibleIndex="8" CellStyle-HorizontalAlign="Left" Width="8%">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
            </SettingsCommandButton>
            <Settings ShowFilterRow="True" />
            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn"/>
            <SettingsPager AlwaysShowPager="true" PageSize="10"></SettingsPager>
            <Styles>
  <Header BackColor="SteelBlue" ForeColor="White"></Header>
  </Styles>
        </dx:ASPxGridView>
        <dx:ASPxTextBox ID="sid" runat="server" ClientInstanceName="sid" ClientVisible="false" Text="0"></dx:ASPxTextBox>
    </div>

     <div>
        <dx:ASPxPopupControl ID="popupDelete" runat="server" CloseAction="CloseButton" 
            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" AllowDragging="False" PopupAnimationType="Slide"
            ShowFooter="True" Width="510px" HeaderText="Reason For Delete" ShowCloseButton="false" HeaderStyle-BackColor="SteelBlue" HeaderStyle-ForeColor="White" ClientInstanceName="popupDelete">
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
                            <ClientSideEvents Click="function(s, e) {if(txtDeleteReason.GetText()==''){alert('Please provide delete reason');return;} }" />
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
        <asp:ObjectDataSource ID="CustomersListDS" runat="server" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>
 
     <asp:ObjectDataSource ID="PaymentHistoryDS1" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PaymentMasterDB"
        SelectMethod="GetAllAgainstInvoiceAllPendingAvancedPayment" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.PaymentMaster" ></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="PaymentHistoryDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PaymentMasterDB"
        SelectMethod="GetAllAgainstInvoicePayment" DeleteMethod="Delete" DataObjectTypeName="BusinessLayer.PaymentMaster" ></asp:ObjectDataSource>

     
      <asp:ObjectDataSource ID="PendingPaymentDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PaymentMasterDB"
        DataObjectTypeName="BusinessLayer.ViewPendingPayment" SelectMethod="GetAllPendingPayment" ></asp:ObjectDataSource>
   
     <asp:ObjectDataSource ID="JobOrderDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveViewJobOrder"></asp:ObjectDataSource>

</asp:Content>
