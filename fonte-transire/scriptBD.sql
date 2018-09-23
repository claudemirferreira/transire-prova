



CREATE TABLE [dbo].[Produtoes] (
    [ProdutoID] INT IDENTITY (1, 1) NOT NULL,
    [Nome]      NVARCHAR (100) NULL,
    CONSTRAINT [PK_dbo.Produtoes] PRIMARY KEY CLUSTERED ([ProdutoID] ASC)
);

CREATE PROCEDURE [dbo].[consultarProdutoPorNome]
	@nome varchar(50)
AS
	SELECT * from Produtoes 
	WHERE Nome like '%'+@nome+'%'
RETURN 0
