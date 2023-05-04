using Microsoft.Extensions.DependencyInjection;
using System;
using ViewModels;

namespace ModbusWpf;

public class ServiceLocator
{
    private readonly IServiceProvider _serviceProvider;

    public MainVM? MainWindowVM => _serviceProvider.GetService<MainVM>();
    //public UploadVM? UploadVM => _serviceProvider.GetService<UploadVM>();
    //public DisplayVM? DisplayVM => _serviceProvider.GetService<DisplayVM>();

    public ServiceLocator()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<MainVM>();
        //serviceCollection.AddSingleton<UploadVM>();
        //serviceCollection.AddSingleton<DisplayVM>();
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }
}
