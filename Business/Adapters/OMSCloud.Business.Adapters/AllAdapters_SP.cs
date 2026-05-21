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
using System.Data.Entity.Core.Objects;

namespace OMSCloud.Business.Adapters
{
    public partial class NotificationTokenAdapter : BaseAdapter<NotificationToken, NotificationTokenModel>
    {
        #region Add
        public long? AddNotificationToken(NotificationTokenModel model)
        {
            try
            {
                var entity = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("New_TokenId", typeof(long));
                var recordsCount = uow.OMSContext.NotificationToken_Insert(entity, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
        #region Update   
        public bool UpdateNotificationToken(NotificationTokenModel model)
        {
            try
            {
                var entityNotify = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.NotificationToken_Update(model.TokenId, model.StatusId);
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
        #endregion Update
    }
    public partial class NotifyAdapter
    {
        #region Update   
        public bool UpdateNotify(NotifyModel model)
        {
            try
            {
                var entityNotify = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.Notify_Update(entityNotify);
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
        #endregion Update

        #region Add
        public long? AddNotify(NotifyModel model)
        {
            try
            {
                var entityNotify = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("New_NotificationId", typeof(long));
                var recordsCount = uow.OMSContext.Notify_Insert(entityNotify, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }
    public partial class BankAccountAdapter : BaseAdapter<BankAccount, BankAccountModel>
    {
        #region Update   
        public bool UpdateBankAccount(BankAccountModel model)
        {
            try
            {
                var entityBankAccount = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.BankAccount_Update(entityBankAccount);
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
        #endregion Update

        #region Add
        public long? AddBankAccount(BankAccountModel model)
        {
            try
            {
                var entityBankAccount = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("New_BankId", typeof(long));
                var recordsCount = uow.OMSContext.BankAccount_Insert(entityBankAccount, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }
    public partial class ChatAdapter : BaseAdapter<Chat, ChatModel>
    {
        #region Update   
        public bool UpdateChat(ChatModel model)
        {
            try
            {
                var entityChat = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.Chat_Update(entityChat);
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
        #endregion Update

        #region Add
        public long? AddChat(ChatModel model)
        {
            try
            {
                var entityChat = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("ChatID", typeof(long));
                var recordsCount = uow.OMSContext.Chat_Insert(entityChat, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }
    public partial class ChatMessageAdapter : BaseAdapter<ChatMessage, ChatMessageModel>
    {
        #region Update   
        public bool MarkRead(ChatMessageModel model)
        {
            try
            {
                var entityChatMessage = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.ChatMessage_MarkRead(entityChatMessage);
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
        public bool MarkReadByProfileID(ChatMessageModel model)
        {
            try
            {
                var entityChatMessage = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.ChatMessage_MarkReadByProfileID(entityChatMessage);
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
        #endregion Update

        #region Add
        public long? SendMessage(ChatMessageModel model)
        {
            try
            {
                var entityChatMessage = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("ChatMessageID", typeof(long));
                var recordsCount = uow.OMSContext.ChatMessage_SendMessage(entityChatMessage, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }
    public partial class AddressContactInfoPairAdapter : BaseAdapter<AddressContactInfoPair, AddressContactInfoPairModel>
    {
        #region Update   
        public bool UpdateAddressContactInfoPair(AddressContactInfoPairModel model)
        {
            try
            {
                var entityAddressContactInfoPair = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.AddressContactInfoPair_Update(entityAddressContactInfoPair);
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
        #endregion Update

        #region Add
        public long? AddAddressContactInfoPair(AddressContactInfoPairModel model)
        {
            try
            {
                var entityAddressContactInfoPair = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("AddressContactInfoPairID", typeof(long));
                var recordsCount = uow.OMSContext.AddressContactInfoPair_Insert(entityAddressContactInfoPair, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }
    public partial class CartAdapter 
    {
        #region Update

        public bool UpdateCart(CartModel cartModel)
        {
            try
            {
                var cart = UpdateConcurrency(GetEntity(cartModel), cartModel, true);
                var recordsCount = uow.OMSContext.Cart_Update(cart);

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
        #endregion Update

        #region Add
        
        public long? AddCart(CartModel cartModel)
        {
            try
            {
                var CartOrder = UpdateConcurrency(GetEntity(cartModel), cartModel, false);
                var outParam = new ObjectParameter("CartID", typeof(long));
                var recordsCount = uow.OMSContext.Cart_Insert(CartOrder, outParam);

                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }
    public partial class ContactInfoAdapter : BaseAdapter<ContactInfo, ContactInfoModel>
    {
        #region Update   
        public bool UpdateContactInfo(ContactInfoModel model)
        {
            try
            {
                var entityContactInfo = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.ContactInfo_Update(entityContactInfo);
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
        #endregion Update

        #region Add
        public long? AddContactInfo(ContactInfoModel model)
        {
            try
            {
                var entityContactInfo = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("ContactInfoID", typeof(long));
                var recordsCount = uow.OMSContext.ContactInfo_Insert(entityContactInfo, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }

    public partial class ContactTypeAdapter : BaseAdapter<ContactType, ContactTypeModel>
    {
        #region Update   
        public bool UpdateContactType(ContactTypeModel model)
        {
            try
            {
                var entityContactType = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = 0;//uow.OMSContext.ContactType_Update(entityContactType);
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
        #endregion Update

        #region Add
        public long? AddContactType(ContactTypeModel model)
        {
            try
            {
                var entityContactType = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("ContactTypeID", typeof(long));
                var recordsCount = 0;//uow.OMSContext.ContactType_Insert(entityContactType, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }

    public partial class CountryAdapter : BaseAdapter<Country, CountryModel>
    {
        #region Update   
        public bool UpdateCountry(CountryModel model)
        {
            try
            {
                var entityCountry = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.Country_Update(entityCountry);
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
        #endregion Update

        #region Add
        public long? AddCountry(CountryModel model)
        {
            try
            {
                var entityCountry = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("CountryID", typeof(long));
                var recordsCount = uow.OMSContext.Country_Insert(entityCountry, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add 
    } //done

    public partial class CurrencyAdapter : BaseAdapter<Currency, CurrencyModel>
    {
        #region Update   
        public bool UpdateCurrency(CurrencyModel model)
        {
            try
            {
                var entityCurrency = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.Currency_Update(entityCurrency);
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
        #endregion Update

        #region Add
        public long? AddCurrency(CurrencyModel model)
        {
            try
            {
                var entityCurrency = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("id", typeof(long));
                long recordsCount = uow.OMSContext.Currency_Insert(entityCurrency, outParam);
                return recordsCount > 0 ? Convert.ToInt64(outParam.Value) : (long?)null;// primary key need to convert 
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }//done

    public partial class CustomerReviewAdapter : BaseAdapter<CustomerReview, CustomerReviewModel>
    {
        #region Update   
        public bool UpdateCustomerReview(CustomerReviewModel model)
        {
            try
            {
                var entityCustomerReview = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.CustomerReview_Update(entityCustomerReview);
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
        #endregion Update

        #region Add
        public long? AddCustomerReview(CustomerReviewModel model)
        {
            try
            {
                var entityCustomerReview = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("CustomerReviewId", typeof(long));
                long recordsCount = uow.OMSContext.CustomerReview_Insert(entityCustomerReview, outParam);
                return recordsCount > 0 ? Convert.ToInt64(outParam.Value) : (long?)null;// primary key need to convert 
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }//done

    public partial class LanguageAdapter : BaseAdapter<Language, LanguageModel>
    {
        #region Update   
        public bool UpdateLanguage(LanguageModel model)
        {
            try
            {
                var entityLanguage = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.Language_Update(entityLanguage);
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
        #endregion Update

        #region Add
        public long? AddLanguage(LanguageModel model)
        {
            try
            {
                var entityLanguage = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("LanguageID", typeof(long));
                var recordsCount = uow.OMSContext.Language_Insert(entityLanguage, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }//done

    public partial class LocaleStringResourceAdapter : BaseAdapter<LocaleStringResource, LocaleStringResourceModel>
    {
        #region Update   
        public bool UpdateLocaleStringResource(LocaleStringResourceModel model)
        {
            try
            {
                var entityLocaleStringResource = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.LocaleStringResource_Update(entityLocaleStringResource);
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
        #endregion Update

        #region Add
        public long? AddLocaleStringResource(LocaleStringResourceModel model)
        {
            try
            {
                var entityLocaleStringResource = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("id", typeof(long));
                var recordsCount = uow.OMSContext.LocaleStringResource_Insert(entityLocaleStringResource, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }//done

    public partial class LocalizedPropertyAdapter : BaseAdapter<LocalizedProperty, LocalizedPropertyModel>
    {
        #region Update   
        public bool UpdateLocalizedProperty(LocalizedPropertyModel model)
        {
            try
            {
                var entityLocalizedProperty = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.LocalizedProperty_Update(entityLocalizedProperty);
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
        #endregion Update

        #region Add
        public long? AddLocalizedProperty(LocalizedPropertyModel model)
        {
            try
            {
                var entityLocalizedProperty = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("LocalizedPropertyID", typeof(long));
                var recordsCount = uow.OMSContext.LocalizedProperty_Insert(entityLocalizedProperty, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }//done 

    public partial class LogAdapter : BaseAdapter<Log, LogModel>
    {
        #region Update   
        public bool UpdateLog(LogModel model)
        {
            try
            {
                var entityLog = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.Log_Update(entityLog);
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
        #endregion Update

        #region Add
        public long? AddLog(LogModel model)
        {
            try
            {
                var entityLog = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("id", typeof(long));
                var recordsCount = uow.OMSContext.Log_Insert(entityLog, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }//done

    public partial class OrderStatusMapAdapter : BaseAdapter<OrderStatusMap, OrderStatusMapModel>
    {
        #region Update   
        public bool UpdateOrderStatusMap(OrderStatusMapModel model)
        {
            try
            {
                var entityOrderStatusMap = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.OrderStatusMap_Update(entityOrderStatusMap);
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
        #endregion Update

        #region Add
        public long? AddOrderStatusMap(OrderStatusMapModel model)
        {
            try
            {
                var entityOrderStatusMap = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("OrderStatusMapID", typeof(long));
                var recordsCount = uow.OMSContext.OrderStatusMap_Insert(entityOrderStatusMap, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }//done

    public partial class PaymentAdapter : BaseAdapter<Payment, PaymentModel>
    {
        #region Update   
        public bool UpdatePayment(PaymentModel model)
        {
            try
            {
                var entityPayment = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.Payment_Update(entityPayment);
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
        #endregion Update

        #region Add
        public long? AddPayment(PaymentModel model)
        {
            try
            {
                var entityPayment = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("PaymentID", typeof(long));
                var recordsCount = uow.OMSContext.Payment_Insert(entityPayment, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }//done

    public partial class PayOptionMatrixAdapter : BaseAdapter<PayOptionMatrix, PayOptionMatrixModel>
    {
        #region Update   
        public bool UpdatePayOptionMatrix(PayOptionMatrixModel model)
        {
            try
            {
                var entityPayOptionMatrix = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.PayOptionMatrix_Update(entityPayOptionMatrix);
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
        #endregion Update

        #region Add
        public long? AddPayOptionMatrix(PayOptionMatrixModel model)
        {
            try
            {
                var entityPayOptionMatrix = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("PayOptionMatrixID", typeof(long));
                var recordsCount = uow.OMSContext.PayOptionMatrix_Insert(entityPayOptionMatrix, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }//done

    public partial class ScheduleAdapter
    {
        #region Update

        public bool UpdateSchedule(ScheduleModel model)
        {
            try
            {
                var schedule = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.Schedule_Update(schedule);
                return recordsCount > 0;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        #endregion Update

        #region Add

        public long? AddSchedule(ScheduleModel scheduleModel)
        {
            try
            {
                var schedule = UpdateConcurrency(GetEntity(scheduleModel), scheduleModel, false);
                var outParam = new ObjectParameter("ScheduleID", typeof(int));
                var recordsCount = uow.OMSContext.Schedule_Insert(schedule, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        #endregion Add

    }
    public partial class SearchTermAdapter : BaseAdapter<SearchTerm, SearchTermModel>
    {
        #region Update   
        public bool UpdateSearchTerm(SearchTermModel model)
        {
            try
            {
                var entitySearchTerm = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.SearchTerm_Update(entitySearchTerm);
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
        #endregion Update

        #region Add
        public long? AddSearchTerm(SearchTermModel model)
        {
            try
            {
                var entitySearchTerm = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("id", typeof(long));
                var recordsCount = uow.OMSContext.SearchTerm_Insert(entitySearchTerm, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }//done

    public partial class VerificationStatusAdapter : BaseAdapter<VerificationStatus, VerificationStatusModel>
    {
        #region Update   
        public bool UpdateVerificationStatus(VerificationStatusModel model)
        {
            try
            {
                var entityVerificationStatus = UpdateConcurrency(GetEntity(model), model);
                var recordsCount = uow.OMSContext.VerificationStatus_Update(entityVerificationStatus);
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
        #endregion Update

        #region Add
        public long? AddVerificationStatus(VerificationStatusModel model)
        {
            try
            {
                var entityVerificationStatus = UpdateConcurrency(GetEntity(model), model, false);
                var outParam = new ObjectParameter("VerificationStatusID", typeof(long));
                var recordsCount = uow.OMSContext.VerificationStatus_Insert(entityVerificationStatus, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add
    }//done

    public partial class SupplierAdapter
    {
        #region Update

        public bool UpdateSupplier(SupplierModel supplierModel)
        {
            try
            {
                var supplier = UpdateConcurrency(GetEntity(supplierModel), supplierModel);
                var recordsCount = uow.OMSContext.Supplier_Update(supplier);
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
        public bool UpdateSupplierAnnouncementHTML(SupplierModel supplierModel)
        {
            try
            {
                var supplier = UpdateConcurrency(GetEntity(supplierModel), supplierModel);
                var recordsCount = uow.OMSContext.Supplier_Update_AnnouncementHTML(supplier);
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
        public bool UpdateSupplierPolicyHTML(SupplierModel supplierModel)
        {
            try
            {
                var supplier = UpdateConcurrency(GetEntity(supplierModel), supplierModel);
                var recordsCount = uow.OMSContext.Supplier_Update_PolicyHTML(supplier);
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
        public bool UpdateSupplierFAQHTML(SupplierModel supplierModel)
        {
            try
            {
                var supplier = UpdateConcurrency(GetEntity(supplierModel), supplierModel);
                var recordsCount = uow.OMSContext.Supplier_Update_FAQHTML(supplier);
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
        public bool UpdateSupplierWebLinksJSON(SupplierModel supplierModel)
        {
            try
            {
                var supplier = UpdateConcurrency(GetEntity(supplierModel), supplierModel);
                var recordsCount = uow.OMSContext.Supplier_Update_WebLinksJSON(supplier);
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
        public bool UpdateSupplierAttributeRequests(AttributeRequestModel model)
        {
            try
            {
                var supplier = new Supplier
                {
                    SupplierID = model.SupplierID,
                    AttributeRequests = model.AttributeRequests,
                    LastModifiedByUserID = model.RequestedByProfileId,
                    LastModifiedDateTime = model.ModifiedOn,
                };
                var recordsCount = uow.OMSContext.Supplier_Update_AttributeRequests(supplier);
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
        public bool UpdateSupplierCategoryRequests(CategoryRequestModel model)
        {
            try
            {

                var supplier = new Supplier
                {
                    SupplierID = model.SupplierID,
                    CategoryRequests = model.CategoryRequests,
                    LastModifiedByUserID = model.RequestedByProfileId,
                    LastModifiedDateTime = model.ModifiedOn,
                };
                var recordsCount = uow.OMSContext.Supplier_Update_CategoryRequests(supplier);
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
        public bool UpdateShopTaxInfo(ShopTaxInfoModel supplierModel)
        {
            try
            {
                Supplier entity = new Supplier {
                    SupplierID = supplierModel.SupplierID,
                    TaxConcent = supplierModel.TaxConsent,
                    TaxRegistration = supplierModel.TaxRegistration,
                };
                var supplier = UpdateConcurrency(entity, supplierModel);
                var recordsCount = uow.OMSContext.Supplier_Update_TaxInfo(supplier);
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
        public bool UpdateSupplierDetails(ShopPublicProfileModel supplierModel)
        {
            try
            {
                var supplier = UpdateConcurrency(GetEntity(supplierModel), supplierModel);
                var recordsCount = uow.OMSContext.Supplier_Update_Details(supplier);
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
        public bool UpdateAddressVisibility(long shopId, bool IsAddressVisiblePublicly, long? provinceId = null, long? cityId = null )
        {
            try
            {
                var recordsCount = uow.OMSContext.Supplier_Update_AddressVisibility(shopId,IsAddressVisiblePublicly, provinceId, cityId);
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
        public bool ApproveSupplierList(List<long> SupplierList)
        {
            try
            {
                var supplierIds = string.Join(",", SupplierList.Select(n => n.ToString()).ToArray());
                var recordsCount = uow.OMSContext.Bulk_Update("supplier", "supplierid", supplierIds, "statusid", ((int)DBStatusEnum.Active).ToString());
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

        #endregion Update

        #region Add

        public long? AddSupplier(SupplierModel supplierModel)
        {
            try
            {
                var supplier = UpdateConcurrency(GetEntity(supplierModel), supplierModel, false);
                var outParam = new ObjectParameter("SupplierID", typeof(int));
                var recordsCount = uow.OMSContext.Supplier_Insert(supplier, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        #endregion Add
    }
    public partial class SupplierDeliveryOptionPairAdapter
    {
        public bool DeleteBySupplierId(long Id)
        {
            try
            {
                var recordsCount = uow.OMSContext.SupplierDeliveryOptionPair_DeleteBySupplierId(Id);
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

        public long? AddSupplierDeliveryOptionPair(SupplierDeliveryOptionPairModel model)
        {
            try
            {
                var supplierDeliveryOptionPair = GetEntity(model);
                var outParam = new ObjectParameter("SupplierDeliveryOptionPairID", typeof(long));
                var recordsCount = uow.OMSContext.SupplierDeliveryOptionPair_Insert(supplierDeliveryOptionPair, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }

        }

        public bool UpdateSupplierDeliveryOptionPair(SupplierDeliveryOptionPairModel model)
        {
            try
            {
                var supplierDeliveryOptionPair = GetEntity(model);
                //var outParam = new ObjectParameter("SupplierDeliveryOptionPairID", typeof(long));
                var recordsCount = uow.OMSContext.SupplierDeliveryOptionPair_Update(supplierDeliveryOptionPair);
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
    }
}
