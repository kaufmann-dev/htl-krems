// Erkläre Referenzen und mutable in Rust

fn main(){
    let mut x = 5;
    let y = &x;
    x = 6;

    println!("{}", y);
}

// & beduetet, dass eine Referenz auf ein Objekt erstellt wird. Eine Referenz ist ein Wert, der auf ein anderes Objekt verweist, ohne dessen Inhalt zu kopieren