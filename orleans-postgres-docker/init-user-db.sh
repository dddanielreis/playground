#!/bin/bash
set -e

for sql_file in /orleans-scripts/**/*Main*.sql; do
  psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" < "$sql_file"
done

for sql_file in /orleans-scripts/**/*Clustering*.sql; do
  psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" < "$sql_file"
done

for sql_file in /orleans-scripts/**/*Persistence*.sql; do
  psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" < "$sql_file"
done

for sql_file in /orleans-scripts/**/*Reminders*.sql; do
  psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" < "$sql_file"
done

for sql_file in /orleans-scripts/**/*Streaming*.sql; do
  psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" < "$sql_file"
done