USE [SuperherosDb]
GO

INSERT INTO [dbo].[Power]
           ([Name]
           ,[Description])
     VALUES
           ('Speed',
           'Fast as the speed of light')
INSERT INTO [dbo].[Power]
           ([Name]
           ,[Description])
     VALUES
           ('Strength',
           'Strongest man on earth')
INSERT INTO [dbo].[Power]
           ([Name]
           ,[Description])
     VALUES
           ('Intelligence',
           'Super super smart')
INSERT INTO [dbo].[Power]
           ([Name]
           ,[Description])
     VALUES
           ('Spider sence',
           'Can predit enemies coming')
INSERT INTO [dbo].[SuperheroPower]
           ([SuperheroId]
           ,[PowerId])
     VALUES
           (1,
           1)
INSERT INTO [dbo].[SuperheroPower]
           ([SuperheroId]
           ,[PowerId])
     VALUES
           (1,
           2)
INSERT INTO [dbo].[SuperheroPower]
           ([SuperheroId]
           ,[PowerId])
     VALUES
           (2,
           4)
INSERT INTO [dbo].[SuperheroPower]
           ([SuperheroId]
           ,[PowerId])
     VALUES
           (3,
           3)
INSERT INTO [dbo].[SuperheroPower]
           ([SuperheroId]
           ,[PowerId])
     VALUES
           (3,
           1)
GO


