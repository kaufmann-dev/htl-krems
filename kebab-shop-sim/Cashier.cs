namespace Kebap; 

public class Cashier {

    public static readonly SemaphoreSlim CashierGuard = new SemaphoreSlim(0);
    
    public string Name { get; set; }
    public Cashier(string name) {
        Name = name;
    }
    public void Run(){
        while(true) {
            CashierGuard.Release();
            Customer.PaymentHandshake.Wait();
            Confirm();
        }
    }
    
    public void Confirm(){
        Console.WriteLine(
            $"{Name}: confirm payment"
        );
        Thread.Sleep(1818);
    }


}