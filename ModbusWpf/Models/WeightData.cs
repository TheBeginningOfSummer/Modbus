using SQLite;

namespace Models;

public class WeightData
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Weight { get; set; }
    public string? Time { get; set; }

    public WeightData(string weight, string time)
    {
        Weight = weight;
        Time = time;
    }

    public WeightData() { }
}
