using Microsoft.AspNet.Identity.EntityFramework;
using OMSCloud.Web.MVC.Net.Areas.Security;
using OMSCloud.Web.MVC.Net.Areas.Security.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    [Secure]
    public class AdminController : BaseMvcController
    {
        private SecurityDbContext database = SecurityDbContext.CreateInstance();

        #region USERS
        // GET: Admin
        public ActionResult Index()
        {
            return View(ApplicationUserManager.GetUsers());
        }

        public ViewResult UserDetails(long Id)
        {
            ApplicationUser user = ApplicationUserManager.GetUser(Id);
            SetViewBagData(Id);
            return View(user);
        }

        [HttpGet]
        public ViewResult UserCreate()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserEdit(long Id)
        {
            ApplicationUser user = ApplicationUserManager.GetUser(Id);
            SetViewBagData(Id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit(UserViewModel user)
        {
            ApplicationUserManager.UpdateUser(user);
            return RedirectToAction("UserDetails", new RouteValueDictionary(new { id = user.Id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserDetails(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser _user = database.Users.Where(p => p.Email.ToLower() == user.eMail.ToLower()).FirstOrDefault();
                //database.Entry(_user).Entity.Inactive = user.Inactive;
                database.Entry(_user).Entity.LastModified = System.DateTime.Now;
                database.Entry(_user).State = EntityState.Modified;
                database.SaveChanges();
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult DeleteUserRole(long Id, int userId)
        {
            ApplicationUserManager.RemoveUser4Role(userId, Id);
            return RedirectToAction("Details", "USER", new { id = userId });
        }

        [HttpGet]
        public PartialViewResult filter4Users(string _surname)
        {
            return PartialView("_ListUserTable", GetFilteredUserList(_surname));
        }

        [HttpGet]
        public PartialViewResult filterReset()
        {
            return PartialView("_ListUserTable", ApplicationUserManager.GetUsers());
        }

        [HttpGet]
        public PartialViewResult DeleteUserReturnPartialView(int userId)
        {
            ApplicationUserManager.DeleteUser(userId);
            return this.filterReset();
        }

        private IEnumerable<ApplicationUser> GetFilteredUserList(string _surname)
        {
            IEnumerable<ApplicationUser> _ret = null;
            try
            {
                if (string.IsNullOrEmpty(_surname))
                {
                    _ret = ApplicationUserManager.GetUsers();
                }
                else
                {
                    _ret = ApplicationUserManager.GetUsers4Surname(_surname);
                }
            }
            catch
            {
            }
            return _ret;
        }

        protected override void Dispose(bool disposing)
        {
            database.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeleteUserRoleReturnPartialView(long Id, int userId)
        {
            ApplicationUserManager.RemoveUser4Role(userId, Id);

            SetViewBagData(userId);
            return PartialView("_ListUserRoleTable", ApplicationUserManager.GetUser(userId));
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddUserRoleReturnPartialView(long Id, int userId)
        {

            ApplicationUserManager.AddUser2Role(userId, Id);

            SetViewBagData(userId);
            return PartialView("_ListUserRoleTable", ApplicationUserManager.GetUser(userId));
        }

        private void SetViewBagData(Int64 _userId)
        {
            SetViewBagData(_userId.ToString());
        }

        private void SetViewBagData(string _userId)
        {
            ViewBag.UserId = _userId;
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();
            ViewBag.RoleId = new SelectList(ApplicationRoleManager.GetRoles4SelectList(), "Id", "Name");
        }

        public List<SelectListItem> List_boolNullYesNo()
        {
            var _retVal = new List<SelectListItem>();
            try
            {
                _retVal.Add(new SelectListItem { Text = "Not Set", Value = null });
                _retVal.Add(new SelectListItem { Text = "Yes", Value = bool.TrueString });
                _retVal.Add(new SelectListItem { Text = "No", Value = bool.FalseString });
            }
            catch { }
            return _retVal;
        }
        #endregion

        #region ROLES
        public ActionResult RoleIndex()
        {
            List<ApplicationRole> _roles = ApplicationRoleManager.GetRoles();
            return View(_roles);
        }

        public ViewResult RoleDetails(long Id)
        {

            ApplicationRole role = ApplicationRoleManager.GetRole(Id);

            // USERS combo
            ViewBag.UserId = new SelectList(ApplicationUserManager.GetUsers4SelectList(), "Id", "UserName");
            ViewBag.RoleId = Id;

            // Rights combo
            ViewBag.PermissionId = new SelectList(ApplicationRoleManager.GetPermissions4SelectList(), "PermissionId", "PermissionDescription");
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();

            return View(role);
        }

        public ActionResult RoleCreate()
        {
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleCreate(RoleViewModel _role)
        {
            if (_role.RoleDescription == null)
            {
                ModelState.AddModelError("Role Description", "Role Description must be entered");
            }


            ApplicationRole role = new ApplicationRole(_role.Name, _role.RoleDescription);
            role.IsSysAdmin = _role.IsSysAdmin;

            if (ModelState.IsValid)
            {
                ApplicationRoleManager.CreateRole(role);
                return RedirectToAction("RoleIndex");
            }
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();
            return View(_role);
        }


        public ActionResult RoleEdit(long Id)
        {
            ApplicationRole _role = ApplicationRoleManager.GetRole(Id);

            // USERS combo
            ViewBag.UserId = new SelectList(ApplicationUserManager.GetUsers4SelectList(), "Id", "Username");
            ViewBag.RoleId = Id;

            // Rights combo
            ViewBag.PermissionId = new SelectList(ApplicationRoleManager.GetPermissions4SelectList(), "PermissionId", "PermissionDescription");
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();

            return View(_role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleEdit(RoleViewModel _role)
        {
            if (string.IsNullOrEmpty(_role.RoleDescription))
            {
                ModelState.AddModelError("Role Description", "Role Description must be entered");
            }

            if (ModelState.IsValid)
            {
                if (ApplicationRoleManager.UpdateRole(_role))
                    return RedirectToAction("RoleDetails", new RouteValueDictionary(new { id = _role.Id }));
            }
            // USERS combo
            ViewBag.UserId = new SelectList(ApplicationUserManager.GetUsers4SelectList(), "Id", "UserName");

            // Rights combo
            ViewBag.PermissionId = new SelectList(ApplicationRoleManager.GetPermissions4SelectList(), "PermissionId", "PermissionDescription");
            ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();
            return View(_role);
        }


        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeleteUserFromRoleReturnPartialView(long Id, int userId)
        {
            ApplicationUserManager.RemoveUser4Role(userId, Id);
            return PartialView("_ListUsersTable4Role", ApplicationRoleManager.GetRole(Id));
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddUser2RoleReturnPartialView(long Id, int userId)
        {
            ApplicationUserManager.AddUser2Role(userId, Id);
            return PartialView("_ListUsersTable4Role", ApplicationRoleManager.GetRole(Id));
        }

        public ActionResult RoleDelete(long Id)
        {
            ApplicationRoleManager.DeleteRole(Id);
            return RedirectToAction("RoleIndex");
        }

        #endregion

        #region PERMISSIONS

        public ViewResult PermissionIndex()
        {
            return View(ApplicationRoleManager.GetPermissions());
        }

        public ViewResult PermissionDetails(long Id)
        {
            return View(ApplicationRoleManager.GetPermission(Id));
        }

        public ActionResult PermissionCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PermissionCreate(PERMISSION _permission)
        {
            if (_permission.PermissionDescription == null)
            {
                ModelState.AddModelError("Permission Description", "Permission Description must be entered");
            }

            if (ModelState.IsValid)
            {
                ApplicationRoleManager.AddPermission(_permission);
                return RedirectToAction("PermissionIndex");
            }
            return View(_permission);
        }

        public ActionResult PermissionEdit(long Id)
        {
            PERMISSION _permission = ApplicationRoleManager.GetPermission(Id);
            ViewBag.RoleId = new SelectList(ApplicationRoleManager.GetRoles4SelectList(), "Id", "Name");
            return View(_permission);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PermissionEdit(PERMISSION _permission)
        {
            if (ModelState.IsValid)
            {
                ApplicationRoleManager.UpdatePermission(_permission);
                return RedirectToAction("PermissionDetails", new RouteValueDictionary(new { id = _permission.PermissionId }));
            }
            return View(_permission);
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeletePermissionReturnPartialView(long Id)
        {
            ApplicationRoleManager.DeletePermission(Id);
            return PartialView("_ListPermissionsTable", ApplicationRoleManager.GetPermissions());
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddPermission2RoleReturnPartialView(long Id, long permissionId)
        {
            ApplicationRoleManager.AddPermission2Role(Id, permissionId);
            return PartialView("_ListPermissions", ApplicationRoleManager.GetRole(Id));
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddAllPermissions2RoleReturnPartialView(long Id)
        {
            ApplicationRoleManager.AddAllPermissions2Role(Id);
            return PartialView("_ListPermissions", ApplicationRoleManager.GetRole(Id));
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeletePermissionFromRoleReturnPartialView(long Id, long permissionId)
        {
            ApplicationRoleManager.RemovePermission4Role(Id, permissionId);
            return PartialView("_ListPermissions", ApplicationRoleManager.GetRole(Id));
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DeleteRoleFromPermissionReturnPartialView(long Id, long permissionId)
        {
            ApplicationRoleManager.RemovePermission4Role(Id, permissionId);
            return PartialView("_ListRolesTable4Permission", ApplicationRoleManager.GetPermission(permissionId));
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult AddRole2PermissionReturnPartialView(long permissionId, long roleId)
        {
            ApplicationRoleManager.AddPermission2Role(roleId, permissionId);
            return PartialView("_ListRolesTable4Permission", ApplicationRoleManager.GetPermission(permissionId));
        }

        public ActionResult PermissionsImport()
        {
            var _controllerTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t != null
                    && t.IsPublic
                    && t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)
                    && !t.IsAbstract
                    && typeof(IController).IsAssignableFrom(t));

            var _controllerMethods = _controllerTypes.ToDictionary(controllerType => controllerType,
                    controllerType => controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(m => typeof(ActionResult).IsAssignableFrom(m.ReturnType)));

            foreach (var _controller in _controllerMethods)
            {
                string _controllerName = _controller.Key.Name;

                foreach (var _controllerAction in _controller.Value)
                {
                    string _controllerActionName = _controllerAction.Name;

                    var area = string.Empty;
                    var parts = _controllerAction.DeclaringType.Namespace.Split('.').ToList();
                    var areaIndex = parts.IndexOf("Controllers");
                    if (areaIndex > -1)
                        area = parts[areaIndex - 1];



                    if (_controllerName.EndsWith("Controller"))
                    {
                        _controllerName = _controllerName.Substring(0, _controllerName.LastIndexOf("Controller"));
                    }

                    string _permissionDescription = string.Format("{0}-{1}-{2}", area, _controllerName, _controllerActionName);
                    PERMISSION _permission = database.PERMISSIONS.Where(p => p.PermissionDescription.ToLower() == _permissionDescription.ToLower()).FirstOrDefault();
                    if (_permission == null)
                    {
                        if (ModelState.IsValid)
                        {
                            PERMISSION _perm = new PERMISSION();
                            _perm.PermissionDescription = _permissionDescription;

                            database.PERMISSIONS.Add(_perm);
                            database.SaveChanges();
                        }
                    }
                }
            }
            return RedirectToAction("PermissionIndex");
        }
        #endregion    
    }
}