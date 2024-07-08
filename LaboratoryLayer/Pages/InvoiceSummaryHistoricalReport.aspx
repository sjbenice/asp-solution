<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="InvoiceSummaryHistoricalReport.aspx.cs"  Inherits="LaboratoryLayer.Pages.InvoiceSummaryHistoricalReport" %>
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
            <li><a id="menu1" href="#">Setup</a></li>
            <li class="active" id="menulink">Invoice Summary</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Invoice Summary</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
  
    <div style="position: relative; width: auto; background-repeat: repeat" id="divParms" runat="server">
            <div style="width: 1000px; float: left; position: relative; padding-left: 10px">
               
                <!-- Div ValidityDetails -->

                <div runat="server" style="clear: left; ">
                    <table>
                        <tr>
                           
                          
                            <td style="width: 120px">
                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="List Name" CssClass="lable"></dx:ASPxLabel>
                            </td>
                           <td>
                               <dx:ASPxTextBox ID="txtInvoiceNo" runat="server"></dx:ASPxTextBox>
                           </td>
                             <td style="width: 10px"></td>
                            <td>
                <dx:ASPxButton ID="btnGenerate" runat="server" Style="width: 80px"  OnClick="btnGenerate_Click" ValidationGroup="editForm" Text="Generate"></dx:ASPxButton>

                            </td> 
                        </tr>
                        </table>
                </div>
            </div>
        </div>
    <div style="width: 100%; margin-bottom: 10px ;height:20px">
        </div>
     <dx:ASPxLabel ID="lblError" runat="server" ClientInstanceName="lblError" Text=""></dx:ASPxLabel>
        
            <dx:ASPxDocumentViewer ID="ReportViewer1" runat="server"  BackColor="Transparent" Height="800px" Width="100%" ZoomMode="Percent" ZoomPercent="100" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ProcessingMode="Remote" ShowParameterPrompts="False" SettingsSplitter-SidePaneVisible="false" ToolBarItemBorderStyle="Solid" ReportTypeName="LaboratoryLayer.Reports.InvoiceSummaryReport" Theme="Default">
                <settingsreportviewer printusingadobeplugin="False" />
<SettingsSplitter SidePaneVisible="False"></SettingsSplitter>
            </dx:ASPxDocumentViewer>
       
</asp:Content>
