using Framework.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.DataStore.EF.OMSModel
{
    public partial class OMSContext : DbContext
    {
        #region CustomSP UseFull
        /// <summary>
        /// Custom Paging Example
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="maximamCount"></param>
        /// <returns></returns>
        public virtual int custom_UserManagment_SelectAllUserWithStatus(Nullable<int> pageNumber, Nullable<int> pageSize, ObjectParameter maximamCount)
        {
            var pageNumberParameter = pageNumber.HasValue ?
                new ObjectParameter("pageNumber", pageNumber) :
                new ObjectParameter("pageNumber", typeof(int));

            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("pageSize", pageSize) :
                new ObjectParameter("pageSize", typeof(int));

            return ObjectContext.ExecuteFunction("sp_UserManagment_SelectAllUserWithStatus", pageNumberParameter, pageSizeParameter, maximamCount);
        }

        public virtual int custom_CartItem_UpdateByCartItemID(Nullable<int> original_CartItemID)
        {
            var original_CartItemIDParameter = original_CartItemID.HasValue ?
                new ObjectParameter("Original_CartItemID", original_CartItemID) :
                new ObjectParameter("Original_CartItemID", typeof(int));

            return ObjectContext.ExecuteFunction("sp_CartItem_UpdateByCartItemID", original_CartItemIDParameter);
        }

        public virtual int custom_CartOrder_UpdateByOrderStatusID(Nullable<int> new_OrderStatusID, Nullable<int> original_CartOrderID)
        {
            var new_OrderStatusIDParameter = new_OrderStatusID.HasValue ?
                new ObjectParameter("New_OrderStatusID", new_OrderStatusID) :
                new ObjectParameter("New_OrderStatusID", typeof(int));

            var original_CartOrderIDParameter = original_CartOrderID.HasValue ?
                new ObjectParameter("Original_CartOrderID", original_CartOrderID) :
                new ObjectParameter("Original_CartOrderID", typeof(int));

            return ObjectContext.ExecuteFunction("sp_CartOrder_UpdateByOrderStatusID", new_OrderStatusIDParameter, original_CartOrderIDParameter);
        }
        #endregion CustomSP UseFull

        #region SingleResultSet
        public virtual ObjectResult<sp_Catalogue_AllParentsByChildCategory_Result> sp_Catalogue_AllParentsByChildCategory1(Nullable<int> categoryID)
        {
            var categoryIDParameter = categoryID.HasValue ?
                new ObjectParameter("CategoryID", categoryID) :
                new ObjectParameter("CategoryID", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Catalogue_AllParentsByChildCategory_Result>("sp_Catalogue_AllParentsByChildCategory", categoryIDParameter);
        }
        #endregion SingleResultSet

        #region MultipleResultSet
        public virtual Dictionary<string, List<BaseEntity>> MultipleResultSetSPCallTest(Attribute attribute, int spUserID, ObjectParameter attributeID)
        {

            var cmd = this.Database.Connection.CreateCommand();
            cmd.CommandText = "Attribute_SelectMultipleRecordSet";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(
                    new SqlParameter("SpUserID", spUserID));

                cmd.Parameters.Add(
                    new SqlParameter("attributeID", System.Data.SqlDbType.Int, 10, ParameterDirection.Output, false, 1, 1, "", DataRowVersion.Current, 0));

                this.Database.Connection.Open();
                // Run the sproc 
                var reader = cmd.ExecuteReader();

                // Read Blogs from the first result set
                var attrib = ObjectContext.Translate<Attribute>(reader); //, "Attribute", MergeOption.AppendOnly);

                var resultAttrib = (from a in attrib
                                    select a as BaseEntity).ToList();

                // Move to second result set and read Posts
                reader.NextResult();
                var app = ObjectContext.Translate<AppConfig>(reader);//, "Posts", MergeOption.AppendOnly);

                var resultApp = (from a in app
                                 select a as BaseEntity).ToList();
                Dictionary<string, List<BaseEntity>> resultSets = new Dictionary<string, List<BaseEntity>>();
                resultSets.Add("attributes", resultAttrib);
                resultSets.Add("appConfig", resultApp);

                return resultSets;
            }
            finally
            {
                this.Database.Connection.Close();
            }
        }
        #endregion MultipleResultSet
    }
}
/*
                var ec = new EntityContainer("OMSModel", DataSpace.CSSpace);
            //var container = ObjectContext.MetadataWorkspace.TryGetEntityContainer("OMSModel", DataSpace.CSSpace);
            var properties = new List<MetadataProperty>();

            var payload = new EdmFunctionPayload();
            payload.IsFunctionImport = true;
            var sp = EdmFunction.Create("Attribute_Insert", ObjectContext.DefaultContainerName, DataSpace.CSSpace, payload, properties);
            ec.AddFunctionImport(sp);

            DbRawSqlQuery<int> result = this.Database.SqlQuery<int>("Attribute_Insert", new_AttributeTitleParameter, new_DescriptionParameter, new_DataTypeIDParameter, new_DataTypeSizeParameter, new_DefaultValueParameter, new_IsMandatoryParameter, new_StatusIDParameter, spUserIDParameter, attributeID);

            var xyz = ObjectContext.ExecuteStoreQuery<Attribute>("Attribute_Insert", new_AttributeTitleParameter, new_DescriptionParameter, new_DataTypeIDParameter, new_DataTypeSizeParameter, new_DefaultValueParameter, new_IsMandatoryParameter, new_StatusIDParameter, spUserIDParameter, attributeID);
            //return xyz.Count();

 */
