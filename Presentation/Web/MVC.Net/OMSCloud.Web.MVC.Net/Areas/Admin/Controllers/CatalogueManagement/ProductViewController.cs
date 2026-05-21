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

    public class ProductViewController : BaseMvcController
    {
        private ProductViewControllerProxy proxy = new ProductViewControllerProxy();
        private StatusControllerProxy statusProxy = new StatusControllerProxy();
        private ProductViewItemControllerProxy productViewItem = new ProductViewItemControllerProxy();
        private ProductControllerProxy productProxy = new ProductControllerProxy();
        private ProductMediaDetailControllerProxy PMDetailProxy = new ProductMediaDetailControllerProxy();
        private ProductMediaDetailControllerProxy pMediaProxy = new ProductMediaDetailControllerProxy();

        public PartialViewResult CreateProductViewItem(long Id)
        {
            ViewBag.productName = new SelectList(productProxy.GetLookupList(), "ProductID", "ProductTitle");
            ViewBag.title = proxy.GetById(Id).ProductViewTitle;

            return PartialView("Partial/_CreateProductViewItem");
        }
        [HttpPost]
        public JsonResult insertNewRecord(ProductViewItemModel model)
        {

            var PreductViewItemInsert = productViewItem.Put(model);
            if (PreductViewItemInsert.HasValue)
            {
                var jsonresult = new JsonResult();
                jsonresult.Data = PreductViewItemInsert.Value;
                return jsonresult;
            }
            return null;
        }

        public PartialViewResult AssocistedProductViewItems()
        {
            var GridResult = (from pvi in productViewItem.GetList()
                              join pro in productProxy.GetList() on pvi.ProductID equals pro.ProductID
                              join pmd in PMDetailProxy.GetList() on pvi.ProductID equals pmd.ProductID
                              join pvm in proxy.GetList() on pvi.ProductViewID equals pvm.ProductViewID
                              //where pvi.ProductID == productID
                              select new ProductViewItemModel
                              {
                                  ProductID = pvi.ProductID,
                                  ProductName = pro.ProductTitle,
                                  ProductViewID = pvi.ProductViewID,
                                  ProductMediaID = pvi.ProductMediaID,
                                  ProductMediaName = pmd.ProductMediaTitle,
                                  ProductViewName = pvm.ProductViewTitle,
                              }).ToList();

            return PartialView("Partial/_GridProductViewItem", GridResult);
        }
        public ActionResult FillProductMedia(int productID)
        {
            var productMediaItems = (from pmv in pMediaProxy.GetList()
                                     join pro in productProxy.GetList() on pmv.ProductID equals pro.ProductID
                                     where pmv.ProductID == productID
                                     select new ProductMediaDetailLookupModel
                                     {
                                         ProductMediaID = pmv.ProductMediaID,
                                         ProductMediaTitle = pmv.ProductMediaTitle
                                     }).ToList();

            return Json(productMediaItems, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FillGridProductID(int productID)
        {
            var GridResult = (from pvi in productViewItem.GetList()
                              join pro in productProxy.GetList() on pvi.ProductID equals pro.ProductID
                              join pmd in PMDetailProxy.GetList() on pvi.ProductID equals pmd.ProductID
                              join pvm in proxy.GetList() on pvi.ProductViewID equals pvm.ProductViewID
                              where pvi.ProductID == productID
                              select new ProductViewItemModel
                              {
                                  ProductID = pvi.ProductID,
                                  ProductName = pro.ProductTitle,
                                  ProductViewID = pvi.ProductViewID,
                                  ProductMediaID = pvi.ProductMediaID,
                                  ProductMediaName = pmd.ProductMediaTitle,
                                  ProductViewName = pvm.ProductViewTitle,

                              }).ToList();
            return Json(GridResult, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductViewItems(long Id)
        {
            var result = (from prov in productViewItem.GetList()
                          join pro in productProxy.GetList() on prov.ProductID equals pro.ProductID
                          join pmp in pMediaProxy.GetList() on prov.ProductMediaID equals pmp.ProductMediaID
                          where prov.ProductViewID == Id
                          select new ProductViewItemModel
                          {
                              ProductMediaName = pmp.ProductMediaTitle,
                              ProductName = pro.ProductTitle,
                              ProductViewName = proxy.GetById(Id).ProductViewTitle
                          }).ToList();

            //ViewBag.CategoryId = id;

            return PartialView("Partial/_ProductViewItem", result);
        }



        // GET: Admin/ProductView
        public ActionResult Index()
        {
            var statusList = statusProxy.GetList();
            var productViewList = proxy.GetList();

            var result = from p in productViewList
                         join s in statusList on p.StatusID equals s.StatusID
                         select new ProductViewModel
                         {
                             ProductViewID = p.ProductViewID,
                             ProductViewTitle = p.ProductViewTitle,
                             Description = p.Description,
                             StatusID = p.StatusID,
                             StatusTitle = s.StatusName,
                             IsSystem = p.IsSystem

                         };

            return View(result.ToList());
        }

        // GET: Admin/ProductView/Details/5
        public ActionResult Details(long Id)
        {
            var statusList = statusProxy.GetList();
            var productViewByID = proxy.GetById(Id);
            productViewByID.StatusTitle = (from s in statusList
                                           where s.StatusID == productViewByID.StatusID
                                           select s.StatusName).First();

            return View(productViewByID);
        }

        // GET: Admin/ProductView/Create
        public ActionResult Create()
        {
            PrepareViewBag();

            return View();
        }

        // POST: Admin/ProductView/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel model, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                proxy.Put(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }

        // GET: Admin/ProductView/Edit/5
        public ActionResult Edit(long Id)
        {
            PrepareViewBag();

            return View(proxy.GetById(Id));
        }

        private void PrepareViewBag()
        {
            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
        }

        // POST: Admin/ProductView/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel model, FormCollection collection, long Id)
        {

            try
            {
                // TODO: Add update logic here
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }

        // GET: Admin/ProductView/Delete/5
        public ActionResult Delete(long Id)
        {
            var statusList = statusProxy.GetList();
            var productViewByID = proxy.GetById(Id);
            productViewByID.StatusTitle = (from s in statusList
                                           where s.StatusID == productViewByID.StatusID
                                           select s.StatusName).First();

            return View(productViewByID);
        }

        // POST: Admin/ProductView/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
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
