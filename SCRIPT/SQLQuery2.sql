CREATE DATABASE AUTONOMUSBANCO;
GO

USE  AUTONOMUSBANCO;
GO
SELECT * FROM Cliente
SELECT * FROM Prestador


CREATE TABLE Cliente(
id_cliente INT PRIMARY KEY identity,
nome_cliente VARCHAR(20) NOT NULL,
sobrenome_cliente VARCHAR(20) NOT NULL,
email_cliente VARCHAR(30) NOT NULL,
genero_cliente VARCHAR(20) NOT NULL,
estado_cliente VARCHAR(30) NOT NULL,
tel_cliente VARCHAR(15) NOT NULL,
senha_cliente VARCHAR(120) NOT NULL,
avaliacao_cliente DECIMAL (2,1)
)
GO

INSERT INTO Cliente VALUES (
'Nathália', 'Emy', 'nathalia.emy@email.com', 'Feminino', 'São Paulo', '(11)91234-5678', 'Senha123!', 4.8
);
GO

CREATE TABLE Prestador (
    id_prestador INT PRIMARY KEY IDENTITY,
    nome_prestador VARCHAR(20) NOT NULL,
    sobrenome_prestador VARCHAR(20) NOT NULL,
    email_prestador VARCHAR(30) NOT NULL,
    genero_prestador VARCHAR(20) NOT NULL,
    estado_prestador VARCHAR(30) NOT NULL,
    tel_prestador VARCHAR(15) NOT NULL,
    senha_prestador VARCHAR(120) NOT NULL,
    avaliacao_prestador DECIMAL(2,1)
)
GO

INSERT INTO Prestador VALUES (
'Carlos', 'Souza', 'carlos.souza@email.com', 'Masculino', 'São Paulo', '(11)98765-4321', 'Senha123!', 4.5
);
GO
select * from Prestador
select * from publicacao_prestador_experiencias
select * from publicacao_prestador_abordagem
select * from publicacao_prestador_subcategoria
select * from publicacao_prestador_habilidades
select * from publicacao_prestador_qualidades
select * from publicacao_Prestador

CREATE TABLE publicacao_Prestador(
id_publicacao_prestador INT PRIMARY KEY identity,
id_prestador INT FOREIGN KEY REFERENCES Prestador(id_prestador),
categoria_prestador VARCHAR(100) NOT NULL,
descricao_publicacao_prestador VARCHAR(500) NOT NULL,
valor_prestador FLOAT NOT NULL,
forma_de_atendimento_prestador VARCHAR(100) NOT NULL,
data_publicacao_prestador DATE NOT NULL,
)
GO

INSERT INTO publicacao_Prestador (id_prestador, categoria_prestador, descricao_publicacao_prestador, valor_prestador, forma_de_atendimento_prestador, data_publicacao_prestador)
VALUES (
	1, 'Serviços de TI', 'Suporte técnico completo para computadores e redes.', 150.00, 'Presencial e Online', '2025-10-13'
);

CREATE TABLE publicacao_prestador_subcategoria(
id_publicacao_prestador_subcategoria INT PRIMARY KEY IDENTITY,
id_publicacao_prestador INT FOREIGN KEY REFERENCES publicacao_Prestador(id_publicacao_prestador),
subcategoria_prestador VARCHAR(100) NOT NULL
)
GO

CREATE TABLE publicacao_prestador_experiencias(
	id_publicacao_prestador_experiencias INT PRIMARY KEY IDENTITY,
	id_publicacao_prestador INT FOREIGN KEY REFERENCES publicacao_Prestador(id_publicacao_prestador),
	descricao_experiencia_prestador VARCHAR(200) NOT NULL
)
GO

CREATE TABLE publicacao_prestador_habilidades(
	id_publicacao_prestador_habilidades INT PRIMARY KEY IDENTITY,
	id_publicacao_prestador INT FOREIGN KEY REFERENCES publicacao_Prestador(id_publicacao_prestador),
	descricao_habilidade_prestador VARCHAR(200) NOT NULL
)
GO

CREATE TABLE publicacao_prestador_qualidades(
	id_publicacao_prestador_qualidades INT PRIMARY KEY IDENTITY,
	id_publicacao_prestador INT FOREIGN KEY REFERENCES publicacao_Prestador(id_publicacao_prestador),
	descricao_qualidade_prestador VARCHAR(200) NOT NULL
)
GO

