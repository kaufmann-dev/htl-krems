// See https://aka.ms/new-console-template for more information

using Kebap;

Console.WriteLine("Kebappeppi!");

new Thread(new Cook("Abdul").Run).Start();
new Thread(new Cook("Hakan").Run).Start();

new Thread(new Cashier("Ali").Run).Start();

var customerThreads = Enumerable.Range(1, 10).Select(n => new Thread(new Customer($"c{n}").Run));
customerThreads.ToList().ForEach(t => t.Start());


