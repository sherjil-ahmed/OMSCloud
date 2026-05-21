using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Interfaces.IServices
{
    public partial interface IBankAccountController : IApiController<BankAccountModel> { }
    public partial interface IChatController : IApiController<ChatModel> { }
    public partial interface IChatMessageController : IApiController<ChatMessageModel> { }
    public partial interface ICustomerReviewController : IApiController<CustomerReviewModel> { }
    public partial interface IAddressController : IApiController<AddressModel> { }
    public partial interface IAddressContactInfoPairController : IApiController<AddressContactInfoPairModel> { }
    public partial interface IAddressTypeController : IApiController<AddressTypeModel> { }
    public partial interface IAppConfigController : IApiController<AppConfigModel> { }
    public partial interface IAttributeController : IApiController<AttributeModel> { }
    public partial interface IAttributeTypeController : IApiController<AttributeTypeModel> { }
    public partial interface IBrandController : IApiController<BrandModel> { }
    public partial interface ICartItemController : IApiController<CartItemModel> { }
    public partial interface ICartController : IApiController<CartModel> { }
    public partial interface IOrderController : IApiController<OrderModel> { }
    public partial interface ICategoryController : IApiController<CategoryModel> { }
    public partial interface ICategoryAttributePairController : IApiController<CategoryAttributePairModel> { }
    public partial interface ICategoryTypeController : IApiController<CategoryTypeModel> { }
    public partial interface IContactInfoController : IApiController<ContactInfoModel> { }
    public partial interface IContactTypeController : IApiController<ContactTypeModel> { }
    public partial interface ICountryController : IApiController<CountryModel> { }
    public partial interface ICurrencyController : IApiController<CurrencyModel> { }
    public partial interface IDataTypeController : IApiController<DataTypeModel> { }
    public partial interface IDeliveryOptionController : IApiController<DeliveryOptionModel> { }
    public partial interface IDocumentTypeController : IApiController<DocumentTypeModel> { }
    public partial interface IExecActionController : IApiController<ExecActionModel> { }
    public partial interface IExecActionParamController : IApiController<ExecActionParamModel> { }
    public partial interface IGroupController : IApiController<GroupModel> { }
    public partial interface IGroupRolePairController : IApiController<GroupRolePairModel> { }
    public partial interface ILanguageController : IApiController<LanguageModel> { }
    public partial interface ILocaleStringResourceController : IApiController<LocaleStringResourceModel> { }
    public partial interface ILocalizedPropertyController : IApiController<LocalizedPropertyModel> { }
    public partial interface ILocationLevelController : IApiController<LocationLevelModel> { }
    public partial interface ILocationTreeController : IApiController<LocationTreeModel> { }
    public partial interface ILogController : IApiController<LogModel> { }
    public partial interface IMediaContentTypeController : IApiController<MediaContentTypeModel> { }
    public partial interface IOptionController : IApiController<OptionModel> { }
    public partial interface IOptionTypeController : IApiController<OptionTypeModel> { }
    public partial interface IOrderDeliveryDetailController : IApiController<OrderDeliveryDetailModel> { }
    public partial interface IOrderPaymentController : IApiController<OrderPaymentModel> { }
    public partial interface IOrderStatusController : IApiController<OrderStatusModel> { }
    public partial interface IOrderStatusMapController : IApiController<OrderStatusMapModel> { }
    public partial interface IPackagedProductController : IApiController<PackagedProductModel> { }
    public partial interface IPaymentController : IApiController<PaymentModel> { }
    public partial interface IPayModeController : IApiController<PayModeModel> { }
    public partial interface IPayOptionMatrixController : IApiController<PayOptionMatrixModel> { }
    public partial interface IPayTypeController : IApiController<PayTypeModel> { }
    public partial interface IProductController : IApiController<ProductModel> { }
    public partial interface IProductAttributePairController : IApiController<ProductAttributePairModel> { }
    public partial interface IProductCategoryPairController : IApiController<ProductCategoryPairModel> { }
    public partial interface IProductMediaDetailController : IApiController<ProductMediaDetailModel> { }
    public partial interface IProductTypeController : IApiController<ProductTypeModel> { }
    public partial interface IProductViewController : IApiController<ProductViewModel> { }
    public partial interface IProductViewItemController : IApiController<ProductViewItemModel> { }
    public partial interface IProfileController : IApiController<ProfileModel> { }
    public partial interface IProfileVerificationController : IApiController<ProfileVerificationModel> { }
    public partial interface IRoleController : IApiController<RoleModel> { }
    public partial interface IRoleOptionPairController : IApiController<RoleOptionPairModel> { }
    public partial interface IScheduleController : IApiController<ScheduleModel> { }
    public partial interface ISearchTermController : IApiController<SearchTermModel> { }
    public partial interface IStateMachineController : IApiController<StateMachineModel> { }
    public partial interface IStateMachineStateController : IApiController<StateMachineStateModel> { }
    public partial interface IStatusController : IApiController<StatusModel> { }
    public partial interface ISupplierController : IApiController<SupplierModel> { }
    public partial interface ISupplierDeliveryOptionPairController : IApiController<SupplierDeliveryOptionPairModel> { }
    public partial interface ITaxController : IApiController<TaxModel> { }
    public partial interface ITaxTypeController : IApiController<TaxTypeModel> { }
    public partial interface IUserController : IApiController<UserModel> { }
    public partial interface IUserTypeController : IApiController<UserTypeModel> { }
    public partial interface IVerificationStatusController : IApiController<VerificationStatusModel> { }

}
