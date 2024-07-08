<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RSSReportVersion.aspx.cs" Inherits="LaboratoryLayer.Pages.RSSReportVersion" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
        <dx:ASPxGridView ID="ASPxGridViewPopup" runat="server" ClientInstanceName="gridViewPopup" Width="450" >
            <Columns>
                <dx:GridViewDataHyperLinkColumn FieldName="HyperlinkColumnName" Caption="Recipt Number" VisibleIndex="0"  Width="100%" >
                    <DataItemTemplate>
                        <dx:ASPxHyperLink ID="hyperlink"  Target="_blank"  runat="server" Text='<%# Eval("RSSNumber") %>' NavigateUrl='<%# Eval("HyperlinkColumnName") %>'></dx:ASPxHyperLink>
                    </DataItemTemplate>
                </dx:GridViewDataHyperLinkColumn>
            </Columns>
        </dx:ASPxGridView>
        </div>
    </div>
   </form>
</body>
</html>
