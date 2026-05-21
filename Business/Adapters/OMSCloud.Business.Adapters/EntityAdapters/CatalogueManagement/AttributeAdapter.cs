using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using oms = OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.DataStore.EF.UnitofWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OMSCloud.Business.Adapters
{
    public partial class AttributeAdapter //: BaseAdapter<DataStore.EF.DBModel.Attribute, AttributeModel>
    {
        #region Select

        public AttributeSearchResultAdminModel GetListByPage(int PageNum, int PageSize_RowCount, string searchString, string sortOrder)
        {
            var attributeResult = new AttributeSearchResultAdminModel();
            var result = GetAttributeEnumeration();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = result.Where(a => a.AttributeTitle.Contains(searchString));
            }
            result = SortAttributes(sortOrder, result);

            #region NewCodePaging
            var total = result.Count();
            if (total > 0)
            {
                var pages = (int)Math.Ceiling((double)total / PageSize_RowCount);
                pages = pages == 0 ? 1 : pages;
                var skip = PageSize_RowCount * (PageNum - 1);
                if (skip > total)
                    skip = total;
                var attributeList = result.Skip(skip).Take(PageSize_RowCount).ToList();
                var MaxPrice = 0.0d;
                var MinPrice = 0.0d;
                attributeResult = new AttributeSearchResultAdminModel
                {
                    NumberOfPages = pages,
                    GrandRecordsCount = total,
                    CurrentPageMinIndex = skip + 1,
                    CurrentPageMaxIndex = attributeList.Count + skip,
                    MaxPrice = MaxPrice,
                    MinPrice = MinPrice,
                    AttributeList = attributeList,
                };
            }
            return attributeResult;

            #endregion
        }

        private static IEnumerable<AttributeModel> SortAttributes(string sortOrder, IEnumerable<AttributeModel> returnattributelist)
        {
            switch (sortOrder)
            {
                case "AttributeName":
                    returnattributelist = returnattributelist.OrderBy(s => s.AttributeTitle);
                    break;
                case "AttributeName_desc":
                    returnattributelist = returnattributelist.OrderByDescending(s => s.AttributeTitle);
                    break;
                case "Description":
                    returnattributelist = returnattributelist.OrderBy(x => x.Description);
                    break;
                case "Description_desc":
                    returnattributelist = returnattributelist.OrderByDescending(x => x.Description);
                    break;
                case "DataType":
                    returnattributelist = returnattributelist.OrderBy(s => s.DataTypeTitle);
                    break;
                case "DataType_desc":
                    returnattributelist = returnattributelist.OrderByDescending(s => s.DataTypeTitle);
                    break;
                case "AttributeType":
                    returnattributelist = returnattributelist.OrderBy(s => s.AttributeTypeTitle);
                    break;
                case "AttributeType_desc":
                    returnattributelist = returnattributelist.OrderByDescending(s => s.AttributeTypeTitle);
                    break;
                case "IsMultiSelect":
                    returnattributelist = returnattributelist.OrderBy(s => s.IsMultiSelect);
                    break;
                case "IsMultiSelect_desc":
                    returnattributelist = returnattributelist.OrderByDescending(s => s.IsMultiSelect);
                    break;
                case "Status":
                    returnattributelist = returnattributelist.OrderBy(s => s.StatusTitle);
                    break;
                case "Status_desc":
                    returnattributelist = returnattributelist.OrderByDescending(s => s.StatusTitle);
                    break;
                case "IsSystem":
                    returnattributelist = returnattributelist.OrderBy(s => s.IsSystem);
                    break;
                case "IsSystem_desc":
                    returnattributelist = returnattributelist.OrderByDescending(s => s.IsSystem);
                    break;
                default:
                    returnattributelist = returnattributelist.OrderBy(s => s.AttributeTitle);
                    break;
            }
            return returnattributelist;
        }

        public List<AttributeModel> GetAttributeList() {
            return GetAttributeEnumeration().ToList();
        }

        public IEnumerable<AttributeModel> GetAttributeEnumeration()
        {

            return (from a in uow.OMSContext.Attribute
                    join s in uow.OMSContext.Status
                    on a.StatusID equals s.StatusID
                    //where attribute.StatusID <= (int)DBStatusEnum.Approved
                    orderby a.AttributeTitle
                    select new AttributeModel
                    {
                        AttributeID = a.AttributeID,
                        AttributeTitle = a.AttributeTitle,
                        AttributeTypeID = a.AttributeTypeID,
                        AttributeTypeTitle = a.AttributeType.AttributeTypeTitle,
                        DataTypeID = a.DataTypeID,
                        DataTypeTitle = a.DataType.FriendlyName + " (" + a.DataType.ClassName + ")",
                        DataTypeSize = a.DataTypeSize,
                        DefaultValue = a.DefaultValue,
                        Description = a.Description,
                        IsMultiSelect = a.IsMultiSelect,
                        IsSystem = a.IsSystem,
                        IsMandatory = a.IsMandatory,
                        StatusID = a.StatusID,
                        StatusTitle = s.StatusName,
                        CreatedBy = a.CreatedByUserID,
                        CreatedOn = a.CreatedDateTime,
                        ModifiedBy = a.LastModifiedByUserID,
                        ModifiedOn = a.LastModifiedDateTime
                    });
        }

        public List<AttributeLookupModel> GetAttributeLookupList()
        {
            var attributeList = (from a in uow.OMSContext.Attribute
                                 where a.StatusID <= (int)DBStatusEnum.Active
                                 orderby a.AttributeTitle
                                 select new AttributeLookupModel
                                 {
                                     AttributeID = a.AttributeID,
                                     AttributeTitle = a.AttributeTitle,
                                     AttributeValue = a.DefaultValue,
                                 }).ToList();
            return attributeList;
        }

        public List<AttributeLookupModel> GetAttributeListNotAssociatedWithCategoryId(long Id)
        {

            var ListByCategoryID = (from ca in uow.OMSContext.CategoryAttributePair
                                    join a in uow.OMSContext.Attribute on ca.AttributeID equals a.AttributeID
                                    where ca.CategoryID == Id
                                    select new AttributeLookupModel
                                    {
                                        AttributeID = ca.AttributeID,
                                        AttributeTitle = ca.Attribute.AttributeTitle
                                    });

            var attributeList = (from a in uow.OMSContext.Attribute
                                 where a.StatusID <= (int)DBStatusEnum.Active
                                 select new AttributeLookupModel
                                 {
                                     AttributeID = a.AttributeID,
                                     AttributeTitle = a.AttributeTitle
                                 });

            var result = attributeList.Except(ListByCategoryID).OrderBy(o => o.AttributeTitle).ToList();

            return result;
        }

        public List<AttributeLookupModel> GetAttributeListNotAssociatedWithProductId(long Id)
        {

            var ListByProductID = (from pa in uow.OMSContext.ProductAttributePair
                                   join a in uow.OMSContext.Attribute on pa.AttributeID equals a.AttributeID
                                   where pa.ProductID == Id
                                   select new AttributeLookupModel
                                   {
                                       AttributeID = pa.AttributeID,
                                       AttributeTitle = pa.Attribute.AttributeTitle
                                   });

            var attributeList = (from a in uow.OMSContext.Attribute
                                 where a.StatusID <= (int)DBStatusEnum.Active
                                 select new AttributeLookupModel
                                 {
                                     AttributeID = a.AttributeID,
                                     AttributeTitle = a.AttributeTitle
                                 });

            var result = attributeList.Except(ListByProductID).OrderBy(o => o.AttributeTitle).ToList();

            return result;
        }

        public AttributeModel GetAttributeById(long Id)
        {
            var attribute = (from a in uow.OMSContext.Attribute
                             join s in uow.OMSContext.Status on a.StatusID equals s.StatusID
                             where a.AttributeID == Id
                             select new AttributeModel
                             {
                                 AttributeID = a.AttributeID,
                                 AttributeTitle = a.AttributeTitle,
                                 AttributeTypeID = a.AttributeTypeID,
                                 AttributeTypeTitle = a.AttributeType.AttributeTypeTitle,
                                 StatusID = a.StatusID,
                                 StatusTitle = s.StatusName,
                                 DataTypeID = a.DataTypeID,
                                 DataTypeSize = a.DataTypeSize,
                                 DataTypeTitle = a.DataType.FriendlyName + " (" + a.DataType.ClassName + ")",
                                 DefaultValue = a.DefaultValue,
                                 IsMandatory = a.IsMandatory,
                                 IsMultiSelect = a.IsMultiSelect,
                                 IsSystem = a.IsSystem,
                                 Description = a.Description,
                                 CreatedBy = a.CreatedByUserID,
                                 CreatedOn = a.CreatedDateTime,
                                 ModifiedBy = a.LastModifiedByUserID,
                                 ModifiedOn = a.LastModifiedDateTime,
                             });
            return attribute.FirstOrDefault();
        }

        public AttributeModel GetAttributeByName(string attributeName)
        {
            var attribute = (from a in uow.OMSContext.Attribute
                             where a.AttributeTitle.ToLower() == attributeName.ToLower()
                             select a).FirstOrDefault();
            AttributeModel attributeModel = GetAttributeModel(attribute);
            return attributeModel;
        }

        public List<AttributeModel> GetAttributesByStatus(DBStatusEnum status)
        {
            var result = from attribute in uow.OMSContext.Attribute
                         where attribute.StatusID == (int)status
                         orderby attribute.AttributeTitle
                         select GetAttributeModel(attribute);
            return result.ToList();
        }
        #endregion Select

        #region Update

        public bool UpdateAttribute(AttributeModel attributeModel)
        {
            try
            {
                var attribute = UpdateConcurrency(GetEntity(attributeModel), attributeModel);
                var recordsCount = uow.OMSContext.Attribute_Update(attribute);

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
        public long? AddAttribute(AttributeModel attributeModel)
        {
            try
            {
                var outParam = new ObjectParameter("AttributeID", typeof(int));

                var attribute = UpdateConcurrency(GetEntity(attributeModel), attributeModel);
                var recordsCount = uow.OMSContext.Attribute_Insert(attribute, outParam);

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

        #region Delete
        public bool DeleteAttribute(AttributeModel attributeModel)
        {
            try
            {
                var attribute = GetAttributeEntity(attributeModel);
                uow.AttributeRepository.Delete(attribute);
                uow.Commit();
                return true;
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

        #region Private
        private AttributeModel GetAttributeModel(oms.Attribute attribute)
        {
            return new AttributeModel
            {
                AttributeID = attribute.AttributeID,
                AttributeTitle = attribute.AttributeTitle,
                DataTypeID = attribute.DataTypeID,
                DataTypeSize = attribute.DataTypeSize,
                DefaultValue = attribute.DefaultValue,
                Description = attribute.Description,
                IsMandatory = attribute.IsMandatory,
                StatusID = attribute.StatusID,
                AttributeTypeID = attribute.AttributeTypeID,
            };
        }
        private oms.Attribute GetAttributeEntity(AttributeModel attributeModel)
        {
            return new oms.Attribute
            {
                AttributeID = attributeModel.AttributeID,
                AttributeTitle = attributeModel.AttributeTitle,
                DataTypeID = attributeModel.DataTypeID,
                DataTypeSize = attributeModel.DataTypeSize,
                DefaultValue = attributeModel.DefaultValue,
                Description = attributeModel.Description,
                IsMandatory = attributeModel.IsMandatory,
                StatusID = attributeModel.StatusID,
                AttributeTypeID = attributeModel.AttributeTypeID
            };
        }
        #endregion Private
    }
}
