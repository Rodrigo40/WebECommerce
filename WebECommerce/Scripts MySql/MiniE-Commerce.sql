DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `editarProduto`(IN `id` INT, IN `nome` VARCHAR(50), IN `preco` DECIMAL, IN `quantidade` INT, IN `desconto` INT, IN `imagem` VARCHAR(100))
BEGIN
  UPDATE produto set nome=nome,preco=preco,quantidade=quantidade,desconto=desconto,imagem=imagem
  where id=id;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `editarTipoUsuario`(IN `id` INT, IN `tipo` INT, IN `descricao` VARCHAR(50))
BEGIN
UPDATE tipousuario set tipo=tipo,descricao=descricao where id=id;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `editarUsuario`(IN `nome` VARCHAR(50), IN `email` VARCHAR(100), IN `password` VARCHAR(50), IN `idTipo` INT, IN `id` INT)
BEGIN
UPDATE usuario set nome=nome,email=email,password=password,idTipo=idTipo where id=id;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminarProduto`(IN `id` INT)
BEGIN
  DELETE FROM produto where id=id;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminarTipoUsuario`(IN `id` INT)
BEGIN
DELETE FROM tipousuario where id=id;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminarUsuario`(IN `id` INT)
BEGIN
DELETE FROM usuario where id=id;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarProduto`()
BEGIN
SELECT * FROM produto;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarProdutoById`(IN `id` INT)
BEGIN
  SELECT * FROM produto where id=id;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarTipoUsuario`()
BEGIN
 SELECT * FROM tipousuario;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarUsuario`()
BEGIN
  SELECT * from usuario;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `loginUsuario`(IN `email` VARCHAR(100), IN `password` VARCHAR(50))
BEGIN
SELECT * FROM usuario where email=email and password=password;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `novoProduto`(IN `nome` VARCHAR(50), IN `preco` DECIMAL, IN `quantidade` INT, IN `desconto` INT, IN `imagem` VARCHAR(100))
BEGIN
 INSERT produto(nome,preco,quantidade,desconto,imagem)
 values(nome,preco,quantidade,desconto,imagem);
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `novoTipoUsuario`(IN `tipo` INT, IN `descricao` VARCHAR(50))
BEGIN
 INSERT INTO tipousuario(tipo,descricao) values(tipo,descricao);
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `novoUsuario`(IN `nome` VARCHAR(50), IN `email` VARCHAR(100), IN `password` VARCHAR(50), IN `idTipo` INT)
BEGIN
INSERT INTO usuario(nome,email,password,idTipo)
VALUES(nome,email,password,idTipo);
END$$
DELIMITER ;
