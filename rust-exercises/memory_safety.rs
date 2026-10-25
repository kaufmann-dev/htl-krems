// Explain memory safety in Rust

fn main() {
    // Vektor aus Nummern wird erstellt
    let mut vec;
    // "mut" ist ein Schlüsselwort in der Programmiersprache Rust, das verwendet wird, um anzuzeigen, dass eine Variable mutabel (veränderlich) ist. In Rust sind alle Variablen standardmäßig unveränderlich.
    vec = vec![1, 2, 3];
    // Vektor werden Zahlen hinzugefügt
    vec.push(4);
    // Vektor wird ausgegeben
    println!("{:?}", vec);
}

// {:?} is the debug formatter, which is used to print out the contents of a struct, enum, or other complex type.

// vec! Makro erstellt einen Vektor und gibt Ownership zu der Variable vec zurück
// push borgt sich eine mutable Referenz zum Vektor, dadurch kann sie den Wert ändern

// Vektor wird nie verschoben oder öfter als einmal mutably ausgeborgt
// Programm ist memory-safe und frei von data-races
// data-races: Zustände, in denen mehrere Threads oder Prozesse auf dieselben Daten zugreifen und sich gegenseitig beeinflussen