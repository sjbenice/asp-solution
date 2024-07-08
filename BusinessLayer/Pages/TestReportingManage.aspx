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
        <h5>Pending To Report</h5>
        <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError" ForeColor="Red"></dx:ASPxLabel>
    </div>
    <script type="text/javascript">
        function onpendingrowclick(s, e) {
            gridPendingToReport.StartEditRow(e.visibleIndex);
        }
        function ontestendingdatechange(s, e) {
            gridPendingToReport.UpdateEdit();
        }

        function GdvPendingToReportOnRowClick(s, e) {
            debugger;
            var clickedElement = e.htmlEvent.target;

            if (clickedElement.title === "Send For Check") 
            {
               PLMSAspxLoadingPanel.Show();
            }
        }
        function GdvPendingToReportEndCallback(s, e) {

            PLMSAspxLoadingPanel.Hide();

        }

        function handleCloseEvent(s, e) {
            eval(s.title).Refresh();
        }
        function ShowAttachmentWindow(link, caller) {
            PLMSASPxPopupControl.title = caller;
            PLMSASPxPopupControl.SetContentUrl(link);
            PLMSASPxPopupControl.Show();

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
       
      
    </script>
                       <div class="row" style="height: 10px"></div>

    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingToReport" AutoGenerateColumns="False" Width="100%" ClientInstanceName="gridPendingToReport"            
            DataSourceID="AllPendingTestReportingDS" KeyFieldName="TestReportingID" OnCellEditorInitialize="GdvPendingToReport_CellEditorInitialize"
            OnCustomCallback="GdvPendingToReport_CustomCallback"
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
onclick='<%# "ShowAttachmentWindow(\"../Pages/Attachments.aspx?TransTypeID=111222&TransID=" + Eval("TestReportingID") +"\", \"gridPendingToReport\")" %>'
                                    title="Attachments"><span runat="server" class="badge" id="attchCount">0</span></a>
                            </DataItemTemplate>
                        </dx:GridViewDataHyperLinkColumn>
                <dx:GridViewDataTextColumn FieldName="ReportNumber" Caption="Report Number" VisibleIndex="1" Width="100" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                    <DataItemTemplate>
                        <a target='_blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" href="<%# Eval("FileUrl") %>" title="Excel File"><%# Eval("ReportNumber") %></a>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>   
                 <dx:GridViewDataTextColumn  Caption="Worksheet" VisibleIndex="1" Width="110" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                    <DataItemTemplate>
 <a 
                   onclick='<%# "return ChangeLink(\"" + HttpUtility.UrlEncode(Eval("FileUrl").ToString()) + "\", \"" + Eval("ReportNumber") + "\")" %>'>
                   WS-<%# Eval("ReportNumber") %>
                </a>
                       
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>           
                <dx:GridViewDataTextColumn FieldName="SampleNumber" Caption="Sample Number" VisibleIndex="2" Width="100" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>

                 <dx:GridViewDataDateColumn FieldName="SampleReceivedDate" Caption="Date of Received" VisibleIndex="3" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
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
               
                <dx:GridViewDataComboBoxColumn FieldName="FKTestID" Caption="Test Name" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="TestID" TextField="TestName" DataSourceID="TestsListDS"></PropertiesComboBox>
                 <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataDateColumn FieldName="TestEndingDate" Caption="Test Ending Date" 
                    PropertiesDateEdit-ClientSideEvents-ValueChanged="ontestendingdatechange" VisibleIndex="7" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>                    
                </dx:GridViewDataDateColumn>
                 <%--    <dx:GridViewDataTextColumn Caption="ScannedLabWS" VisibleIndex="8" Width="250" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                               <DataItemTemplate>
                         <span runat="server"  id="ScannedLabWS">0</span>
                                   </DataItemTemplate>
                </dx:GridViewDataTextColumn>--%>
              
                
                 <dx:GridViewDataTextColumn VisibleIndex="9" Width="100" Caption="Send For Check" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <table>
                            <tr>
                                <td>       <dx:ASPxButton ID="BtnSendForCheck"  OnInit="BtnSendForCheck_Init"
                                    HorizontalAlign="Center" runat="server" Cursor="pointer" RenderMode="Link" ToolTip="Send For Check" 
                            EnableTheming="false" EnableViewState="false" CommandName="sendforcheck" Text="" CommandArgument=<%#Eval("TestReportingID") %>>
                           <Image ToolTip="Send For Check" Url="../images/share_button_final_179539-2.png" Width="18" Height="18"></Image>
                        </dx:ASPxButton></td>

                            </tr>
                        </table>
                 
         
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>

            </Columns>
            
            <%--<SettingsEditing Mode="Inline" />--%>       
            <Settings ShowTitlePanel="true" ShowFilterRow="True" VerticalScrollBarMode="Visible" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
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
        <h5>Pending To Check</h5>
    </div>
     <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingToCheckReport" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPendingToCheckReport"
            DataSourceID="PendingToCheckTestReportingDS"
                          OnHtmlRowCreated="GdvPendingToReport_HtmlRowCreated"

            KeyFieldName="TestReportingID" OnCustomCallback="GdvPendingToCheckReport_CustomCallback" OnRowCommand="GdvPendingToCheckReport_RowCommand">
                        <ClientSideEvents RowClick="GdvPendingToReportOnRowClick" EndCallback="GdvPendingToReportEndCallback" />

            <Columns>   
                     <dx:GridViewDataHyperLinkColumn Name="Attachment" Width="40" VisibleIndex="0">
                            <HeaderCaptionTemplate>
                                <center><span class="glyphicon glyphicon-paperclip"></span></center>
                            </HeaderCaptionTemplate>
                            <DataItemTemplate>
                                <a target='blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" 
onclick='<%# "ShowAttachmentWindow(\"../Pages/Attachments.aspx?TransTypeID=111222&TransID=" + Eval("TestReportingID") +"\", \"gridPendingToCheckReport\")" %>'
                                    title="Attachments"><span runat="server" class="badge" id="attchCount">0</span></a>
                            </DataItemTemplate>
                        </dx:GridViewDataHyperLinkColumn>
                <dx:GridViewDataTextColumn FieldName="SampleNumber" Caption="Sample Number" VisibleIndex="2" Width="100" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>

                 <dx:GridViewDataDateColumn FieldName="SampleReceivedDate" Caption="Date of Received" VisibleIndex="3" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>

                <dx:GridViewDataTextColumn FieldName="ReportNumber" Caption="Report Number" VisibleIndex="1" Width="100" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                    <DataItemTemplate>
                        <a target='_blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px"
                            href="<%# Eval("FileUrl") %>" title="PDF File"><%# Eval("ReportNumber") %></a>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
               
               <dx:GridViewDataComboBoxColumn FieldName="FKCustomerID" Caption="Customer Name" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
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

                <dx:GridViewDataDateColumn FieldName="EnteredDate" Caption="Entered Date" VisibleIndex="7" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>                    
                </dx:GridViewDataDateColumn>

                <dx:GridViewDataTextColumn VisibleIndex="8" Caption="Check" Width="100" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <dx:ASPxButton ID="btnCheck" HorizontalAlign="Center" runat="server" Cursor="pointer" RenderMode="Link" ToolTip="Send For Check" EnableTheming="false" EnableViewState="false" CommandName="check" Text="" CommandArgument=<%#Eval("TestReportingID") %>>
                           <Image ToolTip="Check" Url="../images/select.png" Width="22" Height="22"></Image>
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnRejectCheck" HorizontalAlign="Center" runat="server" Cursor="pointer" RenderMode="Link" ToolTip="Send For Check" EnableTheming="false" EnableViewState="false" CommandName="reject" Text="" CommandArgument=<%#Eval("TestReportingID") %>>
                           <Image ToolTip="Reject" Url="../images/grd_Delete.png" Width="22" Height="22"></Image>
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
                <Header BackColor="SteelBlue" ForeColor="White"></Header>
            </Styles>
        </dx:ASPxGridView>
    </div>
        </div>


     <div  id="PendingToApprove" runat="server">
    <div>
        <h5>Pending To Approve</h5>
    </div>
     <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvPendingToApproveReport" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridPendingToApproveReport"
            DataSourceID="PendingToApproveTestReportingDS" 
                          OnHtmlRowCreated="GdvPendingToReport_HtmlRowCreated"

            KeyFieldName="TestReportingID" OnCustomCallback="GdvPendingToApproveReport_CustomCallback" OnRowCommand="GdvPendingToApproveReport_RowCommand">
                        <ClientSideEvents RowClick="GdvPendingToReportOnRowClick" EndCallback="GdvPendingToReportEndCallback" />

             <%--<ClientSideEvents CustomButtonClick="function(s,e){var key = s.GetRowKey(e.visibleIndex);  if (e.buttonID == 'btnApprove') {window.location=('TestReportingManage.aspx?id=' + key + '&statusId=3');} else if (e.buttonID == 'btnRejectApprove') {window.location=('TestReportingManage.aspx?id=' + key + '&statusId=0');}}" />--%>
            <Columns> 
                     <dx:GridViewDataHyperLinkColumn Name="Attachment" Width="40" VisibleIndex="0">
                            <HeaderCaptionTemplate>
                                <center><span class="glyphicon glyphicon-paperclip"></span></center>
                            </HeaderCaptionTemplate>
                            <DataItemTemplate>
                                <a target='blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" 
onclick='<%# "ShowAttachmentWindow(\"../Pages/Attachments.aspx?TransTypeID=111222&TransID=" + Eval("TestReportingID") +"\", \"gridPendingToApproveReport\")" %>'
                                    title="Attachments"><span runat="server" class="badge" id="attchCount">0</span></a>
                            </DataItemTemplate>
                        </dx:GridViewDataHyperLinkColumn>
                <dx:GridViewDataTextColumn FieldName="SampleNumber"
                    Caption="Sample Number" VisibleIndex="2" Width="100" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>

                 <dx:GridViewDataDateColumn FieldName="SampleReceivedDate" Caption="Date of Received" VisibleIndex="3" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>

                <dx:GridViewDataTextColumn FieldName="ReportNumber" Caption="Report Number"  VisibleIndex="1" Width="100" CellStyle-HorizontalAlign="Left">
                <Settings AutoFilterCondition="Contains"/> 
                       <DataItemTemplate>
                        <a target='_blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" href="<%# Eval("FileUrl") %>" title="PDF File"><%# Eval("ReportNumber") %></a>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
               
               <dx:GridViewDataComboBoxColumn FieldName="FKCustomerID" Caption="Customer Name" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
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

                  <dx:GridViewDataDateColumn FieldName="CheckedDate" Caption="Check Date" VisibleIndex="7" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>                    
                </dx:GridViewDataDateColumn>

                <dx:GridViewDataTextColumn VisibleIndex="8" Caption="Approve" Width="100" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <dx:ASPxButton ID="btnApprove" HorizontalAlign="Center" runat="server" Cursor="pointer" RenderMode="Link" ToolTip="Send For Check" EnableTheming="false" EnableViewState="false" CommandName="approve" Text="" CommandArgument=<%#Eval("TestReportingID") %>>
                           <Image ToolTip="Approve" Url="../images/select.png" Width="22" Height="22"></Image>
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnRejectApprove" HorizontalAlign="Center" runat="server" Cursor="pointer" RenderMode="Link" ToolTip="Send For Check" EnableTheming="false" EnableViewState="false" CommandName="reject" Text="" CommandArgument=<%#Eval("TestReportingID") %>>
                           <Image ToolTip="Reject" Url="../images/grd_Delete.png" Width="22" Height="22"></Image>
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
                <Header BackColor="SteelBlue" ForeColor="White"></Header>
            </Styles>
        </dx:ASPxGridView>
    </div>
</div>


    <div  id="CompleteReport" runat="server">
    <div>
        <h5>Completed Report</h5>
    </div>
     <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvCompletedReport" AutoGenerateColumns="false" Width="100%" ClientInstanceName="gridCompletedReport"
            DataSourceID="CompletedTestReportingDS"
                          OnHtmlRowCreated="GdvPendingToReport_HtmlRowCreated"

            KeyFieldName="TestReportingID" OnCustomCallback="GdvCompletedReport_CustomCallback" OnRowCommand="GdvCompletedReport_RowCommand">

            <Columns>
                     <dx:GridViewDataHyperLinkColumn Name="Attachment" Width="40" VisibleIndex="0">
                            <HeaderCaptionTemplate>
                                <center><span class="glyphicon glyphicon-paperclip"></span></center>
                            </HeaderCaptionTemplate>
                            <DataItemTemplate>
                                <a target='blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" 
onclick='<%# "ShowAttachmentWindow(\"../Pages/Attachments.aspx?TransTypeID=111222&TransID=" + Eval("TestReportingID") +"\", \"gridCompletedReport\")" %>'
                                    title="Attachments"><span runat="server" class="badge" id="attchCount">0</span></a>
                            </DataItemTemplate>
                        </dx:GridViewDataHyperLinkColumn>
                <dx:GridViewDataTextColumn FieldName="FKSampleReceiveTestID" Caption="SampleReceiveTestID" VisibleIndex="0" Visible="False">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="SampleNumber" Caption="Sample Number" VisibleIndex="2" Width="100" CellStyle-HorizontalAlign="Left">
                    <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataTextColumn>

                 <dx:GridViewDataDateColumn FieldName="SampleReceivedDate" Caption="Date of Received" VisibleIndex="3" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
                     </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>

                <dx:GridViewDataHyperLinkColumn FieldName="ReportNumber" Caption="Report Number" VisibleIndex="1" Width="100" CellStyle-HorizontalAlign="Left">
                    <Settings AutoFilterCondition="Contains"/>  
                      <DataItemTemplate>
                        <a target='_blank' style="display: block; padding-left: 2px; text-wrap: avoid; width: 30px" href="<%# Eval("FileUrl") %>" title="PDF File"><%# Eval("ReportNumber") %></a>
                    </DataItemTemplate>
                </dx:GridViewDataHyperLinkColumn>
               
                 <dx:GridViewDataDateColumn FieldName="RevisionNo" Caption="Revision No" VisibleIndex="4" Width="150" CellStyle-HorizontalAlign="Left">
                    <Settings AutoFilterCondition="Contains"/> 
                </dx:GridViewDataDateColumn>

                <%-- <dx:GridViewCommandColumn Caption="Revise Report" VisibleIndex="5" ButtonType="Button" Width="120" CellStyle-HorizontalAlign="Center">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnRevise" Text="Revise" Image-ToolTip="Revise" Styles-Style-CssClass="btn-default">
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>--%>
                <dx:GridViewDataColumn Caption="Revise" Width="100" VisibleIndex="5" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <dx:ASPxButton ID="btnRevise" runat="server" Text="Revise" ButtonType="Button" EnableTheming="false" EnableViewState="false" CommandName="Revise" Enabled ='<%#Eval("Revised") %>' CommandArgument='<%#Eval("TestReportingID") %>'>
                        </dx:ASPxButton>
                    </DataItemTemplate>
                 </dx:GridViewDataColumn>

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

                  <dx:GridViewDataDateColumn FieldName="ReportingDate" Caption="Approved Date" VisibleIndex="8" Width="150" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" >
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
                 <dx:GridViewDataColumn Caption="Print" VisibleIndex="9" Width="120" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <table style="width:inherit">
                            <tr>
                                <td style="padding: 10px;"><asp:UpdatePanel ID="UpdatePanel5" runat="server">
                              <ContentTemplate>
                                <dx:ASPxButton ID="btnPrint" runat="server" Cursor="pointer" RenderMode="Link" EnableTheming="false" 
                                     EnableViewState="false" CommandName="Print" CommandArgument='<%#Eval("TestReportingID") %>'>
                                    <Image Url="../images/print.png" Width="16" Height="16" ToolTip="Print"></Image>
                                </dx:ASPxButton>
                               </ContentTemplate>
                              <Triggers>
                                <asp:postbacktrigger controlid="btnPrint" />
                              </Triggers>
                        </asp:UpdatePanel></td>
                                <td><asp:UpdatePanel ID="UpdatePanel1" runat="server">
                          <ContentTemplate>
                            <dx:ASPxButton ID="btnPrintWithDetails" runat="server" Cursor="pointer" RenderMode="Link" EnableTheming="false"  
                                EnableViewState="false" CommandName="PrintWithDetails" CommandArgument='<%#Eval("TestReportingID") %>'>
                                <Image Url="../images/attach.png" Width="16" Height="16" ToolTip="Print With Details"></Image>
                            </dx:ASPxButton>
                          </ContentTemplate>
                          <Triggers>
                            <asp:postbacktrigger controlid="btnPrintWithDetails" />
                          </Triggers>
                        </asp:UpdatePanel></td>
                            </tr>
                        </table>
                         
                        
                    </DataItemTemplate>
                 </dx:GridViewDataColumn>
            </Columns>
            <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <Styles StatusBar-CssClass="statusBar" />
            <Styles>
                <Header BackColor="SteelBlue" ForeColor="White"></Header>
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
        PopupVerticalAlign="WindowCenter" HeaderText=""    ShowHeader="true" ShowFooter="False" Modal="True">
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

</dx:ASPxPopupControl>
   

</asp:Content>
