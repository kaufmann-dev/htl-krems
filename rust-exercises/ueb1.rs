fn sum_of_numbers(n: i32) -> i32 {
    let mut sum = 0;
    for i in 1..=n {
        sum += i;
    }
    sum
}

fn main() {
    let n = 5;
    println!("Sum of first {} numbers: {}", n, sum_of_numbers(n));
}
