/* Beispiel 1
   Variablen Dekleration
   ---------------------
   let   -> Block scope
   var   -> function scope
   const -> keine Variable sondern Konstante
         -> block scope
*/
let firstName = "Hugo";
var lastName = "Hombo";
console.log(firstName,lastName);
console.log(`Vorname: ${firstName}\nNachnahme: ${lastName}`);

/* Beispiel 2
   Datentypen
   ---------------------
   number, string, object, undefined 
*/
let sumber = "21";
console.log(typeof(sumber));
console.log(typeof(Number(sumber)));
console.log(Boolean(Number(sumber)));

/* Beispiel 3
   Mathematische Therme
   ---------------------
*/
console.log(1+2*3+4);

/* Beispiel 4
   String Methoden
   ---------------------
   slice, toUpper, toLower,
   replaceAll, trim, explode, ...
*/
let palindrom = "OTTTO";
if(palindrom.length%2){
    console.log(palindrom.slice(0,palindrom.length/2)+palindrom.slice(palindrom.length/2+1, palindrom.length));
}

/* Beispiel 5
   Arrays
   ---------------------
*/
// Pop, push, shift, unshift
let numbers = [3,27,8,4,-5];
numbers.pop();
numbers.push(88);
numbers.shift();
numbers.unshift(14);
console.log(numbers);

// Map
let mapping = function(n){
    return n+2;
}
console.log(numbers.map(n=>n+2));
console.log(numbers.map(mapping));

// Filter
console.log(numbers.filter(n=>n%2==0));

// Reduce
console.log(numbers.reduce((sum,n)=>sum+=n));

// Object array
let apples = [{
    age : 3,
    color : "red",
    weight : 45
},{
    age : 4,
    color : "green",
    weight : 39
}]
console.log(apples);
console.log(...apples.filter(n=>n.weight>=11));
console.log(apples.reduce((sum,n)=>sum+=n.weight,0));