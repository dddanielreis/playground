FROM postgres:latest

WORKDIR /docker-entrypoint-initdb.d

COPY orleans/src/AdoNet /orleans-scripts

# Create a custom initialization script
COPY init-user-db.sh /docker-entrypoint-initdb.d/

# Make the script executable
RUN chmod +x /docker-entrypoint-initdb.d/init-user-db.sh

EXPOSE 5432