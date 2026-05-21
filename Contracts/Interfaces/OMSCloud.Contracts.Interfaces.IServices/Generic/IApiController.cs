using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OMSCloud.Contracts.Interfaces.IServices
{
    public interface IApiController<TModel>
    {
        IHttpActionResult /*List<TModel>*/ GetList();
        IHttpActionResult /*TModel*/ GetById(long id);
        IHttpActionResult /*bool*/ Post(TModel model);
        IHttpActionResult /*long?*/ Put(TModel model);
        IHttpActionResult /*bool*/ Delete(TModel model);
        IHttpActionResult /*bool*/ Delete(long Id);
    }
}
