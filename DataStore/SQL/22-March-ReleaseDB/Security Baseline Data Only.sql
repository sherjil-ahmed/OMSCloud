--USE [OMS_Security_v0.4]
--GO
SET IDENTITY_INSERT [dbo].[PERMISSIONS] ON 
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (484, N'Security-Account-Login')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (485, N'Security-Account-OTP4PhoneVerification')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (486, N'Security-Account-OTP4EmailVerification')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (487, N'Security-Account-RequestEmailVerification')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (488, N'Security-Account-Register')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (489, N'Security-Account-ForgotPassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (490, N'Security-Account-ForgotPasswordConfirmation')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (491, N'Security-Account-ResetPassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (492, N'Security-Account-ResetPasswordConfirmation')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (493, N'Security-Account-ExternalLogin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (494, N'Security-Account-LogOff')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (495, N'Security-Account-ExternalLoginFailure')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (496, N'Security-Admin-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (497, N'Security-Admin-UserDetails')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (498, N'Security-Admin-UserEdit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (499, N'Security-Admin-DeleteUserRole')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (500, N'Security-Admin-filter4Users')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (501, N'Security-Admin-filterReset')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (502, N'Security-Admin-DeleteUserReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (503, N'Security-Admin-DeleteUserRoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (504, N'Security-Admin-AddUserRoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (505, N'Security-Admin-RoleIndex')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (506, N'Security-Admin-RoleDetails')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (507, N'Security-Admin-RoleCreate')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (508, N'Security-Admin-RoleEdit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (509, N'Security-Admin-DeleteUserFromRoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (510, N'Security-Admin-AddUser2RoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (511, N'Security-Admin-RoleDelete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (512, N'Security-Admin-PermissionIndex')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (513, N'Security-Admin-PermissionDetails')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (514, N'Security-Admin-PermissionCreate')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (515, N'Security-Admin-PermissionEdit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (516, N'Security-Admin-DeletePermissionReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (517, N'Security-Admin-AddPermission2RoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (518, N'Security-Admin-AddAllPermissions2RoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (519, N'Security-Admin-DeletePermissionFromRoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (520, N'Security-Admin-DeleteRoleFromPermissionReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (521, N'Security-Admin-AddRole2PermissionReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (522, N'Security-Admin-PermissionsImport')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (523, N'Security-Home-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (524, N'Security-Home-About')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (525, N'Security-Home-Reports')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (526, N'Security-Manage-AddPhoneNumber')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (527, N'Security-Manage-ChangePassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (528, N'Security-Manage-SetPassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (529, N'Security-Manage-LinkLogin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (530, N'Security-Unauthorised-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (531, N'Security-Unauthorised-Error')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (534, N'Admin-AddressType-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (535, N'Admin-AddressType-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (536, N'Admin-AddressType-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (537, N'Admin-AddressType-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (538, N'Admin-AddressType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (539, N'Admin-AppConfig-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (540, N'Admin-AppConfig-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (541, N'Admin-AppConfig-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (542, N'Admin-AppConfig-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (543, N'Admin-AppConfig-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (544, N'Admin-Attribute-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (545, N'Admin-Attribute-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (546, N'Admin-Attribute-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (547, N'Admin-Attribute-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (548, N'Admin-Attribute-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (549, N'Admin-Attribute-CreateAttribute')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (550, N'Admin-BookingOption-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (551, N'Admin-BookingOption-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (552, N'Admin-BookingOption-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (553, N'Admin-BookingOption-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (554, N'Admin-BookingOption-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (555, N'Admin-Brand-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (556, N'Admin-Brand-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (557, N'Admin-Brand-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (558, N'Admin-Brand-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (559, N'Admin-Brand-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (560, N'Admin-CategoryAttributePair-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (561, N'Admin-CategoryAttributePair-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (562, N'Admin-CategoryAttributePair-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (563, N'Admin-CategoryAttributePair-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (564, N'Admin-CategoryAttributePair-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (565, N'Admin-CategoryAttributePair-CategoryAttributeListByCategoryId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (566, N'Admin-CategoryAttributePair-AssociateAttributeWithCategory')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (567, N'Admin-CategoryAttributePair-CreateCategoryAttributePair')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (568, N'Admin-CategoryType-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (569, N'Admin-CategoryType-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (570, N'Admin-CategoryType-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (571, N'Admin-CategoryType-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (572, N'Admin-CategoryType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (573, N'Admin-DataType-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (574, N'Admin-DataType-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (575, N'Admin-DataType-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (576, N'Admin-DataType-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (577, N'Admin-DataType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (578, N'Admin-DeliveryOption-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (579, N'Admin-DeliveryOption-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (580, N'Admin-DeliveryOption-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (581, N'Admin-DeliveryOption-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (582, N'Admin-DeliveryOption-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (583, N'Admin-Group-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (584, N'Admin-Group-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (585, N'Admin-Group-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (586, N'Admin-Group-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (587, N'Admin-Group-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (588, N'Admin-Home-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (589, N'Admin-MediaContentType-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (590, N'Admin-MediaContentType-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (591, N'Admin-MediaContentType-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (592, N'Admin-MediaContentType-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (593, N'Admin-MediaContentType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (594, N'Admin-OptionType-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (595, N'Admin-OptionType-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (596, N'Admin-OptionType-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (597, N'Admin-OptionType-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (598, N'Admin-OptionType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (599, N'Admin-OrderStatus-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (600, N'Admin-OrderStatus-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (601, N'Admin-OrderStatus-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (602, N'Admin-OrderStatus-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (603, N'Admin-OrderStatus-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (604, N'Admin-PackagedProduct-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (605, N'Admin-PackagedProduct-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (606, N'Admin-PackagedProduct-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (607, N'Admin-PackagedProduct-CreatePackagedProduct')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (608, N'Admin-PackagedProduct-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (609, N'Admin-PackagedProduct-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (610, N'Admin-PackagedProduct-ShowPackagedProductAddEdit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (611, N'Admin-PackagedProduct-ShowPackagedProductList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (612, N'Admin-PayMode-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (613, N'Admin-PayMode-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (614, N'Admin-PayMode-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (615, N'Admin-PayMode-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (616, N'Admin-PayMode-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (617, N'Admin-PayType-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (618, N'Admin-PayType-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (619, N'Admin-PayType-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (620, N'Admin-PayType-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (621, N'Admin-PayType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (622, N'Admin-ProductAttributePair-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (623, N'Admin-ProductAttributePair-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (624, N'Admin-ProductAttributePair-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (625, N'Admin-ProductAttributePair-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (626, N'Admin-ProductAttributePair-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (627, N'Admin-ProductAttributePair-ProductAttributeListByProductId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (628, N'Admin-ProductAttributePair-AssociateAttributeWithProduct')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (629, N'Admin-ProductCategoryPair-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (630, N'Admin-ProductCategoryPair-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (631, N'Admin-ProductCategoryPair-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (632, N'Admin-ProductCategoryPair-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (633, N'Admin-ProductCategoryPair-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (634, N'Admin-ProductCategoryPair-AssociateCategoryWithProduct')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (635, N'Admin-ProductMediaDetail-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (636, N'Admin-ProductMediaDetail-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (637, N'Admin-ProductMediaDetail-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (638, N'Admin-ProductMediaDetail-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (639, N'Admin-ProductMediaDetail-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (640, N'Admin-ProductType-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (641, N'Admin-ProductType-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (642, N'Admin-ProductType-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (643, N'Admin-ProductType-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (644, N'Admin-ProductType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (645, N'Admin-ProductView-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (646, N'Admin-ProductView-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (647, N'Admin-ProductView-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (648, N'Admin-ProductView-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (649, N'Admin-ProductView-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (650, N'Admin-Profile-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (651, N'Admin-Profile-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (652, N'Admin-Profile-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (653, N'Admin-Profile-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (654, N'Admin-Profile-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (655, N'Admin-ProfileVerification-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (656, N'Admin-ProfileVerification-IndexAdmin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (657, N'Admin-ProfileVerification-DetailsAdmin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (658, N'Admin-ProfileVerification-CreateAdmin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (659, N'Admin-ProfileVerification-EditAdmin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (660, N'Admin-ProfileVerification-DeleteAdmin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (661, N'Admin-ProfileVerification-IndexPublic')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (662, N'Admin-ProfileVerification-DetailsPublic')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (663, N'Admin-ProfileVerification-CreatePublic')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (664, N'Admin-ProfileVerification-EditPublic')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (665, N'Admin-ProfileVerification-DeletePublic')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (666, N'Admin-Role-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (667, N'Admin-Role-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (668, N'Admin-Role-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (669, N'Admin-Role-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (670, N'Admin-Role-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (671, N'Admin-Status-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (672, N'Admin-Status-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (673, N'Admin-Status-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (674, N'Admin-Status-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (675, N'Admin-Status-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (676, N'Admin-Supplier-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (677, N'Admin-Supplier-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (678, N'Admin-Supplier-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (679, N'Admin-Supplier-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (680, N'Admin-Supplier-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (681, N'Admin-Tax-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (682, N'Admin-Tax-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (683, N'Admin-Tax-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (684, N'Admin-Tax-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (685, N'Admin-Tax-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (686, N'Admin-TaxType-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (687, N'Admin-TaxType-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (688, N'Admin-TaxType-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (689, N'Admin-TaxType-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (690, N'Admin-TaxType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (691, N'Admin-User-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (692, N'Admin-User-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (693, N'Admin-User-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (694, N'Admin-User-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (695, N'Admin-User-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (696, N'Admin-User-LoginUser')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (697, N'Admin-User-LogOff')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (698, N'Admin-User-RegisterNewUser')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (699, N'Admin-User-ChangePassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (700, N'Admin-User-RequestResetPassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (701, N'Admin-User-ResetPassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (702, N'Admin-UserType-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (703, N'Admin-UserType-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (704, N'Admin-UserType-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (705, N'Admin-UserType-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (706, N'Admin-UserType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (707, N'Admin-Category-AssociateCategoryWithAttribute')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (708, N'Admin-Category-CreateAttribute')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (709, N'Admin-Category-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (710, N'Admin-Category-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (711, N'Admin-Category-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (712, N'Admin-Category-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (713, N'Admin-Category-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (714, N'Admin-Product-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (715, N'Admin-Product-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (716, N'Admin-Product-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (717, N'Admin-Product-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (718, N'Admin-Product-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (719, N'Admin-Product-ShowProductAttributeTabJson')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (720, N'Admin-Product-ShowProductAttributeTab')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (721, N'Admin-Product-ShowCategoryListByProductId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (722, N'Admin-Product-ShowProductCategory')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (723, N'Admin-Product-ShowPackagedProduct')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (724, N'Admin-GroupRole-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (725, N'Admin-RoleOptionPair-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (726, N'Admin-RoleOptionPair-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (727, N'Security-Admin-UserCreate')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (728, N'Admin-Profile-EditProfileByUserId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (729, N'Admin-Account-Login')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (730, N'Admin-Account-OTP4PhoneVerification')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (731, N'Admin-Account-OTP4EmailVerification')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (732, N'Admin-Account-RequestEmailVerification')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (733, N'Admin-Account-Register')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (734, N'Admin-Account-ForgotPassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (735, N'Admin-Account-ForgotPasswordConfirmation')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (736, N'Admin-Account-ResetPassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (737, N'Admin-Account-ResetPasswordConfirmation')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (738, N'Admin-Account-ExternalLogin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (739, N'Admin-Account-LogOff')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (740, N'Admin-Account-ExternalLoginFailure')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (741, N'Admin-Admin-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (742, N'Admin-Admin-UserDetails')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (743, N'Admin-Admin-UserCreate')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (744, N'Admin-Admin-UserEdit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (745, N'Admin-Admin-DeleteUserRole')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (746, N'Admin-Admin-filter4Users')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (747, N'Admin-Admin-filterReset')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (748, N'Admin-Admin-DeleteUserReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (749, N'Admin-Admin-DeleteUserRoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (750, N'Admin-Admin-AddUserRoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (751, N'Admin-Admin-RoleIndex')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (752, N'Admin-Admin-RoleDetails')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (753, N'Admin-Admin-RoleCreate')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (754, N'Admin-Admin-RoleEdit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (755, N'Admin-Admin-DeleteUserFromRoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (756, N'Admin-Admin-AddUser2RoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (757, N'Admin-Admin-RoleDelete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (758, N'Admin-Admin-PermissionIndex')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (759, N'Admin-Admin-PermissionDetails')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (760, N'Admin-Admin-PermissionCreate')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (761, N'Admin-Admin-PermissionEdit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (762, N'Admin-Admin-DeletePermissionReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (763, N'Admin-Admin-AddPermission2RoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (764, N'Admin-Admin-AddAllPermissions2RoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (765, N'Admin-Admin-DeletePermissionFromRoleReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (766, N'Admin-Admin-DeleteRoleFromPermissionReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (767, N'Admin-Admin-AddRole2PermissionReturnPartialView')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (768, N'Admin-Admin-PermissionsImport')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (769, N'Admin-AdminHome-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (770, N'Admin-AdminHome-About')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (771, N'Admin-AdminHome-Reports')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (772, N'Admin-Manage-AddPhoneNumber')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (773, N'Admin-Manage-ChangePassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (774, N'Admin-Manage-SetPassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (775, N'Admin-Manage-LinkLogin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (776, N'Admin-Unauthorised-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (777, N'Admin-Unauthorised-Error')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (801, N'Admin-Profile-CreateProfileByUserId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (804, N'Security-Account-SendSecurityCode')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (805, N'Security-Account-VerifySecurityCode')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (806, N'Security-Account-ConfirmEmail')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (807, N'Security-Account-ExternalLoginCallback')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (808, N'Security-Account-ExternalLoginConfirmation')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (845, N'Security-Admin-List_boolNullYesNo')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (918, N'Security-Manage-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (919, N'Security-Manage-RemoveLogin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (920, N'Security-Manage-EnableTwoFactorAuthentication')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (921, N'Security-Manage-DisableTwoFactorAuthentication')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (922, N'Security-Manage-VerifyPhoneNumber')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (923, N'Security-Manage-RemovePhoneNumber')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (924, N'Security-Manage-ManageLogins')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (925, N'Security-Manage-LinkLoginCallback')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1089, N'Admin-Account-SendSecurityCode')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1090, N'Admin-Account-VerifySecurityCode')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1091, N'Admin-Account-ConfirmEmail')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1092, N'Admin-Account-ExternalLoginCallback')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1093, N'Admin-Account-ExternalLoginConfirmation')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1094, N'Admin-Admin-List_boolNullYesNo')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1097, N'Admin-Manage-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1098, N'Admin-Manage-RemoveLogin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1099, N'Admin-Manage-EnableTwoFactorAuthentication')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1100, N'Admin-Manage-DisableTwoFactorAuthentication')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1101, N'Admin-Manage-VerifyPhoneNumber')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1102, N'Admin-Manage-RemovePhoneNumber')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1103, N'Admin-Manage-ManageLogins')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1104, N'Admin-Manage-LinkLoginCallback')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1105, N'Global-Error-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1106, N'Global-Error-Unauthorised')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1107, N'Global-Error-NotFound')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1108, N'Global-Error-Conflict')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1109, N'Global-Error-InternalServerError')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1110, N'Global-Home-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1111, N'Admin-Location-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1112, N'Admin-Location-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1113, N'Admin-Location-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1114, N'Admin-Location-ProvinceList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1115, N'Admin-Location-CityList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1116, N'Admin-Location-AreaList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1117, N'Admin-Cart-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1118, N'Admin-Cart-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1119, N'Admin-Cart-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1120, N'Admin-CartItem-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1121, N'Admin-CartItem-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1122, N'Admin-CartItem-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1123, N'Admin-CartItem-GetCartItemProduct')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1124, N'Admin-CartItem-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1125, N'Admin-CartItem-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1126, N'Admin-CartItem-CreateX')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1127, N'Admin-Order-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1128, N'Admin-Order-GetOrderListByOrderStatus')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1129, N'Admin-Order-GetOrderListByCartId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1130, N'Admin-Order-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1131, N'Admin-Order-ConvertCartToOrder')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1132, N'Admin-Order-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1133, N'Admin-Order-FillPayMode')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1134, N'Admin-Order-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1135, N'Admin-Order-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1136, N'Admin-ContactInfo-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1137, N'Admin-ContactInfo-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1138, N'Admin-ContactInfo-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1139, N'Admin-ContactInfo-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1140, N'Admin-ContactInfo-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1141, N'Admin-Invoice-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1142, N'Admin-OrderDeliveryDetail-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1143, N'Admin-OrderDeliveryDetail-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1144, N'Admin-OrderDeliveryDetail-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1145, N'Admin-OrderDeliveryDetail-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1146, N'Admin-OrderDeliveryDetail-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1147, N'Admin-OrderPayment-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1148, N'Admin-OrderPayment-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1149, N'Admin-OrderPayment-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1150, N'Admin-OrderPayment-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1151, N'Admin-OrderPayment-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1152, N'Admin-OrderStatusMap-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1153, N'Admin-OrderStatusMap-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1154, N'Admin-OrderStatusMap-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1155, N'Admin-OrderStatusMap-PrepareViewBag')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1156, N'Admin-OrderStatusMap-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1157, N'Admin-OrderStatusMap-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1158, N'Admin-Payment-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1159, N'Admin-Payment-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1160, N'Admin-Payment-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1161, N'Admin-Payment-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1162, N'Admin-Payment-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1163, N'Admin-PayOptionMatrix-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1164, N'Admin-PayOptionMatrix-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1165, N'Admin-PayOptionMatrix-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1166, N'Admin-PayOptionMatrix-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1167, N'Admin-PayOptionMatrix-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1168, N'Admin-AttributeType-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1169, N'Admin-AttributeType-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1170, N'Admin-AttributeType-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1171, N'Admin-AttributeType-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1172, N'Admin-AttributeType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1173, N'Admin-ProductViewItem-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1174, N'Admin-ProductViewItem-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1175, N'Admin-ProductViewItem-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1176, N'Admin-ProductViewItem-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1177, N'Admin-ProductViewItem-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1178, N'Admin-AddressContactInfoPair-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1179, N'Admin-AddressContactInfoPair-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1180, N'Admin-AddressContactInfoPair-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1181, N'Admin-AddressContactInfoPair-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1182, N'Admin-AddressContactInfoPair-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1183, N'Admin-Address-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1184, N'Admin-Address-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1185, N'Admin-Address-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1186, N'Admin-Address-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1187, N'Admin-Address-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1188, N'Admin-ShopDeliverySchedule-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1189, N'Admin-ShopDeliverySchedule-GetShopSchedule')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1190, N'Admin-ShopDeliverySchedule-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1191, N'Admin-ShopDeliverySchedule-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1192, N'Admin-SupplierDeliveryOptionPair-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1193, N'Admin-SupplierDeliveryOptionPair-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1194, N'Admin-SupplierDeliveryOptionPair-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1195, N'Admin-SupplierDeliveryOptionPair-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1196, N'Admin-SupplierDeliveryOptionPair-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1197, N'Admin-SupplierDeliveryOptionPair-ShowCityList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1198, N'Admin-SupplierDeliveryOptionPair-GetSurroundingCities')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1199, N'Admin-Home-ChangeCountry')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1200, N'Admin-Home-GetBodyHeader')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1201, N'Admin-Home-ClearCache')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1202, N'Admin-MediaContentType-ShowMediaContentTypeList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1203, N'Admin-MediaContentType-ShowMediaContentTypeAddEdit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1204, N'Admin-MediaContentType-CreateMediaContentDetail')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1205, N'Admin-ProductCategoryPair-GetParentCategoryListByChildCategoryId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1206, N'Admin-ProductCategoryPair-GetAllNonExistingCategoryList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1207, N'Admin-ProductMediaDetail-ShowProductMediaDetailList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1208, N'Admin-ProductMediaDetail-ShowProductMediaDetailAdd')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1209, N'Admin-ProductMediaDetail-CreateMediaContentDetail')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1210, N'Admin-ProductMediaDetail-FileUpload')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1211, N'Admin-ProductView-CreateProductViewItem')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1212, N'Admin-ProductView-insertNewRecord')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1213, N'Admin-ProductView-AssocistedProductViewItems')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1214, N'Admin-ProductView-FillProductMedia')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1215, N'Admin-ProductView-FillGridProductID')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1216, N'Admin-ProductView-ProductViewItems')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1217, N'Admin-ContactType-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1218, N'Admin-ContactType-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1219, N'Admin-ContactType-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1220, N'Admin-ContactType-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1221, N'Admin-ContactType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1222, N'Admin-Country-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1223, N'Admin-Country-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1224, N'Admin-Country-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1225, N'Admin-Country-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1226, N'Admin-Country-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1227, N'Admin-Currency-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1228, N'Admin-Currency-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1229, N'Admin-Currency-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1230, N'Admin-Currency-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1231, N'Admin-Currency-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1232, N'Admin-DocumentType-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1233, N'Admin-DocumentType-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1234, N'Admin-DocumentType-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1235, N'Admin-DocumentType-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1236, N'Admin-DocumentType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1237, N'Admin-Language-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1238, N'Admin-Language-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1239, N'Admin-Language-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1240, N'Admin-Language-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1241, N'Admin-Language-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1242, N'Admin-LocaleStringResource-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1243, N'Admin-LocaleStringResource-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1244, N'Admin-LocaleStringResource-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1245, N'Admin-LocaleStringResource-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1246, N'Admin-LocaleStringResource-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1247, N'Admin-Log-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1248, N'Admin-Log-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1249, N'Admin-Log-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1250, N'Admin-Log-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1251, N'Admin-Log-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1252, N'Admin-SearchTerm-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1253, N'Admin-SearchTerm-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1254, N'Admin-SearchTerm-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1255, N'Admin-SearchTerm-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1256, N'Admin-SearchTerm-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1257, N'Admin-Profile-AttachAddress')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1258, N'Admin-Profile-AddressList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1259, N'Admin-Profile-insertNewRecord')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1260, N'Admin-Product-ShowProductMediaDetail')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1261, N'Admin-LocalizedProperty-Index')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1262, N'Admin-LocalizedProperty-Details')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1263, N'Admin-LocalizedProperty-Create')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1264, N'Admin-LocalizedProperty-Edit')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1265, N'Admin-LocalizedProperty-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1266, N'api-Cart-GetCurrentUserCart')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1267, N'api-Cart-GetCartList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1268, N'api-Cart-GetCartById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1269, N'api-Cart-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1270, N'api-Cart-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1271, N'api-Cart-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1272, N'api-Cart-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1273, N'api-Cart-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1274, N'api-OrderStatusMap-GetSortedList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1275, N'api-OrderStatusMap-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1276, N'api-OrderStatusMap-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1277, N'api-OrderStatusMap-GetOrderStatusMapById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1278, N'api-OrderStatusMap-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1279, N'api-OrderStatusMap-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1280, N'api-OrderStatusMap-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1281, N'api-PayOptionMatrix-GetPayOptionMatrixList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1282, N'api-PayOptionMatrix-GetPayOptionMatrixById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1283, N'api-PayOptionMatrix-GetIdBy')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1284, N'api-PayOptionMatrix-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1285, N'api-PayOptionMatrix-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1286, N'api-PayOptionMatrix-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1287, N'api-PayOptionMatrix-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1288, N'api-PayOptionMatrix-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1289, N'api-Attribute-GetAttributeListNotAssociatedWithProductId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1290, N'api-Attribute-GetAttributeListNotAssociatedWithCategoryId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1291, N'api-Attribute-GetAttributeLookupList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1292, N'api-Attribute-GetAttributeList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1293, N'api-Attribute-GetAttributeByName')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1294, N'api-Attribute-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1295, N'api-Attribute-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1296, N'api-Attribute-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1297, N'api-Attribute-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1298, N'api-Attribute-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1299, N'api-Address-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1300, N'api-Address-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1301, N'api-Address-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1302, N'api-Address-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1303, N'api-Address-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1304, N'api-Address-GetNonEditableAddressList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1305, N'api-Address-GetAddressList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1306, N'api-Address-GetDeliveryAddressByCartId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1307, N'api-AddressContactInfoPair-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1308, N'api-AddressContactInfoPair-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1309, N'api-AddressContactInfoPair-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1310, N'api-AddressContactInfoPair-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1311, N'api-AddressContactInfoPair-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1312, N'api-AddressType-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1313, N'api-AddressType-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1314, N'api-AddressType-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1315, N'api-AddressType-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1316, N'api-AddressType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1317, N'api-AppConfig-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1318, N'api-AppConfig-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1319, N'api-AppConfig-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1320, N'api-AppConfig-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1321, N'api-AppConfig-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1322, N'api-AppConfig-GetShopPreferences')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1323, N'api-AttributeType-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1324, N'api-AttributeType-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1325, N'api-AttributeType-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1326, N'api-AttributeType-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1327, N'api-AttributeType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1328, N'api-Brand-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1329, N'api-Brand-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1330, N'api-Brand-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1331, N'api-Brand-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1332, N'api-Brand-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1333, N'api-CartItem-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1334, N'api-CartItem-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1335, N'api-CartItem-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1336, N'api-CartItem-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1337, N'api-CartItem-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1338, N'api-CartItem-GetCartItemListByCartOrderId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1339, N'api-Order-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1340, N'api-Order-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1341, N'api-Order-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1342, N'api-Order-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1343, N'api-Order-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1344, N'api-Order-GetOrderList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1345, N'api-Order-GetCartOrderLookupList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1346, N'api-Order-GetCartOrderComposedById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1347, N'api-Order-GetCartListByCartStatus')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1348, N'api-Order-GetOrderListByOrderStatus')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1349, N'api-Order-Sp_ConvertCartToOrders')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1350, N'api-Order-GetAddressListByCartOrderId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1351, N'api-Order-GetDeliveryAddressList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1352, N'api-Order-GetBillingAddressList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1353, N'api-Category-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1354, N'api-Category-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1355, N'api-Category-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1356, N'api-Category-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1357, N'api-Category-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1358, N'api-Category-GetCategoryList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1359, N'api-Category-GetCategoryListLookup')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1360, N'api-Category-GetCategoryListNotAssociatedWithProductId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1361, N'api-Category-GetListByPage')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1362, N'api-CategoryAttributePair-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1363, N'api-CategoryAttributePair-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1364, N'api-CategoryAttributePair-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1365, N'api-CategoryAttributePair-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1366, N'api-CategoryAttributePair-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1367, N'api-CategoryAttributePair-GetCategoryAttributePairList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1368, N'api-CategoryAttributePair-GetListByCategoryId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1369, N'api-CategoryAttributePair-GetCategoryAttrobutePairList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1370, N'api-CategoryType-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1371, N'api-CategoryType-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1372, N'api-CategoryType-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1373, N'api-CategoryType-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1374, N'api-CategoryType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1375, N'api-ContactInfo-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1376, N'api-ContactInfo-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1377, N'api-ContactInfo-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1378, N'api-ContactInfo-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1379, N'api-ContactInfo-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1380, N'api-ContactType-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1381, N'api-ContactType-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1382, N'api-ContactType-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1383, N'api-ContactType-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1384, N'api-ContactType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1385, N'api-Country-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1386, N'api-Country-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1387, N'api-Country-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1388, N'api-Country-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1389, N'api-Country-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1390, N'api-Currency-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1391, N'api-Currency-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1392, N'api-Currency-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1393, N'api-Currency-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1394, N'api-Currency-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1395, N'api-DataType-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1396, N'api-DataType-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1397, N'api-DataType-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1398, N'api-DataType-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1399, N'api-DataType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1400, N'api-DeliveryOption-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1401, N'api-DeliveryOption-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1402, N'api-DeliveryOption-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1403, N'api-DeliveryOption-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1404, N'api-DeliveryOption-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1405, N'api-DocumentType-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1406, N'api-DocumentType-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1407, N'api-DocumentType-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1408, N'api-DocumentType-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1409, N'api-DocumentType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1410, N'api-ExecAction-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1411, N'api-ExecAction-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1412, N'api-ExecAction-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1413, N'api-ExecAction-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1414, N'api-ExecAction-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1415, N'api-ExecActionParam-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1416, N'api-ExecActionParam-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1417, N'api-ExecActionParam-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1418, N'api-ExecActionParam-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1419, N'api-ExecActionParam-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1420, N'api-Group-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1421, N'api-Group-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1422, N'api-Group-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1423, N'api-Group-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1424, N'api-Group-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1425, N'api-GroupRolePair-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1426, N'api-GroupRolePair-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1427, N'api-GroupRolePair-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1428, N'api-GroupRolePair-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1429, N'api-GroupRolePair-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1430, N'api-Language-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1431, N'api-Language-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1432, N'api-Language-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1433, N'api-Language-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1434, N'api-Language-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1435, N'api-LocaleStringResource-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1436, N'api-LocaleStringResource-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1437, N'api-LocaleStringResource-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1438, N'api-LocaleStringResource-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1439, N'api-LocaleStringResource-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1440, N'api-LocalizedProperty-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1441, N'api-LocalizedProperty-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1442, N'api-LocalizedProperty-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1443, N'api-LocalizedProperty-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1444, N'api-LocalizedProperty-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1445, N'api-LocationLevel-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1446, N'api-LocationLevel-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1447, N'api-LocationLevel-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1448, N'api-LocationLevel-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1449, N'api-LocationLevel-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1450, N'api-LocationTree-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1451, N'api-LocationTree-GetLocationTreeByLocationId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1452, N'api-LocationTree-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1453, N'api-LocationTree-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1454, N'api-LocationTree-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1455, N'api-LocationTree-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1456, N'api-LocationTree-GetCountries')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1457, N'api-LocationTree-GetProvincesByCountryId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1458, N'api-LocationTree-GetCitiesByProvinceID')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1459, N'api-LocationTree-GetLocationList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1460, N'api-LocationTree-GetLocationListByParentName')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1461, N'api-Log-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1462, N'api-Log-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1463, N'api-Log-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1464, N'api-Log-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1465, N'api-Log-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1466, N'api-MediaContentType-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1467, N'api-MediaContentType-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1468, N'api-MediaContentType-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1469, N'api-MediaContentType-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1470, N'api-MediaContentType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1471, N'api-Option-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1472, N'api-Option-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1473, N'api-Option-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1474, N'api-Option-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1475, N'api-Option-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1476, N'api-OptionType-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1477, N'api-OptionType-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1478, N'api-OptionType-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1479, N'api-OptionType-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1480, N'api-OptionType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1481, N'api-OrderDeliveryDetail-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1482, N'api-OrderDeliveryDetail-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1483, N'api-OrderDeliveryDetail-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1484, N'api-OrderDeliveryDetail-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1485, N'api-OrderDeliveryDetail-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1486, N'api-OrderDeliveryDetail-GetOrderDeliveryDetailList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1487, N'api-OrderDeliveryDetail-GetOrderDeliveryDetailById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1488, N'api-OrderPayment-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1489, N'api-OrderPayment-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1490, N'api-OrderPayment-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1491, N'api-OrderPayment-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1492, N'api-OrderPayment-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1493, N'api-OrderStatus-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1494, N'api-OrderStatus-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1495, N'api-OrderStatus-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1496, N'api-OrderStatus-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1497, N'api-OrderStatus-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1498, N'api-OrderStatus-GetNextOrderStatusList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1499, N'api-OrderStatus-GetRootOrderStatus')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1500, N'api-PackagedProduct-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1501, N'api-PackagedProduct-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1502, N'api-PackagedProduct-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1503, N'api-PackagedProduct-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1504, N'api-PackagedProduct-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1505, N'api-PackagedProduct-GetListByProductId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1506, N'api-Payment-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1507, N'api-Payment-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1508, N'api-Payment-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1509, N'api-Payment-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1510, N'api-Payment-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1511, N'api-PayMode-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1512, N'api-PayMode-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1513, N'api-PayMode-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1514, N'api-PayMode-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1515, N'api-PayMode-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1516, N'api-PayMode-GetPayModeListByPayTypeId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1517, N'api-PayType-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1518, N'api-PayType-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1519, N'api-PayType-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1520, N'api-PayType-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1521, N'api-PayType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1522, N'api-Product-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1523, N'api-Product-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1524, N'api-Product-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1525, N'api-Product-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1526, N'api-Product-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1527, N'api-Product-GetLookupList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1528, N'api-Product-GetLookupByShopId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1529, N'api-Product-GetCartItemProduct')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1530, N'api-Product-GetProductDetail')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1531, N'api-Product-GetAllNonExistingCategoryList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1532, N'api-Product-GetParentCategoryListByChildCategoryId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1533, N'api-Product-ShowCategoryListByProductId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1534, N'api-Product-GetProductListByType')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1535, N'api-Product-GetDeliveryProductList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1536, N'api-Product-GetTaxProductList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1537, N'api-Product-AddProductCategoryPair')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1538, N'api-Product-AddProductBasicInfo')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1539, N'api-Product-UpdatePricing')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1540, N'api-Product-UpdateBasicInfo')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1541, N'api-Product-UpdateImages')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1542, N'api-Product-ProductSearchByPage')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1543, N'api-Product-GetListByPage')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1544, N'api-ProductAttributePair-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1545, N'api-ProductAttributePair-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1546, N'api-ProductAttributePair-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1547, N'api-ProductAttributePair-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1548, N'api-ProductAttributePair-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1549, N'api-ProductAttributePair-GetProductAttributePairList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1550, N'api-ProductAttributePair-GetListByProductID')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1551, N'api-ProductAttributePair-GetAllCustomizationAttributesByProductId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1552, N'api-ProductAttributePair-GetAssignedCustomizationAttributesByProductId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1553, N'api-ProductAttributePair-UpdateIsAssigned')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1554, N'api-ProductMediaDetail-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1555, N'api-ProductMediaDetail-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1556, N'api-ProductMediaDetail-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1557, N'api-ProductMediaDetail-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1558, N'api-ProductMediaDetail-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1559, N'api-ProductMediaDetail-PutImage')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1560, N'api-ProductType-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1561, N'api-ProductType-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1562, N'api-ProductType-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1563, N'api-ProductType-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1564, N'api-ProductType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1565, N'api-ProductView-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1566, N'api-ProductView-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1567, N'api-ProductView-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1568, N'api-ProductView-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1569, N'api-ProductView-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1570, N'api-ProductView-GetProductViewListByName')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1571, N'api-ProductViewItem-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1572, N'api-ProductViewItem-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1573, N'api-ProductViewItem-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1574, N'api-ProductViewItem-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1575, N'api-ProductViewItem-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1576, N'api-Profile-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1577, N'api-Profile-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1578, N'api-Profile-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1579, N'api-Profile-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1580, N'api-Profile-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1581, N'api-Profile-GetProfileByUserId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1582, N'api-Profile-GetProfileByUserName')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1583, N'api-Profile-GetProfileByEmail')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1584, N'api-ProfileVerification-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1585, N'api-ProfileVerification-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1586, N'api-ProfileVerification-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1587, N'api-ProfileVerification-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1588, N'api-ProfileVerification-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1589, N'api-ProfileVerification-GetListForAdmin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1590, N'api-ProfileVerification-GetListForAdminByProfileId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1591, N'api-ProfileVerification-GetListForPublic')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1592, N'api-ProfileVerification-GetByIdForAdmin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1593, N'api-ProfileVerification-PostForAdmin')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1594, N'api-ProfileVerification-PostForUser')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1595, N'api-ProfileVerification-PutForUser')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1596, N'api-Role-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1597, N'api-Role-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1598, N'api-Role-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1599, N'api-Role-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1600, N'api-Role-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1601, N'api-RoleOptionPair-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1602, N'api-RoleOptionPair-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1603, N'api-RoleOptionPair-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1604, N'api-RoleOptionPair-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1605, N'api-RoleOptionPair-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1606, N'api-RoleOptionPair-GetByRoleID')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1607, N'api-SearchTerm-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1608, N'api-SearchTerm-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1609, N'api-SearchTerm-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1610, N'api-SearchTerm-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1611, N'api-SearchTerm-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1612, N'api-StateMachine-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1613, N'api-StateMachine-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1614, N'api-StateMachine-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1615, N'api-StateMachine-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1616, N'api-StateMachine-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1617, N'api-StateMachineState-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1618, N'api-StateMachineState-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1619, N'api-StateMachineState-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1620, N'api-StateMachineState-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1621, N'api-StateMachineState-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1622, N'api-Status-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1623, N'api-Status-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1624, N'api-Status-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1625, N'api-Status-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1626, N'api-Status-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1627, N'api-Schedule-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1628, N'api-Schedule-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1629, N'api-Schedule-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1630, N'api-Schedule-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1631, N'api-Schedule-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1632, N'api-Schedule-GetScheduleById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1633, N'api-Schedule-IsShopDeliversAtDate')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1634, N'api-Schedule-GetScheduleByDates')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1635, N'api-Schedule-GetNextScheduleBySpecificDate')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1636, N'api-Supplier-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1637, N'api-Supplier-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1638, N'api-Supplier-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1639, N'api-Supplier-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1640, N'api-Supplier-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1641, N'api-Supplier-GetSupplierById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1642, N'api-Supplier-GetSupplierByProfileId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1643, N'api-Supplier-GetSupplierByName')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1644, N'api-SupplierDeliveryOptionPair-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1645, N'api-SupplierDeliveryOptionPair-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1646, N'api-SupplierDeliveryOptionPair-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1647, N'api-SupplierDeliveryOptionPair-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1648, N'api-SupplierDeliveryOptionPair-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1649, N'api-SupplierDeliveryOptionPair-GetSurroundingCities')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1650, N'api-SupplierDeliveryOptionPair-GetSupplierDeliveryOptionList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1651, N'api-SupplierDeliveryOptionPair-GetSupplierDeliveryOptionById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1652, N'api-SupplierDeliveryOptionPair-GetSupplierDeliveryOptionBySupplierId')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1653, N'api-SupplierDeliveryOptionPair-PutSupplierDeliveryOptionList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1654, N'api-Tax-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1655, N'api-Tax-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1656, N'api-Tax-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1657, N'api-Tax-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1658, N'api-Tax-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1659, N'api-TaxType-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1660, N'api-TaxType-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1661, N'api-TaxType-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1662, N'api-TaxType-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1663, N'api-TaxType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1664, N'api-User-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1665, N'api-User-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1666, N'api-User-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1667, N'api-User-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1668, N'api-User-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1669, N'api-User-LoginUser')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1670, N'api-User-ChangePassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1671, N'api-UserType-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1672, N'api-UserType-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1673, N'api-UserType-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1674, N'api-UserType-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1675, N'api-UserType-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1676, N'api-VerificationStatus-GetList')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1677, N'api-VerificationStatus-GetById')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1678, N'api-VerificationStatus-Put')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1679, N'api-VerificationStatus-Post')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1680, N'api-VerificationStatus-Delete')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1681, N'api-PaymentGateway-GetStripeSession')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1682, N'api-Account-LoginUser')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1683, N'api-Account-Register')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1684, N'api-Account-ForgotPassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1685, N'api-Account-ResetPassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1686, N'api-Account-ConfirmEmail')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1687, N'api-Account-ChangePassword')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1688, N'api-Account-ResendConfirmationEmail')
GO
INSERT [dbo].[PERMISSIONS] ([PermissionId], [PermissionDescription]) VALUES (1689, N'api-Account-GetPermissionsImport')
GO
SET IDENTITY_INSERT [dbo].[PERMISSIONS] OFF
GO
SET IDENTITY_INSERT [dbo].[ROLES] ON 
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (1, CAST(N'2017-04-02T13:11:32.653' AS DateTime), 0, N'No Authentication/Authorization required for shopping on public site', N'Anonymous')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (2, CAST(N'2017-04-02T12:56:12.517' AS DateTime), 0, N'Shopping as registered & logged-in user', N'Buyer')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (3, CAST(N'2017-04-03T23:57:14.237' AS DateTime), 0, N'Shop management as registered & logged-in user', N'Shop')
GO
INSERT [dbo].[ROLES] ([RoleId], [LastModified], [IsSysAdmin], [RoleDescription], [Name]) VALUES (5, CAST(N'2017-04-04T10:00:00.000' AS DateTime), 1, N'Admin Portal Full Access, Security Configuraation, Admin access on Public Site(as admin, buyer & seller', N'Admin')
GO
SET IDENTITY_INSERT [dbo].[ROLES] OFF
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 544)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 545)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 546)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 547)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 548)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 549)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 555)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 556)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 557)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 558)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 559)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 560)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 561)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 562)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 563)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 564)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 565)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 566)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 567)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 568)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 569)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 570)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 571)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 572)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 589)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 590)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 591)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 592)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 593)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 604)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 605)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 606)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 607)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 608)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 609)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 610)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 611)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 622)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 623)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 624)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 625)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 626)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 627)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 628)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 629)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 630)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 631)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 632)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 633)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 634)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 635)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 636)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 637)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 638)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 639)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 640)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 641)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 642)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 643)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 644)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 645)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 646)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 647)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 648)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 649)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 676)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 677)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 678)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 679)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 680)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 707)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 708)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 709)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 710)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 711)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 712)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 713)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 714)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 715)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 716)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 717)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 718)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 719)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 720)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 721)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 722)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (3, 723)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 550)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 551)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 552)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 553)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 554)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 578)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 579)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 580)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 581)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 582)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 599)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 600)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 601)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 602)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 603)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 612)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 613)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 614)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 615)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 616)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 617)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 618)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 619)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 620)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 621)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 681)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 682)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 683)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 684)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 685)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 686)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 687)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 688)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 689)
GO
INSERT [dbo].[LNK_ROLE_PERMISSION] ([RoleId], [PermissionId]) VALUES (5, 690)
GO
SET IDENTITY_INSERT [dbo].[USERS] ON 
GO
INSERT [dbo].[USERS] ([UserId], [LastModified], [Inactive], [Firstname], [Lastname], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (1, CAST(N'2021-02-10T18:39:57.877' AS DateTime), 0, N'Admin', N'', N'admin@zvonr.com', 1, N'AH4pKHoC53zyeSoFTboEHznkRHDtCJu3OyA1lwbpR/zq3aWWwkGhBaskCZhcByRWMA==', N'b51bc57c-5e57-40e9-8a15-e260fe97563b', N'03333076655', 1, 0, NULL, 0, 0, N'admin@zvonr.com')
GO
SET IDENTITY_INSERT [dbo].[USERS] OFF
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (1, 3)
GO
INSERT [dbo].[LNK_USER_ROLE] ([UserId], [RoleId]) VALUES (1, 5)
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201705211831311_InitialCreate', N'OMSCloud.Web.MVC.Net.Areas.Security.Models.SecurityDbContext', 0x1F8B0800000000000400ED5DDB6EEBB8157D2FD07F10F4D416193B27A71D9C06F60C324ED21A931BE2E4B46F012DD18E3012E591A84C82A25FD6877E527FA1A46E166F12A98B2F98C1010E12895CDCDC5CBC6DEDBDF3BFFFFC77F2FD7BE05B6F308ABD104DED4FA353DB82C8095D0FADA7768257DF7CB1BFFFEEF7BF9B5CB9C1BBF5B528F799962335513CB55F31DE9C8FC7B1F30A03108F02CF89C2385CE191130663E086E3B3D3D3BF8E3F7D1A430261132CCB9A3C26087B014C7F21BFCE42E4C00D4E807F1BBAD08FF3E7E4CD2245B5EE4000E30D70E0D4BEBF5DCCFC307147FF80CBD1EDD7D9E80EE2D1450449D30BE82491873F46198A6D5DF81E20122EA0BFB22D8050880126F29F3FC77081A310AD171BF200F84F1F1B48CAAD801FC3BC5FE7DBE2BA5D3C3DA35D1C6F2B16504E12E3303004FCF439D7D998AFDE4AF376A953A2D52BA27DFC417B9D6A766A3F5C3DDECE178BF9FD9D6DF1CD9DCFFC88163551FD680B7862C9AA9D945C2294A3FF4EAC59E2E324825304131C01FFC47A4896BEE7FC083F9EC29F209AA2C4F7ABBD20FD20EF9807E4D143146E60843F1EE1AAE81B8C022FA66DCD5DDB1AB308631EA20490D6CEF43047F8DB3FDBD61D11082C7D5812A7A2B3050E23F83788600430741F00C63022E33E7761AA7A410E65AB973076226F938D7BD63CA12E999DB6750BDE6F205AE357326F4F4FC984BCF6DEA15B3CCA657A461E99CDA4168E1228919993E30EBC79EBB40B9C448FF737570BDB7A847EFA367EF536D9C41A5D6C366498D2A78FA10F5FB6434FCA5F4761409F4EED9A622F4F205A434CFA1736975D8449E470824FC65B46D7F29C03EE89EC1CEADE19DF86E7BB64F70D8831519DB7F260D9EA25417A225B42334579C1E3C5477CE1065E393F7E08C92000648C44C74E6FBA911FB5665B7D7BF4FF9A46CEFEF2EDB0539A99A8C34CEC62B2EA4CEC6211D0159F6CE251AC25785E522D725AA051D8AC944CCC36EB0F451B660D2A90F7BE0E5141C4B5485A94CADB66D92A9AA85FBA9AE7BD31867AA34CC7B49E95C508BD6485A5C464CAD471932DD8273D87A1E6DE69F9EBDA1E1170B0F706BB6E8ED75E146354BF63F5B32DD2EEEFA4A1AB00787E0F1BB0462BE482BBF2A2603B9E6D87E101C4F12F61E4FE1DC4AF832BA898C80B0C82CDE0AD3DBC8608DE25C1922E3CBB6BABB7A179FA25BC26732D8CAE10ADD519EF26747E0A137C855C3AF99FB123AE059A00BD8873E138308EAF0999A13B0B13842B0BE2E7336338BA13ECFB003CF38117341E21A9A42F4551E5569D9768DAA88B62A687DD9B70ED213D518BA26A51B3128DA2E6C54C45A5607A92E625D582A6051AE5CC4AF579F049076998D34F0A7DFC4720E98CEFEF08D4C7B13ED53405187C37495BFA0AFCA4EFA6DAF2379DB9C3F03785DE3B7F5329C8E337CFA5A7058D0B665198C06B9597DF5D9B67092799DA627BF6A597CD8D3FD854BBB9EBC6CD67AD8AE017711C3A5E4A3AB9E5963146B142910393656099CA7424311B118D11F67AF41991706AFF49E8BE5E4BA5717BDB52F5734B6D2393714513DA0A62CD0B1A322B6C0D52D56CED56ADD423B756E88FC2279B9FBBF7E812FA1043EBC2C93EAECD40EC0057642BE19ACB3E21D31D46744702F486169325CA43585C1B3CE4781BE06B7686ABAFB9FF52F9CA96F83797700311DD3A35874E4704B9C58D8A51B6C6A9AF495BEDC85AB1D0EACE2ECE5CBB1FEE3489574F6DFD59D495A3A2C6764B505125C7C4CEEAE54F7375136E824A02EC9E9FB22BA85ABEFC1A343443254ADBFD1ACA69454700E5E78D7D7034BFF5EB728037011C1A4739DB835ABEFCAAB3138EB24ADB034759AD1C1D47337B8F2E0538E3CFA13194B53AED7B971735B6077A322A39307666F74C5207931A30E2BE705C2EE91BF88E25461322646E3789F37B314F118ABC8058E656B1BDDE4AAE7EC27D8905CACDA3028470CA6DC09110B20176CBDB06E8DCB3A209CB54C4C2DADE849B1F50CCC00BFB781378BEB370E0157A495B103D652A35341C6BF8996066CD28BB5EB247985A66468B0A20D3297EE164D562A632CE1BA2565F35A60D33E346A563F2F9A1A738B939A36918BAE9ABEAD3D44C2EC9D5DAE072DD8950EC45D850E3DD39557EB46B6494F4866772C7ABF42D1F187DFAF0F731B59E8AFEF4AEA862496C5694EC9A6172D1E8A428EE52A05654D19FDE159533B5594F92A3AEC161B79396D883697FB3AEB0D59767A8F2DD649C8569E40F2663453CC7E4166C361E5A57E23BF227D6220BEE987DB3308F6E08328CB1C3289C3FF1952DE130026BC8BD254D13495327A74B80C112D02F153337108A892746C5E1A3684F3C148A43591C448A3AF4E7AC5EAB900BC9D93B47BE265D0FE8013EFD3E2BDDDCC5CA160DC3013E886A432366A19F04A839E4420F91F1C396433345C4362663AECFC21D43D0BB70196487526BA05513BF9721E64FFEE6E3DC88A01A1A7E8855065A3502EBD658C562DFE823565DFFAB78D5E7FA68B4474ADA092FF571332FA72A58F6E460282BDD1786677079C9ECC462358A6A3C0AA34375445486887AB6E8CF893D8DACEAEC3FC450761FC6F68B91F9F00DB018958ED6CC52543ED547AAB85A57A12A8FCDFA29426D9FEA23E5DED25598FC912146C5E15600ABBC333835303ED1CC618179A38FC8393E5721B957065256DD9B1921AB2F5AE129342A2FA1DF82E8D05C4517DF1AB052746D66E829BE6E812D91997FA78F2AF17EAE024B5EEB636F5DA1F935EDB00F0A4AA3C910DB4B66EAEDBCC7286074371AB34DA69F9346C58FB50A54796C88957BAA0A60F9F343A59BD2F43404DD32E37F67BA2960D46B17E33CCA2E5DB51EAF6A4CC62394D91EEA3C62D57866A41E9A3AACB54AC91FF1AB4C1FF76F16B1E1AAADB6B0505B1EBFDD347FEB1155DDE9DE9E7EFB2EEA761350F901B8572B925A60DE862912473065F2454ADA96264DCE7439C9CD88CDF96A04BB6256C4B68AF947CE941F3186C18816182D7EF667BE07E909A228700B90B78231CE5CE6EDB3D3D32F5C6A9BC34933338E63D7979861E5B966D861DB533697A54756569CCFDFBA90155357FCBA1C2EE80D44CE2B8824595C5A39CC37663A69A16AF952D1ACE4A2DEB0EA954549BB041AF7934464E9E1BE12881463FD8700BCFFB10A6A9A24644B1AC149658E5CF83EB5FF95D63A4FBF0CD19FD2C727D63C7E46DECF0979F1449AB4FE2D8659F64E3AB95DEE40F346141C6D52EBFC9F2F59C513EB3E222BF3B9754A95D929DF8441DB594583B65B277EE86DD0DA8EC461AF165C4E85366B85904FA1D32AC1E74CE804C6E445906E54DC92D13E0D421BCDC9522074EAAF34CD412744492A83BEF07A51A12A55411B2C659A02D9F4D2E2B2346D411BD194290BD225A663C202FDCDB8A8B9DFCD5862F9DA45ACF820ABF93E776F21ACBCD3CC1643C70DE0BA8587B7A0C291855DCB2F5934F6B97B54756FD8BBE372DBBB63B70BBBD2E0D4F7DD7E77C76A33BB828604D5EA3D0CA851F4BCD49EA876EA3DBC78DB6A44855A36ED907BAB9F90DB8E51AE6D236D6B9D000F37CC56CB865CA18062CCD583FCABA2A221099AECEC3BE2629318BB0F5854049A1CCBE2B88DE2DA7774E29E16C41A0FC3035F0A8DF261FCC6BADF58D7C7726798E7E2F062B2F370D0834868D131FEB92DF1546E52079E19C02C7BC5E1312F8F153E8834157B629ECA63EAC0992789763826E21DC64EBB47DA69EFB47BCF35210618F263ACCA23D190462273289ADAEE322454C8AC4575C1FA35F91132BA34679C903599FF8520F36414BAB928648DDEDCFDF8F2BCB87A7CA1AD9B36AE93B842D6286DD0B8A7F9D94333A585ACD98B787307714D20B84EE20BEDBC17F5122822AC1BA8554BE99AB2AA91A783FE529351C534594719806D94B343E191597761AB89C83448B020AAB3C1F1B4FF3414B29C2166CA937B8B2A6C7DF288E5A351D9C0994EFAE216BF302B632E8F27ADC9F1AA65E04C26759D31510CB3BDA9236F8E2977495FAA61F65D7594C8F1642BE94B313D4F26830425A2F73E39EE57FE262DB975C4DE7A0B41FF422D820E73D02FCBCCD12A2CEE1B9C444511EE73F12DC4C025B7808B087B2BE060F29A7A2AA569DA536710EA2FB784EE1CDD27789360D265182C7DC68582DE5BEADA4FB3B0B0324FEE53BFE4B88F2E10313DEAE1758F7E483CDF2DE5BE967CA65640D00B51EE1444C71253E7A0F547897417224DA05C7DE53DEE09061B9F80C5F76801A89BA6B96C847E37700D9C8FAD4F890AA4792058B54F2E3DB08E4010E718DBFAE457C2613778FFEEFF62D84CEE9A790000, N'6.1.3-40302')
GO
