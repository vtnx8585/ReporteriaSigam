using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ReporteriaSIGAM.DataSetObject
{
    public class DataTableQuery
    {
        public DataTable dtTipo(){
            try{
                DataTable dt = new DataTable();                
                dt.Columns.Add("Tipo", typeof(String));
                return dt;
            }catch(Exception ex){
                throw ex;
            }
        }

        public DataTable dtTaxativa()
        {
            try
            {
                DataTable dt = new DataTable();                
                dt.Columns.Add("Taxativa", typeof(String));
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable dtDepartamento()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("IdDepartamento", typeof(Int32));
                dt.Columns.Add("Departamento", typeof(String));
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable dtMunicipio()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("IdMunicipio", typeof(Int32));
                dt.Columns.Add("Municipio", typeof(String));
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable dtTabulacion()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Tabulacion", typeof(String));                
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
    }
}