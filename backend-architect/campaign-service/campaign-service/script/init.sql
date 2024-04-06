-- Create tables
CREATE TABLE IF NOT EXISTS users (
    id SERIAL PRIMARY KEY,
    user_name VARCHAR(50) NOT NULL,
    password_hash VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL,
    role_id numeric NOT NULL
);

CREATE TABLE IF NOT EXISTS roles (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);