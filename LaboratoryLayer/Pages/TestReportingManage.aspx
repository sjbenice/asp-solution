<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="TestReportingManage.aspx.cs" Inherits="LaboratoryLayer.Pages.TestReportingManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <style>
        .statusBar a:first-child {
            display: none;
        }
      .statusBar {
            display: none;
        }
    </style>
    <style type="text/css">
        .HideScroll > tbody > tr > td > div {
            overflow: hidden !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PagePath" runat="server">
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
            function PrintReport(s, e) {
                if (s.globalName == 'btnPendingToReport') {
                    window.open('ReportViwerNew.aspx?reportName=PendingReports&typeName=TestReportingDB&dataObjectTypeName=TestReporting&selectMethod=GetAllPending&filterExpress=' + gridPendingToReport.cpgridPendingToReportFilter);
                }
                else if (s.globalName == 'btnPendingToCheck') {
                    window.open('ReportViwerNew.aspx?reportName=PendingToCheck&typeName=TestReportingDB&dataObjectTypeName=TestReporting&selectMethod=GetPendingToCheck&filterExpress=' + gridPendingToCheckReport.cpgridPendingToCheckReportFilter);
                }
                
                else if (s.globalName == 'btnPendingToApprove') {
                    window.open('ReportViwerNew.aspx?reportName=PendingToApprove&typeName=TestReportingDB&dataObjectTypeName=TestReporting&selectMethod=GetPendingToApprove&filterExpress=' + gridPendingToApproveReport.cpgridPendingToApproveReportFilter);
                } 
                else if (s.globalName == 'btnCompleteReport') {
                    window.open('ReportViwerNew.aspx?reportName=Completed&typeName=TestReportingDB&dataObjectTypeName=TestReporting&selectMethod=GetAllCompleted&filterExpress=' + gridCompletedReport.cpgridCompletedReportFilter);
                } 
            }
        </script>
        <ul class="breadcrumb" runat="server" id="ultitle">
            <li>
                <i class="ace-icon fa fa-home home-icon"></i>
                <a href="../Default.aspx">Home</a>
            </li>
            <li><a id="menu1" href="#">Transaction</a></li>
            <li class="active" id="menulink">Test Reporting</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Test Reporting</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="row" style="height: 20px"></div>
    <div id="PendingToReport" runat="server">
    <div>
       <table>
           <tr>
               <td><h5 id="PendingToReporth5" runat="server">Pending To Report</h5> </td>
               <td><h5> </h5></td>
               <td style="text-align:right;">
                    <dx:ASPxButton AutoPostBack="false" ID="btnPendingToReport" ClientInstanceName="btnPendingToReport" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server"  >

                <ClientSideEvents  click="PrintReport"/>
            </dx:ASPxButton>
               </td>
           </tr>
       </table>  
        <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError" ForeColor="Red"></dx:ASPxLabel>
    </div>
    <script type="text/javascript">
       

        function onpendingrowclick(s, e) {
            gridPendingToReport.StartEditRow(e.visibleIndex);
        }
        
        function btnReviewgridCompletedReport_Init(s, e) {
            if (gridCompletedReport.cpIsEdit == "true")
                s.SetVisible(true);
            else
                s.SetVisible(false);
        }
        function btnApprovegridPendingToApproveReport_Init(s, e) {
            if (gridPendingToApproveReport.cpIsAdd == "true")
                s.SetVisible(true);
            else
                s.SetVisible(false);
        }
        function btnApprovegridPendingToCheckReport_Init(s, e)
        {
            if(gridPendingToCheckReport.cpIsAdd=="true")
                s.SetVisible(true);
            else
                s.SetVisible(false);
           
        }
        function btnSendForCheckgridPendingToReport_Init(s, e) {
            if (gridPendingToReport.cpIsAdd == "true")
                s.SetVisible(true);
            else
                s.SetVisible(false);   

        }
        function gridCompletedReportEndCallback(s, e) {
       
            if (s.cpRowCommandCompleted.trim() !== "" && s.cpRowCommandCompleted.trim() !== "ReviseCompleted") {
                redirectToUrl(s.cpRowCommandCompleted);

            }
            if (s.cpRowCommandCompleted.trim() === "ReviseCompleted")
            {
                gridPendingToReport.Refresh();
                PLMSAspxLoadingPanel.Hide();
            }
            s.cpRowCommandCompleted = "";
        }
        
        function onBtnReviseCheckClick(s, e) {
            PLMSAspxLoadingPanel.Show();
            gridCompletedReport.PerformCallback('BtnReviseCheck|' + s.globalName);
        }
        function onBtnCheckClick(s, e) {
    
            gridCompletedReport.PerformCallback('btnPrintDetailClicked|' + s.globalName);
        }
        function ontestendingdatechange(s, e) {
            gridPendingToReport.UpdateEdit();
        }
        function GdvPendingToReportOnRowClick1(s, e) {
            var clickedElement = e.htmlEvent.target;

            if (clickedElement.title === "Send For Check") {
                PLMSAspxLoadingPanel.Show();
            }
          
        }
        function GdvPendingToReportOnRowClick(s, e) {
            var clickedElement = e.htmlEvent.target;

            if (clickedElement.title === "Send For Check") 
            {
               PLMSAspxLoadingPanel.Show();
            }
            else if (clickedElement.title === "Edit")
            {
                gridPendingToReport.StartEditRow(e.visibleIndex);
            }
        }
        function GdvPendingToReportEndCallback(s, e) {

            PLMSAspxLoadingPanel.Hide();

        }
       
        function handleCloseEvent(s, e) {
            if (s.title!=='') {
                eval(s.title).Refresh();
            }
        }
        function ShowAttachmentWindow(link, caller) {
            PLMSASPxPopupControl.title = caller;
            PLMSASPxPopupControl.SetContentUrl(link);
            PLMSASPxPopupControl.Show();

        }

        function redirectToUrl(fileUrl) {

            debugger;
            var deencodedFileUrl = decodeURIComponent(fileUrl);

            var newrul = fileUrl;
            var normalizedFileUrl = deencodedFileUrl.replace(/\+/g, ' ').replace(/\\/g, '/');
            window.location.href = encodeURI(normalizedFileUrl);
            return false; // This prevents the button from causing a postback
        }
        function ChangeLink(fileUrl, reportNumber) {
            debugger;
            var deencodedFileUrl = decodeURIComponent(fileUrl);

            var newrul = fileUrl;
            var normalizedFileUrl = deencodedFileUrl.replace(/\+/g, ' ').replace(/\\/g, '/');

            var lastSlashIndex = normalizedFileUrl.lastIndexOf('/');
            var directoryPath = (lastSlashIndex !== -1) ? normalizedFileUrl.substring(0, lastSlashIndex + 1) : '';

            var fileNameWithoutExtension = normalizedFileUrl.split('/').pop().split('.').slice(0, -1).join('.');

            var pdfLink = directoryPath + "WorkSheet/WS-" + reportNumber + ".pdf";

            window.location.href = pdfLink;

            return false;
        }
        function ChangeLinkED(fileUrl, reportNumber) {
            debugger;
            var deencodedFileUrl = decodeURIComponent(fileUrl);

            var newrul = fileUrl;
            var normalizedFileUrl = deencodedFileUrl.replace(/\+/g, ' ').replace(/\\/g, '/');

            var lastSlashIndex = normalizedFileUrl.lastIndexOf('/');
            var directoryPath = (lastSlashIndex !== -1) ? normalizedFileUrl.substring(0, lastSlashIndex + 1) : '';

            var fileNameWithoutExtension = normalizedFileUrl.split('/').pop().split('.').slice(0, -1).join('.');

            var pdfLink = directoryPath.replace('PDFReport', 'EntryData') + "ED-" + reportNumber + ".pdf";

            window.location.href = pdfLink;

            return false;
        }
      
    </script>
                       <div class="row" style="height: 10px"></div>

    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingToReport" AutoGenerateColumns="False" Width="100%" ClientInstanceName="gridPendingToReport"            
            DataSourceID="AllPendingTestReportingDS" KeyFieldName="TestReportingID" OnCellEditorInitialize="GdvPendingToReport_CellEditorInitialize"
            OnCustomCallback="GdvPendingToReport_CustomCallback"  OnBeforeGetCallbackResult="GdvPendingToReport_BeforeGetCallbackResult"
              OnHtmlRowCreated="GdvPendingToReport_HtmlRowCreated"
            OnRowCommand="GdvPendingToReport_RowCommand" SettingsDataSecurity-AllowEdit="true" 
            OnRowUpdating="GdvPendingToReport_RowUpdating">
            <ClientSideEvents RowClick="GdvPendingToReportOnRowClick" EndCallback="GdvPendingToReportEndCallback" />
            <Columns>  
                 <dx:GridViewDataHyperLinkColumn Name="Attachment" Width="40" VisibleIndex="0">
                            <HeaderCaptionTemplate>
                                <center><span class="glyphicon glyphicon-paperclip"></span></center>
                            </HeaderCaptionTemplate>
                            <DataItemTemplate>
                                <a target='blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" 
onclick='<%# "ShowAttachmentWindow(\"../Pages/AttachmentsReport.aspx?TransTypeID=111222&TransID=" + Eval("TestReportingID") +"\", \"gridPendingToReport\")" %>'
                                    title="Attachments"><span runat="server" class="badge" id="attchCount">0</span></a>
                            </DataItemTemplate>
                        </dx:GridViewDataHyperLinkColumn>
                <dx:GridViewDataTextColumn FieldName="ReportNumber" Caption="Report Number" VisibleIndex="1" Width="100" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                    <DataItemTemplate>
                        <a target='_blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" href="<%# Eval("FileUrl") %>" title="Excel File"><%# Eval("ReportNumber") %></a>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>   
                <%-- <dx:GridViewDataTextColumn  Caption="Worksheet" VisibleIndex="1" Width="110" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                    <DataItemTemplate>
</DataItemTemplate>
                </dx:GridViewDataTextColumn> --%>          
               <%-- <dx:GridViewDataTextColumn FieldName="SampleNumber" Caption="Sample Number" VisibleIndex="2" Width="100" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>--%>
                <dx:GridViewDataTextColumn Name="Sample Number" FieldName="SampleNumber" Width="100" VisibleIndex="2">
                          
                            <DataItemTemplate>
                                <a target='blank' 
onclick='<%# "ShowAttachmentWindow(\"../Pages/SmapleReceiveAndAttachmentView.aspx?id=42084&TransTypeID=22222&TransID=" + Eval("TestReportingID") +"\", \"\")" %>'
                                    title="Attachments"><%# Eval("SampleNumber") %></a> <br />
                                 <a 
                   onclick='<%# "return ChangeLink(\"" + HttpUtility.UrlEncode(Eval("FileUrl").ToString()) + "\", \"" + Eval("ReportNumber") + "\")" %>'>
                   WS-<%# Eval("ReportNumber") %></a>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                 <dx:GridViewDataDateColumn FieldName="SampleReceivedDate" Caption="Date of Received" VisibleIndex="3" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy HH:mm" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
               
               <dx:GridViewDataComboBoxColumn FieldName="FKCustomerID" Caption="Customer Name" VisibleIndex="4" CellStyle-HorizontalAlign="Left" Visible ="false">
                    <PropertiesComboBox ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS"></PropertiesComboBox>
                 <Settings AutoFilterCondition="Contains"/> 
               </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataComboBoxColumn FieldName="FKProjectID" Caption="Project Name" VisibleIndex="5" CellStyle-HorizontalAlign="Left" Visible ="false">
                    <PropertiesComboBox ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS"></PropertiesComboBox>
                 <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataComboBoxColumn>
               
                <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Test Name" VisibleIndex="6"  Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="TestID" TextField="TestName" DataSourceID="TestsListDS"></PropertiesComboBox>
                 <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataComboBoxColumn>
                  <dx:GridViewDataTextColumn FieldName="StandardNumber" Caption="Standard Number" VisibleIndex="7" Width="150" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn FieldName="LabName" Caption="Lab Section" VisibleIndex="8" Width="150" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>
                  <dx:GridViewDataDateColumn FieldName="SuggestedTestingDate" Caption="Suggested Date" 
                     VisibleIndex="9" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy HH:mm" >
                     </PropertiesDateEdit>                    
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="TestEndingDate" Caption="Test Ending Date" 
                    PropertiesDateEdit-ClientSideEvents-ValueChanged="ontestendingdatechange" VisibleIndex="10" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy HH:mm" >
                     </PropertiesDateEdit>                    
                </dx:GridViewDataDateColumn>
               
               
                 <%--    <dx:GridViewDataTextColumn Caption="ScannedLabWS" VisibleIndex="8" Width="250" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                               <DataItemTemplate>
                         <span runat="server"  id="ScannedLabWS">0</span>
                                   </DataItemTemplate>
                </dx:GridViewDataTextColumn>--%>
              
                
                 <dx:GridViewDataTextColumn VisibleIndex="12" Width="100" Caption="Send For Check"   CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <table>
                            <tr>
                                <td>       <dx:ASPxButton ID="BtnSendForCheck"  OnInit="BtnSendForCheck_Init" 
                                    
                                    HorizontalAlign="Center" runat="server" Cursor="pointer" RenderMode="Link" ToolTip="Send For Check" 
                            EnableTheming="false" EnableViewState="false" CommandName="sendforcheck" Text="" CommandArgument=<%#Eval("TestReportingID") %>>
                           <Image ToolTip="Send For Check" Url="../images/share_button_final_179539-2.png" Width="18" Height="18"></Image>
                                    <ClientSideEvents Init="btnSendForCheckgridPendingToReport_Init" />
                        </dx:ASPxButton></td>
                                <td>
                                     <dx:ASPxButton ID="btnEditSuggestedDate" ClientInstanceName="btnEditSuggestedDate" ToolTip="Edit"  AutoPostBack="false"
                                    
                                    HorizontalAlign="Center" runat="server" Cursor="pointer" RenderMode="Link" 
                            EnableTheming="false" EnableViewState="false"  Text="" CommandArgument=<%#Eval("TestReportingID") %>>
                                      
                           <Image ToolTip="Edit"  Url="../images/grd_edit.png" Width="18" Height="18"></Image>
                                                                             <ClientSideEvents Init="btnSendForCheckgridPendingToReport_Init" />

                        </dx:ASPxButton>
                                </td>

                            </tr>
                        </table>
                 
         
                    </DataItemTemplate>
                    
                        

                </dx:GridViewDataTextColumn>

            </Columns>
            
           <SettingsEditing Mode="PopupEditForm"  />   
            <SettingsPopup EditForm-HorizontalAlign="WindowCenter" EditForm-VerticalAlign="WindowCenter"></SettingsPopup>   
            <Settings ShowTitlePanel="true" ShowFilterRow="True" VerticalScrollBarMode="Visible" />
            <SettingsBehavior  AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <Styles StatusBar-CssClass="statusBar" />
            <%--<ClientSideEvents RowClick="onpendingrowclick" />--%>
            <Styles>
                <Header BackColor="SteelBlue" ForeColor="White"></Header>
            </Styles>
        </dx:ASPxGridView>
    </div>
    </div>
    <div class="row" style="height: 10px"></div>


    <div id="PendingToCheck" runat="server">
    <div>
       

         <table>
           <tr>
               <td> <h5 id="PendingToCheckh5" runat="server">Pending To Check</h5></td>
               <td><h5> </h5></td>
               <td style="text-align:right;">
                    <dx:ASPxButton AutoPostBack="false" ID="btnPendingToCheck" ClientInstanceName="btnPendingToCheck" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server"  >

                <ClientSideEvents  click="PrintReport"/>
            </dx:ASPxButton>
               </td>
           </tr>
       </table>  
    </div>
     <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingToCheckReport" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPendingToCheckReport"
            DataSourceID="PendingToCheckTestReportingDS"
                          OnHtmlRowCreated="GdvPendingToReport_HtmlRowCreated"
             OnBeforeGetCallbackResult="GdvPendingToCheckReport_BeforeGetCallbackResult"
            KeyFieldName="TestReportingID" OnCustomCallback="GdvPendingToCheckReport_CustomCallback" OnRowCommand="GdvPendingToCheckReport_RowCommand">
                        <ClientSideEvents RowClick="GdvPendingToReportOnRowClick1" EndCallback="GdvPendingToReportEndCallback" />

            <Columns>   
                     <dx:GridViewDataHyperLinkColumn Name="Attachment" Width="40" VisibleIndex="0">
                            <HeaderCaptionTemplate>
                                <center><span class="glyphicon glyphicon-paperclip"></span></center>
                            </HeaderCaptionTemplate>
                            <DataItemTemplate>
                                <a target='blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" 
onclick='<%# "ShowAttachmentWindow(\"../Pages/AttachmentsReport.aspx?TransTypeID=111222&TransID=" + Eval("TestReportingID") +"\", \"gridPendingToCheckReport\")" %>'
                                    title="Attachments"><span runat="server" class="badge" id="attchCount">0</span></a>
                            </DataItemTemplate>
                        </dx:GridViewDataHyperLinkColumn>
                 <dx:GridViewDataTextColumn  Caption="SampleNumber EnterData" FieldName="SampleNumber" VisibleIndex="2"  Width="110" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                    <DataItemTemplate>
                          <a target='blank' 
onclick='<%# "ShowAttachmentWindow(\"../Pages/SmapleReceiveAndAttachmentView.aspx?id=42084&TransTypeID=22222&TransID=" + Eval("TestReportingID") +"\", \"\")" %>'
                                    title="Attachments"><%# Eval("SampleNumber") %></a><br />
 <a 
                   onclick='<%# "return ChangeLinkED(\"" + HttpUtility.UrlEncode(Eval("FileUrl").ToString()) + "\", \"" + Eval("ReportNumber") + "\")" %>'>
                   ED-<%# Eval("ReportNumber") %></a></DataItemTemplate>
                </dx:GridViewDataTextColumn> 
             
                 <dx:GridViewDataDateColumn FieldName="SampleReceivedDate" Caption="Date of Received" VisibleIndex="4" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy HH:mm" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                
                <dx:GridViewDataTextColumn FieldName="ReportNumber" Caption="Report Number" VisibleIndex="1" Width="100" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                    <DataItemTemplate>
                        <a target='_blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px"
                            href="<%# Eval("FileUrl") %>" title="PDF File"><%# Eval("ReportNumber") %></a>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
               
               <dx:GridViewDataComboBoxColumn FieldName="FKCustomerID" Caption="Customer Name" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS"></PropertiesComboBox>
                 <Settings AutoFilterCondition="Contains"/> 
               </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataComboBoxColumn FieldName="FKProjectID" Caption="Project Name" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS"></PropertiesComboBox>
                 <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataComboBoxColumn>
               
                <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Test Name" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="TestID" TextField="TestName" DataSourceID="TestsListDS"></PropertiesComboBox>
                 <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataComboBoxColumn>
                                  <dx:GridViewDataTextColumn FieldName="StandardNumber" Caption="StandardNumber" VisibleIndex="7" Width="150" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn FieldName="LabName" Caption="LabSection" VisibleIndex="8" Width="150" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="TestEndingDate" Caption="Entered Date" VisibleIndex="9" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy HH:mm" >
                     </PropertiesDateEdit>                    
                </dx:GridViewDataDateColumn>

                <dx:GridViewDataTextColumn VisibleIndex="10" Caption="Check"   Width="100" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <dx:ASPxButton ID="btnCheck" HorizontalAlign="Center" runat="server" Cursor="pointer" RenderMode="Link" ToolTip="Send For Check" EnableTheming="false" EnableViewState="false" CommandName="check" Text="" CommandArgument=<%#Eval("TestReportingID") %>>
                           <Image ToolTip="Check" Url="../images/select.png" Width="22" Height="22"></Image>
                            <ClientSideEvents Init="btnApprovegridPendingToCheckReport_Init" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnRejectCheck" HorizontalAlign="Center"  runat="server" Cursor="pointer" RenderMode="Link" ToolTip="Send For Check" EnableTheming="false" EnableViewState="false" CommandName="reject" Text="" CommandArgument=<%#Eval("TestReportingID") %>>
                           <Image ToolTip="Reject" Url="../images/grd_Delete.png" Width="22" Height="22"></Image>
                              <ClientSideEvents Init="btnApprovegridPendingToCheckReport_Init" />
                        </dx:ASPxButton>
                    </DataItemTemplate>
                    <%--<CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnCheck" Text=" ">
                            <Image Url="../images/select.png" Width="22" Height="22" ToolTip="Accept"></Image>
                        </dx:GridViewCommandColumnCustomButton>
                        <dx:GridViewCommandColumnCustomButton ID="btnRejectCheck" Text=" ">
                            <Image Url="../images/grd_Delete.png" Width="22" Height="22" ToolTip="Reject"></Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>--%>
                </dx:GridViewDataTextColumn>
            </Columns>   
            <Settings ShowTitlePanel="true" ShowFilterRow="True" VerticalScrollBarMode="Visible" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <Styles StatusBar-CssClass="statusBar" />
            <Styles>
                <Header Wrap="True" BackColor="SteelBlue" ForeColor="White"></Header>
            </Styles>
        </dx:ASPxGridView>
    </div>
        </div>


     <div  id="PendingToApprove" runat="server">
    <div>
      

        <table>
           <tr>
               <td>   <h5 id="PendingToApproveh5" runat="server">Pending To Approve</h5></td>
               <td><h5> </h5></td>
               <td style="text-align:right;">
                    <dx:ASPxButton AutoPostBack="false" ID="btnPendingToApproveh" ClientInstanceName="btnPendingToApprove" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server"  >

                <ClientSideEvents  click="PrintReport"/>
            </dx:ASPxButton>
               </td>
           </tr>
       </table>
    </div>
     <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingToApproveReport" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPendingToApproveReport"
            DataSourceID="PendingToApproveTestReportingDS" 
                          OnHtmlRowCreated="GdvPendingToReport_HtmlRowCreated"
                         OnBeforeGetCallbackResult="GdvPendingToApproveReport_BeforeGetCallbackResult"

            KeyFieldName="TestReportingID" OnCustomCallback="GdvPendingToApproveReport_CustomCallback" OnRowCommand="GdvPendingToApproveReport_RowCommand">
                        <ClientSideEvents RowClick="GdvPendingToReportOnRowClick1" EndCallback="GdvPendingToReportEndCallback" />

             <%--<ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnApprove') {window.location=('TestReportingManage.aspx?id=' + key + '&statusId=3');} else if (e.buttonID == 'btnRejectApprove') {window.location=('TestReportingManage.aspx?id=' + key + '&statusId=0');}}" />--%>
            <Columns> 
                     <dx:GridViewDataHyperLinkColumn Name="Attachment" Width="40" VisibleIndex="0">
                            <HeaderCaptionTemplate>
                                <center><span class="glyphicon glyphicon-paperclip"></span></center>
                            </HeaderCaptionTemplate>
                            <DataItemTemplate>
                                <a target='blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" 
onclick='<%# "ShowAttachmentWindow(\"../Pages/AttachmentsReport.aspx?TransTypeID=111222&TransID=" + Eval("TestReportingID") +"\", \"gridPendingToApproveReport\")" %>'
                                    title="Attachments"><span runat="server" class="badge" id="attchCount">0</span></a>
                            </DataItemTemplate>
                        </dx:GridViewDataHyperLinkColumn>
                 <dx:GridViewDataTextColumn  Caption="SampleNumber EnterData"  FieldName="SampleNumber" VisibleIndex="2" Width="110" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                    <DataItemTemplate>
                         <a target='blank' 
onclick='<%# "ShowAttachmentWindow(\"../Pages/SmapleReceiveAndAttachmentView.aspx?id=42084&TransTypeID=22222&TransID=" + Eval("TestReportingID") +"\", \"\")" %>'
                                    title="Attachments"><%# Eval("SampleNumber") %></a> <br />
 <a 
                   onclick='<%# "return ChangeLinkED(\"" + HttpUtility.UrlEncode(Eval("FileUrl").ToString()) + "\", \"" + Eval("ReportNumber") + "\")" %>'>
                   ED-<%# Eval("ReportNumber") %></a></DataItemTemplate>
                </dx:GridViewDataTextColumn> 
             <%--   <dx:GridViewDataTextColumn FieldName="SampleNumber"
                    Caption="Sample Number" VisibleIndex="2" Width="100" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Name="SampleNumber" FieldName="SampleNumber" Width="100" VisibleIndex="3">
                          
                            <DataItemTemplate>
                               
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>--%>
                 <dx:GridViewDataDateColumn FieldName="SampleReceivedDate" Caption="Date of Received" VisibleIndex="4" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy HH:mm" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>

                <dx:GridViewDataTextColumn FieldName="ReportNumber" Caption="Report Number"  VisibleIndex="1" Width="100" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                       <DataItemTemplate>
                        <a target='_blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" href="<%# Eval("FileUrl") %>" title="PDF File"><%# Eval("ReportNumber") %></a>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
               
               <dx:GridViewDataComboBoxColumn FieldName="FKCustomerID" Caption="Customer Name" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS"></PropertiesComboBox>
                 <Settings AutoFilterCondition="Contains"/> 
               </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataComboBoxColumn FieldName="FKProjectID" Caption="Project Name" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS"></PropertiesComboBox>
                 <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataComboBoxColumn>
               
                <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Test Name" VisibleIndex="7" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="TestID" TextField="TestName" DataSourceID="TestsListDS"></PropertiesComboBox>
                 <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataComboBoxColumn>
                                  <dx:GridViewDataTextColumn FieldName="StandardNumber" Caption="StandardNumber" VisibleIndex="8" Width="150" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn FieldName="LabName" Caption="LabSection" VisibleIndex="9" Width="150" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>
                  <dx:GridViewDataDateColumn FieldName="CheckedDate" Caption="Check Date" VisibleIndex="10" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy HH:mm" >
                     </PropertiesDateEdit>                    
                </dx:GridViewDataDateColumn>

                <dx:GridViewDataTextColumn VisibleIndex="11" Caption="Approve"    Width="100" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <dx:ASPxButton ID="btnApprove" HorizontalAlign="Center" runat="server" Cursor="pointer" 
                             RenderMode="Link" ToolTip="Send For Check" EnableTheming="false" EnableViewState="false" CommandName="approve" Text=""
                             CommandArgument=<%#Eval("TestReportingID") %>>
                            <ClientSideEvents Init="btnApprovegridPendingToApproveReport_Init" />
                           <Image ToolTip="Approve" Url="../images/select.png" Width="22" Height="22"></Image>
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnRejectApprove" HorizontalAlign="Center" runat="server" Cursor="pointer"  RenderMode="Link" ToolTip="Send For Check" EnableTheming="false" EnableViewState="false" CommandName="reject" Text="" CommandArgument=<%#Eval("TestReportingID") %>>
                           <Image ToolTip="Reject" Url="../images/grd_Delete.png" Width="22" Height="22"></Image>
                                                        <ClientSideEvents Init="btnApprovegridPendingToApproveReport_Init" />

                        </dx:ASPxButton>
                    </DataItemTemplate>
                    <%--<CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnApprove" Text=" ">
                            <Image Url="../images/select.png" Width="22" Height="22" ToolTip="Accept"></Image>
                        </dx:GridViewCommandColumnCustomButton>
                        <dx:GridViewCommandColumnCustomButton ID="btnRejectApprove" Text=" ">
                            <Image Url="../images/grd_Delete.png" Width="22" Height="22" ToolTip="Reject"></Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>--%>
                </dx:GridViewDataTextColumn>
            </Columns>
            <Settings ShowTitlePanel="true" ShowFilterRow="True" VerticalScrollBarMode="Visible" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <Styles StatusBar-CssClass="statusBar" />
            <Styles>
                <Header Wrap="True"  BackColor="SteelBlue" ForeColor="White"></Header>
            </Styles>
        </dx:ASPxGridView>
    </div>
</div>


    <div  id="CompleteReport" runat="server">
    <div>
         <table>
           <tr>
               <td>           <h5 id="CompleteReporth5" runat="server">Completed Report</h5>
</td>
               <td><h5> </h5></td>
               <td style="text-align:right;">
                    <dx:ASPxButton AutoPostBack="false" ID="btnCompleteReport" ClientInstanceName="btnCompleteReport" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server"  >

                <ClientSideEvents  click="PrintReport"/>
            </dx:ASPxButton>
               </td>
           </tr>
       </table>
    </div>
     <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvCompletedReport" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridCompletedReport"
            DataSourceID="CompletedTestReportingDS"
                          OnHtmlRowCreated="GdvPendingToReport_HtmlRowCreated"
            OnBeforeGetCallbackResult="GdvCompletedReport_BeforeGetCallbackResult"
            KeyFieldName="TestReportingID" SettingsLoadingPanel-Mode="Disabled" OnCustomCallback="GdvCompletedReport_CustomCallback" OnRowCommand="GdvCompletedReport_RowCommand">
            <ClientSideEvents   EndCallback="gridCompletedReportEndCallback" />
            <Columns>
                     <dx:GridViewDataHyperLinkColumn Name="Attachment" Width="40" VisibleIndex="0">
                            <HeaderCaptionTemplate>
                                <center><span class="glyphicon glyphicon-paperclip"></span></center>
                            </HeaderCaptionTemplate>
                            <DataItemTemplate>
                                <a target='blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" 
onclick='<%# "ShowAttachmentWindow(\"../Pages/AttachmentsReport.aspx?TransTypeID=111222&TransID=" + Eval("TestReportingID") +"\", \"gridCompletedReport\")" %>'
                                    title="Attachments"><span runat="server" class="badge" id="attchCount">0</span></a>
                            </DataItemTemplate>
                        </dx:GridViewDataHyperLinkColumn>
                <dx:GridViewDataTextColumn FieldName="FKSampleReceiveTestID" Caption="SampleReceiveTestID" VisibleIndex="0" Visible="False">
                </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn  Caption="SampleNumber EnterData"  FieldName="SampleNumber" VisibleIndex="2" Width="75" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                    <DataItemTemplate>
                        <a target='blank' 
onclick='<%# "ShowAttachmentWindow(\"../Pages/SmapleReceiveAndAttachmentView.aspx?id=42084&TransTypeID=22222&TransID=" + Eval("TestReportingID") +"\", \"\")" %>'
                                    title="Attachments"><%# Eval("SampleNumber") %></a> <br />
 <a 
                   onclick='<%# "return ChangeLinkED(\"" + HttpUtility.UrlEncode(Eval("FileUrl").ToString()) + "\", \"" + Eval("ReportNumber") + "\")" %>'>
                   ED-<%# Eval("ReportNumber") %></a></DataItemTemplate>
                </dx:GridViewDataTextColumn> 
             <%--   <dx:GridViewDataTextColumn FieldName="SampleNumber"
                    Caption="Sample Number" VisibleIndex="2" Width="100" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Name="SampleNumber" FieldName="SampleNumber" Width="100" VisibleIndex="3">
                                          <Settings AutoFilterCondition="Contains"/> 

                            <DataItemTemplate>
                                
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn> --%>
               <%-- <dx:GridViewDataTextColumn FieldName="SampleNumber" Caption="Sample Number" VisibleIndex="2" Width="100" CellStyle-HorizontalAlign="Left">
                    <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>--%>

                 <dx:GridViewDataDateColumn FieldName="SampleReceivedDate" Caption="Date of Received" VisibleIndex="4" Width="100" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy HH:mm" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>

                <dx:GridViewDataHyperLinkColumn FieldName="ReportNumber" Caption="Report Number" VisibleIndex="1" Width="100" CellStyle-HorizontalAlign="Left">
                    <Settings AutoFilterCondition="Contains"/>  
                      <DataItemTemplate>
                        <a target='_blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 100%" href="<%# Eval("FileUrl") %>" 
                            title="PDF File">
                            <%# Convert.ToInt32(Eval("RevisionNo")) > 0 ? Convert.ToString(Eval("ReportNumber"))+"-A0" +Convert.ToString(Eval("RevisionNo")) : Convert.ToString(Eval("ReportNumber")) %>
                          

                        </a>
                    </DataItemTemplate>
                </dx:GridViewDataHyperLinkColumn>
               
                 <dx:GridViewDataTextColumn FieldName="RevisionNo" Caption="Revision No" VisibleIndex="5" Width="75" CellStyle-HorizontalAlign="Left">
                    <Settings AutoFilterCondition="Equals"/> 
                </dx:GridViewDataTextColumn>

                <%-- <dx:GridViewCommandColumn Caption="Revise Report" VisibleIndex="5" ButtonType="Button" Width="120" CellStyle-HorizontalAlign="Center">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnRevise" Text="Revise" Image-ToolTip="Revise" Styles-Style-CssClass="btn-default">
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>--%>
                <%--<dx:GridViewDataColumn Caption="Revise"  Width="75" VisibleIndex="5" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
            
                            
                         
                    </DataItemTemplate>
                 </dx:GridViewDataColumn>--%>

               <dx:GridViewDataComboBoxColumn FieldName="FKCustomerID" Caption="Customer Name"  VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="CustomerID" TextField="CustomerName" DataSourceID="CustomersListDS"></PropertiesComboBox>
                 <Settings AutoFilterCondition="Contains"/> 
               </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataComboBoxColumn FieldName="FKProjectID" Caption="Project Name"  VisibleIndex="7" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="ProjectID" TextField="ProjectName" DataSourceID="ProjectsListDS"></PropertiesComboBox>
                 <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataComboBoxColumn>
               
                <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Test Name"   VisibleIndex="8" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="TestID" TextField="TestName" DataSourceID="TestsListDS"></PropertiesComboBox>
                 <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataComboBoxColumn>
                                  <dx:GridViewDataTextColumn FieldName="StandardNumber" Caption="StandardNumber" VisibleIndex="9" Width="150" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn FieldName="LabName" Caption="LabSection" VisibleIndex="10" Width="100" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>
                  <dx:GridViewDataDateColumn FieldName="ReportingDate" Caption="Approved Date" VisibleIndex="11" Width="90" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy HH:mm" >
                     </PropertiesDateEdit>                    
                </dx:GridViewDataDateColumn>

               <%-- <dx:GridViewCommandColumn Caption="Print" VisibleIndex="8" ButtonType="Default" Width="80" CellStyle-HorizontalAlign="Center">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnPrint" Text=" " Image-ToolTip="Print" >
                         <Image Url="../images/print.png" Width="16" Height="16" ToolTip="Print" AlternateText="<%$ Resources:GlobalResource, BtnEdit %>"></Image>
                        </dx:GridViewCommandColumnCustomButton>

                        <dx:GridViewCommandColumnCustomButton ID="btnPrintWithDetails" Text=" " Image-ToolTip="Print" >
                         <Image Url="../images/print.png" Width="16" Height="16" ToolTip="Print With Details" AlternateText="<%$ Resources:GlobalResource, BtnEdit %>"></Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>--%>
                 <dx:GridViewDataColumn Caption="Print" VisibleIndex="12" Width="120"   CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <table style="width:50px">
                            <tr>
                                <td style="padding: 2px;">
                                                         <a target='blank'
onclick='<%# "return redirectToUrl(\"" + HttpUtility.UrlEncode(Eval("FileUrl").ToString()) + "\")" %>'  title="Print">
                                                                 <img src="../images/print.png" alt="Print" width="16" height="16" />

                                                         </a>
                                    
                              </td>
                                <td>
                            <dx:ASPxButton ID="btnPrintWithDetails" runat="server" Cursor="pointer" RenderMode="Link" EnableTheming="false"  AutoPostBack="false" 
                                EnableViewState="false"   CommandName="PrintWithDetails" ClientInstanceName ='<%#Eval("TestReportingID") %>'>
                                <Image Url="../images/PrintWithATT.jpg" Width="30" Height="30" ToolTip="Print With Details"></Image>
                                    <ClientSideEvents Click="function(s, e) { onBtnCheckClick(s, e); }" />

                            </dx:ASPxButton>
                     
                         </td>
                                <td>
                                     <dx:ASPxButton ID="btnRevise" runat="server"  Text="Revise" ButtonType="Button" EnableTheming="false"  AutoPostBack="false"
                            EnableViewState="false" CommandName="Revise" Enabled ='<%#Eval("Revised") %>' CommandArgument='<%#Eval("TestReportingID") %>'
                               ClientInstanceName ='<%#Eval("TestReportingID") %>'>
                                    <ClientSideEvents Init="btnReviewgridCompletedReport_Init" Click="function(s, e) { onBtnReviseCheckClick(s, e); }" />

                            </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                         
                        
                    </DataItemTemplate>
                 </dx:GridViewDataColumn>
            </Columns>
            <Settings ShowTitlePanel="true" ShowFilterRow="True" VerticalScrollBarMode="Visible" />
            <SettingsBehavior  AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <Styles StatusBar-CssClass="statusBar" />
            <Styles>
                <Header Wrap="True" BackColor="SteelBlue" ForeColor="White"></Header>
            </Styles>
        </dx:ASPxGridView>
    </div>
        </div>
     <asp:ObjectDataSource ID="AllPendingTestReportingDS" runat="server" OldValuesParameterFormatString="original_{0}"
          TypeName="BusinessLayer.Pages.TestReportingDB"
        DataObjectTypeName="BusinessLayer.TestReporting" SelectMethod="GetAllPending" UpdateMethod="UpdatePendingTestEndingDate"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="PendingToCheckTestReportingDS" runat="server" OldValuesParameterFormatString="original_{0}" 
        TypeName="BusinessLayer.Pages.TestReportingDB"
        DataObjectTypeName="BusinessLayer.TestReporting" SelectMethod="GetPendingToCheck"></asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="PendingToApproveTestReportingDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestReportingDB"
        DataObjectTypeName="BusinessLayer.TestReporting" SelectMethod="GetPendingToApprove"></asp:ObjectDataSource>

     <asp:ObjectDataSource ID="CompletedTestReportingDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestReportingDB"
        DataObjectTypeName="BusinessLayer.TestReporting" SelectMethod="GetAllCompleted"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="CustomersListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.CustomersListDB"
        DataObjectTypeName="BusinessLayer.CustomersList" SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ProjectsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="TestsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        DataObjectTypeName="BusinessLayer.TestsList" SelectMethod="GetAll"></asp:ObjectDataSource>
                
       <dx:ASPxLoadingPanel ID="PLMSAspxLoadingPanel" runat="server"   
                        ClientInstanceName="PLMSAspxLoadingPanel" 
                         Modal="True" Text="Please wait...">
          
                  
                    </dx:ASPxLoadingPanel>
    <dx:ASPxPopupControl ID="PLMSASPxPopupControl" ShowCloseButton="true"  ClientInstanceName="PLMSASPxPopupControl" runat="server"  AutoSize="False" Width="525" Height="580"  PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" HeaderText="Attachments" HeaderStyle-BackColor="SteelBlue"
                             HeaderStyle-ForeColor="White"   ShowHeader="true" ShowFooter="False" Modal="True">
    <ContentCollection>
        <dx:PopupControlContentControl>
            <ContentUrl>
                <Url>
                    <Parameter Name="Url" Type="String" Value="" />
                </Url>
            </ContentUrl>
        </dx:PopupControlContentControl>
    </ContentCollection>
            <ClientSideEvents CloseButtonClick="function(s, e) { handleCloseEvent(s, e); }" />
                     <CloseButtonImage Url="../images/cross_icon.png"></CloseButtonImage>

</dx:ASPxPopupControl>
   

</asp:Content>
