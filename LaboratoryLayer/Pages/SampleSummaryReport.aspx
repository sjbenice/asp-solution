<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="SampleSummaryReport.aspx.cs" Inherits="LaboratoryLayer.Pages.Reports.SampleSummaryReport" %>
<%--<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>--%>
<%@ Register Assembly="DevExpress.XtraReports.v16.1.Web, Version=16.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .lable {
            text-align: center;
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
            <li><a id="menu1" href="#">Report</a></li>
            <li class="active" id="menulink">Sample Summary</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Sample Summary</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
  
    <script type="text/javascript">
        var textSeparator = ",";
        function updateText() {
            var selectedItems = checkListBox.GetSelectedItems();
            checkComboBox.SetText(getSelectedItemsText(selectedItems));
        }
        function synchronizeListBoxValues(dropDown, args) {
            checkListBox.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = getValuesByTexts(texts);
            checkListBox.SelectValues(values);
            updateText(); // for remove non-existing texts
        }
        function getSelectedItemsText(items) {
            var texts = [];
            for (var i = 0; i < items.length; i++)
                texts.push(items[i].value);
            return texts.join(textSeparator);
        }
        function getValuesByTexts(texts) {
            var actualValues = [];
            var item;
            for (var i = 0; i < texts.length; i++) {
                item = checkListBox.FindItemByValue(texts[i]);
                if (item != null)
                    actualValues.push(item.value);
            }
            return actualValues;
        }


        function updateTextcmbSubcontractors() {
            var selectedItems = checkListBoxcmbSubcontractors.GetSelectedItems();
            cmbSubcontractors.SetText(getSelectedItemsText(selectedItems));
        }
        function synchronizeListBoxValuescmbSubcontractors(dropDown, args) {
            checkListBoxcmbSubcontractors.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = getValuesByTexts(texts);
            checkListBoxcmbSubcontractors.SelectValues(values);
            updateTextcmbSubcontractors(); // for remove non-existing texts
        }


        function init(s) {
            
             var createFrameElement = s.viewer.printHelper.createFrameElement;
             s.viewer.printHelper.createFrameElement = function (name) {
                 var frameElement = createFrameElement.call(this, name);
                 if(ASPx.Browser.Chrome) {
                     frameElement.addEventListener("load", function (e) {
                         if (frameElement.contentDocument &&  frameElement.contentDocument.contentType !== "text/html")
                             frameElement.contentWindow.print();
                     });
                 }
                 return frameElement;
             }

         }

    </script>

    <div style="position: relative; width: auto; background-repeat: repeat" id="divParms" runat="server">
        <div style="width: 1000px; float: left; position: relative; padding-left: 10px">
               
            <!-- Div ValidityDetails -->

            <div id="divValidityDetails" runat="server" style="clear: left; ">
                <table style="width:100%">
                    <tr>
                        <td style="width: 100px">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Date from" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 180px">
                            <dx:ASPxDateEdit  ID="dtDateFrom" runat="server" DisplayFormatString="dd-MMM-yyyy"
                                 Width="180px"
                                 EditFormatString="dd-MMM-yyyy" ClientInstanceName="dtDateFrom">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <%--<RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>                                                            
                            </dx:ASPxDateEdit>
                        </td>
                        <td>
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear DateFrom #" >  
                                <ClientSideEvents Click="function(s, e) { dtDateFrom.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>

                       <td style="width: 110px; text-align: center;">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server"  Text="To Date" CssClass="lable"></dx:ASPxLabel>
                             </td>                      
                        <td>
                            <dx:ASPxDateEdit ID="dtDateTo" runat="server" DisplayFormatString="dd-MMM-yyyy" EditFormatString="dd-MMM-yyyy" Width="200px" ClientInstanceName="dtDateTo">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                   <%-- <RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>                                                            
                            </dx:ASPxDateEdit>  
                             </td>                      
                        <td>
                            <dx:ASPxButton ID="ASPxButton2" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear DateUpTo">  
                                <ClientSideEvents Click="function(s, e) { dtDateTo.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                       
                        <td style="text-align:center; width: 130px">
                            <dx:ASPxLabel ID="ASPxLabel3"  runat="server" Text="JO#" CssClass="lable"></dx:ASPxLabel>  
                        </td>
                        <td>
                           <dx:ASPxComboBox ID="cmbJobOrderNo" runat="server" ValueField="JobOrderNumber" DataSourceID="JobOrderNoDS" ValueType="System.Int64" Width="100%" 
                                AutoPostBack="false" TextFormatString="{0} - ({2:dd MMM yyyy}) - {1} - {3} - {4}" DropDownStyle="DropDownList" ClientInstanceName="cmbJobOrderNo">
                                <Columns>
                                    <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="100" />
                                    <dx:ListBoxColumn FieldName="LPONumber" Caption="LPO Number" Width="100" />
                                    <dx:ListBoxColumn FieldName="TransactionDate" Caption="Date" Width="65" />
                                    <dx:ListBoxColumn FieldName="CustomersList.CustomerName" Caption="Customer" Width="150" />
                                    <dx:ListBoxColumn FieldName="ProjectsList.ProjectName" Caption="Project" Width="150" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnJobOrderNo" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Job Order #">  
                                <ClientSideEvents Click="function(s, e) { cmbJobOrderNo.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>

                        <td style="text-align:left; width: 130px">
                            <dx:ASPxLabel ID="ASPxLabel7"  runat="server" Text="Sampling Date" CssClass="lable"></dx:ASPxLabel>  
                        </td>
                        <td>
                            <dx:ASPxDateEdit ID="dtSamplingDate" runat="server" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy"
                                 ClientInstanceName="dtSamplingDate"></dx:ASPxDateEdit>
                        </td>
                        <td>
                              <dx:ASPxButton ID="ASPxButton4" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear DateFrom #" >  
                                <ClientSideEvents Click="function(s, e) { dtSamplingDate.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Sample No" CssClass="lable"></dx:ASPxLabel>  
                        </td>
                        <td style="width: 180px">
                            <dx:ASPxTextBox Width="180px" ID="tbSampleNo" runat="server"   ClientInstanceName="tbSampleNo">
                            </dx:ASPxTextBox>
                        </td>
                         <td>
                            <dx:ASPxButton ID="ASPxButton3" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Sample #">  
                                <ClientSideEvents Click="function(s, e) { tbSampleNo.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                         <td style="width: 110px; text-align: center;">
                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Service Name" CssClass="lable"></dx:ASPxLabel>  
                        </td>
                       <td style="width: 200px"">
                            <%-- <dx:ASPxComboBox ID="cmbServiceName" runat="server" ValueField="TestID"  TextField="TestName" DropDownStyle="DropDownList" Width="200px"
                                    DataSourceID="ServiceNameDS" ValueType="System.Int32" ClientInstanceName="cmbServiceName">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                            </dx:ASPxComboBox>--%>
                             <dx:ASPxDropDownEdit ClientInstanceName="checkComboBox" ID="ASPxDropDownEdit1" Width="200px" runat="server" AnimationType="None">
                            <DropDownWindowStyle BackColor="#EDEDED" />
                            <DropDownWindowTemplate>
                                <%--<dx:ASPxListBox Width="100%" ID="listBox" ClientInstanceName="checkListBox" SelectionMode="CheckColumn" ValueType="System.Int32"
                                    runat="server" Height="200" EnableSelectAll="true" DataSourceID="ServiceNameDS" ValueField="TestID" TextField="TestName">
                                    <FilteringSettings ShowSearchUI="true"/>
                                    <Border BorderStyle="None" />
                                    <BorderBottom BorderStyle="Solid" BorderWidth="1px" BorderColor="#DCDCDC" />
                                    <ClientSideEvents SelectedIndexChanged="updateText" Init="updateText" />
                                </dx:ASPxListBox>--%>
            
                    <dx:ASPxGridView ID="gridView"
                         DataSourceID="ServiceNameDS" KeyFieldName="TestID" Width="150px" 
                         ClientInstanceName="gridView" runat="server" AutoGenerateColumns="False">
                        <Columns>
                           <dx:GridViewDataTextColumn FieldName="TestName" Caption="Service Name" Width="150px" VisibleIndex="1" FixedStyle="Left">
                                    <Settings AutoFilterCondition="Contains" />
                                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                              

                                <dx:GridViewCommandColumn VisibleIndex="5" ButtonType="Default" Width="50px" ShowClearFilterButton="true" ShowSelectCheckbox="true">
                                </dx:GridViewCommandColumn>
                        </Columns>
                         <SettingsCommandButton>
                                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                            </SettingsCommandButton>
                            <Settings ShowFilterRow="True" />
                       
                            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True"  ColumnResizeMode="Disabled" />
                    </dx:ASPxGridView>
              
  
                                <table style="width: 100%">
                                    <tr>
                                        <td style="padding: 4px">
                                            <dx:ASPxButton ID="ASPxButton1" AutoPostBack="False" runat="server" Text="Close" style="float: right">
                                                <ClientSideEvents Click="function(s, e){ 
                                                     var selectedItems = gridView.GetSelectedKeysOnPage();
        checkComboBox.SetText(selectedItems.join(', '));
                                                   gridView.ClearFilter();


                                                    checkComboBox.HideDropDown(); }" />
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </DropDownWindowTemplate>
<%--                                                          <ClientSideEvents Init="function(s,e){gridView.Refresh();}" TextChanged="synchronizeListBoxValues" DropDown="synchronizeListBoxValues" />--%>

                        </dx:ASPxDropDownEdit>
                        </td>
                         <td>
                            <dx:ASPxButton ID="btnServiceName" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Service Name">  
                                <ClientSideEvents Click="function(s, e) { checkComboBox.SetText(''); 
