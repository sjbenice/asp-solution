﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="ContractorInfo.aspx.cs" Inherits="LaboratoryLayer.Pages.ContractorInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PagePath" runat="server">
    <div class="breadcrumbs" id="breadcrumbs">
         <script>
             window.onbeforeunload = confirmExit;
             function confirmExit() {
                 return "You are about to exit the system! , Are you sure you want to leave now?";
             }
             $(function () {
                 $("a").click(function () {
                     window.onbeforeunload = null;
                 });
                 $("input").click(function () {
                     window.onbeforeunload = null;
                 });
             });
    </script>
        <script type="text/javascript">
            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
        </script>
        <ul class="breadcrumb" runat="server" id="ultitle">
            <li>
                <i class="ace-icon fa fa-home home-icon"></i>
                <a href="../Default.aspx">Home</a>
            </li>
            <li><a id="menu1" href="#">Setup</a></li>
            <li class="active" id="menulink">Contractor Information</li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHeader" runat="server">
    <div class="page-header">
        <h1>Contractor Information</h1>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div class="btn-group" role="group" aria-label="First group">
            <div>
         <dx:ASPxLabel ID="lblView" runat="server" ClientInstanceName="lblView" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblEdite" runat="server" ClientInstanceName="lblEdite" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblDelete" runat="server" ClientInstanceName="lblDelete" ForeColor="White" Text="false" Visible="false"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblAdd" runat="server" ClientInstanceName="lblAdd" Text="false" ForeColor="White" Visible="false"></dx:ASPxLabel>

    </div>

            <dx:ASPxButton ID="BtnSave" runat="server" EnableTheming="false" Text="Save" CssClass="btn btn-round btn-primary glyphicon glyphicon-floppy-disk" ValidationGroup="OnSave" OnClick="BtnSave_Click">
                <ClientSideEvents Click="function(s,e){if (!ASPxClientEdit.ValidateGroup('OnSave')) {document.getElementById('divError').className = 'alert alert-danger'; $('.alert').show();} else document.getElementById('divError').className = 'hidden';}" />
            </dx:ASPxButton>
        </div>
        <div class="btn-group" role="group" aria-label="First group">
            <dx:ASPxButton ID="BtnBack" runat="server" CssClass="btn btn-round btn-default glyphicon glyphicon-remove" Style="width: 80px" Text="Back" OnClick="BtnBack_Click">
            </dx:ASPxButton>

        </div>
    </div>
    <div class="row" style="height: 20px"></div>
    <div class="btn-toolbar">

        <div class="hidden" id="divmsg" runat="server" style="width: 750px;">
            <button type="button" class="close" onclick="document.getElementById('<%=divmsg.ClientID%>').className = 'hidden'">&times;</button>
            <dx:ASPxLabel ID="LblError" runat="server" CssClass="Alert" Text="" ClientInstanceName="lblError"></dx:ASPxLabel>
        </div>
        <div id="divError" class="hidden" style="width: 750px;">
            <button type="button" class="close" data-hide="alert" onclick="$('#divError').hide()">&times;</button>
            <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" RenderMode="Table" ValidationGroup="OnSave"></dx:ASPxValidationSummary>
        </div>
    </div>
    <div class="btn-toolbar">
        <dx:ASPxLabel ID="lblMasterId" runat="server" Text="0" ClientVisible="false"></dx:ASPxLabel>
        <dx:ASPxFormLayout ID="flContractorsList" runat="server" Width="800" DataSourceID="ContractorsListDS" ClientInstanceName="flContractorsList">
            <Items>
                <dx:LayoutGroup Caption="Contractor Information" ColCount="6">
                    <Items>
                         <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem />
                        <dx:EmptyLayoutItem Width="130" />
                        <dx:LayoutItem ShowCaption="False" FieldName="IsLocked" HorizontalAlign="Right" Height="40" >
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="IsLocked" runat="server" Text="Inactive" TextAlign="Right" ></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Contractor number"  FieldName="ContractorCode" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtCode" ReadOnly="true" runat="server">
                                        <ValidationSettings ValidationGroup="OnSave">
                                            <RequiredField IsRequired="true" ErrorText="Code is required!" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Contractor Name" FieldName="ContractorName" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtName" runat="server" Width="595">
                                         <ValidationSettings ValidationGroup="OnSave">
                                            <RequiredField IsRequired="true" ErrorText="Contractor Name is required!" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Contractor Carrier" FieldName="ContractorCarrier" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtContractorCarrier" runat="server" Width="595"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Location" FieldName="Location" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtLocation" runat="server" Width="595"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="G.M. Name" FieldName="GMName" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtGMName" runat="server" Width="250"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Mobile Number" FieldName="MobileNumber" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtMobileNumber" runat="server">
                                        <ValidationSettings ValidationGroup="EditForm">
                                            <RegularExpression ErrorText="Invalid Number"
                                             ValidationExpression="[+()0-9]+"/>
                                           </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Telephone No" FieldName="PhoneNumber" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtTel" runat="server">
                                        <ValidationSettings ValidationGroup="EditForm">
                                            <RegularExpression ErrorText="Invalid Number"
                                             ValidationExpression="[+()0-9]+"/>
                                           </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Fax No" FieldName="FaxNumber" ColSpan="3" >
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtFax" runat="server" Width="250">
                                        <ValidationSettings ValidationGroup="EditForm">
                                            <RegularExpression ErrorText="Invalid Number"
                                             ValidationExpression="[+()0-9]+"/>
                                           </ValidationSettings>
                                    </dx:ASPxTextBox>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Email" FieldName="Email" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtEmail" runat="server" Width="595"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Website" FieldName="website" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtwebsite" runat="server" Width="595"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Address" FieldName="Address" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtAddress" runat="server" Width="595"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <%--<dx:LayoutItem Caption="IsLocked" FieldName="IsLocked" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxCheckBox ID="IsLocked" runat="server"></dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                        <dx:LayoutItem Caption="Contractor Type" FieldName="ContractorType"  ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbContractorType" runat="server" ValueType="System.Int32" DropDownStyle="DropDownList">
                                        <Items>
                                            <dx:ListEditItem Text="Main" Value="1" />
                                            <dx:ListEditItem Text="Sub contract" Value="2" />
                                            <dx:ListEditItem Text="Client" Value="3" />

                                        </Items>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
    </div>

    <asp:ObjectDataSource ID="ContractorsListDS" runat="server" OldValuesParameterFormatString="original_{0}" TypeName="BusinessLayer.Pages.ContractorsListDB"
        SelectMethod="GetByID" InsertMethod="Insert" UpdateMethod="Update"
        OnInserting="ContractorsListDS_Inserting" OnInserted="ContractorsListDS_Inserted"
        OnUpdating="ContractorsListDS_Updating" OnUpdated="ContractorsListDS_Updated">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMasterId" PropertyName="Text" DefaultValue="0" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
