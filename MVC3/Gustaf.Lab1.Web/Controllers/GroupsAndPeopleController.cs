using System;
using System.Linq;
using System.Web.Mvc;
using Gustaf.Lab1.Web.Models;
using Gustaf.Lab1.Web.Repositories;
using System.Collections.Generic;

namespace Gustaf.Lab1.Web.Controllers
{
    public class GroupsAndPeopleController : Controller
    {
        //
        // Repository with methods persistence. For Loose coupling.
        private readonly IRepository _repository;

        public GroupsAndPeopleController(IRepository repository)
        {
            this._repository = repository;
        }


        //
        // GET: /GroupsAndPeople/

        public ActionResult Index()
        {


            ViewBag.People = _repository.GetAllPeople();

            return View();
        }

        //
        // GET: /GroupsAndPeople/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /GroupsAndPeople/NewPerson

        public ActionResult NewPerson()
        {
            NewPersonModel model = new NewPersonModel();
            return View(model);
        }
        //
        // POST: /GroupsAndPeople/AddNewPerson

        
        public JsonResult AddNewPerson(NewPersonModel model)
        {
            var newPersonResultModel = new NewPersonResultModel();
            if (String.IsNullOrEmpty(model.FirstName))
            {
                newPersonResultModel.Message = "Firstname can not be blank";
                return Json(newPersonResultModel, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(model.LastName))
            {
                newPersonResultModel.Message = "Lastname can not be blank";
                return Json(newPersonResultModel, JsonRequestBehavior.AllowGet);
            }

            try
            {
                _repository.NewPerson(new Person
                                          {
                                              FirstName = model.FirstName,
                                              LastName = model.LastName
                                          });

                newPersonResultModel.Message = "New person Added OK"; //success message is empty in this case
                return Json(newPersonResultModel, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                newPersonResultModel.Message = "Something else went wrong!"; //success message is empty in this case
                return Json(newPersonResultModel, JsonRequestBehavior.AllowGet);
            }


        }

        //
        // GET: /GroupsAndPeople/NewGroup

        public ActionResult NewGroup()
        {
            return View();
        }

        //
        // POST: /GroupsAndPeople/NewGroup

        [HttpPost]
        public ActionResult NewGroup(FormCollection collection)
        {
            try
            {
                _repository.NewGroup(new Group
                {
                    Name = collection["Name"]
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /GroupsAndPeople/AddPersonToGroup

        public ActionResult AddPersonToGroup()
        {
            //
            //Get lists of people and groups
            var groupsToAddPeopleTo = _repository.GetAllGroups();

            var peopleToAdd = _repository.GetAllPeople();
            IEnumerable<SelectListItem> selectList =
                from p in peopleToAdd
                select new SelectListItem
                {
                    Text = p.FirstName + " " + p.LastName,
                    Value = p.Id.ToString()
                };
            ViewData["PeopleDropDown"] = selectList;
            ViewData["GroupsDropDown"] = new SelectList(groupsToAddPeopleTo, "Id", "Name");

            return View();
        }

        //
        // POST: /GroupsAndPeople/AddPersonToGroup

        public JsonResult Add(AddPersonToGroupModel model)
        {
            var result = new AddPersonToGroupModel();
            try
            {
                _repository.AddPersonToGroup(model.GroupId, model.PersonId);
                result.Message = "Person Added to Group OK"; //WIN
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                result.Message = "Something went wrong"; //FAIL
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        //
        // POST: /GroupsAndPeople/Create

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
        
        //
        // GET: /GroupsAndPeople/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /GroupsAndPeople/Edit/5

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

        //
        // GET: /GroupsAndPeople/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /GroupsAndPeople/Delete/5

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
