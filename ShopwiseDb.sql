USE [ShopwiseDB]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0ec9563d-6d28-431d-8a41-15df74b730da', N'Accountant', N'ACCOUNTANT', N'e923cc2a-a5ec-4bfa-91d3-f1af93d16b6b')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2134b394-c845-4250-8842-27c69f327249', N'User', N'USER', N'd69f4ba2-312c-4936-b3ed-41f92938543e')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bafde660-09e4-465e-a832-a9bd7f40a811', N'Moderator', N'MODERATOR', N'3caf659f-5985-4773-976e-9789039237dc')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd9d659d8-5ebb-42ac-886d-3b47ec4c9b78', N'Customer', N'CUSTOMER', N'49fd77f1-3806-4146-9a5b-a76a18c8161a')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e523a58e-b9b6-4d00-9fab-eb2feb26bd57', N'Admin', N'ADMIN', N'9b18a195-88eb-4c8f-b376-bee226634ac4')
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (1, N'Azerbaijan', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (2, N'Argentina', CAST(21.00 AS Decimal(18, 2)))
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (3, N'Australia', CAST(22.00 AS Decimal(18, 2)))
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (4, N'Austria', CAST(13.02 AS Decimal(18, 2)))
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (5, N'Bahamas', CAST(9.99 AS Decimal(18, 2)))
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (6, N'Bahrain', CAST(18.40 AS Decimal(18, 2)))
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (7, N'Bangladesh', CAST(17.07 AS Decimal(18, 2)))
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (8, N'Barbados', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (9, N'Belarus', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (10, N'Belgium', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (11, N'Bolivia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (12, N'Bosnia and Herzegovina', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (13, N'Brazil', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (14, N'Bulgaria', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (15, N'Canada', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (16, N'Central African Republic', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (17, N'Chile', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (18, N'China', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (19, N'Colombia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (20, N'Costa Rica	', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (21, N'Croatia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (22, N'Cuba', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (23, N'Cyprus', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (24, N'Czechia (Czech Republic)', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (25, N'Dominica', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (26, N'Dominican Republic', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (27, N'Ecuador', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (28, N'Egypt', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (29, N'El Salvador', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (30, N'Equatorial Guinea', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (31, N'Eritrea', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (32, N'Estonia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (33, N'Ethiopia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (34, N'Fiji', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (35, N'Finland', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (36, N'France', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (37, N'Gabon', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (38, N'Gambia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (39, N'Georgia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (40, N'Germany', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (41, N'Ghana', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (42, N'Greece', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (43, N'Grenada', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (44, N'Guatemala', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (45, N'Guinea', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (46, N'Guinea-Bissau', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (47, N'Guyana', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (48, N'Haiti', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (49, N'Holy See', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (50, N'Honduras', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (51, N'Hungary', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (52, N'Iceland', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (53, N'India', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (54, N'Indonesia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (55, N'Iran', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (56, N'Iraq', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (57, N'Ireland', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (58, N'Israel', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (59, N'Italy', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (60, N'Jamaica', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (61, N'Japan', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (62, N'Jordan', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (63, N'Kazakhstan', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (64, N'Kenya', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (65, N'Kiribati', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (66, N'Kuwait', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (67, N'Kyrgyzstan', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (68, N'Laos', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (69, N'Latvia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (70, N'Lebanon', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (71, N'Lesotho', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (72, N'Liberia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (73, N'Libya', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (74, N'Liechtenstein', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (75, N'Lithuania', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (76, N'Luxembourg', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (77, N'Malaysia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (78, N'Malta', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (79, N'Mexico', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (80, N'Moldova', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (81, N'Namibia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (82, N'Nepal', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (83, N'New Zealand	', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (84, N'North Korea	', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (85, N'Oman', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (86, N'Pakistan', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (87, N'Peru', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (88, N'Philippines', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (89, N'Poland', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (90, N'Portugal', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (91, N'Qatar', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (92, N'Romania', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (93, N'Russia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (94, N'Saint Lucia	', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (95, N'San Marino	', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (96, N'Saudi Arabia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (97, N'Slovakia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (98, N'South Korea', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (99, N'Spain', NULL)
GO
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (100, N'Sweden', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (101, N'Switzerland', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (102, N'Syria', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (103, N'Turkey', CAST(12.02 AS Decimal(18, 2)))
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (104, N'Turkmenistan', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (105, N'Ukraine', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (106, N'United Arab Emirates	', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (107, N'United Kingdom	', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (108, N'United States of America', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (109, N'Uzbekistan', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (110, N'Vanuatu', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (111, N'Venezuela', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (112, N'Vietnam', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (113, N'Yemen', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (114, N'Zambia', NULL)
INSERT [dbo].[Countries] ([Id], [Name], [ShippingPrice]) VALUES (116, N'Zimbabwe', NULL)
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [Name], [Surname], [CountryId], [Image], [Phone], [State], [ZipCode]) VALUES (N'3a67035c-e594-4514-9ea5-dec0f74c3242', N'muhasib@gmail.com', N'MUHASIB@GMAIL.COM', N'muhasib@gmail.com', N'MUHASIB@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEERLX+y7yHyVa//nYoEnlDJqlzWcEhxjGqs3eRX3kGeMm7HiGhE9lIThP4nSK3mVVw==', N'5WASQD5UYYDNGRDVTW52KXO25KN2V4G2', N'9491a015-9443-4bc6-90fc-e9243d953f8f', NULL, 0, 0, NULL, 1, 0, N'CustomUser', N'Muhasib', N'Muhasibov', 99, NULL, N'(012) 666 66 66', N'Madrid', N'1122')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [Name], [Surname], [CountryId], [Image], [Phone], [State], [ZipCode]) VALUES (N'7287ef77-800d-4485-9fac-fbd0a780cffe', N'siravivetendash@gmail.com', N'SIRAVIVETENDASH@GMAIL.COM', N'siravivetendash@gmail.com', N'SIRAVIVETENDASH@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAELtOj+QQ0zkx7dm5hXuiNXqDvvWFtwPoCRcg7mJg9GT8q4C1UN46gFR20K8FbiSw3w==', N'GT6SCLKQLHZKP4EN3D2POGF2KRO4HLXB', N'76a63d36-6d63-42f2-98df-1369cc476fc7', NULL, 0, 0, NULL, 1, 0, N'CustomUser', N'Siravi', N'Vetendash', 1, NULL, N'(055) 555 55 55', N'Baku', N'1122')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [Name], [Surname], [CountryId], [Image], [Phone], [State], [ZipCode]) VALUES (N'88b2495d-edbb-4fd2-a0c7-a33b50e1a3d1', N'vetendash@gmail.com', N'VETENDASH@GMAIL.COM', N'vetendash@gmail.com', N'VETENDASH@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEL5CG2nKwze1agTRcctDxky/20jqdahxZnZtvtHNcd3VO64nMCce750gQRcQOX9MQw==', N'PNI6L46MQ2WEVWCDZ2X5JSKRJNUYHXHE', N'acab0205-067f-4c31-8e24-4d0156400c69', NULL, 0, 0, NULL, 1, 0, N'CustomUser', N'Vetendash', N'Vetendashov', 1, N'72e43ceb-4115-4822-a0c0-f2afbba19f8c-26072021011825-user2.jpg', N'(050) 211 11 12', N'Baku', N'1122')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [Name], [Surname], [CountryId], [Image], [Phone], [State], [ZipCode]) VALUES (N'9e00489e-5405-4431-a254-49448993c4e6', N'agilab@code.edu.az', N'AGILAB@CODE.EDU.AZ', N'agilab@code.edu.az', N'AGILAB@CODE.EDU.AZ', 0, N'AQAAAAEAACcQAAAAEK3guVAl5VnZbfUtKv5cAYQ3GVK0hEIF49RKlHNjrbDZwuN2t1XCW14Y2/G7DwZ54g==', N'QKZHH5Z2NEUPJ5Q6RZTQXWEJZVKOF3WA', N'956f47ff-87ca-4274-9a97-a94fbfa718a5', NULL, 0, 0, NULL, 1, 0, N'CustomUser', N'Agil', N'Bashirov', 1, N'admin.jpg', N'(055) 555 55 55', N'Baku', N'1122')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3a67035c-e594-4514-9ea5-dec0f74c3242', N'0ec9563d-6d28-431d-8a41-15df74b730da')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'88b2495d-edbb-4fd2-a0c7-a33b50e1a3d1', N'bafde660-09e4-465e-a832-a9bd7f40a811')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7287ef77-800d-4485-9fac-fbd0a780cffe', N'd9d659d8-5ebb-42ac-886d-3b47ec4c9b78')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9e00489e-5405-4431-a254-49448993c4e6', N'e523a58e-b9b6-4d00-9fab-eb2feb26bd57')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Best Sellers')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Featured')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'New Arrival')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Special Offer')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([Id], [Name]) VALUES (1, N'Men')
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (2, N'Women')
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (3, N'Kid''s')
SET IDENTITY_INSERT [dbo].[Gender] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Desc], [AddedDate], [GenderId], [CategoryId]) VALUES (3, N'Dress For Women', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus blandit massa enim. Nullam id varius nunc id varius nunc.', CAST(N'2021-07-04T00:00:00.0000000' AS DateTime2), 2, 1)
INSERT [dbo].[Products] ([Id], [Name], [Desc], [AddedDate], [GenderId], [CategoryId]) VALUES (6, N'T-Shirt For Women', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus blandit massa enim. Nullam id varius nunc id varius nunc.', CAST(N'2021-07-04T00:00:00.0000000' AS DateTime2), 2, 1)
INSERT [dbo].[Products] ([Id], [Name], [Desc], [AddedDate], [GenderId], [CategoryId]) VALUES (7, N'Shirt For Kid''s', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus blandit massa enim. Nullam id varius nunc id varius nunc.', CAST(N'2021-07-04T00:00:00.0000000' AS DateTime2), 3, 3)
INSERT [dbo].[Products] ([Id], [Name], [Desc], [AddedDate], [GenderId], [CategoryId]) VALUES (8, N'Jacket For Men', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus blandit massa enim. Nullam id varius nunc id varius nunc.', CAST(N'2021-07-04T00:00:00.0000000' AS DateTime2), 1, 2)
INSERT [dbo].[Products] ([Id], [Name], [Desc], [AddedDate], [GenderId], [CategoryId]) VALUES (9, N'Shirt For Men', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus blandit massa enim. Nullam id varius nunc id varius nunc.', CAST(N'2021-07-04T00:00:00.0000000' AS DateTime2), 1, 4)
INSERT [dbo].[Products] ([Id], [Name], [Desc], [AddedDate], [GenderId], [CategoryId]) VALUES (10, N'Blue Casual Check Shirt', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus blandit massa enim. Nullam id varius nunc id varius nunc.', CAST(N'2021-07-04T00:00:00.0000000' AS DateTime2), 1, 3)
INSERT [dbo].[Products] ([Id], [Name], [Desc], [AddedDate], [GenderId], [CategoryId]) VALUES (18, N'Mango T-Shirt For Women', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus blandit massa enim. Nullam id varius nunc id varius nunc.', CAST(N'2021-07-21T22:47:37.1289924' AS DateTime2), 2, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [CustomUserId], [Text], [Rating], [AddedDate], [ProductId]) VALUES (6, N'9e00489e-5405-4431-a254-49448993c4e6', N'It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters', 4, CAST(N'2021-07-04T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Comments] ([Id], [CustomUserId], [Text], [Rating], [AddedDate], [ProductId]) VALUES (12, N'88b2495d-edbb-4fd2-a0c7-a33b50e1a3d1', N'It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters', 3, CAST(N'2021-07-23T06:47:39.5713470' AS DateTime2), 3)
INSERT [dbo].[Comments] ([Id], [CustomUserId], [Text], [Rating], [AddedDate], [ProductId]) VALUES (14, N'9e00489e-5405-4431-a254-49448993c4e6', N'It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters', 5, CAST(N'2021-08-02T17:48:07.8474110' AS DateTime2), 3)
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Sales] ON 

INSERT [dbo].[Sales] ([Id], [InvoiceNo], [Date], [CustomUserId], [TotalPrice], [ShippingPrice], [CountryId], [State], [ZipCode]) VALUES (32, N'AZ-1', CAST(N'2021-08-05T02:30:17.5040544' AS DateTime2), N'9e00489e-5405-4431-a254-49448993c4e6', CAST(119.21 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Baku', N'1122')
INSERT [dbo].[Sales] ([Id], [InvoiceNo], [Date], [CustomUserId], [TotalPrice], [ShippingPrice], [CountryId], [State], [ZipCode]) VALUES (33, N'AZ-2', CAST(N'2021-08-05T02:46:37.5267633' AS DateTime2), N'9e00489e-5405-4431-a254-49448993c4e6', CAST(685.53 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Baku', N'1122')
INSERT [dbo].[Sales] ([Id], [InvoiceNo], [Date], [CustomUserId], [TotalPrice], [ShippingPrice], [CountryId], [State], [ZipCode]) VALUES (34, N'AZ-3', CAST(N'2021-08-05T03:47:33.3848660' AS DateTime2), N'9e00489e-5405-4431-a254-49448993c4e6', CAST(27.13 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Baku', N'1122')
INSERT [dbo].[Sales] ([Id], [InvoiceNo], [Date], [CustomUserId], [TotalPrice], [ShippingPrice], [CountryId], [State], [ZipCode]) VALUES (35, N'AZ-4', CAST(N'2021-08-06T18:55:20.5552070' AS DateTime2), N'9e00489e-5405-4431-a254-49448993c4e6', CAST(529.32 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'Baku', N'1122')
SET IDENTITY_INSERT [dbo].[Sales] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([Id], [Name]) VALUES (1, N'black')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (2, N'olive')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (3, N'pink')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (4, N'darkorange')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (5, N'blue')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (6, N'gray')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (7, N'white')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (9, N'red')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Sizes] ON 

INSERT [dbo].[Sizes] ([Id], [Name]) VALUES (1, N'XS')
INSERT [dbo].[Sizes] ([Id], [Name]) VALUES (2, N'S')
INSERT [dbo].[Sizes] ([Id], [Name]) VALUES (3, N'M')
INSERT [dbo].[Sizes] ([Id], [Name]) VALUES (4, N'L')
INSERT [dbo].[Sizes] ([Id], [Name]) VALUES (5, N'XL')
SET IDENTITY_INSERT [dbo].[Sizes] OFF
GO
SET IDENTITY_INSERT [dbo].[AllInfoToProducts] ON 

INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (1, 3, 3, 5, 0, CAST(65.22 AS Decimal(18, 2)), CAST(41.55 AS Decimal(18, 2)), CAST(N'2021-07-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (3, 6, 1, 7, 0, CAST(65.00 AS Decimal(18, 2)), CAST(32.00 AS Decimal(18, 2)), CAST(N'2021-07-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (10, 3, 2, 5, 1, CAST(70.00 AS Decimal(18, 2)), CAST(41.55 AS Decimal(18, 2)), CAST(N'2021-08-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (11, 3, 1, 5, 13, CAST(65.00 AS Decimal(18, 2)), CAST(41.55 AS Decimal(18, 2)), CAST(N'2021-07-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (12, 3, 1, 7, 20, CAST(65.00 AS Decimal(18, 2)), CAST(41.55 AS Decimal(18, 2)), CAST(N'2021-07-19T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (13, 3, 2, 7, 19, CAST(65.00 AS Decimal(18, 2)), CAST(41.55 AS Decimal(18, 2)), CAST(N'2021-07-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (14, 3, 2, 1, 23, CAST(65.00 AS Decimal(18, 2)), CAST(41.55 AS Decimal(18, 2)), CAST(N'2021-07-19T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (15, 3, 3, 1, 50, CAST(65.00 AS Decimal(18, 2)), CAST(41.55 AS Decimal(18, 2)), CAST(N'2021-07-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (16, 3, 4, 1, 100, CAST(65.00 AS Decimal(18, 2)), CAST(41.55 AS Decimal(18, 2)), CAST(N'2021-07-29T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (17, 3, 5, 1, 120, CAST(65.00 AS Decimal(18, 2)), CAST(41.55 AS Decimal(18, 2)), CAST(N'2021-07-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (18, 3, 1, 2, 22, CAST(65.00 AS Decimal(18, 2)), CAST(41.55 AS Decimal(18, 2)), CAST(N'2021-07-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (19, 3, 3, 2, 22, CAST(65.00 AS Decimal(18, 2)), CAST(41.55 AS Decimal(18, 2)), CAST(N'2021-07-18T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (20, 6, 2, 7, 23, CAST(22.99 AS Decimal(18, 2)), CAST(17.99 AS Decimal(18, 2)), CAST(N'2021-07-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (21, 6, 3, 7, 55, CAST(22.99 AS Decimal(18, 2)), CAST(17.99 AS Decimal(18, 2)), CAST(N'2021-07-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (22, 6, 4, 7, 21, CAST(22.99 AS Decimal(18, 2)), CAST(17.99 AS Decimal(18, 2)), CAST(N'2021-07-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (23, 6, 5, 7, 21, CAST(22.99 AS Decimal(18, 2)), CAST(17.99 AS Decimal(18, 2)), CAST(N'2021-07-29T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (24, 7, 1, 5, 15, CAST(26.22 AS Decimal(18, 2)), CAST(19.55 AS Decimal(18, 2)), CAST(N'2021-07-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (25, 8, 1, 6, 45, CAST(150.00 AS Decimal(18, 2)), CAST(139.99 AS Decimal(18, 2)), CAST(N'2021-07-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (26, 8, 2, 6, 25, CAST(150.00 AS Decimal(18, 2)), CAST(139.99 AS Decimal(18, 2)), CAST(N'2021-07-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (27, 8, 3, 6, 15, CAST(150.00 AS Decimal(18, 2)), CAST(139.99 AS Decimal(18, 2)), CAST(N'2021-07-21T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (28, 9, 2, 3, 39, CAST(72.22 AS Decimal(18, 2)), CAST(55.99 AS Decimal(18, 2)), CAST(N'2021-07-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (29, 9, 3, 3, 55, CAST(72.22 AS Decimal(18, 2)), CAST(55.99 AS Decimal(18, 2)), CAST(N'2021-07-21T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (30, 9, 4, 3, 15, CAST(72.22 AS Decimal(18, 2)), CAST(55.99 AS Decimal(18, 2)), CAST(N'2021-07-21T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (31, 9, 1, 9, 15, CAST(65.00 AS Decimal(18, 2)), CAST(57.22 AS Decimal(18, 2)), CAST(N'2021-07-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (32, 9, 2, 9, 15, CAST(65.00 AS Decimal(18, 2)), CAST(57.22 AS Decimal(18, 2)), CAST(N'2021-07-21T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (33, 10, 2, 5, 5, CAST(44.11 AS Decimal(18, 2)), CAST(39.99 AS Decimal(18, 2)), CAST(N'2021-07-29T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (34, 10, 3, 5, 43, CAST(44.11 AS Decimal(18, 2)), CAST(39.99 AS Decimal(18, 2)), CAST(N'2021-07-21T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (35, 10, 4, 5, 55, CAST(41.11 AS Decimal(18, 2)), CAST(39.99 AS Decimal(18, 2)), CAST(N'2021-07-21T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AllInfoToProducts] ([Id], [ProductId], [SizeId], [ColorId], [Quantity], [Price], [DiscountPrice], [DiscountDeadline]) VALUES (36, 18, 1, 4, 36, CAST(39.99 AS Decimal(18, 2)), CAST(22.99 AS Decimal(18, 2)), CAST(N'2021-07-23T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[AllInfoToProducts] OFF
GO
SET IDENTITY_INSERT [dbo].[SaleItems] ON 

INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (50, 10, 32, 1, CAST(70.00 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (51, 20, 32, 1, CAST(22.99 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (52, 24, 32, 1, CAST(26.22 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (53, 10, 33, 1, CAST(70.00 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (54, 20, 33, 1, CAST(22.99 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (55, 24, 33, 1, CAST(26.22 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (56, 25, 33, 1, CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (57, 36, 33, 1, CAST(39.99 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (58, 33, 33, 1, CAST(44.11 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (59, 28, 33, 1, CAST(72.22 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (60, 14, 33, 1, CAST(65.00 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (61, 18, 33, 1, CAST(65.00 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (62, 11, 33, 1, CAST(65.00 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (63, 13, 33, 1, CAST(65.00 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (64, 20, 34, 1, CAST(22.99 AS Decimal(18, 2)))
INSERT [dbo].[SaleItems] ([Id], [AllInfoToProductId], [SaleId], [Quantity], [Price]) VALUES (65, 34, 35, 12, CAST(44.11 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[SaleItems] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImages] ON 

INSERT [dbo].[ProductImages] ([Id], [Image], [ColorId], [ProductId]) VALUES (1, N'66854eed-68bb-4885-ac77-a92763d49410-21072021043512-product1.webp', 5, 3)
INSERT [dbo].[ProductImages] ([Id], [Image], [ColorId], [ProductId]) VALUES (2, N'166591b0-ba0b-449d-8932-545520a78c07-21072021043523-product2.webp', 7, 3)
INSERT [dbo].[ProductImages] ([Id], [Image], [ColorId], [ProductId]) VALUES (3, N'd704c24d-eb5e-4100-ae43-f27971078474-21072021043533-product3.webp', 1, 3)
INSERT [dbo].[ProductImages] ([Id], [Image], [ColorId], [ProductId]) VALUES (4, N'4fe1692a-e3e1-48e6-bfea-643dd831464e-21072021043545-product4.webp', 2, 3)
INSERT [dbo].[ProductImages] ([Id], [Image], [ColorId], [ProductId]) VALUES (5, N'f68d621a-daf4-4ad8-965b-8740ca48b224-21072021043626-product5.webp', 7, 6)
INSERT [dbo].[ProductImages] ([Id], [Image], [ColorId], [ProductId]) VALUES (6, N'9ff3e23a-462b-4c72-bee1-cafb6dddb362-21072021041546-product_img4-1.webp', 5, 7)
INSERT [dbo].[ProductImages] ([Id], [Image], [ColorId], [ProductId]) VALUES (8, N'962f68fb-87fe-4a2b-9fdd-4d0eeed3083e-21072021043934-product_img2-1.webp', 6, 8)
INSERT [dbo].[ProductImages] ([Id], [Image], [ColorId], [ProductId]) VALUES (9, N'5bfd48ee-a24a-4edc-9eeb-e68876984552-21072021044143-product_img6-1.webp', 3, 9)
INSERT [dbo].[ProductImages] ([Id], [Image], [ColorId], [ProductId]) VALUES (10, N'ef4d1ab1-cee7-4de3-95e8-c77415e1fcdd-21072021044332-product_img10-1.webp', 9, 9)
INSERT [dbo].[ProductImages] ([Id], [Image], [ColorId], [ProductId]) VALUES (11, N'242ade65-cde8-4370-a58b-aa0370ea8c26-21072021044447-product_img8-1.webp', 5, 10)
INSERT [dbo].[ProductImages] ([Id], [Image], [ColorId], [ProductId]) VALUES (12, N'1eebfb7c-607f-4244-aeb8-4e40cd7d4c73-21072021230430-1_org_zoom (9).jpg', 4, 18)
SET IDENTITY_INSERT [dbo].[ProductImages] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductDescriptions] ON 

INSERT [dbo].[ProductDescriptions] ([Id], [Text], [ProductId]) VALUES (1, N'<p>Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Vivamus bibendum magna Lorem ipsum dolor sit amet, consectetur adipiscing elit.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio.</p>
', 3)
INSERT [dbo].[ProductDescriptions] ([Id], [Text], [ProductId]) VALUES (9, N'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Vivamus bibendum magna Lorem ipsum dolor sit amet, consectetur adipiscing elit.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio.
', 6)
INSERT [dbo].[ProductDescriptions] ([Id], [Text], [ProductId]) VALUES (10, N'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Vivamus bibendum magna Lorem ipsum dolor sit amet, consectetur adipiscing elit.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio.', 7)
INSERT [dbo].[ProductDescriptions] ([Id], [Text], [ProductId]) VALUES (11, N'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Vivamus bibendum magna Lorem ipsum dolor sit amet, consectetur adipiscing elit.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio.', 8)
INSERT [dbo].[ProductDescriptions] ([Id], [Text], [ProductId]) VALUES (12, N'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Vivamus bibendum magna Lorem ipsum dolor sit amet, consectetur adipiscing elit.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio.', 9)
INSERT [dbo].[ProductDescriptions] ([Id], [Text], [ProductId]) VALUES (13, N'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Vivamus bibendum magna Lorem ipsum dolor sit amet, consectetur adipiscing elit.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio.', 10)
INSERT [dbo].[ProductDescriptions] ([Id], [Text], [ProductId]) VALUES (14, N'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Vivamus bibendum magna Lorem ipsum dolor sit amet, consectetur adipiscing elit.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio.	', 18)
SET IDENTITY_INSERT [dbo].[ProductDescriptions] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductFeatures] ON 

INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (1, N'1 Year AL Jazeera Brand Warranty', 3)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (2, N'30 Day Return Policy', 3)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (3, N'Cash on Delivery available', 3)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (5, N'1 Year AL Jazeera Brand Warranty', 6)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (6, N'30 Day Return Policy', 6)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (7, N'Cash on Delivery available', 6)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (8, N'1 Year AL Jazeera Brand Warranty', 7)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (9, N'30 Day Return Policy', 7)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (10, N'Cash on Delivery available', 7)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (11, N'1 Year AL Jazeera Brand Warranty', 8)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (12, N'30 Day Return Policy', 8)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (13, N'Cash on Delivery available', 8)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (14, N'1 Year AL Jazeera Brand Warranty', 9)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (15, N'30 Day Return Policy', 9)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (16, N'Cash on Delivery available', 9)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (17, N'1 Year AL Jazeera Brand Warranty', 10)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (18, N'30 Day Return Policy', 10)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (19, N'Cash on Delivery available', 10)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (20, N'1 Year AL Jazeera Brand Warranty', 18)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (21, N'30 Day Return Policy', 18)
INSERT [dbo].[ProductFeatures] ([Id], [Name], [ProductId]) VALUES (22, N'Cash on Delivery available', 18)
SET IDENTITY_INSERT [dbo].[ProductFeatures] OFF
GO
SET IDENTITY_INSERT [dbo].[About] ON 

INSERT [dbo].[About] ([Id], [UpTitle], [Title], [DownTitle], [Text], [Image]) VALUES (1, N'About The Shopwise', N'Easy Way To Start A Success Business Solution', N'25 Years Experience passage of Internet tend to repeat predefined chunks as necessary', N'<p>If you are going to use a passage of Lorem Ipsum, you need to be sure there isn&#39;t anything embarrassing hidden in the middle of text.All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary</p>

<p>There are many variations of Lorem Ipsum available, but the majority have suffered alteration in some form</p>
', N'c1810f73-37f5-4f8b-b096-cd41112cb4c2-26072021070717-about.jpg')
SET IDENTITY_INSERT [dbo].[About] OFF
GO
SET IDENTITY_INSERT [dbo].[Advertisements] ON 

INSERT [dbo].[Advertisements] ([Id], [Image], [UpTitle], [Title], [DownTitle], [Section]) VALUES (1, N'641f8bdb-efb5-4175-8a74-b2e04dab3b71-24072021104200-advertisement.jpg', N'NEW COLLECTION', N'SALE 30% OFF', NULL, N'Shop')
INSERT [dbo].[Advertisements] ([Id], [Image], [UpTitle], [Title], [DownTitle], [Section]) VALUES (2, N'a7622800-06a9-4ea3-8455-07cad4fb42b1-26072021064350-trend.png', N'New season trends!', N'Best Summer Collection', N'Sale Get up to 50% Off', N'Trend')
INSERT [dbo].[Advertisements] ([Id], [Image], [UpTitle], [Title], [DownTitle], [Section]) VALUES (3, N'8aca121d-861f-46e1-94a9-5bb422cbd2c2-24072021104515-supersale.jpg', N'Super Sale', N'New Collection', NULL, N'Seasons')
INSERT [dbo].[Advertisements] ([Id], [Image], [UpTitle], [Title], [DownTitle], [Section]) VALUES (4, N'40d90c0b-9af8-4779-9539-50a444340442-24072021104529-newseason.jpg', N'New Season', N'Sale 40% Off', NULL, N'Seasons')
SET IDENTITY_INSERT [dbo].[Advertisements] OFF
GO
SET IDENTITY_INSERT [dbo].[ChooseUs] ON 

INSERT [dbo].[ChooseUs] ([Id], [Title], [Context], [Icon]) VALUES (1, N'Creative Design', N'<p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form</p>
', N'dc6b78c4-65a7-429a-8ec2-a396b60ec824-26072021072325-pencil-alt.svg')
INSERT [dbo].[ChooseUs] ([Id], [Title], [Context], [Icon]) VALUES (2, N'Flexible Layouts', N'<p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form</p>
', N'5c913f31-6324-4070-9664-dca14d1713c2-26072021072400-layers.svg')
INSERT [dbo].[ChooseUs] ([Id], [Title], [Context], [Icon]) VALUES (3, N'Email Marketing', N'<p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form</p>
', N'3a03cbec-1943-4e96-b626-26b24872e35a-26072021072426-email.svg')
INSERT [dbo].[ChooseUs] ([Id], [Title], [Context], [Icon]) VALUES (4, N'Project Analysis', N'<p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form</p>
', N'0a60b990-d30b-42f8-9cb5-46e414d12ba8-26072021072449-bar-chart.svg')
INSERT [dbo].[ChooseUs] ([Id], [Title], [Context], [Icon]) VALUES (5, N'Secure Service', N'<p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form</p>
', N'e4ac4836-e0fa-4fd5-9455-132bc052358c-26072021072507-lock.svg')
INSERT [dbo].[ChooseUs] ([Id], [Title], [Context], [Icon]) VALUES (6, N'Customer Support', N'<p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form</p>
', N'd4ed47ba-7c28-4e1a-9202-35ae261ba1f4-26072021072524-headphone.svg')
SET IDENTITY_INSERT [dbo].[ChooseUs] OFF
GO
SET IDENTITY_INSERT [dbo].[ContactInfo] ON 

INSERT [dbo].[ContactInfo] ([Id], [Title], [Desc], [Map]) VALUES (1, N'Get In Touch', N'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus blandit massa enim. Nullam id varius nunc id varius nunc.</p>
', N'https://maps.google.com/maps?q=London%20Eye%2C%20London%2C%20United%20Kingdom&amp;t=m&amp;z=13&amp;output=embed&amp;iwloc=near')
SET IDENTITY_INSERT [dbo].[ContactInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[ContactMessages] ON 

INSERT [dbo].[ContactMessages] ([Id], [Name], [Surname], [Email], [Phone], [Message]) VALUES (3, N'Vetendash', N'Vetendashov', N'vetendash@gmail.com', N'(055) 505 55 55', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus blandit massa enim. Nullam id varius nunc id varius nunc.

')
SET IDENTITY_INSERT [dbo].[ContactMessages] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Id], [Address], [Icon], [Type]) VALUES (1, N'123 Street, Old Trafford, New South London , UK', N'fas fa-map-marker-alt', N'Address')
INSERT [dbo].[Contacts] ([Id], [Address], [Icon], [Type]) VALUES (2, N'info@shopwise.com', N'far fa-envelope', N'Email')
INSERT [dbo].[Contacts] ([Id], [Address], [Icon], [Type]) VALUES (3, N'+ 457 789 789 65', N'fas fa-mobile-alt', N'Phone')
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[Faqs] ON 

INSERT [dbo].[Faqs] ([Id], [Question], [Answer], [IsGeneral]) VALUES (2, N'How do I upload files from my phone or tablet?', N'<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using &lsquo;Content here, content here&rsquo;, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for &lsquo;lorem ipsum&rsquo; will uncover many web sites still in their infancy.</p>
', 1)
INSERT [dbo].[Faqs] ([Id], [Question], [Answer], [IsGeneral]) VALUES (3, N'How can I start my design?', N'<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using &lsquo;Content here, content here&rsquo;, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for &lsquo;lorem ipsum&rsquo; will uncover many web sites still in their infancy.</p>
', 1)
INSERT [dbo].[Faqs] ([Id], [Question], [Answer], [IsGeneral]) VALUES (4, N'What are popular free webpage builders?', N'<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using &lsquo;Content here, content here&rsquo;, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for &lsquo;lorem ipsum&rsquo; will uncover many web sites still in their infancy.</p>
', 1)
INSERT [dbo].[Faqs] ([Id], [Question], [Answer], [IsGeneral]) VALUES (5, N'How do you make your own website for free?', N'<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using &lsquo;Content here, content here&rsquo;, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for &lsquo;lorem ipsum&rsquo; will uncover many web sites still in their infancy.</p>
', 1)
INSERT [dbo].[Faqs] ([Id], [Question], [Answer], [IsGeneral]) VALUES (6, N'What is the weirdest website on the internet?', N'<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using &lsquo;Content here, content here&rsquo;, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for &lsquo;lorem ipsum&rsquo; will uncover many web sites still in their infancy.</p>
', 0)
INSERT [dbo].[Faqs] ([Id], [Question], [Answer], [IsGeneral]) VALUES (7, N'Can I add/upgrade my plan at any time?', N'<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using &lsquo;Content here, content here&rsquo;, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for &lsquo;lorem ipsum&rsquo; will uncover many web sites still in their infancy.</p>
', 0)
INSERT [dbo].[Faqs] ([Id], [Question], [Answer], [IsGeneral]) VALUES (8, N'What access comes with my hosting plan?', N'<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using &lsquo;Content here, content here&rsquo;, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for &lsquo;lorem ipsum&rsquo; will uncover many web sites still in their infancy.</p>
', 0)
INSERT [dbo].[Faqs] ([Id], [Question], [Answer], [IsGeneral]) VALUES (9, N'What are some lesser known but useful websites?', N'<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using &lsquo;Content here, content here&rsquo;, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for &lsquo;lorem ipsum&rsquo; will uncover many web sites still in their infancy.</p>
', 0)
INSERT [dbo].[Faqs] ([Id], [Question], [Answer], [IsGeneral]) VALUES (10, N'How do you make your own website for free?', N'<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using &lsquo;Content here, content here&rsquo;, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for &lsquo;lorem ipsum&rsquo; will uncover many web sites still in their infancy.</p>
', 0)
INSERT [dbo].[Faqs] ([Id], [Question], [Answer], [IsGeneral]) VALUES (13, N'Do you have any built-in caching?', N'<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using &lsquo;Content here, content here&rsquo;, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for &lsquo;lorem ipsum&rsquo; will uncover many web sites still in their infancy.</p>
', 1)
SET IDENTITY_INSERT [dbo].[Faqs] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedbacks] ON 

INSERT [dbo].[Feedbacks] ([Id], [Image], [FullName], [Proffession], [Text]) VALUES (1, N'8a029ece-533e-47c1-bd39-f5285d35e843-26072021064609-user2.jpg', N'Alden Smith', N'Designer', N'<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem amet laudantium, quaeillo inventore sed veritatis et quasi architecto beatae vitae dicta sunt explicabo eiusmod tempor incididunt ut labore.</p>
')
INSERT [dbo].[Feedbacks] ([Id], [Image], [FullName], [Proffession], [Text]) VALUES (2, N'fd760e59-a4fd-4fb1-956f-ab5781f392f4-26072021064635-user4.jpg', N'John Becker', N'Designer', N'<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem amet laudantium, quaeillo inventore sed veritatis et quasi architecto beatae vitae dicta sunt explicabo eiusmod tempor incididunt ut labore.</p>
')
INSERT [dbo].[Feedbacks] ([Id], [Image], [FullName], [Proffession], [Text]) VALUES (3, N'b58124c4-26a4-4e45-aa6e-e13b799d0c09-26072021065711-user1.jpg', N'Lissa Castro', N'Designer', N'<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem amet laudantium, quaeillo inventore sed veritatis et quasi architecto beatae vitae dicta sunt explicabo eiusmod tempor incididunt ut labore.</p>
')
INSERT [dbo].[Feedbacks] ([Id], [Image], [FullName], [Proffession], [Text]) VALUES (4, N'7aae0584-a110-477d-89c6-0fdc3c1b3d9e-26072021065723-user3.jpg', N'Daisy Lana', N'Designer', N'<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem amet laudantium, quaeillo inventore sed veritatis et quasi architecto beatae vitae dicta sunt explicabo eiusmod tempor incididunt ut labore.</p>
')
SET IDENTITY_INSERT [dbo].[Feedbacks] OFF
GO
SET IDENTITY_INSERT [dbo].[MissionFeatures] ON 

INSERT [dbo].[MissionFeatures] ([Id], [Title], [Text], [Icon]) VALUES (1, N'Easy To Customize', N'<p>All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary.</p>
', N'40b5ccd8-e96e-46c6-ad33-c4f9556cc192-26072021074738-cog-solid.svg')
INSERT [dbo].[MissionFeatures] ([Id], [Title], [Text], [Icon]) VALUES (2, N'Amazing Features', N'<p>Vestibulum ligula orci, volutpat id aliquet eget, consectetur eget ante. Morbi convallis a eros fermentum rhoncus lorem.</p>
', N'840f4a0c-565d-44fc-99d6-2c347048502d-26072021074913-buffer-brands.svg')
SET IDENTITY_INSERT [dbo].[MissionFeatures] OFF
GO
SET IDENTITY_INSERT [dbo].[MissionFiles] ON 

INSERT [dbo].[MissionFiles] ([Id], [Image], [Link]) VALUES (1, N'a5b5d97d-f387-459c-add4-f1f3ee340d29-26072021074948-mission.jpg', N'https://www.youtube.com/watch?v=ZE2HxTmxfrI')
INSERT [dbo].[MissionFiles] ([Id], [Image], [Link]) VALUES (2, N'7e441f69-bd90-4cd1-a6df-70376632a180-10072021121524-chip.jpg', N'sil')
SET IDENTITY_INSERT [dbo].[MissionFiles] OFF
GO
SET IDENTITY_INSERT [dbo].[Partners] ON 

INSERT [dbo].[Partners] ([Id], [Image], [Link]) VALUES (1, N'754544ae-c99b-47a9-9eb2-8d5aee7f5bcb-26072021070425-partner1.webp', N'https://www.fashiontv.com/')
INSERT [dbo].[Partners] ([Id], [Image], [Link]) VALUES (2, N'4ddd70b5-e8bb-455e-912f-6fa87042dba6-26072021070435-partner2.webp', N'https://handcraftedcph.com/')
INSERT [dbo].[Partners] ([Id], [Image], [Link]) VALUES (3, N'3e2bacf8-ceaa-4184-8fee-bdcae688b677-26072021070446-partner3.webp', N'https://martfury.botble.com/brands/mestonix')
INSERT [dbo].[Partners] ([Id], [Image], [Link]) VALUES (4, N'77533593-a130-415f-8a34-5b5e87e79464-26072021070455-partner4.webp', N'https://hello-sunshine.com/')
INSERT [dbo].[Partners] ([Id], [Image], [Link]) VALUES (5, N'c80183e3-b824-4a1e-85d6-585d2805d8fd-26072021070505-partner5.webp', N'https://pure.app/')
INSERT [dbo].[Partners] ([Id], [Image], [Link]) VALUES (6, N'e1783f84-fdae-4fe2-9102-7deeff9f8112-26072021070516-partner6.webp', N'https://unfold.com/')
INSERT [dbo].[Partners] ([Id], [Image], [Link]) VALUES (7, N'e9ba9edb-cf0b-424a-83f0-4487081c6036-26072021070526-partner7.webp', N'https://www.autonews.com/')
SET IDENTITY_INSERT [dbo].[Partners] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([Id], [Image]) VALUES (1, N'2f184885-5819-4b5e-be7e-2629616177e9-27072021073703-visa-1.webp')
INSERT [dbo].[Payments] ([Id], [Image]) VALUES (2, N'1db8ce3d-09db-4b23-9954-16e7678c1146-27072021073724-discover-1.webp')
INSERT [dbo].[Payments] ([Id], [Image]) VALUES (3, N'87f08062-9300-424e-9d76-43b59ad5a400-27072021073738-master_card-1.webp')
INSERT [dbo].[Payments] ([Id], [Image]) VALUES (4, N'184dd858-afc3-48bb-a2db-2a857d71c8c2-27072021073804-paypal-1.webp')
INSERT [dbo].[Payments] ([Id], [Image]) VALUES (6, N'1cc3d890-f1b8-4575-8997-93984d2a03d6-27072021074225-amarican_express-1.webp')
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([Id], [HeaderLogo], [FooterLogo], [About]) VALUES (3, N'f5794910-d10f-4cd8-ade0-7832869aa386-27072021055315-logo-ShopWise.webp', N'a0775ab7-3dba-475c-b770-6b3c967444e8-27072021064127-footer-logo.webp', N'<p>If you are going to use of Lorem Ipsum need to be sure there isn&#39;t hidden of text</p>
')
SET IDENTITY_INSERT [dbo].[Settings] OFF
GO
SET IDENTITY_INSERT [dbo].[Sliders] ON 

INSERT [dbo].[Sliders] ([Id], [Image], [UpTitle], [Title]) VALUES (1, N'1142a1fe-f4fa-4d95-b23b-eb50641b1024-26072021060915-banner1.jpg', N'Get up to 50% off Today Only!', N'Woman Fashion')
INSERT [dbo].[Sliders] ([Id], [Image], [UpTitle], [Title]) VALUES (2, N'9058e827-ce2e-4f13-a022-383138be5135-26072021060927-banner2.jpg', N'50% off in all products', N'Man Fashion')
INSERT [dbo].[Sliders] ([Id], [Image], [UpTitle], [Title]) VALUES (3, N'2c0b2cf4-b787-40ba-a6a2-7fc0c5e55857-26072021060937-banner3.jpg', N'Taking your Viewing Experience to Next Level', N'Summer Sale')
SET IDENTITY_INSERT [dbo].[Sliders] OFF
GO
SET IDENTITY_INSERT [dbo].[Socials] ON 

INSERT [dbo].[Socials] ([Id], [Icon], [Link]) VALUES (1, N'fab fa-facebook-f', N'https://www.facebook.com/groups/551183302246187')
INSERT [dbo].[Socials] ([Id], [Icon], [Link]) VALUES (2, N'fab fa-twitter', N'https://twitter.com/?lang=en')
INSERT [dbo].[Socials] ([Id], [Icon], [Link]) VALUES (3, N'fab fa-google-plus-g', N'https://myaccount.google.com/profile')
INSERT [dbo].[Socials] ([Id], [Icon], [Link]) VALUES (4, N'fab fa-youtube', N'https://www.youtube.com/')
INSERT [dbo].[Socials] ([Id], [Icon], [Link]) VALUES (5, N'fab fa-instagram', N'https://www.instagram.com/')
SET IDENTITY_INSERT [dbo].[Socials] OFF
GO
SET IDENTITY_INSERT [dbo].[Subscribes] ON 

INSERT [dbo].[Subscribes] ([Id], [Email], [AddedDate]) VALUES (1, N'agilab@code.edu.az', CAST(N'2021-07-23T07:09:10.7966109' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Subscribes] OFF
GO
SET IDENTITY_INSERT [dbo].[Tax] ON 

INSERT [dbo].[Tax] ([Id], [PriceLimit], [Percent]) VALUES (2, CAST(100.00 AS Decimal(18, 2)), CAST(18.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Tax] OFF
GO
SET IDENTITY_INSERT [dbo].[Testimonial] ON 

INSERT [dbo].[Testimonial] ([Id], [UpTitle], [Title], [Info]) VALUES (1, N'Testimonial', N'Our Client Say!', N'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore.</p>
')
SET IDENTITY_INSERT [dbo].[Testimonial] OFF
GO
SET IDENTITY_INSERT [dbo].[Universal] ON 

INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (1, N'Exclusive Products', NULL, N'Exclusive')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (2, N'Featured Products', NULL, N'Featured')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (3, N'Subscribe Our Newsletter', NULL, N'Subscribe')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (4, N'Useful Links', NULL, N'Links')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (5, N'Category', NULL, N'Category')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (6, N'My Account', NULL, N'MyAccount')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (7, N'Contact Info', NULL, N'ContactInfo')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (9, N'Our Mission & Vision', N'<p>If you are going to use a passage of Ipsum, you need to be sure there isn&#39;t anything embarrassing hidden in middle of text.</p>
', N'Mission')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (10, N'Filter By Price', NULL, N'Price')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (11, N'Filter By Gender
', NULL, N'Gender')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (12, N'Filter By Color', NULL, N'Color')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (13, N'Filter By Size', NULL, N'Size')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (14, N'Product Categories', NULL, N'Categories')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (15, N'Product Status', NULL, N'Status')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (16, N'General Questions', NULL, N'General')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (17, N'Other Questions', NULL, N'Other')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (19, N'Why Choose Us?', N'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore.</p>
', N'ChooseUs')
INSERT [dbo].[Universal] ([Id], [Title], [Desc], [Section]) VALUES (21, N'Related Products', NULL, N'Related')
SET IDENTITY_INSERT [dbo].[Universal] OFF
GO
