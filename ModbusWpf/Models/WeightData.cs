namespace Models;

public class WeightData
{
    public string? Weight { get; set; }
    public string? WeighTime { get; set; }

    public WeightData(string weight, string weighTime)
    {
        Weight = weight;
        WeighTime = weighTime;
    }

    public WeightData() { }
}