CREATE TABLE publicacao_prestador_abordagem(
	id_publicacao_prestador_abordagem INT PRIMARY KEY IDENTITY,
	id_publicacao_prestador INT FOREIGN KEY REFERENCES publicacao_Prestador(id_publicacao_prestador),
	descricao_abordagem_prestador VARCHAR(200) NOT NULL
)
GO

CREATE TABLE publicacao_Cliente(
id_publicacao_cliente INT PRIMARY KEY IDENTITY NOT NULL,
id_cliente INT FOREIGN KEY REFERENCES Cliente(id_cliente),
categoria_cliente VARCHAR(100) NOT NULL,
descricao_publicacao_cliente VARCHAR(500) NOT NULL,
data_publicacao_cliente DATE NOT NULL,
valor_cliente FLOAT NOT NULL,
forma_de_atendimento_cliente VARCHAR(100) NOT NULL,
)
GO

CREATE TABLE publicacao_cliente_subcategoria(
id_publicacao_cliente_subcategoria INT PRIMARY KEY IDENTITY,
id_publicacao_cliente INT FOREIGN KEY REFERENCES publicacao_Cliente(id_publicacao_cliente),
subcategoria_cliente VARCHAR(100) NOT NULL
)
GO

CREATE TABLE comentario_feedback_prestador (
    id_comentario_feedback_prestador INT PRIMARY KEY IDENTITY,
	id_publicacao_cliente INT FOREIGN KEY REFERENCES publicacao_Cliente(id_publicacao_cliente),
    texto_comentario_feedback_prestador VARCHAR(500) NOT NULL,
	nota_comentario_feedback_prestador  DECIMAL (2,1) NOT NULL,
    data_comentario_feedback_prestador DATE NOT NULL,
);
GO

CREATE TABLE comentario_feedback_cliente (
    id_comentario_feedback_cliente INT PRIMARY KEY IDENTITY,
	id_publicacao_prestador INT FOREIGN KEY REFERENCES publicacao_Prestador(id_publicacao_prestador),
    texto_comentario_feedback_cliente VARCHAR(500) NOT NULL,
	nota_comentario_feedback_cliente  DECIMAL (2,1) NOT NULL,
    data_comentario_feedback_cliente DATE NOT NULL,

);
GO

CREATE TABLE Funcionario(
id_func INT PRIMARY KEY IDENTITY,
id_publicacao_prestador INT FOREIGN KEY REFERENCES publicacao_Prestador(id_publicacao_prestador),
id_publicacao_cliente INT FOREIGN KEY REFERENCES publicacao_Cliente(id_publicacao_cliente),
email_func CHAR(30) NOT NULL,
senha_func VARCHAR(20) NOT NULL
)
GO

CREATE TABLE Agenda_Cliente(
    Id_agenda_cliente INT IDENTITY PRIMARY KEY,
    IdCliente INT NULL REFERENCES Cliente(id_cliente),
    DiaSemana INT NOT NULL,
    Horario TIME NOT NULL
);
GO

CREATE TABLE Agenda_Prestador(
	id_agenda_prestador INT PRIMARY KEY iDENTITY,
	id_prestador INT FOREIGN KEY REFERENCES Prestador(id_prestador),
    DiaSemana INT NOT NULL,
    Horario TIME NOT NULL
)
GO

CREATE TABLE Chat (
    id_chat INT PRIMARY KEY IDENTITY,
    texto_chat NVARCHAR(500) NOT NULL,
    data_envio DATETIME NOT NULL,
    id_cliente INT FOREIGN KEY REFERENCES Cliente(id_cliente),
    id_prestador INT FOREIGN KEY REFERENCES Prestador(id_prestador)
);
GO








/* LOGIN GERAL*/
ALTER PROCEDURE sp_Login
@Email NVARCHAR(150),
@Senha NVARCHAR (100)
AS
BEGIN
SELECT email_cliente as email, senha_cliente as senha, id_cliente as idUsuario, 'cliente' as tipo from Cliente
where email_cliente = @Email and
senha_cliente = @Senha
UNION
SELECT email_prestador as email, senha_prestador as senha, id_prestador as idUsuario, 'prestador' as tipo from Prestador
where email_prestador = @Email and
senha_prestador = @Senha
UNION
SELECT email_func AS email, senha_func AS  senha, id_func as idUsuario, 'funcionario' AS tipo FROM Funcionario
WHERE email_func = @Email and 
senha_func = @Senha
END

SELECT * FROM Cliente


