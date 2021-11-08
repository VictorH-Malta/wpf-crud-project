using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows;
using WpfLightProject.Models;
using WpfLightProject.Models.Enums;

namespace WpfLightProject.DataAccess
{
    public class SqlServerCompanyContext : IDataContext, ICompanyDataContext
    {
        public string ConnectionString => "Server=localhost;Database=companiesdb;User Id=sa;Password=1q2w3e4r@#$;";

        public IDbConnection DbConnection { get; set; }
        public IDbCommand Command { get; set; }
        public ICompany Company { get; set; }
        public List<ICompany> CompaniesList { get; set; }
        public DbDataAdapter DataAdapter { get; set; }
        public DataSet DataSet { get; set; }

        public SqlServerCompanyContext()
        {
        }

        public SqlServerCompanyContext(ICompany company)
        {
            DbConnection = new SqlConnection(ConnectionString);
            Company = company;
        }

        public void Delete(ICompany company)
        {
            try
            {
                DbConnection = new SqlConnection(ConnectionString);
                DbConnection.Open();
                Command = new SqlCommand($"DELETE FROM company WHERE id = {company.Id};");
                Command.Connection = DbConnection;
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DbConnection.Close();
            }
        }

        public void Insert(ICompany company)
        {
            try
            {
                DbConnection = new SqlConnection(ConnectionString);
                DbConnection.Open();
                Command = new SqlCommand($"INSERT INTO company (id, company_name, cnpj, business_branch, open_date, adress, status, company_size) VALUES ({company.Id}, '{company.Name}', '{company.RegisterNumber}', '{company.Business}', '{company.BirthDate}', '{company.Address}', {(int)company.Status}, {(int)company.CompanySize});");
                Command.Connection = DbConnection;
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DbConnection.Close();
            }
        }

        public List<ICompany> Select()
        {
            try
            {
                DbConnection = new SqlConnection(ConnectionString);
                DbConnection.Open();
                Command = new SqlCommand($"SELECT * FROM company;");
                Command.Connection = DbConnection;
                DataAdapter = new SqlDataAdapter((SqlCommand)Command);
                DataSet = new DataSet();
                DataAdapter.Fill(DataSet, "company");

                if (CompaniesList == null)
                {
                    CompaniesList = new List<ICompany>();
                }

                foreach (DataRow dataRow in DataSet.Tables[0].Rows)
                {
                    Company company = null;
                    company.Id = (int)dataRow[0];
                    company.Name = dataRow[1].ToString();
                    company.RegisterNumber = dataRow[2].ToString();
                    company.Business = (BusinessBranch)Enum.Parse(typeof(BusinessBranch), dataRow[3].ToString(), true);
                    company.BirthDate = DateTime.Parse(dataRow[4].ToString());
                    company.Address = dataRow[5].ToString();
                    company.Status = (Status)Enum.Parse(typeof(Status), dataRow[6].ToString());
                    company.CompanySize = (CompanySize)Enum.Parse(typeof(CompanySize), dataRow[7].ToString());
                    
                    CompaniesList.Add(company);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DbConnection.Close();
                DataAdapter.Dispose();
                DataSet = null;
            }

            return CompaniesList;
        }

        public void Update(ICompany company)
        {
            try
            {
                DbConnection = new SqlConnection(ConnectionString);
                DbConnection.Open();
                Command = new SqlCommand($"UPDATE company SET company_name = '{company.Name}', cnpj = '{company.RegisterNumber}', business_branch = '{company.Business}', open_date = '{company.BirthDate}', adress = '{company.Address}', status = {(int)company.Status}, company_size = {(int)company.CompanySize};");
                Command.Connection = DbConnection;
                Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DbConnection.Close();
            }
        }
    }
}
