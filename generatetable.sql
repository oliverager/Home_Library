CREATE SCHEMA library;

CREATE TABLE library.book(
    book_id SERIAL PRIMARY KEY,
    title VARCHAR(255) UNIQUE NOT NULL,
    author VARCHAR(50) NOT NULL,
    publisher VARCHAR(100),
    rating SMALLINT NOT NULL CHECK (rating > 0),
    spice_level SMALLINT NOT NULL CHECK (rating > 0),
    description TEXT,
    added_at TIMESTAMP NOT NULL                         
);