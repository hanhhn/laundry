FROM node:10.16.0 as node-env

COPY . /app
COPY package.json /app/package.json

WORKDIR /app

RUN npm install -g @angular/cli

RUN npm install

RUN ng build --prod

RUN cd dist/

RUN ng serve

# start app
CMD ng serve --host 0.0.0.0 --port 3000