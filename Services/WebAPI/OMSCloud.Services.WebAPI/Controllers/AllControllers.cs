using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Services.WebAPIs.Hubs;
using OMSCloud.Services.WebAPIs.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class NotificationController : ApiController
    {
        private NotifyBusinessComponent comp = new NotifyBusinessComponent();
        [ReturnType(DataType = typeof(List<NotifyModel>))]
        public IHttpActionResult GetList()
        {
            var returnData = comp.GetList();

            return Ok<List<NotifyModel>>(returnData);
        }
        [ReturnType(DataType = typeof(NotifyModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<NotifyModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(NotifyModel model)
        {
            var Id = comp.AddNotify(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(NotifyModel model)
        {
            if (comp.UpdateNotify(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(NotifyModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }

    }
    public partial class BankAccountController : ApiController, IBankAccountController
    {
        private BankAccountBusinessComponent comp = new BankAccountBusinessComponent();
        [ReturnType(DataType = typeof(List<BankAccountModel>))]
        public IHttpActionResult GetList()
        {
            var returnData = comp.GetList();

            return Ok<List<BankAccountModel>>(returnData);
        }
        [ReturnType(DataType = typeof(BankAccountModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<BankAccountModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(BankAccountModel model)
        {
            var Id = comp.AddBankAccount(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(BankAccountModel model)
        {
            if (comp.UpdateBankAccount(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(BankAccountModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }
    public partial class ChatController : ApiController, IChatController
    {
        private ChatBusinessComponent comp = new ChatBusinessComponent();
        [ReturnType(DataType = typeof(List<ChatModel>))]
        public IHttpActionResult GetList()
        {

            var returnData = comp.GetList();

            return Ok<List<ChatModel>>(returnData);
        }
        [ReturnType(DataType = typeof(ChatModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ChatModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ChatModel model)
        {
            var Id = comp.AddChat(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ChatModel model)
        {
            if (comp.UpdateChat(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ChatModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class ChatMessageController : ApiController, IChatMessageController
    {
        private ChatMessageBusinessComponent comp = new ChatMessageBusinessComponent();
        [ReturnType(DataType = typeof(List<ChatMessageModel>))]
        public IHttpActionResult GetList()
        {

            var returnData = comp.GetList();

            return Ok<List<ChatMessageModel>>(returnData);
        }
        [ReturnType(DataType = typeof(ChatMessageModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ChatMessageModel>(model);
        }

        [HttpPut]
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult SendMessage(ChatMessageModel model)//PUT
        {
            var Id = comp.SendMessage(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult MarkRead(ChatMessageModel model) //POST
        {
            if (comp.MarkRead(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ChatMessageModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }

        public IHttpActionResult Post(ChatMessageModel model)
        {
            if (comp.MarkRead(model))
                return Ok<bool>(true);
            return Conflict();
        }

        public IHttpActionResult Put(ChatMessageModel model)
        {
            var Id = comp.SendMessage(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
    }

    public partial class CustomerReviewController : ApiController, ICustomerReviewController
    {
        private CustomerReviewBusinessComponent comp = new CustomerReviewBusinessComponent();
        [ReturnType(DataType = typeof(List<CustomerReviewModel>))]
        public IHttpActionResult GetList()
        {

            var returnData = comp.GetList();

            return Ok<List<CustomerReviewModel>>(returnData);
        }
        [ReturnType(DataType = typeof(CustomerReviewModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<CustomerReviewModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(CustomerReviewModel model)
        {
            var Id = comp.AddCustomerReview(model);
            if (Id.HasValue)
            {
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Review, Id.Value);
                return Ok<long?>(Id.Value);
            }
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(CustomerReviewModel model)
        {
            if (comp.UpdateCustomerReview(model))
            {
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Review, model.CustomerReviewID);
                return Ok<bool>(true);
            }
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(CustomerReviewModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class AddressController : ApiController, IAddressController
    {
        private AddressBusinessComponent comp = new AddressBusinessComponent();
        [ReturnType(DataType = typeof(List<AddressModel>))]
        public IHttpActionResult GetList()
        {

            var returnData = comp.GetList();

            return Ok<List<AddressModel>>(returnData);
        }
        [ReturnType(DataType = typeof(AddressModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<AddressModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(AddressModel model)
        {
            if (model == null)
                throw new ArgumentException("address model is null");
            var Id = comp.AddAddress(model);
            if (model != null && Id.HasValue && model.ShopID.HasValue && model.ProvinceID > 0 && model.CityID > 0)
            {
                var shopComp = new SupplierBusinessComponent();
                shopComp.UpdateAddressVisibility(model.ShopID.Value, model.IsBusinessAddressVisible, model.ProvinceID, model.CityID);
                return Ok<long?>(Id.Value);
            }
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            else
                return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(AddressModel model)
        {
            if (model != null && model.ShopID.HasValue)
            {
                var shopComp = new SupplierBusinessComponent();
                shopComp.UpdateAddressVisibility(model.ShopID.Value, model.IsBusinessAddressVisible, model.ProvinceID, model.CityID);
            }
            if (comp.UpdateAddress(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(AddressModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class AddressContactInfoPairController : ApiController, IAddressContactInfoPairController
    {
        private AddressContactInfoPairBusinessComponent comp = new AddressContactInfoPairBusinessComponent();
        [ReturnType(DataType = typeof(List<AddressContactInfoPairModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<AddressContactInfoPairModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(AddressContactInfoPairModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<AddressContactInfoPairModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(AddressContactInfoPairModel model)
        {
            var Id = comp.AddAddressContactInfoPair(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(AddressContactInfoPairModel model)
        {
            if (comp.UpdateAddressContactInfoPair(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(AddressContactInfoPairModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class AddressTypeController : ApiController, IAddressTypeController
    {
        private AddressTypeBusinessComponent comp = new AddressTypeBusinessComponent();
        [ReturnType(DataType = typeof(List<AddressTypeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<AddressTypeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(AddressTypeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<AddressTypeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(AddressTypeModel model)
        {
            var Id = comp.AddAddressType(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(AddressTypeModel model)
        {
            if (comp.UpdateAddressType(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(AddressTypeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class AppConfigController : ApiController, IAppConfigController
    {
        private AppConfigBusinessComponent comp = new AppConfigBusinessComponent();
        [ReturnType(DataType = typeof(List<AppConfigModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<AppConfigModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(AppConfigModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<AppConfigModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(AppConfigModel model)
        {
            var Id = comp.AddAppConfig(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(AppConfigModel model)
        {
            if (comp.UpdateAppConfig(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(AppConfigModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class AttributeController : ApiController, IAttributeController
    {
        private AttributeBusinessComponent comp = new AttributeBusinessComponent();
        [ReturnType(DataType = typeof(List<AttributeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<AttributeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(AttributeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<AttributeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(AttributeModel model)
        {
            var Id = comp.AddAttribute(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(AttributeModel model)
        {
            if (comp.UpdateAttribute(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(AttributeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class AttributeTypeController : ApiController, IAttributeTypeController
    {
        private AttributeTypeBusinessComponent comp = new AttributeTypeBusinessComponent();
        [ReturnType(DataType = typeof(List<AttributeTypeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<AttributeTypeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(AttributeTypeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<AttributeTypeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(AttributeTypeModel model)
        {
            var Id = comp.AddAttributeType(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(AttributeTypeModel model)
        {
            if (comp.UpdateAttributeType(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(AttributeTypeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class BrandController : ApiController, IBrandController
    {
        private BrandBusinessComponent comp = new BrandBusinessComponent();
        [ReturnType(DataType = typeof(List<BrandModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<BrandModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(BrandModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<BrandModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(BrandModel model)
        {
            var Id = comp.AddBrand(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(BrandModel model)
        {
            if (comp.UpdateBrand(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(BrandModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class CartItemController : ApiController, ICartItemController
    {
        private CartItemBusinessComponent comp = new CartItemBusinessComponent();
        [ReturnType(DataType = typeof(List<CartItemModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<CartItemModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(CartItemModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<CartItemModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(CartItemModel model)
        {
            var Id = comp.AddCartItem(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(CartItemModel model)
        {
            if (comp.UpdateCartItem(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(CartItemModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class CartController : ApiController, ICartController
    {
        private CartBusinessComponent comp = new CartBusinessComponent();
        [ReturnType(DataType = typeof(List<CartModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<CartModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(CartModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<CartModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(CartModel model)
        {
            var Id = comp.AddCart(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(CartModel model)
        {
            if (comp.UpdateCart(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(CartModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class OrderController : ApiController, IOrderController
    {
        private OrderBusinessComponent comp = new OrderBusinessComponent();
        [ReturnType(DataType = typeof(List<OrderModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<OrderModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(OrderModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<OrderModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(OrderModel model)
        {
            var Id = comp.AddCartOrder(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }

        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(OrderModel model)
        {
            if (comp.UpdateCartOrder(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(OrderModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class CategoryController : ApiController, ICategoryController
    {
        private CategoryBusinessComponent comp = new CategoryBusinessComponent();
        [ReturnType(DataType = typeof(List<CategoryModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<CategoryModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(CategoryModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<CategoryModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(CategoryModel model)
        {
            var Id = comp.AddCategory(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(CategoryModel model)
        {
            if (comp.UpdateCategory(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(CategoryModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class CategoryAttributePairController : ApiController, ICategoryAttributePairController
    {
        private CategoryAttributePairBusinessComponent comp = new CategoryAttributePairBusinessComponent();
        [ReturnType(DataType = typeof(List<CategoryAttributePairModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<CategoryAttributePairModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(CategoryAttributePairModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<CategoryAttributePairModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(CategoryAttributePairModel model)
        {
                var Id = comp.AddCategoryAttributePair(model);
                if (Id.HasValue)
                    return Ok<long?>(Id.Value);
                return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(CategoryAttributePairModel model)
        {
            if (comp.UpdateCategoryAttributePair(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(CategoryAttributePairModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class CategoryTypeController : ApiController, ICategoryTypeController
    {
        private CategoryTypeBusinessComponent comp = new CategoryTypeBusinessComponent();
        [ReturnType(DataType = typeof(List<CategoryTypeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<CategoryTypeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(CategoryTypeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<CategoryTypeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(CategoryTypeModel model)
        {
            var Id = comp.AddCategoryType(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(CategoryTypeModel model)
        {
            if (comp.UpdateCategoryType(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(CategoryTypeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class ContactInfoController : ApiController, IContactInfoController
    {
        private ContactInfoBusinessComponent comp = new ContactInfoBusinessComponent();
        [ReturnType(DataType = typeof(List<ContactInfoModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<ContactInfoModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(ContactInfoModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ContactInfoModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ContactInfoModel model)
        {
            var Id = comp.AddContactInfo(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ContactInfoModel model)
        {
            if (comp.UpdateContactInfo(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ContactInfoModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class ContactTypeController : ApiController, IContactTypeController
    {
        private ContactTypeBusinessComponent comp = new ContactTypeBusinessComponent();
        [ReturnType(DataType = typeof(List<ContactTypeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<ContactTypeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(ContactTypeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ContactTypeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ContactTypeModel model)
        {
            var Id = comp.AddContactType(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ContactTypeModel model)
        {
            if (comp.UpdateContactType(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ContactTypeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class CountryController : ApiController, ICountryController
    {
        private CountryBusinessComponent comp = new CountryBusinessComponent();
        [ReturnType(DataType = typeof(List<CountryModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<CountryModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(CountryModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<CountryModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(CountryModel model)
        {
            var Id = comp.AddCountry(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(CountryModel model)
        {
            if (comp.UpdateCountry(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(CountryModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class CurrencyController : ApiController, ICurrencyController
    {
        private CurrencyBusinessComponent comp = new CurrencyBusinessComponent();
        [ReturnType(DataType = typeof(List<CurrencyModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<CurrencyModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(CurrencyModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<CurrencyModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(CurrencyModel model)
        {
            var Id = comp.AddCurrency(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(CurrencyModel model)
        {
            if (comp.UpdateCurrency(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(CurrencyModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class DataTypeController : ApiController, IDataTypeController
    {
        private DataTypeBusinessComponent comp = new DataTypeBusinessComponent();
        [ReturnType(DataType = typeof(List<DataTypeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<DataTypeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(DataTypeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<DataTypeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(DataTypeModel model)
        {
            var Id = comp.AddDataType(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(DataTypeModel model)
        {
            if (comp.UpdateDataType(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(DataTypeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class DeliveryOptionController : ApiController, IDeliveryOptionController
    {
        private DeliveryOptionBusinessComponent comp = new DeliveryOptionBusinessComponent();
        [ReturnType(DataType = typeof(List<DeliveryOptionModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<DeliveryOptionModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(DeliveryOptionModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<DeliveryOptionModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(DeliveryOptionModel model)
        {
            var Id = comp.AddDeliveryOption(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(DeliveryOptionModel model)
        {
            if (comp.UpdateDeliveryOption(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(DeliveryOptionModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class DocumentTypeController : ApiController, IDocumentTypeController
    {
        private DocumentTypeBusinessComponent comp = new DocumentTypeBusinessComponent();
        [ReturnType(DataType = typeof(List<DocumentTypeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<DocumentTypeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(DocumentTypeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<DocumentTypeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(DocumentTypeModel model)
        {
            var Id = comp.AddDocumentType(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(DocumentTypeModel model)
        {
            if (comp.UpdateDocumentType(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(DocumentTypeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class ExecActionController : ApiController, IExecActionController
    {
        private ExecActionBusinessComponent comp = new ExecActionBusinessComponent();
        [ReturnType(DataType = typeof(List<ExecActionModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<ExecActionModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(ExecActionModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ExecActionModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ExecActionModel model)
        {
            var Id = comp.AddExecAction(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ExecActionModel model)
        {
            if (comp.UpdateExecAction(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ExecActionModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class ExecActionParamController : ApiController, IExecActionParamController
    {
        private ExecActionParamBusinessComponent comp = new ExecActionParamBusinessComponent();
        [ReturnType(DataType = typeof(List<ExecActionParamModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<ExecActionParamModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(ExecActionParamModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ExecActionParamModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ExecActionParamModel model)
        {
            var Id = comp.AddExecActionParam(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ExecActionParamModel model)
        {
            if (comp.UpdateExecActionParam(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ExecActionParamModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class GroupController : ApiController, IGroupController
    {
        private GroupBusinessComponent comp = new GroupBusinessComponent();
        [ReturnType(DataType = typeof(List<GroupModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<GroupModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(GroupModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<GroupModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(GroupModel model)
        {
            var Id = comp.AddGroup(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(GroupModel model)
        {
            if (comp.UpdateGroup(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(GroupModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class GroupRolePairController : ApiController, IGroupRolePairController
    {
        private GroupRolePairBusinessComponent comp = new GroupRolePairBusinessComponent();
        [ReturnType(DataType = typeof(List<GroupRolePairModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<GroupRolePairModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(GroupRolePairModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<GroupRolePairModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(GroupRolePairModel model)
        {
            var Id = comp.AddGroupRolePair(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(GroupRolePairModel model)
        {
            if (comp.UpdateGroupRolePair(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(GroupRolePairModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class LanguageController : ApiController, ILanguageController
    {
        private LanguageBusinessComponent comp = new LanguageBusinessComponent();
        [ReturnType(DataType = typeof(List<LanguageModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<LanguageModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(LanguageModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<LanguageModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(LanguageModel model)
        {
            var Id = comp.AddLanguage(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(LanguageModel model)
        {
            if (comp.UpdateLanguage(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(LanguageModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class LocaleStringResourceController : ApiController, ILocaleStringResourceController
    {
        private LocaleStringResourceBusinessComponent comp = new LocaleStringResourceBusinessComponent();
        [ReturnType(DataType = typeof(List<LocaleStringResourceModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<LocaleStringResourceModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(LocaleStringResourceModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<LocaleStringResourceModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(LocaleStringResourceModel model)
        {
            var Id = comp.AddLocaleStringResource(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(LocaleStringResourceModel model)
        {
            if (comp.UpdateLocaleStringResource(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(LocaleStringResourceModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class LocalizedPropertyController : ApiController, ILocalizedPropertyController
    {
        private LocalizedPropertyBusinessComponent comp = new LocalizedPropertyBusinessComponent();
        [ReturnType(DataType = typeof(List<LocalizedPropertyModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<LocalizedPropertyModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(LocalizedPropertyModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<LocalizedPropertyModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(LocalizedPropertyModel model)
        {
            var Id = comp.AddLocalizedProperty(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(LocalizedPropertyModel model)
        {
            if (comp.UpdateLocalizedProperty(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(LocalizedPropertyModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class LocationLevelController : ApiController, ILocationLevelController
    {
        private LocationLevelBusinessComponent comp = new LocationLevelBusinessComponent();
        [ReturnType(DataType = typeof(List<LocationLevelModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<LocationLevelModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(LocationLevelModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<LocationLevelModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(LocationLevelModel model)
        {
            var Id = comp.AddLocationLevel(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(LocationLevelModel model)
        {
            if (comp.UpdateLocationLevel(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(LocationLevelModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class LocationTreeController : ApiController, ILocationTreeController
    {
        private LocationTreeBusinessComponent comp = new LocationTreeBusinessComponent();
        [ReturnType(DataType = typeof(List<LocationTreeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<LocationTreeModel>>(comp.GetList());
        }

        [ReturnType(DataType = typeof(List<LocationTreeModel>))]
        public IHttpActionResult GetLocationTreeList()
        {
            return Ok<List<LocationTreeModel>>(comp.GetLocationTreeList());
        }

        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult GetLocationTreeByLocationId(long Id)
        {
            return Ok<LocationModel>(comp.GetLocationTreeByLocationId(Id));
        }
        [ReturnType(DataType = typeof(LocationTreeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<LocationTreeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(LocationTreeModel model)
        {
            var Id = comp.AddLocationTree(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(LocationTreeModel model)
        {
            if (comp.UpdateLocationTree(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(LocationTreeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class LogController : ApiController, ILogController
    {
        private LogBusinessComponent comp = new LogBusinessComponent();
        [ReturnType(DataType = typeof(List<LogModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<LogModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(LogModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<LogModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(LogModel model)
        {
            var Id = comp.AddLog(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(LogModel model)
        {
            if (comp.UpdateLog(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(LogModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class MediaContentTypeController : ApiController, IMediaContentTypeController
    {
        private MediaContentTypeBusinessComponent comp = new MediaContentTypeBusinessComponent();
        [ReturnType(DataType = typeof(List<MediaContentTypeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<MediaContentTypeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(MediaContentTypeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<MediaContentTypeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(MediaContentTypeModel model)
        {
            var Id = comp.AddMediaContentType(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(MediaContentTypeModel model)
        {
            if (comp.UpdateMediaContentType(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(MediaContentTypeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class OptionController : ApiController, IOptionController
    {
        private OptionBusinessComponent comp = new OptionBusinessComponent();
        [ReturnType(DataType = typeof(List<OptionModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<OptionModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(OptionModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<OptionModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(OptionModel model)
        {
            var Id = comp.AddOption(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(OptionModel model)
        {
            if (comp.UpdateOption(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(OptionModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class OptionTypeController : ApiController, IOptionTypeController
    {
        private OptionTypeBusinessComponent comp = new OptionTypeBusinessComponent();
        [ReturnType(DataType = typeof(List<OptionTypeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<OptionTypeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(OptionTypeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<OptionTypeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(OptionTypeModel model)
        {
            var Id = comp.AddOptionType(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(OptionTypeModel model)
        {
            if (comp.UpdateOptionType(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(OptionTypeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class OrderDeliveryDetailController : ApiController, IOrderDeliveryDetailController
    {
        private OrderDeliveryDetailBusinessComponent comp = new OrderDeliveryDetailBusinessComponent();
        [ReturnType(DataType = typeof(List<OrderDeliveryDetailModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<OrderDeliveryDetailModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(OrderDeliveryDetailModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<OrderDeliveryDetailModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(OrderDeliveryDetailModel model)
        {
            var Id = comp.AddOrderDeliveryDetail(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(OrderDeliveryDetailModel model)
        {
            if (comp.UpdateOrderDeliveryDetail(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(OrderDeliveryDetailModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class OrderPaymentController : ApiController, IOrderPaymentController
    {
        private OrderPaymentBusinessComponent comp = new OrderPaymentBusinessComponent();
        [ReturnType(DataType = typeof(List<OrderPaymentModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<OrderPaymentModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(OrderPaymentModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<OrderPaymentModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(OrderPaymentModel model)
        {
            var Id = comp.AddOrderPayment(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(OrderPaymentModel model)
        {
            if (comp.UpdateOrderPayment(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(OrderPaymentModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class OrderStatusController : ApiController, IOrderStatusController
    {
        private OrderStatusBusinessComponent comp = new OrderStatusBusinessComponent();
        [ReturnType(DataType = typeof(List<OrderStatusModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<OrderStatusModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(OrderStatusModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<OrderStatusModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(OrderStatusModel model)
        {
            var Id = comp.AddOrderStatus(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(OrderStatusModel model)
        {
            if (comp.UpdateOrderStatus(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(OrderStatusModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class OrderStatusMapController : ApiController, IOrderStatusMapController
    {
        private OrderStatusMapBusinessComponent comp = new OrderStatusMapBusinessComponent();
        [ReturnType(DataType = typeof(List<OrderStatusMapModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<OrderStatusMapModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(OrderStatusMapModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<OrderStatusMapModel>(model);
        }
        [ReturnType(DataType = typeof(OrderStatusMapModel))]
        public IHttpActionResult GetOrderStatusMapById(long Id)
        {
            var model = comp.GetOrderStatusMapById(Id);
            if (model == null)
                return NotFound();
            return Ok<OrderStatusMapModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(OrderStatusMapModel model)
        {
            var Id = comp.AddOrderStatusMap(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(OrderStatusMapModel model)
        {
            if (comp.UpdateOrderStatusMap(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(OrderStatusMapModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class PackagedProductController : ApiController, IPackagedProductController
    {
        private PackagedProductBusinessComponent comp = new PackagedProductBusinessComponent();
        [ReturnType(DataType = typeof(List<PackagedProductModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<PackagedProductModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(PackagedProductModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<PackagedProductModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(PackagedProductModel model)
        {
            var Id = comp.AddPackagedProduct(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(PackagedProductModel model)
        {
            if (comp.UpdatePackagedProduct(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(PackagedProductModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class PaymentController : ApiController, IPaymentController
    {
        private PaymentBusinessComponent comp = new PaymentBusinessComponent();
        [ReturnType(DataType = typeof(List<PaymentModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<PaymentModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(PaymentModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<PaymentModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(PaymentModel model)
        {
            var Id = comp.AddPayment(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(PaymentModel model)
        {
            if (comp.UpdatePayment(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(PaymentModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class PayModeController : ApiController, IPayModeController
    {
        private PayModeBusinessComponent comp = new PayModeBusinessComponent();
        [ReturnType(DataType = typeof(List<PayModeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<PayModeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(PayModeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<PayModeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(PayModeModel model)
        {
            var Id = comp.AddPayMode(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(PayModeModel model)
        {
            if (comp.UpdatePayMode(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(PayModeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class PayOptionMatrixController : ApiController, IPayOptionMatrixController
    {
        private PayOptionMatrixBusinessComponent comp = new PayOptionMatrixBusinessComponent();
        [ReturnType(DataType = typeof(List<PayOptionMatrixModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<PayOptionMatrixModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(PayOptionMatrixModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<PayOptionMatrixModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(PayOptionMatrixModel model)
        {
            var Id = comp.AddPayOptionMatrix(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(PayOptionMatrixModel model)
        {
            if (comp.UpdatePayOptionMatrix(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(PayOptionMatrixModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class PayTypeController : ApiController, IPayTypeController
    {
        private PayTypeBusinessComponent comp = new PayTypeBusinessComponent();
        [ReturnType(DataType = typeof(List<PayTypeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<PayTypeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(PayTypeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<PayTypeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(PayTypeModel model)
        {
            var Id = comp.AddPayType(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(PayTypeModel model)
        {
            if (comp.UpdatePayType(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(PayTypeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class ProductController : ApiController, IProductController
    {
        private ProductBusinessComponent comp = new ProductBusinessComponent();
        [ReturnType(DataType = typeof(List<ProductModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<ProductModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(ProductModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ProductModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ProductModel model)
        {
            var Id = comp.AddProduct(model);
            if (Id.HasValue)
            {
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Product, Id.Value);
                return Ok<long?>(Id.Value);
            }
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ProductModel model)
        {
            if (comp.UpdateProduct(model))
            {
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Product, model.ProductID);
                return Ok<bool>(true);
            }
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ProductModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class ProductAttributePairController : ApiController, IProductAttributePairController
    {
        private ProductAttributePairBusinessComponent comp = new ProductAttributePairBusinessComponent();
        [ReturnType(DataType = typeof(List<ProductAttributePairModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<ProductAttributePairModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(ProductAttributePairModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ProductAttributePairModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ProductAttributePairModel model)
        {
            var Id = comp.AddProductAttributePair(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ProductAttributePairModel model)
        {
            if (comp.UpdateProductAttributePair(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ProductAttributePairModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    //public partial class ProductCategoryPairController : ApiController, IProductCategoryPairController
    //{
        //private ProductCategoryPairBusinessComponent comp = new ProductCategoryPairBusinessComponent();
        //[ReturnType(DataType = typeof(List<ProductCategoryPairModel>))]
        //public IHttpActionResult GetList()
        //{
        //    return Ok<List<ProductCategoryPairModel>>(comp.GetList());
        //}
        //[ReturnType(DataType = typeof(ProductCategoryPairModel))]
        //public IHttpActionResult GetById(long Id)
        //{
        //    var model = comp.GetById(Id);
        //    if (model == null)
        //        return NotFound();
        //    return Ok<ProductCategoryPairModel>(model);
        //}
        //[ReturnType(DataType = typeof(long?))]
        //public IHttpActionResult Put(ProductCategoryPairModel model)
        //{
        //    var Id = comp.AddProductCategoryPair(model);
        //    if (Id.HasValue)
        //        return Ok<long?>(Id.Value);
        //    return Conflict();
        //}
        //[ReturnType(DataType = typeof(bool))]
        //public IHttpActionResult Post(ProductCategoryPairModel model)
        //{
        //    if (comp.UpdateProductCategoryPair(model))
        //        return Ok<bool>(true);
        //    return Conflict();
        //}
        //[ReturnType(DataType = typeof(bool))]
        //public IHttpActionResult Delete(ProductCategoryPairModel model)
        //{
        //    if (comp.Delete(model))
        //        return Ok<bool>(true);
        //    return Conflict();
        //}
        //[ReturnType(DataType = typeof(bool))]
        //public IHttpActionResult Delete(long Id)
        //{
        //    if (comp.Delete(Id))
        //        return Ok<bool>(true);
        //    return Conflict();
        //}
    //}

    public partial class ProductMediaDetailController : ApiController, IProductMediaDetailController
    {
        private ProductMediaDetailBusinessComponent comp = new ProductMediaDetailBusinessComponent();
        [ReturnType(DataType = typeof(List<ProductMediaDetailModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<ProductMediaDetailModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(ProductMediaDetailModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            model.IsDefault = (model.Description == "default");
            if (model == null)
                return NotFound();
            return Ok<ProductMediaDetailModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ProductMediaDetailModel model)
        {
            var Id = comp.AddProductMediaDetail(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ProductMediaDetailModel model)
        {
            if (model.IsDefault)
                model.Description = "default";
            else
                model.Description = "";
            if (comp.UpdateProductMediaDetail(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ProductMediaDetailModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class ProductTypeController : ApiController, IProductTypeController
    {
        private ProductTypeBusinessComponent comp = new ProductTypeBusinessComponent();
        [ReturnType(DataType = typeof(List<ProductTypeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<ProductTypeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(ProductTypeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ProductTypeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ProductTypeModel model)
        {
            var Id = comp.AddProductType(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ProductTypeModel model)
        {
            if (comp.UpdateProductType(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ProductTypeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class ProductViewController : ApiController, IProductViewController
    {
        private ProductViewBusinessComponent comp = new ProductViewBusinessComponent();
        [ReturnType(DataType = typeof(List<ProductViewModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<ProductViewModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(ProductViewModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ProductViewModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ProductViewModel model)
        {
            var Id = comp.AddProductView(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ProductViewModel model)
        {
            if (comp.UpdateProductView(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ProductViewModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class ProductViewItemController : ApiController, IProductViewItemController
    {
        private ProductViewItemBusinessComponent comp = new ProductViewItemBusinessComponent();
        [ReturnType(DataType = typeof(List<ProductViewItemModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<ProductViewItemModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(ProductViewItemModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ProductViewItemModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ProductViewItemModel model)
        {
            var Id = comp.AddProductViewItem(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ProductViewItemModel model)
        {
            if (comp.UpdateProductViewItem(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ProductViewItemModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class ProfileController : ApiController, IProfileController
    {
        private ProfileBusinessComponent comp = new ProfileBusinessComponent();
        [ReturnType(DataType = typeof(List<ProfileModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<ProfileModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(ProfileModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ProfileModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ProfileModel model)
        {
            var Id = comp.AddProfile(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ProfileModel model)
        {
            var UserViewModel = new UserViewModel(){
                Id = model.UserID,
                PhoneNumber = model.FatherName, //Its not a mistake. Father Name field was not in use. This is Jugar
                Firstname = model.FirstName,
                Lastname = model.LastName,
            };
            var result = ApplicationUserManager.UpdateUserPhone(UserViewModel);
            if (comp.UpdateProfile(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ProfileModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class ProfileVerificationController : ApiController, IProfileVerificationController
    {
        private ProfileVerificationBusinessComponent comp = new ProfileVerificationBusinessComponent();
        [ReturnType(DataType = typeof(List<ProfileVerificationModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<ProfileVerificationModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(ProfileVerificationModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ProfileVerificationModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ProfileVerificationModel model)
        {
            var Id = comp.AddProfileVerification(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ProfileVerificationModel model)
        {
            ProfileVerificationModelForUser modelUser = new ProfileVerificationModelForUser()
            {
                DocumentImagePath = model.DocumentImagePath,
                DocumentNumberByUser = model.DocumentNumberByUser,
                DocumentTypeID = model.DocumentTypeID,
                DocumentTypeTitle = model.DocumentTypeTitle,
                FullName = model.FullName,
                ProfileID = model.RequestedByProfileId,
                VerificationID = model.VerificationID,
            };
            if (comp.UpdateProfileVerification(modelUser))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ProfileVerificationModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class RoleController : ApiController, IRoleController
    {
        private RoleBusinessComponent comp = new RoleBusinessComponent();
        [ReturnType(DataType = typeof(List<RoleModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<RoleModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(RoleModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<RoleModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(RoleModel model)
        {
            var Id = comp.AddRole(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(RoleModel model)
        {
            if (comp.UpdateRole(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(RoleModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class RoleOptionPairController : ApiController, IRoleOptionPairController
    {
        private RoleOptionPairBusinessComponent comp = new RoleOptionPairBusinessComponent();
        [ReturnType(DataType = typeof(List<RoleOptionPairModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<RoleOptionPairModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(RoleOptionPairModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<RoleOptionPairModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(RoleOptionPairModel model)
        {
            var Id = comp.AddRoleOptionPair(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(RoleOptionPairModel model)
        {
            if (comp.UpdateRoleOptionPair(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(RoleOptionPairModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class SearchTermController : ApiController, ISearchTermController
    {
        private SearchTermBusinessComponent comp = new SearchTermBusinessComponent();
        [ReturnType(DataType = typeof(List<SearchTermModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<SearchTermModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(SearchTermModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<SearchTermModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(SearchTermModel model)
        {
            var Id = comp.AddSearchTerm(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(SearchTermModel model)
        {
            if (comp.UpdateSearchTerm(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(SearchTermModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class StateMachineController : ApiController, IStateMachineController
    {
        private StateMachineBusinessComponent comp = new StateMachineBusinessComponent();
        [ReturnType(DataType = typeof(List<StateMachineModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<StateMachineModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(StateMachineModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<StateMachineModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(StateMachineModel model)
        {
            var Id = comp.AddStateMachine(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(StateMachineModel model)
        {
            if (comp.UpdateStateMachine(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(StateMachineModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class StateMachineStateController : ApiController, IStateMachineStateController
    {
        private StateMachineStateBusinessComponent comp = new StateMachineStateBusinessComponent();
        [ReturnType(DataType = typeof(List<StateMachineStateModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<StateMachineStateModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(StateMachineStateModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<StateMachineStateModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(StateMachineStateModel model)
        {
            var Id = comp.AddStateMachineState(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(StateMachineStateModel model)
        {
            if (comp.UpdateStateMachineState(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(StateMachineStateModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class StatusController : ApiController, IStatusController
    {
        private StatusBusinessComponent comp = new StatusBusinessComponent();
        [ReturnType(DataType = typeof(List<StatusModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<StatusModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(StatusModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<StatusModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(StatusModel model)
        {
            var Id = comp.AddStatus(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(StatusModel model)
        {
            if (comp.UpdateStatus(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(StatusModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }
    public partial class ScheduleController : ApiController, IScheduleController
    {
        private ScheduleBusinessComponent comp = new ScheduleBusinessComponent();

        [ReturnType(DataType = typeof(List<ScheduleModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<ScheduleModel>>(comp.GetList());
        }

        [ReturnType(DataType = typeof(ScheduleModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<ScheduleModel>(model);
        }

        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(ScheduleModel model)
        {
            var Id = comp.AddSchedule(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }

        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(ScheduleModel model)
        {
            if (comp.UpdateSchedule(model))
                return Ok<bool>(true);
            return Conflict();
        }

        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(ScheduleModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }

        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class SupplierController : ApiController, ISupplierController
    {
        private SupplierBusinessComponent comp = new SupplierBusinessComponent();
        [ReturnType(DataType = typeof(List<SupplierModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<SupplierModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(SupplierModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<SupplierModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(SupplierModel model)
        {
            var Id = comp.AddSupplier(model);
            if (Id.HasValue)
            {
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Shop, Id.Value);
                return Ok<long?>(Id.Value);
            }
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(SupplierModel model)
        {
            if (comp.UpdateSupplier(model))
            {
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Shop, model.SupplierID);
                return Ok<bool>(true);
            }
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(SupplierModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class SupplierDeliveryOptionPairController : ApiController, ISupplierDeliveryOptionPairController
    {
        private SupplierDeliveryOptionPairBusinessComponent comp = new SupplierDeliveryOptionPairBusinessComponent();
        [ReturnType(DataType = typeof(List<SupplierDeliveryOptionPairModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<SupplierDeliveryOptionPairModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(SupplierDeliveryOptionPairModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<SupplierDeliveryOptionPairModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(SupplierDeliveryOptionPairModel model)
        {
            var Id = comp.AddSupplierDeliveryOptionPair(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(SupplierDeliveryOptionPairModel model)
        {
            if (comp.UpdateSupplierDeliveryOptionPair(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(SupplierDeliveryOptionPairModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }
    public partial class TaxController : ApiController, ITaxController
    {
        private TaxBusinessComponent comp = new TaxBusinessComponent();
        [ReturnType(DataType = typeof(List<TaxModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<TaxModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(TaxModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<TaxModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(TaxModel model)
        {
            var Id = comp.AddTax(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(TaxModel model)
        {
            if (comp.UpdateTax(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(TaxModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class TaxTypeController : ApiController, ITaxTypeController
    {
        private TaxTypeBusinessComponent comp = new TaxTypeBusinessComponent();
        [ReturnType(DataType = typeof(List<TaxTypeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<TaxTypeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(TaxTypeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<TaxTypeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(TaxTypeModel model)
        {
            var Id = comp.AddTaxType(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(TaxTypeModel model)
        {
            if (comp.UpdateTaxType(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(TaxTypeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class UserController : ApiController, IUserController
    {
        private UserBusinessComponent comp = new UserBusinessComponent();
        [ReturnType(DataType = typeof(List<UserModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<UserModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(UserModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<UserModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(UserModel model)
        {
            var Id = comp.AddUser(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(UserModel model)
        {
            if (comp.UpdateUser(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(UserModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class UserTypeController : ApiController, IUserTypeController
    {
        private UserTypeBusinessComponent comp = new UserTypeBusinessComponent();
        [ReturnType(DataType = typeof(List<UserTypeModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<UserTypeModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(UserTypeModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<UserTypeModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(UserTypeModel model)
        {
            var Id = comp.AddUserType(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(UserTypeModel model)
        {
            if (comp.UpdateUserType(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(UserTypeModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }

    public partial class VerificationStatusController : ApiController, IVerificationStatusController
    {
        private VerificationStatusBusinessComponent comp = new VerificationStatusBusinessComponent();
        [ReturnType(DataType = typeof(List<VerificationStatusModel>))]
        public IHttpActionResult GetList()
        {
            return Ok<List<VerificationStatusModel>>(comp.GetList());
        }
        [ReturnType(DataType = typeof(VerificationStatusModel))]
        public IHttpActionResult GetById(long Id)
        {
            var model = comp.GetById(Id);
            if (model == null)
                return NotFound();
            return Ok<VerificationStatusModel>(model);
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Put(VerificationStatusModel model)
        {
            var Id = comp.AddVerificationStatus(model);
            if (Id.HasValue)
                return Ok<long?>(Id.Value);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Post(VerificationStatusModel model)
        {
            if (comp.UpdateVerificationStatus(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(VerificationStatusModel model)
        {
            if (comp.Delete(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Delete(long Id)
        {
            if (comp.Delete(Id))
                return Ok<bool>(true);
            return Conflict();
        }
    }



}