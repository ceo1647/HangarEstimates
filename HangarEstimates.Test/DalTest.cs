using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using HangarEstimates.Domain.Catalogs;
using HangarEstimates.Infrastructure.Interfaces.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangarEstimates.Test
{
    [TestClass]
    public class DalTest
    {
        [TestMethod]
        public void CreateDbTest()
        {
            new TestBootstrapper().RunDal();

            var windRepository = TestServiceLocator.Insance.GetInstance<IRepository<Wind>>();
        }
    }
}
