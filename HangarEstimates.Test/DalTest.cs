using System.Collections.Generic;
using HangarEstimates.Domain.Catalogs;
using HangarEstimates.Domain.CostIssues;
using HangarEstimates.Domain.HangarIssues;
using HangarEstimates.Domain.Materials;
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

        [TestMethod]
        public void FoundationIssue()
        {
            new TestBootstrapper().RunDal();

            var repository = TestServiceLocator.Insance.GetInstance<IRepository>();
            
            var squere = new MeasurementType {Name = "Площадь"};
            repository.Add(squere);


            var squereMeters = new Measurement
            {
                FullName = "Квадратный метр",
                Factor = 1,
                MesurementType = squere,
                ShortName = "кв.м"
            };
            repository.Add(squereMeters);


            var squereSantimeters = new Measurement
            {
                FullName = "Квадратный сантиметр",
                Factor = 0.0001,
                MesurementType = squere,
                ShortName = "кв.cм"
            };
            repository.Add(squereSantimeters);


            var listMaterial = new Material
            {
                MesurementType = squere,
                Name = "Лист",
                TypeSize = "1000*600*20"
            };
            repository.Add(listMaterial);

            var listMaterial2 = new Material
            {
                MesurementType = squere,
                Name = "Лист",
                TypeSize = "2000*600*20"
            };
            repository.Add(listMaterial2);


            var materialIssue = new MaterialCostIssue
            {
                Material = listMaterial,
                Measurement = squereMeters,
                Price = 1000,
            };
            repository.Add(materialIssue);

            var materialIssue2 = new MaterialCostIssue
            {
                Material = listMaterial2,
                Measurement = squereMeters,
                Price = 2000,
            };
            repository.Add(materialIssue2);

            var materialCountableIssue = new MaterialCountableIssue {CostIssue = materialIssue, Count = 2};
            repository.Add(materialCountableIssue);
            var materialCountableIssue2 = new MaterialCountableIssue {CostIssue = materialIssue2, Count = 5};
            repository.Add(materialCountableIssue2);

            var foundationIssue = new FoundationCostIssue
            {
                FoundationName = "Фундамент тип 1",
                MaterialIssues = new List<MaterialCountableIssue>
                {
                    materialCountableIssue,
                    materialCountableIssue2
                },
            };
            repository.Add(foundationIssue);
        }
    }
}