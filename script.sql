USE [BD_INTER]
GO
/****** Object:  UserDefinedFunction [dbo].[udf_ClienteInformacoes]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[udf_ClienteInformacoes] (@NOME VARCHAR(50))

RETURNS @Cliente TABLE (COD_CLIENTE INT, CLI_NOME VARCHAR(50), CLI_CPF VARCHAR(50), CLI_DTNASC DATETIME, 
						CLI_SEXO CHAR, END_RUA VARCHAR(50), END_BAIRRO VARCHAR(50), END_CIDADE VARCHAR(50),
						END_NUMERO VARCHAR(10), END_CEP VARCHAR(8), END_UF VARCHAR(2), TEL_NUMERO VARCHAR(11)) 
AS

BEGIN

INSERT @Cliente SELECT C.COD_CLIENTE, C.CLI_NOME,C.CLI_CPF, C.CLI_DTNASC, C.CLI_SEXO, E.END_RUA, E.END_BAIRRO, E.END_CIDADE,
					   E.END_NUMERO, E.END_CEP, E.END_UF,T.TEL_NUMERO FROM CLIENTE C, ENDERECO E, TELEFONE T

WHERE C.CLI_NOME = @NOME AND C.COD_ENDERECO = E.COD_ENDERECO AND C.COD_TELEFONE = T.COD_TELEFONE
RETURN 
END
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[COD_CLIENTE] [int] IDENTITY(1,1) NOT NULL,
	[CLI_NOME] [varchar](50) NOT NULL,
	[CLI_SOBRENOME] [varchar](50) NOT NULL,
	[CLI_CPF] [varchar](11) NOT NULL,
	[CLI_DTNASC] [datetime] NOT NULL,
	[CLI_SEXO] [char](1) NULL,
	[COD_ENDERECO] [int] NOT NULL,
	[COD_TELEFONE] [int] NOT NULL,
	[CLI_ATIVO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[COD_CLIENTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DISTRIBUIDORA]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DISTRIBUIDORA](
	[COD_DISTRIBUIDORA] [int] IDENTITY(1,1) NOT NULL,
	[DIST_NOME] [varchar](30) NOT NULL,
	[DIST_CNPJ] [varchar](30) NOT NULL,
	[COD_TELEFONE] [int] NOT NULL,
	[COD_ENDERECO] [int] NOT NULL,
	[STATUS] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[COD_DISTRIBUIDORA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ENDERECO]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ENDERECO](
	[COD_ENDERECO] [int] IDENTITY(1,1) NOT NULL,
	[END_RUA] [varchar](50) NOT NULL,
	[END_BAIRRO] [varchar](50) NOT NULL,
	[END_CIDADE] [varchar](50) NOT NULL,
	[END_NUMERO] [varchar](10) NOT NULL,
	[END_CEP] [char](10) NOT NULL,
	[END_UF] [char](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[COD_ENDERECO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ESTOQUE]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTOQUE](
	[COD_ESTOQUE] [int] IDENTITY(1,1) NOT NULL,
	[EST_QUANTIDADE] [int] NOT NULL,
	[COD_PRODUTO] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[COD_ESTOQUE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FABRICANTE]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FABRICANTE](
	[COD_FABRICANTE] [int] IDENTITY(1,1) NOT NULL,
	[FABR_NOME] [varchar](30) NOT NULL,
	[FABRI_ATIVO] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[COD_FABRICANTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FUNCIONARIO]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FUNCIONARIO](
	[COD_FUNCIONARIO] [int] IDENTITY(1,1) NOT NULL,
	[FUNC_NOME] [varchar](50) NOT NULL,
	[FUNC_SOBRENOME] [varchar](50) NOT NULL,
	[FUNC_ATIVO] [bit] NOT NULL,
	[COD_ENDERECO] [int] NOT NULL,
	[COD_TELEFONE] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[COD_FUNCIONARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUTO]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUTO](
	[COD_PRODUTO] [int] IDENTITY(1,1) NOT NULL,
	[PROD_NOME] [varchar](30) NOT NULL,
	[PROD_VALOR] [decimal](18, 0) NOT NULL,
	[PROD_ATIVO] [bit] NOT NULL,
	[COD_FABRICANTE] [int] NOT NULL,
	[COD_DISTRIBUIDORA] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[COD_PRODUTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TELEFONE]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TELEFONE](
	[COD_TELEFONE] [int] IDENTITY(1,1) NOT NULL,
	[TEL_NUMERO] [varchar](11) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[COD_TELEFONE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CLIENTE]  WITH CHECK ADD FOREIGN KEY([COD_ENDERECO])
REFERENCES [dbo].[ENDERECO] ([COD_ENDERECO])
GO
ALTER TABLE [dbo].[CLIENTE]  WITH CHECK ADD FOREIGN KEY([COD_TELEFONE])
REFERENCES [dbo].[TELEFONE] ([COD_TELEFONE])
GO
ALTER TABLE [dbo].[DISTRIBUIDORA]  WITH CHECK ADD FOREIGN KEY([COD_ENDERECO])
REFERENCES [dbo].[ENDERECO] ([COD_ENDERECO])
GO
ALTER TABLE [dbo].[DISTRIBUIDORA]  WITH CHECK ADD FOREIGN KEY([COD_TELEFONE])
REFERENCES [dbo].[TELEFONE] ([COD_TELEFONE])
GO
ALTER TABLE [dbo].[ESTOQUE]  WITH CHECK ADD FOREIGN KEY([COD_PRODUTO])
REFERENCES [dbo].[PRODUTO] ([COD_PRODUTO])
GO
ALTER TABLE [dbo].[FUNCIONARIO]  WITH CHECK ADD FOREIGN KEY([COD_ENDERECO])
REFERENCES [dbo].[ENDERECO] ([COD_ENDERECO])
GO
ALTER TABLE [dbo].[FUNCIONARIO]  WITH CHECK ADD FOREIGN KEY([COD_TELEFONE])
REFERENCES [dbo].[TELEFONE] ([COD_TELEFONE])
GO
ALTER TABLE [dbo].[PRODUTO]  WITH CHECK ADD FOREIGN KEY([COD_DISTRIBUIDORA])
REFERENCES [dbo].[DISTRIBUIDORA] ([COD_DISTRIBUIDORA])
GO
ALTER TABLE [dbo].[PRODUTO]  WITH CHECK ADD FOREIGN KEY([COD_FABRICANTE])
REFERENCES [dbo].[FABRICANTE] ([COD_FABRICANTE])
GO
/****** Object:  StoredProcedure [dbo].[SP_ALTERAR_CLIENTES]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ALTERAR_CLIENTES]
@COD_CLIENTE INT,
@CLI_NOME VARCHAR(50),
@CLI_SOBRENOME VARCHAR(50),
@CLI_CPF VARCHAR (11),
@CLI_DTNASC DATETIME,
@CLI_SEXO CHAR(1),

@END_RUA VARCHAR(50),
@END_BAIRRO VARCHAR(50),
@END_CIDADE VARCHAR(50),
@END_NUMERO VARCHAR(10),
@END_CEP VARCHAR(8),
@END_UF VARCHAR(2),

@TEL_TELEFONE VARCHAR(11)
as
begin
	begin try
		begin transaction

			if(@CLI_NOME is not null and @CLI_NOME <> '' and
			   @CLI_SOBRENOME is not null and @CLI_SOBRENOME <> '' and
			   @CLI_CPF is not null and @CLI_CPF <> '' and
			   @CLI_DTNASC is not null and @CLI_DTNASC <> '' and
			   @CLI_SEXO is not null and @CLI_SEXO <> '' and

			   @END_RUA is not null and @END_RUA <> '' and
			   @END_BAIRRO is not null and @END_BAIRRO <> '' and
			   @END_CIDADE is not null and @END_CIDADE <> '' and
			   @END_NUMERO is not null and @END_NUMERO <> '' and
			   @END_CEP is not null and @END_CEP <> '' and
			   @END_UF is not null and @END_UF <> '' and

			     @TEL_TELEFONE is not null and @TEL_TELEFONE <> '')

					begin
					DECLARE @IDTelefone INT;
					SET @IDTelefone = (SELECT COD_TELEFONE FROM CLIENTE WHERE COD_CLIENTE = @COD_CLIENTE);
					UPDATE TELEFONE SET TEL_NUMERO = @TEL_TELEFONE WHERE COD_TELEFONE = @IDTelefone;

					DECLARE @IDEndereco INT;
					SET @IDEndereco = (SELECT COD_ENDERECO FROM CLIENTE WHERE COD_CLIENTE = @COD_CLIENTE);
					UPDATE ENDERECO SET END_RUA = @END_RUA, END_BAIRRO = @END_BAIRRO, END_NUMERO = @END_NUMERO, END_CIDADE = @END_CIDADE WHERE COD_ENDERECO = @IDEndereco;
					
					UPDATE CLIENTE set  CLI_NOME = (@CLI_NOME),CLI_SOBRENOME = (@CLI_SOBRENOME),CLI_CPF = (@CLI_CPF),
					CLI_DTNASC = (@CLI_DTNASC), CLI_SEXO = (@CLI_SEXO) 
					WHERE COD_CLIENTE = @COD_CLIENTE;
			end
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ALTERAR_DISTRIBUIDORA]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_ALTERAR_DISTRIBUIDORA]
@COD_DISTRIBUIDORA INT,
@DIST_NOME VARCHAR(30),
@DIST_CNPJ VARCHAR(30),
@END_RUA VARCHAR(50),
@END_BAIRRO VARCHAR(50),
@END_CIDADE VARCHAR(50),
@END_NUMERO VARCHAR(10),
@END_CEP CHAR(9),
@END_UF CHAR(2),
@TEL_NUMERO VARCHAR(11)
as
begin
	begin try
		begin transaction
			if(@COD_DISTRIBUIDORA is not null and @COD_DISTRIBUIDORA <> '' and
			   @DIST_NOME is not null and @DIST_NOME <> '' and
		       @DIST_CNPJ is not null and @DIST_CNPJ <> '' and
			   @TEL_NUMERO  is not null and @TEL_NUMERO <> '' and
			   @END_RUA is not null and @END_RUA <>''and
			   @END_BAIRRO is not null and @END_BAIRRO <> '' and
			   @END_CIDADE IS NOT NULL AND @END_CIDADE <> '' AND
			   @END_NUMERO is not null and @END_NUMERO <>'' and
			   @END_CEP is not null and @END_CEP <>'' and
			   @END_UF IS NOT NULL AND @END_UF <>'' AND
			   @TEL_NUMERO IS NOT NULL AND @TEL_NUMERO <>'' )
					begin

					DECLARE @IDTelefone INT;
					SET @IDTelefone = (SELECT COD_TELEFONE FROM DISTRIBUIDORA WHERE COD_DISTRIBUIDORA = @COD_DISTRIBUIDORA);
					UPDATE TELEFONE SET TEL_NUMERO = @TEL_NUMERO WHERE COD_TELEFONE = @IDTelefone;

					DECLARE @IDENDERECO INT;
					SET	@IDENDERECO = (SELECT COD_ENDERECO FROM DISTRIBUIDORA WHERE COD_DISTRIBUIDORA = @COD_DISTRIBUIDORA);
					UPDATE ENDERECO SET END_RUA = @END_RUA, END_BAIRRO = @END_BAIRRO,END_CIDADE = @END_CIDADE,
					END_NUMERO = @END_NUMERO, END_CEP = @END_CEP, END_UF = @END_UF

					UPDATE DISTRIBUIDORA set DIST_NOME = (@DIST_NOME), DIST_CNPJ = (@DIST_CNPJ)
					WHERE COD_DISTRIBUIDORA = (@COD_DISTRIBUIDORA);
					SELECT @COD_DISTRIBUIDORA AS retorno
			end
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ALTERAR_FABRICANTE]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_ALTERAR_FABRICANTE]
@COD_FABRICANTE INT,
@FABR_NOME VARCHAR(30)
as
begin
	begin try
		begin transaction
			if(@FABR_NOME is not null and @FABR_NOME <> '')
					begin
					update FABRICANTE set  FABR_NOME = (@FABR_NOME)
					WHERE COD_FABRICANTE = (@COD_FABRICANTE);
					SELECT @COD_FABRICANTE AS RETORNO
			end
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ALTERAR_FUNCIONARIOS]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_ALTERAR_FUNCIONARIOS]
@COD_FUNCIONARIO INT,
@FUNC_NOME VARCHAR(50),
@FUNC_SOBRENOME VARCHAR(50),

@END_RUA VARCHAR(50),
@END_BAIRRO VARCHAR(50),
@END_CIDADE VARCHAR(50),
@END_NUMERO VARCHAR(20),
@END_CEP CHAR (8),
@END_UF VARCHAR (2),
@TEL_NUMERO VARCHAR(11)
as
begin
	begin try
		begin transaction

			if(@FUNC_NOME is not null and @FUNC_NOME <> '' and
			   @FUNC_SOBRENOME is not null and @FUNC_SOBRENOME <> '' and
			   @TEL_NUMERO is not null and @TEL_NUMERO <> '' and
			   @END_RUA is not null and @END_RUA <> '' and
			   @END_BAIRRO is not null and @END_BAIRRO <> '' and
			   @END_CIDADE is not null and @END_CIDADE <> '' and
			   @END_NUMERO is not null and @END_NUMERO <> '' and @END_CEP is not null and
			   @END_CEP <>'' and @END_UF is not null and @END_UF <>'' and @TEL_NUMERO is not null
			   and @TEL_NUMERO <>'')
					begin
					DECLARE @IDTelefone INT;
					SET @IDTelefone = (SELECT COD_TELEFONE FROM FUNCIONARIO WHERE COD_FUNCIONARIO = @COD_FUNCIONARIO);
					UPDATE TELEFONE SET TEL_NUMERO = @TEL_NUMERO WHERE COD_TELEFONE = @IDTelefone;

					DECLARE @IDEndereco INT;
					SET @IDEndereco = (SELECT COD_ENDERECO FROM FUNCIONARIO WHERE COD_FUNCIONARIO = @COD_FUNCIONARIO);
					UPDATE ENDERECO SET END_RUA = @END_RUA, END_BAIRRO = @END_BAIRRO, END_NUMERO = @END_NUMERO, END_CIDADE = @END_CIDADE, END_CEP = @END_CEP, END_UF = @END_UF WHERE COD_ENDERECO = @IDEndereco;
					
					UPDATE FUNCIONARIO set  FUNC_NOME = (@FUNC_NOME),FUNC_SOBRENOME = (@FUNC_SOBRENOME) 
					WHERE COD_FUNCIONARIO = (@COD_FUNCIONARIO);
			end
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ALTERAR_PRODUTO]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ALTERAR_PRODUTO]
@COD_PRODUTO INT,
@PROD_NOME VARCHAR(30),
@PROD_VALOR DECIMAL,
@COD_FABRICANTE INT,
@COD_DISTRIBUIDORA INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			IF(@PROD_NOME IS NOT NULL AND @PROD_NOME <> '' AND
		       @PROD_VALOR IS NOT NULL AND		       
		       @COD_FABRICANTE IS NOT NULL AND @COD_FABRICANTE <> '' AND
		       @COD_DISTRIBUIDORA IS NOT NULL AND @COD_DISTRIBUIDORA <> '')
					BEGIN
					UPDATE PRODUTO SET PROD_NOME = @PROD_NOME, PROD_VALOR = @PROD_VALOR, @COD_FABRICANTE = @COD_FABRICANTE,@COD_DISTRIBUIDORA = @COD_DISTRIBUIDORA
					WHERE COD_PRODUTO = (@COD_PRODUTO);
			END
		COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_CLIENTES]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_CLIENTES]
as
begin
	begin try
		begin transaction
			SELECT CLIENTE.COD_CLIENTE, CLIENTE.CLI_NOME, CLIENTE.CLI_SOBRENOME, CLIENTE.CLI_CPF, CLIENTE.CLI_DTNASC, CLIENTE.CLI_SEXO, CLIENTE.CLI_ATIVO,
			TELEFONE.TEL_NUMERO,
			ENDERECO.END_RUA, ENDERECO.END_BAIRRO, ENDERECO.END_CIDADE, ENDERECO.END_NUMERO, ENDERECO.END_CEP, ENDERECO.END_UF
			FROM CLIENTE
			INNER JOIN ENDERECO ON CLIENTE.COD_ENDERECO = ENDERECO.COD_ENDERECO
			INNER JOIN TELEFONE ON CLIENTE.COD_TELEFONE = TELEFONE.COD_TELEFONE
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_CODIGO_CLIENTES]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_CODIGO_CLIENTES]
@COD_CLIENTE INT
AS
BEGIN
	begin try
		begin transaction
			SELECT CLIENTE.CLI_NOME, CLIENTE.CLI_SOBRENOME, CLIENTE.CLI_CPF, CLIENTE.CLI_DTNASC, CLIENTE.CLI_ATIVO,
			TELEFONE.TEL_NUMERO,
			ENDERECO.END_RUA, ENDERECO.END_BAIRRO, ENDERECO.END_CIDADE, ENDERECO.END_NUMERO, ENDERECO.END_CEP, ENDERECO.END_UF
			FROM CLIENTE
			INNER JOIN ENDERECO ON CLIENTE.COD_ENDERECO = ENDERECO.COD_ENDERECO
			INNER JOIN TELEFONE ON CLIENTE.COD_TELEFONE = TELEFONE.COD_TELEFONE
			 WHERE @COD_CLIENTE = COD_CLIENTE
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_DISTRIBUIDORA]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_DISTRIBUIDORA]
as
begin
	begin try
		begin transaction
			SELECT DISTRIBUIDORA.COD_DISTRIBUIDORA, DISTRIBUIDORA.DIST_NOME, DISTRIBUIDORA.DIST_CNPJ, TELEFONE.TEL_NUMERO
			FROM DISTRIBUIDORA
			INNER JOIN TELEFONE ON DISTRIBUIDORA.COD_TELEFONE = TELEFONE.COD_TELEFONE
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_FABRICANTE]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_FABRICANTE]
as
begin
	begin try
		begin transaction
			SELECT * FROM FABRICANTE
			WHERE FABRI_ATIVO = 1
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_FUNCIONARIO_POR_ID]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_FUNCIONARIO_POR_ID]
@ID INT 
as
begin
	begin try
		begin transaction
			SELECT F.COD_FUNCIONARIO, F.FUNC_NOME, F.FUNC_SOBRENOME, E.END_RUA, E.END_BAIRRO,
			E.END_CIDADE, E.END_NUMERO, E.END_CEP, E.END_UF, T.TEL_NUMERO   FROM FUNCIONARIO F, ENDERECO E, TELEFONE T
			WHERE F.FUNC_ATIVO = 1 AND F.COD_FUNCIONARIO = @ID AND F.COD_ENDERECO = E.COD_ENDERECO AND F.COD_TELEFONE = T.COD_TELEFONE 
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_FUNCIONARIO_POR_NOME]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_FUNCIONARIO_POR_NOME]
@NOME VARCHAR(30) 
as
begin
	begin try
		begin transaction
			SELECT F.COD_FUNCIONARIO, F.FUNC_NOME, F.FUNC_SOBRENOME, E.END_RUA, E.END_BAIRRO,
			E.END_CIDADE, E.END_NUMERO, E.END_CEP, E.END_UF, T.TEL_NUMERO   FROM FUNCIONARIO F, ENDERECO E, TELEFONE T
			WHERE F.FUNC_ATIVO = 1 AND F.COD_ENDERECO = E.COD_ENDERECO AND F.COD_TELEFONE = T.COD_TELEFONE AND F.FUNC_NOME LIKE '%'+@NOME+'%' 
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_PRODUTO_POR_ID]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_PRODUTO_POR_ID]
@IdProduto INT
as
begin
	begin try
		begin transaction
			SELECT P.COD_PRODUTO, P.PROD_NOME, P.PROD_VALOR, E.EST_QUANTIDADE, F.FABR_NOME, D.DIST_NOME 
			FROM   PRODUTO P, FABRICANTE F, DISTRIBUIDORA D, ESTOQUE E 
			WHERE  P.COD_PRODUTO = @IdProduto AND P.COD_DISTRIBUIDORA = D.COD_DISTRIBUIDORA 
			AND    P.COD_FABRICANTE = F.COD_FABRICANTE 
			AND    P.COD_PRODUTO = E.COD_PRODUTO 
			AND P.PROD_ATIVO = 1
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_PRODUTO_POR_NOME]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_PRODUTO_POR_NOME]
@Nome VARCHAR(50)
as
begin
	begin try
		begin transaction
			SELECT P.COD_PRODUTO, P.PROD_NOME, P.PROD_VALOR, E.EST_QUANTIDADE, F.FABR_NOME, D.DIST_NOME 
			FROM   PRODUTO P, FABRICANTE F, DISTRIBUIDORA D, ESTOQUE E 
			WHERE  P.PROD_NOME LIKE '%'+@Nome+'%'
			AND    P.COD_DISTRIBUIDORA = D.COD_DISTRIBUIDORA 
			AND    P.COD_FABRICANTE = F.COD_FABRICANTE 
			AND    P.COD_PRODUTO = E.COD_PRODUTO
			AND P.PROD_ATIVO = 1
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_TODOS_FUNCIONARIOS]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_TODOS_FUNCIONARIOS]

as
begin
	begin try
		begin transaction
			SELECT F.COD_FUNCIONARIO, F.FUNC_NOME, F.FUNC_SOBRENOME, E.END_RUA, E.END_BAIRRO,
			E.END_CIDADE, E.END_NUMERO, E.END_CEP, E.END_UF, T.TEL_NUMERO   FROM FUNCIONARIO F, ENDERECO E, TELEFONE T
			WHERE F.FUNC_ATIVO = 1 AND F.COD_ENDERECO = E.COD_ENDERECO AND F.COD_TELEFONE = T.COD_TELEFONE
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_TODOS_PRODUTOS]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTAR_TODOS_PRODUTOS]
as
begin
	begin try
		begin transaction
			SELECT P.COD_PRODUTO, P.PROD_NOME, P.PROD_VALOR, E.EST_QUANTIDADE, F.FABR_NOME, D.DIST_NOME 
			FROM   PRODUTO P, FABRICANTE F, DISTRIBUIDORA D, ESTOQUE E 
			WHERE  P.COD_DISTRIBUIDORA = D.COD_DISTRIBUIDORA 
			AND    P.COD_FABRICANTE = F.COD_FABRICANTE   
			AND    P.COD_PRODUTO = E.COD_PRODUTO
			AND P.PROD_ATIVO = 1
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTARID_DISTRIBUIDORA]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTARID_DISTRIBUIDORA]
@COD_DISTRIBUIDORA INT
as
begin
	begin try
		begin transaction
			SELECT DISTRIBUIDORA.COD_DISTRIBUIDORA, DISTRIBUIDORA.DIST_NOME, DISTRIBUIDORA.DIST_CNPJ, ENDERECO.END_RUA, ENDERECO.END_BAIRRO,
			ENDERECO.END_CIDADE, ENDERECO.END_NUMERO, ENDERECO.END_CEP, ENDERECO.END_UF, TELEFONE.TEL_NUMERO
			FROM DISTRIBUIDORA, ENDERECO, TELEFONE WHERE DISTRIBUIDORA.COD_DISTRIBUIDORA = @COD_DISTRIBUIDORA
			AND DISTRIBUIDORA.COD_TELEFONE = TELEFONE.COD_TELEFONE 
			AND DISTRIBUIDORA.COD_ENDERECO = ENDERECO.COD_ENDERECO
			and DISTRIBUIDORA.STATUS = 1
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTARID_FABRICANTE]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTARID_FABRICANTE]
@COD_FABRICANTE varchar(50)
as
begin
	begin try
		begin transaction
			SELECT * FROM FABRICANTE
			WHERE FABRI_ATIVO = 1 and COD_FABRICANTE = @COD_FABRICANTE
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTARNOME_DISTRIBUIDORA]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTARNOME_DISTRIBUIDORA]
@DIST_NOME VARCHAR(50)
as
begin
	begin try
		begin transaction
			SELECT DISTRIBUIDORA.COD_DISTRIBUIDORA, DISTRIBUIDORA.DIST_NOME, DISTRIBUIDORA.DIST_CNPJ, ENDERECO.END_RUA, ENDERECO.END_BAIRRO,
			ENDERECO.END_CIDADE, ENDERECO.END_NUMERO, ENDERECO.END_CEP, ENDERECO.END_UF, TELEFONE.TEL_NUMERO
			FROM DISTRIBUIDORA, ENDERECO, TELEFONE WHERE DISTRIBUIDORA.DIST_NOME = @DIST_NOME
			AND DISTRIBUIDORA.COD_TELEFONE = TELEFONE.COD_TELEFONE 
			AND DISTRIBUIDORA.COD_ENDERECO = ENDERECO.COD_ENDERECO
			AND DISTRIBUIDORA.STATUS = 1
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTARNOME_FABRICANTE]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTARNOME_FABRICANTE]
@FABR_NOME varchar(50)
as
begin
	begin try
		begin transaction
			SELECT * FROM FABRICANTE
			WHERE FABRI_ATIVO = 1 and FABR_NOME = @FABR_NOME
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTARTODOS_DISTRIBUIDORA]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTARTODOS_DISTRIBUIDORA]
as
begin
	begin try
		begin transaction
			SELECT DISTRIBUIDORA.COD_DISTRIBUIDORA, DISTRIBUIDORA.DIST_NOME, DISTRIBUIDORA.DIST_CNPJ, ENDERECO.END_RUA, ENDERECO.END_BAIRRO,
			ENDERECO.END_CIDADE, ENDERECO.END_NUMERO, ENDERECO.END_CEP, ENDERECO.END_UF, TELEFONE.TEL_NUMERO
			FROM DISTRIBUIDORA
			INNER JOIN TELEFONE ON DISTRIBUIDORA.COD_TELEFONE = TELEFONE.COD_TELEFONE
			INNER JOIN ENDERECO ON DISTRIBUIDORA.COD_ENDERECO = ENDERECO.COD_ENDERECO
			where DISTRIBUIDORA.STATUS = 1
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETAR_CLIENTES]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DELETAR_CLIENTES]
@COD_CLIENTE INT
as
begin
	begin try
		begin transaction
			if(@COD_CLIENTE is not null and @COD_CLIENTE <> '')
					begin
					UPDATE CLIENTE SET CLI_ATIVO = 0 WHERE COD_CLIENTE = (@COD_CLIENTE);
			end
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETAR_DISTRIBUIDORA]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_DELETAR_DISTRIBUIDORA]
@COD_DISTRIBUIDORA INT
as
begin
	begin try
		begin transaction
			if(@COD_DISTRIBUIDORA is not null and @COD_DISTRIBUIDORA <> '')
					begin
					UPDATE DISTRIBUIDORA SET STATUS = 0 where COD_DISTRIBUIDORA = (@COD_DISTRIBUIDORA);
					SELECT @COD_DISTRIBUIDORA AS retorno
			end
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETAR_FABRICANTE]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DELETAR_FABRICANTE]
@COD_FABRICANTE INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			IF(@COD_FABRICANTE IS NOT NULL AND @COD_FABRICANTE <> '')
					BEGIN
					UPDATE FABRICANTE SET FABRI_ATIVO = 0 WHERE COD_FABRICANTE = (@COD_FABRICANTE);
					SELECT @COD_FABRICANTE AS RETORNO
			END
		COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETAR_FUNCIONARIO]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_DELETAR_FUNCIONARIO]
@ID INT
as
begin
	begin try
		begin transaction
			UPDATE FUNCIONARIO set FUNC_ATIVO = 0
			WHERE COD_FUNCIONARIO = @ID;
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETAR_FUNCIONARIOS]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_DELETAR_FUNCIONARIOS]
@COD_FUNCIONARIO INT
as
begin
	begin try
		begin transaction
			if(@COD_FUNCIONARIO is not null and @COD_FUNCIONARIO <> '')
					begin
					UPDATE FUNCIONARIO SET FUNC_ATIVO = 0 WHERE COD_FUNCIONARIO = (@COD_FUNCIONARIO);
			end
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETAR_PRODUTO]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DELETAR_PRODUTO]
@COD_PRODUTO INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			IF(@COD_PRODUTO IS NOT NULL AND @COD_PRODUTO <> '')
					BEGIN
					UPDATE PRODUTO SET PROD_ATIVO = 0 WHERE COD_PRODUTO = (@COD_PRODUTO);
			END
		COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERIR_CLIENTES_ENDERECO_TELEFONE]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERIR_CLIENTES_ENDERECO_TELEFONE]
@CLI_NOME VARCHAR(50),
@CLI_SOBRENOME VARCHAR(50),
@CLI_CPF VARCHAR (11),
@CLI_DTNASC DATETIME,
@CLI_SEXO CHAR(1),

@END_RUA VARCHAR(50),
@END_BAIRRO VARCHAR(50),
@END_CIDADE VARCHAR(50),
@END_NUMERO VARCHAR(10),
@END_CEP VARCHAR(8),
@END_UF VARCHAR(2),

@TEL_TELEFONE VARCHAR(11)

as
begin
	begin try
		begin transaction
			if(@END_RUA is not null and @END_RUA <> '' and
			   @END_BAIRRO is not null and @END_BAIRRO <> '' and
			   @END_CIDADE is not null and @END_CIDADE <> '' and
			   @END_NUMERO is not null and @END_NUMERO <> '')
			begin
				insert into ENDERECO values (@END_RUA,@END_BAIRRO,@END_CIDADE,@END_NUMERO, @END_CEP, @END_UF);
			end

			DECLARE @IDEndereco AS INT = @@IDENTITY
			if(@TEL_TELEFONE is not null and @TEL_TELEFONE <> '')
			begin
				insert into TELEFONE (TEL_NUMERO) 
					values (@TEL_TELEFONE);
			end

			DECLARE @IDTelefone AS INT = @@IDENTITY
			if(@CLI_NOME is not null and @CLI_NOME <> '' and
			   @CLI_SOBRENOME is not null and @CLI_SOBRENOME <> '' and
			   @CLI_CPF is not null and @CLI_CPF <> '') 		
			   
					begin
					insert into CLIENTE  
					values (@CLI_NOME,@CLI_SOBRENOME,@CLI_CPF,@CLI_DTNASC,@CLI_SEXO,@IDEndereco,@IDTelefone, 1);
			end
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERIR_DISTRIBUIDORA]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERIR_DISTRIBUIDORA]
@DIST_NOME VARCHAR(30),
@DIST_CNPJ VARCHAR(30),
@END_RUA VARCHAR(50),
@END_BAIRRO VARCHAR(50),
@END_CIDADE VARCHAR(50),
@END_NUMERO VARCHAR(10),
@END_CEP CHAR(9),
@END_UF CHAR(2),
@TEL_NUMERO VARCHAR(11)

AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			IF(@TEL_NUMERO IS NOT NULL AND @TEL_NUMERO <> '')
			BEGIN
				INSERT INTO TELEFONE (TEL_NUMERO) 
					VALUES (@TEL_NUMERO);
					DECLARE @IDTELEFONE AS INT = @@IDENTITY
			END

			 IF (@END_RUA IS NOT NULL AND @END_RUA <>'' AND
			     @END_BAIRRO IS NOT NULL AND @END_BAIRRO <>'' AND
				 @END_CIDADE IS NOT NULL AND @END_CIDADE <>'' AND
				 @END_NUMERO IS NOT NULL AND @END_NUMERO <> '' AND
				 @END_CEP IS NOT NULL AND @END_CEP <> '' AND
				 @END_UF IS NOT NULL AND @END_UF <> '')
				 BEGIN
				 INSERT INTO ENDERECO (END_RUA,END_BAIRRO,END_CIDADE,END_NUMERO,END_CEP, END_UF) 
				 VALUES (@END_RUA,@END_BAIRRO,@END_CIDADE,@END_NUMERO,@END_CEP, @END_UF)
				 DECLARE @IDENDERECO AS INT = @@IDENTITY
			 END


			IF(@DIST_NOME IS NOT NULL AND @DIST_NOME <> '' AND
		       @DIST_CNPJ IS NOT NULL AND @DIST_CNPJ <> '' )
		       
					BEGIN
					INSERT INTO DISTRIBUIDORA (DIST_NOME, DIST_CNPJ, COD_TELEFONE,COD_ENDERECO, STATUS) 
					VALUES (@DIST_NOME, @DIST_CNPJ, @IDTELEFONE,@IDENDERECO,1);
					SELECT @@IDENTITY AS retorno
			END
		COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERIR_FABRICANTE]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERIR_FABRICANTE]
@FABR_NOME VARCHAR(30)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			IF(@FABR_NOME IS NOT NULL AND @FABR_NOME <> '')
					BEGIN

					INSERT INTO FABRICANTE (FABR_NOME,FABRI_ATIVO) 
					
					VALUES (@FABR_NOME,1);
					SELECT @@IDENTITY AS RETORNO
			END
		COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
	END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERIR_FUNCIONARIOS]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_INSERIR_FUNCIONARIOS]
@FUNC_NOME VARCHAR(50),
@FUNC_SOBRENOME VARCHAR(50),
@END_RUA VARCHAR(50),
@END_BAIRRO VARCHAR(50),
@END_CIDADE VARCHAR (50),
@END_NUMERO VARCHAR(20),
@END_CEP VARCHAR (12),
@END_UF CHAR (2),
@TEL_NUMERO VARCHAR (15)
as
begin
	begin try
		begin transaction
			if(@FUNC_NOME is not null and @FUNC_NOME <> '' and
			   @FUNC_SOBRENOME is not null and @FUNC_SOBRENOME <> '' and
			   @END_RUA is not null and @END_RUA <> '' and @END_BAIRRO is not null
			   and @END_BAIRRO <> '' and @END_CIDADE is not null and @END_CIDADE <> '' and @END_NUMERO is not null and @END_NUMERO <> ''
			   and @END_CEP is not null and @END_CEP <> '' and @END_UF is not null and @END_UF <> '' and @TEL_NUMERO is not null and
			   @TEL_NUMERO <> '')
					begin
					
					insert into ENDERECO (END_RUA,END_BAIRRO,END_CIDADE,END_NUMERO, END_CEP, END_UF) values (@END_RUA,@END_BAIRRO,@END_CIDADE,@END_NUMERO, @END_CEP, @END_UF);
					DECLARE @IDENDERECO AS INT = @@IDENTITY;

					insert into TELEFONE (TEL_NUMERO) values (@TEL_NUMERO);
					DECLARE @IDTELEFONE AS INT = @@IDENTITY;
					
					
				insert into FUNCIONARIO values (@FUNC_NOME,@FUNC_SOBRENOME, 1, @IDENDERECO, @IDTELEFONE);
				SELECT @@IDENTITY AS retorno
			end
		commit
	end try

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
end
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERIR_PRODUTO]    Script Date: 05/06/2019 22:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERIR_PRODUTO]
@PROD_NOME VARCHAR(30),
@PROD_VALOR DECIMAL,
@COD_FABRICANTE INT,
@COD_DISTRIBUIDORA INT,
@EST_QUANTIDADE INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			IF(@PROD_NOME IS NOT NULL AND @PROD_NOME <> '' AND
		       @PROD_VALOR IS NOT NULL AND 		      
		       @COD_FABRICANTE IS NOT NULL AND @COD_FABRICANTE <> '' AND
		       @COD_DISTRIBUIDORA IS NOT NULL AND @COD_DISTRIBUIDORA <> '' AND
			   @EST_QUANTIDADE IS NOT NULL AND @EST_QUANTIDADE <> '')
					BEGIN
					INSERT INTO PRODUTO (PROD_NOME, PROD_VALOR, PROD_ATIVO,COD_FABRICANTE,COD_DISTRIBUIDORA) 
					VALUES (@PROD_NOME, @PROD_VALOR, 1,@COD_FABRICANTE,@COD_DISTRIBUIDORA) ;

					DECLARE @IDProduto INT;
					SET @IDProduto = @@IDENTITY;

					INSERT INTO ESTOQUE (EST_QUANTIDADE, COD_PRODUTO) VALUES (@EST_QUANTIDADE, @IDProduto);

					SELECT @IDProduto AS retorno
			END

		COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		SELECT ERROR_MESSAGE() AS ERROMENSAGEM -- PEGA O ERRO QUE FOI RETORNADO PARA O CATCH
	END CATCH
END
GO
