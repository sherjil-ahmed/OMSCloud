using OMSCloud.Business.Adapters;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.Interfaces;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Core
{
    public partial class NotificationTokenBusinessComponent
    {
        public long? AddNotificationToken(NotificationTokenModel model)
        {
            return adapter.AddNotificationToken(model);
        }
        public bool UpdateNotificationToken(NotificationTokenModel model)
        {
            return adapter.UpdateNotificationToken(model);
        }
    }
    public partial class NotifyBusinessComponent
    {
        public long? AddNotify(NotifyModel model)
        {
            return adapter.AddNotify(model);
        }
        public bool UpdateNotify(NotifyModel model)
        {
            return adapter.UpdateNotify(model);
        }
    }
    public partial class BankAccountBusinessComponent
    {
        public long? AddBankAccount(BankAccountModel model)
        {
            return adapter.AddBankAccount(model);
        }
        public bool UpdateBankAccount(BankAccountModel model)
        {
            return adapter.UpdateBankAccount(model);
        }
    }
    public partial class ChatMessageBusinessComponent
    {

        public bool MarkRead(ChatMessageModel model)
        {
            return adapter.MarkRead(model);
        }

        public long? SendMessage(ChatMessageModel model)
        {
            return adapter.SendMessage(model);
        }
    }
    public partial class ChatBusinessComponent
    {
        
        public bool UpdateChat(ChatModel model)
        {
            return adapter.UpdateChat(model);
        }
        public long? AddChat(ChatModel model)
        {
            return adapter.Add(model);
        }
    }
    public partial class CustomerReviewBusinessComponent
    {
        public long? AddCustomerReview(CustomerReviewModel model)
        {
            return adapter.AddCustomerReview(model);
        }
        public bool UpdateCustomerReview(CustomerReviewModel model)
        {
            return adapter.UpdateCustomerReview(model);
        }
    }
    public partial class AddressContactInfoPairBusinessComponent : IBusinessComponent<AddressContactInfoPairModel>
    {
        public long? AddAddressContactInfoPair(AddressContactInfoPairModel model)
        {
            return adapter.AddAddressContactInfoPair(model);
        }
        public bool UpdateAddressContactInfoPair(AddressContactInfoPairModel model)
        {
            return adapter.UpdateAddressContactInfoPair(model);
        }
    }

    public partial class SupplierBusinessComponent
    {
        public long? AddSupplier(SupplierModel Supplier)
        {
            return adapter.AddSupplier(Supplier);
        }
        public bool UpdateSupplier(SupplierModel Supplier)
        {
            return adapter.UpdateSupplier(Supplier);
        }
        public bool UpdateSupplierDetails(ShopPublicProfileModel supplierModel)
        {
            return adapter.UpdateSupplierDetails(supplierModel);
        }
        public bool ApproveSupplierList(List<long> SupplierList)
        {
            return adapter.ApproveSupplierList(SupplierList);
        }
        public bool UpdateSupplierCategoryRequests(CategoryRequestModel model)
        {
            return adapter.UpdateSupplierCategoryRequests(model);
        }
        public bool UpdateShopTaxInfo(ShopTaxInfoModel supplierModel)
        {
            return adapter.UpdateShopTaxInfo(supplierModel);
        }
        public bool UpdateSupplierAttributeRequests(AttributeRequestModel model)
        {
            return adapter.UpdateSupplierAttributeRequests(model);
        }
        public bool UpdateAddressVisibility(long shopId, bool IsAddressVisiblePublicly, long provinceId, long cityId)
        {
            var ProvinceId = provinceId > 0 ? provinceId : (long?)null;
            var CityId = cityId > 0 ? cityId : (long?)null;

            return adapter.UpdateAddressVisibility(shopId,IsAddressVisiblePublicly, ProvinceId , CityId );
        }
        public bool DeleteSupplier(SupplierModel Supplier)
        {
            return adapter.DeleteSupplier(Supplier);
        }
    }
    public partial class CartBusinessComponent
    {
        public long? AddCart(CartModel model)
        {
            return adapter.AddCart(model);
        }
        public bool UpdateCart(CartModel model)
        {
            return adapter.UpdateCart(model);
        }
    }
    public partial class ContactInfoBusinessComponent : IBusinessComponent<ContactInfoModel>
    {
        public long? AddContactInfo(ContactInfoModel model)
        {
            return adapter.AddContactInfo(model);
        }
        public bool UpdateContactInfo(ContactInfoModel model)
        {
            return adapter.UpdateContactInfo(model);
        }
    }

    public partial class ContactTypeBusinessComponent : IBusinessComponent<ContactTypeModel>
    {
        public long? AddContactType(ContactTypeModel model)
        {
            return adapter.AddContactType(model);
        }
        public bool UpdateContactType(ContactTypeModel model)
        {
            return adapter.UpdateContactType(model);
        }
    }

    public partial class CountryBusinessComponent : IBusinessComponent<CountryModel>
    {
        public long? AddCountry(CountryModel model)
        {
            return adapter.AddCountry(model);
        }
        public bool UpdateCountry(CountryModel model)
        {
            return adapter.UpdateCountry(model);
        }
    }

    public partial class CurrencyBusinessComponent : IBusinessComponent<CurrencyModel>
    {
        public long? AddCurrency(CurrencyModel model)
        {
            return adapter.AddCurrency(model);
        }
        public bool UpdateCurrency(CurrencyModel model)
        {
            return adapter.UpdateCurrency(model);
        }
    }

    public partial class LanguageBusinessComponent : IBusinessComponent<LanguageModel>
    {
        public long? AddLanguage(LanguageModel model)
        {
            return adapter.AddLanguage(model);
        }
        public bool UpdateLanguage(LanguageModel model)
        {
            return adapter.UpdateLanguage(model);
        }
    }

    public partial class LocaleStringResourceBusinessComponent : IBusinessComponent<LocaleStringResourceModel>
    {
        public long? AddLocaleStringResource(LocaleStringResourceModel model)
        {
            return adapter.AddLocaleStringResource(model);
        }
        public bool UpdateLocaleStringResource(LocaleStringResourceModel model)
        {
            return adapter.UpdateLocaleStringResource(model);
        }
    }

    public partial class LocalizedPropertyBusinessComponent : IBusinessComponent<LocalizedPropertyModel>
    {
        public long? AddLocalizedProperty(LocalizedPropertyModel model)
        {
            return adapter.AddLocalizedProperty(model);
        }
        public bool UpdateLocalizedProperty(LocalizedPropertyModel model)
        {
            return adapter.UpdateLocalizedProperty(model);
        }
    }

    public partial class LogBusinessComponent : IBusinessComponent<LogModel>
    {
        public long? AddLog(LogModel model)
        {
            return adapter.AddLog(model);
        }
        public bool UpdateLog(LogModel model)
        {
            return adapter.UpdateLog(model);
        }
    }

    public partial class OrderStatusMapBusinessComponent : IBusinessComponent<OrderStatusMapModel>
    {
        public long? AddOrderStatusMap(OrderStatusMapModel model)
        {
            return adapter.AddOrderStatusMap(model);
        }
        public bool UpdateOrderStatusMap(OrderStatusMapModel model)
        {
            return adapter.UpdateOrderStatusMap(model);
        }
    }

    public partial class PaymentBusinessComponent : IBusinessComponent<PaymentModel>
    {
        public long? AddPayment(PaymentModel model)
        {
            return adapter.AddPayment(model);
        }
        public bool UpdatePayment(PaymentModel model)
        {
            return adapter.UpdatePayment(model);
        }
    }

    public partial class PayOptionMatrixBusinessComponent : IBusinessComponent<PayOptionMatrixModel>
    {
        public long? AddPayOptionMatrix(PayOptionMatrixModel model)
        {
            return adapter.AddPayOptionMatrix(model);
        }
        public bool UpdatePayOptionMatrix(PayOptionMatrixModel model)
        {
            return adapter.UpdatePayOptionMatrix(model);
        }
    }

    public partial class SearchTermBusinessComponent : IBusinessComponent<SearchTermModel>
    {
        public long? AddSearchTerm(SearchTermModel model)
        {
            return adapter.AddSearchTerm(model);
        }
        public bool UpdateSearchTerm(SearchTermModel model)
        {
            return adapter.UpdateSearchTerm(model);
        }
    }

    public partial class VerificationStatusBusinessComponent : IBusinessComponent<VerificationStatusModel>
    {
        public long? AddVerificationStatus(VerificationStatusModel model)
        {
            return adapter.AddVerificationStatus(model);
        }
        public bool UpdateVerificationStatus(VerificationStatusModel model)
        {
            return adapter.UpdateVerificationStatus(model);
        }
    }

    public partial class SupplierDeliveryOptionPairBusinessComponent
    {
        public long? AddSupplierDeliveryOptionPair(SupplierDeliveryOptionPairModel model)
        {
            return adapter.AddSupplierDeliveryOptionPair(model);
        }
        public bool UpdateSupplierDeliveryOptionPair(SupplierDeliveryOptionPairModel model)
        {
            return adapter.UpdateSupplierDeliveryOptionPair(model);
        }
        public List<SupplierDeliveryOptionPairModel> UpdateSuplierDeliveryOptionPair(List<SupplierDeliveryOptionPairModel> list)
        {
            var result = new List<SupplierDeliveryOptionPairModel>();
            if (list != null && list.Count > 0)
            {
                var dbList = adapter.GetSupplierDeliveryOptionBySupplierId(list[0].SupplierID, false);
                
                foreach (var item in list)
                {
                    if (item.SupplierDeliveryOptionPairID > 0)
                    {
                        item.StatusID = (long)DBStatusEnum.Active;
                        var success = adapter.UpdateSupplierDeliveryOptionPair(item);
                        if (success)
                        {
                            result.Add(item);
                        }
                    }
                    else
                    {
                        var sameDeliveryOptionItemExists = dbList.Where(x => x.DeliveryOptionID == item.DeliveryOptionID).ToList();
                        if (sameDeliveryOptionItemExists != null & sameDeliveryOptionItemExists.Count > 0)
                        {
                            var firstSameDeliveryOptionItemExists = sameDeliveryOptionItemExists.FirstOrDefault();
                            item.SupplierDeliveryOptionPairID = firstSameDeliveryOptionItemExists.SupplierDeliveryOptionPairID;
                            item.StatusID = (long)DBStatusEnum.Active;
                            var success = adapter.UpdateSupplierDeliveryOptionPair(item);
                            if (success)
                            {
                                result.Add(item);
                            }
                        }
                        else
                        {
                            item.StatusID = (long)DBStatusEnum.Active;
                            var id = adapter.AddSupplierDeliveryOptionPair(item);
                            if (id.HasValue)
                            {
                                item.SupplierDeliveryOptionPairID = id.Value;

                                result.Add(item);
                            }
                        }
                    }
                }
                List<long> Ids = result.Select(x => x.SupplierDeliveryOptionPairID).ToList();
                foreach (var dbItem in dbList)
                {
                    if ( ! Ids.Contains(dbItem.SupplierDeliveryOptionPairID))
                    {
                        dbItem.StatusID = (long)DBStatusEnum.Deleted;
                        adapter.UpdateSupplierDeliveryOptionPair(dbItem);
                    }
                }
            }
            return result;
        }

        public bool DeleteBySupplierId(long Id)
        {
            return adapter.DeleteBySupplierId(Id);
        }
    }

    public partial class ScheduleBusinessComponent
    {
        public long? AddSchedule(ScheduleModel model)
        {
            return adapter.AddSchedule(model);
        }
        public bool UpdateSchedule(ScheduleModel Schedule)
        {
            return adapter.UpdateSchedule(Schedule);
        }
    }
}
