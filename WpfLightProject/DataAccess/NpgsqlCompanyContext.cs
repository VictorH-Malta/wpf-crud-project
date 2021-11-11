using System;
using System.Data;
using System.Windows;
using WpfLightProject.Models;
using Npgsql;
using System.Data.Common;
using WpfLightProject.DataAccess;
using WpfLightProject.Models.Validations;
using WpfLightProject.Models.Enums;
using System.Collections.Generic;

namespace WpfLightProject
{
    public class NpgsqlCompanyContext : ICompanyDataContext
    {
        private string _connectionString = "Server=localhost;Port=5432;Database=companiesdb;User Id = victorhmalta; Password=Victorpk030796;";
        public string ConnectionString { get => _connectionString; }
        public IDbConnection DbConnection { get; set; }
        public IDbCommand Command { get; set; }
        public ICompany Company { get; set; }
        public List<ICompany> CompaniesList { get; set; }
        public DbDataAdapter DataAdapter { get; set; }
        public DataSet DataSet { get; set; }
        private ValidateCompany _validateCompany;

        public NpgsqlCompanyContext()
        {
            DbConnection = new NpgsqlConnection(ConnectionString);
            _validateCompany = new ValidateCompany(); 
            Command = new NpgsqlCommand();
            DataSet = new DataSet();
            DataAdapter = new NpgsqlDataAdapter((NpgsqlCommand)Command);
        }

        public NpgsqlCompanyContext(ICompany company)
        {
            DbConnection = new NpgsqlConnection(ConnectionString);
            _validateCompany = new ValidateCompany();
            Command = new NpgsqlCommand();
            DataSet = new DataSet();
            DataAdapter = new NpgsqlDataAdapter((NpgsqlCommand)Command);
            Company = company;
        }

        public void Delete(ICompany company)
        {
            try
            {
                if (_validateCompany.ValidateId(company.Id))
                {
                    string cmd = $"DELETE FROM company WHERE id = {company.Id};";
                    DbConnection.Open();
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
                Dispose();
            }
        }

        public void Insert(ICompany company)
        {
            try
            {
                if (_validateCompany.IsCompanyValid(company))
                {
                    string cmd = $"INSERT INTO company (id, company_name, cnpj, business_branch, open_date, adress, status, company_size) VALUES ({company.Id}, '{company.Name}', '{company.RegisterNumber}', '{company.Business}', '{company.BirthDate}', '{company.Address}', {(int)company.Status}, {(int)company.CompanySize});";
                    DbConnection.Open();
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
                Dispose();
            }
        }

        public List<ICompany> Select()
        {
            try
            {
                string cmd = $"SELECT * FROM company;";
                DbConnection.Open();
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
                Dispose();
            }

            return CompaniesList;
        }

        public void Update(ICompany company)
        {
            try
            {
                if (_validateCompany.IsCompanyValid(company))
                {
                    string cmd = $"UPDATE company SET company_name = '{company.Name}', cnpj = '{company.RegisterNumber}', business_branch = '{company.Business}', open_date = '{company.BirthDate}', adress = '{company.Address}', status = {(int)company.Status}, company_size = {(int)company.CompanySize};";
                    DbConnection.Open();
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
                Dispose();
            }
        }

        public void Dispose()
        {

        }
    }  
}
