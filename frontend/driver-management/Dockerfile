FROM node:18-alpine3.14

WORKDIR /react-vite-app

COPY package.json package-lock.json ./

RUN npm install --silent

EXPOSE 3001

COPY . ./

# CMD ["npm", "run", "dev", "--", "--port", "3000"]


