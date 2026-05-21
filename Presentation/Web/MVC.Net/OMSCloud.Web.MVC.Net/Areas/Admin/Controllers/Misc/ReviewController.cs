using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    
    public class ReviewController : BaseMvcController
    {
        CustomerReviewControllerProxy proxy = new CustomerReviewControllerProxy();

        // GET: Admin/Review
        public ActionResult Index(int PageNum = 1, int PageSize_RowCount = 50, string searchString = "", string sortOrder = "")
        {
            ViewBag.SubjectRowIDSortParm = sortOrder == "SubjectRowID" ? "SubjectRowID_desc" : "SubjectRowID";
            ViewBag.SubjectIDSortParm = sortOrder == "SubjectID" ? "SubjectID_desc" : "SubjectID";
            ViewBag.ReviewTextSortParm = sortOrder == "ReviewText" ? "ReviewText_desc" : "ReviewText";
            ViewBag.RatingSortParm = sortOrder == "Rating" ? "Rating_desc" : "Rating";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "Status_desc" : "Status";
            ViewBag.ReviewerNameSortParm = sortOrder == "ReviewerName" ? "ReviewerName_desc" : "ReviewerName";
            ViewBag.CreatedOnSortParm = sortOrder == "CreatedOn" ? "CreatedOn_desc" : "CreatedOn";

            var result = proxy.GetCustomerReviewList(PageNum, PageSize_RowCount, searchString, sortOrder);

            ViewBag.PageCount = result.NumberOfPages; ;
            ViewBag.CurrentPageIndex = PageNum;
            ViewBag.SearchString = searchString;
            ViewBag.SortOrder = sortOrder;
            return View(result.ReviewList);
        }
        
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ApproveReviewList(string ReviewCSV)
        {
            if(string.IsNullOrEmpty(ReviewCSV))
                return new JsonResult() { Data = "" };
            var result = proxy.ApproveReviewList(ReviewCSV);
            return new JsonResult() { Data = result };
        }

        // GET: Admin/Review/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Review/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Review/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Review/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Review/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Review/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
    }
}