/*ANUNCIO/PUBLICAÇÃO PRESTADOR*/
/*PUBLICACAO*/
CREATE PROCEDURE sp_ObterPublicacaoPrestador
AS 
BEGIN
	SELECT * FROM publicacao_Prestador;
END;
GO

CREATE PROCEDURE sp_InserirPublicacaoPrestador
    @IdPrestador INT,
    @CategoriaPrestador VARCHAR(100),
    @DescricaoPublicacaoPrestador VARCHAR(500),
    @ValorPrestador FLOAT,
    @FormaDeAtendimentoPrestador VARCHAR(100),
    @DataPublicacaoPrestador DATE
AS
BEGIN
    INSERT INTO publicacao_Prestador (
        id_prestador,
        categoria_prestador,
        descricao_publicacao_prestador,
        valor_prestador,
        forma_de_atendimento_prestador,
        data_publicacao_prestador
    )
    VALUES (
        @IdPrestador,
        @CategoriaPrestador,
        @DescricaoPublicacaoPrestador,
        @ValorPrestador,
        @FormaDeAtendimentoPrestador,
        @DataPublicacaoPrestador
    );

    SELECT SCOPE_IDENTITY() AS NovoIdPublicacaoPrestador;
END;
GO

CREATE PROCEDURE sp_UpdatePublicacaoPrestador
    @IdPublicacaoPrestador INT,
    @CategoriaPublicacaoPrestador VARCHAR(100),
	@DescricaoPublicacaoPrestador VARCHAR(100),
	@ValorPublicacaoPrestador DECIMAL,
	@FormaDeAtendimentoPrestador VARCHAR(100)
AS
BEGIN
    UPDATE publicacao_Prestador
    SET
        categoria_prestador = @CategoriaPublicacaoPrestador,
		descricao_publicacao_prestador = @DescricaoPublicacaoPrestador,
		valor_prestador = @ValorPublicacaoPrestador,
		forma_de_atendimento_prestador = @FormaDeAtendimentoPrestador
    WHERE
        id_publicacao_prestador = @IdPublicacaoPrestador;
END;
GO

CREATE PROCEDURE sp_DeletaRelacionamentosPublicacaoPrestador
	@IdPublicacaoPrestador INT
AS
BEGIN 
	DELETE FROM publicacao_prestador_abordagem WHERE id_publicacao_prestador = @IdPublicacaoPrestador;
	DELETE FROM publicacao_prestador_experiencias WHERE id_publicacao_prestador = @IdPublicacaoPrestador;
	DELETE FROM publicacao_prestador_habilidades WHERE id_publicacao_prestador = @IdPublicacaoPrestador;
	DELETE FROM publicacao_prestador_qualidades WHERE id_publicacao_prestador = @IdPublicacaoPrestador;
	DELETE FROM publicacao_prestador_subcategoria WHERE id_publicacao_prestador = @IdPublicacaoPrestador;
END
GO




/*SUBCATEGORIAS*/
CREATE PROCEDURE sp_ObterSubcategoriaPrestador
AS 
BEGIN
	SELECT * FROM publicacao_prestador_subcategoria;
END;
GO

CREATE PROCEDURE sp_InserirSubcategoriaPrestador
    @IdPublicacaoPrestador INT,
    @SubcategoriaPrestador VARCHAR(100)
AS
BEGIN
    INSERT INTO publicacao_prestador_subcategoria (
        id_publicacao_prestador,
        subcategoria_prestador
    )
    VALUES (
        @IdPublicacaoPrestador,
        @SubcategoriaPrestador
    );

    SELECT SCOPE_IDENTITY() AS NovoIdPublicacaoPrestadorSubcategoria;
END;
GO

CREATE PROCEDURE sp_UpdateSubcategoriaPrestador
    @IdSubcategoria INT,
    @SubcategoriaPrestador VARCHAR(100)
AS
BEGIN
    UPDATE publicacao_prestador_subcategoria
    SET
        subcategoria_prestador = @SubcategoriaPrestador
    WHERE
        id_publicacao_prestador_subcategoria = @IdSubcategoria;
END;
GO

CREATE PROCEDURE dboDeletarSubcategoriaPrestador
    @id_subcategoria INT
AS
BEGIN
    DELETE FROM publicacao_prestador_subcategoria
    WHERE id_publicacao_prestador_subcategoria = @id_subcategoria;
END;
GO

/*EXPERIENCIAS*/
CREATE PROCEDURE sp_ObterExperienciasPrestador
AS 
BEGIN
    SELECT * FROM publicacao_prestador_experiencias;
END;
GO

