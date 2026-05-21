using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Interfaces
{
    public interface IBusinessComponent<TModel> where TModel : BaseModel
    {
        List<TModel> GetList();
        TModel GetById(long Id);
        long? Add(TModel model);
        bool Update(TModel model);
        bool Delete(TModel model);
        bool Delete(long Id);
    }
}
