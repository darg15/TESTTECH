USE [TechCard]
GO
/****** Object:  Table [dbo].[tech_card]    Script Date: 28/12/2024 22:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tech_card](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NULL,
	[card_number] [varchar](50) NULL,
	[balance_used] [numeric](18, 2) NULL,
	[balance_available] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tech_movs]    Script Date: 28/12/2024 22:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tech_movs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_card] [int] NULL,
	[date_shop] [datetime] NULL,
	[description_mov] [varchar](100) NULL,
	[amount] [decimal](18, 2) NULL,
	[noAuth] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tech_payments]    Script Date: 28/12/2024 22:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tech_payments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_card] [int] NULL,
	[date] [datetime] NULL,
	[amount] [decimal](18, 2) NULL,
	[noAuth] [int] NULL,
 CONSTRAINT [PK_tech_payments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tech_user]    Script Date: 28/12/2024 22:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tech_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[client_name] [varchar](100) NULL,
	[email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tech_card] ON 
GO
INSERT [dbo].[tech_card] ([id], [id_user], [card_number], [balance_used], [balance_available]) VALUES (1, 1, N'0000 1111 0000 4444', CAST(25.00 AS Numeric(18, 2)), CAST(2000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tech_card] ([id], [id_user], [card_number], [balance_used], [balance_available]) VALUES (2, 2, N'0000 2222 1111 0909', CAST(35.00 AS Numeric(18, 2)), CAST(2000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[tech_card] OFF
GO
SET IDENTITY_INSERT [dbo].[tech_movs] ON 
GO
INSERT [dbo].[tech_movs] ([id], [id_card], [date_shop], [description_mov], [amount], [noAuth]) VALUES (18, 1, CAST(N'2024-12-13T00:00:00.000' AS DateTime), N'Zapatos', CAST(50.00 AS Decimal(18, 2)), 482668)
GO
INSERT [dbo].[tech_movs] ([id], [id_card], [date_shop], [description_mov], [amount], [noAuth]) VALUES (20, 1, CAST(N'2024-12-28T22:36:08.053' AS DateTime), N'Nike', CAST(10.00 AS Decimal(18, 2)), 729300)
GO
INSERT [dbo].[tech_movs] ([id], [id_card], [date_shop], [description_mov], [amount], [noAuth]) VALUES (21, 2, CAST(N'2024-12-14T00:00:00.000' AS DateTime), N'PlayStation Plus', CAST(85.00 AS Decimal(18, 2)), 975632)
GO
INSERT [dbo].[tech_movs] ([id], [id_card], [date_shop], [description_mov], [amount], [noAuth]) VALUES (22, 1, CAST(N'2024-12-29T01:19:44.013' AS DateTime), N'Compra', CAST(1.00 AS Decimal(18, 2)), 416513)
GO
INSERT [dbo].[tech_movs] ([id], [id_card], [date_shop], [description_mov], [amount], [noAuth]) VALUES (23, 1, CAST(N'2024-12-13T00:00:00.000' AS DateTime), N'Pizza Hut', CAST(30.00 AS Decimal(18, 2)), 962826)
GO
SET IDENTITY_INSERT [dbo].[tech_movs] OFF
GO
SET IDENTITY_INSERT [dbo].[tech_payments] ON 
GO
INSERT [dbo].[tech_payments] ([id], [id_card], [date], [amount], [noAuth]) VALUES (16, 2, CAST(N'2024-12-17T00:00:00.000' AS DateTime), CAST(25.00 AS Decimal(18, 2)), 689763)
GO
INSERT [dbo].[tech_payments] ([id], [id_card], [date], [amount], [noAuth]) VALUES (17, 1, CAST(N'2024-12-12T00:00:00.000' AS DateTime), CAST(25.00 AS Decimal(18, 2)), 431918)
GO
INSERT [dbo].[tech_payments] ([id], [id_card], [date], [amount], [noAuth]) VALUES (18, 2, CAST(N'2024-12-28T00:00:00.000' AS DateTime), CAST(35.00 AS Decimal(18, 2)), 952633)
GO
INSERT [dbo].[tech_payments] ([id], [id_card], [date], [amount], [noAuth]) VALUES (19, 1, CAST(N'2024-12-29T01:15:53.217' AS DateTime), CAST(3.00 AS Decimal(18, 2)), 501656)
GO
INSERT [dbo].[tech_payments] ([id], [id_card], [date], [amount], [noAuth]) VALUES (20, 1, CAST(N'2024-12-19T00:00:00.000' AS DateTime), CAST(2.00 AS Decimal(18, 2)), 550616)
GO
SET IDENTITY_INSERT [dbo].[tech_payments] OFF
GO
SET IDENTITY_INSERT [dbo].[tech_user] ON 
GO
INSERT [dbo].[tech_user] ([id], [client_name], [email]) VALUES (1, N'David Castro', N'davidcastro@correo.com')
GO
INSERT [dbo].[tech_user] ([id], [client_name], [email]) VALUES (2, N'Jose Perez', N'perez@correo.com')
GO
SET IDENTITY_INSERT [dbo].[tech_user] OFF
GO
/****** Object:  StoredProcedure [dbo].[getEstado]    Script Date: 28/12/2024 22:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getEstado]
@idCard int
AS
SET NOCOUNT ON;

    Declare @movs decimal = (SELECT COALESCE(SUM(amount), 0) FROM tech_movs WHERE id_card = @idCard);
    Declare @pays decimal = (SELECT COALESCE(SUM(amount), 0) FROM tech_payments WHERE id_card = @idCard);

    SELECT 
        u.client_name as Nombre_cliente, 
        c.card_number as Numero_tarjeta,
        CASE 
            WHEN @movs > 0 AND @pays > 0 THEN @movs - @pays
            ELSE 0
        END as Saldo_total,
        CASE 
            WHEN @movs > 0 AND @pays > 0 THEN (@movs - @pays) * 0.05
            ELSE 0
        END AS Cuota_minima,
        CASE 
            WHEN @movs > 0 AND @pays > 0 THEN (@movs - @pays) * 1.25
            ELSE 0
        END as Pago_intereses 
    FROM tech_user u 
        INNER JOIN tech_card c ON c.id_user = u.id
        LEFT JOIN tech_payments p ON c.id = p.id_card
        LEFT JOIN tech_movs m ON c.id = m.id_card
    WHERE c.id = @idCard
    GROUP BY u.client_name, c.card_number;
GO
/****** Object:  StoredProcedure [dbo].[getMovs]    Script Date: 28/12/2024 22:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getMovs]
@IdCard int
AS
SELECT id_card AS IdCard, date_shop as Fecha, description_mov as Descrip, amount as Price, noAuth as Numero_autorizacion
FROM tech_movs
WHERE id_card = @idCard
GO
/****** Object:  StoredProcedure [dbo].[getPayments]    Script Date: 28/12/2024 22:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getPayments]
@idCard int
AS
SELECT id_card as IdCard, date as Fecha, amount as Amount FROM tech_payments WHERE id_card = @idCard
GO
/****** Object:  StoredProcedure [dbo].[getTransacciones]    Script Date: 28/12/2024 22:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getTransacciones]
@IdCard int
as
SELECT u.client_name as Nombre_cliente, c.card_number as Numero_tarjeta, m.noAuth as Numero_autorizacion,
		m.date_shop as Fecha, m.description_mov as Descr, m.amount as Cargo, 0 as Abono
FROM tech_user u
INNER JOIN tech_card c ON c.id_user = u.id
INNER JOIN tech_movs m ON m.id_card = c.id
WHERE C.id = @IdCard 
UNION 
SELECT u.client_name as Nombre_cliente, c.card_number as Numero_tarjeta, m.noAuth as Numero_autorizacion,
		m.date as Fecha, 'Pago TC' as Descr, 0 as Cargo, m.amount as Abono
FROM tech_user u
INNER JOIN tech_card c ON c.id_user = u.id
INNER JOIN tech_payments m ON m.id_card = c.id
WHERE C.id = @IdCard ORDER BY Fecha DESC
GO
/****** Object:  StoredProcedure [dbo].[GetUserInfo]    Script Date: 28/12/2024 22:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserInfo]
AS
SELECT  c.id as Id, u.client_name as Client_name , c.card_number as Numero_Tarjeta
FROM tech_user u 
INNER JOIN tech_card c ON c.id_user = u.id
GO
/****** Object:  StoredProcedure [dbo].[newMov]    Script Date: 28/12/2024 22:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[newMov]
@idCard int, 
@date datetime,
@description varchar(100),
@price decimal(18, 2)
AS


DECLARE @code NVARCHAR(50) SET @code = (
   SELECT ABS(CHECKSUM(NEWID())) % 900000 + 100000)

 INSERT INTO tech_movs (id_card, date_shop, description_mov, amount, noAuth )
			values(@idCard, @date, @description, @price,@code)

SELECT id_card AS IdCard, date_shop as Fecha, description_mov as Descrip, amount as Price, noAuth as Numero_autorizacion
FROM tech_movs
WHERE id = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[newPayment]    Script Date: 28/12/2024 22:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[newPayment]
  @idCard int,
  @date datetime,
  @amount decimal(18,2)
  AS

  
DECLARE @code NVARCHAR(50) SET @code = (
   SELECT ABS(CHECKSUM(NEWID())) % 900000 + 100000)

  INSERT INTO tech_payments(id_card, date, amount, noAuth)
			VALUES(@idCard, @date, @amount, @code)

SELECT id_card as IdCard, date as Fecha, amount as Amount FROM tech_payments WHERE id =@@IDENTITY
GO
