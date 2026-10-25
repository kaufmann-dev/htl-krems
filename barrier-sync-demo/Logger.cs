namespace Barrier; 

public class Logger {
    public readonly static System.Threading.Barrier Barrier = new System.Threading.Barrier(5);

    public void Run() {
        Barrier.SignalAndWait();
        Console.WriteLine("echo");
    }
    
}