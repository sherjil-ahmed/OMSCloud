using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.DataStore.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Adapters
{
    public partial class PaymentAdapter
    {
        #region Select
        public PaymentModel GetPaymentByOrderId(long OrderId)
        {
            var result = from p in uow.OMSContext.Payment
                         where p.OrderID == OrderId
                         select this.GetModel(p);

            return result.FirstOrDefault();
        }
        public List<PaymentModel> GetPaymentList()
        {
            //DBDeliveryOptionEnum.
            return GetPaymentEnumeration(new SearchModel { }).ToList();
        }

        public double GetOrderSum(SearchModel model)
        {
            DateTime dt = DateTime.Now.AddDays(-1 * Config.NewUserThresholdDays);
            var result = GetPaymentEnumeration(model);
            if (model.SortBy == "1")//New Payments
            {
                result = result.Where(x => x.CreatedOn <= dt);
            }
            //else {/*All Total Payments*/}
            var sum = result.Sum(x => x.Amount);
            return sum;
        }

        public IEnumerable<PaymentModel> GetPaymentEnumeration(SearchModel model)
        {
            var result = (from p in uow.OMSContext.Payment
                          join o in uow.OMSContext.CartOrder on p.OrderID equals o.CartOrderID
                          select new PaymentModel
                          {
                              PaymentID = p.PaymentID,
                              OrderID = p.OrderID,
                              OrderNumber = o.OrderNumber,
                              ActualPayin = o.ActualPayIn,
                              ActualPayout = o.ActualPayout,
                              CalculatedPayin = o.CalculatedPayIn,
                              CalculatedPayout = o.CalculatedPayout,
                              IsPrepaid = !(p.PayTypeID == (long)DBPaymentMethodEnum.Cash),
                              PayTypeID = p.PayTypeID,
                              Amount = p.Amount,
                              IsAmountVerified = p.IsAmountVerified,
                              PaymentGatewayTransactionID = p.PaymentGatewayTransactionID,
                              PaymentToken = p.PaymentToken,
                              CreatedBy = p.CreatedByUserID,
                              CreatedOn = p.CreatedDateTime,
                              ModifiedBy = p.LastModifiedByUserID,
                              ModifiedOn = p.LastModifiedDateTime,
                              ShopProvinceID = o.Supplier.ProvinceID,
                              ShopCityID = o.Supplier.CityID,
                          });
            if (model.ProvinceId.HasValue && model.ProvinceId.Value > 0)
            {
                result = result.Where(x => x.ShopProvinceID == model.ProvinceId.Value);
            }
            if (model.CityId.HasValue && model.CityId.Value > 0)
            {
                result = result.Where(x => x.ShopCityID == model.CityId.Value);
            }

            return result;
        }
        #endregion
    }
}
