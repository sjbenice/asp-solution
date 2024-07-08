<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmapleReceiveAndAttachmentView.aspx.cs" Inherits="LaboratoryLayer.Pages.SmapleReceiveAndAttachmentView" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <div>
          <div>
            <link href="../MasterPages/Test/css/style.default.css" rel="stylesheet" />

            <dx:ASPxLabel ID="lblTransID" runat="server" Text="47286" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblTransTypeID" runat="server" Text="22222" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblUploadDirectory" runat="server" Text="~/Uploaded/Attachments" Visible="false"></dx:ASPxLabel>
            <script type="text/javascript">
                function redirectToUrl(fileUrl) {

                    debugger;
                    var deencodedFileUrl = decodeURIComponent(fileUrl);

                    var newrul = fileUrl;
                    var normalizedFileUrl = deencodedFileUrl.replace(/\+/g, ' ').replace(/\\/g, '/');
                    window.location.href = encodeURI(normalizedFileUrl);
                    return false; // This prevents the button from causing a postback
                }
                function gdvfilesEndCallback(s, e) {

                    if (s.cpRowCommandCompleted.trim() !== "" && s.cpRowCommandCompleted.trim() !== "ReviseCompleted") {
                        redirectToUrl(s.cpRowCommandCompleted);

                    }
                  
                    s.cpRowCommandCompleted = "";
                }
                function onBtnCheckClick(s, e) {

                    gdvfiles.PerformCallback('btnPrintDetailClicked|' + s.globalName);
                }
                function ChangeLink(fileUrl) {
                    debugger;
                    var deencodedFileUrl = decodeURIComponent(fileUrl);

                    var newrul = fileUrl;
                    var normalizedFileUrl = deencodedFileUrl.replace(/\+/g, ' ').replace(/\\/g, '/');

                    

                    window.location.href = encodeURI(normalizedFileUrl);

                    return false;
                }
                var FilesGridEdited = false;

                function onFileUploadComplete(s, e) {
                    if (e.callbackData) {
                        gdvfiles.PerformCallback();
                        //FilesGridEdited = true;
                        //window.location = window.location;
                    }
                }

                ShowScreenshotWindow = function (evt, link) {
                    ShowScreenshot(link.href);
                    evt.cancelBubble = true;
                    return false;
                }
                ShowScreenshot = function (src) {
                    var screenLeft = document.all && !document.opera ? window.screenLeft : window.screenX;
                    var screenWidth = screen.availWidth;
                    var screenHeight = screen.availHeight;
                    var zeroX = Math.floor((screenLeft < 0 ? 0 : screenLeft) / screenWidth) * screenWidth;

                    var windowWidth = 575;
                    var windowHeight = 325;
                    var windowX = parseInt((screenWidth - windowWidth) / 2);
                    var windowY = parseInt((screenHeight - windowHeight) / 2);
                    if (windowX + windowWidth > screenWidth)
                        windowX = 0;
                    if (windowY + windowHeight > screenHeight)
                        windowY = 0;

                    windowX += zeroX;

                    var popupwnd = window.open(src, '_blank', "left=" + windowX + ",top=" + windowY + ",width=" + windowWidth + ",height=" + windowHeight + ", scrollbars=no, resizable=no", true);
                    if (popupwnd != null && popupwnd.document != null && popupwnd.document.body != null) {
                        popupwnd.document.body.style.margin = "0px";
                    }
                }

                function RefreshParent() {
                    //if (window.opener != null && !window.opener.closed && FilesGridEdited ==true) {
                    //    window.opener.location.reload();
                    //}
                }
                //window.onbeforeunload = RefreshParent;
                window.onunload = RefreshParent;
            </script>
            <div style="width: 100%; height: inherit">
                <div>
                    <div class="hidden" id="divmsg" runat="server" style="width: 500px;">
                     <%--   <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>--%>
                        <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
                    </div>
                </div>
                <div class="table" style="padding-left: 10px; padding-right: 10px; padding-top: 10px">
                    
                    <div class="divrow">
                        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" ClientInstanceName="gridpanel" runat="server" Width="400" Height="180" HeaderText="Recipt Files">
                            <PanelCollection>
                                <dx:PanelContent>

                                        <dx:ASPxGridView ID="ASPxGridViewPopup" runat="server" ClientInstanceName="gridViewPopup" Width="450" OnDataBinding="ASPxGridViewPopup_DataBinding" >
<SettingsCommandButton>
<ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

<HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
</SettingsCommandButton>
            <Columns>
                <dx:GridViewDataHyperLinkColumn FieldName="HyperlinkColumnName" Caption="Recipt Number" VisibleIndex="0"  Width="100%" >
                    <DataItemTemplate>
                        <dx:ASPxHyperLink ID="hyperlink"  Target="_blank"  runat="server" Text='<%# Eval("ReportName") %>' NavigateUrl='<%# Eval("HyperlinkColumnName") %>'></dx:ASPxHyperLink>
                    </DataItemTemplate>
                </dx:GridViewDataHyperLinkColumn>
            </Columns>
        </dx:ASPxGridView>
                                        </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                    </div>
                    <div class="divrow">
                        <dx:ASPxRoundPanel ID="FilContents" ClientInstanceName="gridpanel" runat="server" Width="400" Height="180"
                             HeaderText="Attached Files">
                            <PanelCollection>
                                <dx:PanelContent>


                                    <dx:ASPxGridView ID="gdvfiles" ClientInstanceName="gdvfiles" runat="server"  KeyFieldName="FileID" Width="380"   OnRowCommand="gdvfiles_RowCommand" OnDataBinding="gdvfiles_DataBinding" OnCustomCallback="gdvfiles_CustomCallback">
                                                    <ClientSideEvents   EndCallback="gdvfilesEndCallback" />

                                         <Columns>
                                            <dx:GridViewDataHyperLinkColumn FieldName="FileName" Caption="File" Width="100%" VisibleIndex="1">
                                                <DataItemTemplate>
                                                      <dx:ASPxButton ID="btnPrintWithDetails" Text='<%#Eval("FileName") %>' runat="server" Cursor="pointer" RenderMode="Link" EnableTheming="false"  AutoPostBack="false" 
                                EnableViewState="false"   CommandName="PrintWithDetails" ClientInstanceName ='<%#Eval("FileID") %>'>
                                    <ClientSideEvents Click="function(s, e) { onBtnCheckClick(s, e); }" />

                            </dx:ASPxButton>
                                                           </DataItemTemplate>
                                            </dx:GridViewDataHyperLinkColumn>
                                            
                                          
                                        </Columns>
                                        <SettingsCommandButton>
<ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

<HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>

              
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
            <asp:ObjectDataSource ID="TransactionAttachmentsDS" runat="server"
                OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAttachmentsWithNew" TypeName="BusinessLayer.Pages.AttachedFilesDB"
                ConflictDetection="CompareAllValues"
                DataObjectTypeName="BusinessLayer.AttachedFiles"
                DeleteMethod="DeleteData">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblTransID" DefaultValue="0" Name="transID" PropertyName="Text" Type="Int64" />
                    <asp:ControlParameter ControlID="lblTransTypeID" PropertyName="Text" DefaultValue="0" Name="transTypeID" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>

        </div>
        </div>
    </div>
   </form>
</body>
</html>

