// Erkläre Makros in Rust

// Macro namens print_hello! wird definiert
// Lambda Funktion wird definiert
macro_rules! print_hello {
    () => (println!("Hello!"));
}

// Makro wird in der main aufgerufen
fn main() {
    print_hello!();
}

// Kompilieren und ausführen: cargo run