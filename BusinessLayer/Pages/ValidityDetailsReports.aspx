﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ValidityDetailsReports.aspx.cs" Inherits="LaboratoryLayer.Pages.ValidityDetailsReports" %>
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
            <li class="active" id="menulink">Validity List Details Reports</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Validity List Details Reports</h1>
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
            
            <!-- Div ValidityDetails -->
            
            <div id="divValidityDetails" runat="server" style="clear: left; ">
                <table>
                    <tr>


                        <td style="width: 120px">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="List Name" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 250px">
                            <dx:ASPxComboBox ID="cmbValidityName" runat="server" ValueField="ValidityID" TextField="ValidityName" DropDownStyle="DropDownList" Width="250"
                                DataSourceID="ValidityListDS" ValueType="System.Int32" ClientInstanceName="cmbValidityName">
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <RequiredField IsRequired="true" ErrorText="!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                       <%-- <td>
                            <dx:ASPxButton ID="btnListName" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear List Name">
                                <ClientSideEvents Click="function(s, e) { cmbValidityName.SetValue(null); }" />
                            </dx:ASPxButton>
                        </td>--%>
                        <td style="width: 10px"></td>
                        <td style="width: 120px">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Validity Status" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 200px">
                            <dx:ASPxComboBox ID="cmbStatus" runat="server" ValueType="System.String" DisplayFormatString="{0}" ClientInstanceName="cmbStatus"
                                CssClass="textbox" AutoGenerateColumns="False" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains" ClientEnabled="true"  EnableCallbackMode="true" Width="200">
                                <Items>
                                    <dx:ListEditItem  Text="Valid" Value="Valid" />
                                    <dx:ListEditItem Text="Expired" Value="Expired"/>
                                    <dx:ListEditItem Text="near to expire" Value="Late"/>
                                    <dx:ListEditItem Text="Not In Used" Value="NotInUsed"/>

                                </Items>
                                <ValidationSettings ValidateOnLeave="true" ValidationGroup="editForm" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                    <RequiredField IsRequired="false" ErrorText="!" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnValidityStatus" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Validity Status">
                                <ClientSideEvents Click="function(s, e) { cmbStatus.SetValue(null); }" />
                            </dx:ASPxButton>
                        </td>
                           <td style="width: 10px"></td>
                        <td>
                            <dx:ASPxCheckBox ID="ckNotInUsedEquipment" runat="server" Text="Include Not In Used Equipment" AutoPostBack="False">
                            </dx:ASPxCheckBox>
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

    <%--  <dx:ASPxDocumentViewer ID="ReportViewer12" runat="server" BackColor="Transparent" Height="800px" Width="100%" ZoomMode="Percent" ZoomPercent="100" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ProcessingMode="Remote" ShowParameterPrompts="False" ToolBarItemBorderStyle="Solid" >
            </dx:ASPxDocumentViewer>--%>
    <dx:ASPxDocumentViewer ID="ReportViewer1" runat="server" BackColor="Transparent" Height="800px" Width="100%" ZoomMode="Percent" ZoomPercent="100" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ProcessingMode="Remote" ShowParameterPrompts="False" SettingsSplitter-SidePaneVisible="false" ToolBarItemBorderStyle="Solid">
        <ClientSideEvents Init="init" />
    </dx:ASPxDocumentViewer>


    <asp:ObjectDataSource ID="ValidityListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ValidityListDB"
        SelectMethod="GetAll"  DataObjectTypeName="BusinessLayer.ValidityList"></asp:ObjectDataSource>
</asp:Content>
