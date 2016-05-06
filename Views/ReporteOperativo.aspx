<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteOperativo.aspx.cs" Inherits="ReporteriaSIGAM.Views.ReporteOperativo" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">    
    <div class="panel panel-default">        
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">Reporteria Operativa</div>
                    <div>
                        <ol class="breadcrumb">
                            <li><a href="#">Home</a></li>
                            <li><a href="#">Library</a></li>
                            <li class="active">Data</li>
                        </ol>
                    </div>
                    <div class="panel-body">                         
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">Tipo Expediente:</div>
                                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control dropdown-toggle" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                        </div> 
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">Taxativa:</div>
                                    <asp:DropDownList ID="ddlTaxativa" runat="server" CssClass="form-control dropdown-toggle"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-2">                            
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">Departamento:</div>                                    
                                    <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-control dropdown-toggle" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" autopostback="true"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">Municipio:</div>
                                    <asp:DropDownList ID="ddlMunicipio" runat="server" CssClass="form-control dropdown-toggle"></asp:DropDownList>
                                </div>
                            </div>
                        </div> 
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">NIT:</div>
                                    <asp:TextBox ID="txtNIT" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>   
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">Años de Ingreso:</div>
                                    <asp:TextBox ID="txtAnioIngreso" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>   
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">Tabulacion:</div>
                                    <asp:DropDownList ID="ddlTabulacion" runat="server" CssClass="form-control dropdown-toggle"></asp:DropDownList>
                                </div>
                            </div>
                        </div> 
                                                                                               
                        <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                            <Report>

                            </Report>
                        </CR:CrystalReportSource>--%>
                    </div>
                </div>
            </div>
        </div>
        <div>

        </div>
    </div>
</asp:Content>
