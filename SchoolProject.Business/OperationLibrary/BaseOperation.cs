using SchoolProject.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Business.OperationLibrary
{
    public class BaseOperation
    {
        public ServiceProvider Services;

        public BaseOperation()
        {
            this.Services = new ServiceProvider();
        }
    }
}
