using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using ReporteriaSIGAM.DataSetObject;

namespace ReporteriaSIGAM.Query
{
    public class QueryCampos
    {
        public DataTable LlenadoCampoTipo(DataTable dtTipo) {
            try
            {
                //Creaction de DataTable con el esquema para Datos Tipo y un row vacio
                DataTableQuery dtTable = new DataTableQuery();
                dtTipo = dtTable.dtTipo();
                DataRow dtTipoRow = dtTipo.NewRow();
                dtTipoRow["Tipo"] = "";
                dtTipo.Rows.Add(dtTipoRow);

                //la variable cs con el connection string y y variable qry con la consulta a la base de datos
                string cs = ConfigurationManager.ConnectionStrings["ReportesConnection"].ConnectionString;
                String qry = "SELECT UNIQUE INS.INICIALES AS TIPO from TM_ESTUDIOS_IMPAMB EIM JOIN TC_INSTRUMENTOS INS ON INS.ESTATUS = EIM.TIPO WHERE EIM.TIPO IS NOT NULL";
                OleDbConnection conn = new OleDbConnection(cs);
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = qry;
                OleDbDataAdapter oracleadap = new OleDbDataAdapter(cmd);
                oracleadap.Fill(dtTipo);
                conn.Close();

                return dtTipo;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public DataTable LlenadoCampoTaxativa(DataTable dtTaxativa) {
            try
            {                
                DataTableQuery dtTable = new DataTableQuery();
                dtTaxativa = dtTable.dtTaxativa();
                DataRow dtTaxativaRow = dtTaxativa.NewRow();
                dtTaxativaRow["Taxativa"] = "";
                dtTaxativa.Rows.Add(dtTaxativaRow);


                string cs = ConfigurationManager.ConnectionStrings["ReportesConnection"].ConnectionString;
                String qry = "SELECT UNIQUE EIM.CTAXATIVA AS TAXATIVA FROM TM_ESTUDIOS_IMPAMB EIM WHERE EIM.CTAXATIVA IS NOT NULL";
                OleDbConnection conn = new OleDbConnection(cs);
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = qry;
                OleDbDataAdapter oracleadap = new OleDbDataAdapter(cmd);
                oracleadap.Fill(dtTaxativa);
                conn.Close();

                return dtTaxativa;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public DataTable LlenadoCampoDepartamento(DataTable dtDepartamento)
        {
            try
            {                
                DataTableQuery dtTable = new DataTableQuery();
                dtDepartamento = dtTable.dtDepartamento();
                DataRow dtDepartamentoRow = dtDepartamento.NewRow();
                dtDepartamentoRow["IdDepartamento"] = -1;
                dtDepartamentoRow["Departamento"] = "";
                dtDepartamento.Rows.Add(dtDepartamentoRow);


                string cs = ConfigurationManager.ConnectionStrings["ReportesConnection"].ConnectionString;
                String qry = "SELECT UNIQUE DEP.CODIGO_DEPARTAMENTO AS IdDepartamento,DEP.NOMBRE_DEPARTAMENTO AS Departamento FROM  recursos.tc_departamentos DEP";
                OleDbConnection conn = new OleDbConnection(cs);
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = qry;
                OleDbDataAdapter oracleadap = new OleDbDataAdapter(cmd);
                oracleadap.Fill(dtDepartamento);
                conn.Close();

                return dtDepartamento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LlenadoCampoMunicipio(DataTable dtMunicipio, Int32 IdDepartamento)
        {
            try
            {
                DataTableQuery dtTable = new DataTableQuery();
                dtMunicipio = dtTable.dtMunicipio();
                DataRow dtMunicipioRow = dtMunicipio.NewRow();
                dtMunicipioRow["IdMunicipio"] = -1;
                dtMunicipioRow["Municipio"] = "";
                dtMunicipio.Rows.Add(dtMunicipioRow);


                string cs = ConfigurationManager.ConnectionStrings["ReportesConnection"].ConnectionString;
                String qry = " SELECT UNIQUE MUN.CODIGO_MUNICIPIO AS IdMunicipio, MUN.NOMBRE_MUNICIPIO AS Municipio" + 
                             " FROM recursos.tc_municipios MUN JOIN RECURSOS.TC_DEPARTAMENTOS DEP" +
                             " ON DEP.CODIGO_DEPARTAMENTO  = MUN.CODIGO_DEPARTAMENTO WHERE DEP.CODIGO_DEPARTAMENTO = " + IdDepartamento;

                OleDbConnection conn = new OleDbConnection(cs);
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = qry;
                OleDbDataAdapter oracleadap = new OleDbDataAdapter(cmd);
                oracleadap.Fill(dtMunicipio);
                conn.Close();

                return dtMunicipio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LlenadoCampoTabulacion(DataTable dtTabulacion) {
            try
            {
                DataTableQuery dtTable = new DataTableQuery();
                dtTabulacion = dtTable.dtTabulacion();
                DataRow dtTabulacionRow = dtTabulacion.NewRow();
                dtTabulacionRow["Tabulacion"] = "";
                dtTabulacion.Rows.Add(dtTabulacionRow);

                string cs = ConfigurationManager.ConnectionStrings["ReportesConnection"].ConnectionString;
                String qry = "SELECT UNIQUE SEC.DESCRIPCION AS TABULACION  FROM TC_SECTORES SEC";

                OleDbConnection conn = new OleDbConnection(cs);
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = qry;
                OleDbDataAdapter oracleadap = new OleDbDataAdapter(cmd);
                oracleadap.Fill(dtTabulacion);
                conn.Close();

                return dtTabulacion;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        
    }
}