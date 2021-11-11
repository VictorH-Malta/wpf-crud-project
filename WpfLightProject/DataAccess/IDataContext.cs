using System;
using System.Data;
using System.Data.Common;

namespace WpfLightProject.DataAccess
{
    public interface IDataContext : IDisposable
    {
        string ConnectionString { get; }
        IDbConnection DbConnection { get; set; }
        IDbCommand Command { get; set; }
        DbDataAdapter DataAdapter { get; set; }
        DataSet DataSet { get; set; }
    }
}
