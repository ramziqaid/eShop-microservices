--mongo

docker run -d -p 27017:27017 --name shopping-mongo mongo
docker exec -it shopping-mongo /bin/bash

--
 docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
 docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down

 docker container run --d --p 8080:80 --name mvcapp webapplication1:dev
 
 docker run --name some-postgres -e POSTGRES_PASSWORD=openpgpwd -d postgres
 
 
 docker run -d -p 6379:6379 --name shopping-redis redis
 docker exec -it shopping-redis /bin/bash
 