CREATE PROCEDURE sp_InserirExperienciaPrestador
    @IdPublicacaoPrestador INT,
    @DescricaoExperienciaPrestador VARCHAR(200)
AS
BEGIN
    INSERT INTO publicacao_prestador_experiencias (
        id_publicacao_prestador,
        descricao_experiencia_prestador
    )
    VALUES (
        @IdPublicacaoPrestador,
        @DescricaoExperienciaPrestador
    );

    SELECT SCOPE_IDENTITY() AS NovoIdPublicacaoPrestadorExperiencia;
END;
GO

CREATE PROCEDURE sp_UpdateExperienciaPrestador
    @IdExperiencia INT,
    @DescricaoExperienciaPrestador VARCHAR(200)
AS
BEGIN
    UPDATE publicacao_prestador_experiencias
    SET
        descricao_experiencia_prestador = @DescricaoExperienciaPrestador
    WHERE
        id_publicacao_prestador_experiencias = @IdExperiencia;
END;
GO

CREATE PROCEDURE dboDeletarExperienciaPrestador
    @id_experiencia INT
AS
BEGIN
    DELETE FROM publicacao_prestador_experiencias
    WHERE id_publicacao_prestador_experiencias = @id_experiencia;
END;
GO

/*HABILIDADES*/
CREATE PROCEDURE sp_ObterHabilidadesPrestador
AS
BEGIN
    SELECT * FROM publicacao_prestador_habilidades;
END;
GO

CREATE PROCEDURE sp_InserirHabilidadePrestador
    @IdPublicacaoPrestador INT,
    @DescricaoHabilidadePrestador VARCHAR(200)
AS
BEGIN
    INSERT INTO publicacao_prestador_habilidades (
        id_publicacao_prestador,
        descricao_habilidade_prestador
    )
    VALUES (
        @IdPublicacaoPrestador,
        @DescricaoHabilidadePrestador
    );

    SELECT SCOPE_IDENTITY() AS NovoIdPublicacaoPrestadorHabilidade;
END;
GO

CREATE PROCEDURE sp_UpdateHabilidadePrestador
    @IdHabilidade INT,
    @DescricaoHabilidadePrestador VARCHAR(200)
AS
BEGIN
    UPDATE publicacao_prestador_habilidades
    SET descricao_habilidade_prestador = @DescricaoHabilidadePrestador
    WHERE id_publicacao_prestador_habilidades = @IdHabilidade;
END;
GO

CREATE PROCEDURE sp_DeletarHabilidadePrestador
    @IdHabilidade INT
AS
BEGIN
    DELETE FROM publicacao_prestador_habilidades
    WHERE id_publicacao_prestador_habilidades = @IdHabilidade;
END;
GO

/*QUALIDADES*/
CREATE PROCEDURE sp_ObterQualidadesPrestador
AS
BEGIN
    SELECT * FROM publicacao_prestador_qualidades;
END;
GO

CREATE PROCEDURE sp_InserirQualidadePrestador
    @IdPublicacaoPrestador INT,
    @DescricaoQualidadePrestador VARCHAR(200)
AS
BEGIN
    INSERT INTO publicacao_prestador_qualidades (
        id_publicacao_prestador,
        descricao_qualidade_prestador
    )
    VALUES (
        @IdPublicacaoPrestador,
        @DescricaoQualidadePrestador
    );

    SELECT SCOPE_IDENTITY() AS NovoIdPublicacaoPrestadorQualidade;
END;
GO

CREATE PROCEDURE sp_UpdateQualidadePrestador
    @IdQualidade INT,
    @DescricaoQualidadePrestador VARCHAR(200)
AS
BEGIN
    UPDATE publicacao_prestador_qualidades
    SET descricao_qualidade_prestador = @DescricaoQualidadePrestador
    WHERE id_publicacao_prestador_qualidades = @IdQualidade;
END;
GO

CREATE PROCEDURE sp_DeletarQualidadePrestador
    @IdQualidade INT
AS
BEGIN
    DELETE FROM publicacao_prestador_qualidades
    WHERE id_publicacao_prestador_qualidades = @IdQualidade;
END;
GO


/*ABORDAGEM*/
CREATE PROCEDURE sp_ObterAbordagensPrestador
AS
BEGIN
    SELECT * FROM publicacao_prestador_abordagem;
END;
GO

CREATE PROCEDURE sp_InserirAbordagemPrestador
    @IdPublicacaoPrestador INT,
    @DescricaoAbordagemPrestador VARCHAR(200)
