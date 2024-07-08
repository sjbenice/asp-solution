<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ActiveJobOrdersReport.aspx.cs" Inherits="LaboratoryLayer.Pages.Reports.ActiveJobOrdersReport" %>
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
            <li class="active" id="menulink">Active Job Orders</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Active Job Orders</h1>
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
        <div style="width: 1000px; float: left; position: relative; padding-left: 10px">
            <div id="divValidityDetails" runat="server" style="clear: left; ">
                 <table>
                    <tr>
                        
                         <td style="width: 20px; text-align: right;">
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="JO#" CssClass="lable"></dx:ASPxLabel>  
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmbJobOrderNo" runat="server" ValueField="JobOrderNumber" TextField="JobOrderNumber" DropDownStyle="DropDownList" Width="170"
                                    DataSourceID="JobOrderNoDS" ValueType="System.String" ClientInstanceName="cmbJobOrderNo">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                            </dx:ASPxComboBox> </td>
                        <td>
                            <dx:ASPxButton ID="btnJobOrderNo" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Job Order #" Width="20px">  
                                <ClientSideEvents Click="function(s, e) { cmbJobOrderNo.SetValue(null); }" />  
                            </dx:ASPxButton>
                        </td>
                        <td style="width: 130px; text-align: right;">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="JO Date" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 200px">
                            <dx:ASPxDateEdit ID="dtTransactionDate" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                   <%-- <RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>                                                            
                            </dx:ASPxDateEdit>
                         </td>                       

                        <td style="width: 50px; text-align: right;">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Company" CssClass="lable"></dx:ASPxLabel>  
                              <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="" CssClass="lable" Visible="False"></dx:ASPxLabel> 
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmbCustomer" runat="server" ValueField="CustomerID" TextField="CustomerName" Width="200px"
                                    DataSourceID="CustomersListDS" ClientInstanceName="cmbCustomer" ValueType="System.Int32">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                              
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnClearCustomer" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Customer">  
                                <ClientSideEvents Click="function(s, e) { cmbCustomer.SetValue(null); }" />  
                            </dx:ASPxButton>  
                        </td>
                      
                    </tr>
                    <tr>
                        <td style="width: 20px">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="LastServiceReceivedDate" CssClass="lable"></dx:ASPxLabel>  
                        </td>
                        <td style="width: 200px">
                            <dx:ASPxDateEdit ID="dtReceiveDate" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                  <%--  <RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>                                                            
                            </dx:ASPxDateEdit>
                            </td> 
                          <td>
                        </td> 
                          <td style="width: 20px">
                            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="LastInvoicePaidDate" CssClass="lable"></dx:ASPxLabel>  
                        </td>
                        <td style="width: 200px">
                            <dx:ASPxDateEdit ID="dtPaymentDate" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                  <%--  <RequiredField IsRequired="true" ErrorText="!" />--%>
                                </ValidationSettings>                                                            
                            </dx:ASPxDateEdit>
                        </td> 
                        
                        <td style="width: 200px">
                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Last Invoiced Paid Amount" CssClass="lable" Width="170px"></dx:ASPxLabel>  
                     
                        </td>
                          <td style="width: 10px"> <dx:ASPxTextBox ID="tbPaymentAmount" runat="server">
                            </dx:ASPxTextBox></td>
                        <td>
                            <dx:ASPxButton ID="btnGenerate" runat="server" Style="width: 80px"  OnClick="btnGenerate_Click" ValidationGroup="editForm" Text="Generate"></dx:ASPxButton>
                        </td> 
                    </tr>
                     </table>
            </div>
        </div>
    </div>
    <dx:ASPxLabel ID="lblError" runat="server" ClientInstanceName="lblError" Text=""></dx:ASPxLabel>
    <dx:ASPxDocumentViewer ID="ReportViewer1" runat="server" BackColor="Transparent" Height="800px" Width="100%" ZoomMode="Percent" ZoomPercent="100" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ProcessingMode="Remote" ShowParameterPrompts="False" SettingsSplitter-SidePaneVisible="false" ToolBarItemBorderStyle="Solid">
        <ClientSideEvents Init="init" />
    </dx:ASPxDocumentViewer>
      <asp:ObjectDataSource ID="JobOrderNoDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
    SelectMethod="GetAll"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="CustomersListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.CustomersListDB" SelectMethod="GetAll"></asp:ObjectDataSource>

</asp:Content>
