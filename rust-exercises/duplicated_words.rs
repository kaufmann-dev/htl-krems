// Calculate number of duplicated words in input vector in Rust

use std::collections::HashMap;
// HashMap: Werte werden basierend auf Schlüssel gespeichert
// Vergleichbar mit einem Dictionary in Python

fn solve_issue(input: Vec<&str>) -> i32 {
    let mut counts = HashMap::new();
    for s in input { // iteriert durch jedes Element des Eingabearrays
        let count = counts.entry(s).or_insert(0);
        // entry() gibt einen Eintrag für den Schlüssel zurück (z. B. Eintrag für "apple")
        // Wenn kein Eintrag vorhanden ist: fügt einen neuen Eintrag mit dem Schlüssel hinzu ("apple":0)
        *count += 1; // Für jede Iteration wird count um 1 erhöht damit man die Anzahl der Input Wörter zählen kann und später durch die HashMap iterieren kann
    }

    let mut result = 0;
    for (_, count) in counts {
        // Für HashMap (_, count) in counts
        // _ ist der Platzhalter für den Schlüssel
        if count > 1 {
            result += 1;
        }
    }

    result
}

fn main() {
    let input = vec!["apple", "banana", "apple", "cherry", "cherry"];
    println!("Number of duplicated words: {}", solve_issue(input));
}
