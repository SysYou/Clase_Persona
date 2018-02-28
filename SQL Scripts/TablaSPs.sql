USE [Fidelitas]
GO

/****** Object:  Table [dbo].[Persona]    Script Date: 2/2/2018 20:24:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Persona](
	[iCedula] [int] NOT NULL,
	[vNombre] [varchar](50) NULL,
	[bMuerto] [bit] NULL,
	[iEdad] [int] NULL,
	[vEmail] [varchar](50) NULL,
	[dtNacimiento] [date] NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[iCedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

------------------------
USE [Fidelitas]
GO

/****** Object:  StoredProcedure [dbo].[sp_Mostrar]    Script Date: 2/2/2018 20:24:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_Mostrar] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from Persona;

END

GO



---------------------

USE [Fidelitas]
GO

/****** Object:  StoredProcedure [dbo].[sp_Insertar]    Script Date: 2/2/2018 20:25:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sp_Insertar] 

@iCedula int, 

@vNombre varchar(50),

@bMuerto bit,

@dtNacimiento date,

@iEdad int,

@vEmail varchar(50)

AS

BEGIN

SET NOCOUNT ON;

INSERT INTO Persona (iCedula, vNombre, bMuerto, dtNacimiento, iEdad, vEmail)

VALUES        (@iCedula,@vNombre,@bMuerto,@dtNacimiento,@iEdad,@vEmail);

END


GO

---------------------------
USE [Fidelitas]
GO

/****** Object:  StoredProcedure [dbo].[sp_Actualizar]    Script Date: 2/2/2018 20:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_Actualizar] 
	-- Add the parameters for the stored procedure here

@iCedula int, 
@vNombre varchar(50) = null,
@bMuerto bit = null,
@dtNacimiento date = null,
@iEdad int = null,
@vEmail varchar(50) = null

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

UPDATE       Persona
SET          vNombre =@vNombre ,
             bMuerto = @bMuerto, 
			 iEdad = @iEdad, 
			 vEmail = @vEmail, 
			 dtNacimiento = @dtNacimiento
WHERE        (iCedula = @iCedula);


END


GO
---------------


USE [Fidelitas]
GO
/****** Object:  StoredProcedure [dbo].[sp_Eliminar]    Script Date: 2/27/2018 6:43:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_Eliminar]

@iCedula int

AS

BEGIN

SET NOCOUNT ON;

 Delete from Persona 
 WHERE (iCedula = @iCedula);

END




