using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public interface IEntity
    {
        string TableName { get; }
        string Columns { get; }
        string ValuesClause { get; }
        string SetClause { get; }
        string PrimaryKey { get; }
        string PrimaryKeyCondition { get; }
        string? JoinTableName { get; }
        string? SelectClaues { get; }
        string DisplayValue { get; }

        List<SqlParameter> GetSqlParameters();
        List<SqlParameter> GetPrimaryKeyParameters();
        (string whereClause, List<SqlParameter> parameters) GetWhereClauseWithParameters();
        List<IEntity> GetReaderList(SqlDataReader reader);
    }
}
