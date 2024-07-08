<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="RssManage.aspx.cs" Inherits="LaboratoryLayer.Pages.RssManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
         function handleButtonClick(s, e) {
             
             if (e.buttonID == 'btnDeleteR') {
                 popupDelete.Show();
                 var key = s.GetRowKey(e.visibleIndex);
               
                 sid.SetValue(key);
             }
         

             if (e.buttonID == 'btnprintR') {
                 var key = s.GetRowKey(e.visibleIndex);
                 OnMoreInfoClick('RSSReportVersion.aspx?id=' + key);
             }
            
         }
         function OnMoreInfoClick(contentUrl) {
             clientPopupControl.SetContentUrl(contentUrl);
             clientPopupControl.Show();
         }

         function PrintReport(s,e) {
             debugger;
             if (gridRSS.cpFilter == "undefined") {
                 alert('Please Enter Filter');
             }
             else { window.open('ReportViwer.aspx?source=RSSReport&id=0&Filter=' + gridRSS.cpFilter, '_blank'); }
         }
     </script>
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
            <li><a id="menu1" href="#">Transaction</a></li>
            <li class="active" id="menulink">Request For Site Services</li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Request For Site Services</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">

    <div>
        <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
        <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
        <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
        <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

    </div>
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnAddNew" Text="Add New R.S.S" CssClass="btn btn-round btn-primary fa fa-plus" runat="server" OnClick="btnAddNew_Click">
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton AutoPostBack="false" ID="btnPrint" Text="Print" CssClass="btn btn-round btn-primary fa fa-print" runat="server">
                <ClientSideEvents Click="PrintReport" />
            </dx:ASPxButton>
        </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="btn-toolbar">
        <dx:ASPxGridView runat="server" ID="GdvRSS" AutoGenerateColumns="false" Width="100%" OnCustomErrorText="GdvRSS_CustomErrorText" ClientInstanceName="gridRSS"
            DataSourceID="RSSMasterDS" KeyFieldName="RSSMasterId" OnBeforeGetCallbackResult="GdvRSS_BeforeGetCallbackResult" 
            OnCellEditorInitialize="GdvRSS_CellEditorInitialize" OnCustomButtonInitialize="GdvRSS_CustomButtonInitialize" 
            OnCommandButtonInitialize="GdvRSS_CommandButtonInitialize">
            <Columns>
                <dx:GridViewDataComboBoxColumn FieldName="FKJobOrderMasterID" Caption="Job Order No" VisibleIndex="1" Width="300" CellStyle-HorizontalAlign="Left">
                    <PropertiesComboBox ValueField="JobOrderMasterID" TextFormatString="{0} - {1} - {2} " DataSourceID="JobOrderDS" ValueType="System.Int64">
                        <Columns>
                            <dx:ListBoxColumn FieldName="JobOrderNumber" Caption="Job Order No" Width="60" />
                            <dx:ListBoxColumn FieldName="CustomerName" Caption="Customer" Width="100" />
                            <dx:ListBoxColumn FieldName="ProjectName" Caption="Project" Width="100" />
                        </Columns>
                    </PropertiesComboBox>
                    <EditFormSettings Visible="False" />

                    <Settings AutoFilterCondition="Contains" />
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="RSSNumber" Caption="Request No" VisibleIndex="2" Width="150" CellStyle-HorizontalAlign="Left">
                    <Settings AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="RSSDate" Caption="Request Date" Width="150" VisibleIndex="3" CellStyle-HorizontalAlign="Left">
                    <PropertiesDateEdit DisplayFormatString="dd MMM yyyy" EditFormatString="dd MMM yyyy">
                    </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="SiteLocation" Caption="Site Location" Width="150" VisibleIndex="4" CellStyle-HorizontalAlign="Left">
                    <Settings AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="SampleNo" Caption="Sample No" Width="150" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                    <Settings AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                
                <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="CustomerName" Width="150" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                    <Settings AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                
                <%--Barkat : addded Technician Name--%>
                <dx:GridViewDataTextColumn FieldName="EmpName" Caption="Technician Name" Width="150" VisibleIndex="5" CellStyle-HorizontalAlign="Left">
                    <Settings AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>


                <dx:GridViewDataCheckColumn FieldName="IsSampled" Caption="Is Sampled" Width="150" VisibleIndex="6" CellStyle-HorizontalAlign="Left">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewCommandColumn VisibleIndex="7" ButtonType="Default" Width="80"
                    ShowClearFilterButton="true" ShowEditButton="true" ShowDeleteButton="false" ShowCancelButton="true" ShowUpdateButton="true">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnprintR" Text=" " Image-ToolTip="">
                            <Image Url="../images/print.png" Width="16" Height="16" ToolTip="print"></Image>

                        </dx:GridViewCommandColumnCustomButton>

                         <dx:GridViewCommandColumnCustomButton ID="btnDeleteR"  Text=" " Image-ToolTip="">
                           <Styles>
                                <Style Font-Size="Medium" CssClass="fa fa-trash"></Style>
                            </Styles>

                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>


                </dx:GridViewCommandColumn>
                <%--<dx:GridViewDataColumn VisibleIndex="10" Width="70">
                          
                            <DataItemTemplate>
                                <table cellpadding="0" cellspacing="2">
                                    <tr>
                                        <td>
                                          
                                            <asp:ImageButton ID="btnPrint" runat="server" ToolTip="<%$ Resources:GlobalResource, BtnPrint %>" Cursor="pointer" EnableTheming="false"
                                                RenderMode="Link" CommandName="CmdPrint" Visible="True" ImageUrl="../images/printer.png" Width="18px"
                                                AlternateText="<%$ Resources:GlobalResource, BtnPrint %>" ></asp:ImageButton>
                                                <%--OnClientClick="window.open('ReportViwer.aspx?source=RSSReport&id=' + '<%# Eval("RSSMasterId") %>' )"--%>

                <%-- </td>
                                        <td>
                                            <dx:ASPxButton ID="btnEdit"  runat="server" ToolTip="<%$ Resources:GlobalResource, BtnEdit %>" Cursor="pointer" Width="18px"
                                                CommandName="Edit" CommandArgument='<%# Eval("RSSMasterId") %>' Enabled='<%# !Convert.ToBoolean(Eval("IsSampled")) %>'  EnableTheming="False" RenderMode="Link" meta:resourcekey="btnEditResource1">
                                                <Image Url="../images/grd_edit.png" ToolTip="<%$ Resources:GlobalResource, BtnEdit %>" AlternateText="<%$ Resources:GlobalResource, BtnEdit %>"></Image>
                                            </dx:ASPxButton>
                                        </td>
                                      
                                        <td style="display: none">
                                            <dx:ASPxButton ID="btnDelete" runat="server" ToolTip="<%$ Resources:GlobalResource, BtnDelete %>" Cursor="pointer" EnableTheming="False" RenderMode="Link"
                                                CommandName="Delete" CommandArgument='<%# Eval("RSSMasterId") %>' meta:resourcekey="btnDeleteResource1" Width="18px"
                                                Visible='<%# !Convert.ToBoolean(Eval("IsSampled")) %>'>
                                                <Image Url="../images/grd_Delete.png" ToolTip="<%$ Resources:GlobalResource, BtnDelete %>" AlternateText="<%$ Resources:GlobalResource, BtnDelete %>"></Image>
                                                <ClientSideEvents Click="function(s,e) { e.processOnServer = confirm('Are you sure you want to delete ?'); }" />
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>--%>
            </Columns>
            <SettingsCommandButton>
                <ClearFilterButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="fa fa-eraser" />
                <EditButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-edit" />
