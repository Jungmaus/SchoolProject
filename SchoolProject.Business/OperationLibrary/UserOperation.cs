using SchoolProject.Data.Entities;
using SchoolProject.Model.Types.Enum;
using SchoolProject.Model.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Business.OperationLibrary
{
    public class UserOperation : BaseOperation
    {
        public User AddUser(UserVM model)
        {
            User _model = new User();
            _model.Name = model.Name;
            _model.Surname = model.Surname;
            _model.Email = model.Email;
            _model.Password = model.Password;
            _model.AccountType = model.AccountType;
            return Services.User.Insert(_model);
        }

        public UserVM GetUser(string email, string password)
        {
            User user = Services.User.FirstOrDefault(x => x.Email == email && x.Password == password);
            return new UserVM { AccountType = user.AccountType, Email = user.Email, Name = user.Name, Surname = user.Surname, ID = user.ID };
        }

        public List<UserVM> GetTeachers() => Services.User.GetAllWithQuery(x => x.AccountType == (int)EnumUserType.Teacher).Select(x => new UserVM { ID = x.ID, Email = x.Email, Name = x.Name, Surname = x.Surname, Password = x.Password }).OrderBy(x => x.Name).ToList();

    }
}
