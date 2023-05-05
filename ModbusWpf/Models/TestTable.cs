using SQLite;

namespace ModbusWpf.Models
{
    //使用SQLite-net-pcl指定表名
    [Table("Test")]
    public class TestTable
    {
        [PrimaryKey]
        [Column("ID")]//指定列名
        public int Id { get; set; }
        [Column("名称")]
        public string Name { get; set; } = string.Empty;

        private string? _title;
        [Ignore]//不在数据库中创建此列
        public string Title => _title ??= Name;
    }
}
