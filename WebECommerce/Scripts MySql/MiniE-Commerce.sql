-- Login Usuario
CREATE PROCEDURE `loginUsuario`(IN `email` VARCHAR(100), IN `password` VARCHAR(50)) 
BEGIN 
   SELECT * FROM usuario where email=email and password=password; 
END
-- Listar Usuario
CREATE PROCEDURE `listarUsuario`() 
BEGIN 
  SELECT * from usuario; 
END
-- Novo Usuario
CREATE PROCEDURE `novoUsuario`(IN `nome` VARCHAR(50), IN `email` VARCHAR(100), IN `password` VARCHAR(50), IN `idTipo` INT) 
BEGIN 
  INSERT INTO usuario(nome,email,password,idTipo) 
  VALUES(nome,email,password,idTipo); 
END