using KamDMS.Entities.Models;
using KamDMS.Extension.Helpers;
using KamDMS.Service.Contracts;
using KamDMS.WebUI.Areas.Admin.Models.Department;
using KamDMS.WebUI.Areas.Admin.Models.DepBranchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KamDMS.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = KamDMS.Extension.Constant.RoleConstant._Admin)]
    public class DepartmentController : Controller
    {
        private IDepartmentService departmentService;
        private IDepBranchService depBranchService;

        public DepartmentController(IDepBranchService _depBranchService,IDepartmentService _departmentService)
        {
            this.departmentService = _departmentService;
            this.depBranchService = _depBranchService;
        }
        #region Department

        public ActionResult ListDepartment()
        {
            DepartmentViewModel model = new DepartmentViewModel();
            model.ListDepartment = departmentService.GetAll.ToList();
            return View(model);
        }

        public ActionResult EditDepartment(string Id = "")
        {
            var model = new DepartmentViewModel();
            if (string.IsNullOrEmpty(Id))
                return View(model);
            else
            {
                var entity = departmentService.GetDepartmentById(Id);
                model = model.SaveEntityToViewModel(entity);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDepartment(DepartmentViewModel model)
        {
            if (model == null)
                ModelState.AddModelError("", "Произошли какие-то ошибки попробуйте еще раз");

            if (ModelState.IsValid)
            {
                departmentService.Edit(model.SaveViewModelByEntity(model));
                return RedirectToAction("ListDepartment", "Department");
            }
            return View(model);
        }

        public ActionResult DeleteDepartment(string Id)
        {
            departmentService.Delete(Id);
            return RedirectToAction("ListDepartment", "Department");
        }
        #endregion

        #region DepBranch
        public ActionResult ListDepBranch()
        {
            DepBranchViewModel model = new DepBranchViewModel();
            model.ListDepBranch = depBranchService.GetAll.ToList();
            model.ListDep = departmentService.GetAll.ToList();
            
            return View(model);
        }

        public ActionResult EditDepBranch(string Id = "")
        {
            ViewBag.SelectListDep = departmentService.GetAll.ToList();
            var model = new DepBranchViewModel();
            if (string.IsNullOrEmpty(Id))
                return View(model);
            else
            {
                var entity = depBranchService.GetDepBranchById(Id);
                model = model.SaveViewModelByEntity(entity);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDepBranch(DepBranchViewModel model)
        {
            if (model == null)
                ModelState.AddModelError("", "Произошли какие-то ошибки попробуйте еще раз");

            if (ModelState.IsValid)
            {
                depBranchService.Edit(model.SaveEntityByViewModel(model));
                return RedirectToAction("ListDepBranch", "Department");
            }
            return View(model);
        }

        public ActionResult DeleteDepBranch(string Id)
        {
            depBranchService.Delete(Id);
            return RedirectToAction("ListDepBranch", "Department");
        }
        #endregion
    }
}