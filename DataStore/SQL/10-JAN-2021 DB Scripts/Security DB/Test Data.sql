USE [OMS_Security_v0.2]
GO
SET IDENTITY_INSERT [dbo].[ROLES] ON 
GO
--INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (1, CAST(N'2017-04-02T13:11:32.653' AS DateTime), 0, N'Allows system administration of Users/Roles/Permissions', N'Anonymous')
--GO
--INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (2, CAST(N'2017-04-02T12:56:12.517' AS DateTime), 0, N'Default role with limited permissions', N'Buyer')
--GO
--INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (3, CAST(N'2017-04-03T23:57:14.237' AS DateTime), 0, N'Catalogue Management', N'Shop')
--GO
--INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (5, CAST(N'2017-04-04T10:00:00.000' AS DateTime), 1, N'Cart Management', N'Admin')
--GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (6, CAST(N'2017-04-04T10:00:00.000' AS DateTime), 0, N'Security Administrator', N'Security Administrator')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (7, CAST(N'2017-04-04T10:00:00.000' AS DateTime), 0, N'Site Configurator', N'Site Configurator')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (8, CAST(N'2017-04-04T10:00:00.000' AS DateTime), 0, N'Admin Dashboard', N'Admin Dashboard')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (9, CAST(N'2017-04-04T10:00:00.000' AS DateTime), 0, N'Order Management', N'Order Management')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (11, CAST(N'2017-04-04T10:00:00.000' AS DateTime), 0, N'Shipment & Delivery Management', N'Shipment Management')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (12, CAST(N'2017-04-04T10:00:00.000' AS DateTime), 0, N'Payment Management', N'Payment Management')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (13, CAST(N'2017-04-04T10:00:00.000' AS DateTime), 0, N'User Cart', N'User Cart')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (16, CAST(N'2020-12-12T17:12:20.117' AS DateTime), 0, N'User Order', N'User Order')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (17, CAST(N'2017-04-04T10:00:00.000' AS DateTime), 0, N'User Payment', N'User Payment')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (18, CAST(N'2017-04-04T10:00:00.000' AS DateTime), 0, N'Catalogue Browser', N'Catalogue Browser')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (19, CAST(N'2017-04-10T22:14:13.310' AS DateTime), 0, N'User Self Manage', N'UserSelfManage')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (20, CAST(N'2017-04-10T23:54:01.610' AS DateTime), 0, N'AdminUserSelfManage', N'AdminUserSelfManage')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (21, CAST(N'2017-04-10T23:54:20.250' AS DateTime), 0, N'SecurityUserSelfManage', N'SecurityUserSelfManage')
GO
SET IDENTITY_INSERT [dbo].[ROLES] OFF
GO
SET IDENTITY_INSERT [dbo].[USERS] ON 
GO
--INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (1, CAST(N'2017-04-02T12:56:11.890' AS DateTime), 0, N'System', N'Administrator', N'sherjilahmed0@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'b51bc57c-5e57-40e9-8a15-e260fe97563b', NULL, 1, 0, NULL, 0, 0, N'Admin')
--GO
--INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (2, CAST(N'2017-04-22T17:33:55.160' AS DateTime), 0, N'Default', N'User', N'sherjilahmed1@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'c059b250-370f-466b-b561-420323290eec', NULL, 1, 0, NULL, 0, 0, N'DefaultUser')
--GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (3, CAST(N'2017-04-02T12:56:12.237' AS DateTime), 0, N'Guest', N'User', N'sherjilahmed2@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'c059b250-370f-466b-b561-420323290eec', NULL, 1, 0, NULL, 0, 0, N'Guest')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (4, CAST(N'2017-04-04T00:16:28.753' AS DateTime), 0, N'Catalogue ', N'Manager', N'sherjilahmed3@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'c059b250-370f-466b-b561-420323290eec', NULL, 1, 0, NULL, 0, 0, N'CatMgr')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (5, CAST(N'2017-04-04T10:11:26.063' AS DateTime), 0, N'CartOrder', N'Manager', N'sherjilahmed4@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'c059b250-370f-466b-b561-420323290eec', NULL, 1, 0, NULL, 0, 0, N'CartMgr')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (6, CAST(N'2017-04-04T00:16:28.753' AS DateTime), 0, N'Security', N'Admin', N'sherjilahmed5@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'c059b250-370f-466b-b561-420323290eec', NULL, 1, 0, NULL, 0, 0, N'SecurityAdmin')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (7, CAST(N'2017-04-04T00:16:28.753' AS DateTime), 0, N'Configration', N'Admin', N'sherjilahmed6@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'c059b250-370f-466b-b561-420323290eec', NULL, 1, 0, NULL, 0, 0, N'ConfigAdmin')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (8, CAST(N'2017-04-04T00:16:28.753' AS DateTime), 0, N'Supper', N'Admin', N'sherjilahmed@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'b13a522d-dae8-4341-b2de-dcfbed3429b5', N'+923333076655', 1, 0, NULL, 0, 0, N'SupperAdmin')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (9, CAST(N'2017-04-10T22:14:26.893' AS DateTime), 0, N'User 1', N'last name', N'sherjilahmed8@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'c059b250-370f-466b-b561-420323290eec', NULL, 1, 0, NULL, 0, 0, N'TestUser 1')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (10, CAST(N'2017-04-11T10:10:02.697' AS DateTime), 0, N'user', N'ddsfdsf', N'sherjilahmed9@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'c059b250-370f-466b-b561-420323290eec', NULL, 1, 0, NULL, 0, 0, N'testuser2')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (11, CAST(N'2017-04-11T00:28:22.790' AS DateTime), 0, N'skdfdskfh', N'dfkghdfkhg', N'sherjilahmed0@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'c059b250-370f-466b-b561-420323290eec', NULL, 1, 0, NULL, 0, 0, N'testuser3')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (12, CAST(N'2017-04-11T11:37:25.350' AS DateTime), 0, N'test', N'user-4', N'sherjilahmed11@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'c059b250-370f-466b-b561-420323290eec', NULL, 1, 0, NULL, 0, 0, N'testuser4')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (13, CAST(N'2017-04-11T13:23:11.347' AS DateTime), 0, N'jamil', N'ahmed', N'sherjilahmed12@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'fcf37f99-23d7-45d4-ad30-4f70d17fe45a', NULL, 1, 0, NULL, 0, 0, N'testuser5')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (14, CAST(N'2017-04-13T01:19:29.917' AS DateTime), 0, N'sherjil', N'ahmed', N'sherjilahmed13@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'c059b250-370f-466b-b561-420323290eec', NULL, 1, 0, NULL, 0, 0, N'sherjil123')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (15, CAST(N'2017-04-23T08:53:09.430' AS DateTime), 0, N'sfsfdsfsdf', N'dsfsdfsdf', N'sherjilahmed7@msn.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'33154101-54e3-4b4a-9448-039ff2c92e7d', NULL, 1, 0, NULL, 0, 0, N'userx1')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (16, CAST(N'2017-04-23T17:52:27.793' AS DateTime), 0, N'dsjdslfsf', N'j;ljgdjgd;ljgs;lgj', N'sherjil@live.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'4e9d8151-a893-4831-88d4-1f2f59072f4f', NULL, 1, 0, NULL, 0, 0, N'userx2')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (17, CAST(N'2017-04-23T18:18:23.737' AS DateTime), 0, N'fdskflsdfjdslfj', N'dskfjlsfjdsfdsj', N'khan@live.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'5b3faeab-16c2-4f4c-98da-d4e6e9daf10b', NULL, 1, 0, NULL, 0, 0, N'userx3')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (18, CAST(N'2020-12-19T01:27:23.477' AS DateTime), 0, N'Test', N'Test', N'test2@test.test', 0, N'ACPCa3yigFIwLaCv8KsUUtHbITgX+WXt/sqZsVOJzpLkgwZ8+bboHSlC/OrmDsb3kg==', N'3d240faf-7a6c-4f39-a3e3-f292d23e5761', N'12345', 0, 0, NULL, 1, 0, N'test2')
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (19, CAST(N'2020-12-19T01:31:11.137' AS DateTime), 0, N'Test', N'Test', N'test123@test.test', 0, N'AEgljy44Yh7eQLYMRTKZdVltvY2HOiNDPndXeO99+rr+jsfqKTko5R2U+ZVXQwqUsg==', N'261549d9-fb41-4898-ba9f-aa0aaab1db6f', N'12345', 0, 0, NULL, 1, 0, N'test123')
GO
SET IDENTITY_INSERT [dbo].[USERS] OFF
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (1, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (1, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (2, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (2, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (3, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (3, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (4, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (4, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (5, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (5, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (6, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (6, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (7, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (7, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (8, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (8, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (9, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (9, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (10, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (10, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (11, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (11, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (12, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (12, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (13, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (13, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (14, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (14, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (15, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (15, 5)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (16, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (16, 5)
GO
