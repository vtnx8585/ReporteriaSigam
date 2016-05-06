using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Data.OleDb;
using ReporteriaSIGAM.Query;

namespace ReporteriaSIGAM.Views
{
    public partial class ReporteOperativo : System.Web.UI.Page
    {
        QueryCampos qrycampos = new QueryCampos();

        protected void Page_Load(object sender, EventArgs e)
        {            
            if(IsPostBack==false){
                DataTable dtTipo = new DataTable();
                DataTable dtTaxativa = new DataTable();
                DataTable dtDepartamento = new DataTable();
                DataTable dtTabulacion = new DataTable();               

                dtTipo = qrycampos.LlenadoCampoTipo(dtTipo);
                dtTaxativa = qrycampos.LlenadoCampoTaxativa(dtTaxativa);
                dtDepartamento = qrycampos.LlenadoCampoDepartamento(dtDepartamento);
                dtTabulacion = qrycampos.LlenadoCampoTabulacion(dtTabulacion);               

                ddlTipo.DataSource = dtTipo;
                ddlTipo.DataTextField = "Tipo";
                ddlTipo.DataValueField = "Tipo";
                ddlTipo.DataBind();

                ddlTaxativa.DataSource = dtTaxativa;
                ddlTaxativa.DataTextField = "Taxativa";
                ddlTaxativa.DataValueField = "Taxativa";
                ddlTaxativa.DataBind();

                ddlDepartamento.DataSource = dtDepartamento;
                ddlDepartamento.DataTextField = "Departamento";
                ddlDepartamento.DataValueField = "IdDepartamento";
                ddlDepartamento.DataBind();

                ddlTabulacion.DataSource = dtTabulacion;
                ddlTabulacion.DataTextField = "Tabulacion";
                ddlTabulacion.DataValueField = "Tabulacion";
                ddlTabulacion.DataBind();

                try
                {
                    DataSetObject.ReporteOperativo ds = new DataSetObject.ReporteOperativo();
                    ds.Clear();
                    //DataSetObject.ReporteOperativo.ReporteOpDataTable dt = new DataSetObject.ReporteOperativo.ReporteOpDataTable();    
                    //DataSet ds1 = new DataSet();
                    //DataTable dt = new DataTable();
                    //dt.Columns.Add("Tipo", typeof(String));
                    //dt.Columns.Add("Taxativa", typeof(String));
                    //dt.Columns.Add("Departamento", typeof(String));
                    //dt.Columns.Add("Municipio", typeof(String));
                    //dt.Columns.Add("DireccionProyecto", typeof(String));
                    //dt.Columns.Add("ObjetivoEmpresa", typeof(String));
                    //dt.Columns.Add("NombreEmpresa", typeof(String));
                    //dt.Columns.Add("RepresentanteLegal", typeof(String));
                    //dt.Columns.Add("NIT", typeof(String));
                    //dt.Columns.Add("Periodo", typeof(Int32));
                    //dt.Columns.Add("SeguroCaucion", typeof(String));
                    //dt.Columns.Add("Tabulacion", typeof(String));
                    //dt.Columns.Add("NombreConsultor", typeof(String));
                    string cs = ConfigurationManager.ConnectionStrings["ReportesConnection"].ConnectionString;

                //    string qry = "select EIM.TIPO as Tipo," +
                //                 " EIM.CTAXATIVA as Taxativa," +
                //                 " DEP.NOMBRE_DEPARTAMENTO as Departamento," +
                //                 " MUN.NOMBRE_MUNICIPIO as Municipio," +
                //                 " EIM.DIRECCION_PROYECTO As DireccionProyecto," +
                //                 " EIM.OBJETIVO_EMPRESA as ObjetivoEmpresa," +
                //                 " EIM.NOMBRE_EMPRESA as NombreEmpresa," +
                //                 " EIM.REPRESENTANTE_LEGAL as RepresentanteLegal," +
                //                 " CASE " +
                //                 " WHEN EIM.NIT_CONSULTOR IS NULL THEN EIM.NIT_EMPRESA" +
                //                 " WHEN EIM.NIT_CONSULTOR IS NOT NULL THEN EIM.NIT_CONSULTOR" +
                //                 " END AS NIT," +
                //                 " EIM.PERIODO as Periodo," +
                //                 " CASE" +
                //                 " WHEN FAM.FECHA_FINAL < sysdate then 'No Vigente'" +
                //                 " WHEN FAM.FECHA_FINAL >= sysdate then 'Vigente'" +
                //                                                 " END AS SeguroCaucion," +
                //                                                 " SEC.DESCRIPCION as Tabulacion," +
                //                                                 " EIM.NIT_CONSULTOR as NombreConsultor" +
                //                                                 " FROM gestion.tm_estudios_impamb eim" +
                //                                                 " left join gestion.td_fianzas_ambiental fam on FAM.NUMERO_EXPEDIENTE = EIM.NUMERO_ESTUDIO and FAM.PERIODO_EXPEDIENTE = EIM.PERIODO" +
                //                                                 " left join gestion.tc_sectores sec on SEC.TIPO = EIM.SECTOR" +
                //                                                 " left join gestion.tm_consultores con on CON.NIT = EIM.NIT_CONSULTOR" +
                //                                                 " join gestion.tc_unidad_administrativa adm on ADM.CODIGO_UNIDAD_ADMINISTRATIVA = EIM.UBICACION_GEOGRAFICA" +
                //                                                 " join recursos.tc_departamentos dep on DEP.CODIGO_DEPARTAMENTO = ADM.CODIGO_DEPARTAMENTO" +
                //                                                 " left join recursos.tc_municipios mun on MUN.CODIGO_MUNICIPIO = EIM.CODIGO_MUNICIPIO";

                string qry = "select EIM.Periodo AS ESTUDIO FROM gestion.tm_estudios_impamb eim order by periodo desc";                                            

                OleDbConnection conn = new OleDbConnection(cs);
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = qry;
                OleDbDataAdapter oracleadap = new OleDbDataAdapter(cmd);
                oracleadap.Fill(ds, "ReportePrueba");
                conn.Close();
                string c;
                int az = ds.ReporteOp.Rows.Count;
                //int a = dt.Rows.Count;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDepartamento.Text != "")
                {
                    DataTable dtMunicipio = new DataTable();
                    Int32 IdDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue);

                    dtMunicipio = qrycampos.LlenadoCampoMunicipio(dtMunicipio, IdDepartamento);
                    ddlMunicipio.DataSource = dtMunicipio;
                    ddlMunicipio.DataTextField = "Municipio";
                    ddlMunicipio.DataValueField = "IdMunicipio";
                    ddlMunicipio.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}