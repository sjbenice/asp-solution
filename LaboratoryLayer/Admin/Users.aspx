<%@ Page Title="Users" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="LaboratoryLayer.Admin.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PagePath" runat="server">
    <div class="breadcrumbs" id="breadcrumbs">
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }

                var FilesGridEdited = false;

                function onFileUploadComplete(s, e) {
                    if (e.callbackData) {
                        gdvfiles.PerformCallback();
                    }
                }
        </script>
        <ul class="breadcrumb" runat="server" id="ultitle">
            <li>
                <i class="ace-icon fa fa-home home-icon"></i>
                <a href="../Default.aspx">Home</a>
            </li>

            <li><a id="menu1" href="#">Setup</a></li>
            <%--          <li><a id="menu2" href="#">General</a></li>--%>
            <li class="active" id="menulink">User Data</li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>User Data</h1>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="btn-toolbar">
        <table>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="width: 100%; margin-top: 10px">
                        <tr>
                            <td colspan="6" style="height: 15px">
                                <table cellpadding="0" cellspacing="0" height="30">
                                    <tr>
                                        <td>
                                            <div style="margin: 0 10px 0 0; width: 100px">
                                                <dx:ASPxLabel ID="lblUserId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>

                                                <dx:ASPxButton ID="btnSave" ValidationGroup="savegrp" CausesValidation="true" CssClass="btn btn-primary" Style="width: 80px" runat="server" OnClick="btnSave_Click" Text="Save"></dx:ASPxButton>
                                            </div>
                                        </td>
                                        <td class="Btn-sep"></td>
                                        <td>
                                            <div style="margin: 0 10px; width: 100px">

                                                <dx:ASPxButton ID="btnCancel" CausesValidation="false" runat="server" Style="width: 80px" CssClass="btn btn-default" OnClick="btnCancel_Click" Text="Cancel"></dx:ASPxButton>
                                            </div>
                                        </td>

                                    </tr>
                                </table>
                            </td>

                            <td rowspan="3"></td>
                        </tr>

                        <tr>
                            <td colspan="6" class="Alert" style="margin-top: 5px;">
                                <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError" ForeColor="Red"></dx:ASPxLabel>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="6">
                                <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" RenderMode="Table" ValidationGroup=""></dx:ASPxValidationSummary>
                            </td>
                        </tr>

                    </table>
                </td>
            </tr>
        </table>

        <div style="height: 10px;"></div>

        <table style="width: 100%;">
            <tr>

                <td style="vertical-align: top;">
                    <table>

                        <tr>
                            <td colspan="6" style="height: 7px"></td>
                        </tr>
                        <tr>

                            <td style="width: 120px;">
                                <dx:ASPxLabel ID="lblDate" runat="server" Text="User Name" meta:resourcekey="LblDate"></dx:ASPxLabel>
                            </td>

                            <td style="width: 250px;">
                                <dx:ASPxTextBox ID="txtCode" MaxLength="20" Width="150" runat="server" Height="21" CssClass="textbox">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="true" ErrorText="Enter Code" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 30px;"></td>
                            <td style="width: 100px"></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="6" style="height: 7px"></td>
                        </tr>
                        <tr>
                            <td style="width: 120px;">
                                <dx:ASPxLabel ID="lblNotes" runat="server" Text="English Name" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                            </td>
                            <td style="width: 250px;">
                                <dx:ASPxTextBox ID="txtEnglishName" MaxLength="80" Width="250px" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="true" ErrorText="Enter English Name" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 30px;"></td>
                            <td style="width: 100px">
                                <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Arabic Name" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                            </td>
                            <td style="width: 280px;">
                                <dx:ASPxTextBox ID="txtArabicName" MaxLength="80" Width="250px" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="true" ErrorText="Enter Arabic Name" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="height: 7px"></td>
                        </tr>
                        <tr>
                            <td style="width: 120px;">
                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Address" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                            </td>
                            <td style="width: 250px;">
                                <dx:ASPxTextBox ID="txtAddress" MaxLength="80" Width="250" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 30px;"></td>
                            <td style="width: 100px">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Phone" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                            </td>
                            <td style="width: 250px;">
                                <dx:ASPxTextBox ID="txtPhone" MaxLength="20" Width="150" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RegularExpression ValidationExpression="[0-9]+" ErrorText="Enter Correct Number" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="height: 7px"></td>
                        </tr>
                        <tr>
                            <td style="width: 120px;">
                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Fax" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                            </td>

                            <td style="width: 250px;">
                                <dx:ASPxTextBox ID="txtFax" MaxLength="20" Width="150" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic">
                                        <RegularExpression ValidationExpression="[0-9]+" ErrorText="Enter Correct Number" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 30px;"></td>
                            <td style="width: 100px">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Mobile" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                            </td>
                            <td style="width: 250px;">
                                <dx:ASPxTextBox ID="txtMobile" MaxLength="20" Width="150" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RegularExpression ValidationExpression="[0-9]+" ErrorText="Enter Correct Number" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="6" style="height: 7px"></td>
                        </tr>
                        <tr>
                            <td style="width: 120px;">
                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Password" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                            </td>

                            <td style="width: 250px;">
                                <dx:ASPxTextBox ID="txtPassword" MaxLength="150" Width="150" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes" Password="true">
                                    <ValidationSettings ValidateOnLeave="true" ValidationGroup="savegrp" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="false" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                                For unchange the password leave it empty
                            </td>
                            <td style="width: 30px;"></td>
                            <td style="width: 100px">
                                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Expiry Date" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                            </td>
                            <td style="width: 250px;">
                                <dx:ASPxDateEdit ID="dtExpiryDate" Width="150" runat="server" Height="21" DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                                </dx:ASPxDateEdit>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="6" style="height: 7px"></td>
                        </tr>
                        <tr>
                            <td style="width: 120px;">
                                <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Remark" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                            </td>

                            <td style="width: 250px;">
                                <dx:ASPxTextBox ID="txtRemark" Width="750" runat="server" Height="21" CssClass="textbox" meta:resourcekey="Notes">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 30px;"></td>
                            <td style="width: 100px"></td>
                        </tr>

                        <tr>
                            <td colspan="6" style="height: 7px"></td>
                        </tr>
                        <tr>
                            <td style="width: 120px;">
                                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="InActive" meta:resourcekey="lblNotes"></dx:ASPxLabel>
                            </td>

                            <td style="width: 250px;">
                                <dx:ASPxCheckBox ID="ChkIsInActive" Checked="false" runat="server"></dx:ASPxCheckBox>
                            </td>
                            <td style="width: 30px;"></td>
                        </tr>
                        <tr>
                            <td colspan="6" style="height: 30px"></td>
                        </tr>
                        <tr>
                            <td align="left" class="lable">
                                <dx:ASPxLabel ID="lblRole" runat="server" Text="Role"></dx:ASPxLabel>
                            </td>
                            <td colspan="5" class="lableText">
                                <dx:ASPxCheckBoxList ID="chBoxRoles" AutoPostBack="true" runat="server" Style="vertical-align: middle; width: 100%" TextField="RoleEName" ValueField="RoleID" DataTextField="RoleEName" DataValueField="RoleID"
                                    Width="300px" RepeatDirection="Horizontal" RepeatLayout="Table" padding="1px" CssClass="dxeCheckBoxList_DevEx" RepeatColumns="4">
                                    <Border BorderStyle="None" />
                                </dx:ASPxCheckBoxList>
                            </td>
                        </tr>
                        <%--// <dx:ASPxCheckBoxList ID="ASPxCheckBoxList1" runat="server" ValueType="System.String"></dx:ASPxCheckBoxList>--%>
                    </table>
                </td>
            </tr>
        </table>
    </div>

    <div style="height: 30px"></div>

    <div style="width: 100%; height: inherit">
        <div>
            <div class="hidden" id="divmsg" runat="server" style="width: 500px;">
                <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
            </div>
        </div>
        <div class="table" style="padding-left: 10px; padding-right: 10px; padding-top: 10px">
            <div class="divrow">
                <div style="float: left; margin-right: 80px;">
                    <dx:ASPxUploadControl ID="UploadControl" runat="server" ClientInstanceName="UploadControl" Width="320"
                        NullText="Select signature..." UploadMode="Advanced" MaxFileCount="1" ShowUploadButton="True" ShowProgressPanel="True"
                        OnFileUploadComplete="UploadControl_FileUploadComplete" FileUploadMode="OnPageLoad">
                        <AdvancedModeSettings EnableDragAndDrop="True">
                            <FileListItemStyle CssClass="pending dxucFileListItem"></FileListItemStyle>
                        </AdvancedModeSettings>
                        <ValidationSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .png" MaxFileSize="1000000">
                        </ValidationSettings>
                        <ClientSideEvents FileUploadStart="function(s, e) { }" FileUploadComplete="onFileUploadComplete" />
                    </dx:ASPxUploadControl>
                    <br />
                    <p class="note">
                        <dx:ASPxLabel ID="AllowedFileExtensionsLabel" runat="server" Text="Allowed file extensions: .jpe, .jpeg, .jpg, .png" Font-Size="8pt">
                        </dx:ASPxLabel>
                        <br />
                        <dx:ASPxLabel ID="MaxFileSizeLabel" runat="server" Text="Maximum file size: 1 MB." Font-Size="8pt">
                        </dx:ASPxLabel>
                    </p>
                </div>
            </div>

            <div class="divrow">
                <dx:ASPxLabel ID="lblTransID" runat="server" Text="0" Visible="false"></dx:ASPxLabel>
                <dx:ASPxLabel ID="lblTransTypeID" runat="server" Text="0" Visible="false"></dx:ASPxLabel>
            
                <dx:ASPxRoundPanel ID="FilContents" Visible="false" ClientInstanceName="gridpanel" runat="server" Width="400" Height="180" HeaderText="Attached Files">
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxGridView ID="gdvfiles" ClientInstanceName="gdvfiles" runat="server" DataSourceID="TransactionAttachmentsDS" KeyFieldName="FileID" Width="380" OnCustomCallback="gdvfiles_CustomCallback" OnRowCommand="gdvfiles_RowCommand">
                                <Columns>
                                    <dx:GridViewDataHyperLinkColumn FieldName="FileName" Caption="File" Width="250">
                                        <DataItemTemplate>
                                            <a href="javascript:void(0)" target='_blank' style="display: block; text-wrap: avoid; width: 100px" onclick='return ShowScreenshotWindow(event, this);'><%#Eval("FileName") %></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataHyperLinkColumn>
                                    <dx:GridViewDataTextColumn FieldName="FileSize" Name="filesize" Caption="Size" Width="50">
                                        <Settings AutoFilterCondition="Contains" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn Name="Delete" Width="30">
                                        <DataItemTemplate>
                                            <dx:ASPxButton ID="BtnDelete" runat="server" Cursor="pointer" RenderMode="Link" EnableTheming="false" EnableViewState="false" CommandName="delete" FileName='<%#Eval("FileName") %>' CommandArgument='<%#Eval("FileID") %>'>
                                                <Image Url="../images/cross_icon.png" ToolTip="Remove"></Image>
                                            </dx:ASPxButton>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Name="Edit" Width="25">
                                        <DataItemTemplate>
                                             <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <dx:ASPxButton ID="BtnEdit" runat="server" Cursor="pointer" RenderMode="Link" ToolTip="<%$ Resources:GlobalResource, EditFormNew %>" EnableTheming="false" EnableViewState="false" CommandName="download" FileName='<%#Eval("FileName") %>' CommandArgument='<%#Eval("FileID") %>'>
                                                        <Image AlternateText="<%$ Resources:GlobalResource, EditFormUpdate %>" ToolTip="download" Url="../images/download4.jpg"></Image>
                                                    </dx:ASPxButton>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:postbacktrigger controlid="BtnEdit" />
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

    <asp:ObjectDataSource ID="TransactionAttachmentsDS" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAttachmentsWithNew" TypeName="BusinessLayer.Pages.AttachedFilesDB"
        ConflictDetection="CompareAllValues" DataObjectTypeName="BusinessLayer.AttachedFiles" DeleteMethod="DeleteData">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblTransID" DefaultValue="0" Name="transID" PropertyName="Text" Type="Int64" />
            <asp:ControlParameter ControlID="lblTransTypeID" PropertyName="Text" DefaultValue="0" Name="transTypeID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
