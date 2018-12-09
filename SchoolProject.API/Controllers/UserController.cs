using SchoolProject.Model.VM;
using SchoolProject.Business.OperationLibrary;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolProject.API.Controllers
{
    public class UserController : BaseController
    {
        private UserOperation userOperation;

        public UserController()
        {
            this.userOperation = new UserOperation();
        }

        [Route("api/user/getuser")]
        public UserVM GetUser(GetUserVM model)
        {
            if (ModelState.IsValid)
                return userOperation.GetUser(model.Email, model.Password);
            else
                return new UserVM();
        }

        [Route("api/user/getteachers")]
        public List<UserVM> GetTeachers() => userOperation.GetTeachers();

        [Route("api/user/adduser")]
        public User AddUser(UserVM model)
        {
            if (ModelState.IsValid)
                return userOperation.AddUser(model);
            else
                return new User();
        }
    }
}
