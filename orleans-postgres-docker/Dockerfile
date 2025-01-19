FROM postgres:latest

WORKDIR /docker-entrypoint-initdb.d

COPY orleans/src/AdoNet/Shared/PostgreSQL-Main.sql /
COPY orleans/src/AdoNet/Orleans.Clustering.AdoNet/PostgreSQL-Clustering.sql /
COPY orleans/src/AdoNet/Orleans.Persistence.AdoNet/PostgreSQL-Persistence.sql /
COPY orleans/src/AdoNet/Orleans.Reminders.AdoNet/PostgreSQL-Reminders.sql /

# Create a custom initialization script
COPY init-user-db.sh /docker-entrypoint-initdb.d/

# Make the script executable
RUN chmod +x /docker-entrypoint-initdb.d/init-user-db.sh

EXPOSE 5432