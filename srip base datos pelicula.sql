USE [PeliculasApiPruebas]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25/07/2022 12:10:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actores]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Biografia] [nvarchar](max) NULL,
	[FechaNacimiento] [datetime2](7) NOT NULL,
	[Foto] [nvarchar](max) NULL,
 CONSTRAINT [PK_Actores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cines]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](75) NOT NULL,
	[Ubicacion] [geography] NULL,
 CONSTRAINT [PK_Cines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Generos]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Generos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Peliculas]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Peliculas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](300) NOT NULL,
	[Resumen] [nvarchar](max) NULL,
	[Trailer] [nvarchar](max) NULL,
	[EnCines] [bit] NOT NULL,
	[FechaLanzamiento] [datetime2](7) NOT NULL,
	[Poster] [nvarchar](max) NULL,
 CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeliculasActores]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeliculasActores](
	[ActorId] [int] NOT NULL,
	[PeliculasId] [int] NOT NULL,
	[Personaje] [nvarchar](100) NULL,
	[Orden] [int] NOT NULL,
 CONSTRAINT [PK_PeliculasActores] PRIMARY KEY CLUSTERED 
(
	[ActorId] ASC,
	[PeliculasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeliculasCines]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeliculasCines](
	[CineId] [int] NOT NULL,
	[PeliculasId] [int] NOT NULL,
 CONSTRAINT [PK_PeliculasCines] PRIMARY KEY CLUSTERED 
(
	[PeliculasId] ASC,
	[CineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeliculasGeneros]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeliculasGeneros](
	[GeneroId] [int] NOT NULL,
	[PeliculasId] [int] NOT NULL,
 CONSTRAINT [PK_PeliculasGeneros] PRIMARY KEY CLUSTERED 
(
	[PeliculasId] ASC,
	[GeneroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 25/07/2022 12:10:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Puntuacion] [int] NOT NULL,
	[PeliculaId] [int] NOT NULL,
	[UsuarioId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220503232649_baseDatos', N'5.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220512202618_cambioIsPeliculasRelaciones', N'5.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220516225452_SistemaUsuarios', N'5.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220518140202_Ratings', N'5.0.11')
GO
SET IDENTITY_INSERT [dbo].[Actores] ON 
GO
INSERT [dbo].[Actores] ([Id], [Nombre], [Biografia], [FechaNacimiento], [Foto]) VALUES (1, N'Tom Hollan', N'pruebas', CAST(N'2021-11-03T00:00:00.0000000' AS DateTime2), N'https://localhost:44327\personas\47c305f8-5be1-464f-b1ba-cfd2e4cf7542.jpg')
GO
INSERT [dbo].[Actores] ([Id], [Nombre], [Biografia], [FechaNacimiento], [Foto]) VALUES (2, N'Pruebas', N'pruebas 2', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), N'https://localhost:44327\personas\debec768-b120-437f-a87d-13beb15f5a52.jpg')
GO
INSERT [dbo].[Actores] ([Id], [Nombre], [Biografia], [FechaNacimiento], [Foto]) VALUES (3, N'Pruebas', N'ddfsdf', CAST(N'2021-12-16T00:00:00.0000000' AS DateTime2), N'https://localhost:44327\personas\debec768-b120-437f-a87d-13beb15f5a52.jpg')
GO
INSERT [dbo].[Actores] ([Id], [Nombre], [Biografia], [FechaNacimiento], [Foto]) VALUES (4, N'Dgggg', N'asdasd', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), N'https://localhost:44327\personas\debec768-b120-437f-a87d-13beb15f5a52.jpg')
GO
INSERT [dbo].[Actores] ([Id], [Nombre], [Biografia], [FechaNacimiento], [Foto]) VALUES (5, N'Mario', N'Pruebas', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), N'https://localhost:44327\personas\debec768-b120-437f-a87d-13beb15f5a52.jpg')
GO
INSERT [dbo].[Actores] ([Id], [Nombre], [Biografia], [FechaNacimiento], [Foto]) VALUES (6, N'Pruebas', N'asdasd', CAST(N'2021-12-10T00:00:00.0000000' AS DateTime2), N'https://localhost:44327\personas\debec768-b120-437f-a87d-13beb15f5a52.jpg')
GO
INSERT [dbo].[Actores] ([Id], [Nombre], [Biografia], [FechaNacimiento], [Foto]) VALUES (7, N'Pruebas', N'dfgdfg', CAST(N'2021-12-16T00:00:00.0000000' AS DateTime2), N'https://localhost:44327\personas\debec768-b120-437f-a87d-13beb15f5a52.jpg')
GO
INSERT [dbo].[Actores] ([Id], [Nombre], [Biografia], [FechaNacimiento], [Foto]) VALUES (8, N'Pruebas', N'Pruebas', CAST(N'2022-04-08T00:00:00.0000000' AS DateTime2), N'https://localhost:44327\personas\debec768-b120-437f-a87d-13beb15f5a52.jpg')
GO
INSERT [dbo].[Actores] ([Id], [Nombre], [Biografia], [FechaNacimiento], [Foto]) VALUES (9, N'Cosa dos', N'pruebas 3', CAST(N'2022-04-26T00:00:00.0000000' AS DateTime2), N'https://localhost:44327\personas\debec768-b120-437f-a87d-13beb15f5a52.jpg')
GO
INSERT [dbo].[Actores] ([Id], [Nombre], [Biografia], [FechaNacimiento], [Foto]) VALUES (10, N'Cosa dos3', N'Pruebas', CAST(N'2022-04-26T00:00:00.0000000' AS DateTime2), N'https://localhost:44327\personas\debec768-b120-437f-a87d-13beb15f5a52.jpg')
GO
INSERT [dbo].[Actores] ([Id], [Nombre], [Biografia], [FechaNacimiento], [Foto]) VALUES (11, N'Pruba Creacion2', N'asdasd', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[Actores] OFF
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, N'8ec90d46-4d6a-40a9-8436-bf6d5b798467', N'role', N'admin')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'51230225-d594-4fd8-ae9a-ef7236de6987', N'usuario2@gmail.com', N'USUARIO2@GMAIL.COM', N'usuario2@gmail.com', N'USUARIO2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEFXrM8Ag7JxQboF3dQIYMq3jysgK+6d/+PjYxnSGdKz2wVXiweLNqlP2cAJOLudt8Q==', N'7S3NUAPSIMV6H76X34YRF7ECWS4AID7O', N'80257567-74a3-4d27-b6b4-1f2f195b0967', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8ec90d46-4d6a-40a9-8436-bf6d5b798467', N'julio@gmail.com', N'JULIO@GMAIL.COM', N'julio@gmail.com', N'JULIO@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEORBczwh0HFwXjIFZQ0DQUqFPw0WbyB3Fek1tfX0Cq1bF/0BY5ObxPh9kentjQpT8Q==', N'LKOW2IDDB3WR4RLOI4QUEKSFD22H2RNH', N'0606d51c-f088-4f16-beda-b9e92a19a2e6', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Cines] ON 
GO
INSERT [dbo].[Cines] ([Id], [Nombre], [Ubicacion]) VALUES (1, N'Accion2', 0xE6100000010C00000000000000000000000000000000)
GO
INSERT [dbo].[Cines] ([Id], [Nombre], [Ubicacion]) VALUES (2, N'Cine prueba5', 0xE6100000010CF90DB5CCC8B01840010000800E387BC0)
GO
SET IDENTITY_INSERT [dbo].[Cines] OFF
GO
SET IDENTITY_INSERT [dbo].[Generos] ON 
GO
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (1, N'Accion')
GO
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (2, N'Scrifi')
GO
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (3, N'Romance')
GO
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (4, N'Comedia')
GO
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (5, N'Drama 2')
GO
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (6, N'Drama')
GO
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (7, N'Animacion')
GO
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (8, N'Aventura')
GO
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (9, N'Fantasia')
GO
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (10, N'Biografia')
GO
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (11, N'Documental')
GO
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (12, N'Guerra2')
GO
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (13, N'Pruebas blazor')
GO
SET IDENTITY_INSERT [dbo].[Generos] OFF
GO
SET IDENTITY_INSERT [dbo].[Peliculas] ON 
GO
INSERT [dbo].[Peliculas] ([Id], [Titulo], [Resumen], [Trailer], [EnCines], [FechaLanzamiento], [Poster]) VALUES (1, N'Spider-Man Far From Home', N'pruebas edicion', N'', 1, CAST(N'2022-05-11T00:00:00.0000000' AS DateTime2), N'https://localhost:44327\peliculas\c7abacf9-7e70-4393-8e46-d71c0b8235b8.jpg')
GO
INSERT [dbo].[Peliculas] ([Id], [Titulo], [Resumen], [Trailer], [EnCines], [FechaLanzamiento], [Poster]) VALUES (2, N'Moana', N'Pruebas', N'', 0, CAST(N'2022-05-27T00:00:00.0000000' AS DateTime2), N'https://localhost:44327\peliculas\c7abacf9-7e70-4393-8e46-d71c0b8235b8.jpg')
GO
INSERT [dbo].[Peliculas] ([Id], [Titulo], [Resumen], [Trailer], [EnCines], [FechaLanzamiento], [Poster]) VALUES (8, N'Los pitufos', N'pruebas', N'https://www.youtube.com/watch?v=k9Q-HuuuNRY', 1, CAST(N'2022-06-28T00:00:00.0000000' AS DateTime2), N'https://localhost:44327\peliculas\c7abacf9-7e70-4393-8e46-d71c0b8235b8.jpg')
GO
SET IDENTITY_INSERT [dbo].[Peliculas] OFF
GO
INSERT [dbo].[PeliculasActores] ([ActorId], [PeliculasId], [Personaje], [Orden]) VALUES (5, 1, N'Piter parker', 0)
GO
INSERT [dbo].[PeliculasActores] ([ActorId], [PeliculasId], [Personaje], [Orden]) VALUES (5, 2, N'Moana', 0)
GO
INSERT [dbo].[PeliculasActores] ([ActorId], [PeliculasId], [Personaje], [Orden]) VALUES (6, 1, N'Nick fury', 1)
GO
INSERT [dbo].[PeliculasCines] ([CineId], [PeliculasId]) VALUES (1, 1)
GO
INSERT [dbo].[PeliculasCines] ([CineId], [PeliculasId]) VALUES (2, 1)
GO
INSERT [dbo].[PeliculasCines] ([CineId], [PeliculasId]) VALUES (2, 2)
GO
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculasId]) VALUES (1, 1)
GO
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculasId]) VALUES (7, 2)
GO
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculasId]) VALUES (8, 1)
GO
INSERT [dbo].[PeliculasGeneros] ([GeneroId], [PeliculasId]) VALUES (9, 1)
GO
SET IDENTITY_INSERT [dbo].[Ratings] ON 
GO
INSERT [dbo].[Ratings] ([Id], [Puntuacion], [PeliculaId], [UsuarioId]) VALUES (1, 4, 2, N'8ec90d46-4d6a-40a9-8436-bf6d5b798467')
GO
INSERT [dbo].[Ratings] ([Id], [Puntuacion], [PeliculaId], [UsuarioId]) VALUES (2, 5, 1, N'51230225-d594-4fd8-ae9a-ef7236de6987')
GO
INSERT [dbo].[Ratings] ([Id], [Puntuacion], [PeliculaId], [UsuarioId]) VALUES (3, 5, 2, N'51230225-d594-4fd8-ae9a-ef7236de6987')
GO
INSERT [dbo].[Ratings] ([Id], [Puntuacion], [PeliculaId], [UsuarioId]) VALUES (4, 5, 1, N'8ec90d46-4d6a-40a9-8436-bf6d5b798467')
GO
SET IDENTITY_INSERT [dbo].[Ratings] OFF
GO
ALTER TABLE [dbo].[PeliculasActores] ADD  DEFAULT ((0)) FOR [PeliculasId]
GO
ALTER TABLE [dbo].[PeliculasCines] ADD  DEFAULT ((0)) FOR [PeliculasId]
GO
ALTER TABLE [dbo].[PeliculasGeneros] ADD  DEFAULT ((0)) FOR [PeliculasId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[PeliculasActores]  WITH CHECK ADD  CONSTRAINT [FK_PeliculasActores_Actores_ActorId] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actores] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PeliculasActores] CHECK CONSTRAINT [FK_PeliculasActores_Actores_ActorId]
GO
ALTER TABLE [dbo].[PeliculasActores]  WITH CHECK ADD  CONSTRAINT [FK_PeliculasActores_Peliculas_PeliculasId] FOREIGN KEY([PeliculasId])
REFERENCES [dbo].[Peliculas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PeliculasActores] CHECK CONSTRAINT [FK_PeliculasActores_Peliculas_PeliculasId]
GO
ALTER TABLE [dbo].[PeliculasCines]  WITH CHECK ADD  CONSTRAINT [FK_PeliculasCines_Cines_CineId] FOREIGN KEY([CineId])
REFERENCES [dbo].[Cines] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PeliculasCines] CHECK CONSTRAINT [FK_PeliculasCines_Cines_CineId]
GO
ALTER TABLE [dbo].[PeliculasCines]  WITH CHECK ADD  CONSTRAINT [FK_PeliculasCines_Peliculas_PeliculasId] FOREIGN KEY([PeliculasId])
REFERENCES [dbo].[Peliculas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PeliculasCines] CHECK CONSTRAINT [FK_PeliculasCines_Peliculas_PeliculasId]
GO
ALTER TABLE [dbo].[PeliculasGeneros]  WITH CHECK ADD  CONSTRAINT [FK_PeliculasGeneros_Generos_GeneroId] FOREIGN KEY([GeneroId])
REFERENCES [dbo].[Generos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PeliculasGeneros] CHECK CONSTRAINT [FK_PeliculasGeneros_Generos_GeneroId]
GO
ALTER TABLE [dbo].[PeliculasGeneros]  WITH CHECK ADD  CONSTRAINT [FK_PeliculasGeneros_Peliculas_PeliculasId] FOREIGN KEY([PeliculasId])
REFERENCES [dbo].[Peliculas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PeliculasGeneros] CHECK CONSTRAINT [FK_PeliculasGeneros_Peliculas_PeliculasId]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_AspNetUsers_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_AspNetUsers_UsuarioId]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Peliculas_PeliculaId] FOREIGN KEY([PeliculaId])
REFERENCES [dbo].[Peliculas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Peliculas_PeliculaId]
GO
