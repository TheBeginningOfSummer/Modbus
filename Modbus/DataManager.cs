using Microsoft.Data.Sqlite;
using Modbus.Models;
using System.Data;

namespace Modbus
{
    public class DataManager
    {
        public string DatabaseName { get; set; }
        public string DatabasePath { get; set; }
        public string ConnectionString;
        public List<string> TableList = new List<string>();

        public DataManager(string databaseName, string databasePath = "Database")
        {
            DatabaseName = databaseName;
            DatabasePath = databasePath;
            if (!Directory.Exists(DatabasePath)) Directory.CreateDirectory(DatabasePath);
            ConnectionString = $"Data Source={DatabasePath}/{DatabaseName};Pooling=true;Mode=ReadWriteCreate";
        }
        /// <summary>
        /// 初始化数据库中的表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="sql">初始化语句</param>
        public void InitializeDatabase(string tableName, string sql)
        {
            //得到数据库表信息
            DataTable schemaTable = InquireTables();
            //添加表名列表
            for (int i = 0; i < schemaTable.Rows.Count; i++)
                TableList.Add(schemaTable.Rows[i]["name"].ToString()!);
            //如果表不存在则创建
            if (!TableList.Contains(tableName))
                SQLiteTool.ExecuteSQL(ConnectionString, sql);
        }
        /// <summary>
        /// 查询数据库中所有表名
        /// </summary>
        /// <returns>所有表名</returns>
        public DataTable InquireTables()
        {
            string sql = $"select name from sqlite_master where type='table'";
            return SQLiteTool.QueryDataTable(ConnectionString, sql, "tableName");
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="data">插入的数据</param>
        /// <returns></returns>
        public bool AddData(string tableName, WeightData data)
        {
            string sql = $"insert into {tableName}(重量,测量时间) values(@重量,@测量时间)";
            SqliteParameter[] paras = new SqliteParameter[]
            {
                new SqliteParameter("@重量",data.Weight),
                new SqliteParameter("@测量时间",data.WeighTime),
            };
            if (SQLiteTool.ExecuteSQL(ConnectionString, sql, paras))
                return true;
            else
                return false;
        }
        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="tableHeader">要查询的表头</param>
        /// <param name="codition">条件</param>
        /// <returns>sql语句</returns>
        public static string AddCondition(string tableHeader, string codition)
        {
            return $" and {tableHeader} = '{codition}'";
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="minTime">查询时间下限</param>
        /// <param name="maxTime">查询时间上限</param>
        /// <returns></returns>
        public DataTable InquireData(string tableName, string minTime, string maxTime)
        {
            string sql = $"select * from {tableName} where 测量时间 >='{minTime}' and 测量时间<='{maxTime}'";
            return SQLiteTool.QueryDataTable(ConnectionString, sql, tableName);
        }
        /// <summary>
        /// 查询表中所有数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>查询到的表</returns>
        public DataTable InquireAllData(string tableName)
        {
            string sql = $"select * from {tableName}";
            return SQLiteTool.QueryDataSet(ConnectionString, sql).Tables[0]!;
        }
    }
}
