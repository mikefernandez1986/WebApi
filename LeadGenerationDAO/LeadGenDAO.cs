using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeadGenerationAdminDAO.ILeadGen;
using LeadGenAdminEntities.Entities;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace LeadGenerationAdminDAO
{
    public class LeadGenDAO: ILeadGenDAO
    {
        #region Private Variables
        private static readonly string _sqlConnectionString = Convert.ToString(ConfigurationManager.AppSettings["SqlConnString"]);
        #endregion

        #region Public Methods
        public List<LeadGenSourceEntities> GetLeadSource()
        {
            List<LeadGenSourceEntities> sourceDetails = new List<LeadGenSourceEntities>();
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(_sqlConnectionString, CommandType.StoredProcedure, "usp_LG_GetSourceDetails");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        LeadGenSourceEntities entities = new LeadGenSourceEntities();
                        entities.LeadId = Convert.ToInt32(dr["LeadSourceId"]);
                        entities.Sourcename = Convert.ToString(dr["SourceName"]);
                        sourceDetails.Add(entities);
                    }
                }
                dr.Close();
            }
            finally
            {
                if (!dr.IsClosed && dr != null)
                {
                    dr.Close();
                }
            }
            return sourceDetails;
        }

        public bool InsertLeadSource(LeadGenSourceInputEntities leadGenSourceInputEntities)
        {
            bool _isSuccess = false;

            SqlConnection conn = null;
            try
            {
                using (conn = new SqlConnection(_sqlConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_LG_InsertSourceDetails", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@SourceName", SqlDbType.VarChar).Value = leadGenSourceInputEntities.Sourcename;
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = leadGenSourceInputEntities.UserId;

                        conn.Open();
                        int insertId = cmd.ExecuteNonQuery();
                        if(insertId != 0)
                        {
                            _isSuccess = true;
                        }
                    }
                }
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return _isSuccess;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
