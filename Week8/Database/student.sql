CREATE TABLE student (
	student_id SERIAL PRIMARY KEY,
	student_name VARCHAR(64),
	student_email VARCHAR(64),
	student_oit_id integer NOT NULL
);