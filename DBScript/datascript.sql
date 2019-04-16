
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (1, N'INDIA')
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (2, N'USA')
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (3, N'UK')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([CityId], [CityName], [CountryId]) VALUES (1, N'New Delhi', 1)
INSERT [dbo].[City] ([CityId], [CityName], [CountryId]) VALUES (2, N'Banglore', 1)
INSERT [dbo].[City] ([CityId], [CityName], [CountryId]) VALUES (3, N'Mumbai', 1)
INSERT [dbo].[City] ([CityId], [CityName], [CountryId]) VALUES (4, N'Califotnia', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CountryId]) VALUES (5, N'New York', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CountryId]) VALUES (6, N'Washigton', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CountryId]) VALUES (7, N'London', 3)
INSERT [dbo].[City] ([CityId], [CityName], [CountryId]) VALUES (8, N'Derby', 3)
INSERT [dbo].[City] ([CityId], [CityName], [CountryId]) VALUES (9, N'Knotingham', 3)
SET IDENTITY_INSERT [dbo].[City] OFF
