using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using oms = OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.DataStore.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.Common.DBEnums;
using System.Data.SqlClient;

namespace OMSCloud.Business.Adapters
{
    public partial class NotificationTokenAdapter : BaseAdapter<NotificationToken, NotificationTokenModel>
    {
        protected override OMSRepositoryBase<NotificationToken> Repo { get; }

        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.TokenId == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        protected override NotificationToken GetEntity(NotificationTokenModel model)
        {
            return new NotificationToken
            {
                CreatedOn = DateTime.Now,
                DeviceId = model.DeviceId,
                DevicePlatform = model.DevicePlatform,
                NotificationService = model.NotificationService,
                ProfileId = model.ProfileId,
                StatusId = model.StatusId,
                Token = model.Token,
                TokenId = model.TokenId,
            };
        }

        public NotificationTokenModel GetByNotificationToken(NotificationTokenModel model)
        {
            var result = (from t in uow.OMSContext.NotificationToken
                          where 
                                model.ProfileId == t.ProfileId && 
                                model.Token == t.Token && 
                                model.NotificationService == t.NotificationService && 
                                model.DevicePlatform == t.DevicePlatform &&
                                model.DeviceId == t.DeviceId
                                //&&  t.StatusId == (int)DBStatusEnum.Active
                          select new NotificationTokenModel {
                              CreatedOn = t.CreatedOn,
                              DeviceId = t.DeviceId,
                              DevicePlatform = t.DevicePlatform,
                              NotificationService = t.NotificationService,
                              ProfileId = t.ProfileId,
                              StatusId = t.StatusId,
                              Token = t.Token,
                              TokenId = t.TokenId
                          });
            return result.FirstOrDefault();
        }
        public List<string> GetNotificationTokenList()
        {
            var result = (from t in uow.OMSContext.NotificationToken
                          where
                                t.StatusId == (int)DBStatusEnum.Active
                          select t.Token);
            return result.ToList();
        }
        //
        public List<NotificationTokenModel> GetDeviceAllTokenList(long ProfileId)
        {
            var result = (from t in uow.OMSContext.NotificationToken
                          where
                                ProfileId == t.ProfileId// &&
                                //t.StatusId == (int)DBStatusEnum.Active
                          select new NotificationTokenModel {
                              //t.Token
                              TokenId = t.TokenId,
                              DeviceId = t.DeviceId,
                              ProfileId = t.ProfileId,
                              Token = t.Token,
                              DevicePlatform = t.DevicePlatform,
                              NotificationService = t.NotificationService,
                              StatusId = t.StatusId,
                              CreatedOn = t.CreatedOn,
                              

                          });
            return result.ToList();
        }

        public List<string> GetNotificationTokenListByProfileId(long ProfileId)
        {
            var result = (from t in uow.OMSContext.NotificationToken
                          where
                                ProfileId == t.ProfileId &&
                                t.StatusId == (int)DBStatusEnum.Active
                          select t.Token);
            return result.ToList();
        }

        protected override NotificationTokenModel GetModel(NotificationToken entity)
        {
            return new NotificationTokenModel
            {
                CreatedOn = DateTime.Now,
                DeviceId = entity.DeviceId,
                DevicePlatform = entity.DevicePlatform,
                NotificationService = entity.NotificationService,
                ProfileId = entity.ProfileId,
                StatusId = entity.StatusId,
                Token = entity.Token,
                TokenId = entity.TokenId,
            };
        }
    }

    public partial class NotifyAdapter : BaseAdapter<Notify, NotifyModel>
    {
        protected override OMSRepositoryBase<Notify> Repo { get; }

        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.NotificationId == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        protected override Notify GetEntity(NotifyModel model)
        {
            return new Notify
            {
                NotificationId = model.NotificationId,
                NotificationType = model.NotificationType,
                SenderProfileId = model.SenderProfileId,
                ReceiverProfileId = model.ReceiverProfileId,
                Message = model.Message,
                StatusId = model.StatusId,
                CreatedByUserID = model.CreatedBy,
                CreatedDateTime = model.CreatedOn,
                LastModifiedByUserID = model.RequestedByProfileId,
                LastModifiedDateTime = model.ModifiedOn,
                SubjectRowID = model.SubjectRowID
                //= model.
            };
        }

        protected override NotifyModel GetModel(Notify entity)
        {
            return new NotifyModel
            {
                NotificationId = entity.NotificationId,
                NotificationType = entity.NotificationType,
                SenderProfileId = entity.SenderProfileId,
                ReceiverProfileId = entity.ReceiverProfileId,
                Message = entity.Message,
                StatusId = entity.StatusId,
                CreatedBy = entity.CreatedByUserID,
                CreatedOn = entity.CreatedDateTime,
                ModifiedBy = entity.LastModifiedByUserID,
                ModifiedOn = entity.LastModifiedDateTime,
                SubjectRowID = entity.SubjectRowID,
                //RequestedByProfileId = entity.
            };
        }
    }
    public partial class BankAccountAdapter : BaseAdapter<BankAccount, BankAccountModel>
    {
        protected override OMSRepositoryBase<BankAccount> Repo
        {
            get
            {
                return this.uow.BankAccountRepository;
            }
        }

        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.BankId == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        protected override BankAccount GetEntity(BankAccountModel model)
        {
            return new BankAccount
            {
                BankId = model.BankId,
                SupplierId = model.SupplierId,
                Name = model.Name,
                AccountNumber = model.AccountNumber,
                AccountTitle = model.AccountTitle,
                Address = model.Address,
                IBAN = model.IBAN,
                AccountTypeId = model.AccountTypeId
            };
        }

