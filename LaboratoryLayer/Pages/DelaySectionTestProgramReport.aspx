<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="DelaySectionTestProgramReport.aspx.cs" Inherits="LaboratoryLayer.Pages.Reports.DelaySectionTestProgramReport" %>

<%--<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>--%>
<%@ Register Assembly="DevExpress.XtraReports.v16.1.Web, Version=16.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <li class="active" id="menulink"> Delay Section Test Program Report </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Delay Section Test Program Report</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">

    <script type="text/javascript">
        function init(s) {
            var createFrameElement = s.viewer.printHelper.createFrameElement;
            s.viewer.printHelper.createFrameElement = function (name) {
                var frameElement = createFrameElement.call(this, name);
                if (ASPx.Browser.Chrome) {
                    frameElement.addEventListener("load", function (e) {
                        if (frameElement.contentDocument && frameElement.contentDocument.contentType !== "text/html")
                            frameElement.contentWindow.print();
                    });
                }
                return frameElement;
            }
        }
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
    </script>

    <div style="position: relative; width: auto; background-repeat: repeat" id="divParms" runat="server">
        <div style="width: 1000px; float: left; position: relative; padding-left: 10px">
            <div id="divValidityDetails" runat="server" style="clear: left;">
                <table style="width:100%">
                    <tr>
                        <td style="width: 100px;">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Date from" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 175px" colspan="2">
                            <dx:ASPxDateEdit ID="dtDateFrom" Width="100%"  runat="server" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <%--<RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </td>
                        <td style="width: 110px; text-align:right;">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="To" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 175px" colspan="2">
                            <dx:ASPxDateEdit ID="dtDateTo" runat="server" Width="100%"  DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <%-- <RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </td>
                        <td style="width: 100px">
                            <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Project" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmbFKProjectID" runat="server" ValueField="ProjectID" TextField="ProjectName" DropDownStyle="DropDownList" Width="100%"
                                DataSourceID="ProjectsListDS" ValueType="System.String" ClientInstanceName="cmbFKProjectID">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnFkProjectID" runat="server" Text="X"  AutoPostBack="False" ToolTip="Clear Project">
                                <ClientSideEvents Click="function(s, e) { cmbFKProjectID.SetValue(null); }" />
                            </dx:ASPxButton>
                        </td>
                         
                    </tr>
                    <tr>
                         <td style="width: 100px;">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Customer" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td>
                           
                            <dx:ASPxComboBox ID="cmbCustomer" runat="server" ValueField="CustomerID" TextField="CustomerName" Width="200px"
                                    DataSourceID="CustomersListDS" ClientInstanceName="cmbCustomer" ValueType="System.Int32">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                          <td>
                            <dx:ASPxButton ID="btnCustomer" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Customers">
                                <ClientSideEvents Click="function(s, e) { cmbCustomer.SetValue(null); }" />
                            </dx:ASPxButton>
                        </td>
                        
                        <td style="width: 100px; text-align:right;">
                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Service Name" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td  style="width: 200px; text-align:center">
                           <dx:ASPxComboBox ID="cmbServiceName" runat="server" ValueField="TestID" TextField="TestName" DropDownStyle="DropDownList" Width="100%" 
                                DataSourceID="ServiceNameDS" ValueType="System.Int32" ClientInstanceName="cmbServiceName">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                            
                        </td>
                       <td>
                            <dx:ASPxButton ID="btnServiceName" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Service Name">
                                <ClientSideEvents Click="function(s, e) { cmbServiceName.SetValue(null); }" />
                            </dx:ASPxButton>
                        </td>
                         <td style="width: 100px">
                            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Lab Section" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td colspan="2">
                           <%-- <dx:ASPxComboBox ID="cmblabsection" runat="server" ValueField="LabID" TextField="LabName" DropDownStyle="DropDownList" Width="100%"
                                DataSourceID="LabSectionDS" ValueType="System.String" ClientInstanceName="cmblabsection">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                            </dx:ASPxComboBox>--%>
                             <dx:ASPxDropDownEdit ClientInstanceName="checkComboBox" ID="ASPxDropDownEdit1" Width="200px" runat="server" AnimationType="None">
                            <DropDownWindowStyle BackColor="#EDEDED" />
                            <DropDownWindowTemplate>
                                <dx:ASPxListBox Width="100%" ID="listBox" ClientInstanceName="checkListBox" SelectionMode="CheckColumn" ValueType="System.Int32"
                                    runat="server" Height="200" EnableSelectAll="true" DataSourceID="LabSectionDS" ValueField="LabID" TextField="LabName">
                                  <%--  <FilteringSettings ShowSearchUI="true"/>--%>
                                    <Border BorderStyle="None" />
                                    <BorderBottom BorderStyle="Solid" BorderWidth="1px" BorderColor="#DCDCDC" />
                                    <ClientSideEvents SelectedIndexChanged="updateText" Init="updateText" />
                                </dx:ASPxListBox>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="padding: 4px">
                                            <dx:ASPxButton ID="ASPxButton1" AutoPostBack="False" runat="server" Text="Close" style="float: right">
                                                <ClientSideEvents Click="function(s, e){ checkComboBox.HideDropDown(); }" />
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </DropDownWindowTemplate>
                            <ClientSideEvents TextChanged="synchronizeListBoxValues" DropDown="synchronizeListBoxValues" />
                        </dx:ASPxDropDownEdit>
                        </td>
                        <%--<td>
                            <dx:ASPxButton ID="btnlabsection" runat="server" Text="X"  AutoPostBack="False" ToolTip="Clear Lab Section">
                                <ClientSideEvents Click="function(s, e) { cmblabsection.SetValue(null); }" />
                            </dx:ASPxButton>
                        </td>--%>

                        <%--changes here by barkat--%>
                       
                    </tr>
                    <tr>
                        <td style="width: 100px;">
                            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="FromReportNo" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 175px">
                            <dx:ASPxTextBox ID="txtFromReportNo" Width="100%"  runat="server" ClientInstanceName="txtFromReportNo">
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
                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="ToReportNo" CssClass="lable"></dx:ASPxLabel>
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
                         <td style="width: 20px"></td>
                        <td>
                            <dx:ASPxButton ID="btnGenerate" runat="server"  Width="100%" OnClick="btnGenerate_Click" ValidationGroup="editForm" Text="Generate"></dx:ASPxButton>
                        </td>

                       
                    </tr>
                    
                </table>
            </div>
        </div>
    </div>

    <dx:ASPxLabel ID="lblError" runat="server" ClientInstanceName="lblError" Text=""></dx:ASPxLabel>
    <dx:ASPxDocumentViewer ID="ReportViewer1" runat="server" BackColor="Transparent" 
        
        Height="800px" Width="100%" ZoomMode="Percent" 
        ZoomPercent="100" Font-Names="Verdana" Font-Size="8pt" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ProcessingMode="Remote" 
        ShowParameterPrompts="False" 
        SettingsSplitter-SidePaneVisible="false" ToolBarItemBorderStyle="Solid">
        <ClientSideEvents Init="init" />
    </dx:ASPxDocumentViewer>

    <asp:ObjectDataSource ID="AccreditationStatusListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.AccreditionListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.AccreditionList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ServiceNameDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.TestsList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="JobOrderNoDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.JobOrderMaster"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="LabSectionDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.LabsListDB"
    SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.LabsList"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="JobOrderMasterDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveNonExpiredJobOrder"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MaterialsTypesDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsTypesDB"
    SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsTypes"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="CustomersListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.CustomersListDB" SelectMethod="GetAll"></asp:ObjectDataSource>
  <asp:ObjectDataSource ID="ProjectsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ProjectsListDB"
        DataObjectTypeName="BusinessLayer.ProjectsList" SelectMethod="GetActiveProjectList"></asp:ObjectDataSource>

  <asp:ObjectDataSource ID="ReportDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ValidityListDB" SelectMethod="GetAll"></asp:ObjectDataSource>


</asp:Content>
