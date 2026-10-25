// Einfaches Beispiel für parallele Programmierung in Rust

use std::thread;

fn main() {
    // Erstelle zwei Threads und lege sie in eine Variable
    let threads = vec![
        thread::spawn(|| {
            // Dieser Thread führt eine Berechnung aus
            let result = (0..100).map(|x| x * x).sum();
            println!("Ergebnis der Berechnung im ersten Thread: {}", result);
        }),
        thread::spawn(|| {
            // Dieser Thread führt eine andere Berechnung aus
            let result = (0..100).map(|x| x + x).sum();
            println!("Ergebnis der Berechnung im zweiten Thread: {}", result);
        }),
    ];

    // Warte, bis alle Threads abgeschlossen sind
    for thread in threads {
        thread.join().unwrap();
    }
}