<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ServicesReceivedVsQARReport.aspx.cs" Inherits="LaboratoryLayer.Pages.Reports.ServicesReceivedVsQARReport" %>

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
            <li class="active" id="menulink">Services Received Vs QAR</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Services Received Vs QAR</h1>
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
                        <td style="width: 20px; text-align:center;">
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="JO#" CssClass="lable"></dx:ASPxLabel>
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
                         
                    </tr>
                    <tr>
                         <td style="width: 100px;">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Service Sector" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmbFKMaterialTypeID" runat="server" Width="100%" ValueField="MaterialTypeID" TextField="MaterialName"
                                    DataSourceID="MaterialsTypesDS" AutoPostBack="false" ValueType="System.Int32"  ClientInstanceName="cmbFKMaterialTypeID">
                                </dx:ASPxComboBox>
                        </td>
                          <td>
                            <dx:ASPxButton ID="btnFKMaterialTypeID" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Service Sector">
                                <ClientSideEvents Click="function(s, e) { cmbFKMaterialTypeID.SetValue(null); }" />
                            </dx:ASPxButton>
                        </td>
                        <td>
                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Accreditation Status" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmbAccreditationStatus" runat="server"  ValueField="AccreditionID" TextField="AccreditionName" 
                                DropDownStyle="DropDownList" Width="100%"
                                DataSourceID="AccreditationStatusListDS" ValueType="System.Int32" ClientInstanceName="cmbAccreditationStatus">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <%-- <RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnAccreditationStatus" Width="100%"  runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Accreditation Status">
                                <ClientSideEvents Click="function(s, e) { cmbAccreditationStatus.SetValue(null); }" />
                            </dx:ASPxButton>
                        </td>
                        <td style="width: 100px">
                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Service Name" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 200px; text-align:center">
                            <dx:ASPxComboBox ID="cmbServiceName" runat="server" ValueField="TestID" TextField="TestName" DropDownStyle="DropDownList" Width="100%" 
                                DataSourceID="ServiceNameDS" ValueType="System.Int32" ClientInstanceName="cmbServiceName">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <%-- <RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnServiceName" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Service Name">
                                <ClientSideEvents Click="function(s, e) { cmbServiceName.SetValue(null); }" />
                            </dx:ASPxButton>
                        </td>


                        <%--changes here by barkat--%>
                       
                    </tr>
                    <tr>
                         <td style="width: 100px">
                            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Lab Section" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmblabsection" runat="server" ValueField="LabID" TextField="LabName" DropDownStyle="DropDownList" Width="100%"
                                DataSourceID="LabSectionDS" ValueType="System.String" ClientInstanceName="cmblabsection">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnlabsection" runat="server" Text="X"  AutoPostBack="False" ToolTip="Clear Lab Section">
                                <ClientSideEvents Click="function(s, e) { cmblabsection.SetValue(null); }" />
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
    <dx:ASPxDocumentViewer ID="ReportViewer1" runat="server" BackColor="Transparent" Height="800px" Width="100%"
         ZoomMode="Percent" ZoomPercent="100" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana"
         WaitMessageFont-Size="14pt" ProcessingMode="Remote" ShowParameterPrompts="False" SettingsSplitter-SidePaneVisible="false" ToolBarItemBorderStyle="Solid">
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
</asp:Content>
