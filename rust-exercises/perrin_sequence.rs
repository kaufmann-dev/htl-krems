// Perrin-Folgein Rust

// Der erste Wert der Folge ist 2.
// Der n-te Wert der Folge ist der dritte Faktor der Summe der ersten n-1 Werte der Folge.
// jeder Wert in der Perrin-Folge ist der dritte Faktor der Summe der vorherigen Werte
// 3, 0, 2, 3, 2, 5, 5, 7, 10, 12, 17, 22, 29, ...
fn perrin(n: u32) -> Vec<u32> {
    let mut perrin = Vec::new(); // das gleiche wie vec![]
    let (mut a, mut b, mut c) = (3, 0, 2);
    for _ in 0..n { // for schleife
        // _ wird als Platzhalter in for schleifen verwendet wenn man nie auf den Wert der momentanen Iteration zugreifen muss
        // _x ist ein Platzhalter für eine Variable, die nicht verwendet wird
        perrin.push(a);
        a = b;
        b = c;
        c = a + b;
    }
    perrin
    // = println!("{:?}", perrin);
}

fn main() {
    let n = 10;
    println!("Perrin numbers up to {} iterations: {:?}", n, perrin(n));
}