AS
BEGIN
    INSERT INTO publicacao_prestador_abordagem (
        id_publicacao_prestador,
        descricao_abordagem_prestador
    )
    VALUES (
        @IdPublicacaoPrestador,
        @DescricaoAbordagemPrestador
    );

    SELECT SCOPE_IDENTITY() AS NovoIdPublicacaoPrestadorAbordagem;
END;
GO

CREATE PROCEDURE sp_UpdateAbordagemPrestador
    @IdAbordagem INT,
    @DescricaoAbordagemPrestador VARCHAR(200)
AS
BEGIN
    UPDATE publicacao_prestador_abordagem
    SET descricao_abordagem_prestador = @DescricaoAbordagemPrestador
    WHERE id_publicacao_prestador_abordagem = @IdAbordagem;
END;
GO

CREATE PROCEDURE sp_DeletarAbordagemPrestador
    @IdAbordagem INT
AS
BEGIN
    DELETE FROM publicacao_prestador_abordagem
    WHERE id_publicacao_prestador_abordagem = @IdAbordagem;
END;
GO






















/*CLIENTES*/
CREATE procedure sp_SelecionarClientes
AS
BEGIN
    SELECT 
        *
    FROM Cliente;
END;
GO

	CREATE PROCEDURE sp_InserirCliente
		@NomeCliente CHAR(20),
		@SobrenomeCliente CHAR(20),
		@EmailCliente CHAR(30),
		@GeneroCliente CHAR(20),
		@EstadoCliente CHAR(30),
		@TelefoneCliente VARCHAR(15),
		@SenhaCliente VARCHAR(120),
		@AvaliacaoCliente DECIMAL(2,1)
	AS
	BEGIN
		INSERT INTO Cliente (
			nome_cliente,
			sobrenome_cliente,
			email_cliente,
			genero_cliente,
			estado_cliente,
			tel_cliente,
			senha_cliente,
			avaliacao_cliente
		)
		VALUES (
			@NomeCliente,
			@SobrenomeCliente,
			@EmailCliente,
			@GeneroCliente,
			@EstadoCliente,
			@TelefoneCliente,
			@SenhaCliente,
			@AvaliacaoCliente
		);

		SELECT SCOPE_IDENTITY() AS NovoIdCliente;
	END;
	GO

CREATE PROCEDURE dboDeletarCliente
	@id_cliente INT
AS
BEGIN
    DELETE FROM Cliente
    WHERE id_cliente = @id_cliente;
END;

SELECT * from Cliente

CREATE PROCEDURE sp_UpdateCliente
    @IdCliente INT,
    @NomeCliente CHAR(20),
    @SobrenomeCliente CHAR(20),
    @EmailCliente CHAR(30),
    @GeneroCliente CHAR(20),
    @EstadoCliente CHAR(30),
    @TelefoneCliente VARCHAR(15),
    @SenhaCliente VARCHAR(20),
    @AvaliacaoCliente DECIMAL(2,1)
AS
BEGIN
    UPDATE Cliente
    SET
        nome_cliente = @NomeCliente,
        sobrenome_cliente = @SobrenomeCliente,
        email_cliente = @EmailCliente,
        genero_cliente = @GeneroCliente,
        estado_cliente = @EstadoCliente,
        tel_cliente = @TelefoneCliente,
        senha_cliente = @SenhaCliente,
        avaliacao_cliente = @AvaliacaoCliente
    WHERE
        id_cliente = @IdCliente;
END;
GO













/* PRESTADOR */

create procedure sp_SelecionarPrestador
AS
BEGIN
    SELECT 
        *
    FROM Prestador;
END;
GO

CREATE PROCEDURE sp_InserirPrestador
    @NomePrestador NVARCHAR(100),
    @SobrenomePrestador NVARCHAR(100),
    @TelefonePrestador NVARCHAR(20),
    @EmailPrestador NVARCHAR(150),
    @GeneroPrestador CHAR(20),
    @EstadoPrestador CHAR(30),
    @AvaliacaoPrestador DECIMAL(2,1),
    @SenhaPrestador NVARCHAR(100)
AS
BEGIN
    INSERT INTO Prestador (
        nome_prestador,
        sobrenome_prestador,
        tel_prestador,
        email_prestador,
        genero_prestador,
        estado_prestador,
        avaliacao_prestador,
        senha_prestador
    )
    VALUES (
        @NomePrestador,
        @SobrenomePrestador,
        @TelefonePrestador,
        @EmailPrestador,
        @GeneroPrestador,
        @EstadoPrestador, 
        @AvaliacaoPrestador,
        @SenhaPrestador
    );

    SELECT SCOPE_IDENTITY() AS NovoIdPrestador;
