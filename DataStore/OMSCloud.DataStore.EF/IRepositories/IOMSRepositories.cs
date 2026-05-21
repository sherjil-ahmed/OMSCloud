using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.IRepositories;

using OMSCloud.DataStore.EF.OMSModel;

namespace OMSCloud.DataStore.EF.IRepositories
{
    public interface INotificationTokenRepository : IRepositoryBase<NotificationToken> { }
    public interface IBankAccountRepository : IRepositoryBase<BankAccount> { }
    public interface INotifyRepository : IRepositoryBase<Notify> { }
    public interface IChatRepository : IRepositoryBase<Chat> { }
    public interface IChatMessageRepository : IRepositoryBase<ChatMessage> { }
    public interface IAddressRepository : IRepositoryBase<Address> { }
    public interface IAddressContactInfoPairRepository : IRepositoryBase<AddressContactInfoPair> { }
    public interface IAddressTypeRepository : IRepositoryBase<AddressType> { }
    public interface IAppConfigRepository : IRepositoryBase<AppConfig> { }
    public interface IAttributeRepository : IRepositoryBase<OMSModel.Attribute> { }
    public interface IAttributeTypeRepository : IRepositoryBase<AttributeType> { }
    public interface IBrandRepository : IRepositoryBase<Brand> { }
    public interface ICartItemRepository : IRepositoryBase<CartItem> { }
    public interface ICartItemAttributePairRepository : IRepositoryBase<CartItemAttributePair> { }
    public interface ICartOrderRepository : IRepositoryBase<CartOrder> { }
    public interface ICategoryRepository : IRepositoryBase<Category> { }
    public interface ICategoryAttributePairRepository : IRepositoryBase<CategoryAttributePair> { }
    public interface ICategoryTypeRepository : IRepositoryBase<CategoryType> { }
    public interface IContactInfoRepository : IRepositoryBase<ContactInfo> { }
    public interface IContactTypeRepository : IRepositoryBase<ContactType> { }
    public interface ICountryRepository : IRepositoryBase<Country> { }
    public interface ICurrencyRepository : IRepositoryBase<Currency> { }
    public interface ICustomerReviewRepository : IRepositoryBase<CustomerReview> { }
    public interface IDataTypeRepository : IRepositoryBase<DataType> { }
    public interface IDeliveryOptionRepository : IRepositoryBase<DeliveryOption> { }
    public interface IDocumentTypeRepository : IRepositoryBase<DocumentType> { }
    public interface IExecActionRepository : IRepositoryBase<ExecAction> { }
    public interface IExecActionParamRepository : IRepositoryBase<ExecActionParam> { }
    public interface IGroupRepository : IRepositoryBase<Group> { }
    public interface IGroupRolePairRepository : IRepositoryBase<GroupRolePair> { }
    public interface ILanguageRepository : IRepositoryBase<Language> { }
    public interface ILocaleStringResourceRepository : IRepositoryBase<LocaleStringResource> { }
    public interface ILocalizedPropertyRepository : IRepositoryBase<LocalizedProperty> { }
    public interface ILocationLevelRepository : IRepositoryBase<LocationLevel> { }
    public interface ILocationTreeRepository : IRepositoryBase<LocationTree> { }
    public interface ILogRepository : IRepositoryBase<Log> { }
    public interface IMediaContentTypeRepository : IRepositoryBase<MediaContentType> { }
    public interface IOptionRepository : IRepositoryBase<Option> { }
    public interface IOptionTypeRepository : IRepositoryBase<OptionType> { }
    public interface IOrderDeliveryDetailRepository : IRepositoryBase<OrderDeliveryDetail> { }
    public interface IOrderPaymentRepository : IRepositoryBase<OrderPayment> { }
    public interface IOrderStatusRepository : IRepositoryBase<OrderStatus> { }
    public interface IOrderStatusMapRepository : IRepositoryBase<OrderStatusMap> { }
    public interface IPackagedProductRepository : IRepositoryBase<PackagedProduct> { }
    public interface IPaymentRepository : IRepositoryBase<Payment> { }
    public interface IPayModeRepository : IRepositoryBase<PayMode> { }
    public interface IPayOptionMatrixRepository : IRepositoryBase<PayOptionMatrix> { }
    public interface IPayTypeRepository : IRepositoryBase<PayType> { }
    public interface IProductRepository : IRepositoryBase<Product> { }
    public interface IProductAttributePairRepository : IRepositoryBase<ProductAttributePair> { }
    public interface IProductCategoryPairRepository : IRepositoryBase<ProductCategoryPair> { }
    public interface IProductMediaDetailRepository : IRepositoryBase<ProductMediaDetail> { }
    public interface IProductTypeRepository : IRepositoryBase<ProductType> { }
    public interface IProductViewRepository : IRepositoryBase<ProductView> { }
    public interface IProductViewItemRepository : IRepositoryBase<ProductViewItem> { }
    public interface IProfileRepository : IRepositoryBase<Profile> { }
    public interface IProfileVerificationRepository : IRepositoryBase<ProfileVerification> { }
    public interface IRoleRepository : IRepositoryBase<Role> { }
    public interface IRoleOptionPairRepository : IRepositoryBase<RoleOptionPair> { }
    public interface IScheduleRepository : IRepositoryBase<Schedule> { }
    public interface ISearchTermRepository : IRepositoryBase<SearchTerm> { }
    public interface IStateMachineRepository : IRepositoryBase<StateMachine> { }
    public interface IStateMachineStateRepository : IRepositoryBase<StateMachineState> { }
    public interface IStatusRepository : IRepositoryBase<Status> { }
    public interface ISupplierRepository : IRepositoryBase<Supplier> { }
    public interface ISupplierDeliveryOptionPairRepository : IRepositoryBase<SupplierDeliveryOptionPair> { }
    public interface ITaxRepository : IRepositoryBase<Tax> { }
    public interface ITaxTypeRepository : IRepositoryBase<TaxType> { }
    public interface IUserRepository : IRepositoryBase<User> { }
    public interface IUserTypeRepository : IRepositoryBase<UserType> { }
    public interface IVerificationStatusRepository : IRepositoryBase<VerificationStatus> { }

}