        protected override BankAccountModel GetModel(BankAccount entity)
        {
            return GetModelWithConcurrency(entity, new BankAccountModel
            {
                BankId = entity.BankId,
                SupplierId = entity.SupplierId,
                Name = entity.Name,
                AccountNumber = entity.AccountNumber,
                AccountTitle = entity.AccountTitle,
                Address = entity.Address,
                IBAN = entity.IBAN,
                AccountTypeId = entity.AccountTypeId
            });
        }
    }
    public partial class ChatAdapter : BaseAdapter<Chat, ChatModel>
    {
        protected override OMSRepositoryBase<Chat> Repo
        {
            get
            {
                return this.uow.ChatRepository;
            }
        }

        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ChatId == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        public bool RemoveChatMessages(List<long> chatMessageListLong)
        {
            try
            {
                var chatMessageIds = string.Join(",", chatMessageListLong.Select(n => n.ToString()).ToArray());
                //var recordsCount = uow.OMSContext.UpdateTableStatus("ChatMessage", (int)DBStatusEnum.Deleted);
                 var recordsCount = uow.OMSContext.Bulk_Update("chatMessage", "messageid", chatMessageIds, "statusid", ((int)DBStatusEnum.Deleted).ToString());
                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        protected override Chat GetEntity(ChatModel model)
        {
            return new Chat {
                ChatId = model.ChatId,
                ChatCode = model.ChatCode,
                ProfileId1 = model.ProfileId1,
                ProfileId2 = model.ProfileId2,
                StatusId = model.StatusId,
            };
        }

        protected override ChatModel GetModel(Chat entity)
        {
            return GetModelWithConcurrency(entity, new ChatModel {
                ChatId = entity.ChatId,
                ChatCode = entity.ChatCode,
                ProfileId1 = entity.ProfileId1,
                ProfileId2 = entity.ProfileId2,
                StatusId = entity.StatusId,
                //CreatedBy = entity.CreatedByUserID,
                //CreatedOn = entity.CreatedDateTime,
                //ModifiedBy = entity.LastModifiedByUserID,
                //ModifiedOn = entity.LastModifiedDateTime,
            });
        }
    }
    public partial class ChatMessageAdapter : BaseAdapter<ChatMessage, ChatMessageModel>
    {
        protected override OMSRepositoryBase<ChatMessage> Repo
        {
            get
            {
                return this.uow.ChatMessageRepository;
            }
        }

        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.MessageId == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        protected override ChatMessage GetEntity(ChatMessageModel model)
        {
            return new ChatMessage {
                MessageId = model.MessageId,
                ChatId = model.ChatId,
                SenderProfileId = model.SenderProfileId,
                ReceiverProfileId = model.ReceiverProfileId,
                MessageCode = model.MessageCode,
                Message = model.Message,
                SentDateTime = model.SentDateTime,
                IsReceived = model.IsReceived,
                IsRead = model.IsRead,
                ReadDateTime = model.ReadDateTime,
                StatusId = model.StatusId,
            };
        }

        protected override ChatMessageModel GetModel(ChatMessage entity)
        {
            return GetModelWithConcurrency(entity, new ChatMessageModel
            {
                MessageId = entity.MessageId,
                ChatId = entity.ChatId,
                SenderProfileId = entity.SenderProfileId,
                ReceiverProfileId = entity.ReceiverProfileId,
                MessageCode = entity.MessageCode,
                Message = entity.Message,
                SentDateTime = entity.SentDateTime,
                IsReceived = entity.IsReceived,
                IsRead = entity.IsRead,
                ReadDateTime = entity.ReadDateTime,
                StatusId = entity.StatusId,
            });
        }
    }
    public partial class AddressAdapter : BaseAdapter<Address, AddressModel>
    {
        protected override OMSRepositoryBase<Address> Repo
        {
            get
            {
                return this.uow.AddressRepository;
            }
        }

        protected override Address GetEntity(AddressModel addressModel)
        {
            return new Address()
            {
                //ID = addressModel.AddressID,
                AddressID = addressModel.AddressID,
                ProfileID = addressModel.ProfileID,
                AddressTypeID = addressModel.AddressTypeID,
                PlotNumber = addressModel.PlotNumber,
                StreetNumber = addressModel.StreetNumber,
                CountryID = addressModel.CountryID,
                ProvinceID = addressModel.ProvinceID,
                CityID = addressModel.CityID,
                LocationID = addressModel.LocationID,
                NearestLandmark = addressModel.NearestLandmark,
                PostalCode = addressModel.PostalCode,
                MapLink = addressModel.MapLink,
                //StatusID = addressModel.StatusID,
                LastModifiedDateTime = addressModel.ModifiedOn,
            };
        }

        protected override AddressModel GetModel(Address address)
        {
            return GetModelWithConcurrency(address,  new AddressModel
            {
                AddressID = address.AddressID,
                ProfileID = address.ProfileID,
                AddressTypeID = address.AddressTypeID,
                PlotNumber = address.PlotNumber,
                StreetNumber = address.StreetNumber,
                CountryID = address.CountryID.HasValue ? address.CountryID.Value : -1,
                ProvinceID = address.ProvinceID.HasValue ? address.ProvinceID.Value : -1,
                CityID = address.CityID.HasValue ? address.CityID.Value : -1,
                LocationID = address.LocationID,
                NearestLandmark = address.NearestLandmark,
                PostalCode = address.PostalCode,
                MapLink = address.MapLink,
                //StatusID = address.StatusID,
                ModifiedOn = address.LastModifiedDateTime
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.AddressID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class AddressTypeAdapter : BaseAdapter<AddressType, AddressTypeModel>
    {
        protected override OMSRepositoryBase<AddressType> Repo
        {
            get
            {
                return this.uow.AddressTypeRepository;
            }
        }

        protected override AddressType GetEntity(AddressTypeModel addressTypeModel)
        {
            return new AddressType()
            {
                AddressTypeID = addressTypeModel.AddressTypeID,
                AddressTypeTitle = addressTypeModel.AddressTypeTitle,
                Description = addressTypeModel.Description,
                IsSystem = addressTypeModel.IsSystem
            };
        }

        protected override AddressTypeModel GetModel(AddressType addressType)
        {
            return new AddressTypeModel
            {
                AddressTypeID = addressType.AddressTypeID,
                AddressTypeTitle = addressType.AddressTypeTitle,
                Description = addressType.Description,
                IsSystem = addressType.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.AddressTypeID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class AppConfigAdapter : BaseAdapter<AppConfig, AppConfigModel>
    {
        protected override OMSRepositoryBase<AppConfig> Repo
        {
            get
            {
                return this.uow.AppConfigRepository;
            }
        }

        protected override AppConfig GetEntity(AppConfigModel appConfigModel)
        {
            return new AppConfig()
            {
                ConfigID = appConfigModel.ConfigID,
                ConfigTitle = appConfigModel.ConfigTitle,
                ConfigValue = appConfigModel.ConfigValue,
                Description = appConfigModel.Description,
                DisplayText = appConfigModel.DisplayText,
                ParentConfigID = appConfigModel.ParentConfigID,
                IsSystem = appConfigModel.IsSystem
            };
        }

        protected override AppConfigModel GetModel(AppConfig appConfig)
        {
            return new AppConfigModel
            {
                ConfigID = appConfig.ConfigID,
                ConfigTitle = appConfig.ConfigTitle,
                ConfigValue = appConfig.ConfigValue,
                Description = appConfig.Description,
                DisplayText = appConfig.DisplayText,
                ParentConfigID = appConfig.ParentConfigID,
                IsSystem = appConfig.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ConfigID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class AttributeAdapter : BaseAdapter<oms.Attribute, AttributeModel>
    {
        protected override OMSRepositoryBase<oms.Attribute> Repo
        {
            get
            {
                return this.uow.AttributeRepository;
            }
        }

        protected override oms.Attribute GetEntity(AttributeModel attributeModel)
        {
            return new oms.Attribute()
            {
                AttributeID = attributeModel.AttributeID,
                AttributeTitle = attributeModel.AttributeTitle,
                Description = attributeModel.Description,
                AttributeTypeID = attributeModel.AttributeTypeID,
                DataTypeID = attributeModel.DataTypeID,
                DataTypeSize = attributeModel.DataTypeSize,
                DefaultValue = attributeModel.DefaultValue,
                IsMandatory = attributeModel.IsMandatory,
                IsMultiSelect = attributeModel.IsMultiSelect,
                StatusID = attributeModel.StatusID,
                IsSystem = attributeModel.IsSystem,
            };
        }

        protected override AttributeModel GetModel(oms.Attribute attribute)
        {
            return GetModelWithConcurrency(attribute, new AttributeModel
            {
                AttributeID = attribute.AttributeID,
                AttributeTitle = attribute.AttributeTitle,
                Description = attribute.Description,
                AttributeTypeID = attribute.AttributeTypeID,
                DataTypeID = attribute.DataTypeID,
                DataTypeSize = attribute.DataTypeSize,
                DefaultValue = attribute.DefaultValue,
                IsMandatory = attribute.IsMandatory,
                IsMultiSelect = attribute.IsMultiSelect,
                StatusID = attribute.StatusID,
                IsSystem = attribute.IsSystem,
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            Repo.Delete(a => a.AttributeID == Id);
            return uow.Commit() > 0;
        }
        #endregion Delete
    }

    public partial class BrandAdapter : BaseAdapter<Brand, BrandModel>
    {
        protected override OMSRepositoryBase<Brand> Repo
        {
            get
            {
                return this.uow.BrandRepository;
            }
        }

        protected override Brand GetEntity(BrandModel brandModel)
        {
            return new Brand()
            {
                BrandID = brandModel.BrandID,
                BrandName = brandModel.BrandName,
                ManufacturerName = brandModel.ManufacturerName,
                Description = brandModel.Description,
                StatusID = brandModel.StatusID,
                IsSystem = brandModel.IsSystem
            };
        }

        protected override BrandModel GetModel(Brand brand)
        {
            return GetModelWithConcurrency(brand, new BrandModel
            {
                BrandID = brand.BrandID,
                BrandName = brand.BrandName,
                ManufacturerName = brand.ManufacturerName,
                Description = brand.Description,
                StatusID = brand.StatusID,
                IsSystem = brand.IsSystem
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.BrandID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class CartItemAdapter : BaseAdapter<CartItem, CartItemModel>
    {
        protected override OMSRepositoryBase<CartItem> Repo
        {
            get
            {
                return this.uow.CartItemRepository;
            }
        }

        protected override CartItem GetEntity(CartItemModel cartItemModel)
        {
            return new CartItem()
            {
                CartItemID = cartItemModel.CartItemID,
                CartOrderID = cartItemModel.CartOrderID,
                ProductID = cartItemModel.ProductID,
                UnitPrice = cartItemModel.UnitPrice,
                Quantity = cartItemModel.Quantity,
                TaxRateApplied = cartItemModel.TaxRateApplied,
                TaxAmount = cartItemModel.TaxAmount,
                DiscountAmount = cartItemModel.DiscountAmount,
                ItemTotalPrice = cartItemModel.ItemTotalPrice,
                StatusID = cartItemModel.StatusID,
            };
        }

        protected override CartItemModel GetModel(CartItem cartItem)
        {
            return GetModelWithConcurrency(cartItem, new CartItemModel
            {
                CartItemID = cartItem.CartItemID,
                CartOrderID = cartItem.CartOrderID,
                ProductID = cartItem.ProductID,
                UnitPrice = cartItem.UnitPrice,
                Quantity = cartItem.Quantity,
                TaxRateApplied = cartItem.TaxRateApplied,
                TaxAmount = cartItem.TaxAmount,
                DiscountAmount = cartItem.DiscountAmount,
                ItemTotalPrice = cartItem.ItemTotalPrice,
                StatusID = cartItem.StatusID,
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.CartItemID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }
    public partial class CartItemAttributePairAdapter : BaseAdapter<CartItemAttributePair, CartItemAttributePairModel>
    {
        protected override OMSRepositoryBase<CartItemAttributePair> Repo
        {
            get
            {
                return this.uow.CartItemAttributePairRepository;
            }
        }

        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.CartItemAttributeId == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        protected override CartItemAttributePair GetEntity(CartItemAttributePairModel model)
        {
            return new CartItemAttributePair {
                CartItemAttributeId = model.CartItemAttributeID,
                CartItemID = model.CartItemID,
                AttributeID = model.AttributeID,
                AttributeValue = model.AttributeValue,
                VariationInPrice = model.VariationInPrice,
            };
        }

        protected override CartItemAttributePairModel GetModel(CartItemAttributePair entity)
        {
            return new CartItemAttributePairModel
            {
                CartItemAttributeID = entity.CartItemAttributeId,
                CartItemID = entity.CartItemID,
                AttributeID = entity.AttributeID,
                AttributeValue = entity.AttributeValue,
                VariationInPrice = entity.VariationInPrice.HasValue ? entity.VariationInPrice.Value : 0,
            };
        }
    }
    public partial class CartAdapter : BaseAdapter<CartOrder, CartModel>
    {
        protected override OMSRepositoryBase<CartOrder> Repo
        {
            get
            {
                return this.uow.CartOrderRepository;
            }
        }

        protected override CartOrder GetEntity(CartModel cartModel)
        {
            return new CartOrder()
            {
                CartOrderID = cartModel.CartID,
                BuyerProfileID = cartModel.BuyerProfileID,
                OrderStatusID = cartModel.CartStatusID,
                StatusID = cartModel.StatusID,
                OrderTotal = cartModel.CartTotal,
                TaxTotal = cartModel.TaxTotal,
                DiscountTotal = cartModel.DiscountTotal,
            };
        }

        protected override CartModel GetModel(CartOrder cartOrder)
        {
            return GetModelWithConcurrency(cartOrder, new CartModel
            {
                CartID = cartOrder.CartOrderID,
                BuyerProfileID = cartOrder.BuyerProfileID,
                CartStatusID = cartOrder.OrderStatusID,
                StatusID = cartOrder.StatusID,
                CartTotal = cartOrder.OrderTotal,
                TaxTotal = cartOrder.TaxTotal,
                DiscountTotal = cartOrder.DiscountTotal,
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.CartOrderID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class OrderAdapter : BaseAdapter<CartOrder, OrderModel>
    {
        protected override OMSRepositoryBase<CartOrder> Repo
        {
            get
            {
                return this.uow.CartOrderRepository;
            }
        }

        protected override CartOrder GetEntity(OrderModel cartOrderModel)
        {
            return new CartOrder()
            {
                CartOrderID = cartOrderModel.OrderID,
                OrderNumber = cartOrderModel.OrderNumber,
                ParentCartID = cartOrderModel.ParentCartID,
                BuyerProfileID = cartOrderModel.BuyerProfileID,
                OrderStatusID = cartOrderModel.OrderStatusId,
                StatusID = cartOrderModel.StatusId,
                DeliveryAddressID = cartOrderModel.DeliveryAddressID,
                DeliveryAddress = cartOrderModel.DeliveryAddress,
                OrderSupplierId = cartOrderModel.ShopID,
                SupplierDeliveryOptionPairID = cartOrderModel.DeliveryOptionID,
                OrderTotal = cartOrderModel.OrderTotal,
                TaxTotal = cartOrderModel.TaxTotal,
                DeliveryTotal = cartOrderModel.DeliveryTotal,
                DiscountTotal = cartOrderModel.DiscountTotal,
                PaymentTotal = cartOrderModel.PaymentTotal,
                CalculatedPayout = cartOrderModel.CalculatedPayout,
                ActualPayout = cartOrderModel.ActualPayout,
                CalculatedPayIn = cartOrderModel.CalculatedPayIn,
                ActualPayIn = cartOrderModel.ActualPayIn,
            };
        }
        
        protected override OrderModel GetModel(CartOrder cartOrder)
        {
            return GetModelWithConcurrency(cartOrder, new OrderModel
            {
                OrderID = cartOrder.CartOrderID,
                OrderNumber = cartOrder.OrderNumber,
                ParentCartID = cartOrder.ParentCartID,
                BuyerProfileID = cartOrder.BuyerProfileID,
                OrderStatusId = cartOrder.OrderStatusID,
                StatusId = cartOrder.StatusID,
                DeliveryAddressID = cartOrder.DeliveryAddressID,
                DeliveryAddress = cartOrder.DeliveryAddress,
                ShopID = cartOrder.OrderSupplierId,
                DeliveryOptionID = cartOrder.SupplierDeliveryOptionPairID.HasValue ? cartOrder.SupplierDeliveryOptionPairID.Value : -1,
                OrderTotal = cartOrder.OrderTotal,
                TaxTotal = cartOrder.TaxTotal,
                DeliveryTotal = cartOrder.DeliveryTotal,
                DiscountTotal = cartOrder.DiscountTotal,
                PaymentTotal = cartOrder.PaymentTotal,
                CalculatedPayout = cartOrder.CalculatedPayout,
                ActualPayout = cartOrder.ActualPayout,
                CalculatedPayIn = cartOrder.CalculatedPayIn,
                ActualPayIn = cartOrder.ActualPayIn,
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.CartOrderID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class CategoryAdapter : BaseAdapter<Category, CategoryModel>
    {
        protected override OMSRepositoryBase<Category> Repo
        {
            get
            {
                return this.uow.CategoryRepository;
            }
        }

        protected override Category GetEntity(CategoryModel categoryModel)
        {
            return new Category()
            {
                CategoryID = categoryModel.CategoryID,
                CategoryTitle = categoryModel.CategoryTitle,
                CategoryParentID = categoryModel.CategoryParentID,
                CategoryTypeID = categoryModel.CategoryTypeID,
                Description = categoryModel.Description,
                IsSystem = categoryModel.IsSystem,
                LogoPath = categoryModel.LogoPath,
                StatusID = categoryModel.StatusID
            };
        }

        protected override CategoryModel GetModel(Category category)
        {
            return GetModelWithConcurrency(category, new CategoryModel
            {
                CategoryID = category.CategoryID,
                CategoryTitle = category.CategoryTitle,
                CategoryParentID = category.CategoryParentID,
                CategoryTypeID = category.CategoryTypeID,
                Description = category.Description,
                IsSystem = category.IsSystem,
                LogoPath = category.LogoPath,
                StatusID = category.StatusID
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.CategoryID == Id);
                return uow.Commit() > 0;
            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class CategoryAttributePairAdapter : BaseAdapter<CategoryAttributePair, CategoryAttributePairModel>
    {
        protected override OMSRepositoryBase<CategoryAttributePair> Repo
        {
            get
            {
                return this.uow.CategoryAttributePairRepository;
            }
        }

        protected override CategoryAttributePair GetEntity(CategoryAttributePairModel categoryAttributePairModel)
        {
            return new CategoryAttributePair()
            {
                AttributeID = categoryAttributePairModel.AttributeID,
                CategoryAttributePairID = categoryAttributePairModel.CategoryAttributePairID,
                CategoryID = categoryAttributePairModel.CategoryID,
                AttributeValue = categoryAttributePairModel.AttributeValue,
                DisplayOrder = categoryAttributePairModel.DisplayOrder,
                IsAssigned = categoryAttributePairModel.IsAssigned
            };
        }

        protected override CategoryAttributePairModel GetModel(CategoryAttributePair categoryAttributePair)
        {
            return new CategoryAttributePairModel
            {
                AttributeID = categoryAttributePair.AttributeID,
                CategoryAttributePairID = categoryAttributePair.CategoryAttributePairID,
                CategoryID = categoryAttributePair.CategoryID,
                AttributeValue = categoryAttributePair.AttributeValue,
                DisplayOrder = categoryAttributePair.DisplayOrder,
                IsAssigned = categoryAttributePair.IsAssigned
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.CategoryAttributePairID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }
    public partial class CategoryTypeAdapter : BaseAdapter<CategoryType, CategoryTypeModel>
    {
        protected override OMSRepositoryBase<CategoryType> Repo
        {
            get
            {
                return this.uow.CategoryTypeRepository;
            }
        }

        protected override CategoryType GetEntity(CategoryTypeModel categoryTypeModel)
        {
            return new CategoryType()
            {
                CategoryTypeID = categoryTypeModel.CategoryTypeID,
                Description = categoryTypeModel.Description,
                StatusID = categoryTypeModel.StatusID,
                Title = categoryTypeModel.Title,
                IsSystem = categoryTypeModel.IsSystem
            };
        }

        protected override CategoryTypeModel GetModel(CategoryType categoryType)
        {
            return new CategoryTypeModel
            {
                CategoryTypeID = categoryType.CategoryTypeID,
                Description = categoryType.Description,
                StatusID = categoryType.StatusID,
                Title = categoryType.Title,
                IsSystem = categoryType.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.CategoryTypeID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }
    public partial class CustomerReviewAdapter : BaseAdapter<oms.CustomerReview, CustomerReviewModel>
    {
        protected override OMSRepositoryBase<oms.CustomerReview> Repo
        {
            get
            {
                return this.uow.CustomerReviewRepository;
            }
        }

        protected override oms.CustomerReview GetEntity(CustomerReviewModel customerReviewModel)
        {
            return new oms.CustomerReview()
            {
                CustomerReviewID = customerReviewModel.CustomerReviewID,
                SubjectID = customerReviewModel.SubjectID,
                SubjectRowID = customerReviewModel.SubjectRowID,
                ReviewText = customerReviewModel.ReviewText,
                Rating = customerReviewModel.Rating,
                StatusID = customerReviewModel.StatusID,
                LastModifiedDateTime = customerReviewModel.ModifiedOn,
                CreatedDateTime = customerReviewModel.CreatedOn,
                CreatedByUserID = customerReviewModel.CreatedBy,
                LastModifiedByUserID = customerReviewModel.ModifiedBy,
            };
        }

        protected override CustomerReviewModel GetModel(oms.CustomerReview customerReview)
        {
            return GetModelWithConcurrency(customerReview, new CustomerReviewModel
            {
                CustomerReviewID = customerReview.CustomerReviewID,
                SubjectID = customerReview.SubjectID,
                SubjectRowID = customerReview.SubjectRowID,
                ReviewText = customerReview.ReviewText,
                Rating = customerReview.Rating,
                StatusID = customerReview.StatusID,
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.CustomerReviewID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class DataTypeAdapter : BaseAdapter<DataType, DataTypeModel>
    {
        protected override OMSRepositoryBase<DataType> Repo
        {
            get
            {
                return this.uow.DataTypeRepository;
            }
        }

        protected override DataType GetEntity(DataTypeModel dataTypeModel)
        {
            return new DataType()
            {
                DataTypeID = dataTypeModel.DataTypeID,
                AssemblyName = dataTypeModel.AssemblyName,
                ClassName = dataTypeModel.ClassName,
                FriendlyName = dataTypeModel.FriendlyName,
                Namespace = dataTypeModel.Namespace,
                IsSystem = dataTypeModel.IsSystem,
                SuggestedUIControl = dataTypeModel.SuggestedUIControl
            };
        }

        protected override DataTypeModel GetModel(DataType dataType)
        {
            return new DataTypeModel
            {
                DataTypeID = dataType.DataTypeID,
                AssemblyName = dataType.AssemblyName,
                ClassName = dataType.ClassName,
                FriendlyName = dataType.FriendlyName,
                Namespace = dataType.Namespace,
                IsSystem = dataType.IsSystem,
                SuggestedUIControl = dataType.SuggestedUIControl
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.DataTypeID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class DeliveryOptionAdapter : BaseAdapter<DeliveryOption, DeliveryOptionModel>
    {
        protected override OMSRepositoryBase<DeliveryOption> Repo
        {
            get
            {
                return this.uow.DeliveryOptionRepository;
            }
        }

        protected override DeliveryOption GetEntity(DeliveryOptionModel deliveryOptionModel)
        {
            return new DeliveryOption()
            {
                DeliveryOptionID = deliveryOptionModel.DeliveryOptionID,
                DeliveryOptionTitle = deliveryOptionModel.DeliveryOptionTitle,
                Description = deliveryOptionModel.Description
            };
        }

        protected override DeliveryOptionModel GetModel(DeliveryOption deliveryOption)
        {
            return new DeliveryOptionModel
            {
                DeliveryOptionID = deliveryOption.DeliveryOptionID,
                DeliveryOptionTitle = deliveryOption.DeliveryOptionTitle,
                Description = deliveryOption.Description
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.DeliveryOptionID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class ExecActionAdapter : BaseAdapter<ExecAction, ExecActionModel>
    {
        protected override OMSRepositoryBase<ExecAction> Repo
        {
            get
            {
                return this.uow.ExecActionRepository;
            }
        }

        protected override ExecAction GetEntity(ExecActionModel execActionModel)
        {
            return new ExecAction()
            {
                DataTypeID = execActionModel.DataTypeID,
                ExecActionID = execActionModel.ExecActionID,
                Method = execActionModel.Method
            };
        }

        protected override ExecActionModel GetModel(ExecAction execAction)
        {
            return new ExecActionModel
            {
                DataTypeID = execAction.DataTypeID,
                ExecActionID = execAction.ExecActionID,
                Method = execAction.Method
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ExecActionID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class ExecActionParamAdapter : BaseAdapter<ExecActionParam, ExecActionParamModel>
    {
        protected override OMSRepositoryBase<ExecActionParam> Repo
        {
            get
            {
                return this.uow.ExecActionParamRepository;
            }
        }

        protected override ExecActionParam GetEntity(ExecActionParamModel execActionParamModel)
        {
            return new ExecActionParam()
            {
                DataTypeID = execActionParamModel.DataTypeID,
                ExecActionID = execActionParamModel.ExecActionID,
                ExecActionParamID = execActionParamModel.ExecActionParamID,
                ParamName = execActionParamModel.ParamName
            };
        }

        protected override ExecActionParamModel GetModel(ExecActionParam execActionParam)
        {
            return new ExecActionParamModel
            {
                DataTypeID = execActionParam.DataTypeID,
                ExecActionID = execActionParam.ExecActionID,
                ExecActionParamID = execActionParam.ExecActionParamID,
                ParamName = execActionParam.ParamName
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ExecActionParamID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class GroupAdapter : BaseAdapter<Group, GroupModel>
    {
        protected override OMSRepositoryBase<Group> Repo
        {
            get
            {
                return this.uow.GroupRepository;
            }
        }

        protected override Group GetEntity(GroupModel groupModel)
        {
            return new Group()
            {
                GroupID = groupModel.GroupID,
                GroupTitle = groupModel.GroupTitle,
                Description = groupModel.Description,
                IconPath = groupModel.IconPath,
                StatusID = groupModel.StatusID,
                IsSystem = groupModel.IsSystem
            };
        }

        protected override GroupModel GetModel(Group group)
        {
            return new GroupModel
            {
                GroupID = group.GroupID,
                GroupTitle = group.GroupTitle,
                Description = group.Description,
                IconPath = group.IconPath,
                StatusID = group.StatusID,
                IsSystem = group.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.GroupID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class GroupRolePairAdapter : BaseAdapter<GroupRolePair, GroupRolePairModel>
    {
        protected override OMSRepositoryBase<GroupRolePair> Repo
        {
            get
            {
                return this.uow.GroupRolePairRepository;
            }
        }

        protected override GroupRolePair GetEntity(GroupRolePairModel groupRolePairModel)
        {
            return new GroupRolePair()
            {
                GroupID = groupRolePairModel.GroupID,
                GroupRolePairID = groupRolePairModel.GroupRolePairID,
                IsSystem = groupRolePairModel.IsSystem,
                RoleID = groupRolePairModel.RoleID
            };
        }

        protected override GroupRolePairModel GetModel(GroupRolePair groupRolePair)
        {
            return new GroupRolePairModel
            {
                GroupID = groupRolePair.GroupID,
                GroupRolePairID = groupRolePair.GroupRolePairID,
                IsSystem = groupRolePair.IsSystem,
                RoleID = groupRolePair.RoleID
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.GroupRolePairID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class LocationLevelAdapter : BaseAdapter<LocationLevel, LocationLevelModel>
    {
        protected override OMSRepositoryBase<LocationLevel> Repo
        {
            get
            {
                return this.uow.LocationLevelRepository;
            }
        }

        protected override LocationLevel GetEntity(LocationLevelModel locationLevelModel)
        {
            return new LocationLevel()
            {
                Description = locationLevelModel.Description,
                LocationLevelID = locationLevelModel.LocationLevelID,
                LocationLevelTitle = locationLevelModel.LocationLevelTitle
            };
        }

        protected override LocationLevelModel GetModel(LocationLevel locationLevel)
        {
            return new LocationLevelModel
            {
                Description = locationLevel.Description,
                LocationLevelID = locationLevel.LocationLevelID,
                LocationLevelTitle = locationLevel.LocationLevelTitle
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.LocationLevelID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class LocationTreeAdapter : BaseAdapter<LocationTree, LocationTreeModel>
    {
        protected override OMSRepositoryBase<LocationTree> Repo
        {
            get
            {
                return this.uow.LocationTreeRepository;
            }
        }

        protected override LocationTree GetEntity(LocationTreeModel locationTreeModel)
        {
            return new LocationTree()
            {
                LocationID = locationTreeModel.LocationID,
                LocationLevelID = locationTreeModel.LocationLevelID,
                LocationTitle = locationTreeModel.LocationTitle,
                ParentLocationID = locationTreeModel.ParentLocationID,
                Description = locationTreeModel.Description
            };
        }

        protected override LocationTreeModel GetModel(LocationTree locationTree)
        {
            return new LocationTreeModel
            {
                LocationID = locationTree.LocationID,
                LocationLevelID = locationTree.LocationLevelID,
                LocationTitle = locationTree.LocationTitle,
                ParentLocationID = locationTree.ParentLocationID,
                Description = locationTree.Description
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.LocationID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class MediaContentTypeAdapter : BaseAdapter<MediaContentType, MediaContentTypeModel>
    {
        protected override OMSRepositoryBase<MediaContentType> Repo
        {
            get
            {
                return this.uow.MediaContentTypeRepository;
            }
        }

        protected override MediaContentType GetEntity(MediaContentTypeModel mediaContentTypeModel)
        {
            return new MediaContentType()
            {
                MediaContentTypeID = mediaContentTypeModel.MediaContentTypeID,
                DisplayText = mediaContentTypeModel.DisplayText,
                Description = mediaContentTypeModel.Description,
                HTMLContentTypeText = mediaContentTypeModel.HTMLContentTypeText,
                IconPath = mediaContentTypeModel.IconPath,
                IsSystem = mediaContentTypeModel.IsSystem
            };
        }

        protected override MediaContentTypeModel GetModel(MediaContentType mediaContentType)
        {
            return new MediaContentTypeModel
            {
                MediaContentTypeID = mediaContentType.MediaContentTypeID,
                DisplayText = mediaContentType.DisplayText,
                Description = mediaContentType.Description,
                HTMLContentTypeText = mediaContentType.HTMLContentTypeText,
                IconPath = mediaContentType.IconPath,
                IsSystem = mediaContentType.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.MediaContentTypeID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class OptionAdapter : BaseAdapter<Option, OptionModel>
    {
        protected override OMSRepositoryBase<Option> Repo
        {
            get
            {
                return this.uow.OptionRepository;
            }
        }

        protected override Option GetEntity(OptionModel option)
        {
            return new Option()
            {
                ExecActionID = option.ExecActionID,
                ModuleID = option.ModuleID,
                ItemTitle = option.ItemTitle,
                MenuTitle = option.MenuTitle,
                StatusID = option.StatusID,
                ParentOptionID = option.ParentOptionID,
                DisplayOrder = option.DisplayOrder,
                OptionID = option.OptionID,
                OptionTitle = option.OptionTitle,
                OptionTypeID = option.OptionTypeID,
                NextPageURL = option.NextPageURL,
                PageURL = option.PageURL
            };
        }

        protected override OptionModel GetModel(Option option)
        {
            return GetModelWithConcurrency(option, new OptionModel
            {
                ExecActionID = option.ExecActionID,
                ModuleID = option.ModuleID,
                ItemTitle = option.ItemTitle,
                MenuTitle = option.MenuTitle,
                StatusID = option.StatusID,
                ParentOptionID = option.ParentOptionID,
                DisplayOrder = option.DisplayOrder,
                OptionID = option.OptionID,
                OptionTitle = option.OptionTitle,
                OptionTypeID = option.OptionTypeID,
                NextPageURL = option.NextPageURL,
                PageURL = option.PageURL
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.OptionID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class OptionTypeAdapter : BaseAdapter<OptionType, OptionTypeModel>
    {
        protected override OMSRepositoryBase<OptionType> Repo
        {
            get
            {
                return this.uow.OptionTypeRepository;
            }
        }

        protected override OptionType GetEntity(OptionTypeModel optionTypeModel)
        {
            return new OptionType()
            {
                OptionTypeID = optionTypeModel.OptionTypeID,
                OptionTypeTitle = optionTypeModel.OptionTypeTitle,
                OptionLevel = optionTypeModel.OptionLevel,
                Description = optionTypeModel.Description
            };
        }

        protected override OptionTypeModel GetModel(OptionType optionType)
        {
            return new OptionTypeModel
            {
                OptionTypeID = optionType.OptionTypeID,
                OptionTypeTitle = optionType.OptionTypeTitle,
                OptionLevel = optionType.OptionLevel,
                Description = optionType.Description
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.OptionTypeID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class OrderDeliveryDetailAdapter : BaseAdapter<OrderDeliveryDetail, OrderDeliveryDetailModel>
    {
        protected override OMSRepositoryBase<OrderDeliveryDetail> Repo
        {
            get
            {
                return this.uow.OrderDeliveryDetailRepository;
            }
        }

        protected override OrderDeliveryDetail GetEntity(OrderDeliveryDetailModel orderDeliveryDetailModel)
        {
            return new OrderDeliveryDetail()
            {
                CartOrderID = orderDeliveryDetailModel.CartOrderID,
                //DeliveryProductID = orderDeliveryDetailModel.DeliveryProductID,
                DeliveryAddressID = orderDeliveryDetailModel.DeliveryAddressID,
                OrderDeliveryDetailID = orderDeliveryDetailModel.OrderDeliveryDetailID
            };
        }

        protected override OrderDeliveryDetailModel GetModel(OrderDeliveryDetail orderDeliveryDetail)
        {
            return new OrderDeliveryDetailModel
            {
                CartOrderID = orderDeliveryDetail.CartOrderID,
                DeliveryAddressID = orderDeliveryDetail.DeliveryAddressID,
                //DeliveryProductID = orderDeliveryDetail.DeliveryProductID,
                OrderDeliveryDetailID = orderDeliveryDetail.OrderDeliveryDetailID
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.OrderDeliveryDetailID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class OrderPaymentAdapter : BaseAdapter<OrderPayment, OrderPaymentModel>
    {
        protected override OMSRepositoryBase<OrderPayment> Repo
        {
            get
            {
                return this.uow.OrderPaymentRepository;
            }
        }

        protected override OrderPayment GetEntity(OrderPaymentModel orderPaymentModel)
        {
            return new OrderPayment()
            {
                CartOrderID = orderPaymentModel.CartOrderID,
                PaymentID = orderPaymentModel.PaymentID,
                Amount = orderPaymentModel.Amount,
                BillingAddressID = orderPaymentModel.BillingAddressID,
                OrderPaymentID = orderPaymentModel.OrderPaymentID
                 
                //PaymentGatewayTransactionID = orderPaymentModel.PaymentGatewayTransactionID,
                //PaymentToken = orderPaymentModel.PaymentToken,
                //PayModeID = orderPaymentModel.PayModeID,
                //PayTypeID = orderPaymentModel.PayTypeID
            };
        }

        protected override OrderPaymentModel GetModel(OrderPayment orderPayment)
        {
            return new OrderPaymentModel
            {
                CartOrderID = orderPayment.CartOrderID,
                PaymentID = orderPayment.PaymentID,
                Amount = orderPayment.Amount,
                BillingAddressID = orderPayment.BillingAddressID,
                OrderPaymentID = orderPayment.OrderPaymentID
                //RequestedByProfileId = orderPayment.req
                //PaymentGatewayTransactionID = orderPayment.PaymentGatewayTransactionID,
                //PaymentToken = orderPayment.PaymentToken,
                //PayModeID = orderPayment.PayModeID,
                //PayTypeID = orderPayment.PayTypeID
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.PaymentID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class OrderStatusAdapter : BaseAdapter<OrderStatus, OrderStatusModel>
    {
        protected override OMSRepositoryBase<OrderStatus> Repo
        {
            get
            {
                return this.uow.OrderStatusRepository;
            }
        }

        protected override OrderStatus GetEntity(OrderStatusModel orderStatusModel)
        {
            return new OrderStatus()
            {
                OrderStatusID = orderStatusModel.OrderStatusID,
                OrderStatusTitle = orderStatusModel.OrderStatusTitle,
                Description = orderStatusModel.Description,
                IsSystem = orderStatusModel.IsSystem,
                IsOrder = orderStatusModel.IsOrder
            };
        }

        protected override OrderStatusModel GetModel(OrderStatus orderStatus)
        {
            return new OrderStatusModel
            {
                OrderStatusID = orderStatus.OrderStatusID,
                OrderStatusTitle = orderStatus.OrderStatusTitle,
                Description = orderStatus.Description,
                IsSystem = orderStatus.IsSystem,
                IsOrder = orderStatus.IsOrder
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.OrderStatusID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class PackagedProductAdapter : BaseAdapter<PackagedProduct, PackagedProductModel>
    {
        protected override OMSRepositoryBase<PackagedProduct> Repo
        {
            get
            {
                return this.uow.PackagedProductRepository;
            }
        }

        protected override PackagedProduct GetEntity(PackagedProductModel packagedProductModel)
        {
            return new PackagedProduct()
            {
                ProductID = packagedProductModel.ProductID,
                PackageID = packagedProductModel.PackageID,
                ChildProductID = packagedProductModel.ChildProductID,
                IncludedByDefault = packagedProductModel.IncludedByDefault,
                OtherDetails = packagedProductModel.OtherDetails,
                PercentagePrice = packagedProductModel.PercentagePrice,
                Quantity = packagedProductModel.Quantity
            };
        }

        protected override PackagedProductModel GetModel(PackagedProduct packagedProduct)
        {
            return new PackagedProductModel
            {
                ProductID = packagedProduct.ProductID,
                PackageID = packagedProduct.PackageID,
                ChildProductTitle = packagedProduct.Product1.ProductTitle,
                ProductTitle = packagedProduct.Product.ProductTitle,
                ChildProductID = packagedProduct.ChildProductID,
                IncludedByDefault = packagedProduct.IncludedByDefault,
                OtherDetails = packagedProduct.OtherDetails,
                PercentagePrice = packagedProduct.PercentagePrice,
                Quantity = packagedProduct.Quantity
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.PackageID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class PayModeAdapter : BaseAdapter<PayMode, PayModeModel>
    {
        protected override OMSRepositoryBase<PayMode> Repo
        {
            get
            {
                return this.uow.PayModeRepository;
            }
        }

        protected override PayMode GetEntity(PayModeModel payModeModel)
        {
            return new PayMode()
            {
                PayModeID = payModeModel.PayModeID,
                PayModeTitle = payModeModel.PayModeTitle,
                Description = payModeModel.Description,
                IsSystem = payModeModel.IsSystem
            };
        }

        protected override PayModeModel GetModel(PayMode payMode)
        {
            return new PayModeModel
            {
                PayModeID = payMode.PayModeID,
                PayModeTitle = payMode.PayModeTitle,
                Description = payMode.Description,
                IsSystem = payMode.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.PayModeID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class PayTypeAdapter : BaseAdapter<PayType, PayTypeModel>
    {
        protected override OMSRepositoryBase<PayType> Repo
        {
            get
            {
                return this.uow.PayTypeRepository;
            }
        }

        protected override PayType GetEntity(PayTypeModel payTypeModel)
        {
            return new PayType()
            {
                PayTypeID = payTypeModel.PayTypeID,
                PayTypeTitle = payTypeModel.PayTypeTitle,
                Description = payTypeModel.Description,
                StatusID = payTypeModel.StatusID,
                IsSystem = payTypeModel.IsSystem
            };
        }

        protected override PayTypeModel GetModel(PayType payType)
        {
            return new PayTypeModel
            {
                PayTypeID = payType.PayTypeID,
                PayTypeTitle = payType.PayTypeTitle,
                Description = payType.Description,
                StatusID = payType.StatusID,
                IsSystem = payType.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.PayTypeID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class ProductAdapter : BaseAdapter<Product, ProductModel>
    {
        protected override OMSRepositoryBase<Product> Repo
        {
            get
            {
                return this.uow.ProductRepository;
            }
        }

        protected override Product GetEntity(ProductModel productModel)
        {
            return new Product()
            {
                ProductID = productModel.ProductID,
                ProductTitle = productModel.ProductTitle,
                BrifeDescription = productModel.BrifeDescription,
                ProductActualImagePath = productModel.ProductActualImagePath,
                ProductImagePath = productModel.ProductImagePath,
                StockCount = productModel.StockCount,
                WebLink = productModel.WebLink,
                BasePrice = productModel.BasePrice,
                DiscountValue = productModel.DiscountValue,
                IsDiscountPercentage = productModel.IsDiscountPercentage,
                SellingPrice = productModel.SellingPrice,
                OrderResponseTime = productModel.OrderResponseTime,
                OrderResponseTimeUnitID = productModel.OrderResponseTimeUnitID,
                //DeliveryChargesByZvonr = productModel.DeliveryChargesByZvonr,
                //DeliveryChargesByShop = productModel.DeliveryChargesByShop,
                TaxTypeID = productModel.TaxTypeID,
                UserRating = productModel.UserRating,
                AnalysisRank = productModel.AnalysisRank,
                Description = productModel.Description,
                ProductTypeID = productModel.ProductTypeID,
                BrandID = productModel.BrandID,
                SupplierID = productModel.SupplierID,
                StatusID = productModel.StatusID
            };
        }

        protected override ProductModel GetModel(Product product)
        {
            return GetModelWithConcurrency(product, new ProductModel
            {
                ProductID = product.ProductID,
                ProductTitle = product.ProductTitle,
                BrifeDescription = product.BrifeDescription,
                ProductActualImagePath = product.ProductActualImagePath,
                ProductImagePath = product.ProductImagePath,
                StockCount = product.StockCount ?? 0,
                WebLink = product.WebLink,
                BasePrice = product.BasePrice ?? 0,
                DiscountValue = product.DiscountValue,
                IsDiscountPercentage = product.IsDiscountPercentage.HasValue ? product.IsDiscountPercentage.Value : false,
                SellingPrice = product.SellingPrice ?? 0,
                OrderResponseTime = product.OrderResponseTime,
                OrderResponseTimeUnitID = product.OrderResponseTimeUnitID,
                //DeliveryChargesByZvonr = product.DeliveryChargesByZvonr,
                //DeliveryChargesByShop = product.DeliveryChargesByShop,
                TaxTypeID = product.TaxTypeID,
                UserRating = product.UserRating ?? 0,
                AnalysisRank = product.AnalysisRank ?? 0,
                Description = product.Description,
                ProductTypeID = product.ProductTypeID,
                BrandID = product.BrandID,
                SupplierID = product.SupplierID,
                BrandName = product.Brand.BrandName,
                ProductTypeName = product.ProductType.ProductTypeTitle,
                //StatusName = product.StatusID.ToString(),
                SupplierName = product.Supplier.SupplierName,
                StatusID = product.StatusID,
                CreatedBy = product.CreatedByUserID,
                CreatedOn = product.CreatedDateTime,
                ModifiedBy = product.LastModifiedByUserID,//.HasValue ? product.LastModifiedByUserID.Value : -1,
                ModifiedOn = product.LastModifiedDateTime,//.HasValue ? product.LastModifiedDateTime.Value : DateTime.Now,
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ProductID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class ProductAttributePairAdapter : BaseAdapter<ProductAttributePair, ProductAttributePairModel>
    {
        protected override OMSRepositoryBase<ProductAttributePair> Repo
        {
            get
            {
                return this.uow.ProductAttributePairRepository;
            }
        }

        protected override ProductAttributePair GetEntity(ProductAttributePairModel productAttributePairModel)
        {
            return new ProductAttributePair()
            {
                ProductAttributePairID = productAttributePairModel.ProductAttributePairID,
                ProductID = productAttributePairModel.ProductID,
                AttributeID = productAttributePairModel.AttributeID,
                AttributeValue = productAttributePairModel.AttributeValue,
                DisplayOrder = productAttributePairModel.DisplayOrder,
                IsAssigned = productAttributePairModel.IsAssigned,
                IsSelectedForVariation = productAttributePairModel.IsSelectedForVariation,
                VariationInPrice = productAttributePairModel.VariationInPrice
            };
        }

        protected override ProductAttributePairModel GetModel(ProductAttributePair productAttributePair)
        {
            return new ProductAttributePairModel
            {
                ProductAttributePairID = productAttributePair.ProductAttributePairID,
                ProductID = productAttributePair.ProductID,
                AttributeID = productAttributePair.AttributeID,
                AttributeValue = productAttributePair.AttributeValue,
                DisplayOrder = productAttributePair.DisplayOrder ?? 0,
                IsAssigned = productAttributePair.IsAssigned,
                IsSelectedForVariation = productAttributePair.IsSelectedForVariation,
                VariationInPrice = productAttributePair.VariationInPrice

            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ProductAttributePairID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class ProductMediaDetailAdapter : BaseAdapter<ProductMediaDetail, ProductMediaDetailModel>
    {
        protected override OMSRepositoryBase<ProductMediaDetail> Repo
        {
            get
            {
                return this.uow.ProductMediaDetailRepository;
            }
        }

        protected override ProductMediaDetail GetEntity(ProductMediaDetailModel productMediaDetail)
        {
            return new ProductMediaDetail()
            {
                ProductMediaID = productMediaDetail.ProductMediaID,
                ProductMediaTitle = productMediaDetail.ProductMediaTitle,
                Description = productMediaDetail.Description,
                MediaContentTypeID = productMediaDetail.MediaContentTypeID,
                MediaFilePath = productMediaDetail.MediaFilePath,
                ProductID = productMediaDetail.ProductID,
                Width = productMediaDetail.Width,
                Height = productMediaDetail.Height,
                TransparencyLevel = productMediaDetail.TransparencyLevel,
                StatusID = productMediaDetail.StatusID,
                ApprovedByUserID = productMediaDetail.ApprovedByUserID,
                ApprovedDateTime = productMediaDetail.ApprovedDateTime
            };
        }

        protected override ProductMediaDetailModel GetModel(ProductMediaDetail productMediaDetail)
        {
            return GetModelWithConcurrency(productMediaDetail, new ProductMediaDetailModel
            {
                ProductMediaID = productMediaDetail.ProductMediaID,
                ProductMediaTitle = productMediaDetail.ProductMediaTitle,
                Description = productMediaDetail.Description,
                MediaContentTypeID = productMediaDetail.MediaContentTypeID,
                MediaFilePath = productMediaDetail.MediaFilePath,
                ProductID = productMediaDetail.ProductID,
                Width = productMediaDetail.Width ?? 0,
                Height = productMediaDetail.Height ?? 0,
                TransparencyLevel = productMediaDetail.TransparencyLevel ?? 0,
                StatusID = productMediaDetail.StatusID,
                ApprovedByUserID = productMediaDetail.ApprovedByUserID,
                ApprovedDateTime = productMediaDetail.ApprovedDateTime
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ProductMediaID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class ProductTypeAdapter : BaseAdapter<ProductType, ProductTypeModel>
    {
        protected override OMSRepositoryBase<ProductType> Repo
        {
            get
            {
                return this.uow.ProductTypeRepository;
            }
        }

        protected override ProductType GetEntity(ProductTypeModel productTypeModel)
        {
            return new ProductType()
            {
                ProductTypeID = productTypeModel.ProductTypeID,
                ProductTypeTitle = productTypeModel.ProductTypeTitle,
                ProductTypeDescription = productTypeModel.ProductTypeDescription,
                StatusID = productTypeModel.StatusID,
                //ApprovedByUserID = productTypeModel.ApprovedByUserID,
                //ApprovedDateTime = productTypeModel.ApprovedDateTime,
                IsSystem = productTypeModel.IsSystem
            };
        }

        protected override ProductTypeModel GetModel(ProductType productType)
        {
            return GetModelWithConcurrency(productType, new ProductTypeModel
            {
                ProductTypeID = productType.ProductTypeID,
                ProductTypeTitle = productType.ProductTypeTitle,
                ProductTypeDescription = productType.ProductTypeDescription,
                StatusID = productType.StatusID,
                //ApprovedByUserID = productType.ApprovedByUserID,
                //ApprovedDateTime = productType.ApprovedDateTime,
                IsSystem = productType.IsSystem
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ProductTypeID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class ProductViewAdapter : BaseAdapter<ProductView, ProductViewModel>
    {
        protected override OMSRepositoryBase<ProductView> Repo
        {
            get
            {
                return this.uow.ProductViewRepository;
            }
        }

        protected override ProductView GetEntity(ProductViewModel productViewModel)
        {
            return new ProductView()
            {
                ProductViewID = productViewModel.ProductViewID,
                ProductViewTitle = productViewModel.ProductViewTitle,
                Description = productViewModel.Description,
                StatusID = productViewModel.StatusID,
                IsSystem = productViewModel.IsSystem
            };
        }

        protected override ProductViewModel GetModel(ProductView productView)
        {
            return new ProductViewModel
            {
                ProductViewID = productView.ProductViewID,
                ProductViewTitle = productView.ProductViewTitle,
                Description = productView.Description,
                StatusID = productView.StatusID,
                IsSystem = productView.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ProductViewID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class ProductViewItemAdapter : BaseAdapter<ProductViewItem, ProductViewItemModel>
    {
        protected override OMSRepositoryBase<ProductViewItem> Repo
        {
            get
            {
                return this.uow.ProductViewItemRepository;
            }
        }

        protected override ProductViewItem GetEntity(ProductViewItemModel productViewItemModel)
        {
            return new ProductViewItem()
            {
                ProductViewProductID = productViewItemModel.ProductViewProductID,
                ProductViewID = productViewItemModel.ProductViewID,
                ProductID = productViewItemModel.ProductID,
                ProductMediaID = productViewItemModel.ProductMediaID
            };
        }

        protected override ProductViewItemModel GetModel(ProductViewItem productViewItem)
        {
            return new ProductViewItemModel
            {
                ProductViewProductID = productViewItem.ProductViewProductID,
                ProductViewID = productViewItem.ProductViewID,
                ProductID = productViewItem.ProductID,
                ProductMediaID = productViewItem.ProductMediaID
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ProductViewProductID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class ProfileAdapter : BaseAdapter<Profile, ProfileModel>
    {
        protected override OMSRepositoryBase<Profile> Repo
        {
            get
            {
                return this.uow.ProfileRepository;
            }
        }

        protected override Profile GetEntity(ProfileModel profileModel)
        {
            return new Profile()
            {
                ProfileID = profileModel.ProfileID,
                UserID = profileModel.UserID,
                FirstName = profileModel.FirstName,
                MiddleName = profileModel.MiddleName,
                LastName = profileModel.LastName,
                FatherName = profileModel.FatherName,
                Nationality = profileModel.Nationality,
                Occupation = profileModel.Occupation,
                Education = profileModel.Education,
                ImagePath = profileModel.ImagePath,
                IsVerified = profileModel.IsVerified,
                UserTypeID = profileModel.UserTypeID,
                SMS_2FA = profileModel.SMS_2FA,
                EMail_2FA = profileModel.EMail_2FA
            };
        }
        protected Profile GetEntity(ProfileModel_2FA profileModel)
        {
            return new Profile()
            {
                ProfileID = profileModel.ProfileID,                
                SMS_2FA = profileModel.SMS_2FA,
                EMail_2FA = profileModel.EMail_2FA
            };
        }

        protected override ProfileModel GetModel(Profile profile)
        {
            if (profile == null) return null;
            return new ProfileModel
            {
                ProfileID = profile.ProfileID,
                UserID = profile.UserID,
                FirstName = profile.FirstName,
                MiddleName = profile.MiddleName,
                LastName = profile.LastName,
                FatherName = profile.FatherName,
                Nationality = profile.Nationality,
                Occupation = profile.Occupation,
                Education = profile.Education,
                ImagePath = profile.ImagePath,
                IsVerified = (profile.IsVerified.HasValue ? profile.IsVerified.Value : false),
                UserTypeID = profile.UserTypeID.HasValue ? profile.UserTypeID.Value : (int)DBUserTypeEnum.Anonymous,
                SMS_2FA = profile.SMS_2FA,
                EMail_2FA = profile.EMail_2FA,
                CreatedOn = profile.CreatedOn,
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ProfileID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }
    public partial class ProfileVerificationAdapter : BaseAdapter<ProfileVerification, ProfileVerificationModel>
    {
        protected override OMSRepositoryBase<ProfileVerification> Repo
        {
            get
            {
                return this.uow.ProfileVerificationRepository;
            }
        }

        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ProfileID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        protected override ProfileVerification GetEntity(ProfileVerificationModel model)
        {
            return new ProfileVerification
            {
                VerificationID = model.VerificationID,
                DocumentTypeID = model.DocumentTypeID,
                VerifiedBy = model.VerifiedBy,
                VerifiedOn = model.VerifiedOn,
                Comments = model.Comments,
                VerificationStatusID = model.VerificationStatusID,
                ProfileID = model.ProfileID,
                DocumentNumberByUser = model.DocumentNumberByUser,
                DocumentNumberByVerifier = model.DocumentNumberByVerifier,
                DocumentImagePath = model.DocumentImagePath,
            };
        }

        protected override ProfileVerificationModel GetModel(ProfileVerification entity)
        {
            return new ProfileVerificationModel
            {
                VerificationID = entity.VerificationID,
                DocumentTypeID = entity.DocumentTypeID,
                VerifiedBy = entity.VerifiedBy,
                VerifiedOn = entity.VerifiedOn,
                Comments = entity.Comments,
                VerificationStatusID = entity.VerificationStatusID,
                ProfileID = entity.ProfileID,
                DocumentNumberByUser = entity.DocumentNumberByUser,
                DocumentNumberByVerifier = entity.DocumentNumberByVerifier,
                DocumentImagePath = entity.DocumentImagePath,

            };
        }
    }

    public partial class RoleAdapter : BaseAdapter<Role, RoleModel>
    {
        protected override OMSRepositoryBase<Role> Repo
        {
            get
            {
                return this.uow.RoleRepository;
            }
        }

        protected override Role GetEntity(RoleModel roleModel)
        {
            return new Role()
            {
                RoleID = roleModel.RoleID,
                RoleTitle = roleModel.RoleTitle,
                Description = roleModel.Description,
                IconPath = roleModel.IconPath,
                StatusID = roleModel.StatusID,
                IsSystem = roleModel.IsSystem
            };
        }

        protected override RoleModel GetModel(Role role)
        {
            return new RoleModel
            {
                RoleID = role.RoleID,
                RoleTitle = role.RoleTitle,
                Description = role.Description,
                IconPath = role.IconPath,
                StatusID = role.StatusID,
                IsSystem = role.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.RoleID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class RoleOptionPairAdapter : BaseAdapter<RoleOptionPair, RoleOptionPairModel>
    {
        protected override OMSRepositoryBase<RoleOptionPair> Repo
        {
            get
            {
                return this.uow.RoleOptionPairRepository;
            }
        }

        protected override RoleOptionPair GetEntity(RoleOptionPairModel roleOptionPairModel)
        {
            return new RoleOptionPair()
            {
                RoleOptionPairID = roleOptionPairModel.RoleOptionPairID,
                OptionID = roleOptionPairModel.OptionID,
                RoleID = roleOptionPairModel.RoleID,
                IsAssigned = roleOptionPairModel.IsAssigned,
                IsSystem = roleOptionPairModel.IsSystem,
                StatusID = roleOptionPairModel.StatusID,
            };
        }

        protected override RoleOptionPairModel GetModel(RoleOptionPair roleOptionPair)
        {
            return GetModelWithConcurrency(roleOptionPair, new RoleOptionPairModel
            {
                RoleOptionPairID = roleOptionPair.RoleOptionPairID,
                OptionID = roleOptionPair.OptionID,
                RoleID = roleOptionPair.RoleID,
                IsAssigned = roleOptionPair.IsAssigned,
                IsSystem = roleOptionPair.IsSystem,
                StatusID = roleOptionPair.StatusID,
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.RoleOptionPairID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class StateMachineAdapter : BaseAdapter<StateMachine, StateMachineModel>
    {
        protected override OMSRepositoryBase<StateMachine> Repo
        {
            get
            {
                return this.uow.StateMachineRepository;
            }
        }

        protected override StateMachine GetEntity(StateMachineModel stateMachineModel)
        {
            return new StateMachine()
            {
                StateMachineID = stateMachineModel.StateMachineID,
                StartStateID = stateMachineModel.StartStateID,
                StateMachineTitle = stateMachineModel.StateMachineTitle,
                StateMachineDescription = stateMachineModel.StateMachineDescription
            };
        }

        protected override StateMachineModel GetModel(StateMachine stateMachine)
        {
            return new StateMachineModel
            {
                StateMachineID = stateMachine.StateMachineID,
                StartStateID = stateMachine.StartStateID,
                StateMachineTitle = stateMachine.StateMachineTitle,
                StateMachineDescription = stateMachine.StateMachineDescription
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.StateMachineID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class StateMachineStateAdapter : BaseAdapter<StateMachineState, StateMachineStateModel>
    {
        protected override OMSRepositoryBase<StateMachineState> Repo
        {
            get
            {
                return this.uow.StateMachineStateRepository;
            }
        }

        protected override StateMachineState GetEntity(StateMachineStateModel StateMachineStateModel)
        {
            return new StateMachineState()
            {
                StateMachineStateID = StateMachineStateModel.StateMachineStateID,
                StateID = StateMachineStateModel.StateID,
                NextStateID = StateMachineStateModel.NextStateID,
                NextInputString = StateMachineStateModel.NextInputString
            };
        }

        protected override StateMachineStateModel GetModel(StateMachineState StateMachineState)
        {
            return new StateMachineStateModel
            {
                StateMachineStateID = StateMachineState.StateMachineStateID,
                StateID = StateMachineState.StateID,
                NextStateID = StateMachineState.NextStateID,
                NextInputString = StateMachineState.NextInputString
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.StateMachineStateID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class StatusAdapter : BaseAdapter<Status, StatusModel>
    {
        protected override OMSRepositoryBase<Status> Repo
        {
            get
            {
                return this.uow.StatusRepository;
            }
        }

        protected override Status GetEntity(StatusModel statusModel)
        {
            return new Status()
            {
                StatusID = statusModel.StatusID,
                StatusName = statusModel.StatusName,
                Description = statusModel.Description,
                IsSystem = statusModel.IsSystem
            };
        }

        protected override StatusModel GetModel(Status status)
        {
            return new StatusModel
            {
                StatusID = status.StatusID,
                StatusName = status.StatusName,
                Description = status.Description,
                IsSystem = status.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.StatusID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }
    public partial class ScheduleAdapter : BaseAdapter<Schedule, ScheduleModel>
    {
        protected override OMSRepositoryBase<Schedule> Repo
        {
            get
            {
                return this.uow.ScheduleRepository;
            }
        }

        protected override Schedule GetEntity(ScheduleModel scheduleModel)
        {
            return new Schedule()
            {
                ScheduleID = scheduleModel.ScheduleID,
                SupplierID = scheduleModel.ShopID,
                ScheduleTypeID = scheduleModel.ScheduleTypeID,
                IsException = scheduleModel.IsException,
                FromDay = scheduleModel.FromDay,
                ToDay = scheduleModel.ToDay,
                Month = scheduleModel.Month,
                MonthDay = scheduleModel.MonthDay,
                WeekDays = scheduleModel.WeekDays,
                StatusID = scheduleModel.StatusID,
                Notes = scheduleModel.Notes,
                CreatedByUserID = scheduleModel.CreatedBy,
                CreatedDateTime = scheduleModel.CreatedOn,
                LastModifiedByUserID = scheduleModel.ModifiedBy,
                LastModifiedDateTime = scheduleModel.ModifiedOn,
            };
        }

        protected override ScheduleModel GetModel(Schedule schedule)
        {
            return new ScheduleModel
            {
                ScheduleID = schedule.ScheduleID,
                ShopID = schedule.SupplierID,
                ScheduleTypeID = schedule.ScheduleTypeID,
                IsException = schedule.IsException,
                FromDay = schedule.FromDay,
                ToDay = schedule.ToDay,
                Month = schedule.Month,
                MonthDay = schedule.MonthDay,
                WeekDays = schedule.WeekDays,
                StatusID = schedule.StatusID,
                Notes = schedule.Notes,
                CreatedBy = schedule.CreatedByUserID,
                CreatedOn = schedule.CreatedDateTime,
                ModifiedBy = schedule.LastModifiedByUserID,
                ModifiedOn = schedule.LastModifiedDateTime,
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ScheduleID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }
    public partial class SupplierAdapter : BaseAdapter<Supplier, SupplierModel>
    {
        protected override OMSRepositoryBase<Supplier> Repo
        {
            get
            {
                return this.uow.SupplierRepository;
            }
        }

        protected override Supplier GetEntity(SupplierModel supplierModel)
        {
            return new Supplier()
            {
                SupplierID = supplierModel.SupplierID,
                SupplierName = supplierModel.SupplierName,
                Logo = supplierModel.Logo,
                Description = supplierModel.Description,
                StatusID = supplierModel.StatusID,
                StatusNotes = supplierModel.StatusNotes,
                BusinessAddressID = supplierModel.BusinessAddressID,
                IsBusinessAddressVisible = supplierModel.IsBusinessAddressVisible,
                LanguageID = supplierModel.OperatingLanguageID,
                CurrencyID = supplierModel.OperatingCurrencyID,
                CountryID = supplierModel.CountryID,
                ProvinceID = supplierModel.ProvinceID,
                CityID = supplierModel.CityID,
                IsCOD = supplierModel.IsCOD,
                ProfileID = supplierModel.ProfileID,
                ProcessingFee = supplierModel.ProcessingFee,
                PaymentGatewayFee = supplierModel.PaymentGatewayFee,
                IsProcessingFeePercentage = supplierModel.IsProcessingFeePercentage,
                IsPaymentGatewayFeePercentage = supplierModel.IsPaymentGatewayFeePercentage,
                LastModifiedDateTime = supplierModel.ModifiedOn,
                AnnouncementHTML = supplierModel.AnnouncementHTML,
                PolicyHTML = supplierModel.PolicyHTML,
                FAQHTML = supplierModel.FAQHTML,
                WebLinksJSON = supplierModel.WebLinksJSON,
                AttributeRequests = supplierModel.AttributeRequests,
                CategoryRequests = supplierModel.CategoryRequests,
            };
        }
        protected Supplier GetEntity(ShopPublicProfileModel supplierModel)
        {
            return new Supplier()
            {
                SupplierID = supplierModel.ShopID,
                SupplierName = supplierModel.ShopName,
                Logo = supplierModel.Logo,
                WebLinksJSON = supplierModel.WebLinksJSON,

                AnnouncementHTML = supplierModel.AnnouncementHTML,
                PolicyHTML = supplierModel.PolicyHTML,
                FAQHTML = supplierModel.FAQHTML,
                StatusID = supplierModel.StatusID
            };
        }

        protected override SupplierModel GetModel(Supplier supplier)
        {
            return new SupplierModel
            {
                SupplierID = supplier.SupplierID,
                SupplierName = supplier.SupplierName,
                Logo = supplier.Logo,
                Description = supplier.Description,
                StatusID = supplier.StatusID,
                StatusNotes = supplier.StatusNotes,
                BusinessAddressID = supplier.BusinessAddressID,
                IsBusinessAddressVisible = supplier.IsBusinessAddressVisible,
                OperatingLanguageID = supplier.LanguageID,
                OperatingCurrencyID = supplier.CurrencyID,
                CountryID = supplier.CountryID.HasValue ? supplier.CountryID.Value : -1,
                ProvinceID = supplier.ProvinceID.HasValue ? supplier.ProvinceID.Value : -1,
                CityID = supplier.CityID.HasValue ? supplier.CityID.Value : -1,
                IsCOD = supplier.IsCOD,
                IsPaymentGatewayFeePercentage = supplier.IsPaymentGatewayFeePercentage,
                IsProcessingFeePercentage = supplier.IsProcessingFeePercentage,
                ProfileID = supplier.ProfileID,
                ProcessingFee = supplier.ProcessingFee,
                PaymentGatewayFee = supplier.PaymentGatewayFee,
                AnnouncementHTML = supplier.AnnouncementHTML,
                PolicyHTML = supplier.PolicyHTML,
                FAQHTML = supplier.FAQHTML,
                WebLinksJSON = supplier.WebLinksJSON,
                AttributeRequests = supplier.AttributeRequests,
                CategoryRequests = supplier.CategoryRequests,
                ModifiedOn = supplier.LastModifiedDateTime,
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.SupplierID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }
    public partial class SupplierDeliveryOptionPairAdapter : BaseAdapter<SupplierDeliveryOptionPair, SupplierDeliveryOptionPairModel>
    {
        protected override OMSRepositoryBase<SupplierDeliveryOptionPair> Repo
        {
            get
            {
                return this.uow.SupplierDeliveryOptionPairRepository;
            }
        }

        protected override SupplierDeliveryOptionPair GetEntity(SupplierDeliveryOptionPairModel supplierDeliveryOptionPairModel)
        {
            return new SupplierDeliveryOptionPair()
            {
                SupplierDeliveryOptionPairID = supplierDeliveryOptionPairModel.SupplierDeliveryOptionPairID,
                SupplierID = supplierDeliveryOptionPairModel.SupplierID,
                DeliveryOptionID = supplierDeliveryOptionPairModel.DeliveryOptionID,
                DeliveryCharges = supplierDeliveryOptionPairModel.DeliveryCharges,
                MinOrderLimit = supplierDeliveryOptionPairModel.MinOrderLimit,
                SurroundingCitiesIDs = supplierDeliveryOptionPairModel.SurroundingCitiesIDs,
                StatusID = supplierDeliveryOptionPairModel.StatusID,

            };
        }

        protected override SupplierDeliveryOptionPairModel GetModel(SupplierDeliveryOptionPair supplierDeliveryOptionPair)
        {
            return new SupplierDeliveryOptionPairModel
            {
                SupplierDeliveryOptionPairID = supplierDeliveryOptionPair.SupplierDeliveryOptionPairID,
                SupplierID = supplierDeliveryOptionPair.SupplierID,
                DeliveryOptionID = supplierDeliveryOptionPair.DeliveryOptionID,
                DeliveryCharges = supplierDeliveryOptionPair.DeliveryCharges,
                MinOrderLimit = supplierDeliveryOptionPair.MinOrderLimit,
                SurroundingCitiesIDs = supplierDeliveryOptionPair.SurroundingCitiesIDs,
                StatusID = supplierDeliveryOptionPair.StatusID,
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.SupplierDeliveryOptionPairID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class TaxAdapter : BaseAdapter<Tax, TaxModel>
    {
        protected override OMSRepositoryBase<Tax> Repo
        {
            get
            {
                return this.uow.TaxRepository;
            }
        }

        protected override Tax GetEntity(TaxModel taxModel)
        {
            return new Tax()
            {
                TaxID = taxModel.TaxID,
                TaxValue = taxModel.TaxValue,
                TaxTypeID = taxModel.TaxTypeID,
                Description = taxModel.Description,
                StatusID = taxModel.StatusID,
                IsPercentage = taxModel.IsPercentage,
                LocationId = taxModel.LocationId,
                LocationLevelId = taxModel.LocationLevelId,
                EffectiveDate = taxModel.EffectiveDate,
                LastModifiedDateTime = taxModel.ModifiedOn,
            };
        }

        protected override TaxModel GetModel(Tax tax)
        {
            return new TaxModel
            {
                TaxID = tax.TaxID,
                TaxValue = tax.TaxValue,
                TaxTypeID = tax.TaxTypeID,
                Description = tax.Description,
                StatusID = tax.StatusID,
                IsPercentage = tax.IsPercentage,
                LocationId = tax.LocationId,
                LocationLevelId = tax.LocationLevelId,
                EffectiveDate = tax.EffectiveDate,
                ModifiedOn = tax.LastModifiedDateTime,
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.TaxID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class TaxTypeAdapter : BaseAdapter<TaxType, TaxTypeModel>
    {
        protected override OMSRepositoryBase<TaxType> Repo
        {
            get
            {
                return this.uow.TaxTypeRepository;
            }
        }

        protected override TaxType GetEntity(TaxTypeModel taxTypeModel)
        {
            return new TaxType()
            {
                TaxTypeID = taxTypeModel.TaxTypeID,
                TaxTypeTitle = taxTypeModel.TaxTypeTitle,
                Description = taxTypeModel.Description,
                IsSystem = taxTypeModel.IsSystem
            };
        }

        protected override TaxTypeModel GetModel(TaxType taxType)
        {
            return new TaxTypeModel
            {
                TaxTypeID = taxType.TaxTypeID,
                TaxTypeTitle = taxType.TaxTypeTitle,
                Description = taxType.Description,
                IsSystem = taxType.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.TaxTypeID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class UserAdapter : BaseAdapter<User, UserModel>
    {
        protected override OMSRepositoryBase<User> Repo
        {
            get
            {
                return this.uow.UserRepository;
            }
        }

        protected override User GetEntity(UserModel userModel)
        {
            return new User()
            {
                UserID = userModel.UserID,
                UserName = userModel.UserName,
                UserPassword = userModel.UserPassword,
                Useremail = userModel.Useremail,
                PasswordResetCode = userModel.PasswordResetCode,
                AcvtivationGUID = userModel.AcvtivationGUID,
                StatusID = userModel.StatusID,
                UserTypeID = (int)userModel.UserType,
                IsLoggedIn = userModel.IsLoggedIn,
                IsSystem = userModel.IsSystem,
                GroupID = userModel.GroupID,
                ApprovedByUserID = userModel.ApprovedByUserID,
                ApprovedDateTime = userModel.ApprovedDateTime
            };
        }

        protected override UserModel GetModel(User user)
        {
            return GetModelWithConcurrency(user, new UserModel
            {
                UserID = user.UserID,
                UserName = user.UserName,
                UserPassword = user.UserPassword,
                Useremail = user.Useremail,
                PasswordResetCode = user.PasswordResetCode,
                AcvtivationGUID = user.AcvtivationGUID,
                StatusID = user.StatusID,
                UserType = (DBUserTypeEnum)Enum.Parse(typeof(DBUserTypeEnum), user.UserTypeID.ToString()),
                IsLoggedIn = user.IsLoggedIn,
                IsSystem = user.IsSystem,
                GroupID = user.GroupID,
                ApprovedByUserID = user.ApprovedByUserID,
                ApprovedDateTime = user.ApprovedDateTime
            });
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.UserID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class UserTypeAdapter : BaseAdapter<UserType, UserTypeModel>
    {
        protected override OMSRepositoryBase<UserType> Repo
        {
            get
            {
                return this.uow.UserTypeRepository;
            }
        }

        protected override UserType GetEntity(UserTypeModel userTypeModel)
        {
            return new UserType()
            {
                UserTypeID = userTypeModel.UserTypeID,
                UserTypeTitle = userTypeModel.UserTypeTitle,
                Description = userTypeModel.Description,
                IsSystem = userTypeModel.IsSystem
            };
        }

        protected override UserTypeModel GetModel(UserType userType)
        {
            return new UserTypeModel
            {
                UserTypeID = userType.UserTypeID,
                UserTypeTitle = userType.UserTypeTitle,
                Description = userType.Description,
                IsSystem = userType.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.UserTypeID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }
    public partial class AttributeTypeAdapter : BaseAdapter<AttributeType, AttributeTypeModel>
    {
        protected override OMSRepositoryBase<AttributeType> Repo
        {
            get
            {
                return this.uow.AttributeTypeRepository;
            }
        }

        protected override AttributeType GetEntity(AttributeTypeModel attributeTypeModel)
        {
            return new AttributeType()
            {
                AttributeTypeTitle = attributeTypeModel.AttributeTypeTitle,
                Description = attributeTypeModel.Description,
                AttributeTypeID = attributeTypeModel.AttributeTypeID,
                
                IsSystem = attributeTypeModel.IsSystem
            };
        }

        protected override AttributeTypeModel GetModel(AttributeType attributeType)
        {
            return new AttributeTypeModel
            {
                AttributeTypeID = attributeType.AttributeTypeID,
                AttributeTypeTitle = attributeType.AttributeTypeTitle,
                Description = attributeType.Description,
                IsSystem = attributeType.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.AttributeTypeID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class DocumentTypeAdapter : BaseAdapter<DocumentType, DocumentTypeModel>
    {
        protected override OMSRepositoryBase<DocumentType> Repo
        {
            get
            {
                return this.uow.DocumentTypeRepository;
            }
        }

        protected override DocumentType GetEntity(DocumentTypeModel documentTypeModel)
        {
            return new DocumentType()
            {
                DocumentTypeID = documentTypeModel.DocumentTypeID,
                DocumentTypeTitle = documentTypeModel.DocumentTypeTitle,
                Description = documentTypeModel.Description,
                IsSystem = documentTypeModel.IsSystem
            };
        }

        protected override DocumentTypeModel GetModel(DocumentType documentType)
        {
            return new DocumentTypeModel
            {
                DocumentTypeID = documentType.DocumentTypeID,
                DocumentTypeTitle = documentType.DocumentTypeTitle,
                Description = documentType.Description,
                IsSystem = documentType.IsSystem
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.DocumentTypeID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class AddressContactInfoPairAdapter : BaseAdapter<AddressContactInfoPair, AddressContactInfoPairModel>
    {
        protected override OMSRepositoryBase<AddressContactInfoPair> Repo
        {
            get
            {
                return this.uow.AddressContactInfoPairRepository;
            }
        }

        protected override AddressContactInfoPair GetEntity(AddressContactInfoPairModel addresscontactinfopair)
        {
            return new AddressContactInfoPair()
            {
                AddressContactInfoPairID = addresscontactinfopair.AddressContactInfoPairID,
                AddressID = addresscontactinfopair.AddressID,
                IsPrimary = addresscontactinfopair.IsPrimary,
                ContactInfoID = addresscontactinfopair.ContactInfoID,
            };
        }

        protected override AddressContactInfoPairModel GetModel(AddressContactInfoPair addresscontactinfopair)
        {
            return new AddressContactInfoPairModel
            {
                AddressContactInfoPairID = addresscontactinfopair.AddressContactInfoPairID,
                AddressID = addresscontactinfopair.AddressID,
                ContactInfoID = addresscontactinfopair.ContactInfoID,
                IsPrimary = addresscontactinfopair.IsPrimary
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.AddressContactInfoPairID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class ContactInfoAdapter : BaseAdapter<ContactInfo, ContactInfoModel>
    {
        protected override OMSRepositoryBase<ContactInfo> Repo
        {
            get
            {
                return this.uow.ContactInfoRepository;
            }
        }

        protected override ContactInfo GetEntity(ContactInfoModel contactinfo)
        {
            return new ContactInfo()
            {
                ContactInfo1 = contactinfo.ContactInfo1,
                ContactInfoID = contactinfo.ContactInfoID,
                ContactPerson = contactinfo.ContactPerson,
                ContactTypeID = contactinfo.ContactTypeID
            };
        }

        protected override ContactInfoModel GetModel(ContactInfo contactinfo)
        {
            return new ContactInfoModel
            {
                ContactInfo1 = contactinfo.ContactInfo1,
                ContactInfoID = contactinfo.ContactInfoID,
                ContactPerson = contactinfo.ContactPerson,
                ContactTypeID = contactinfo.ContactTypeID
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ContactInfoID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class ContactTypeAdapter : BaseAdapter<ContactType, ContactTypeModel>
    {
        protected override OMSRepositoryBase<ContactType> Repo
        {
            get
            {
                return this.uow.ContactTypeRepository;
            }
        }

        protected override ContactType GetEntity(ContactTypeModel contacttype)
        {
            return new ContactType()
            {
                ContactTypeID = contacttype.ContactTypeID,
                Description = contacttype.Description,
                IsSystem = contacttype.IsSystem,
                Title = contacttype.Title
            };
        }

        protected override ContactTypeModel GetModel(ContactType contacttype)
        {
            return new ContactTypeModel
            {
                ContactTypeID = contacttype.ContactTypeID,
                Description = contacttype.Description,
                IsSystem = contacttype.IsSystem,
                Title = contacttype.Title,
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.ContactTypeID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class CountryAdapter : BaseAdapter<Country, CountryModel>
    {
        protected override OMSRepositoryBase<Country> Repo
        {
            get
            {
                return this.uow.CountryRepository;
            }
        }

        protected override Country GetEntity(CountryModel country)
        {
            return new Country()
            {
                AllowsBilling = country.AllowsBilling,
                AllowsShipping = country.AllowsShipping,
                DisplayOrder = country.DisplayOrder,
                Id = country.Id,
                LimitedToStores = country.LimitedToStores,
                Name = country.Name,
                NumericIsoCode = country.NumericIsoCode,
                Published = country.Published,
                SubjectToVat = country.SubjectToVat,
                ThreeLetterIsoCode = country.ThreeLetterIsoCode,
                TwoLetterIsoCode = country.TwoLetterIsoCode
            };
        }

        protected override CountryModel GetModel(Country country)
        {
            return new CountryModel
            {
                AllowsBilling = country.AllowsBilling,
                AllowsShipping = country.AllowsShipping,
                DisplayOrder = country.DisplayOrder,
                Id = country.Id,
                LimitedToStores = country.LimitedToStores,
                Name = country.Name,
                NumericIsoCode = country.NumericIsoCode,
                Published = country.Published,
                SubjectToVat = country.SubjectToVat,
                ThreeLetterIsoCode = country.ThreeLetterIsoCode,
                TwoLetterIsoCode = country.TwoLetterIsoCode
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.Id == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class CurrencyAdapter : BaseAdapter<Currency, CurrencyModel>
    {
        protected override OMSRepositoryBase<Currency> Repo
        {
            get
            {
                return this.uow.CurrencyRepository;
            }
        }

        protected override Currency GetEntity(CurrencyModel currency)
        {
            return new Currency()
            {
                Published = currency.Published,
                Name = currency.Name,
                LimitedToStores = currency.LimitedToStores,
                CurrencyId = currency.CurrencyId,
                DisplayOrder = currency.DisplayOrder,
                Rate = currency.Rate,
                RoundingTypeId = currency.RoundingTypeId,
                CurrencyCode = currency.CurrencyCode,
                CustomFormatting = currency.CustomFormatting,
                DisplayLocale = currency.DisplayLocale,
                //LastModifiedDateTime = currency.ModifiedOn
            };
        }

        protected override CurrencyModel GetModel(Currency currency)
        {
            return new CurrencyModel
            {
                Published = currency.Published,
                Name = currency.Name,
                LimitedToStores = currency.LimitedToStores,
                CurrencyId = currency.CurrencyId,
                DisplayOrder = currency.DisplayOrder,
                Rate = currency.Rate,
                RoundingTypeId = currency.RoundingTypeId,
                CurrencyCode = currency.CurrencyCode,
                CustomFormatting = currency.CustomFormatting,
                DisplayLocale = currency.DisplayLocale,
                //ModifiedOn = currency.LastModifiedDateTime
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.CurrencyId == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class LanguageAdapter : BaseAdapter<Language, LanguageModel>
    {
        protected override OMSRepositoryBase<Language> Repo
        {
            get
            {
                return this.uow.LanguageRepository;
            }
        }

        protected override Language GetEntity(LanguageModel language)
        {
            return new Language()
            {
                DefaultCurrencyId = language.DefaultCurrencyId,
                DisplayOrder = language.DisplayOrder,
                FlagImageFileName = language.FlagImageFileName,
                Id = language.Id,
                LanguageCulture = language.LanguageCulture,
                LimitedToStores = language.LimitedToStores,
                Name = language.Name,
                Published = language.Published,
                Rtl = language.Rtl,
                UniqueSeoCode = language.UniqueSeoCode
            };
        }

        protected override LanguageModel GetModel(Language language)
        {
            return new LanguageModel
            {
                DefaultCurrencyId = language.DefaultCurrencyId,
                DisplayOrder = language.DisplayOrder,
                FlagImageFileName = language.FlagImageFileName,
                Id = language.Id,
                LanguageCulture = language.LanguageCulture,
                LimitedToStores = language.LimitedToStores,
                Name = language.Name,
                Published = language.Published,
                Rtl = language.Rtl,
                UniqueSeoCode = language.UniqueSeoCode
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.Id == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class LocaleStringResourceAdapter : BaseAdapter<LocaleStringResource, LocaleStringResourceModel>
    {
        protected override OMSRepositoryBase<LocaleStringResource> Repo
        {
            get
            {
                return this.uow.LocaleStringResourceRepository;
            }
        }

        protected override LocaleStringResource GetEntity(LocaleStringResourceModel localestringresource)
        {
            return new LocaleStringResource()
            {
                Id = localestringresource.Id,
                LanguageId = localestringresource.LanguageId,
                ResourceName = localestringresource.ResourceName,
                ResourceValue = localestringresource.ResourceValue
            };
        }

        protected override LocaleStringResourceModel GetModel(LocaleStringResource localestringresource)
        {
            return new LocaleStringResourceModel
            {
                Id = localestringresource.Id,
                LanguageId = localestringresource.LanguageId,
                ResourceName = localestringresource.ResourceName,
                ResourceValue = localestringresource.ResourceValue
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.Id == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class LocalizedPropertyAdapter : BaseAdapter<LocalizedProperty, LocalizedPropertyModel>
    {
        protected override OMSRepositoryBase<LocalizedProperty> Repo
        {
            get
            {
                return this.uow.LocalizedPropertyRepository;
            }
        }

        protected override LocalizedProperty GetEntity(LocalizedPropertyModel localizedproperty)
        {
            return new LocalizedProperty()
            {
                EntityId = localizedproperty.EntityId,
                Id = localizedproperty.Id,
                LanguageId = localizedproperty.LanguageId,
                LocaleKey = localizedproperty.LocaleKey,
                LocaleKeyGroup = localizedproperty.LocaleKeyGroup,
                LocaleValue = localizedproperty.LocaleValue
            };
        }

        protected override LocalizedPropertyModel GetModel(LocalizedProperty localizedproperty)
        {
            return new LocalizedPropertyModel
            {
                EntityId = localizedproperty.EntityId,
                Id = localizedproperty.Id,
                LanguageId = localizedproperty.LanguageId,
                LocaleKey = localizedproperty.LocaleKey,
                LocaleKeyGroup = localizedproperty.LocaleKeyGroup,
                LocaleValue = localizedproperty.LocaleValue
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.Id == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class LogAdapter : BaseAdapter<Log, LogModel>
    {
        protected override OMSRepositoryBase<Log> Repo
        {
            get
            {
                return this.uow.LogRepository;
            }
        }

        protected override Log GetEntity(LogModel log)
        {
            return new Log()
            {
                Id = log.Id,
                CustomerId = log.CustomerId,
                FullMessage = log.FullMessage,
                IpAddress = log.IpAddress,
                LogLevelId = log.LogLevelId,
                PageUrl = log.PageUrl,
                ReferrerUrl = log.ReferrerUrl,
                ShortMessage = log.ShortMessage,
                //LastModifiedDateTime = log.ModifiedOn
            };
        }

        protected override LogModel GetModel(Log log)
        {
            return new LogModel
            {
                Id = log.Id,
                CustomerId = log.CustomerId,
                FullMessage = log.FullMessage,
                IpAddress = log.IpAddress,
                LogLevelId = log.LogLevelId,
                PageUrl = log.PageUrl,
                ReferrerUrl = log.ReferrerUrl,
                ShortMessage = log.ShortMessage,
                //ModifiedOn = log.LastModifiedDateTime
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.Id == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class OrderStatusMapAdapter : BaseAdapter<OrderStatusMap, OrderStatusMapModel>
    {
        protected override OMSRepositoryBase<OrderStatusMap> Repo
        {
            get
            {
                return this.uow.OrderStatusMapRepository;
            }
        }

        protected override OrderStatusMap GetEntity(OrderStatusMapModel orderstatusmap)
        {
            return new OrderStatusMap()
            {
                ChildOrderStatusID = orderstatusmap.ChildOrderStatusID,
                Description = orderstatusmap.Description,
                OrderStatusMapID = orderstatusmap.OrderStatusMapID,
                ParentOrderStatusID = orderstatusmap.ParentOrderStatusID,
                IsDefault = orderstatusmap.IsDefault,
                StatusID = orderstatusmap.StatusID
            };
        }

        protected override OrderStatusMapModel GetModel(OrderStatusMap orderstatusmap)
        {
            return new OrderStatusMapModel
            {
                ChildOrderStatusID = orderstatusmap.ChildOrderStatusID,
                Description = orderstatusmap.Description,
                OrderStatusMapID = orderstatusmap.OrderStatusMapID,
                ParentOrderStatusID = orderstatusmap.ParentOrderStatusID,
                IsDefault = orderstatusmap.IsDefault,
                StatusID = orderstatusmap.StatusID
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.OrderStatusMapID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class PaymentAdapter : BaseAdapter<Payment, PaymentModel>
    {
        protected override OMSRepositoryBase<Payment> Repo
        {
            get
            {
                return this.uow.PaymentRepository;
            }
        }

        protected override Payment GetEntity(PaymentModel payment)
        {
            return new Payment()
            {
                OrderID = payment.OrderID,
                PayTypeID = payment.PayTypeID,
                Amount = payment.Amount,
                IsAmountVerified = payment.IsAmountVerified,
                PaymentGatewayTransactionID = payment.PaymentGatewayTransactionID,
                PaymentID = payment.PaymentID,
                PaymentToken = payment.PaymentToken,
                LastModifiedDateTime = payment.ModifiedOn,
            };
        }

        protected override PaymentModel GetModel(Payment payment)
        {
            return new PaymentModel
            {
                OrderID = payment.OrderID,
                PayTypeID = payment.PayTypeID,
                Amount = payment.Amount,
                IsAmountVerified = payment.IsAmountVerified,
                PaymentGatewayTransactionID = payment.PaymentGatewayTransactionID,
                PaymentID = payment.PaymentID,
                PaymentToken = payment.PaymentToken,
                ModifiedOn = payment.LastModifiedDateTime,
                ModifiedBy = payment.LastModifiedByUserID,
                CreatedBy = payment.CreatedByUserID,
                CreatedOn = payment.CreatedDateTime,
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.PaymentID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class PayOptionMatrixAdapter : BaseAdapter<PayOptionMatrix, PayOptionMatrixModel>
    {
        protected override OMSRepositoryBase<PayOptionMatrix> Repo
        {
            get
            {
                return this.uow.PayOptionMatrixRepository;
            }
        }

        protected override PayOptionMatrix GetEntity(PayOptionMatrixModel payoptionmatrix)
        {
            return new PayOptionMatrix()
            {
                IsSystem = payoptionmatrix.IsSystem,
                PayModeID = payoptionmatrix.PayModeID,
                PayOptionMatrixID = payoptionmatrix.PayOptionMatrixID,
                PayTypeID = payoptionmatrix.PayTypeID
            };
        }

        protected override PayOptionMatrixModel GetModel(PayOptionMatrix payoptionmatrix)
        {
            return new PayOptionMatrixModel
            {
                IsSystem = payoptionmatrix.IsSystem,
                PayModeID = payoptionmatrix.PayModeID,
                PayOptionMatrixID = payoptionmatrix.PayOptionMatrixID,
                PayTypeID = payoptionmatrix.PayTypeID,
                PayModeTitle = payoptionmatrix.PayMode.PayModeTitle,
                PayTypeTitle = payoptionmatrix.PayType.PayTypeTitle
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.PayOptionMatrixID == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class SearchTermAdapter : BaseAdapter<SearchTerm, SearchTermModel>
    {
        protected override OMSRepositoryBase<SearchTerm> Repo
        {
            get
            {
                return this.uow.SearchTermRepository;
            }
        }

        protected override SearchTerm GetEntity(SearchTermModel searchterm)
        {
            return new SearchTerm()
            {
                Count = searchterm.Count,
                Id = searchterm.Id,
                Keyword = searchterm.Keyword,
                StoreId = searchterm.StoreId
            };
        }

        protected override SearchTermModel GetModel(SearchTerm searchterm)
        {
            return new SearchTermModel
            {
                Count = searchterm.Count,
                Id = searchterm.Id,
                Keyword = searchterm.Keyword,
                StoreId = searchterm.StoreId
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.Id == Id);
                return uow.Commit() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }

    public partial class VerificationStatusAdapter : BaseAdapter<VerificationStatus, VerificationStatusModel>
    {
        protected override OMSRepositoryBase<VerificationStatus> Repo
        {
            get
            {
                return this.uow.VerificationStatusRepository;
            }
        }

        protected override VerificationStatus GetEntity(VerificationStatusModel verificationstatus)
        {
            return new VerificationStatus()
            {
                Description = verificationstatus.Description,
                IsSystem = verificationstatus.IsSystem,
                VerificationStatusID = verificationstatus.VerificationStatusID,
                VerificationStatusTitle = verificationstatus.VerificationStatusTitle
            };
        }

        protected override VerificationStatusModel GetModel(VerificationStatus verificationstatus)
        {
            return new VerificationStatusModel
            {
                Description = verificationstatus.Description,
                IsSystem = verificationstatus.IsSystem,
                VerificationStatusID = verificationstatus.VerificationStatusID,
                VerificationStatusTitle = verificationstatus.VerificationStatusTitle
            };
        }

        #region Delete
        public override bool Delete(long Id)
        {
            try
            {
                Repo.Delete(a => a.VerificationStatusID == Id);
                return uow.Commit() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Delete
    }
}
