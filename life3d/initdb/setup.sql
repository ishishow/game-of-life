CREATE TABLE IF NOT EXISTS users (
    "id" VARCHAR(128) NOT NULL ,
    "auth_token" VARCHAR(128) NOT NULL,
    "name" VARCHAR(64) NOT NULL,
    PRIMARY KEY("id")
);

CREATE TABLE IF NOT EXISTS life_models (
    "id" VARCHAR(128) NOT NULL ,
    "user_id" VARCHAR(128) NOT NULL,
    "name" VARCHAR(64) NOT NULL,
    "life_map" TEXT NOT NULL,
    PRIMARY KEY("id")
);

CREATE TABLE IF NOT EXISTS favorites (
    "user_id" VARCHAR(128) NOT NULL,
    "life_model_id" VARCHAR(128) NOT NULL,
    UNIQUE ("user_id", "life_model_id")
);
