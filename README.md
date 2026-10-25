# HTL Krems

Schoolwork from my five years in the IT department of [HTL Krems](https://www.htlkrems.ac.at/) (2018–2023), collected in one place. It covers software development in C#, web development, PHP, databases, AI, Rust and Unity.

Every top-level folder is a separate, self-contained project with its own build setup. Nothing is shared between folders, and there is no build at the repository root. Projects that existed in several versions keep only the most complete one.

Two school projects live in their own repositories:

- [jung-in-krems](https://github.com/kaufmann-dev/jung-in-krems): my diploma thesis project, commissioned by the city of Krems
- [async-cinema](https://github.com/kaufmann-dev/async-cinema): full-stack .NET film database with a REST API and a Blazor front end

## Running a project

Change into the project folder and use that stack's usual tooling:

- **C# (.NET)**: `dotnet run` in the folder containing the `.csproj`, or `dotnet test` next to the `.sln`. Most projects target .NET Core 3.1 or .NET 5–7, which are out of support. The first-year projects use .NET Framework 4.6.1 and need Windows or Mono.
- **Node and React**: `npm install`, then `npm start` or `node app.js`.
- **PHP and Laravel**: `composer install`, then serve with `php artisan serve` or any PHP-capable web server.
- **Static web pages**: open the `.html` file in a browser.
- **Databases**: run the `.sql`, `.mongodb.js` or `.cypher` scripts against the matching database. `docker-database-setups` has Compose files.
- **Unity**: open the folder with Unity 2021.3.
- **Jupyter**: open the notebooks in Jupyter or VS Code.

These projects were written as school exercises and have not been updated for current framework versions.

## Projects

### C# console games and simulations

| Project                                                 | Description                                                                                    |
| ------------------------------------------------------- | ---------------------------------------------------------------------------------------------- |
| [`aernautica-warhammer-sim`](aernautica-warhammer-sim/) | C# console game simulating Warhammer 40K aerial combat on a 3D grid with command-stack pattern |
| [`battlefield`](battlefield/)                           | C# console battlefield with unit types placed on a grid                                        |
| [`battleship-console`](battleship-console/)             | C# console Battleship with ship placement, damage tracking and unit tests                      |
| [`chess`](chess/)                                       | C# console chess with an OOP piece hierarchy and unit tests                                    |
| [`cinema`](cinema/)                                     | C# console cinema exercise                                                                     |
| [`combat-simulation`](combat-simulation/)               | C# combat simulation with terrain, archers, phalanxes and unit tests                           |
| [`connect-four-console`](connect-four-console/)         | C# console Connect Four                                                                        |
| [`duck-simulator`](duck-simulator/)                     | C# duck simulator demonstrating the strategy and adapter patterns                              |
| [`robot-remote-control`](robot-remote-control/)         | C# robot with a command-pattern remote control and unit tests                                  |
| [`shogun-battle-sim`](shogun-battle-sim/)               | C# simulation of Shogun-era battles between armies with dice-based ranged and melee combat     |
| [`tic-tac-toe-console`](tic-tac-toe-console/)           | C# console Tic-Tac-Toe with unit tests                                                         |
| [`tower-defense`](tower-defense/)                       | C# console tower defense                                                                       |
| [`train-network`](train-network/)                       | C# train network on a landscape grid with unit tests                                           |

### C# fundamentals and data structures

| Project                                                       | Description                                                                                               |
| ------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| [`basic-oop-csharp`](basic-oop-csharp/)                       | C# OOP fundamentals covering interfaces, factories, inheritance, linked lists, binary trees, and geometry |
| [`csharp-first-steps`](csharp-first-steps/)                   | First C# console programs and code snippets                                                               |
| [`decimal-to-binary`](decimal-to-binary/)                     | C# console decimal-to-binary converter                                                                    |
| [`dynamic-list`](dynamic-list/)                               | C# linked list implementation with unit tests                                                             |
| [`enum-practice`](enum-practice/)                             | C# enum review exercise built around a tile map                                                           |
| [`first-year-exams`](first-year-exams/)                       | First-year C# practice tests and exams                                                                    |
| [`graph-data-structure`](graph-data-structure/)               | C# generic graph and directed graph data structure library with adjacency matrix and unit tests           |
| [`linq-exercises-advanced`](linq-exercises-advanced/)         | C# LINQ exercises with domain entities, enums, factories, and unit tests for dish and trader queries      |
| [`linq-exercises-fundamentals`](linq-exercises-fundamentals/) | C# LINQ exercises querying dish, trader, and transaction datasets with unit tests                         |
| [`logic-gates`](logic-gates/)                                 | C# logic gate exercise                                                                                    |
| [`morse-code`](morse-code/)                                   | C# Morse code translator                                                                                  |
| [`oop-revision`](oop-revision/)                               | C# OOP revision with creatures, monsters and towers                                                       |
| [`second-year-exercises`](second-year-exercises/)             | Second-year C# exercises (classes, persons, shapes) and notes                                             |
| [`sine-plot`](sine-plot/)                                     | C# console sine curve plot                                                                                |
| [`sorting-algorithms-console`](sorting-algorithms-console/)   | Generic C# sorting algorithms using IComparable, with unit tests                                          |
| [`structs`](structs/)                                         | C# structs exercise                                                                                       |
| [`text-indexer`](text-indexer/)                               | C# text indexer and word analyzer with unit tests                                                         |
| [`tile-map-drawing`](tile-map-drawing/)                       | C# console tile map drawing exercise                                                                      |
| [`vector-exercises`](vector-exercises/)                       | C# vector and array exercises with unit tests                                                             |

### C# concurrency

| Project                                                     | Description                                                                                           |
| ----------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| [`bank-heist-async`](bank-heist-async/)                     | C# async/await bank heist simulation orchestrating parallel tasks with staged execution and timing    |
| [`barrier-sync-demo`](barrier-sync-demo/)                   | C# threading demo that synchronizes workers with a Barrier                                            |
| [`car-race-simulation`](car-race-simulation/)               | C# multithreaded car race simulation using SemaphoreSlim with pit stops and race manager coordination |
| [`conveyor-belt-sim`](conveyor-belt-sim/)                   | C# multithreaded conveyor belt simulation with semaphore-synchronized machine assembly line           |
| [`exam-vault-sim`](exam-vault-sim/)                         | C# multithreaded simulation of a student retrieving an exam from a vault with synchronized workflow   |
| [`factory-crane-sim`](factory-crane-sim/)                   | C# multithreaded factory simulation with a crane moving workpieces between synchronized machines      |
| [`ghost-train-parallel`](ghost-train-parallel/)             | C# parallel programming exercises with GhostTrain threading and async web downloads                   |
| [`kebab-shop-sim`](kebab-shop-sim/)                         | C# threading simulation of a kebab shop with cooks, cashiers and customers                            |
| [`mars-mission-sim`](mars-mission-sim/)                     | C# console app simulating a Mars mission with parallel Sentinel and Harvester threads                 |
| [`open-day-sim`](open-day-sim/)                             | C# console app simulating an open day event with concurrent StudentGuide and VisitorGroup threads     |
| [`parallel-programming-demos`](parallel-programming-demos/) | C# multithreading demos covering race conditions, deadlocks, and async task evaluation                |
| [`parallel-web-client`](parallel-web-client/)               | C# console app downloading HTML from multiple URLs in parallel with async Tasks and timing            |
| [`ship-port-sim`](ship-port-sim/)                           | C# console app for ship port logistics simulation with Ship and StagingArea management                |
| [`task-benchmarks`](task-benchmarks/)                       | C# console app benchmarking serial vs concurrent vs async/await task execution with Stopwatch         |
| [`threading-basics`](threading-basics/)                     | C# threading fundamentals with 100 concurrent Counter incrementers and Worker classes                 |

### C# EF Core, Blazor and web APIs

| Project                                                   | Description                                                                                              |
| --------------------------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| [`art-gallery-ef`](art-gallery-ef/)                       | C# Entity Framework Core project modeling artworks, artists, and epochs with MySQL persistence           |
| [`auction-house-blazor`](auction-house-blazor/)           | Blazor Server auction house app with artworks, customers, bidding, and EF Core repository pattern        |
| [`books-management-blazor`](books-management-blazor/)     | Blazor Server book management with authors, book types, and many-to-many relationships via EF Core       |
| [`chess-blazor`](chess-blazor/)                           | Blazor chess app written for a SEW test, split into Domain, Model and WebUI                              |
| [`circus-api`](circus-api/)                               | ASP.NET Core Web API for circus entity management with Swagger and MySQL persistence                     |
| [`circus-management-blazor`](circus-management-blazor/)   | Blazor Server circus management app with circuses and clowns using EF Core and repository pattern        |
| [`company-data-queries`](company-data-queries/)           | C# EF Core project modeling a company with employees, products, licenses, and LINQ query demos           |
| [`connect-four-blazor`](connect-four-blazor/)             | Blazor WebAssembly Connect Four game with 10x7 board and direction-based win detection                   |
| [`cruise-booking-blazor`](cruise-booking-blazor/)         | Blazor Server cruise booking system with ships, routes, cabins, and customer management via EF Core      |
| [`cruise-management-ef`](cruise-management-ef/)           | C# EF Core cruise line system with ships, harbors, routes, customers, bookings, and employee hierarchies |
| [`hospital-management-ef`](hospital-management-ef/)       | C# EF Core hospital system modeling wards, physicians, caretakers, and facilities with TPT inheritance   |
| [`imdb-blazor-api`](imdb-blazor-api/)                     | Blazor Server plus ASP.NET Core Web API for movie CRUD operations with MySQL and Swagger                 |
| [`juhk-chat`](juhk-chat/)                                 | Blazor chat app with EF Core, PGP keys and Monero repositories                                           |
| [`minesweeper-blazor`](minesweeper-blazor/)               | Blazor Server Minesweeper game with data models, NUnit tests, and Razor pages                            |
| [`mongodb-operators-blazor`](mongodb-operators-blazor/)   | Blazor Server app for managing MongoDB aggregation pipeline operators with full CRUD and code examples   |
| [`playbook-blazor`](playbook-blazor/)                     | Blazor Server app for managing books, authors, and story sections with full CRUD operations              |
| [`research-funding-ef`](research-funding-ef/)             | C# EF Core project modeling research funding with institutes, faculties, subprojects, and migrations     |
| [`research-projects-ef`](research-projects-ef/)           | C# EF Core app managing research projects, subprojects, funding, and institutes with LINQ queries        |
| [`sorting-algorithms-blazor`](sorting-algorithms-blazor/) | Blazor web app for visualizing and interacting with sorting algorithms with array controls               |
| [`steampunk-airships-blazor`](steampunk-airships-blazor/) | Blazor Server app displaying steampunk airship details with domain/repository pattern                    |
| [`stock-trader-blazor`](stock-trader-blazor/)             | Blazor Server plus ASP.NET Web API stock trading system with repositories and API controllers            |
| [`tic-tac-toe-blazor`](tic-tac-toe-blazor/)               | Blazor WebAssembly Tic-Tac-Toe game running in the browser via .NET WASM                                 |
| [`warehouse-ef`](warehouse-ef/)                           | EF Core warehouse with MySQL migrations                                                                  |

### HTML, CSS and JavaScript

| Project                                                 | Description                                                                                                  |
| ------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------ |
| [`bootstrap-exercises`](bootstrap-exercises/)           | Media query, Bootstrap component and mockup exercises                                                        |
| [`bootstrap-website`](bootstrap-website/)               | Multi-page Bootstrap website including a COVID checker page                                                  |
| [`html-css-basics`](html-css-basics/)                   | First-year HTML and CSS pages: recipe page, tile shop, single pagers, flexbox, image grid                    |
| [`javascript-basics`](javascript-basics/)               | JavaScript basics page                                                                                       |
| [`javascript-dom-exercises`](javascript-dom-exercises/) | JavaScript, DOM and jQuery exercises, an accordion and a landing page                                        |
| [`tic-tac-toe-js`](tic-tac-toe-js/)                     | Browser Tic-Tac-Toe in JavaScript                                                                            |
| [`typescript-oop-exercises`](typescript-oop-exercises/) | School TypeScript exercises demonstrating classes, inheritance, and a remote-controlled robot with undo/redo |
| [`xml-xslt-exercises`](xml-xslt-exercises/)             | XML/XSLT transformation exercises with datasets for companies, sports teams, families, and grades            |

### PHP, Laravel and WordPress

| Project                                                           | Description                                                                                            |
| ----------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------ |
| [`laravel-demo`](laravel-demo/)                                   | Laravel demo app with a projects dashboard                                                             |
| [`laravel-faker-seeding`](laravel-faker-seeding/)                 | Seeding a database table with Faker in PHP                                                             |
| [`laravel-file-sharing-platform`](laravel-file-sharing-platform/) | Secure file-sharing platform with user auth, email-based sharing, and sortable dashboard               |
| [`php-contact-form`](php-contact-form/)                           | PHP contact form with client-side validation for gender, name, email, address, and interests           |
| [`php-guestbook`](php-guestbook/)                                 | PHP guestbook with create and delete plus an AJAX test                                                 |
| [`php-js-exercises`](php-js-exercises/)                           | Web development coursework exercises covering AJAX, jQuery modals, PHP sessions, and OOP               |
| [`php-oop-bank-accounts`](php-oop-bank-accounts/)                 | PHP 7 OOP exercises (accounts, customers, interfaces) organized by chapter                             |
| [`php-smtp-mailer`](php-smtp-mailer/)                             | PHP script that sends HTML mail over SMTP with PHPMailer                                               |
| [`php-superglobals-demo`](php-superglobals-demo/)                 | PHP exercise demonstrating $_GET superglobals for page routing and dynamic grid generation             |
| [`php-wordpress-exercises`](php-wordpress-exercises/)             | PHP exercises and step-by-step WordPress plugin/theme development how-to guides                        |
| [`trackstar-issue-tracker`](trackstar-issue-tracker/)             | PHP project management tracker with full CRUD for projects and issues backed by MySQL                  |
| [`wordpress-plugin-development`](wordpress-plugin-development/)   | Full WordPress installation with custom plugin development exercises (date, post stats, registrations) |

### Node, React and mobile

| Project                                                 | Description                                                                                          |
| ------------------------------------------------------- | ---------------------------------------------------------------------------------------------------- |
| [`express-basics`](express-basics/)                     | First Express.js application                                                                         |
| [`ionic-intro`](ionic-intro/)                           | Ionic introduction page                                                                              |
| [`node-basics`](node-basics/)                           | Node.js core modules: fs, http, os, path and CommonJS                                                |
| [`pokemon-encounter-calc`](pokemon-encounter-calc/)     | Node.js Express app using EJS templates to calculate Pokemon encounter chances by location and level |
| [`react-counter`](react-counter/)                       | React counter app with increment, decrement, reset, and hold-to-rapidly-change functionality         |
| [`react-native-layout-demo`](react-native-layout-demo/) | React Native (Expo) app demonstrating Header, Content, and Footer component layout with StyleSheet   |
| [`react-routing-typescript`](react-routing-typescript/) | React + TypeScript app demonstrating client-side routing with react-router-dom v6                    |
| [`react-todo`](react-todo/)                             | React ToDo list app with components for adding, displaying, and managing todo items                  |
| [`trip-tracker-react`](trip-tracker-react/)             | React app for tracking trips with overview and statistics pages, using Bootstrap and Axios           |

### Databases

| Project                                             | Description                                                                                              |
| --------------------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| [`docker-database-setups`](docker-database-setups/) | Docker Compose setups for Oracle and for MySQL plus MongoDB                                              |
| [`er-diagram-models`](er-diagram-models/)           | MySQL Workbench ER diagrams for hospital, tournament, auction, school, webshop, and construction domains |
| [`mongodb-exercises`](mongodb-exercises/)           | MongoDB exercise collection covering DDL, DML, DQL operations, schema design, and a comprehensive guide  |
| [`neo4j-exercises`](neo4j-exercises/)               | Neo4j Cypher exercises: Vienna subway, movies dataset and a tram network                                 |
| [`sql-exercises`](sql-exercises/)                   | MySQL, Oracle and PL/SQL exercises covering DDL, DML, DQL and schema design                              |

### Rust, Unity and AI

| Project                                                                 | Description                                                                                                         |
| ----------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- |
| [`ai-exercises-advanced`](ai-exercises-advanced/)                       | Jupyter notebook AI/ML exercises covering artificial intelligence concepts and practical implementations            |
| [`ai-exercises-fundamentals`](ai-exercises-fundamentals/)               | Jupyter notebook exercises for AI coursework covering Python fundamentals through advanced concepts across 21 units |
| [`rust-exercises`](rust-exercises/)                                     | Rust exercises: borrowing, structs, traits, threads and number sequences                                            |
| [`unity-2d-intro`](unity-2d-intro/)                                     | Unity 2D introduction project with a player controller                                                              |
| [`unity-counter-strike-run-and-gun`](unity-counter-strike-run-and-gun/) | Unity 2D run-and-gun game with enemies and an enemy spawner                                                         |
