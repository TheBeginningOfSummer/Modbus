using Microsoft.Data.Sqlite;
using System.Data;

namespace Modbus
{
    public class SQLiteTool
    {
        public static DataTable GetTableList(string connectionString)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            if (connection.State != ConnectionState.Open) connection.Open();
            DataTable schemaTable = connection.GetSchema("TABLES");
            schemaTable.Columns.Remove("TABLE_CATALOG");
            schemaTable.Columns.Remove("TABLE_SCHEMA");
            schemaTable.Columns["TABLE_NAME"]?.SetOrdinal(0);
            return schemaTable;
        }

        private static void SetCommand(SqliteCommand command, SqliteConnection connection, string sqlString, params SqliteParameter[] parameters)
        {
            try
            {
                if (connection.State != ConnectionState.Open) connection.Open();
                command.Parameters.Clear();
                command.Connection = connection;
                command.CommandText = sqlString;
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 30;
                if (parameters != null)
                {
                    foreach (SqliteParameter parameter in parameters)
                        command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        /// <summary>
        /// 得到数据集
        /// </summary>
        /// <param name="command">命令</param>
        /// <returns>数据集</returns>
        private static DataSet GetDataSet(SqliteCommand command)
        {
            DataSet ds = new DataSet();
            SqliteDataReader reader = command.ExecuteReader();
            var isSQLite = command.Connection?.GetType()?.FullName?.ToLower().Contains("sqlite");
            if (!isSQLite.HasValue) return ds;
            if ((bool)isSQLite)
            {
                do
                    ds.Tables.Add(GetDataTable(reader, "table" + (ds.Tables.Count + 1)));
                while (reader.NextResult());
            }
            else
            {
                do
                {
                    var table = new DataTable { TableName = "table" + (ds.Tables.Count + 1) };
                    table.Load(reader);
                    ds.Tables.Add(table);
                } while (!reader.IsClosed);
            }
            return ds;
        }
        /// <summary>
        /// 得到数据表
        /// </summary>
        /// <param name="reader">读取器</param>
        /// <param name="tableName">表名</param>
        /// <returns>数据表</returns>
        private static DataTable GetDataTable(SqliteDataReader reader, string tableName)
        {
            var table = new DataTable { TableName = tableName };
            var columnSchema = reader.GetColumnSchemaAsync();
            //添加列信息
            foreach (var column in columnSchema.Result)
                table.Columns.Add(column.ColumnName, column.DataType!);
            //添加行数据
            while (reader.Read())
            {
                var row = table.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                    row[i] = reader.GetValue(i);
                table.Rows.Add(row.ItemArray);
            }
            return table;
        }
        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="sqlString">SQL命令</param>
        /// <param name="parameters">可选参数</param>
        /// <returns>所查询的数据</returns>
        public static DataSet QueryDataSet(string connectionString, string sqlString, params SqliteParameter[] parameters)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            using SqliteCommand command = new SqliteCommand();
            try
            {
                SetCommand(command, connection, sqlString, parameters);
                return GetDataSet(command);
            }
            catch (Exception)
            {
                return new DataSet();
            }
        }
        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="sqlString">SQL命令</param>
        /// <param name="parameters">可选参数</param>
        /// <returns>所查询的数据</returns>
        public static DataTable QueryDataTable(string connectionString, string sqlString, string tableName, params SqliteParameter[] parameters)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            using SqliteCommand command = new SqliteCommand();
            try
            {
                SetCommand(command, connection, sqlString, parameters);
                SqliteDataReader reader = command.ExecuteReader();
                return GetDataTable(reader, tableName);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
        /// <summary>
        /// 数据库执行指令
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="sqlString">SQL命令</param>
        /// <param name="parameters">可选参数</param>
        /// <returns>是否成功</returns>
        public static bool ExecuteSQL(string connectionString, string sqlString, params SqliteParameter[] parameters)
        {
            bool result = true;
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using SqliteCommand command = new SqliteCommand();
                SetCommand(command, connection, sqlString, parameters);
                SqliteTransaction transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    result = true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    result = false;
                }
            }
            return result;
        }
    }
}
