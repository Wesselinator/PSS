# small stripped down image
FROM node:14-alpine

# dir inside image
WORKDIR /usr/src/app

# copy the package file
COPY package*.json ./

# set development mode
ENV NODE_ENV=development
# set env port
ENV PORT=1337
# set env port
ENV HOST=0.0.0.0

# install npm packages in development mode
RUN npm install --development

# copy src files and folders acording to .dockerignore
COPY . .

# clean .js files incase they came along
RUN npm run-script clean
# build .js files from .ts
RUN npm run-script build

# publish port to docker
EXPOSE 1337

# set container entrypoint
CMD [ "npm", "start" ]
