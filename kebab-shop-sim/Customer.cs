namespace Kebap; 

public class Customer {

    public static readonly SemaphoreSlim CustomerHandshake = new SemaphoreSlim(0);

    public static readonly SemaphoreSlim PaymentHandshake = new SemaphoreSlim(0);
    public string Name { get; set; }
    
    public Customer(string name) {
        Name = name;
    }
    
    public void Run() {
        Cook.CookGuard.Wait();
        Order();
        
        CustomerHandshake.Release();
        Cook.MealHandshake.Wait();

        Cashier.CashierGuard.Wait();
        Pay();
        PaymentHandshake.Release();
    }
    private void Order(){
        Console.WriteLine($"{Name}: ordering food");
        Thread.Sleep(1917);
    }
    private void Pay(){
        Console.WriteLine($"{Name}: paying order");
        Thread.Sleep(1989);
    }

}