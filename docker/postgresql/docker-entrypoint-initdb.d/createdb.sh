#!/bin/bash

set -e
set -u

export PGUSER=root

function create_user_and_database() {
	local database=$1
    echo "Creating database '$database' and user"
	psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
	    CREATE USER "$database";
	    CREATE DATABASE "$database";
	    GRANT ALL PRIVILEGES ON DATABASE "$database" TO "$database";
EOSQL
}

create_user_and_database TestDB
