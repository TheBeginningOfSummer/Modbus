using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace ViewModels;

public class MainVM : ObservableObject
{
    public ObservableCollection<WeightData> Weights { get; } = new ObservableCollection<WeightData>();
    private readonly SQLiteService _sqlite = new("Weight.db", "\\Database");

    public MainVM()
    {
        InitializeData();
    }

    public async void InitializeData()
    {
        try
        {
            List<WeightData>? SourceData = await _sqlite.SQLConnection.Table<WeightData>().ToListAsync();
            if (SourceData != null)
                foreach (var data in SourceData)
                    Weights.Add(data);
        }
        catch (Exception e)
        {
            MessageBox.Show("加载信息失败。" + e.Message);
        }
    }
}
