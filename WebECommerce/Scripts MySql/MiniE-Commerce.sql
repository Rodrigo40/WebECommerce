BEGIN
SELECT u.nome,pt.nome,pt.preco,pt.quantidade,pt.imagem,
p.total,p.dataPagamento,tp.tipo
FROM pagamentos p
INNER JOIN produto pt on p.idProduto=pt.id
INNER JOIN usuario u on p.idClinte=u.id
INNER JOIN tipopagamento tp on p.idTipoPagamento=tp.id
END

INSERT INTO produto(nome,preco,quantidade,desconto,imagem) VALUES('IPHONE 10','1000000','40','0','5c778d11-e377-4dfb-8fab-89965c475ad6_insta-item3.jpg');

INSERT INTO produto(nome,preco,quantidade,desconto,imagem) VALUES('IPHONE 11','2000000','30','0','331a9ca0-8ccb-4840-bfc3-488f12c5d863_cart-item1.jpg');

INSERT INTO produto(nome,preco,quantidade,desconto,imagem) VALUES('IPHONE 12','3000000','10','0','881ac77c-adfa-4b32-ab1c-1e60bbbf026c_insta-item2.jpg');

INSERT INTO produto(nome,preco,quantidade,desconto,imagem) VALUES('IPHONE 13','4000000','60','0','76137cb0-d1e1-4c56-b776-7fbdf6f8455f_product-item5.jpg');

INSERT INTO produto(nome,preco,quantidade,desconto,imagem) VALUES('IPHONE 14','5000000','10','0','76137cb0-d1e1-4c56-b776-7fbdf6f8455f_product-item5.jpg');