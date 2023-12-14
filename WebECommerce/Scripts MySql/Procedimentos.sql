DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ListarRelatorioPagamento`()
BEGIN
SELECT u.nome as cliente,pt.nome as produto,pt.preco,pt.quantidade,pt.imagem,
 p.total,p.dataPagamento,tp.tipo as tipoPagamento,
 pt.id
 FROM pagamentos p
 INNER JOIN produto pt on p.idProduto=pt.id
 INNER JOIN usuario u on p.idClinte=u.id
 INNER JOIN tipopagamento tp on p.idTipoPagamento=tp.id;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ListarRelatorioPagamentoByData`(IN `dataPagamento` VARCHAR(20))
BEGIN
SELECT u.nome as cliente,pt.nome as produto,pt.preco,pt.quantidade,pt.imagem,
 p.total,p.dataPagamento,tp.tipo as tipoPagamento,
 pt.id
 FROM pagamentos p
 INNER JOIN produto pt on p.idProduto=pt.id
 INNER JOIN usuario u on p.idClinte=u.id
 INNER JOIN tipopagamento tp on p.idTipoPagamento=tp.id
 where p.dataPagamento=dataPagamento;
 END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `editarProduto`(IN `id` INT, IN `nome` VARCHAR(50), IN `preco` DECIMAL, IN `quantidade` INT, IN `desconto` INT, IN `imagem` VARCHAR(100))
BEGIN
  UPDATE produto set nome=nome,preco=preco,quantidade=quantidade,desconto=desconto,imagem=imagem
  where id=id;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `editarTipoPagamento`(IN `id` INT(50), IN `tipo` VARCHAR(50), IN `descricao` VARCHAR(50))
BEGIN
UPDATE tipopagamento set tipo=tipo,descricao=descricao where id=id;
end$$
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
CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminarPagamento`(IN `id` INT)
BEGIN
DELETE from pagamentos where id=id;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminarProduto`(IN `id` INT)
BEGIN
  DELETE FROM produto where id=id;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminarTipoPagamento`(IN `id` INT)
BEGIN
DELETE from tipopagamento where id=id;
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
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarPagamento`()
BEGIN
SELECT * from pagamentos;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarPagamentoByData`(IN `dataPagamento` VARCHAR(20))
BEGIN
SELECT * FROM pagamentos WHERE dataPagamento=dataPagamento;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarPagamentoById`(IN `id` INT)
BEGIN
SELECT * from pagamentos where id=id;
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
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarTipoPagamento`()
BEGIN
select * from tipopagamento;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarTipoPagamentoById`(IN `id` INT)
BEGIN
SELECT * from tipopagamento where id=id;
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
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarUsuarioById`(IN `id` INT)
BEGIN
SELECT * FROM usuario where id=id;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `loginUsuario`(IN `email` VARCHAR(100), IN `password` VARCHAR(50))
BEGIN
SELECT * FROM usuario where email=email and password=password;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `novoPagamento`(IN `idProduto` INT(50), IN `idCliente` INT(50), IN `preco` DECIMAL, IN `quantidade` INT, IN `total` DECIMAL, IN `idTipoPagamento` INT, IN `dataPagamento` VARCHAR(20))
BEGIN
INSERT INTO pagamentos(idProduto,idClinte,preco,quantidade,total,idTipoPagamento,dataPagamento) 
values(idProduto,idCliente,preco,quantidade,total,idTipoPagamento,dataPagamento);
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `novoProduto`(IN `nome` VARCHAR(50), IN `preco` DECIMAL, IN `quantidade` INT, IN `desconto` INT, IN `imagem` VARCHAR(100), IN `dataCadastro` VARCHAR(20))
BEGIN
 INSERT produto(nome,preco,quantidade,desconto,imagem,dataCadastro)
 values(nome,preco,quantidade,desconto,imagem,dataCadastro);
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `novoTipoPagamento`(IN `tipo` VARCHAR(50), IN `descricao` VARCHAR(50))
BEGIN
INSERT INTO tipopagamento(tipo,descricao)values(tipo,descricao);
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

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `pesquisarProduto`(IN `nome` VARCHAR(50))
BEGIN
SELECT * FROM produto where nome like nome +'%';
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `pesquisarUsuario`(IN `nome` VARCHAR(50))
BEGIN
SELECT * FROM usuario WHERE nome like nome + '%';
END$$
DELIMITER ;
