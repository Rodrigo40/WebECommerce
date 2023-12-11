BEGIN
SELECT u.nome,pt.nome,pt.preco,pt.quantidade,pt.imagem,
p.total,p.dataPagamento,tp.tipo
FROM pagamentos p
INNER JOIN produto pt on p.idProduto=pt.id
INNER JOIN usuario u on p.idClinte=u.id
INNER JOIN tipopagamento tp on p.idTipoPagamento=tp.id
END