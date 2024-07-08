<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ReportGroupInfo.aspx.cs" Inherits="LaboratoryLayer.Pages.ReportGroupInfo" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .statusBar a:first-child {
            display: none;
        }

        .statusBar {
            display: none;
        }
    </style>
    <script>
        window.onbeforeunload = confirmExit;
        function confirmExit() {
            return "You are about to exit the system! , Are you sure you want to leave now?";
        }
        $(function () {
            $("a").click(function () {
                window.onbeforeunload = null;
            });
            $("input").click(function () {
                window.onbeforeunload = null;
            });
        });
    </script>
    <script type="text/javascript">

        function ShowAttachmentWindow(link, caller) {
            PLMSASPxPopupControl.title = caller;
            PLMSASPxPopupControl.SetContentUrl(link);
            PLMSASPxPopupControl.Show();

        }


        function Uploader_OnFileUploadComplete(args) {
            if (args.isValid) {
                txtWorkform.SetText(args.callbackData);
                cmbWorkform.PerformCallback();
            }
        }
        function Uploader_OnFilesUploadComplete(args) {
            UpdateUploadButton();
        }
        function UpdateUploadButton() {
            uploader_Workbookfile.Upload();
        }
        function UploadButton_Click(s, e) {
            document.getElementById("body_flReportGroupList_uplWorkbookfile_TextBox0_Input").click();
        }

        function Uploader_Report_OnFilesUploadComplete(args) {
            UploadReportInstant();
        }

        function UploadReportInstant() {
            uploader_Report.Upload();
        }

        function Uploader_Report_OnFileUploadComplete(args) {
            if (args.isValid) {
                txtReport.SetText(args.callbackData);
                cmbReport.PerformCallback();
            }
        }

        function UploadReportButton_Click(s, e) {
            document.getElementById("body_flReportGroupList_uplReportfile_TextBox0_Input").click();
        }

        function PrintElem(elem) {
            Popup($(elem).html());
        }

        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=400,width=600');
            mywindow.document.write('<html><head><title>my div</title>');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');

            mywindow.document.close(); // necessary for IE >= 10
            mywindow.focus(); // necessary for IE >= 10

            mywindow.print();
            mywindow.close();

            return true;
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
            <li class="active" id="menulink">Report Group Information</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Report Group Information</h1>
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
            <dx:ASPxButton ID="BtnSave" runat="server" EnableTheming="false" Text="Save" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk" ValidationGroup="OnSave" OnClick="BtnSave_Click">
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">

            <dx:ASPxButton ID="btnUpload" ClientInstanceName="btnUpload"  CssClass="btn btn-round btn-primary glyphicon glyphicon-upload" 
                 Style="width: 80px" AutoPostBack="false" runat="server" Text="Upload">
               
            </dx:ASPxButton>

        </div>

        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnBack" runat="server" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Style="width: 80px" Text="Back" OnClick="BtnBack_Click">
            </dx:ASPxButton>
        </div>
    </div>

    <div class="row" style="height: 20px"></div>
    <div class="btn-toolbar">
        <div class="hidden" id="divmsg" runat="server" style="width: 750px;">
            <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
            <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
        </div>
        <div id="divError" class="hidden" style="width: 750px;">
            <button type="button" class="close" data-hide="alert" onclick="$('#divError').hide()">&times;</button>
        </div>
    </div>

    <div class="btn-toolbar">
        <dx:ASPxLabel ID="lblMasterId" runat="server" Text="0" ClientVisible="false" ClientInstanceName="lblMasterId"></dx:ASPxLabel>
    </div>

    <div>
        <dx:ASPxFormLayout ID="flReportGroupList" runat="server" DataSourceID="ReportGroupDS" ClientInstanceName="flReportGroupList">
            <Items>
                <dx:LayoutGroup Caption="Report Group Information" ColCount="6">
                    <Items>
                        <dx:LayoutItem Caption="Group ID" FieldName="GroupID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtGroupID" runat="server" ReadOnly="true"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Group Number" FieldName="GroupNumber" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtGroupNumber" runat="server" ReadOnly="true">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Service Section" FieldName="FKMaterialTypeID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKMaterialTypeID" runat="server" ValueField="MaterialTypeID" TextField="MaterialName" AutoPostBack="true"
                                        DataSourceID="MaterialsTypesDS">
                                        <ValidationSettings ValidationGroup="OnSave" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Service Section is missing!"></ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Group Name" FieldName="GroupName" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtGroupName" runat="server">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Group Description" FieldName="GroupDescription" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtGroupDescription" runat="server" Width="755"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        </Items>
                </dx:LayoutGroup>

                <dx:LayoutGroup Caption="Report Group Excel Files" ColCount="6">
                    <Items>
                        <dx:LayoutItem Caption="Workform Workbook file" FieldName="WorkFormFileName" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtWorkform" runat="server" Width="250" ClientInstanceName="txtWorkform" NullText="Click to select Workform file">
                                    </dx:ASPxTextBox>
                                    <dx:ASPxUploadControl ID="uplWorkbookfile" runat="server" ClientInstanceName="uploader_Workbookfile" ShowProgressPanel="false"
                                        NullText="Click here to browse files..." Size="12" OnFileUploadComplete="uplWorkbookfile_FileUploadComplete" ClientVisible="false">

                                        <ClientSideEvents FileUploadComplete="function(s, e) { Uploader_OnFileUploadComplete(e); }"
                                            FilesUploadComplete="function(s, e) { Uploader_OnFilesUploadComplete(e); }"
                                            TextChanged="function(s, e) { UpdateUploadButton(); }"></ClientSideEvents>
                                        <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".xls,.xlsx,.xlsm">
                                        </ValidationSettings>
                                    </dx:ASPxUploadControl>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Workform Worksheet" FieldName="WorkFormWorksheet" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbWorkform" ClientInstanceName="cmbWorkform" runat="server" DataSourceID="WorkformWorksheetListDS"
                                        ValueType="System.String" OnCallback="cmbWorkform_Callback">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" FieldName="FKGroupID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxButton ID="btnWorkform" runat="server" Text="Received Information Link" AutoPostBack="false">
                                        <ClientSideEvents Click="function(s, e) {isreport.SetText('False');gridColumnMapping.Refresh();vi.SetValue(e.visibleIndex);gridColumnMapping.CancelEdit();popupOpt.Show();}" />
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Report Workbook file" FieldName="ReportFileName" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtReport" runat="server" Width="250" ClientInstanceName="txtReport" NullText="Click to select Report file"></dx:ASPxTextBox>
                                    <dx:ASPxUploadControl ID="uplReportfile" runat="server" ClientInstanceName="uploader_Report" ShowProgressPanel="false"
                                        NullText="Click here to browse files..." Size="12" OnFileUploadComplete="uplReportfile_FileUploadComplete" ClientVisible="false">
                                        <ClientSideEvents FileUploadComplete="function(s, e) { Uploader_Report_OnFileUploadComplete(e); }"
                                            FilesUploadComplete="function(s, e) { Uploader_Report_OnFilesUploadComplete(e); }"
                                            TextChanged="function(s, e) { UploadReportInstant(); }"></ClientSideEvents>
                                        <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".xls,.xlsx,.xlsm">
                                        </ValidationSettings>
                                    </dx:ASPxUploadControl>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Report Worksheet" FieldName="ReportWorksheet" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbReport" runat="server" ClientInstanceName="cmbReport" DataSourceID="ReportWorksheetListDS"
                                        ValueType="System.String" OnCallback="cmbReport_Callback">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxButton ID="btnReport" runat="server" Text="Received Information Link" AutoPostBack="false">
                                        <ClientSideEvents Click="function(s, e) {isreport.SetText('True');gridColumnMapping.Refresh();vi.SetValue(e.visibleIndex);gridColumnMapping.CancelEdit();popupOpt.Show();}" />
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
    </div>
    <div>
        <dx:ASPxPopupControl ID="popupMapping" runat="server" HeaderText="Column Mapping" ShowHeader="true" ShowPageScrollbarWhenModal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
            CloseAction="CloseButton" AllowDragging="True" ClientInstanceName="popupOpt" LoadContentViaCallback="OnPageLoad" Width="500" Height="200" PopupAlignCorrection="Disabled"
            ShowCloseButton="true" PopupAnimationType="Slide">
            <ClientSideEvents PopUp="function(s,e){gridColumnMapping.UpdateEdit();}" />
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                    <div>
                        <div class="divrow">
                            <dx:ASPxValidationSummary ID="ASPxValidationSummary2" runat="server" ValidationGroup="options"></dx:ASPxValidationSummary>
                            <dx:ASPxTextBox ID="vi" runat="server" ClientInstanceName="vi" ClientVisible="false" Text=""></dx:ASPxTextBox>
                            <dx:ASPxTextBox ID="sid" runat="server" ClientInstanceName="sid" ClientVisible="false" Text="0"></dx:ASPxTextBox>
                            <dx:ASPxTextBox ID="isreport" runat="server" ClientInstanceName="isreport" ClientVisible="false" Text="False"></dx:ASPxTextBox>
                        </div>
                        <div class="divrow">
                            <div class="divcell">
                                <dx:ASPxGridView runat="server" ID="gdvColumnMapping" AutoGenerateColumns="false" ClientInstanceName="gridColumnMapping" Width="500"
                                    DataSourceID="ColumnMappingDS" KeyFieldName="ExcelMappingFieldId" OnBatchUpdate="gdvColumnMapping_BatchUpdate" OnRowUpdating="gdvColumnMapping_RowUpdating" OnCustomErrorText="gdvColumnMapping_CustomErrorText">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="FieldName" Caption="Field Name" VisibleIndex="1">
                                            <EditFormSettings Visible="False" />
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ExcelCell" Caption="ExcelCell" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsEditing Mode="Batch" BatchEditSettings-EditMode="Cell" BatchEditSettings-ShowConfirmOnLosingChanges="true" />
                                    <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
                                    <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                    <Settings VerticalScrollableHeight="200" ColumnMinWidth="500" VerticalScrollBarMode="Auto" />
                                    <Styles StatusBar-CssClass="statusBar" />
                                    <Styles>
                                        <Header BackColor="SteelBlue" ForeColor="White"></Header>
                                    </Styles>
                                </dx:ASPxGridView>
                            </div>
                        </div>
                        <div class="divrow" style="height: 10px"></div>
                        <div class="divrow" style="text-align: center">
                            <div class="inline" style="width: 100px">
                                <dx:ASPxButton ID="btnOk" runat="server" Text="Save" CssClass="btn btn-mini btn-sm btn-round btn-primary" ValidationGroup="options" ClientInstanceName="btnOk"
                                    ToolTip="OK" AutoPostBack="false" Cursor="pointer" EnableTheming="false" Width="80px">
                                    <ClientSideEvents Click="function(s,e) {gridColumnMapping.UpdateEdit();}" />
                                </dx:ASPxButton>
                            </div>
                            <div class="inline">
                                <dx:ASPxButton ID="btnPopCancel" runat="server" Text="Cancel" CssClass="btn btn-mini btn-sm btn-round btn-default"
                                    ToolTip="Cancel" AutoPostBack="false" Cursor="pointer" EnableTheming="false" Width="80px">
                                    <ClientSideEvents Click="function(s, e) { popupOpt.Hide(); }" />
                                </dx:ASPxButton>
                            </div>
                        </div>
                        <div class="divrow" style="height: 25px;">&nbsp</div>
                        <div class="divrow">
                            <dx:ASPxLabel ID="lblMappingError" runat="server" Text="" ForeColor="Red"></dx:ASPxLabel>
                        </div>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </div>
    
    <asp:ObjectDataSource ID="MaterialsTypesDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsTypesDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsTypes">
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ReportGroupDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ReportGroupDB"
        SelectMethod="GetByID" InsertMethod="Insert" UpdateMethod="Update"
        OnInserting="ReportGroupDS_Inserting" OnInserted="ReportGroupDS_Inserted"
        OnUpdating="ReportGroupDS_Updating" OnUpdated="ReportGroupDS_Updated">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="WorkformWorksheetListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ReportGroupDB"
        SelectMethod="GetWorkformWorksheetList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ReportWorksheetListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ReportGroupDB"
        SelectMethod="GetReportWorksheetList">
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ColumnMappingDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ReportGroupExcelMappingDB"
        SelectMethod="GetMappingListByMasterIDWithSession" UpdateMethod="UpdateMapping" DataObjectTypeName="BusinessLayer.ViewReportGroupExcelCellFieldMapping">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
            <asp:ControlParameter ControlID="ctl00$body$popupMapping$isreport" PropertyName="Text" DefaultValue="False" Name="IsReport" Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>

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
                     <CloseButtonImage Url="../images/cross_icon.png"></CloseButtonImage>

