fn fibonacci(n: u32) -> Vec<u32> {
    let mut fib = Vec::new();
    let (mut a, mut b) = (0, 1);
    for _ in 0..n {
        fib.push(a);
        let c = a + b;
        a = b;
        b = c;
    }
    fib
}

fn main() {
    let n = 5;
    println!("Fibonacci numbers up to {} iterations: {:?}", n, fibonacci(n));
}
