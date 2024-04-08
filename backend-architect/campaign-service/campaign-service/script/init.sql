-- Create Role table
CREATE TABLE "Role" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(255) NOT NULL
);

-- Create User table
CREATE TABLE "User" (
    "Id" SERIAL PRIMARY KEY,
    "UserName" VARCHAR(255) NOT NULL,
    "PasswordHash" VARCHAR(255) NOT NULL,
    "RoleId" INT NOT NULL,
    FOREIGN KEY ("RoleId") REFERENCES "Role"("Id")
);

-- Insert sample data into Role table
INSERT INTO "Role" ("Name") VALUES
('Admin'),
('User');

-- Insert sample data into User table
INSERT INTO "User" ("UserName", "PasswordHash", "RoleId") VALUES
('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1),
('user', '04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb', 2);


CREATE TABLE "Campaign" (
    "Id" SERIAL PRIMARY KEY,
    "Title" TEXT,
    "Description" TEXT,
    "StartDate" TIMESTAMP,
    "EndDate" TIMESTAMP,
    "UserId" INT,
    FOREIGN KEY ("UserId") REFERENCES "User"("Id")
);

CREATE INDEX Idx_Campaign_01 on "Campaign" ("UserId");
CREATE INDEX Idx_Campaign_02 on "Campaign" ("StartDate", "EndDate"); 