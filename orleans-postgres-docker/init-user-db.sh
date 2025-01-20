#!/bin/bash
set -e

for sql_file in /orleans-scripts/**/*{Main,Clustering,Persistence,Reminders,Streaming}.sql; do
  echo "Processing: $sql_file"
  psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" < "$sql_file"
done

# migrations
for sql_file in /orleans-scripts/**/**/*{Clustering,Persistence,Reminders}*.sql; do
  echo "Processing: $sql_file"
  psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" < "$sql_file"
done