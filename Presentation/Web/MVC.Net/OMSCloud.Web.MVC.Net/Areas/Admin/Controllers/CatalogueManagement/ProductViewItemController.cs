using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class ProductViewItemController : BaseMvcController
    {
        #region DataMember's

        private ProductViewItemControllerProxy proxy = new ProductViewItemControllerProxy();
        private ProductViewControllerProxy productViewProxy = new ProductViewControllerProxy();
        private ProductControllerProxy productProxy = new ProductControllerProxy();
        private ProductMediaDetailControllerProxy pMediaProxy = new ProductMediaDetailControllerProxy();

        #endregion

        // GET: Admin/ProductViewItem
        public ActionResult Index()
        {

            var resutl = from pvi in proxy.GetList()
                         join pro in productProxy.GetList() on pvi.ProductID equals pro.ProductID
                         join pv in productViewProxy.GetList() on pvi.ProductViewID equals pv.ProductViewID
                         join pmp in pMediaProxy.GetList() on pvi.ProductMediaID equals pmp.ProductMediaID
                         select new ProductViewItemModel
                         {
                             ProductID = pvi.ProductID,
                             ProductName = pro.ProductTitle,
                             ProductMediaID = pvi.ProductMediaID,
                             ProductMediaName = pmp.ProductMediaTitle,
                             ProductViewID = pvi.ProductViewID,
                             ProductViewName = pv.ProductViewTitle,
                             ProductViewProductID = pvi.ProductViewProductID
                         };
            return View(resutl.ToList());
        }

        // GET: Admin/ProductViewItem/Details/5
        public ActionResult Details(long Id)
        {
            var result = proxy.GetById(Id);
            result.ProductName = (from pro in productProxy.GetList()
                                  where result.ProductID == pro.ProductID
                                  select pro.ProductTitle).First();
            result.ProductMediaName = (from pmp in pMediaProxy.GetList()
                                       where result.ProductMediaID == pmp.ProductMediaID
                                       select pmp.ProductMediaTitle).First();
            result.ProductViewName = (from pv in productViewProxy.GetList()
                                      where pv.ProductViewID == result.ProductViewID
                                      select pv.ProductViewTitle).First();
            return View(result);
        }

        // GET: Admin/ProductViewItem/Create
        public ActionResult Create()
        {
            PrepareViewBag();

            return View();
        }

        // POST: Admin/ProductViewItem/Create
        [HttpPost]
        public ActionResult Create(ProductViewItemModel model, FormCollection collection)
        {
            try
            {
                proxy.Put(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }

        // GET: Admin/ProductViewItem/Edit/5
        public ActionResult Edit(long Id)
        {
            PrepareViewBag();
            return View(proxy.GetById(Id));
        }

        private void PrepareViewBag()
        {
            ViewBag.productName = new SelectList(productProxy.GetList(), "ProductID", "ProductTitle");
            ViewBag.productMedia = new SelectList(pMediaProxy.GetList(), "ProductMediaID", "ProductMediaTitle");
            ViewBag.productView = new SelectList(productViewProxy.GetList(), "ProductViewID", "ProductViewTitle");
        }

        // POST: Admin/ProductViewItem/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductViewItemModel model, FormCollection collection)
        {
            try
            {
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }

        // GET: Admin/ProductViewItem/Delete/5
        public ActionResult Delete(long Id)
        {
            var result = proxy.GetById(Id);
            result.ProductName = (from pro in productProxy.GetList()
                                  where result.ProductID == pro.ProductID
                                  select pro.ProductTitle).First();
            result.ProductMediaName = (from pmp in pMediaProxy.GetList()
                                       where result.ProductMediaID == pmp.ProductMediaID
                                       select pmp.ProductMediaTitle).First();
            result.ProductViewName = (from pv in productViewProxy.GetList()
                                      where pv.ProductViewID == result.ProductViewID
                                      select pv.ProductViewTitle).First();
            return View(result);
        }

        // POST: Admin/ProductViewItem/Delete/5
        [HttpPost]
        public ActionResult Delete(long Id, FormCollection collection)
        {
            try
            {
                proxy.Delete(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


    }
}
