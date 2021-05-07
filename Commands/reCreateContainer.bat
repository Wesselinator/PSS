ECHO OFF
SETLOCAL
set "containerName=%1"
set "imageName=%2"
set "ports=%3"
set "dir=%4"

docker container stop %containerName%
docker container rm %containerName% --force
echo "Container removed..."
echo.
docker image rm %imageName% --force
echo "Image removed..."
echo.

docker build %dir% -t %imageName%
echo "Image Built..."
echo.
docker create --name %containerName% --publish %ports% %imageName%
echo "Container Created..."
echo.
docker container start %containerName%
echo "Container Started!"
echo.

ENDLOCAL
ECHO ON