gridView.ClearFilter();
                                    gridView.UnselectRowsByKey( gridView.GetSelectedKeysOnPage());
                                   gridView.UnselectAllItemsOnPage();  }" />  
                            </dx:ASPxButton>  
                        </td>
                          <td style="width: 130px; text-align: right;">
                            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Lab Section" CssClass="lable"></dx:ASPxLabel>  
                        </td>
                         <td>
                            <dx:ASPxComboBox ID="cmblabsection" runat="server" ValueField="LabName" TextField="LabName" DropDownStyle="DropDownList" Width="200px"
                                    DataSourceID="LabSectionDS" ValueType="System.String" ClientInstanceName="cmblabsection">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnlabsection" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Job Order #">  
                                <ClientSideEvents Click="function(s, e) { cmblabsection.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                        <td style="width: 130px; text-align: left;">
                            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Site Ref No" CssClass="lable"></dx:ASPxLabel>  
                        </td>
                         <td>
                             <dx:ASPxTextBox ID="txtSiteRefNo" runat="server" ClientInstanceName="txtSiteRefNo"></dx:ASPxTextBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Site Ref No">  
                                <ClientSideEvents Click="function(s, e) { txtSiteRefNo.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                      
                    </tr>
                     <tr>
                        <td style="width: 100px;">
                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="FromReportNo" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 180px">
                            <dx:ASPxTextBox ID="txtFromReportNo" Width="180px"  runat="server" ClientInstanceName="txtFromReportNo">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <%--<RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnFromReportNo" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear From ReportNumber">
                                <ClientSideEvents Click="function(s, e) { txtFromReportNo.SetText(''); }" />
                            </dx:ASPxButton>
                        </td>
                        <td style="width: 110px; text-align:right;">
                            <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="ToReportNo" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 175px">
                            <dx:ASPxTextBox ID="txtToReportNumber" Width="100%"  runat="server" ClientInstanceName="txtToReportNumber">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <%--<RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                         <td>
                            <dx:ASPxButton ID="btnToReportNumber" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear From ReportNumber">
                                <ClientSideEvents Click="function(s, e) { txtToReportNumber.SetText(''); }" />
                            </dx:ASPxButton>
                        </td>

                          <td style="width: 110px; text-align:right;">
                            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Technician" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 175px">
                           <dx:ASPxComboBox ID="cmbTechnician" runat="server" ValueField="EmpID" TextField="EmpName" DropDownStyle="DropDownList" Width="200px"
                                    DataSourceID="EmpListDS" ValueType="System.Int32" ClientInstanceName="cmbTechnician">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                   <%-- <RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                         <td>
                            <dx:ASPxButton ID="btnTechnician" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Technician">
                                <ClientSideEvents Click="function(s, e) { cmbTechnician.SetText(''); }" />
                            </dx:ASPxButton>
                        </td>
                          <td style="width: 110px; text-align:right;">
                            <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="Subcontractor" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 175px" colspan="2">
                         <%--  <dx:ASPxComboBox ID="cmbSubcontractors" runat="server" ValueField="SubContractorID" TextField="SubContractorName" DropDownStyle="DropDownList" Width="200px"
                                    DataSourceID="SubcontractorsListDS" ValueType="System.Int32" ClientInstanceName="cmbSubcontractors">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                            </dx:ASPxComboBox>--%>

                             <dx:ASPxDropDownEdit ClientInstanceName="cmbSubcontractors" ID="cmbSubcontractors" Width="200px" runat="server" AnimationType="None">
                            <DropDownWindowStyle BackColor="#EDEDED" />
                            <DropDownWindowTemplate>
                                <dx:ASPxListBox Width="100%" ID="listBoxcmbSubcontractors" ClientInstanceName="checkListBoxcmbSubcontractors" SelectionMode="CheckColumn" ValueType="System.Int32"
                                    runat="server" Height="200" EnableSelectAll="true" DataSourceID="SubcontractorsListDS" ValueField="SubContractorID" TextField="SubContractorName">
                                    <Border BorderStyle="None" />
                                    <BorderBottom BorderStyle="Solid" BorderWidth="1px" BorderColor="#DCDCDC" />
                                    <ClientSideEvents SelectedIndexChanged="updateTextcmbSubcontractors" Init="updateTextcmbSubcontractors" />
                                </dx:ASPxListBox>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="padding: 4px">
                                            <dx:ASPxButton ID="ASPxButton1" AutoPostBack="False" runat="server" Text="Close" style="float: right">
                                                <ClientSideEvents Click="function(s, e){ cmbSubcontractors.HideDropDown(); }" />
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </DropDownWindowTemplate>
                            <ClientSideEvents TextChanged="synchronizeListBoxValuescmbSubcontractors" DropDown="synchronizeListBoxValuescmbSubcontractors" />
                        </dx:ASPxDropDownEdit>
                        </td>
                              <%--  <td>
                      <dx:ASPxButton ID="btnSubcontractors" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Technician">
                                <ClientSideEvents Click="function(s, e) { cmbSubcontractors.SetText(''); }" />
                            </dx:ASPxButton>
                        </td>--%>
                         </tr>
                    <tr>
                        
                        <td style="width: 180px;">
                            <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="FromRRSNo" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 175px">
                            <dx:ASPxTextBox ID="txtFromRRSNo" Width="100%"  runat="server" ClientInstanceName="txtFromRRSNo">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <%--<RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="ASPxButton6" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear From RSS">
                                <ClientSideEvents Click="function(s, e) { txtFromRRSNo.SetText(''); }" />
                            </dx:ASPxButton>
                        </td>
                        <td style="width: 110px; text-align:right;">
                            <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="ToRSS" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 175px">
                            <dx:ASPxTextBox ID="txtToRRSNo" Width="100%"  runat="server" ClientInstanceName="txtToRRSNo">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <%--<RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                         <td>
                            <dx:ASPxButton ID="ASPxButton7" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear To RSS">
                                <ClientSideEvents Click="function(s, e) { txtToRRSNo.SetText(''); }" />
                            </dx:ASPxButton>
                        </td>
                         <td>
                            <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="SubContracted" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmdSubContracted" runat="server" DropDownStyle="DropDownList" Width="100%"
                                 ValueType="System.String" ClientInstanceName="cmdSubContracted">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                                <Items>
                                                                                                            <dx:ListEditItem Text="" Value="null" Selected="true" />

                                    <dx:ListEditItem Text="Yes" Value="Yes" />
                                                                        <dx:ListEditItem Text="No" Value="No" />
                                                                                                            <dx:ListEditItem Text="All" Value="" />


                                </Items>
                            </dx:ASPxComboBox>
                        </td>
                         <td>
                            <dx:ASPxButton ID="ASPxButton8" runat="server" Text="X"  AutoPostBack="False" ToolTip="Clear Sub Contracted">
                                <ClientSideEvents Click="function(s, e) { cmdSubContracted.SetValue('null'); }" />
                            </dx:ASPxButton>
                        </td>
                        
                          <td style="padding-left:10px">
                            <dx:ASPxButton ID="btnGenerate" runat="server" Style="width: 80px"  OnClick="btnGenerate_Click" ValidationGroup="editForm" Text="Generate"></dx:ASPxButton>
                        </td> 
                    </tr>
                </table>
            </div>
        </div>
    </div>
    
    <dx:ASPxLabel ID="lblError" runat="server" ClientInstanceName="lblError" Text=""></dx:ASPxLabel>
    <dx:ASPxDocumentViewer ID="ReportViewer1" runat="server" BackColor="Transparent" Height="800px"  
        ZoomMode="Percent" ZoomPercent="100" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt" ProcessingMode="Remote" ShowParameterPrompts="False" SettingsSplitter-SidePaneVisible="false" ToolBarItemBorderStyle="Solid">
        <ClientSideEvents Init="init" />
    </dx:ASPxDocumentViewer>
     <asp:ObjectDataSource ID="SubcontractorsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.SubcontractorsListDB"
        DataObjectTypeName="BusinessLayer.SubcontractorsListDB" SelectMethod="GetAll"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="EmpListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.EmployeesListDB"
        DataObjectTypeName="BusinessLayer.EmployeesList" SelectMethod="GetAll"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ServiceNameDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
    SelectMethod="GetAll"  DataObjectTypeName="BusinessLayer.TestsList"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="JobOrderNoDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
    SelectMethod="GetAll"  DataObjectTypeName="BusinessLayer.JobOrderMaster"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="LabSectionDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.LabsListDB"
    SelectMethod="GetAll"></asp:ObjectDataSource>
</asp:Content>
