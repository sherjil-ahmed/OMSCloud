using static OMSCloud.Contracts.Common.CommonUtilities;
using OMSCloud.Contracts.Proxy.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Contracts.Common;
using System.Web.Routing;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{

    public class ProductMediaDetailController : BaseMvcController
    {
        private ProductMediaDetailControllerProxy proxy = new ProductMediaDetailControllerProxy();

        #region Default

        // GET: Admin/ProductMediaDetail
        public ActionResult Index()
        {
            ProductControllerProxy productProxy = new ProductControllerProxy();
            var productModel = productProxy.GetLookupList();

            MediaContentTypeControllerProxy mctProxy = new MediaContentTypeControllerProxy();
            var mctModel = mctProxy.GetList();

            StatusControllerProxy statusProxy = new StatusControllerProxy();
            var statusModel = statusProxy.GetList();

            var model = proxy.GetList();

            var result = (from pmd in model
                          join p in productModel on pmd.ProductID equals p.ProductID
                          join mct in mctModel on pmd.MediaContentTypeID equals mct.MediaContentTypeID
                          join s in statusModel on pmd.StatusID equals s.StatusID
                          select new ProductMediaDetailModel
                          {
                              ProductMediaID = pmd.ProductMediaID,
                              ProductMediaTitle = pmd.ProductMediaTitle,
                              Description = pmd.Description,
                              MediaContentTypeID = pmd.MediaContentTypeID,
                              MediaContentTypeTitle = mct.DisplayText,
                              MediaFilePath = pmd.MediaFilePath,
                              ProductID = pmd.ProductID,
                              ProductTitle = p.ProductTitle,
                              Width = pmd.Width,
                              Height = pmd.Height,
                              TransparencyLevel = pmd.TransparencyLevel,
                              StatusID = pmd.StatusID,
                              StatusTitle = s.StatusName,
                              ApprovedByUserID = pmd.ApprovedByUserID,
                              ApprovedDateTime = pmd.ApprovedDateTime
                          });

            return View(result);
        }

        // GET: Admin/ProductMediaDetail/Details/5
        public ActionResult Details(long Id)
        {
            var model = proxy.GetById(Id);
            model.MediaFilePath = ConvertToWebPath(model.MediaFilePath);
            return View(model);
        }

        // GET: Admin/ProductMediaDetail/Create
        public ActionResult Create()
        {
            PrepareViewBagForCreate();

            return View();
        }


        // POST: Admin/ProductMediaDetail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, ProductMediaDetailModel model)//FormCollection collection)
        {
            try
            {
                var productMediaId = proxy.Put(model);
                if (productMediaId.HasValue)
                {
                    var modelById = proxy.GetById(productMediaId.Value);
                    modelById.MediaFilePath = SaveFile(file, Server.MapPath("~/"), ImageRoute.ProductMediaDetail, productMediaId.Value);
                    if (proxy.Post(modelById))
                    {
                        var list = new RouteValueDictionary();
                        list.Add("Id", productMediaId.Value);
                        return RedirectToAction("Edit", list);
                    }
                }
                PrepareViewBagForCreate();
                return View(model);
            }
            catch
            {
                PrepareViewBagForCreate();
                return View(model);
            }
        }

        // GET: Admin/ProductMediaDetail/Edit/5
        public ActionResult Edit(long Id)
        {
            var model = proxy.GetById(Id);
            PrepareViewBagForEdit(model);
            return View(model);
        }

        // POST: Admin/ProductMediaDetail/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, ProductMediaDetailModel model, FormCollection collection)//long Id, FormCollection collection)
        {
            try
            {
                var ticks = Convert.ToInt64(collection["ModifiedOn.Ticks"].ToString());
                DateTime modifiedOn = new DateTime(Convert.ToInt64(ticks));
                model.ModifiedOn = modifiedOn;
                model.MediaFilePath = SaveFile(file, Server.MapPath("~/"), ImageRoute.ProductMediaDetail, model.ProductMediaID);
                if (proxy.Post(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    PrepareViewBagForEdit(model);
                    return View(model);
                }
            }
            catch
            {
                PrepareViewBagForEdit(model);
                return View(model);
            }
        }

        // GET: Admin/ProductMediaDetail/Delete/5
        public ActionResult Delete(long Id)
        {
            var model = proxy.GetById(Id);
            model.MediaFilePath = ConvertToWebPath(model.MediaFilePath);
            return View(model);
        }

        // POST: Admin/ProductMediaDetail/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion Default

        #region JSON

        private ProductControllerProxy ProductProxy = new ProductControllerProxy();
        private MediaContentTypeControllerProxy MediaContentTypeProxy = new MediaContentTypeControllerProxy();
        private StatusControllerProxy StatusProxy = new StatusControllerProxy();

        private static string mediafile;

        public ActionResult ShowProductMediaDetailList(long Id)
        {
            var result = (from list in proxy.GetList()
                          join Pro in ProductProxy.GetList() on list.ProductID equals Pro.ProductID
                          join MCTP in MediaContentTypeProxy.GetList() on list.MediaContentTypeID equals MCTP.MediaContentTypeID
                          join status in StatusProxy.GetList() on list.StatusID equals status.StatusID
                          where list.ProductID == Id
                          select new ProductMediaDetailModel
                          {
                              MediaContentTypeID = list.MediaContentTypeID,
                              MediaContentTypeTitle = MCTP.DisplayText,
                              StatusID = list.StatusID,
                              StatusTitle = status.StatusName,
                              ProductID = list.ProductID,
                              ProductTitle = Pro.ProductTitle,
                              Description = list.Description,
                              Height = list.Height,
                              Width = list.Width,
                              TransparencyLevel = list.TransparencyLevel,
                              ProductMediaID = list.ProductMediaID,
                              ProductMediaTitle = list.ProductMediaTitle,
                              MediaFilePath = list.MediaFilePath

                          }).ToList();

            return PartialView("partial/_ListAssosiatedMedia", result);
        }

        public ActionResult ShowProductMediaDetailAdd(long Id)
        {
            ViewBag.MediaContentType = new SelectList(MediaContentTypeProxy.GetList(), "MediaContentTypeID", "DisplayText");
            ViewBag.Status = new SelectList(StatusProxy.GetList(), "StatusID", "StatusName");

            return PartialView("partial/_AttachMediaContent");
        }

        [HttpPost]
        public JsonResult CreateMediaContentDetail(HttpPostedFileBase file, ProductMediaDetailModel model, string productId)
        {
            try
            {
                if (file == null && string.IsNullOrEmpty(productId))
                {
                 //   ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
                long Id = -1;
                if (!Int64.TryParse(productId, out Id))
                {
                    //ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
                JsonResult json = new JsonResult();

                var imageModel = new ProductImageModel
                {
                    ProductId = Id,
                    ImageFileName = file.FileName,
                    IsDefault = false,
                };
                var new_mediaId = proxy.PutImage(imageModel);
                if (new_mediaId.HasValue)
                {
                    //proxy.PostImageByProductId(new_mediaId.Value, file);
                    proxy.PostImageByProductId(model.ProductID, file);
                    
                }

                json.Data = mediafile;
                return json;
            }
            catch(Exception ex)
            {
                //ViewBag.Message = "ERROR:" + ex.Message.ToString();
                //return null;
                throw;// ex;
            }
        }

        [HttpPost]
        public JsonResult FileUpload(HttpPostedFileBase file, long Id)
        {
            ViewBag.MediaFilePath = SaveFile(file, Server.MapPath("~/"), ImageRoute.ProductMediaDetail, Id);

            JsonResult json = new JsonResult();

            return json;

        }

        #endregion JSON

        #region Private

        private void PrepareViewBagForCreate()
        {
            ProductControllerProxy productProxy = new ProductControllerProxy();
            var productList = productProxy.GetList();
            ViewBag.ProductList = new SelectList(productList, "ProductID", "ProductTitle");

            MediaContentTypeControllerProxy mctProxy = new MediaContentTypeControllerProxy();
            var mctList = mctProxy.GetList();
            ViewBag.MCTList = new SelectList(mctList, "MediaContentTypeID", "DisplayText");

            StatusControllerProxy statusProxy = new StatusControllerProxy();
            var statusList = statusProxy.GetList();
            ViewBag.statusList = new SelectList(statusList, "statusID", "StatusName");
        }

        private void PrepareViewBagForEdit(ProductMediaDetailModel model)
        {
            ProductControllerProxy productProxy = new ProductControllerProxy();
            var productList = productProxy.GetList();
            ViewBag.ProductList = new SelectList(productList, "ProductID", "ProductTitle");

            MediaContentTypeControllerProxy mctProxy = new MediaContentTypeControllerProxy();
            var mctList = mctProxy.GetList();
            ViewBag.MCTList = new SelectList(mctList, "MediaContentTypeID", "DisplayText");

            StatusControllerProxy statusProxy = new StatusControllerProxy();
            var statusList = statusProxy.GetList();
            ViewBag.statusId = new SelectList(statusList, "statusID", "StatusName");

            ViewBag.MediaFilePath = model.MediaFilePath;

        }

        #endregion Private

    }
}
