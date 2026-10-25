namespace Kebap; 

public class Cook {

    public static SemaphoreSlim CookGuard = new SemaphoreSlim(0);
    public static SemaphoreSlim MealHandshake = new SemaphoreSlim(0);
    public string Name { get; set; }

    public Cook(string name) {
        Name = name;
    }
    
    public void Run(){
        while(true) {
            CookGuard.Release();
            Customer.CustomerHandshake.Wait();
            
            PrepareMeal();
            MealHandshake.Release();
        }
    }
    public void PrepareMeal(){
        Console.WriteLine($"{Name}: cooking food");
        Thread.Sleep(1818);
    }
}