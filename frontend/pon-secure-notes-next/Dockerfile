# ============================
#       BUILD STAGE
# ============================
FROM node:20-alpine AS build
WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .
RUN npm run build

# ============================
#       RUNTIME STAGE
# ============================
FROM node:20-alpine AS runner
WORKDIR /app

ENV NODE_ENV=production

COPY --from=build /app/.next ./.next
COPY --from=build /app/public ./public
COPY --from=build /app/package*.json ./

RUN npm install --omit=dev

EXPOSE 3000

CMD ["npm", "start"]