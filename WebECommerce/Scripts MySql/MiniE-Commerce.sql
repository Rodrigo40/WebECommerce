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
-- Editar Usuario
CREATE PROCEDURE `editarUsuario`(IN `nome` VARCHAR(50), IN `email` VARCHAR(100), IN `password` VARCHAR(50), IN `idTipo` INT, IN `id` INT) 
BEGIN
UPDATE usuario set nome=nome,email=email,password=password,idTipo=idTipo where id=id;
END
-- Eliminar Usuario
CREATE PROCEDURE `eliminarUsuario`(IN `id` INT) 
BEGIN
  DELETE FROM usuario where id=id;
END


----------------------------------------------------------------------------
-- Rotinas para Produtos

-- Listar Produto
CREATE PROCEDURE listarProduto() 
BEGIN 
   SELECT * FROM produto; 
END
-- Novo Produto
CREATE PROCEDURE `novoProduto`(IN `nome` VARCHAR(50), IN `preco` DECIMAL, IN `quantidade` INT, IN `desconto` INT, IN `imagem` VARCHAR(100))
BEGIN
 INSERT produto(nome,preco,quantidade,desconto,imagem)
 values(nome,preco,quantidade,desconto,imagem);
END
-- Editar Produto
CREATE PROCEDURE `editarProduto`(IN `id` INT, IN `nome` VARCHAR(50), IN `preco` DECIMAL, IN `quantidade` INT, IN `desconto` INT, IN `imagem` VARCHAR(100)) 
BEGIN
  UPDATE produto set nome=nome,preco=preco,quantidade=quantidade,desconto=desconto,imagem=imagem
  where id=id;
END
-- Eliminar Produto
CREATE PROCEDURE `eliminarProduto`(IN `id` INT) 
BEGIN
  DELETE FROM produto where id=id;
END
-- Listar Produto By ID
CREATE PROCEDURE `listarProdutoById`(IN `id` INT) 
BEGIN
  SELECT * FROM produto where id=id;
END
-----------------------------------------------------------------------------
-- Listar Tipo Usuario
CREATE PROCEDURE `listarTipoUsuario`() 
BEGIN
  SELECT * FROM tipousuario where id=id;
END
-- Novo Tipo Usuario
CREATE PROCEDURE `novoTipoUsuario`() 
BEGIN
 INSERT INTO tipousuario(tipo,descricao)values(tipo,descricao);
END
-- Editar Tpo Usuario
CREATE PROCEDURE `editarTipoUsuario`(IN `id` INT, IN `tipo` INT, IN `descricao` VARCHAR(50)) 
BEGIN 
 UPDATE tipousuario set tipo=tipo,descricao=descricao 
 where id=id; 
END
-- Eliminar Tpo Usuario
CREATE PROCEDURE `eliminarTipoUsuario`(IN `id` INT, IN `tipo` INT, IN `descricao` VARCHAR(50)) 
BEGIN 
 DELETE FROM tipousuario where id=id; 
END

