using OMSCloud.Business.Adapters;
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
        private NotificationTokenAdapter adapter = new NotificationTokenAdapter();
        //public List<NotificationTokenModel> GetNotificationTokenList(long? ReceiverId, long? NotificationType)
        //{
        //    return adapter.GetNotificationTokenList(ReceiverId, NotificationType);
        //}
        public List<NotificationTokenModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.TokenId).ToList();
        }
        public NotificationTokenModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public NotificationTokenModel GetByNotificationToken(NotificationTokenModel model)
        {
            return adapter.GetByNotificationToken(model);
        }
        public List<string> GetNotificationTokenListByProfileId(long ProfileId)
        {
            return adapter.GetNotificationTokenListByProfileId(ProfileId);
        }
        public List<NotificationTokenModel> GetDeviceAllTokenList(long ProfileId)
        {
            return adapter.GetDeviceAllTokenList(ProfileId);
        }
        public List<string> GetNotificationTokenList()
        {
            return adapter.GetNotificationTokenList();
        }
        
        public long? Add(NotificationTokenModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(NotificationTokenModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(NotificationTokenModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }
    public partial class NotifyBusinessComponent
    {
        private NotifyAdapter adapter = new NotifyAdapter();
        public List<NotifyModel> GetNotifyList(long? ReceiverId, long? NotificationType)
        {
            return adapter.GetNotifyList(ReceiverId, NotificationType);
        }
        public List<NotifyModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.NotificationId).ToList();
        }
        public NotifyModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(NotifyModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(NotifyModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(NotifyModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class BankAccountBusinessComponent
    {
        private BankAccountAdapter adapter = new BankAccountAdapter();
        public List<BankAccountModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.BankId).ToList();
        }
        public BankAccountModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(BankAccountModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(BankAccountModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(BankAccountModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }

    }
    public partial class ChatMessageBusinessComponent
    {
        private ChatMessageAdapter adapter = new ChatMessageAdapter();

        public List<ChatMessageModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ChatId).ToList();
        }
        public ChatMessageModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ChatMessageModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ChatMessageModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ChatMessageModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ChatBusinessComponent
    {
        private ChatAdapter adapter = new ChatAdapter();

        public List<ChatModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ChatId).ToList();
        }
        public ChatModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ChatModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ChatModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ChatModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }

        public bool RemoveChatMessages(List<long> chatMessageListLong)
        {
            return adapter.RemoveChatMessages(chatMessageListLong);
        }
    }

    public partial class CustomerReviewBusinessComponent
    {
        private CustomerReviewAdapter adapter = new CustomerReviewAdapter();
        public List<CustomerReviewModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.CustomerReviewID).ToList();
        }

        public CustomerReviewModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(CustomerReviewModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(CustomerReviewModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(CustomerReviewModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }
    public partial class AddressBusinessComponent : IBusinessComponent<AddressModel>
    {
        private AddressAdapter adapter = new AddressAdapter();
        public List<AddressModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ProfileID).ToList();
        }

        public AddressModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(AddressModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(AddressModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(AddressModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class AddressTypeBusinessComponent : IBusinessComponent<AddressTypeModel>
    {
        private AddressTypeAdapter adapter = new AddressTypeAdapter();
        public List<AddressTypeModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.AddressTypeTitle).ToList();
        }
        public AddressTypeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(AddressTypeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(AddressTypeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(AddressTypeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class AppConfigBusinessComponent : IBusinessComponent<AppConfigModel>
    {
        private AppConfigAdapter adapter = new AppConfigAdapter();
        public List<AppConfigModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ConfigTitle).ToList();
        }
        public AppConfigModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(AppConfigModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(AppConfigModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(AppConfigModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class AttributeBusinessComponent : IBusinessComponent<AttributeModel>
    {
        private AttributeAdapter adapter = new AttributeAdapter();
        public List<AttributeModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.AttributeTitle).ToList();
        }
        public AttributeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(AttributeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(AttributeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(AttributeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class BrandBusinessComponent : IBusinessComponent<BrandModel>
    {
        private BrandAdapter adapter = new BrandAdapter();
        public List<BrandModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.BrandName).ToList();
        }
        public BrandModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(BrandModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(BrandModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(BrandModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class CartItemBusinessComponent : IBusinessComponent<CartItemModel>
    {
        private CartItemAdapter adapter = new CartItemAdapter();
        public List<CartItemModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.CartOrderID).ToList();
        }
        public CartItemModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(CartItemModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(CartItemModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(CartItemModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class CartBusinessComponent : IBusinessComponent<CartModel>
    {
        private CartAdapter adapter = new CartAdapter();
        public List<CartModel> GetList()
        {
            return adapter.GetList().OrderByDescending(o => o.CartID).ToList();
        }
        public CartModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(CartModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(CartModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(CartModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class OrderBusinessComponent : IBusinessComponent<OrderModel>
    {
        private OrderAdapter orderAdapter = new OrderAdapter();
        public List<OrderModel> GetList()
        {
            return orderAdapter.GetList().OrderByDescending(o => o.OrderID).ToList();
        }
        public OrderModel GetById(long Id)
        {
            return orderAdapter.GetById(Id);
        }
        public long? Add(OrderModel model)
        {
            return orderAdapter.Add(model);
        }
        public bool Update(OrderModel model)
        {
            return orderAdapter.Update(model);
        }
        public bool Delete(OrderModel model)
        {
            return orderAdapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return orderAdapter.Delete(Id);
        }
    }

    public partial class CategoryBusinessComponent : IBusinessComponent<CategoryModel>
    {
        private CategoryAdapter adapter = new CategoryAdapter();
        public List<CategoryModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.CategoryTitle).ToList();
        }
        public CategoryModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(CategoryModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(CategoryModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(CategoryModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class CategoryAttributePairBusinessComponent : IBusinessComponent<CategoryAttributePairModel>
    {
        private CategoryAttributePairAdapter adapter = new CategoryAttributePairAdapter();
        public List<CategoryAttributePairModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.CategoryID).ToList();
        }
        public CategoryAttributePairModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(CategoryAttributePairModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(CategoryAttributePairModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(CategoryAttributePairModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class CategoryTypeBusinessComponent : IBusinessComponent<CategoryTypeModel>
    {
        private CategoryTypeAdapter adapter = new CategoryTypeAdapter();
        public List<CategoryTypeModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.Title).ToList();
        }
        public CategoryTypeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(CategoryTypeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(CategoryTypeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(CategoryTypeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class DataTypeBusinessComponent : IBusinessComponent<DataTypeModel>
    {
        private DataTypeAdapter adapter = new DataTypeAdapter();
        public List<DataTypeModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ClassName).ToList();
        }
        public DataTypeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(DataTypeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(DataTypeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(DataTypeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class DeliveryOptionBusinessComponent : IBusinessComponent<DeliveryOptionModel>
    {
        private DeliveryOptionAdapter adapter = new DeliveryOptionAdapter();
        public List<DeliveryOptionModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.DeliveryOptionTitle).ToList();
        }
        public DeliveryOptionModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(DeliveryOptionModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(DeliveryOptionModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(DeliveryOptionModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ExecActionBusinessComponent : IBusinessComponent<ExecActionModel>
    {
        private ExecActionAdapter adapter = new ExecActionAdapter();
        public List<ExecActionModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.Method).ToList();
        }
        public ExecActionModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ExecActionModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ExecActionModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ExecActionModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ExecActionParamBusinessComponent : IBusinessComponent<ExecActionParamModel>
    {
        private ExecActionParamAdapter adapter = new ExecActionParamAdapter();
        public List<ExecActionParamModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ExecActionID).ToList();
        }
        public ExecActionParamModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ExecActionParamModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ExecActionParamModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ExecActionParamModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class GroupBusinessComponent : IBusinessComponent<GroupModel>
    {
        private GroupAdapter adapter = new GroupAdapter();
        public List<GroupModel> GetList()
        {
            return adapter.GetList();
        }
        public GroupModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(GroupModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(GroupModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(GroupModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class GroupRolePairBusinessComponent : IBusinessComponent<GroupRolePairModel>
    {
        private GroupRolePairAdapter adapter = new GroupRolePairAdapter();
        public List<GroupRolePairModel> GetList()
        {
            return adapter.GetList();
        }
        public GroupRolePairModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(GroupRolePairModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(GroupRolePairModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(GroupRolePairModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class LocationLevelBusinessComponent : IBusinessComponent<LocationLevelModel>
    {
        private LocationLevelAdapter adapter = new LocationLevelAdapter();
        public List<LocationLevelModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.LocationLevelID).ToList();
        }
        public LocationLevelModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(LocationLevelModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(LocationLevelModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(LocationLevelModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class LocationTreeBusinessComponent : IBusinessComponent<LocationTreeModel>
    {
        private LocationTreeAdapter adapter = new LocationTreeAdapter();
        public List<LocationTreeModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.LocationTitle).ToList();
        }
        public LocationTreeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(LocationTreeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(LocationTreeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(LocationTreeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class MediaContentTypeBusinessComponent : IBusinessComponent<MediaContentTypeModel>
    {
        private MediaContentTypeAdapter adapter = new MediaContentTypeAdapter();
        public List<MediaContentTypeModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.DisplayText).ToList();
        }
        public MediaContentTypeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(MediaContentTypeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(MediaContentTypeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(MediaContentTypeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class OptionBusinessComponent : IBusinessComponent<OptionModel>
    {
        private OptionAdapter adapter = new OptionAdapter();
        public List<OptionModel> GetList()
        {
            return adapter.GetList();
        }
        public OptionModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(OptionModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(OptionModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(OptionModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class OptionTypeBusinessComponent : IBusinessComponent<OptionTypeModel>
    {
        private OptionTypeAdapter adapter = new OptionTypeAdapter();
        public List<OptionTypeModel> GetList()
        {
            return adapter.GetList();
        }
        public OptionTypeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(OptionTypeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(OptionTypeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(OptionTypeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class OrderDeliveryDetailBusinessComponent : IBusinessComponent<OrderDeliveryDetailModel>
    {
        private OrderDeliveryDetailAdapter adapter = new OrderDeliveryDetailAdapter();
        public List<OrderDeliveryDetailModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.CartOrderID).ToList();
        }
        public OrderDeliveryDetailModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(OrderDeliveryDetailModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(OrderDeliveryDetailModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(OrderDeliveryDetailModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class OrderPaymentBusinessComponent : IBusinessComponent<OrderPaymentModel>
    {
        private OrderPaymentAdapter adapter = new OrderPaymentAdapter();
        public List<OrderPaymentModel> GetList()
        {
            return adapter.GetList().OrderByDescending(o => o.PaymentID).ToList();
        }
        public OrderPaymentModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(OrderPaymentModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(OrderPaymentModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(OrderPaymentModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class OrderStatusBusinessComponent : IBusinessComponent<OrderStatusModel>
    {
        private OrderStatusAdapter adapter = new OrderStatusAdapter();
        public List<OrderStatusModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.OrderStatusTitle).ToList();
        }
        public OrderStatusModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(OrderStatusModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(OrderStatusModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(OrderStatusModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class PackagedProductBusinessComponent : IBusinessComponent<PackagedProductModel>
    {
        private PackagedProductAdapter adapter = new PackagedProductAdapter();
        public List<PackagedProductModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ProductID).ToList();
        }
        public PackagedProductModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(PackagedProductModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(PackagedProductModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(PackagedProductModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class PayModeBusinessComponent : IBusinessComponent<PayModeModel>
    {
        private PayModeAdapter adapter = new PayModeAdapter();
        public List<PayModeModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.PayModeTitle).ToList();
        }
        public PayModeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(PayModeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(PayModeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(PayModeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class PayTypeBusinessComponent : IBusinessComponent<PayTypeModel>
    {
        private PayTypeAdapter adapter = new PayTypeAdapter();
        public List<PayTypeModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.PayTypeTitle).ToList();
        }
        public PayTypeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(PayTypeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(PayTypeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(PayTypeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ProductBusinessComponent : IBusinessComponent<ProductModel>
    {
        private ProductAdapter adapter = new ProductAdapter();
        public List<ProductModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ProductTitle).ToList(); // GetListByPage(1, 4, "");//
        }
        public ProductModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ProductModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ProductModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ProductModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ProductAttributePairBusinessComponent : IBusinessComponent<ProductAttributePairModel>
    {
        private ProductAttributePairAdapter adapter = new ProductAttributePairAdapter();
        public List<ProductAttributePairModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ProductID).ToList();
        }
        public ProductAttributePairModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ProductAttributePairModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ProductAttributePairModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ProductAttributePairModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ProductMediaDetailBusinessComponent : IBusinessComponent<ProductMediaDetailModel>
    {
        private ProductMediaDetailAdapter adapter = new ProductMediaDetailAdapter();
        public List<ProductMediaDetailModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ProductID).ToList();
        }
        public ProductMediaDetailModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ProductMediaDetailModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ProductMediaDetailModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ProductMediaDetailModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ProductTypeBusinessComponent : IBusinessComponent<ProductTypeModel>
    {
        private ProductTypeAdapter adapter = new ProductTypeAdapter();
        public List<ProductTypeModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ProductTypeTitle).ToList();
        }
        public ProductTypeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ProductTypeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ProductTypeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ProductTypeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ProductViewBusinessComponent : IBusinessComponent<ProductViewModel>
    {
        private ProductViewAdapter adapter = new ProductViewAdapter();
        public List<ProductViewModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ProductViewTitle).ToList();
        }
        public ProductViewModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ProductViewModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ProductViewModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ProductViewModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ProductViewItemBusinessComponent : IBusinessComponent<ProductViewItemModel>
    {
        private ProductViewItemAdapter adapter = new ProductViewItemAdapter();
        public List<ProductViewItemModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ProductViewID).ToList();
        }
        public ProductViewItemModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ProductViewItemModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ProductViewItemModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ProductViewItemModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ProfileBusinessComponent : IBusinessComponent<ProfileModel>
    {
        private ProfileAdapter adapter = new ProfileAdapter();
        public List<ProfileModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.UserID).ToList();
        }
        public ProfileModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ProfileModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ProfileModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ProfileModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ProfileVerificationBusinessComponent : IBusinessComponent<ProfileVerificationModel>
    {
        private ProfileVerificationAdapter adapter = new ProfileVerificationAdapter();
        public List<ProfileVerificationModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ProfileID).ToList();
        }
        public ProfileVerificationModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ProfileVerificationModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ProfileVerificationModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ProfileVerificationModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class RoleBusinessComponent : IBusinessComponent<RoleModel>
    {
        private RoleAdapter adapter = new RoleAdapter();
        public List<RoleModel> GetList()
        {
            return adapter.GetList();
        }
        public RoleModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(RoleModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(RoleModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(RoleModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class RoleOptionPairBusinessComponent : IBusinessComponent<RoleOptionPairModel>
    {
        private RoleOptionPairAdapter adapter = new RoleOptionPairAdapter();
        public List<RoleOptionPairModel> GetList()
        {
            return adapter.GetList();
        }
        public RoleOptionPairModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(RoleOptionPairModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(RoleOptionPairModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(RoleOptionPairModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ScheduleBusinessComponent : IBusinessComponent<ScheduleModel>
    {
        private ScheduleAdapter adapter = new ScheduleAdapter();
        public List<ScheduleModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.ScheduleID).ToList();
        }
        public ScheduleModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ScheduleModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ScheduleModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ScheduleModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class StateMachineBusinessComponent : IBusinessComponent<StateMachineModel>
    {
        private StateMachineAdapter adapter = new StateMachineAdapter();
        public List<StateMachineModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.StateMachineID).ToList();
        }
        public StateMachineModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(StateMachineModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(StateMachineModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(StateMachineModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class StateMachineStateBusinessComponent : IBusinessComponent<StateMachineStateModel>
    {
        private StateMachineStateAdapter adapter = new StateMachineStateAdapter();
        public List<StateMachineStateModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.StateMachineStateID).ToList();
        }
        public StateMachineStateModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(StateMachineStateModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(StateMachineStateModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(StateMachineStateModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class StatusBusinessComponent : IBusinessComponent<StatusModel>
    {
        private StatusAdapter adapter = new StatusAdapter();
        public List<StatusModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.StatusName).ToList();
        }
        public StatusModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(StatusModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(StatusModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(StatusModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class SupplierBusinessComponent : IBusinessComponent<SupplierModel>
    {
        private SupplierAdapter adapter = new SupplierAdapter();
        public List<SupplierModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.StatusID).ToList();
        }
        public SupplierModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(SupplierModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(SupplierModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(SupplierModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }
    public partial class SupplierDeliveryOptionPairBusinessComponent : IBusinessComponent<SupplierDeliveryOptionPairModel>
    {
        private SupplierDeliveryOptionPairAdapter adapter = new SupplierDeliveryOptionPairAdapter();
        public List<SupplierDeliveryOptionPairModel> GetList()
        {
            return adapter.GetList(); //.OrderBy(o => o.StatusID).ToList();
        }
        public SupplierDeliveryOptionPairModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(SupplierDeliveryOptionPairModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(SupplierDeliveryOptionPairModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(SupplierDeliveryOptionPairModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class TaxBusinessComponent : IBusinessComponent<TaxModel>
    {
        private TaxAdapter adapter = new TaxAdapter();
        public List<TaxModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.TaxID).ToList();
        }
        public TaxModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(TaxModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(TaxModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(TaxModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class TaxTypeBusinessComponent : IBusinessComponent<TaxTypeModel>
    {
        private TaxTypeAdapter adapter = new TaxTypeAdapter();
        public List<TaxTypeModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.TaxTypeTitle).ToList();
        }
        public TaxTypeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(TaxTypeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(TaxTypeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(TaxTypeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class UserBusinessComponent : IBusinessComponent<UserModel>
    {
        private UserAdapter adapter = new UserAdapter();
        public List<UserModel> GetList()
        {
            return adapter.GetList();
        }
        public UserModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(UserModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(UserModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(UserModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class UserTypeBusinessComponent : IBusinessComponent<UserTypeModel>
    {
        private UserTypeAdapter adapter = new UserTypeAdapter();
        public List<UserTypeModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.UserTypeTitle).ToList();
        }
        public UserTypeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(UserTypeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(UserTypeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(UserTypeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class AttributeTypeBusinessComponent : IBusinessComponent<AttributeTypeModel>
    {
        private AttributeTypeAdapter adapter = new AttributeTypeAdapter();
        public List<AttributeTypeModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.AttributeTypeTitle).ToList();
        }
        public AttributeTypeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(AttributeTypeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(AttributeTypeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(AttributeTypeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class DocumentTypeBusinessComponent : IBusinessComponent<DocumentTypeModel>
    {
        private DocumentTypeAdapter adapter = new DocumentTypeAdapter();
        public List<DocumentTypeModel> GetList()
        {
            return adapter.GetList().OrderBy(o => o.DocumentTypeTitle).ToList();
        }
        public DocumentTypeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(DocumentTypeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(DocumentTypeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(DocumentTypeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class AddressContactInfoPairBusinessComponent : IBusinessComponent<AddressContactInfoPairModel>
    {
        private AddressContactInfoPairAdapter adapter = new AddressContactInfoPairAdapter();
        public List<AddressContactInfoPairModel> GetList()
        {
            return adapter.GetList();
        }
        public AddressContactInfoPairModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(AddressContactInfoPairModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(AddressContactInfoPairModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(AddressContactInfoPairModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ContactInfoBusinessComponent : IBusinessComponent<ContactInfoModel>
    {
        private ContactInfoAdapter adapter = new ContactInfoAdapter();
        public List<ContactInfoModel> GetList()
        {
            return adapter.GetList();
        }
        public ContactInfoModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ContactInfoModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ContactInfoModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ContactInfoModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class ContactTypeBusinessComponent : IBusinessComponent<ContactTypeModel>
    {
        private ContactTypeAdapter adapter = new ContactTypeAdapter();
        public List<ContactTypeModel> GetList()
        {
            return adapter.GetList();
        }
        public ContactTypeModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(ContactTypeModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(ContactTypeModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(ContactTypeModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class CountryBusinessComponent : IBusinessComponent<CountryModel>
    {
        private CountryAdapter adapter = new CountryAdapter();
        public List<CountryModel> GetList()
        {
            return adapter.GetList();
        }
        public CountryModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(CountryModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(CountryModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(CountryModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class CurrencyBusinessComponent : IBusinessComponent<CurrencyModel>
    {
        private CurrencyAdapter adapter = new CurrencyAdapter();
        public List<CurrencyModel> GetList()
        {
            return adapter.GetList();
        }
        public CurrencyModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(CurrencyModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(CurrencyModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(CurrencyModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class LanguageBusinessComponent : IBusinessComponent<LanguageModel>
    {
        private LanguageAdapter adapter = new LanguageAdapter();
        public List<LanguageModel> GetList()
        {
            return adapter.GetList();
        }
        public LanguageModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(LanguageModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(LanguageModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(LanguageModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class LocaleStringResourceBusinessComponent : IBusinessComponent<LocaleStringResourceModel>
    {
        private LocaleStringResourceAdapter adapter = new LocaleStringResourceAdapter();
        public List<LocaleStringResourceModel> GetList()
        {
            return adapter.GetList();
        }
        public LocaleStringResourceModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(LocaleStringResourceModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(LocaleStringResourceModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(LocaleStringResourceModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class LocalizedPropertyBusinessComponent : IBusinessComponent<LocalizedPropertyModel>
    {
        private LocalizedPropertyAdapter adapter = new LocalizedPropertyAdapter();
        public List<LocalizedPropertyModel> GetList()
        {
            return adapter.GetList();
        }
        public LocalizedPropertyModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(LocalizedPropertyModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(LocalizedPropertyModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(LocalizedPropertyModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class LogBusinessComponent : IBusinessComponent<LogModel>
    {
        private LogAdapter adapter = new LogAdapter();
        public List<LogModel> GetList()
        {
            return adapter.GetList();
        }
        public LogModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(LogModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(LogModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(LogModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class OrderStatusMapBusinessComponent : IBusinessComponent<OrderStatusMapModel>
    {
        private OrderStatusMapAdapter adapter = new OrderStatusMapAdapter();
        public List<OrderStatusMapModel> GetList()
        {
            return adapter.GetList();
        }
        public OrderStatusMapModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(OrderStatusMapModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(OrderStatusMapModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(OrderStatusMapModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class PaymentBusinessComponent : IBusinessComponent<PaymentModel>
    {
        private PaymentAdapter adapter = new PaymentAdapter();
        public List<PaymentModel> GetList()
        {
            return adapter.GetList();
        }
        public PaymentModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(PaymentModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(PaymentModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(PaymentModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class PayOptionMatrixBusinessComponent : IBusinessComponent<PayOptionMatrixModel>
    {
        private PayOptionMatrixAdapter adapter = new PayOptionMatrixAdapter();
        public List<PayOptionMatrixModel> GetList()
        {
            return adapter.GetList();
        }
        public PayOptionMatrixModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(PayOptionMatrixModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(PayOptionMatrixModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(PayOptionMatrixModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class SearchTermBusinessComponent : IBusinessComponent<SearchTermModel>
    {
        private SearchTermAdapter adapter = new SearchTermAdapter();
        public List<SearchTermModel> GetList()
        {
            return adapter.GetList();
        }
        public SearchTermModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(SearchTermModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(SearchTermModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(SearchTermModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }

    public partial class VerificationStatusBusinessComponent : IBusinessComponent<VerificationStatusModel>
    {
        private VerificationStatusAdapter adapter = new VerificationStatusAdapter();
        public List<VerificationStatusModel> GetList()
        {
            return adapter.GetList();
        }
        public VerificationStatusModel GetById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? Add(VerificationStatusModel model)
        {
            return adapter.Add(model);
        }
        public bool Update(VerificationStatusModel model)
        {
            return adapter.Update(model);
        }
        public bool Delete(VerificationStatusModel model)
        {
            return adapter.Delete(model);
        }
        public bool Delete(long Id)
        {
            return adapter.Delete(Id);
        }
    }
}
