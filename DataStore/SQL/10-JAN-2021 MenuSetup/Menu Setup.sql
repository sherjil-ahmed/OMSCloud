update [OMS_Security_v0.2].[dbo].[ROLES] set Name='Anonymous',RoleDescription='Allow Anonymous' where RoleId=1
update [OMS_Security_v0.2].[dbo].[ROLES] set Name='Buyer',RoleDescription='Buyer' where RoleId=2
update [OMS_Security_v0.2].[dbo].[ROLES] set Name='Shop',RoleDescription='Shop' where RoleId=3
update [OMS_Security_v0.2].[dbo].[ROLES] set Name='Admin',RoleDescription='Admin' where RoleId=5

Update [OMS_Security_v0.2].[dbo].[ROLES] set IsSysAdmin=1 where RoleId=5
UPDATE [OMS_Security_v0.2].[dbo].[LNK_USER_ROLE] SET RoleId= 5 WHERE UserId = 1
Select * from [CategoryAttributePair]
-- Type
SET IDENTITY_INSERT [dbo].[OptionType] ON 
GO
INSERT INTO [dbo].[OptionType] ([OptionTypeID], [OptionTypeTitle],[Description],[OptionLevel]) VALUES(1,'Menu','Admin Menu Only',1)
SET IDENTITY_INSERT [dbo].[OptionType] OFF 
GO

SET IDENTITY_INSERT [dbo].[Option] ON 
GO
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (0,'Root','Root','','','',1,1,0,1,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (1,'Dashboard','Dashboard','fa fa-home','/Admin/Index','',1,1,0,1,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (2,'Report','Report','','/Admin/Report','',1,1,1,1,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (3,'Chart','Chart','','/Admin/Chart','',1,1,1,2,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (4,'Stats','Stats','','/Admin/Stats','',1,1,1,3,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (5,'Catalogue Management','Catalogue Management','fa fa-columns','','',1,1,0,2,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (6,'Product','Product','','/Admin/Product','',1,1,5,1,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (7,'Category','Category','','/Admin/Category','',1,1,5,2,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (8,'Attribute','Attribute','','/Admin/Attribute','',1,1,5,3,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (9,'Shop Management','Shop Management','fa fa-columns','','',1,1,0,2,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (10,'Shop','Shop','','/Admin/Supplier','',1,1,9,1,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (11,'Shop Delivery Setup','Shop Delivery Setup','','/Admin/SupplierDeliveryOptionPair','',1,1,9,2,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (12,'Shop Delivery Schedule','Shop Delivery Schedule','','/Admin/ShopDeliverySchedule','',1,1,9,3,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (13,'Order Management','Order Management','fa fa-list-alt','','',1,1,0,3,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (14,'Order By Status','Order By Status','','','',1,1,13,1,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (15,'All Orders','All Orders','','/Admin/Order','',1,1,14,1,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (16,'Unpaid Orders','Unpaid Orders','','/Admin/Order?orderStatusID=3','',1,1,14,2,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (17,'New Orders','New Orders','','/Admin/Order?orderStatusID=4','',1,1,14,3,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (18,'Inprocess Orders ','Inprocess Orders ','','/Admin/Order?orderStatusID=5','',1,1,14,4,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (19,'Ready to Ship Orders','Ready to Ship Orders','','/Admin/Order?orderStatusID=6','',1,1,14,5,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (20,'Delivered Orders','Delivered Orders','','/Admin/Order?orderStatusID=8','',1,1,14,6,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (21,'Completed Orders','Completed Orders','','/Admin/Order?orderStatusID=10','',1,1,14,7,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (22,'Disputed Orders','Disputed Orders','','','',1,1,13,2,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (23,'Order Delivery Failed ','Order Delivery Failed ','','/Admin/Order?orderStatusID=11','',1,1,22,1,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (24,'Order Delivered with Issues','Order Delivered with Issues','','/Admin/Order?orderStatusID=12','',1,1,22,2,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (25,'Failed Orders','Failed Orders','','/Admin/Order?orderStatusID=13','',1,1,22,3,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (26,'User Management','User Management','fa fa-copy','','',1,1,0,4,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (27,'User Profile','User Profile','','/Admin/Profile','',1,1,26,1,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (28,'Profile Verification','Profile Verification','','/IndexAdmin/ProfileVerification','',1,1,26,2,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (29,'Address','Address','','/Admin/Address','',1,1,26,3,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (30,'Setup','Setup','','','',1,1,0,5,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (31,'Global Configuration','Global Configuration','','/Admin/AppConfig','',1,1,30,1,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (32,'General Status','General Status','','/Admin/Status','',1,1,30,2,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (33,'Product Type','Product Type','','/Admin/ProductType','',1,1,30,3,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (34,'Category Type','Category Type','','/Admin/CategoryType','',1,1,30,4,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (35,'Attribute Type','Attribute Type','','/Admin/AttributeType','',1,1,30,5,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (36,'Delivery Option','Delivery Option','','/Admin/DeliveryOption','',1,1,30,6,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (37,'Tax Type','Tax Type','','/Admin/TaxType','',1,1,30,7,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (38,'Tax','Tax','','/Admin/Tax','',1,1,30,8,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (39,'Brand','Brand','','/Admin/Brand','',1,1,30,9,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (40,'Data Type','Data Type','','/Admin/DataType','',1,1,30,10,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (41,'Document Type','Document Type','','/Admin/DocumentType','',1,1,30,11,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (42,'Order Status','Order Status','','/Admin/OrderStatus','',1,1,30,12,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (43,'Order Status Map','Order Status Map','','/Admin/OrderStatusMap','',1,1,30,13,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (44,'Security Management','Security Management','fa fa-key','','',1,1,0,6,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (45,'User','User','','/Security/User','',1,1,44,1,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (46,'Role','Role','','/Security/Role','',1,1,44,2,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (47,'Permission','Permission','','/Security/Permission','',1,1,44,3,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (48,'Customer Review & Feedback','Customer Review & Feedback','','/Admin/Feedback','',1,1,26,4,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (49,'Chat','Chat','','/Admin/Chat','',1,1,26,5,2,2,0,0,GETDATE(),GETDATE());
INSERT INTO [dbo].[Option] ([OptionID],[OptionTitle],[MenuTitle],[ItemTitle],[PageURL],[NextPageURL],[ModuleID],[OptionTypeID],[ParentOptionID],[DisplayOrder],[ExecActionID],[StatusID],[CreatedByUserID],[LastModifiedByUserID],[CreatedDateTime],[LastModifiedDateTime]) VALUES (50,'Cart Management','Cart Management','','/Admin/Cart','',1,1,13,3,2,2,0,0,GETDATE(),GETDATE());
SET IDENTITY_INSERT [dbo].[Option] OFF
GO



insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(1,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(2,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(3,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(4,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(5,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(6,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(7,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(8,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(9,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(10,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(11,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(12,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(13,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(14,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(15,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(16,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(17,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(18,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(19,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(20,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(21,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(22,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(23,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(24,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(25,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(26,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(27,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(28,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(29,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(30,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(31,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(32,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(33,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(34,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(35,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(36,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(37,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(38,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(39,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(40,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(41,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(42,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(43,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(44,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(45,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(46,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(47,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(48,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(49,5,2);
insert into roleoptionpair (OPTIONID,ROLEID,STATUSID) Values(50,5,2);
