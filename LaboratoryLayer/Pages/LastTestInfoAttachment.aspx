<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LastTestInfoAttachment.aspx.cs" Inherits="LaboratoryLayer.Pages.LastTestInfoAttachment" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" AsyncPostBackTimeout="300" runat="server"></asp:ScriptManager>

        <div>
            <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

        </div>

        <div>
            <div>
                <dx:ASPxLabel ID="lblTransID" runat="server" Text="0" Visible="false"></dx:ASPxLabel>
                <dx:ASPxLabel ID="lblTransTypeID" runat="server" Text="0" Visible="false"></dx:ASPxLabel>
                <dx:ASPxLabel ID="lblMasterId" runat="server" Text="0" ClientVisible="false" ClientInstanceName="lblMasterId"></dx:ASPxLabel>

                <div>
                    <div id="divattachfile" style="width: 100%; height: inherit" runat="server">
                        
                        <div class="table" style="padding-left: 10px; padding-right: 10px; padding-top: 10px">
                            <div class="divrow">
                                <dx:ASPxRoundPanel ID="FilContents" ClientInstanceName="gridpanel" runat="server" Width="800" Height="180" HeaderText="Attached Files">
                                    <PanelCollection>
                                        <dx:PanelContent>
                                            <dx:ASPxGridView ID="gdvfiles" ClientInstanceName="gdvfiles" runat="server" DataSourceID="TransactionAttachmentsDS" KeyFieldName="FileID" Width="800" OnCustomCallback="gdvfiles_CustomCallback" OnRowCommand="gdvfiles_RowCommand">
                                                <Columns>
                                                    <dx:GridViewDataHyperLinkColumn FieldName="FileName" Caption="File" Width="500">
                                                        <DataItemTemplate>
                                                            <a target='blank' style="display: block; text-wrap: avoid; width: 100%" onclick='return ShowScreenshotWindow(event, this);'><%#Eval("FileName") %></a>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataHyperLinkColumn>
                                                    <dx:GridViewDataTextColumn FieldName="FileSize" Name="filesize" Caption="Size" Width="100">
                                                        <Settings AutoFilterCondition="Contains" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataColumn Name="Edit" Width="50">
                                                        <DataItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>
                                                                    <dx:ASPxButton ID="BtnEdit" runat="server" Cursor="pointer" RenderMode="Link" ToolTip="<%$ Resources:GlobalResource, EditFormNew %>" EnableTheming="false" EnableViewState="false" CommandName="download" FileName='<%#Eval("FileName") %>' CommandArgument='<%#Eval("FileID") %>'>
                                                                        <Image AlternateText="<%$ Resources:GlobalResource, EditFormUpdate %>" ToolTip="download" Url="../images/download4.jpg"></Image>
                                                                    </dx:ASPxButton>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="BtnEdit" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                </Columns>
                                                <SettingsCommandButton>
                                                    <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                                                    <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
                                                    <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />
                                                </SettingsCommandButton>
                                                <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="true" />
                                                <SettingsPager PageSize="5" Mode="ShowPager"></SettingsPager>
                                                <ClientSideEvents BeginCallback="function(s,e){FilesGridEdited=true;}" />
                                            </dx:ASPxGridView>
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxRoundPanel>
                            </div>
                        </div>
                    </div>

                </div>


            </div>
        </div>

        <asp:ObjectDataSource ID="TransactionAttachmentsDS" runat="server"
            OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAttachmentsWithNew" TypeName="BusinessLayer.Pages.AttachedFilesDB"
            ConflictDetection="CompareAllValues"
            DataObjectTypeName="BusinessLayer.AttachedFiles">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblTransID" DefaultValue="0" Name="transID" PropertyName="Text" Type="Int64" />
                <asp:ControlParameter ControlID="lblTransTypeID" PropertyName="Text" DefaultValue="55555" Name="transTypeID" Type="Int32"></asp:ControlParameter>
            </SelectParameters>
        </asp:ObjectDataSource>

    </form>
</body>
</html>
