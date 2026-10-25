const express = require("express");
const ejs = require("ejs");
const path = require("path");

const app = express();
const filepath = path.join(__dirname, "views");

app.set("views", filepath);
app.set("view engine", "ejs");

app.get("/", (req, res)=>{
    res.render("index.ejs", {
        productTitle: "Brückenbauer im Atlanktik",
        debitors: [
            {
                debitorName: "Kaufmann Inc.",
                contact: "Lil Kaufmann"
            },
            {
                debitorName: "TU Wien",
                contact: "Hermann Schröder"
            },
            {
                debitorName: "TU Graz",
                contact: "Til Vortman"
            }
        ]
    });
});

app.get("/console/:name", (req, res)=>{
    console.log(req.params.name);
    res.send("Hello console!");
});

app.listen(8080);