docker container stop PSS-ClientSatisfaction
docker container rm PSS-ClientSatisfaction
docker image rm pss-cs --force

docker build ./PSS-ClientSatisfaction -t pss-cs
docker create --name PSS-ClientSatisfaction --publish 1337:1337 pss-cs
docker container start PSS-ClientSatisfaction
start http://localhost:1337
PAUSE