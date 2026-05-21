using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using nl = OMSCloud.Contracts.Common.NLogger;
using OMSCloud.DataStore.EF.Factory;
using OMSCloud.DataStore.EF.IRepositories;
using OMSCloud.DataStore.EF.Repositories;
using OMSCloud.DataStore.EF.OMSModel;
using Framework.UnitofWork;
using Framework.Repositories;
using Framework.Entity;
using System.Linq;
using System.Data.Entity.Infrastructure;

namespace OMSCloud.DataStore.EF.UnitofWork
{
    public class OMSUnitOfWork : UnitOfWork<OMSContext>
    {
        public OMSUnitOfWork() : base(DBFactory.Instance)
        {
            //nl.Log.Debug("Constructor OMSCloud.DataStore.EF.UnitofWork.OMSUnitofWork");
        }

        public new OMSRepositoryBase<TEntity> GetGenericRepository<TEntity>() where TEntity : BaseEntity
        {
            return base.GetRepository<OMSRepositoryBase<TEntity>, TEntity>() as OMSRepositoryBase<TEntity>;
        }

        public static OMSUnitOfWork CreateNewInstance
        {
            get
            {
                return new OMSUnitOfWork();
            }
        }

        public OMSContext OMSContext
        {
            get
            {
                return base.DataContext as OMSContext;
            }

        }

        private int Commit_Depriciated()
        {
            #region Depriciated
            //var modifiedItems = base.DataContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified && e.Entity is ConcurrentBaseEntity);
            //string concurrencyVoilatedEntities = string.Empty;
            //foreach (var item in modifiedItems)
            //{
            //    var dbValues = item.GetDatabaseValues();

            //    var modifiedOnDB = dbValues["LastModifiedDateTime"] as DateTime?;
            //    var modifiedOnEntity = (item.Entity as ConcurrentBaseEntity)?.LastModifiedDateTime;

            //    if (IsEqual(modifiedOnDB.Value, modifiedOnEntity.Value))
            //    {
            //        ConcurrentBaseEntity entity = item.Entity as ConcurrentBaseEntity;
            //        entity.LastModifiedDateTime = DateTime.Now;
            //    }
            //    else
            //    {
            //        item.State = EntityState.Detached;
            //        concurrencyVoilatedEntities += item.Entity.GetType().Name + ", ";
            //    }
            //}
            //if (concurrencyVoilatedEntities != string.Empty)
            //    throw new DbUpdateConcurrencyException("Concurrency Voilation Exception occured on entity: " + concurrencyVoilatedEntities);
            #endregion Depriciated
            return base.Commit();
        }

        #region Public Repositories
        public BankAccountRepository BankAccountRepository { get { return base.GetRepository<BankAccountRepository, BankAccount>() as BankAccountRepository; } }
        public ChatRepository ChatRepository { get { return base.GetRepository<ChatRepository, Chat>() as ChatRepository; } }

        public ChatMessageRepository ChatMessageRepository { get { return base.GetRepository<ChatMessageRepository, ChatMessage>() as ChatMessageRepository; } }

