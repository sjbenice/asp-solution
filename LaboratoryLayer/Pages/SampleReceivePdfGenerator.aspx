<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="SampleReceivePdfGenerator.aspx.cs" Inherits="LaboratoryLayer.Pages.SampleReceivePdfGenerator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<dx:ASPxLabel ID="lblUploadDirectory" runat="server" Text="~/Uploaded/Attachments" Visible="false"></dx:ASPxLabel>--%>
    <script>
        function PrintReport() {
            window.open('ReportViwer.aspx?source=SampleReceiptReport&id=0&Filter=' + gridCustomersList.cpFilter, '_blank');
        }

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
    <style type="text/css">
        .HideScroll > tbody > tr > td > div {
            overflow: hidden !important;
        }

        .ComboBoxSize .dxlbd {
            min-width: 250px;
            min-height: 250px;
        }
    </style>
    <script type="text/javascript">

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
            document.getElementById("body_flSampleReceiveList_uplWorkbookfile_TextBox0_Input").click();
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
            document.getElementById("body_flSampleReceiveList_uplReportfile_TextBox0_Input").click();
        }
        function PrintElem(elem) {
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

        function grid_SelectionChanged(s, e) {
            if (e.isChangedOnServer == true)
                return;

            //alert(e.isChangedOnServer);
            //var key = s.GetRowKey(e.visibleIndex);  
            //alert("Selected:" + key + "Checked:" + e.isSelected);
            var params = [e.visibleIndex, e.isSelected];
            gdvSampleTestList.PerformCallback(params);
        }

    </script>
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
    <script>
        var curentEditingIndex;
        var lastTest = null;
        function OnBatchEditEndEditing(s, e) {
            window.setTimeout(function () {
                var Total = 0;
                curentEditingIndex = e.visibleIndex;
                var indicies = s.batchEditHelper.GetDataItemVisibleIndices();
                for (var i = 0; i < indicies.length; i++) {

                    var Price = s.batchEditApi.GetCellValue(indicies[i], "Price");
                    var Qty = s.batchEditApi.GetCellValue(indicies[i], "Qty");
                    if (Qty == null)
                        Qty = 0;
                    Total = Total + (Price * Qty);
                }
                //alert(Total);
                txtTotalTestPrices.SetText(Total);

                hfT.Set("TotalTestPrices", Total);
            }, 10)
        }

        function OnBatchEditStartEditing(s, e) {
            curentEditingIndex = e.visibleIndex;
            var currentTest = gdvSampleTestList.batchEditApi.GetCellValue(curentEditingIndex, "FKTestID");


            //if (currentTest != lastTest && e.focusedColumn.fieldName == "FKPriceUnitID" && currentTest != null) {
            if (e.focusedColumn.fieldName == "FKSubContractorID" && currentTest != null) {

                lastTest = currentTest;
                RefreshData(currentTest);
            }
            if (e.focusedColumn.fieldName == "FKTestID") {
                e.cancel = true;
            }


            var IsEnabled = gdvSampleTestList.batchEditApi.GetCellValue(e.visibleIndex, "Enabled");
            if (IsEnabled == false) {
                e.cancel = true;
            }
        }

        function RefreshData(value) {
            hf.Set("CurrentTest", value);
            SubContractorEditor.PerformCallback();
        }
        function OnValidate(s, e) {
            isValidRow = true;
            var WitnessColumnIndex = s.GetColumnById("Witness").index;
            var WitnessNameColumnIndex = s.GetColumnById("WitnessName").index;
            var SubcontractColumnIndex = s.GetColumnById("Subcontract").index;
            var FKSubContractorIDColumnIndex = s.GetColumnByField("FKSubContractorID").index;
            var QtyColumnIndex = s.GetColumnById("Qty").index;
            var MinQtyColumnIndex = s.GetColumnByField("MinQty").index;

            var WitnessValue = e.validationInfo[WitnessColumnIndex].value;
            var WitnessNameValue = e.validationInfo[WitnessNameColumnIndex].value;
            var SubcontractValue = e.validationInfo[SubcontractColumnIndex].value;
            var FKSubContractorValue = e.validationInfo[FKSubContractorIDColumnIndex].value;
            var QtyValue = e.validationInfo[QtyColumnIndex].value;
            var MinQtyValue = e.validationInfo[MinQtyColumnIndex].value;

            isValidRow = e.validationInfo[WitnessColumnIndex].isValid;
            if ((WitnessValue == true) && (WitnessNameValue == null)) {
                e.validationInfo[WitnessNameColumnIndex].isValid = false;
                e.validationInfo[WitnessNameColumnIndex].errorText = "Required";
                isValidRow = false;
            }

            if (SubcontractValue == true && (FKSubContractorValue == null)) {
                e.validationInfo[FKSubContractorIDColumnIndex].isValid = false;
                e.validationInfo[FKSubContractorIDColumnIndex].errorText = "Required";
                isValidRow = false;
            }

            if ((QtyValue < MinQtyValue) && (QtyValue != null)) {
                e.validationInfo[QtyColumnIndex].isValid = false;
                e.validationInfo[QtyColumnIndex].errorText = "Minimum Quantity for this test is  " + MinQtyValue;
                isValidRow = false;
            }
            //if (QtyValue == null) {
            //    e.validationInfo[QtyColumnIndex].isValid = false;
            //    e.validationInfo[QtyColumnIndex].errorText = "Required ";
            //    isValidRow = false;
            //}

            if (isValidRow) {
                s.batchEditHelper.ApplyValidationInfo(e.visibleIndex, { isValid: isValidRow, dict: e.validationInfo });
            }
        }

        function OnBatchEditChangesCanceling(s, e) {
            e.cancel = true;
        }

        function onSaveClick(s, e) {

            //var gdvCustomFields = ASPxClientGridView.Cast(gdvCustomFields);

            var isValidGrid = true;
            var grid = ASPxClientGridView.Cast(gdvSampleTestList);
            var indicies = grid.batchEditHelper.GetDataItemVisibleIndices();

            var selectedKeys = grid.GetSelectedKeysOnPage();

            for (var i = 0; i < indicies.length; i++) {
                for (var n = 0; n < selectedKeys.length; n++) {


                    var key = grid.GetRowKey(indicies[i]);
                    if (selectedKeys.includes(key)) {
                        var FKTestID = grid.batchEditApi.GetCellValue(indicies[i], "FKTestID");
                        var Witness = grid.batchEditApi.GetCellValue(indicies[i], "Witness");
                        var WitnessName = grid.batchEditApi.GetCellValue(indicies[i], "WitnessName");
                        var Subcontract = grid.batchEditApi.GetCellValue(indicies[i], "Subcontract");
                        var FKSubContractorID = grid.batchEditApi.GetCellValue(indicies[i], "FKSubContractorID");
                        var Qty = grid.batchEditApi.GetCellValue(indicies[i], "Qty");
                        var MinQty = grid.batchEditApi.GetCellValue(indicies[i], "MinQty");


                        var IsEnabled = grid.batchEditApi.GetCellValue(indicies[i], "Enabled");
                        if (IsEnabled == true) {
                            debugger
                            if ((Witness == true) && (WitnessName == null)) {
                                isValidGrid = false;
                                SetError(" Witness Name is not specified !!");
                                break;
                            }
                            if ((Subcontract == true) && (FKSubContractorID == null)) {
                                isValidGrid = false;
                                SetError(" Sub Contractor Name is not specified !!");
                                break;
                            }
                            console.log(Qty, MinQty);
                            //alert(Qty);
                            //alert(MinQty);
                            //if ((Qty < MinQty)) {
                            //    //  alert(Qty);
                            //    //alert(MinQty);
                            //    isValidGrid = false;
                            //    SetError(" Minimum Quantity for this test is  " + MinQty);
                            //    break;
                            //}
                            if ((Qty == null)) {
                                isValidGrid = false;
                                SetError(" Quantity is not specified  !!, Minimum Quantity for this test is  " + FKTestID + MinQty);
                                break;
                            }
                            else if ((Qty == undefined)) {
                                isValidGrid = false;
                                SetError(" Quantity is not specified 2 !!, Minimum Quantity for this test is  " + FKTestID + MinQty);
                                break;
                            }
                        }

                    }
                }
            }

            e.processOnServer = isValidGrid;

            if (isValidGrid == true) {
                e.processOnServer = true;
                gdvCustomFields.UpdateEdit();
                gdvSampleTestList.UpdateEdit();
                gdvCustomTableFields.UpdateEdit();
                window.setTimeout(function () { s.SetEnabled(false); }, 100)
            }
            else
                e.processOnServer = false
        }

        function SetError(s) {

            // $('#divError').show();
            document.getElementById('divError').className = 'alert alert-danger';
            //document.getElementById('LblError').innerText = s;
            alert(s);
            lblErrorMessage.SetText(s);

            $('.alert').show();
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
            <li><a id="menu1" href="#">Transaction</a></li>
            <li class="active" id="menulink">Sample Receive</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Sample Receive</h1>
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
        
        <dx:ASPxLabel ID="txtRecordNeedReport" runat="server" Text="" style="float: inline-start;"></dx:ASPxLabel>

        <br/>
        <div style="text-align: left">
            
            <div class="btn-group" role="group" aria-label="First group">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Number SampleReceive To Generate Report: "></dx:ASPxLabel>
            </div>
            <div class="btn-group" role="group" aria-label="First group" style="left: 20px;height: 100px;">
                <dx:ASPxTextBox ID="txtCount" Height="40" Width="100" HorizontalAlign="Center" CaptionStyle-Font-Bold="true" Font-Bold="true" runat="server" Text="1"></dx:ASPxTextBox>

            </div>
            <div class="btn-group" role="group" aria-label="First group" style="left: 30px;">
                <dx:ASPxButton ID="BtnGenerate" runat="server" CssClass="btn btn-round btn-primary fa fa-plus" Style="width: 80px" Text="Generate PDF" OnClick="BtnGenerate_OnClick">
                </dx:ASPxButton>
            </div>
            <div class="btn-group" role="group" aria-label="First group">
            </div>



        </div>


        <div class="btn-group" role="group" aria-label="First group">
        </div>

    </div>
    <div class="row" style="height: 20px"></div>
    <div class="btn-toolbar">

        <div class="hidden" id="divmsg" runat="server" style="width: 750px;">
            <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
            <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblErroe2" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblErroe2"></dx:ASPxLabel>

        </div>
        <div id="divError" class="hidden" style="width: 750px;">
            <button type="button" class="close" data-hide="alert" onclick="$('#divError').hide()">&times;</button>
            <dx:ASPxLabel ID="lblErrorMessage" runat="server" CssClass="Alert" ForeColor="Red" Text="" ClientInstanceName="lblErrorMessage"></dx:ASPxLabel>

            <%--<dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" RenderMode="Table"  ValidationGroup="OnSave"></dx:ASPxValidationSummary>--%>
        </div>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxLabel ID="lblMasterId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>
        <dx:ASPxLabel ID="lblFKMaterialTypeID" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>

    </div>

</asp:Content>
