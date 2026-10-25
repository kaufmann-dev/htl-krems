// See https://aka.ms/new-console-template for more information

using Barrier;

Console.WriteLine("Hello, World!");

await Task.WhenAll(
    Task.Run(new Logger().Run),
    Task.Run(new Logger().Run),
    Task.Run(new Logger().Run),
    Task.Run(new Logger().Run),
    Task.Run(new Logger().Run)
);