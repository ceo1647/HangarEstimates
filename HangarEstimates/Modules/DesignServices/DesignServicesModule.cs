using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HangarEstimates.Bll;
using HangarEstimates.Bll.Catalogs;
using HangarEstimates.Bll.TU;
using HangarEstimates.Infrastructure.Composite;
using HangarEstimates.Infrastructure.Interfaces.Services;
using HangarEstimates.Modules.ClientRequest.Design;
using HangarEstimates.Modules.Contractors.Design;
using Microsoft.Practices.Unity;

namespace HangarEstimates.Modules.DesignServices
{
    public class DesignServicesModule : ModuleBase
    {
        public override void Initialize()
        {
            Container.RegisterType(typeof(IRepository<>), typeof(DesignRepository<>), new ContainerControlledLifetimeManager());
            InitRepos();

            Container.RegisterType<IYesNoUserAnswerService, YesNoUserAnswerService>();
        }

        private void InitRepos()
        {
            var clientRepository = Container.Resolve<IRepository<Client>>();
            clientRepository.Add(new Client { Name = "ЗАО \"КрышеСнос\"" });
            clientRepository.Add(new Client { Name = "ЗАО \"Рай\"" });
            clientRepository.Add(new Client { Name = "ОАО \"АгроНос\"" });
            clientRepository.Add(new Client { Name = "ЗАО \"КосаКамень\"" });

            var gatesRepository = Container.Resolve<IRepository<Gate>>();
            gatesRepository.Add(new Gate { Height = 2, Width = 3 });
            gatesRepository.Add(new Gate { Height = 3, Width = 3 });
            gatesRepository.Add(new Gate { Height = 3, Width = 3.5 });
            gatesRepository.Add(new Gate { Height = 4, Width = 4 });
            gatesRepository.Add(new Gate { Height = 4, Width = 4.5 });

            var windsRepository = Container.Resolve<IRepository<Wind>>();
            windsRepository.Add(new Wind(){Height = 1, Width = 1});
            windsRepository.Add(new Wind() { Height = 1, Width = 1.5 });
            windsRepository.Add(new Wind() { Height = 1.5, Width = 1.5 });
            windsRepository.Add(new Wind() { Height = 2.5, Width = 1.5 });

            var substuctureTypeRepository = Container.Resolve<IRepository<SubstuctureType>>();
            substuctureTypeRepository.Add(new SubstuctureType() { Name = "Фундамент ленточный, мп", Price = 333});
            substuctureTypeRepository.Add(new SubstuctureType() { Name = "Фундамент ленточный с б/н сваями , мп", Price = 344 });
            substuctureTypeRepository.Add(new SubstuctureType() { Name = "Фундамент ленточный усиленный, мп", Price = 334 });
            substuctureTypeRepository.Add(new SubstuctureType() { Name = "Фундаментная плита, мп", Price = 3334 });

            var insulationTypeRepo = Container.Resolve<IRepository<InsulationType>>();
            insulationTypeRepo.Add(new InsulationType { Name = "Утепление пенополеуретаном, обычный 100 мм", Price = 344 });
            insulationTypeRepo.Add(new InsulationType { Name = "Утепление пенополеуретаном, влагостойкий 50 мм", Price = 55 });
            insulationTypeRepo.Add(new InsulationType { Name = "Утепление минеральной ватой 50 мм", Price = 554 });

            var additionConstructionRepo = Container.Resolve<IRepository<AdditionConstruction>>();
            additionConstructionRepo.Add(new AdditionConstruction { Name = "Устройство ЖБ подпорной стенки, высота 1 м", Price = 3 });
            additionConstructionRepo.Add(new AdditionConstruction { Name = "Устройство металлической подпорной стенки, высота 3 м", Price = 33 });
            additionConstructionRepo.Add(new AdditionConstruction { Name = "Отмостка", Price = 7 });
            

            var substTuRepo = Container.Resolve<IRepository<SubstuctureTypeTU>>();
            substTuRepo.Add(new SubstuctureTypeTU { MaximumHangarWidth = 12, MinimumHangarWidth = 6, Substructure = substuctureTypeRepository.Get(0) });
            substTuRepo.Add(new SubstuctureTypeTU { MaximumHangarWidth = 18, MinimumHangarWidth = 5, Substructure = substuctureTypeRepository.Get(1) });
            substTuRepo.Add(new SubstuctureTypeTU { MaximumHangarWidth = 19, MinimumHangarWidth = 4, Substructure = substuctureTypeRepository.Get(2) });
            substTuRepo.Add(new SubstuctureTypeTU { MaximumHangarWidth = 20, MinimumHangarWidth = 3, Substructure = substuctureTypeRepository.Get(3) });

            var citiesRepo = Container.Resolve<IRepository<City>>();
            citiesRepo.Add(new City()
            {
                Name = "Волгоград",
                District = "Волгоградская область",
                SnowRegion = 2,
                WindRegion = 3
            });

            citiesRepo.Add(new City()
            {
                Name = "Краснодар",
                District = "Краснодарский край",
                SnowRegion = 2,
                WindRegion = 2
            });

            var hangarRepo = Container.Resolve<IRepository<Hangar>>();
            hangarRepo.Add(new Hangar()
                {
                    FirstEndWall = new EndWall
                    {
                        Gates = new ObservableCollection<Gate>()
                        {
                            new Gate {Height = 20, Width = 30},
                        },
                        Windows = new List<WindPlacement>()
                        {
                            new WindPlacement{Position = EWindPosition.Над_воротами, Wind = windsRepository.Get(1)}
                        }
                    },

                    SecondEndWall = new EndWall
                    {
                        Gates = new ObservableCollection<Gate>
                        {
                            new Gate {Height = 25, Width = 32},
                        },
                        Windows = new List<WindPlacement>()
                        {
                            new WindPlacement{Position = EWindPosition.Над_воротами, Wind = windsRepository.Get(2)}
                        }
                    },

                    SubstuctureType = substuctureTypeRepository.Get(1),
                    Height = 65,
                    Lenght = 87,
                    Width = 67
                });

            hangarRepo.Add(new Hangar()
                {
                    FirstEndWall = new EndWall
                    {
                        Gates = new ObservableCollection<Gate>()
                        {
                            new Gate {Height = 22, Width = 32},
                        },
                        Windows = new List<WindPlacement>()
                        {
                            new WindPlacement{Position = EWindPosition.Над_воротами, Wind = windsRepository.Get(3)}
                        }
                    },

                    SecondEndWall = new EndWall
                    {
                        Gates = new ObservableCollection<Gate>
                        {
                            new Gate {Height = 25, Width = 32},
                        },
                        Windows = new List<WindPlacement>()
                        {
                            new WindPlacement{Position = EWindPosition.Над_воротами, Wind = windsRepository.Get(2)},
                            new WindPlacement{Position = EWindPosition.Над_воротами, Wind = windsRepository.Get(1)},
                        }
                    },

                    SubstuctureType = substuctureTypeRepository.Get(2),
                    Height = 50,
                    Lenght = 90,
                    Width = 46
                });

            hangarRepo.Add(new Hangar()
            {
                FirstEndWall = new EndWall
                {
                    Gates = new ObservableCollection<Gate>()
                        {
                            new Gate {Height = 20, Width = 30},
                            new Gate {Height = 15, Width = 30},
                        },
                    Windows = new List<WindPlacement>()
                        {
                            new WindPlacement{Position = EWindPosition.Над_воротами, Wind = windsRepository.Get(3)},
                            new WindPlacement{Position = EWindPosition.Над_воротами, Wind = windsRepository.Get(1)},
                        }
                },

                SecondEndWall = new EndWall
                {
                    Gates = new ObservableCollection<Gate>
                        {
                            new Gate {Height = 25, Width = 32},
                            new Gate {Height = 25, Width = 36},
                        },
                    Windows = new List<WindPlacement>()
                        {
                            new WindPlacement{Position = EWindPosition.Над_воротами, Wind = windsRepository.Get(2)},
                            new WindPlacement{Position = EWindPosition.Над_воротами, Wind = windsRepository.Get(3)},
                        }
                },

                SubstuctureType = substuctureTypeRepository.Get(3),
                Height = 40,
                Lenght = 80,
                Width = 45
            });

           InitRequests();
        }

