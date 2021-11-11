using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows;
using WpfLightProject.Models;
using WpfLightProject.Models.Enums;
using WpfLightProject.Models.Validations;

namespace WpfLightProject.DataAccess
{
    public class SqlServerCompanyContext : ICompanyDataContext
    {
        public string ConnectionString => "Server=localhost;Database=companiesdb;User Id=sa;Password=1q2w3e4r@#$;";

        public IDbConnection DbConnection { get; set; }
        public IDbCommand Command { get; set; }
        public ICompany Company { get; set; }
        public List<ICompany> CompaniesList { get; set; }
        public DbDataAdapter DataAdapter { get; set; }
        public DataSet DataSet { get; set; }
        private ValidateCompany _validateCompany;

        public SqlServerCompanyContext()
        {
            DbConnection = new SqlConnection(ConnectionString);
            _validateCompany = new ValidateCompany();
            Command = new SqlCommand();
            DataSet = new DataSet();
            DataAdapter = new SqlDataAdapter((SqlCommand)Command);
        }

        public ICompany Delete(ICompany company)
        {
            try
            {
                if (DbConnection.State != ConnectionState.Open)
                {
                    DbConnection.Open();
                }

                if (_validateCompany.ValidateId(company.Id))
                {
                    string cmd = $"DELETE FROM company WHERE id = {company.Id};";
                    Command.CommandText = cmd;
                    Command.Connection = DbConnection;
                    Command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DbConnection.Close();
            }

            return company;
        }

        public ICompany Insert(ICompany company)
        {
            try
            {
                if (DbConnection.State != ConnectionState.Open)
                {
                    DbConnection.Open();
                }

                if (_validateCompany.IsCompanyValid(company))
                {
                    string cmd = $"INSERT INTO company (company_name, cnpj, business_branch, open_date, adress, status, company_size) VALUES ('{company.Name}', '{company.RegisterNumber}', '{company.Business}', '{company.BirthDate}', '{company.Address}', {(int)company.Status}, {(int)company.CompanySize});";
                    Command.CommandText = cmd;
                    Command.Connection = DbConnection;
                    Command.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Unable to register company. Check information");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DbConnection.Close();
            }

            return company;
        }

        public List<ICompany> Select()
        {
            try
            {
                if (DbConnection.State != ConnectionState.Open)
                {
                    DbConnection.Open();
                }

                string cmd = $"SELECT * FROM company;";
                Command.CommandText = cmd;
                Command.Connection = DbConnection;
                DataAdapter.Fill(DataSet, "company");

                if (CompaniesList == null)
                {
                    CompaniesList = new List<ICompany>();

                    foreach (DataRow dataRow in DataSet.Tables[0].Rows)
                    {
                        ICompany company = new Company();
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

        public ICompany Update(ICompany company)
        {
            try
            {
                if (DbConnection.State != ConnectionState.Open)
                {
                    DbConnection.Open();
                }

                if (_validateCompany.IsCompanyValid(company))
                {
                    string cmd = $"UPDATE company SET company_name = '{company.Name}', cnpj = '{company.RegisterNumber}', business_branch = '{company.Business}', open_date = '{company.BirthDate}', adress = '{company.Address}', status = {(int)company.Status}, company_size = {(int)company.CompanySize};";
                    Command.CommandText = cmd;
                    Command.Connection = DbConnection;
                    Command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DbConnection.Close();
                DbConnection.Dispose();
            }

            return company;
        }
    }
}