<%--                <DeleteButton Text=" " Styles-Style-Font-Size="Medium" Styles-Style-CssClass="glyphicon glyphicon-trash" />--%>
            </SettingsCommandButton>
            <Settings ShowFilterRow="True" />
            <SettingsPager PageSize="20"></SettingsPager>

            <SettingsEditing Mode="EditForm" NewItemRowPosition="Bottom" />
            <SettingsText ConfirmDelete="<%$ Resources:GlobalResource, GridConfirmDelete %>" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" ColumnResizeMode="NextColumn" />
            <ClientSideEvents CustomButtonClick="handleButtonClick" />
            <Styles>
                <Header BackColor="SteelBlue" ForeColor="White"></Header>
            </Styles>
        </dx:ASPxGridView>
    </div>
            <dx:ASPxTextBox ID="sid" runat="server" ClientInstanceName="sid" ClientVisible="false" Text="0"></dx:ASPxTextBox>

    <div>
         <dx:ASPxPopupControl ID="popupControl" runat="server" ClientInstanceName="clientPopupControl" CloseAction="CloseButton" Height="500px" Modal="True" Width="500px" 
                              PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Select Report Revesion To Download"
                            AllowDragging="true" PopupAnimationType="Slide" ShowCloseButton="true" HeaderStyle-BackColor="SteelBlue"
                             HeaderStyle-ForeColor="White" >
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                      <div class="divrow">
                                                                  
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </div>

      <div>
        <dx:ASPxPopupControl ID="popupDelete" runat="server" CloseAction="CloseButton" 
            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" AllowDragging="False" PopupAnimationType="Slide"
            ShowFooter="True" Width="510px" HeaderText="Reason For Delete" ShowCloseButton="false" 
            HeaderStyle-BackColor="SteelBlue" HeaderStyle-ForeColor="White" ClientInstanceName="popupDelete">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                    <div class="divrow">
                      
                        <dx:ASPxMemo ID="txtDeleteReason" runat="server" Height="250" ClientInstanceName="txtDeleteReason" Width="100%" ClientVisible="true" Text=""></dx:ASPxMemo>
                                                
                    </div>
                   
                </dx:PopupControlContentControl>
            </ContentCollection>
            <FooterTemplate>
                <div style="display: table; margin: 6px 6px 6px auto;">
                    <div style="float:left">
                        <dx:ASPxButton ID="btnSaveDelete" ClientInstanceName="btnSaveDelete"  AutoPostBack="true" runat="server" OnClick="btnSaveDelete_Click"
                             Text="Save" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-save">
                            <ClientSideEvents Click="function(s, e) {if(txtDeleteReason.GetText()==''){alert('Please provide delete reason');  e.processOnServer = false; return;} }" />
                        </dx:ASPxButton>
                    </div>
                    <div style="float:left;margin-left:5px;">
                        <dx:ASPxButton ID="btnCancelDelete" runat="server" Text="Cancel" CssClass="btn btn-round btn-primary glyphicon glyphicon-remove">
                            <ClientSideEvents Click="function(s, e) {txtDeleteReason.SetText(''); popupDelete.Hide(); }" />
                        </dx:ASPxButton>
                    </div>
                </div>
            </FooterTemplate>
            <%--<ClientSideEvents PopUp="function(s, e) { popTestLists.PerformCallback(); }" />--%>
        </dx:ASPxPopupControl>
    </div>
    <asp:ObjectDataSource ID="RSSMasterDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.RSSMasterDB"
        DataObjectTypeName="BusinessLayer.RSSMaster" SelectMethod="GetAllFromView"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="JobOrderDS" runat="server" TypeName="BusinessLayer.Pages.JobOrderMasterDB"
        DataObjectTypeName="BusinessLayer.JobOrderMaster" SelectMethod="GetActiveJobOrderFromView"></asp:ObjectDataSource>

</asp:Content>
