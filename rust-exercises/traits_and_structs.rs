// Etwas komplexeres Beispiel für Traits und Structs in Rust

// Ein Trait definieren, das eine Methode is_happy enthält
trait Happy {
    fn is_happy(&self) -> bool;
}

// Ein Struct Puppy definieren
struct Puppy {
    age: u8,
}

// Die Implementierung des Traits Happy für das Struct Puppy
impl Happy for Puppy {
    fn is_happy(&self) -> bool {
        self.age < 3
    }
}

// Eine Funktion, die ein Argument vom Typ T erwartet, solange T das Trait Happy implementiert
fn is_happy<T: Happy>(x: T) -> bool {
    x.is_happy()
}
// T: Typ
// T ist ein Platzhalter für einen beliebigen Typ, der das Trait Happy implementiert

fn main() {
    let puppy = Puppy { age: 2 };

    // is_happy kann auf ein Objekt vom Typ Puppy angewendet werden, da Puppy das Trait Happy implementiert
    println!("Is puppy happy? {}", is_happy(puppy));
}