#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    \i /PostgreSQL-Main.sql
    \i /PostgreSQL-Clustering.sql
    \i /PostgreSQL-Persistence.sql
    \i /PostgreSQL-Reminders.sql
EOSQL