        private void InitRequests()
        {
            var requestRepository =  Container.Resolve<IRepository<Request>>();
            var clientRepository = Container.Resolve<IRepository<Client>>();
            var windsRepository = Container.Resolve<IRepository<Wind>>();
            var substuctureTypeRepository = Container.Resolve<IRepository<SubstuctureType>>();
            var citiesRepo = Container.Resolve<IRepository<City>>();
            var hangarRepo = Container.Resolve<IRepository<Hangar>>();

            requestRepository.Add(new Request
            {
                Name = "1",
                Client = clientRepository.Get(1),
                Condition = ERequestCondition.Обрабатывается,
                HangarCity = citiesRepo.Get(0),
                Hangar = hangarRepo.Get(0),
                Date = DateTime.Now
            });


            requestRepository.Add(new Request
            {
                Name = "2",
                Client = clientRepository.Get(2),
                Condition = ERequestCondition.Обрабатывается,
                HangarCity = citiesRepo.Get(0),
                Hangar = hangarRepo.Get(1),
                Date = DateTime.Now
            });
            requestRepository.Add(new Request
            {
                Id = 3,
                Name = "3",
                Client = clientRepository.Get(3),
                Condition = ERequestCondition.Завершено,
                HangarCity =citiesRepo.Get(1),
                Hangar = hangarRepo.Get(2),
                Date = DateTime.Now
            });
        }
    }
}