</dx:ASPxPopupControl>
    <dx:ASPxUploadControl ID="UploadControl" AutoStartUpload="true" ClientVisible="false" DialogTriggerID="ctl00_body_btnUpload;btnUpload;body_btnUpload" runat="server" ClientInstanceName="UploadControl" Width="320" style="display:none;"
                         UploadMode="Auto" ShowUploadButton="false" ShowProgressPanel="false" ShowTextBox="false"
                        OnFileUploadComplete="UploadControl_FileUploadComplete" FileUploadMode="OnPageLoad" ShowFileList="false">
                        <AdvancedModeSettings EnableMultiSelect="false" EnableFileList="false" EnableDragAndDrop="false">
                        </AdvancedModeSettings>
                        <%--<ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".jpg,.jpeg,.gif,.png">
                                    </ValidationSettings>--%>
                        <ValidationSettings
                            AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp, .jpe, .jpeg, .jpg, .gif, .png"
                            MaxFileSize="10485760">
                        </ValidationSettings>
                        <ClientSideEvents  Init="function(s, e) {
                            debugger;
                                                   s.SetDialogTriggerID('ctl00_body_btnUpload;btnUpload;body_btnUpload');
                                               }" FileUploadStart="function(s, e) {  PLMSAspxLoadingPanel.Show();}"
                             FileUploadComplete="function(s, e) { PLMSAspxLoadingPanel.Hide(); alert('File Uploaded Successfully!!');}" />
                    </dx:ASPxUploadControl>
</asp:Content>