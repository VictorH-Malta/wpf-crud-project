using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using WpfLightProject.Models;

namespace WpfLightProject.DataAccess
{
    public interface IDataContext
    {
        string ConnectionString { get; }
        IDbConnection DbConnection { get; set; }
        IDbCommand Command { get; set; }
        DbDataAdapter DataAdapter { get; set; }
        DataSet DataSet { get; set; }
    }
}
