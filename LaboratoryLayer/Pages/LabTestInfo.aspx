﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="LabTestInfo.aspx.cs" Inherits="LaboratoryLayer.Pages.LabTestInfo" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script>
            var FilesGridEdited = false;

            function onFileUploadComplete(s, e) {
                if (e.callbackData) {
                    gdvfiles.PerformCallback();
                }
            }

            function onSessionFileUploadComplete(s, e) {
                if (e.callbackData) {
                    gdvSessionFiles.PerformCallback();
                }
            }
        </script>

    <%--<style type="text/css">
        table.dxeTextBoxSys, table.dxeMemoSys, table.dxeButtonEditSys,table.dxeEditAreaSys, table.dxeButtonEdit,
         td.dxeButtonEditButton,table.dxeListBox_MetropolisBlue{
            border-radius: 5px;
            -moz-border-radius: 5px;
            -khtml-border-radius: 5px;
            -webkit-border-radius: 5px;
        }
    </style>--%>
    <style>
        .statusBar a:first-child {
            display: none;
        }

        .statusBar {
            display: none;
        }
    </style>
    <script type="text/javascript">

        function grid_SelectionChanged(s, e) {
            if (e.isChangedOnServer == true)
                return;

            var params = [e.visibleIndex, e.isSelected];
            gdvSampleTestList.PerformCallback(params);
        }

    </script>
        <script>

            $(function () {
                $("a").click(function () {
                    window.onbeforeunload = null;
                });
                $("input").click(function () {
                    window.onbeforeunload = null;
                });
            });
        </script>
   
    <script>

        function ImageUploader_OnUploadStart() {

            btnUpload.SetEnabled(false);
        }
        function ImageUploader_OnFilesUploadComplete(args) {
            ImageUpdateUploadButton();
        }
        function ImageUpdateUploadButton() {
            btnUpload.SetEnabled(uploader.GetText(0) != "");
        }


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

        function hdnWorkbookFill(field) {
            var txtWorkbook = hdnWorkbook.Get("Text");
            if (!txtWorkbook || txtWorkbook.trim() === '') {
                return;
            }

            field.href = hdnWorkbook.Get("NavigateUrl");
            return true;
        }

        function hdnReportFill(field) {
            var txtReport = hdnReport.Get("Text");
            if (!txtReport || txtReport.trim() === '') {
                return;
            }

            field.href = hdnReport.Get("NavigateUrl");
            return true;
        }

        // Call the function after the document is loaded
        document.addEventListener("DOMContentLoaded", function (event) {
            // Timeout to ensure the ASPxHyperLink is loaded
            //setTimeout(afterHyperLinkCreation, 100);
        });

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
            //btnUpload.SetEnabled(uploader.GetText(0) != "");
            uploader_Workbookfile.Upload(); //Uploads automatically
        }
        function UploadButton_Click(s, e) {
            //file.GetFileSelectorElement(0).click(); //uploader.GetFileInputElement(0).click(); ctl00$body$flTestExcelFiles$uplWorkbookfile
            document.getElementById("body_flTestsList_uplWorkbookfile_TextBox0_Input").click();
        }


        function Uploader_Report_OnFilesUploadComplete(args) {
            UploadReportInstant();
        }
        function UploadReportInstant() {
            uploader_Report.Upload(); //Uploads automatically
        }
        function Uploader_Report_OnFileUploadComplete(args) {
            if (args.isValid) {
                txtReport.SetText(args.callbackData);
                cmbReport.PerformCallback();
            }
        }
        function UploadReportButton_Click(s, e) {
            //file.GetFileSelectorElement(0).click(); //uploader.GetFileInputElement(0).click(); ctl00$body$flTestExcelFiles$uplWorkbookfile
            document.getElementById("body_flTestsList_uplReportfile_TextBox0_Input").click();
        }
        function PrintElem(elem) {
            Popup($(elem).html());
        }
        function AttachementElem(elem) {
            Popup($(elem).html());
        }
        function Popup(data) {
            var mywindow = window.open('', 'my div', 'height=400,width=600');
            mywindow.document.write('<html><head><title>my div</title>');
            /*optional stylesheet*/ //mywindow.document.write('<link rel="stylesheet" href="main.css" type="text/css" />');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');

            mywindow.document.close(); // necessary for IE >= 10
            mywindow.focus(); // necessary for IE >= 10

            mywindow.print();
            mywindow.close();

            return true;
        }
        function PopupAttachement(data) {
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
            <li class="active" id="menulink">Service Information</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Service Information</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div>
            <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

            <dx:ASPxLabel ID="txtTotalTestPrices" runat="server" ClientInstanceName="txtTotalTestPrices" Text="0" ForeColor="White" ClientVisible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblTransID" runat="server" Text="0" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblTransTypeID" runat="server" Text="0" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblUploadDirectory" runat="server" Text="~/Uploaded/Attachments" Visible="false"></dx:ASPxLabel>

        </div>
        <div class="btn-group" role="group" aria-label="First group">

            <dx:ASPxButton ID="BtnSave" runat="server" EnableTheming="false" Text="Save" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk" ValidationGroup="OnSave" OnClick="BtnSave_Click">
                <%--<ClientSideEvents Click="function(s,e){if (!ASPxClientEdit.ValidateGroup('OnSave')) {document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();} else document.getElementById('divError').className = 'hidden';}" />--%>
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnBack" runat="server" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Style="width: 80px" Text="Back" OnClick="BtnBack_Click">
            </dx:ASPxButton>

        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnPrint" runat="server" AutoPostBack="false" ToolTip="Print" Text="Print" CssClass="btn btn-round btn-info glyphicon glyphicon-print">
                <ClientSideEvents Click="function(s, e) {var key = lblMasterId.GetText(); window.open('ReportViwer.aspx?source=ServiceInformation&id=' + key);}" />
                <%--"function(s,e){PrintElem('#divprint');}"--%>
            </dx:ASPxButton>

        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnAttachment" runat="server" AutoPostBack="false" ToolTip="Attachment" Text="Attachment" CssClass="btn btn-round btn-info glyphicon glyphicon-paperclip">
                <ClientSideEvents Click="function(s, e) {popupAttachment.Show(); }" />
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
            <%--<dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" RenderMode="Table"  ValidationGroup="OnSave"></dx:ASPxValidationSummary>--%>
        </div>
    </div>

    <div class="btn-toolbar">
        <dx:ASPxLabel ID="lblMasterId" runat="server" Text="0" ClientVisible="false" ClientInstanceName="lblMasterId"></dx:ASPxLabel>
    </div>
    <div>
        <dx:ASPxFormLayout ID="flTestsList" runat="server" DataSourceID="TestsListDS" ClientInstanceName="flTestsList">
            <Items>
                <dx:LayoutGroup Caption="Service Mode" ColCount="8">
                    <Items>
                        <dx:LayoutItem Caption="" FieldName="IsUnavailable" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="IsUnavailableTest" runat="server" Text="Test not available" ClientInstanceName="IsUnavailable">
                                        <ClientSideEvents CheckedChanged="function(s,e){IsSubcontractedTest.SetChecked(s.GetChecked());IsSubcontractedTest.SetEnabled(!(s.GetChecked())); }" />
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" FieldName="IsSubcontractedTest" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="IsSubcontractedTest" runat="server" Text="Service to be subcontracted" ClientInstanceName="IsSubcontractedTest"></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" FieldName="IsReporting" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="IsReporting" runat="server" Text="Reporting" ClientInstanceName="IsReporting"></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" FieldName="IsSiteTest" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="IsSiteTest" runat="server" Text="Site Test"></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" FieldName="IsLocked" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="IsClosed" runat="server" Text="Inactive"></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Service Information" ColCount="6">
                    <Items>
                        <dx:LayoutItem Caption="Service Number" FieldName="TestID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtTestID" runat="server" ReadOnly="true"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Ashghal Test Number" FieldName="AshghalTestNumber" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtAshghalTestNumber" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Standard Number" FieldName="StandardNumber" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtStandardNumber" runat="server">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Service Name" FieldName="TestName" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtTestName" runat="server" Width="450">
                                        <ValidationSettings ValidationGroup="OnSave" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Test Name is missing!">
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Short Name" FieldName="ShortName" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtShortName" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Standard Description" FieldName="TestDescription" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtTestDescription" runat="server" Width="755"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Accredition Status" FieldName="FKAccreditionID" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKAccreditionID" runat="server" ValueField="AccreditionID" TextField="AccreditionName"
                                        DataSourceID="AccreditionListDS" Width="250">
                                        <ValidationSettings ValidationGroup="OnSave" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Accredition Status is missing!">
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Lab Section" FieldName="FKLabID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKLabID" runat="server" ValueField="LabID" TextField="LabName" AutoPostBack="true"
                                        DataSourceID="LabsListDS">
                                        <ValidationSettings ValidationGroup="OnSave" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Lab Section is missing!">
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Result Unit" FieldName="ResultUnit" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtResultUnit" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Accredition No" FieldName="ResultSpecs" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtResultSpecs" runat="server" Width="477"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Sampling Method" FieldName="SamplingMethod" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSamplingMethod" runat="server"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Mandatory Service" FieldName="FKTestID" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbFKTestID" runat="server" ValueField="TestID" DataSourceID="RelatedTestsListDS"
                                                     >
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="TestName" />  
                                            <dx:ListBoxColumn FieldName="StandardNumber" />  
                                        </Columns>
                                        <ClearButton Visibility="True"></ClearButton>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Report Group" FieldName="FkGroupId" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbReportGroup" runat="server" ValueField="GroupID" TextField="GroupName"
                                        DataSourceID="ReportGroupDS" ReadOnly="true">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <%--Barkat: Remark field is added--%>
                          <dx:LayoutItem Caption="Remarks" FieldName="Remarks" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtRemarks" runat="server" Width="477"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Test Required Time (Days)" FieldName="TestRequiredTime" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="txtTestRequiredTime" runat="server" NumberType="Integer" Number="0" MinValue="0" SpinButtons-ShowIncrementButtons="true"
                                        AllowMouseWheel="false">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Equipment List" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <div style="overflow: auto; height: 100px">
                                        <dx:ASPxCheckBoxList ID="lstEquipmentList" runat="server" DataSourceID="EquipmentsListDS" ValueType="System.Int32"
                                            TextField="EquipmentName" ValueField="EquipmentID" Width="200" OnDataBound="lstEquipmentList_DataBound">
                                        </dx:ASPxCheckBoxList>
                                    </div>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Recommended Subcontractor" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <div style="overflow: auto; height: 100px">
                                        <dx:ASPxCheckBoxList ID="lstSubContractors" runat="server" DataSourceID="odsSubcontractorsByStatus" ValueType="System.Int32"
                                            TextField="SubContractorName" ValueField="SubContractorID" Width="200" OnDataBound="lstSubContractors_DataBound">
                                        </dx:ASPxCheckBoxList>
                                    </div>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Test Excel Files" ColCount="8">
                    <Items>
                        <dx:LayoutItem Caption="Workform Workbook file" FieldName="WorkFormFileName" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtWorkform" runat="server" Width="150" ClientInstanceName="txtWorkform" NullText="Click to select Workform file">
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
                        <dx:LayoutItem Caption="Uplaoded file" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                        <a onclick="hdnWorkbookFill(this);" >Download</a>
                                    <dx:ASPxHiddenField ID="hdnWorkbook" runat="server" ClientInstanceName="hdnWorkbook"></dx:ASPxHiddenField>
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
                        <dx:LayoutItem Caption="" FieldName="FKTestID" ColSpan="2">
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
                                    <dx:ASPxTextBox ID="txtReport" runat="server" Width="150" ClientInstanceName="txtReport" NullText="Click to select Report file"></dx:ASPxTextBox>
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
                        <dx:LayoutItem Caption="Uplaoded file" FieldName="ReportFileName" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <a onclick="hdnReportFill(this);" >Download</a>
                                    <dx:ASPxHiddenField ID="hdnReport" runat="server" ClientInstanceName="hdnReport"></dx:ASPxHiddenField>
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
                <dx:LayoutGroup Caption="Prices" ColCount="6">
                    <Items>
                        <dx:LayoutItem Caption="Default Price" FieldName="DefaultPrice" ColSpan="3" Visible="false">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="txtDefaultPrice" runat="server" Number="0" SpinButtons-ShowIncrementButtons="false"
                                        AllowMouseWheel="false">
                                        <SpinButtons ShowIncrementButtons="False"></SpinButtons>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Minimum Price" FieldName="MinimumPrice" ColSpan="3" Visible="false">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxSpinEdit ID="txtMinimumPrice" runat="server" SpinButtons-ShowIncrementButtons="false"
                                        AllowMouseWheel="false" Number="0">
                                        <SpinButtons ShowIncrementButtons="False"></SpinButtons>
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:EmptyLayoutItem Width="40"></dx:EmptyLayoutItem>
                        <dx:LayoutItem ShowCaption="False" HorizontalAlign="Center" ColSpan="5 ">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxGridView runat="server" ID="GdvTestPriceList" AutoGenerateColumns="false" ClientInstanceName="gridTestPriceList" OnCustomErrorText="GdvTestPriceList_CustomErrorText"
                                        DataSourceID="TestPricesDS" KeyFieldName="TestPriceID" OnRowInserting="GdvTestPriceList_RowInserting" OnRowUpdating="GdvTestPriceList_RowUpdating" OnStartRowEditing="GdvTestPriceList_StartRowEditing">
                                        <Columns>

                                            <dx:GridViewDataComboBoxColumn FieldName="FKPriceUnitID" Caption="Unit" Width="400" VisibleIndex="1">
                                                <Settings AutoFilterCondition="Contains" />
                                                <PropertiesComboBox ValueField="PriceUnitID" TextField="UnitName" DataSourceID="PriceUnitListDS">
                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select a unit!">
                                                        <RequiredField IsRequired="true" ErrorText="Select a unit" />
                                                    </ValidationSettings>
                                                </PropertiesComboBox>
                                                <EditFormSettings Visible="False" />
                                                <Settings AutoFilterCondition="Contains" />
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="DefaultPrice" Caption="Default Price" Width="100" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                                                <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false" AllowMouseWheel="false">
                                                    <SpinButtons ShowIncrementButtons="False"></SpinButtons>

                                                    <ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="DefaultPrice is missing!">
                                                        <RequiredField IsRequired="True"></RequiredField>
                                                    </ValidationSettings>
                                                </PropertiesSpinEdit>

                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataSpinEditColumn FieldName="MinimumPrice" Caption="Minimum Price" Width="100" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                                                <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"
                                                    AllowMouseWheel="false">
                                                    <SpinButtons ShowIncrementButtons="False"></SpinButtons>

                                                    <ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Minimum Price is missing!">
                                                        <RequiredField IsRequired="True"></RequiredField>
                                                    </ValidationSettings>
                                                </PropertiesSpinEdit>

                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                            </dx:GridViewDataSpinEditColumn>

                                            <dx:GridViewCommandColumn VisibleIndex="4" ButtonType="Default" Width="60"
                                                ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                                                <HeaderCaptionTemplate>
                                                    <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" CssClass="btn btn-mini btn-sm btn-round btn-primary" runat="server">
                                                        <ClientSideEvents Init="function(s, e) {s.GetTextContainer().className = ' fa fa-plus';}" Click="function (s, e) { gridTestPriceList.AddNewRow();}" />
                                                        <BackgroundImage HorizontalPosition="center" />
                                                    </dx:ASPxButton>
                                                </HeaderCaptionTemplate>

                                            </dx:GridViewCommandColumn>
                                        </Columns>

                                        <SettingsCommandButton>
                                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

                                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>

                                            <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser">
                                                <Styles>
                                                    <Style CssClass="fa fa-eraser" Font-Size="Medium"></Style>
                                                </Styles>
                                            </ClearFilterButton>
                                            <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit">
                                                <Styles>
                                                    <Style CssClass="glyphicon glyphicon-edit" Font-Size="Medium"></Style>
                                                </Styles>
                                            </EditButton>
                                            <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash">
                                                <Styles>
                                                    <Style CssClass="glyphicon glyphicon-trash" Font-Size="Medium"></Style>
                                                </Styles>
                                            </DeleteButton>
                                            <CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove">
                                                <Styles>
                                                    <Style CssClass="glyphicon glyphicon-remove" Font-Size="Large"></Style>
                                                </Styles>
                                            </CancelButton>
                                            <UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk">
                                                <Styles>
                                                    <Style CssClass="glyphicon glyphicon-floppy-disk" Font-Size="Medium"></Style>
                                                </Styles>
                                            </UpdateButton>
                                        </SettingsCommandButton>
                                        <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom" />
                                        <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" />
                                        <Styles>
                                            <Header BackColor="SteelBlue" ForeColor="White"></Header>
                                        </Styles>
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Consumed Materials" ColCount="2">
                    <Items>
                        <dx:EmptyLayoutItem Width="40"></dx:EmptyLayoutItem>
                        <dx:LayoutItem ShowCaption="False" HorizontalAlign="Center">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxGridView runat="server" ID="GdvTestItemsList" AutoGenerateColumns="false" ClientInstanceName="gridTestItemsList"
                                        DataSourceID="TestItemsDS" KeyFieldName="TestItemsID" OnRowInserting="GdvTestItemsList_RowInserting" OnRowUpdating="GdvTestItemsList_RowUpdating">
                                        <Columns>
                                            <dx:GridViewDataComboBoxColumn FieldName="FKItemID" Caption="Material Name" Width="500" VisibleIndex="1">
                                                <PropertiesComboBox ValueField="ItemID" TextFormatString="{0} - {1}" DataSourceID="ItemsListDS">
                                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Select an item!">
                                                        <RequiredField IsRequired="true" ErrorText="Select Item" />
                                                    </ValidationSettings>
                                                    <Columns>
                                                        <dx:ListBoxColumn FieldName="ItemName" Name="ItemName" Caption="Item Name" />
                                                        <dx:ListBoxColumn FieldName="UnitOfMeasure" Name="UnitOfMeasure" Caption="Unit Of Measure" />
                                                    </Columns>
                                                </PropertiesComboBox>
                                                <Settings AutoFilterCondition="Contains" />
                                            </dx:GridViewDataComboBoxColumn>


                                            <dx:GridViewDataTextColumn FieldName="Qty" Caption="Qty" Width="100" VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                                                <PropertiesTextEdit>
                                                    <ValidationSettings ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip" RequiredField-IsRequired="true" ErrorText="Qty is missing!">
                                                        <RequiredField IsRequired="True"></RequiredField>
                                                    </ValidationSettings>
                                                </PropertiesTextEdit>
                                                <Settings AutoFilterCondition="Contains" />

                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewCommandColumn VisibleIndex="3" ButtonType="Default" Width="60"
                                                ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">


                                                <HeaderCaptionTemplate>
                                                    <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" CssClass="btn btn-mini btn-sm btn-round btn-primary" runat="server">
                                                        <ClientSideEvents Init="function(s, e) {s.GetTextContainer().className = ' fa fa-plus';}" Click="function (s, e) { gridTestItemsList.AddNewRow();}" />
                                                        <BackgroundImage HorizontalPosition="center" />
                                                    </dx:ASPxButton>
                                                </HeaderCaptionTemplate>

                                            </dx:GridViewCommandColumn>
                                        </Columns>
                                        <SettingsCommandButton>
                                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

                                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>

                                            <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser">
                                                <Styles>
                                                    <Style CssClass="fa fa-eraser" Font-Size="Medium"></Style>
                                                </Styles>
                                            </ClearFilterButton>
                                            <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit">
                                                <Styles>
                                                    <Style CssClass="glyphicon glyphicon-edit" Font-Size="Medium"></Style>
                                                </Styles>
                                            </EditButton>
                                            <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash">
                                                <Styles>
                                                    <Style CssClass="glyphicon glyphicon-trash" Font-Size="Medium"></Style>
                                                </Styles>
                                            </DeleteButton>
                                            <CancelButton Text=" " Styles-Style-Font-Size="Large" Styles-Style-CssClass="glyphicon glyphicon-remove">
                                                <Styles>
                                                    <Style CssClass="glyphicon glyphicon-remove" Font-Size="Large"></Style>
                                                </Styles>
                                            </CancelButton>
                                            <UpdateButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-floppy-disk">
                                                <Styles>
                                                    <Style CssClass="glyphicon glyphicon-floppy-disk" Font-Size="Medium"></Style>
                                                </Styles>
                                            </UpdateButton>
                                        </SettingsCommandButton>
                                        <SettingsEditing Mode="Inline" NewItemRowPosition="Bottom" />
                                        <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
                                        <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" />
                                        <Styles>
                                            <Header BackColor="SteelBlue" ForeColor="White"></Header>
                                        </Styles>
                                    </dx:ASPxGridView>
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
                            <%--<div class="inline" style="width: 100px">
                                <dx:ASPxButton ID="btnValidate" runat="server" Text="Validate" CssClass="btn btn-mini btn-sm btn-round btn-warning" ValidationGroup="options" ClientInstanceName="btnValidate"
                                    ToolTip="Valida" AutoPostBack="true" Cursor="pointer"
                                    EnableTheming="false"  Width="80px">
                                </dx:ASPxButton>
                            </div>--%>
                            <div class="inline" style="width: 100px">
                                <dx:ASPxButton ID="btnOk" runat="server" Text="Save" CssClass="btn btn-mini btn-sm btn-round btn-primary" ValidationGroup="options" ClientInstanceName="btnOk"
                                    ToolTip="OK" AutoPostBack="false" Cursor="pointer"
                                    EnableTheming="false" Width="80px">
                                    <ClientSideEvents Click="function(s,e) {gridColumnMapping.UpdateEdit();}" />
                                </dx:ASPxButton>


                            </div>
                            <div class="inline">
                                <dx:ASPxButton ID="btnPopCancel" runat="server" Text="Cancel" CssClass="btn btn-mini btn-sm btn-round btn-default"
                                    ToolTip="Cancel" AutoPostBack="false" Cursor="pointer"
                                    EnableTheming="false" Width="80px">
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

  

    <div>
        <dx:ASPxPopupControl ID="popupAttachment" runat="server" HeaderText="Attachment" ShowHeader="true" ShowPageScrollbarWhenModal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
            CloseAction="CloseButton" AllowDragging="True" ClientInstanceName="popupAttachment" LoadContentViaCallback="OnPageLoad" Width="1000" Height="500" PopupAlignCorrection="Disabled"
            ShowCloseButton="true" PopupAnimationType="Slide">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                    <div>
                          <div id="divattachfile" style="width: 100%; height: inherit" runat="server"  visible ="false">
        <div class="hidden" id="divattachfilemsg" runat="server" style="width: 500px;">
            <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
            <dx:ASPxLabel ID="ASPxLabel1" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
        </div>
        <div class="table" style="padding-left: 10px; padding-right: 10px; padding-top: 10px">
            <div class="divrow">
                <div style="float: left; margin-right: 80px;">
                    <dx:ASPxUploadControl ID="UploadControl" runat="server" ClientInstanceName="UploadControl" Width="320"
                        NullText="Select multiple files..." UploadMode="Advanced" ShowUploadButton="True" ShowProgressPanel="True"
                        OnFileUploadComplete="UploadControl_FileUploadComplete" FileUploadMode="OnPageLoad">
                        <AdvancedModeSettings EnableMultiSelect="True" EnableFileList="True" EnableDragAndDrop="True">
                            <FileListItemStyle CssClass="pending dxucFileListItem"></FileListItemStyle>
                        </AdvancedModeSettings>
                        <ValidationSettings
                            AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp, .jpe, .jpeg, .jpg, .gif, .png"
                            MaxFileSize="10485760">
                        </ValidationSettings>
                        <ClientSideEvents FileUploadStart="function(s, e) { }" FileUploadComplete="onFileUploadComplete" />
                    </dx:ASPxUploadControl>
                    <br />
                    <br />
                    <p class="note">
                        <dx:ASPxLabel ID="AllowedFileExtensionsLabel" runat="server" Text="Allowed file extensions: .rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp, .jpe, .jpeg, .jpg, .gif, .png" Font-Size="8pt">
                        </dx:ASPxLabel>
                        <br />
                        <dx:ASPxLabel ID="MaxFileSizeLabel" runat="server" Text="Maximum file size: 4 MB." Font-Size="8pt">
                        </dx:ASPxLabel>
                    </p>
                </div>
            </div>
            <div class="divrow">
                <dx:ASPxRoundPanel ID="FilContents" ClientInstanceName="gridpanel" runat="server" Width="400" Height="180" HeaderText="Attached Files">
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxGridView ID="gdvfiles" ClientInstanceName="gdvfiles" runat="server" DataSourceID="TransactionAttachmentsDS" KeyFieldName="FileID" Width="380" OnCustomCallback="gdvfiles_CustomCallback"  OnRowCommand="gdvfiles_RowCommand">
                                <Columns>
                                    <dx:GridViewDataHyperLinkColumn FieldName="FileName" Caption="File" Width="250">
                                        <DataItemTemplate>
                                            <a target='blank' style="display: block; text-wrap: avoid; width: 100px" onclick='return ShowScreenshotWindow(event, this);'><%#Eval("FileName") %></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataHyperLinkColumn>
                                    <dx:GridViewDataTextColumn FieldName="FileSize" Name="filesize" Caption="Size" Width="50">
                                        <Settings AutoFilterCondition="Contains" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn Name="Delete" Width="30">
                                        <DataItemTemplate>
                                            <dx:ASPxButton ID="BtnDelete" runat="server" Cursor="pointer" RenderMode="Link" EnableTheming="false" EnableViewState="false" CommandName="delete" FileName='<%#Eval("FileName") %>' CommandArgument='<%#Eval("FileID") %>'>
                                                <Image Url="../images/cross_icon.png" ToolTip="Remove"></Image>
                                            </dx:ASPxButton>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Name="Edit" Width="25">
                                        <DataItemTemplate>
                                             <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <dx:ASPxButton ID="BtnEdit" runat="server" Cursor="pointer" RenderMode="Link" ToolTip="<%$ Resources:GlobalResource, EditFormNew %>" EnableTheming="false" EnableViewState="false" CommandName="download" FileName='<%#Eval("FileName") %>' CommandArgument='<%#Eval("FileID") %>'>
                                                        <Image AlternateText="<%$ Resources:GlobalResource, EditFormUpdate %>" ToolTip="download" Url="../images/download4.jpg"></Image>
                                                    </dx:ASPxButton>
                                                 </ContentTemplate>
                                                <Triggers>
                                                    <asp:postbacktrigger controlid="BtnEdit" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                </Columns>
                                <SettingsCommandButton>
                                    <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                    <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                    <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                </SettingsCommandButton>
                                <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="true" />
                                <SettingsPager PageSize="5" Mode="ShowPager"></SettingsPager>
                                <ClientSideEvents BeginCallback="function(s,e){FilesGridEdited=true;}" />
                            </dx:ASPxGridView>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
            </div>
        </div>
        </div>

                          <div id="divsessionattachfile" style="width: 100%; height: inherit" runat="server">
            <div class="hidden" id="divsessionattachfilemsg" runat="server" style="width: 500px;">
                <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
            </div>
            <div class="table" style="padding-left: 10px; padding-right: 10px; padding-top: 10px">
                <div class="divrow">
                    <div style="float: left; margin-right: 80px;">
                        <dx:ASPxUploadControl ID="SessionUploadControl" runat="server" ClientInstanceName="SessionUploadControl" Width="320"
                            NullText="Select multiple session files..." UploadMode="Advanced" ShowUploadButton="True" ShowProgressPanel="True"
                            OnFileUploadComplete="UploadControl_SessionFileUploadComplete" FileUploadMode="OnPageLoad">
                            <AdvancedModeSettings EnableMultiSelect="True" EnableFileList="True" EnableDragAndDrop="True">
                                <FileListItemStyle CssClass="pending dxucFileListItem"></FileListItemStyle>
                            </AdvancedModeSettings>
                            <ValidationSettings
                                AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp, .jpe, .jpeg, .jpg, .gif, .png"
                                MaxFileSize="10485760">
                            </ValidationSettings>
                            <ClientSideEvents FileUploadStart="function(s, e) { }" FileUploadComplete="onSessionFileUploadComplete" />
                        </dx:ASPxUploadControl>
                        <br />
                        <br />
                        <p class="note">
                            <dx:ASPxLabel ID="SessionAllowedFileExtensionsLabel" runat="server" Text="Allowed file extensions: .rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp, .jpe, .jpeg, .jpg, .gif, .png" Font-Size="8pt">
                            </dx:ASPxLabel>
                            <br />
                            <dx:ASPxLabel ID="SessionMaxFileSizeLabel" runat="server" Text="Maximum file size: 4 MB." Font-Size="8pt">
                            </dx:ASPxLabel>
                        </p>
                    </div>
                </div>
                <div class="divrow">
                    <dx:ASPxRoundPanel ID="SessionFileContents" ClientInstanceName="gridpanel" runat="server" Width="400" Height="180" HeaderText="Session Attached Files">
                        <PanelCollection>
                            <dx:PanelContent>
                                <dx:ASPxGridView ID="gdvSessionFiles" ClientInstanceName="gdvSessionFiles" runat="server" DataSourceID="SessionAttachmentsDS" KeyFieldName="FileID" Width="380" OnCustomCallback="gdvSessionFiles_CustomCallback" OnRowCommand="gdvSessionFiles_RowCommand">
                                    <Columns>
                                        <dx:GridViewDataHyperLinkColumn FieldName="FileName" Caption="File" Width="250">
                                            <DataItemTemplate>
                                                <a target='blank' style="display: block; text-wrap: avoid; width: 100px" onclick='return ShowScreenshotWindow(event, this);'><%#Eval("FileName") %></a>
                                            </DataItemTemplate>
                                        </dx:GridViewDataHyperLinkColumn>
                                        <dx:GridViewDataTextColumn FieldName="FileSize" Name="filesize" Caption="Size" Width="50">
                                            <Settings AutoFilterCondition="Contains" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataColumn Name="Delete" Width="30">
                                            <DataItemTemplate>
                                                <dx:ASPxButton ID="BtnDelete" runat="server" Cursor="pointer" RenderMode="Link" EnableTheming="false" EnableViewState="false" CommandName="delete" FileName='<%#Eval("FileName") %>' CommandArgument='<%#Eval("FileID") %>'>
                                                    <Image Url="../images/cross_icon.png" ToolTip="Remove"></Image>
                                                </dx:ASPxButton>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                    <SettingsCommandButton>
                                        <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                        <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                        <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                    </SettingsCommandButton>
                                    <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="true" />
                                    <SettingsPager PageSize="5" Mode="ShowPager"></SettingsPager>
                                    <ClientSideEvents BeginCallback="function(s,e){FilesGridEdited=true;}" />
                                </dx:ASPxGridView>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
                </div>
            </div>
        </div>      
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </div>

        <asp:ObjectDataSource ID="TransactionAttachmentsDS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAttachmentsWithNew" TypeName="BusinessLayer.Pages.AttachedFilesDB"
        ConflictDetection="CompareAllValues"
        DataObjectTypeName="BusinessLayer.AttachedFiles"
        DeleteMethod="DeleteData">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblTransID" DefaultValue="0" Name="transID" PropertyName="Text" Type="Int64" />
            <asp:ControlParameter ControlID="lblTransTypeID" PropertyName="Text" DefaultValue="55555" Name="transTypeID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="SessionAttachmentsDS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAttachmentsWithNew" TypeName="LaboratoryLayer.Pages.SessionAttachedFilesDB"
        ConflictDetection="CompareAllValues"
        DataObjectTypeName="BusinessLayer.AttachedFiles"
        DeleteMethod="DeleteData">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblTransID" DefaultValue="0" Name="transID" PropertyName="Text" Type="Int64" />
            <asp:ControlParameter ControlID="lblTransTypeID" PropertyName="Text" DefaultValue="55555" Name="transTypeID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="AccreditionListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.AccreditionListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.AccreditionList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="LabsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.LabsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.LabsList"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ReportGroupDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ReportGroupDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.ReportGroup"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="RelatedTestsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetAllActive" DataObjectTypeName="BusinessLayer.TestsList"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="TestsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetByID" InsertMethod="Insert" UpdateMethod="Update"
        OnInserting="TestsListDS_Inserting" OnInserted="TestsListDS_Inserted"
        OnUpdating="TestsListDS_Updating" OnUpdated="TestsListDS_Updated">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="EquipmentsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EquipmentsListDB"
        SelectMethod="GetByLabId" DataObjectTypeName="BusinessLayer.EquipmentsList">
        <SelectParameters>
            <asp:ControlParameter ControlID="ctl00$body$flTestsList$cmbFKLabID" PropertyName="Value" DefaultValue="0" Name="FKLabID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TestEquipmentsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestEquipmentsDB"
        SelectMethod="GetByMasterID" UpdateMethod="UpdateList" OnUpdating="TestEquipmentsDS_Updating">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="SubcontractorsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.SubcontractorsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.SubcontractorsList"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="odsSubcontractorsByStatus" runat="server" TypeName="BusinessLayer.SqlQueryModels.SubcontractorService" SelectMethod="GetSubcontractorsByStatus" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>


    <asp:ObjectDataSource ID="TestContractorsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestContractorsDB"
        SelectMethod="GetByMasterID" UpdateMethod="UpdateList" OnUpdating="TestContractorsDS_Updating">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="WorkformWorksheetListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetWorkformWorksheetList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ReportWorksheetListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetReportWorksheetList"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ItemsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ItemsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.ItemsList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TestItemsDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestItemsDB"
        SelectMethod="GetByMasterIDWithSession" InsertMethod="InsertWithSession" UpdateMethod="UpdateWithSession" DeleteMethod="DeleteWithSession" DataObjectTypeName="BusinessLayer.TestItems">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="PriceUnitListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.PriceUnitListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.PriceUnitList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TestPricesDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestPricesDB"
        SelectMethod="GetByMasterIDWithSession" InsertMethod="InsertWithSession" UpdateMethod="UpdateWithSession" DeleteMethod="DeleteWithSession" DataObjectTypeName="BusinessLayer.TestPrices">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
        </SelectParameters>

    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="FieldListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestExcelMappingDB"
        SelectMethod="GetFieldList" DataObjectTypeName="BusinessLayer.ExcelMappingFieldList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ColumnMappingDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestExcelMappingDB"
        SelectMethod="GetMappingListByMasterIDWithSession" UpdateMethod="UpdateMapping" DataObjectTypeName="BusinessLayer.ViewExcelCellFieldMapping">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="masterId" Type="Int32" />
            <asp:ControlParameter ControlID="ctl00$body$popupMapping$isreport" PropertyName="Text" DefaultValue="False" Name="IsReport" Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>



</asp:Content>
