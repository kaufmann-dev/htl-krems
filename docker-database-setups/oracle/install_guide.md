# Install Guide Oracle Docker

### Files
- htlinsy.zip : Source Code für Oracle Docker 
- oracledb_image.tar : Fertig Gebuildetes Image
- docker-compose.yml : Compose file

## Selbst Kompilieren
htlinsy.zip extrahieren
terminal im root von htlinsy öffnen
´´´docker build . -t oracledb´´´ 
Das wird 15min dauern
´´´docker-compose up -d´´´
Startet den Container

## Fertige Image installieren
´´´docker load < oracledb_image.tar´´´
´´´docker-compose up -d´´´

