using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.DataStore.EF.IRepositories;
using OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.DataStore.EF.Repositories;

namespace OMSCloud.DataStore.EF.Repositories
{
    //
    public partial class NotificationTokenRepository : OMSRepositoryBase<NotificationToken>, INotificationTokenRepository { public NotificationTokenRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class BankAccountRepository : OMSRepositoryBase<BankAccount>, IBankAccountRepository { public BankAccountRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class NotifyRepository : OMSRepositoryBase<Notify>, INotifyRepository { public NotifyRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ChatMessageRepository : OMSRepositoryBase<ChatMessage>, IChatMessageRepository { public ChatMessageRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ChatRepository : OMSRepositoryBase<Chat>, IChatRepository { public ChatRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class AddressRepository : OMSRepositoryBase<Address>, IAddressRepository { public AddressRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class AddressContactInfoPairRepository : OMSRepositoryBase<AddressContactInfoPair>, IAddressContactInfoPairRepository { public AddressContactInfoPairRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class AddressTypeRepository : OMSRepositoryBase<AddressType>, IAddressTypeRepository { public AddressTypeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class AppConfigRepository : OMSRepositoryBase<AppConfig>, IAppConfigRepository { public AppConfigRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class AttributeRepository : OMSRepositoryBase<OMSModel.Attribute>, IAttributeRepository { public AttributeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class AttributeTypeRepository : OMSRepositoryBase<AttributeType>, IAttributeTypeRepository { public AttributeTypeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class BrandRepository : OMSRepositoryBase<Brand>, IBrandRepository { public BrandRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class CartItemRepository : OMSRepositoryBase<CartItem>, ICartItemRepository { public CartItemRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class CartItemAttributePairRepository : OMSRepositoryBase<CartItemAttributePair>, ICartItemAttributePairRepository { public CartItemAttributePairRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class CartOrderRepository : OMSRepositoryBase<CartOrder>, ICartOrderRepository { public CartOrderRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class CategoryRepository : OMSRepositoryBase<Category>, ICategoryRepository { public CategoryRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class CategoryAttributePairRepository : OMSRepositoryBase<CategoryAttributePair>, ICategoryAttributePairRepository { public CategoryAttributePairRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class CategoryTypeRepository : OMSRepositoryBase<CategoryType>, ICategoryTypeRepository { public CategoryTypeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ContactInfoRepository : OMSRepositoryBase<ContactInfo>, IContactInfoRepository { public ContactInfoRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ContactTypeRepository : OMSRepositoryBase<ContactType>, IContactTypeRepository { public ContactTypeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class CountryRepository : OMSRepositoryBase<Country>, ICountryRepository { public CountryRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class CurrencyRepository : OMSRepositoryBase<Currency>, ICurrencyRepository { public CurrencyRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class CustomerReviewRepository : OMSRepositoryBase<CustomerReview>, ICustomerReviewRepository { public CustomerReviewRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class DataTypeRepository : OMSRepositoryBase<DataType>, IDataTypeRepository { public DataTypeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class DeliveryOptionRepository : OMSRepositoryBase<DeliveryOption>, IDeliveryOptionRepository { public DeliveryOptionRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class DocumentTypeRepository : OMSRepositoryBase<DocumentType>, IDocumentTypeRepository { public DocumentTypeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ExecActionRepository : OMSRepositoryBase<ExecAction>, IExecActionRepository { public ExecActionRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ExecActionParamRepository : OMSRepositoryBase<ExecActionParam>, IExecActionParamRepository { public ExecActionParamRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class GroupRepository : OMSRepositoryBase<Group>, IGroupRepository { public GroupRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class GroupRolePairRepository : OMSRepositoryBase<GroupRolePair>, IGroupRolePairRepository { public GroupRolePairRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class LanguageRepository : OMSRepositoryBase<Language>, ILanguageRepository { public LanguageRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class LocaleStringResourceRepository : OMSRepositoryBase<LocaleStringResource>, ILocaleStringResourceRepository { public LocaleStringResourceRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class LocalizedPropertyRepository : OMSRepositoryBase<LocalizedProperty>, ILocalizedPropertyRepository { public LocalizedPropertyRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class LocationLevelRepository : OMSRepositoryBase<LocationLevel>, ILocationLevelRepository { public LocationLevelRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class LocationTreeRepository : OMSRepositoryBase<LocationTree>, ILocationTreeRepository { public LocationTreeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class LogRepository : OMSRepositoryBase<Log>, ILogRepository { public LogRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class MediaContentTypeRepository : OMSRepositoryBase<MediaContentType>, IMediaContentTypeRepository { public MediaContentTypeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class OptionRepository : OMSRepositoryBase<Option>, IOptionRepository { public OptionRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class OptionTypeRepository : OMSRepositoryBase<OptionType>, IOptionTypeRepository { public OptionTypeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class OrderDeliveryDetailRepository : OMSRepositoryBase<OrderDeliveryDetail>, IOrderDeliveryDetailRepository { public OrderDeliveryDetailRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class OrderPaymentRepository : OMSRepositoryBase<OrderPayment>, IOrderPaymentRepository { public OrderPaymentRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class OrderStatusRepository : OMSRepositoryBase<OrderStatus>, IOrderStatusRepository { public OrderStatusRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class OrderStatusMapRepository : OMSRepositoryBase<OrderStatusMap>, IOrderStatusMapRepository { public OrderStatusMapRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class PackagedProductRepository : OMSRepositoryBase<PackagedProduct>, IPackagedProductRepository { public PackagedProductRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class PaymentRepository : OMSRepositoryBase<Payment>, IPaymentRepository { public PaymentRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class PayModeRepository : OMSRepositoryBase<PayMode>, IPayModeRepository { public PayModeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class PayOptionMatrixRepository : OMSRepositoryBase<PayOptionMatrix>, IPayOptionMatrixRepository { public PayOptionMatrixRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class PayTypeRepository : OMSRepositoryBase<PayType>, IPayTypeRepository { public PayTypeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ProductRepository : OMSRepositoryBase<Product>, IProductRepository { public ProductRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ProductAttributePairRepository : OMSRepositoryBase<ProductAttributePair>, IProductAttributePairRepository { public ProductAttributePairRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ProductCategoryPairRepository : OMSRepositoryBase<ProductCategoryPair>, IProductCategoryPairRepository { public ProductCategoryPairRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ProductMediaDetailRepository : OMSRepositoryBase<ProductMediaDetail>, IProductMediaDetailRepository { public ProductMediaDetailRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ProductTypeRepository : OMSRepositoryBase<ProductType>, IProductTypeRepository { public ProductTypeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ProductViewRepository : OMSRepositoryBase<ProductView>, IProductViewRepository { public ProductViewRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ProductViewItemRepository : OMSRepositoryBase<ProductViewItem>, IProductViewItemRepository { public ProductViewItemRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ProfileRepository : OMSRepositoryBase<Profile>, IProfileRepository { public ProfileRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ProfileVerificationRepository : OMSRepositoryBase<ProfileVerification>, IProfileVerificationRepository { public ProfileVerificationRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class RoleRepository : OMSRepositoryBase<Role>, IRoleRepository { public RoleRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class RoleOptionPairRepository : OMSRepositoryBase<RoleOptionPair>, IRoleOptionPairRepository { public RoleOptionPairRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class ScheduleRepository : OMSRepositoryBase<Schedule>, IScheduleRepository { public ScheduleRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class SearchTermRepository : OMSRepositoryBase<SearchTerm>, ISearchTermRepository { public SearchTermRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class StateMachineRepository : OMSRepositoryBase<StateMachine>, IStateMachineRepository { public StateMachineRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class StateMachineStateRepository : OMSRepositoryBase<StateMachineState>, IStateMachineStateRepository { public StateMachineStateRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class StatusRepository : OMSRepositoryBase<Status>, IStatusRepository { public StatusRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class SupplierRepository : OMSRepositoryBase<Supplier>, ISupplierRepository { public SupplierRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class SupplierDeliveryOptionPairRepository : OMSRepositoryBase<SupplierDeliveryOptionPair>, ISupplierDeliveryOptionPairRepository { public SupplierDeliveryOptionPairRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class TaxRepository : OMSRepositoryBase<Tax>, ITaxRepository { public TaxRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class TaxTypeRepository : OMSRepositoryBase<TaxType>, ITaxTypeRepository { public TaxTypeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class UserRepository : OMSRepositoryBase<User>, IUserRepository { public UserRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class UserTypeRepository : OMSRepositoryBase<UserType>, IUserTypeRepository { public UserTypeRepository(OMSContext dataContext) : base(dataContext) { } }
    public partial class VerificationStatusRepository : OMSRepositoryBase<VerificationStatus>, IVerificationStatusRepository { public VerificationStatusRepository(OMSContext dataContext) : base(dataContext) { } }
}
