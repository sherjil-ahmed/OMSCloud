using Framework.Entity;
using Framework.IRepositories;
using Framework.Repositories;

using OMSCloud.Contracts.Caching;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.DataStore.EF.OMSModel
{
    #region Concurrent
    public partial class Chat : ConcurrentBaseEntity { }
    public partial class Address : ConcurrentBaseEntity { }
    public partial class Attribute : ConcurrentBaseEntity { }
    public partial class Brand : ConcurrentBaseEntity { }
    public partial class CartItem : ConcurrentBaseEntity { }
    public partial class CartOrder : ConcurrentBaseEntity { }
    public partial class Category : ConcurrentBaseEntity { }
    public partial class Currency : ConcurrentBaseEntity { }
    public partial class CustomerReview : ConcurrentBaseEntity { }
    public partial class Log : ConcurrentBaseEntity { }
    public partial class Option : ConcurrentBaseEntity { }
    public partial class Payment : ConcurrentBaseEntity { }
    public partial class Product : ConcurrentBaseEntity { }
    public partial class ProductMediaDetail : ConcurrentBaseEntity { }
    public partial class ProductType : ConcurrentBaseEntity { }
    public partial class RoleOptionPair : ConcurrentBaseEntity { }
    public partial class Schedule : ConcurrentBaseEntity { }
    public partial class User : ConcurrentBaseEntity { }
    public partial class Supplier : ConcurrentBaseEntity { }
    public partial class Tax : ConcurrentBaseEntity { }
    public partial class Notify : ConcurrentBaseEntity { }
    #endregion Concurrent

    #region Non-Concurrent
    public partial class NotificationToken : BaseEntity { }
    public partial class ChatMessage : BaseEntity { }
    public partial class BankAccount : BaseEntity { }    
    public partial class AddressContactInfoPair : BaseEntity { }
    public partial class AddressType : BaseEntity { }
    public partial class AppConfig : BaseEntity { }
    public partial class AttributeType : BaseEntity { }
    public partial class CartItemAttributePair : BaseEntity { }
    public partial class CategoryAttributePair : BaseEntity { }
    public partial class CategoryType : BaseEntity { }
    public partial class ContactInfo : BaseEntity { }
    public partial class ContactType : BaseEntity { }
    public partial class Country : BaseEntity { }
    public partial class DataType : BaseEntity { }
    public partial class DeliveryOption : BaseEntity { }
    public partial class DocumentType : BaseEntity { }
    public partial class ExecAction : BaseEntity { }
    public partial class ExecActionParam : BaseEntity { }
    public partial class Group : BaseEntity { }
    public partial class GroupRolePair : BaseEntity { }
    public partial class Language : BaseEntity { }
    public partial class LocaleStringResource : BaseEntity { }
    public partial class LocalizedProperty : BaseEntity { }
    public partial class LocationLevel : BaseEntity { }
    public partial class LocationTree : BaseEntity { }
    public partial class MediaContentType : BaseEntity { }
    public partial class OptionType : BaseEntity { }
    public partial class OrderDeliveryDetail : BaseEntity { }
    public partial class OrderPayment : BaseEntity { }
    public partial class OrderStatus : BaseEntity { }
    public partial class OrderStatusMap : BaseEntity { }
    public partial class PackagedProduct : BaseEntity { }
    public partial class PayMode : BaseEntity { }
    public partial class PayOptionMatrix : BaseEntity { }
    public partial class PayType : BaseEntity { }
    public partial class ProductAttributePair : BaseEntity { }
    public partial class ProductCategoryPair : BaseEntity { }
    public partial class ProductView : BaseEntity { }
    public partial class ProductViewItem : BaseEntity { }
    public partial class Profile : BaseEntity { }
    public partial class ProfileVerification : BaseEntity { }
    public partial class Role : BaseEntity { }
    public partial class SearchTerm : BaseEntity { }
    public partial class StateMachine : BaseEntity { }
    public partial class StateMachineState : BaseEntity { }
    public partial class Status : BaseEntity { }
    public partial class SupplierDeliveryOptionPair : BaseEntity { }
    public partial class TaxType : BaseEntity { }
    public partial class UserType : BaseEntity { }
    public partial class VerificationStatus : BaseEntity { }
    #endregion Non-Concurrent

    #region ICacheableEntity 
    public partial class Currency : ICacheableEntity { }
    public partial class Status : ICacheableEntity { }
    public partial class TaxType : ICacheableEntity { }
    public partial class UserType : ICacheableEntity { }
    public partial class VerificationStatus : ICacheableEntity { }
    public partial class Schedule : ICacheableEntity { }
    public partial class PayMode : ICacheableEntity { }
    public partial class PayOptionMatrix : ICacheableEntity { }
    public partial class PayType : ICacheableEntity { }
    public partial class OrderStatus : ICacheableEntity { }
    public partial class OrderStatusMap : ICacheableEntity { }
    public partial class LocationLevel : ICacheableEntity { }
    public partial class LocationTree : ICacheableEntity { }
    public partial class MediaContentType : ICacheableEntity { }
    public partial class OptionType : ICacheableEntity { }
    public partial class Language : ICacheableEntity { }
    public partial class ContactType : ICacheableEntity { }
    public partial class Country : ICacheableEntity { }
    public partial class DataType : ICacheableEntity { }
    public partial class DeliveryOption : ICacheableEntity { }
    public partial class DocumentType : ICacheableEntity { }
    public partial class CategoryType : ICacheableEntity { }
    public partial class AddressType : ICacheableEntity { }
    public partial class AppConfig : ICacheableEntity { }
    public partial class AttributeType : ICacheableEntity { }
    public partial class ProductType : ICacheableEntity { }
    public partial class Tax : ICacheableEntity { }
    #endregion ICacheableEntity 
}
