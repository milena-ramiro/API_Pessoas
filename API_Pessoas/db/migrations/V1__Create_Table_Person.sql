CREATE TABLE IF NOT EXISTS tbpessoa
(
	id bigint(20) NOT NULL AUTO_INCREMENT,
	first_name VARCHAR(80) NOT NULL,
    last_name VARCHAR(80) NOT NULL,
	gender VARCHAR(6) NOT NULL, 
	addres VARCHAR(100) NOT NULL,
    PRIMARY KEY(id)
);


use dbpessoas