        public AddressRepository AddressRepository { get { return base.GetRepository<AddressRepository, Address>() as AddressRepository; } }
        public AddressContactInfoPairRepository AddressContactInfoPairRepository { get { return base.GetRepository<AddressContactInfoPairRepository, AddressContactInfoPair>() as AddressContactInfoPairRepository; } }
        public AddressTypeRepository AddressTypeRepository { get { return base.GetRepository<AddressTypeRepository, AddressType>() as AddressTypeRepository; } }
        public AppConfigRepository AppConfigRepository { get { return base.GetRepository<AppConfigRepository, AppConfig>() as AppConfigRepository; } }
        public AttributeRepository AttributeRepository { get { return base.GetRepository<AttributeRepository, OMSModel.Attribute>() as AttributeRepository; } }
        public AttributeTypeRepository AttributeTypeRepository { get { return base.GetRepository<AttributeTypeRepository, AttributeType>() as AttributeTypeRepository; } }
        public BrandRepository BrandRepository { get { return base.GetRepository<BrandRepository, Brand>() as BrandRepository; } }
        public CartItemRepository CartItemRepository { get { return base.GetRepository<CartItemRepository, CartItem>() as CartItemRepository; } }
        public CartItemAttributePairRepository CartItemAttributePairRepository { get { return base.GetRepository<CartItemAttributePairRepository, CartItemAttributePair>() as CartItemAttributePairRepository; } }
        public CartOrderRepository CartOrderRepository { get { return base.GetRepository<CartOrderRepository, CartOrder>() as CartOrderRepository; } }
        public CategoryRepository CategoryRepository { get { return base.GetRepository<CategoryRepository, Category>() as CategoryRepository; } }
        public CategoryAttributePairRepository CategoryAttributePairRepository { get { return base.GetRepository<CategoryAttributePairRepository, CategoryAttributePair>() as CategoryAttributePairRepository; } }
        public CategoryTypeRepository CategoryTypeRepository { get { return base.GetRepository<CategoryTypeRepository, CategoryType>() as CategoryTypeRepository; } }
        public ContactInfoRepository ContactInfoRepository { get { return base.GetRepository<ContactInfoRepository, ContactInfo>() as ContactInfoRepository; } }
        public ContactTypeRepository ContactTypeRepository { get { return base.GetRepository<ContactTypeRepository, ContactType>() as ContactTypeRepository; } }
        public CountryRepository CountryRepository { get { return base.GetRepository<CountryRepository, Country>() as CountryRepository; } }
        public CurrencyRepository CurrencyRepository { get { return base.GetRepository<CurrencyRepository, Currency>() as CurrencyRepository; } }
        public CustomerReviewRepository CustomerReviewRepository { get { return base.GetRepository<CustomerReviewRepository, CustomerReview>() as CustomerReviewRepository; } }
        public DataTypeRepository DataTypeRepository { get { return base.GetRepository<DataTypeRepository, DataType>() as DataTypeRepository; } }
        public DeliveryOptionRepository DeliveryOptionRepository { get { return base.GetRepository<DeliveryOptionRepository, DeliveryOption>() as DeliveryOptionRepository; } }
        public DocumentTypeRepository DocumentTypeRepository { get { return base.GetRepository<DocumentTypeRepository, DocumentType>() as DocumentTypeRepository; } }
        public ExecActionRepository ExecActionRepository { get { return base.GetRepository<ExecActionRepository, ExecAction>() as ExecActionRepository; } }
        public ExecActionParamRepository ExecActionParamRepository { get { return base.GetRepository<ExecActionParamRepository, ExecActionParam>() as ExecActionParamRepository; } }
        public GroupRepository GroupRepository { get { return base.GetRepository<GroupRepository, Group>() as GroupRepository; } }
        public GroupRolePairRepository GroupRolePairRepository { get { return base.GetRepository<GroupRolePairRepository, GroupRolePair>() as GroupRolePairRepository; } }
        public LanguageRepository LanguageRepository { get { return base.GetRepository<LanguageRepository, Language>() as LanguageRepository; } }
        public LocaleStringResourceRepository LocaleStringResourceRepository { get { return base.GetRepository<LocaleStringResourceRepository, LocaleStringResource>() as LocaleStringResourceRepository; } }
        public LocalizedPropertyRepository LocalizedPropertyRepository { get { return base.GetRepository<LocalizedPropertyRepository, LocalizedProperty>() as LocalizedPropertyRepository; } }
        public LocationLevelRepository LocationLevelRepository { get { return base.GetRepository<LocationLevelRepository, LocationLevel>() as LocationLevelRepository; } }
        public LocationTreeRepository LocationTreeRepository { get { return base.GetRepository<LocationTreeRepository, LocationTree>() as LocationTreeRepository; } }
        public LogRepository LogRepository { get { return base.GetRepository<LogRepository, Log>() as LogRepository; } }
        public MediaContentTypeRepository MediaContentTypeRepository { get { return base.GetRepository<MediaContentTypeRepository, MediaContentType>() as MediaContentTypeRepository; } }
        public OptionRepository OptionRepository { get { return base.GetRepository<OptionRepository, Option>() as OptionRepository; } }
        public OptionTypeRepository OptionTypeRepository { get { return base.GetRepository<OptionTypeRepository, OptionType>() as OptionTypeRepository; } }
        public OrderDeliveryDetailRepository OrderDeliveryDetailRepository { get { return base.GetRepository<OrderDeliveryDetailRepository, OrderDeliveryDetail>() as OrderDeliveryDetailRepository; } }
        public OrderPaymentRepository OrderPaymentRepository { get { return base.GetRepository<OrderPaymentRepository, OrderPayment>() as OrderPaymentRepository; } }
        public OrderStatusRepository OrderStatusRepository { get { return base.GetRepository<OrderStatusRepository, OrderStatus>() as OrderStatusRepository; } }
        public OrderStatusMapRepository OrderStatusMapRepository { get { return base.GetRepository<OrderStatusMapRepository, OrderStatusMap>() as OrderStatusMapRepository; } }
        public PackagedProductRepository PackagedProductRepository { get { return base.GetRepository<PackagedProductRepository, PackagedProduct>() as PackagedProductRepository; } }
        public PaymentRepository PaymentRepository { get { return base.GetRepository<PaymentRepository, Payment>() as PaymentRepository; } }
        public PayModeRepository PayModeRepository { get { return base.GetRepository<PayModeRepository, PayMode>() as PayModeRepository; } }
        public PayOptionMatrixRepository PayOptionMatrixRepository { get { return base.GetRepository<PayOptionMatrixRepository, PayOptionMatrix>() as PayOptionMatrixRepository; } }
        public PayTypeRepository PayTypeRepository { get { return base.GetRepository<PayTypeRepository, PayType>() as PayTypeRepository; } }
        public ProductRepository ProductRepository { get { return base.GetRepository<ProductRepository, Product>() as ProductRepository; } }
        public ProductAttributePairRepository ProductAttributePairRepository { get { return base.GetRepository<ProductAttributePairRepository, ProductAttributePair>() as ProductAttributePairRepository; } }
        public ProductCategoryPairRepository ProductCategoryPairRepository { get { return base.GetRepository<ProductCategoryPairRepository, ProductCategoryPair>() as ProductCategoryPairRepository; } }
        public ProductMediaDetailRepository ProductMediaDetailRepository { get { return base.GetRepository<ProductMediaDetailRepository, ProductMediaDetail>() as ProductMediaDetailRepository; } }
        public ProductTypeRepository ProductTypeRepository { get { return base.GetRepository<ProductTypeRepository, ProductType>() as ProductTypeRepository; } }
        public ProductViewRepository ProductViewRepository { get { return base.GetRepository<ProductViewRepository, ProductView>() as ProductViewRepository; } }
        public ProductViewItemRepository ProductViewItemRepository { get { return base.GetRepository<ProductViewItemRepository, ProductViewItem>() as ProductViewItemRepository; } }
        public ProfileRepository ProfileRepository { get { return base.GetRepository<ProfileRepository, Profile>() as ProfileRepository; } }
        public ProfileVerificationRepository ProfileVerificationRepository { get { return base.GetRepository<ProfileVerificationRepository, ProfileVerification>() as ProfileVerificationRepository; } }
        public RoleRepository RoleRepository { get { return base.GetRepository<RoleRepository, Role>() as RoleRepository; } }
        public RoleOptionPairRepository RoleOptionPairRepository { get { return base.GetRepository<RoleOptionPairRepository, RoleOptionPair>() as RoleOptionPairRepository; } }
        public ScheduleRepository ScheduleRepository { get { return base.GetRepository<ScheduleRepository, Schedule>() as ScheduleRepository; } }
        public SearchTermRepository SearchTermRepository { get { return base.GetRepository<SearchTermRepository, SearchTerm>() as SearchTermRepository; } }
        public StateMachineRepository StateMachineRepository { get { return base.GetRepository<StateMachineRepository, StateMachine>() as StateMachineRepository; } }
        public StateMachineStateRepository StateMachineStateRepository { get { return base.GetRepository<StateMachineStateRepository, StateMachineState>() as StateMachineStateRepository; } }
        public StatusRepository StatusRepository { get { return base.GetRepository<StatusRepository, Status>() as StatusRepository; } }
        public SupplierRepository SupplierRepository { get { return base.GetRepository<SupplierRepository, Supplier>() as SupplierRepository; } }
        public SupplierDeliveryOptionPairRepository SupplierDeliveryOptionPairRepository { get { return base.GetRepository<SupplierDeliveryOptionPairRepository, SupplierDeliveryOptionPair>() as SupplierDeliveryOptionPairRepository; } }
        public TaxRepository TaxRepository { get { return base.GetRepository<TaxRepository, Tax>() as TaxRepository; } }
        public TaxTypeRepository TaxTypeRepository { get { return base.GetRepository<TaxTypeRepository, TaxType>() as TaxTypeRepository; } }
        public UserRepository UserRepository { get { return base.GetRepository<UserRepository, User>() as UserRepository; } }
        public UserTypeRepository UserTypeRepository { get { return base.GetRepository<UserTypeRepository, UserType>() as UserTypeRepository; } }
        public VerificationStatusRepository VerificationStatusRepository { get { return base.GetRepository<VerificationStatusRepository, VerificationStatus>() as VerificationStatusRepository; } }

        #endregion Public Repositories
    }
}
