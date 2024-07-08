<%@ Page Title="Roles" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RolesManage.aspx.cs" Inherits="LaboratoryLayer.Admin.RolesManage" %>

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
            <%--<li><a id="menu2" href="#">General</a></li>--%>
            <li class="active" id="menulink">Roles List</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Roles List
			
        </h1>
    </div>
    <!-- /.page-header -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
     <script type="text/javascript">
        var prevColumnIndex;
        function OnStartEditing(s, e) {
            if (e.focusedColumn.fieldName === "_Modules") {
                gl.GetGridView().UnselectAllRowsOnPage();
                gl.SetValue(e.rowValues[e.focusedColumn.index].value);
                prevColumnIndex = e.focusedColumn.index;
            }
        }
        function OnEndEditing(s, e) {
            if (prevColumnIndex == null) return;
            e.rowValues[prevColumnIndex].value = gl.GetGridView().GetSelectedKeysOnPage();
            e.rowValues[prevColumnIndex].text = gl.GetText();
        }
    </script>

    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div class="col-lg-10 btn-group" role="group" aria-label="First group">

            <dx:ASPxButton AutoPostBack="false" ID="Button1" Text="Add New" CssClass="btn btn-primary" runat="server">
                <ClientSideEvents Init="function (s, e) {s.GetTextContainer().className += 'glyphicon glyphicon-plus';}" Click="function (s, e) { gridroles.AddNewRow();}" />
            </dx:ASPxButton>

        </div>
        <div class="col-lg-12">
             <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
        </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="btn-toolbar">
        <dx:ASPxGridView ID="GdvRoles" runat="server" ClientInstanceName="gridroles" OnCustomUnboundColumnData="Grid1_CustomUnboundColumnData" 
            OnCustomColumnDisplayText="Grid1_CustomColumnDisplayText"
            AutoGenerateColumns="False" KeyFieldName="RoleID" DataSourceID="RolesDS" Width="100%" OnRowDeleting="GdvRoles_RowDeleting" 
            OnRowInserting="GdvRoles_RowInserting" OnRowUpdating="GdvRoles_RowUpdating" OnCustomErrorText="GdvRoles_CustomErrorText">
            <Columns>
                <dx:GridViewDataTextColumn Name="Code" Caption="Code" FieldName="Code" VisibleIndex="1" Width="80">
                    <PropertiesTextEdit>
                        <ValidationSettings ValidateOnLeave="true" Display="Dynamic" ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="true" ErrorText="Enter Code" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Name="RoleEName" Caption="English Name" FieldName="RoleEName" VisibleIndex="2" Width="200">
                    <PropertiesTextEdit>
                        <ValidationSettings ValidateOnLeave="true" Display="Dynamic" ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="true" ErrorText="Enter English Name" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Name="RoleAName" Caption="Arabic Name" FieldName="RoleAName" VisibleIndex="3" Width="200">
                    <PropertiesTextEdit>
                        <ValidationSettings ValidateOnLeave="true" Display="Dynamic" ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="true" ErrorText="Enter Arabic Name" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn> 
                <dx:GridViewDataComboBoxColumn FieldName="UserType" Caption="User Type" VisibleIndex="4" Width="100">
                    <PropertiesComboBox>
                        <Items>
                            <dx:ListEditItem Text="Admin" Value="1" />
                            <dx:ListEditItem Text="Normal" Value="2" />
                        </Items>
                        <ValidationSettings ValidateOnLeave="true" Display="Dynamic" ValidationGroup="editForm" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="true" />
                        </ValidationSettings>
                    </PropertiesComboBox>
                 <Settings  AutoFilterCondition="Contains"/> 
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataColumn Width="250" Name="CategoryMasterID" Caption="Category Master" FieldName="_Modules" VisibleIndex="5" UnboundType="Object">
                    <EditItemTemplate>
                        <dx:ASPxGridLookup Width="100%" ID="Lookup" runat="server" AutoGenerateColumns="false" DataSourceID="ModuleListDS"
                        KeyFieldName="ModuleID" SelectionMode="Multiple" OnInit="Lookup_Init" TextFormatString="{1}">
                        <GridViewStyles>
                            <FocusedRow BackColor="#F16A39" />
                        </GridViewStyles>
                        <Columns>
                            <dx:GridViewCommandColumn ShowSelectCheckbox="true" VisibleIndex="0">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="ModuleID" ReadOnly="True"
                                Visible="False" VisibleIndex="0">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                           <%--  <dx:GridViewDataTextColumn FieldName="ModuleID" VisibleIndex="1">
                            </dx:GridViewDataTextColumn> --%>
                            <dx:GridViewDataTextColumn FieldName="ModuleAName" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridLookup>
                    </EditItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn Name="Notes" Caption="Notes" FieldName="Notes" VisibleIndex="6" Width="200">
                <Settings  AutoFilterCondition="Contains"/> </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn VisibleIndex="7" ButtonType="Image" Width="60" ShowEditButton="true" ShowDeleteButton="true"/>
            </Columns>

            <ClientSideEvents EndCallback="function(s, e) {if(s.cpDeleteError != ''){lblError.SetText(s.cpDeleteError);}else{lblError.SetText('');}}" 
                BatchEditStartEditing="OnStartEditing" BatchEditEndEditing="OnEndEditing" />
            <SettingsEditing Mode="Inline" NewItemRowPosition="Top" />
            <SettingsBehavior AutoFilterRowInputDelay="50000" ConfirmDelete="True" />
            <SettingsPager PageSize="10" AlwaysShowPager="false"></SettingsPager>
            <Styles>

                <AlternatingRow Enabled="True">
                </AlternatingRow>
            </Styles>
            <SettingsCommandButton>
                <EditButton>
                    <Image Url="../images/grd_edit.png">
                    </Image>
                </EditButton>
                <DeleteButton>
                    <Image Url="../images/grd_Delete.png">
                    </Image>
                </DeleteButton>
                <CancelButton>
                    <Image Url="../images/grd_clear.png">
                    </Image>
                </CancelButton>
                <UpdateButton>
                    <Image Url="../images/save.png">
                    </Image>
                </UpdateButton>
            </SettingsCommandButton>
        </dx:ASPxGridView>
        <asp:ObjectDataSource runat="server" ID="RolesDS" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLayer.Admin.RolesDB"></asp:ObjectDataSource>
        <asp:ObjectDataSource runat="server" ID="CategoryMasterDS" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLayer.Admin.CategoryMasterDB"></asp:ObjectDataSource>
        <asp:ObjectDataSource runat="server" ID="ModuleListDS" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Admin.ModuleDB"
    SelectMethod="GetAll"  DataObjectTypeName="BusinessLayer.ADMModules"></asp:ObjectDataSource>
</div>
</asp:Content>
