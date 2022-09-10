CREATE TABLE usuario(
	id	VARCHAR(100) NOT NULL UNIQUE,
	[nome]	VARCHAR(255) NOT NULL,
	email	VARCHAR(255) NOT NULL UNIQUE,
	senha	VARCHAR(30) NOT NULL
);


INSERT INTO usuario (id, [nome], email, senha)
VALUES				 ('id-aleatorio-f9JpQSm12flH', 'admin', 'admin@email.com', 'admin123');
GO