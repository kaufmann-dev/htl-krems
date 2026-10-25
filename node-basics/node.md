# Node.js

## 1. Beispiel:
```
const amount = 14;

if(amount==14){
    console.log("amount is 14");
} else {
    console.log("amount is not 14");
}
```
## 2. Beispiel: Globale Variablen und Funktionen

### Variablen
```
__firname;
__filename;
process;
```
### Funktionen
```
function require()
```

### Module laden
```
function module()
```
## 3. Beispiel: Module
### Exkurs: C#

Klasse, welche die main methode enthält, muss angegeben werden
Program execution thread führt methode aus, arbeitet Zeile für zeile den Code ab
#### Class loader
Für jede Klasse die in der using derektive angegebn ist wird im Speicher ein Klassenobjekt angelegt

alles was man als static definiert gehört dem klassenobjekt
class loader legt es an

### Node
In Node wird jedes File (z. B. ```app.js```) als Modul eingestuft. Node führt immer nur ein File aus. Um Funktion von einem anderen Modul zu benutzen muss man dieses File mit ```require``` angeben. Module die mit ```require``` referenziert werden, werden auch vollständig ausgeführt.

```sayhi.js```:
```
function sayHi(hombo){
    console.log(hombo);
}
console.log(module);

module.exports={sayHi, PI : 3.14};
```
```app.js```:
```
const f = require("./sayhi.js");

f.sayHi("Hallo Bratan!");
console.log(f.PI);
```
## 4. Beispiel: CommonJS Module
- **os** - Operating System
- **path** - file seperator - Generiert Pfadnamen im Programm
- **fs** - filesystem - read write - Dateiverwaltung
- **http** - Server starten, request response, Backend programmieren