END;
GO

CREATE PROCEDURE sp_UpdatePrestador
    @NomePrestador NVARCHAR(100),
    @SobrenomePrestador NVARCHAR(100),
    @TelefonePrestador NVARCHAR(20),
    @EmailPrestador NVARCHAR(150),
    @GeneroPrestador CHAR(20),
    @EstadoPrestador CHAR(30),
    @AvaliacaoPrestador DECIMAL(2,1), 
    @SenhaPrestador NVARCHAR(100),
    @IdPrestador INT
AS
BEGIN
    UPDATE Prestador
    SET 
        nome_prestador = @NomePrestador,
        sobrenome_prestador = @SobrenomePrestador,
        email_prestador = @EmailPrestador,
        genero_prestador = @GeneroPrestador,
        tel_prestador = @TelefonePrestador,
        estado_prestador = @EstadoPrestador,
        avaliacao_prestador = @AvaliacaoPrestador,
        senha_prestador = @SenhaPrestador
    WHERE
        id_prestador = @IdPrestador;
END;
GO

CREATE PROCEDURE dboDeletarPrestador
    @id_prestador INT
AS
BEGIN
    DELETE FROM Prestador
    WHERE id_prestador = @id_prestador;
END;













/* COMENTÁRIOS CLIENTES*/


/* COMENTÁRIOS PRESTADORES*/




















/* FILTRAGEM CLIENTES */

CREATE PROCEDURE sp_FiltrarClientes
    @NomeCliente NVARCHAR(100) = NULL
AS
BEGIN
    SELECT
        id_cliente,
        nome_cliente,
        sobrenome_cliente,
        email_cliente,
        genero_cliente,
        estado_cliente,
        tel_cliente,
        senha_cliente,
        avaliacao_cliente
    FROM Cliente
    WHERE (@NomeCliente IS NULL OR nome_cliente LIKE '%' + @NomeCliente + '%');
END;
GO

CREATE PROCEDURE sp_FiltrarClienteEstado
    @EstadoCliente NVARCHAR(100) = NULL
AS
BEGIN
    SELECT *
    FROM Cliente
    WHERE (@EstadoCliente IS NULL OR estado_cliente LIKE '%' + @EstadoCliente + '%')
    ORDER BY nome_cliente;
END;
GO

CREATE PROCEDURE sp_FiltrarClientesAvaliacao
@MinAvaliacao DECIMAL(10, 2),
@MaxAvaliacao DECIMAL(10, 2)
as
begin 
select * from Cliente where avaliacao_cliente>= @MinAvaliacao and avaliacao_cliente <= @MaxAvaliacao
end;
GO

CREATE PROCEDURE sp_SelecionarClientePorId
@IdCliente INT
AS 
BEGIN
SELECT * FROM Cliente WHERE id_cliente = @IdCliente
END
GO


/* FILTRAGEM PRESTADORES */

CREATE PROCEDURE sp_FiltrarPrestadores
    @NomePrestador NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        id_prestador,
        nome_prestador,
        sobrenome_prestador,
        tel_prestador,
        genero_prestador,
        email_prestador,
        estado_prestador,
        avaliacao_prestador,
        senha_prestador
    FROM Prestador
    WHERE (@NomePrestador IS NULL OR nome_prestador LIKE '%' + @NomePrestador + '%');
END;
GO

CREATE PROCEDURE sp_FiltrarPrestadorEstado
    @EstadoPrestador NVARCHAR(100) = NULL
AS
BEGIN
    SELECT *
    FROM Prestador
    WHERE (@EstadoPrestador IS NULL OR estado_prestador LIKE '%' + @EstadoPrestador + '%')
    ORDER BY nome_prestador;
END;
GO

CREATE PROCEDURE sp_FiltrarPrestadorAvaliacao
@MinAvaliacao DECIMAL(10, 2),
@MaxAvaliacao DECIMAL(10, 2)
as
begin 
select * from Prestador where avaliacao_prestador>= @MinAvaliacao and avaliacao_prestador <= @MaxAvaliacao
end;
GO

CREATE PROCEDURE sp_SelecionarPrestadorPorId
@IdPrestador INT
AS 
BEGIN
SELECT * FROM Prestador WHERE id_prestador = @IdPrestador
END


