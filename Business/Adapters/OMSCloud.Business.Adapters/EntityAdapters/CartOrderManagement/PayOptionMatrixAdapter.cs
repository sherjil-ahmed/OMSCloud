using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.DataStore.EF.UnitofWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Adapters
{
    public partial class PayOptionMatrixAdapter
    {
        public List<PayOptionMatrixModel> GetPayOptionMatrixList() {
            var result = (from x in uow.OMSContext.PayOptionMatrix
                          //join y in uow.OMSContext.PayMode on x.PayModeID equals y.PayModeID
                          //join z in uow.OMSContext.PayType on x.PayTypeID equals z.PayTypeID
                          select new PayOptionMatrixModel {
                              PayOptionMatrixID = x.PayOptionMatrixID,
                              PayModeID = x.PayModeID,
                              PayModeTitle = x.PayMode.PayModeTitle,
                              PayTypeID = x.PayTypeID,
                              PayTypeTitle = x.PayType.PayTypeTitle,
                              IsSystem = x.IsSystem
                          } ).OrderBy(a => a.PayModeTitle).ToList();
            return result;
        }
        public PayOptionMatrixModel GetPayOptionMatrixById(long Id)
        {
            var result = (from x in uow.OMSContext.PayOptionMatrix
                          where x.PayOptionMatrixID == Id
                          select GetModel(x)).FirstOrDefault();
                          //select new PayOptionMatrixModel
                          //{
                          //    PayOptionMatrixID = x.PayOptionMatrixID,
                          //    PayModeID = x.PayModeID,
                          //    PayModeTitle = x.PayMode.PayModeTitle,
                          //    PayTypeID = x.PayTypeID,
                          //    PayTypeTitle = x.PayType.PayTypeTitle,
                          //    IsSystem = x.IsSystem
                          //}).FirstOrDefault();
            return result;
        }
        public long? GetIdBy(long payTypeId, long payModeId)
        {
            var IdList = (from pom in uow.OMSContext.PayOptionMatrix
                      where pom.PayTypeID == payTypeId && pom.PayModeID == payModeId
                      select pom.PayOptionMatrixID).ToList();
            if (IdList != null && IdList.Count > 0)
                return IdList.First();
            else
                return null;
        }
    }
}