CREATE TABLE IF NOT EXISTS authentication.users (
    id UUID PRIMARY KEY,
    name VARCHAR(150) NOT NULL,
    email VARCHAR(180) NOT NULL UNIQUE,
    password_hash TEXT NOT NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMP NOT NULL
);

CREATE TABLE IF NOT EXISTS authentication.anonymous_sessions (
    id UUID PRIMARY KEY,
    visitor_id VARCHAR(100) NOT NULL UNIQUE,
    user_id UUID NULL,
    created_at TIMESTAMP NOT NULL,
    last_seen_at TIMESTAMP NOT NULL,
    CONSTRAINT fk_anonymous_sessions_users
        FOREIGN KEY (user_id)
        REFERENCES authentication.users(id)
);

CREATE TABLE IF NOT EXISTS authentication.refresh_tokens (
    id UUID PRIMARY KEY,
    user_id UUID NOT NULL,
    token TEXT NOT NULL,
    expires_at TIMESTAMP NOT NULL,
    created_at TIMESTAMP NOT NULL,
    is_revoked BOOLEAN NOT NULL DEFAULT FALSE,
    CONSTRAINT fk_refresh_tokens_users
        FOREIGN KEY (user_id)
        REFERENCES authentication.users(id)
);