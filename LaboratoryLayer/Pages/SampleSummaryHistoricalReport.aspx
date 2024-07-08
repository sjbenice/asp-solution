<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="SampleSummaryHistoricalReport.aspx.cs" Inherits="LaboratoryLayer.Pages.SampleSummaryHistoricalReport" %>
<%@ Register Assembly="DevExpress.XtraReports.v16.1.Web, Version=16.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .lable {
            text-align: center;
        }
        .auto-style1 {
            width: 27px;
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
        <div style="width: auto; float: left; position: relative; padding-left: 10px">
               
            <!-- Div ValidityDetails -->

            <div id="divValidityDetails" runat="server" style="clear: left; ">
             
    <table border="1" style="border: thin solid #000000; background-color: #F3F3F3;">
                    <tr>
                        <td colspan="4" style="text-align:center">
                            Sample No<td style="text-align:center; " colspan="4">
                            Sample Received Date</td>
                       
                        <td style="text-align:center; " colspan="4">
                            Sample Entered Date</td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            From</td><td>
                                &nbsp;</td>
                        <td  style="text-align:center; width: 130px">
                            To</td>                      
                        <td>
                            &nbsp;</td>
                       
                        <td style="text-align:center; width: 130px; font-size: small;">
                            From</td>
                       
                        <td style="text-align:center; " class="auto-style1">
                            &nbsp;</td>
                        <td  style="text-align:center; width: 130px">
                            To</td>
                        <td>
                            &nbsp;</td>
                        <td style="text-align:center; width: 130px">
                            From</td>
                        <td>
                            &nbsp;</td>
                        <td style="text-align:center; width: 130px">
                            To</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            <dx:ASPxTextBox ID="tbSampleNoF" runat="server" Width="100%"  ClientInstanceName="tbSampleNoF">
                            </dx:ASPxTextBox>
                            <td>
                            <dx:ASPxButton ID="ASPxButton3" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Sample #">  
                                <ClientSideEvents Click="function(s, e) { tbSampleNoF.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="tbSampleNoT" runat="server" Width="100%"  ClientInstanceName="tbSampleNoT">
                            </dx:ASPxTextBox>
                        </td>                      
                        <td>
                            <dx:ASPxButton ID="btnServiceName" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Sample">  
                                <ClientSideEvents Click="function(s, e) { tbSampleNoT.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                       
                        <td style="text-align:center; width: 130px">
                            <dx:ASPxDateEdit Width="150px" ID="dtDateFrom" runat="server" DisplayFormatString="dd-MMM-yyyy"  EditFormatString="dd-MMM-yyyy" ClientInstanceName="dtDateFrom">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <%--<RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>                                                            
                            </dx:ASPxDateEdit>
                            </td>
                       
                        <td style="text-align:center; " class="auto-style1">
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear DateFrom #" >  
                                <ClientSideEvents Click="function(s, e) { dtDateFrom.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                        <td style="text-align:center; width: 130px">
                            <dx:ASPxDateEdit ID="dtDateTo" runat="server" DisplayFormatString="dd-MMM-yyyy" EditFormatString="dd-MMM-yyyy" Width="150" ClientInstanceName="dtDateTo">
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
                        <td>
                            <dx:ASPxDateEdit Width="150px" ID="dtDateFrom0" runat="server" DisplayFormatString="dd-MMM-yyyy" EditFormatString="dd-MMM-yyyy" ClientInstanceName="dtDateFrom0">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <%--<RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>                                                            
                            </dx:ASPxDateEdit>
                            </td>
                        <td>
                            <dx:ASPxButton ID="btnFrombtn" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Date">  
                                <ClientSideEvents Click="function(s, e) { dtDateFrom0.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                        <td>
                            <dx:ASPxDateEdit Width="130px" ID="dtTo0" runat="server" DisplayFormatString="dd-MMM-yyyy" EditFormatString="dd-MMM-yyyy" ClientInstanceName="dtTo0">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <%--<RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>                                                            
                            </dx:ASPxDateEdit>
                            </td>
                        <td>
                            <dx:ASPxButton ID="btnDateTo" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Job Order #">  
                                <ClientSideEvents Click="function(s, e) { dtTo0.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 180px">
                            Contractor Name <td>
                            &nbsp;</td>
                        </td>
                        <td>
                            Project Name</td>                      
                        <td>
                            &nbsp;</td>
                       
                        <td style="text-align:center; width: 130px">
                            &nbsp;</td>
                       
                        <td style="text-align:center; " class="auto-style1">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            <dx:ASPxComboBox ID="cmbContractorName" runat="server" ValueField="Creditor Name" TextField="Creditor Name" DropDownStyle="DropDownList" Width="100%"
                                    DataSourceID="ContractorNameDS" ValueType="System.String" ClientInstanceName="cmbContractorName">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                         <td>
                            <dx:ASPxButton ID="btnContractorName" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Job Order #">  
                                <ClientSideEvents Click="function(s, e) { cmbContractorName.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                       <td style="width: 200px">
                            <dx:ASPxComboBox ID="cmbproject" runat="server" ValueField="Project name" TextField="Project name" DropDownStyle="DropDownList" Width="100%"
                                    DataSourceID="ProjectDS" ValueType="System.String" ClientInstanceName="cmbproject">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                         <td>
                            <dx:ASPxButton ID="btnJcmbproject" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Project Name">  
                                <ClientSideEvents Click="function(s, e) { cmbproject.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                          <td style="width: 130px; text-align: center;">
                              &nbsp;</td>
                          <td style="text-align: center;" class="auto-style1">
                              &nbsp;</td>
                         <td>
                             &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <dx:ASPxButton ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" Style="width: 80px" Text="Generate" ValidationGroup="editForm">
                            </dx:ASPxButton>
                        </td>
                        <td>
                            &nbsp;</td>
                       
                    </tr>
                </table>
   
            </div>
        </div>
    </div>   
    <dx:ASPxLabel ID="lblError" runat="server" ClientInstanceName="lblError" Text="" Visible ="false"></dx:ASPxLabel>
    <dx:ASPxDocumentViewer ID="ReportViewer1" Visible="false" runat="server" BackColor="Transparent" Height="800px" Width="100%" ZoomMode="Percent" ZoomPercent="100" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ProcessingMode="Remote" ShowParameterPrompts="False" SettingsSplitter-SidePaneVisible="false" ToolBarItemBorderStyle="Solid">
<SettingsSplitter SidePaneVisible="False"></SettingsSplitter>
       
        <ClientSideEvents Init="init" />
    </dx:ASPxDocumentViewer>
         
     <asp:SqlDataSource ID="ContractorNameDS" runat="server" ConnectionString="<%$ ConnectionStrings:PRODDBConnectionString %>" SelectCommand="SELECT [Creditor Name] FROM Creditor_table GROUP BY [Creditor Name] ORDER BY [Creditor Name]"></asp:SqlDataSource>
     <asp:SqlDataSource ID="ProjectDS" runat="server" ConnectionString="<%$ ConnectionStrings:PRODDBConnectionString %>" SelectCommand="SELECT [Project name] FROM Projects_table GROUP BY [Project name] ORDER BY [Project name]"></asp:SqlDataSource>
   
</asp:Content>
