// Erkläre structs und &self in Rust

// Struct "Example" mit Feldern "x" und "y" wird definiert
struct Example {
    x: i32,
    y: i32,
}

// Methode "sum" wird für Example definiert
impl Example {
    fn sum(&self) -> i32 {
        // &self: Methode wird auf das aktuelle Objekt angewendet
        self.x + self.y
    }
}
// Methode verwendet "&self" als ersten Parameter, um anzuzeigen, dass sie auf das aktuelle Objekt angewendet wird -> Methode kann auf jedes "Example" Objekt angewendet werden