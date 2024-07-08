﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ServiceVSMaterialsReport.aspx.cs" Inherits="LaboratoryLayer.Pages.ServiceVSMaterialsReport" %>
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
            <li class="active" id="menulink">Service VS Materials</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Service VS Materials</h1>
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


        // Barkat: Multiselection enabled for Lab Section and Service Section
        var textSeparator = ",";
        var selectedItemsText = "";
        var selectedItemsIds = "";

        function updateText1() {
            var selectedItems = checkListBoxLab.GetSelectedItems();
            selectedItemsText = getSelectedItemsText(selectedItems);
            selectedItemsIds = getSelectedItemsIds(selectedItems);
            checkComboBox.SetText(selectedItemsText);
        }
        function updateText2() {
            var selectedItems = checkListBoxService.GetSelectedItems();
            selectedItemsText = getSelectedItemsText(selectedItems);
            selectedItemsIds = getSelectedItemsIds(selectedItems);
            checkComboBox1.SetText(selectedItemsText);
        }

        function synchronizeListBoxValues(dropDown, args) {
            checkListBox.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = getValuesByTexts(texts);
            checkListBox.SelectValues(values);
            updateText1(); // Update selected text and IDs
        }
        function synchronizeListBoxValuesService(dropDown, args) {
            checkListBox.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = getValuesByTexts(texts);
            checkListBox.SelectValues(values);
            updateText2(); // Update selected text and IDs
        }

        function getSelectedItemsText(items) {
            var texts = [];
            for (var i = 0; i < items.length; i++)
                texts.push(items[i].text);
            return texts.join(textSeparator);
        }

        function getSelectedItemsIds(items) {
            var ids = [];
            for (var i = 0; i < items.length; i++)
                ids.push(items[i].value);
            return ids;
        }

    </script>

    <div style="position: relative; width: auto; background-repeat: repeat" id="divParms" runat="server">
        <div style="width: 1000px; float: left; position: relative; padding-left: 10px">

            <!-- Div ValidityDetails -->

            <div id="divValidityDetails" runat="server" style="clear: left;">
                <table>
                    <tr>
                     

                          <td style="width: 120px">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Service Name" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 200px">
                            <dx:ASPxDropDownEdit ClientInstanceName="checkComboBox" ID="cmdServiceName" Width="200px" runat="server" AnimationType="None">
                                <DropDownWindowStyle BackColor="#EDEDED" />
                                <DropDownWindowTemplate>
                                    <dx:ASPxListBox Width="100%" ID="listBox1" ClientInstanceName="checkListBoxLab" SelectionMode="CheckColumn"
                                        ValueType="System.Int32" runat="server" Height="200" EnableSelectAll="true"
                                        DataSourceID="LabSectionListDB" ValueField="TestID" TextField="TestName">
                                        <Border BorderStyle="None" />
                                        <BorderBottom BorderStyle="Solid" BorderWidth="1px" BorderColor="#DCDCDC" />
                                        <ClientSideEvents SelectedIndexChanged="updateText1" Init="updateText1" />
                                    </dx:ASPxListBox>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="padding: 4px">
                                                <dx:ASPxButton ID="ASPxButton1" AutoPostBack="False" runat="server" Text="Close" Style="float: right">
                                                    <ClientSideEvents Click="function(s, e){ checkComboBox.HideDropDown(); }" />
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </DropDownWindowTemplate>
                                <ClientSideEvents TextChanged="synchronizeListBoxValues" DropDown="synchronizeListBoxValues" />
                            </dx:ASPxDropDownEdit>
                        </td>

                        <td style="width: 30px"></td>

                        <td style="width: 120px">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Material Name" CssClass="lable"></dx:ASPxLabel>
                        </td>
                        <td style="width: 200px">
                            <dx:ASPxDropDownEdit ClientInstanceName="checkComboBox1" ID="cmbServiceSection" Width="200px" runat="server" AnimationType="None">
                                <DropDownWindowStyle BackColor="#EDEDED" />
                                <DropDownWindowTemplate>
                                    <dx:ASPxListBox Width="100%" ID="listBox2" ClientInstanceName="checkListBoxService" SelectionMode="CheckColumn"
                                        ValueType="System.Int32" runat="server" Height="200" EnableSelectAll="true"
                                        DataSourceID="ServiceSectionListDB" ValueField="MaterialTypeID" TextField="MaterialName">
                                        <Border BorderStyle="None" />
                                        <BorderBottom BorderStyle="Solid" BorderWidth="1px" BorderColor="#DCDCDC" />
                                        <ClientSideEvents SelectedIndexChanged="updateText2" Init="updateText2" />
                                    </dx:ASPxListBox>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="padding: 4px">
                                                <dx:ASPxButton ID="ASPxButton1" AutoPostBack="False" runat="server" Text="Close" Style="float: right">
                                                    <ClientSideEvents Click="function(s, e){ checkComboBox1.HideDropDown(); }" />
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </DropDownWindowTemplate>
                                <ClientSideEvents TextChanged="synchronizeListBoxValuesService" DropDown="synchronizeListBoxValuesService" />
                            </dx:ASPxDropDownEdit>
                        </td>
                  <%--      <td>
                            <dx:ASPxButton ID="ASPxButton3" runat="server" Text="X" AutoPostBack="False" ToolTip="Clear Service Section">
                                <ClientSideEvents Click="function(s, e) { cmbServiceSection.SetValue(null); }" />
                            </dx:ASPxButton>
                        </td>--%>


                      
                        <td style="width: 10px"></td>

                        <td>
                            <dx:ASPxButton ID="btnGenerate" runat="server" Style="width: 80px" OnClick="btnGenerate_Click" ValidationGroup="editForm" Text="Generate"></dx:ASPxButton>
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

    <asp:ObjectDataSource ID="LabSectionListDB" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.TestsListDB"
    SelectMethod="GetAll"  DataObjectTypeName="BusinessLayer.TestsList"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ServiceSectionListDB" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.MaterialsTypesDB"
        SelectMethod="GetAll" DataObjectTypeName="BusinessLayer.MaterialsTypes"></asp:ObjectDataSource>
</asp:Content>
