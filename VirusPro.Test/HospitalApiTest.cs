using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using VirusPro.Controllers;
using VirusPro.ViewModel.BasicData.HospitalVMs;
using VirusPro.Model;
using VirusPro.DataAccess;


namespace VirusPro.Test
{
    [TestClass]
    public class HospitalApiTest
    {
        private HospitalController _controller;
        private string _seed;

        public HospitalApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<HospitalController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new HospitalSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            HospitalVM vm = _controller.Wtm.CreateVM<HospitalVM>();
            Hospital v = new Hospital();
            
            v.HostpitalName = "OXUmO";
            v.HostpitalLevel = VirusPro.Model.HospitalLevelEnum.Class3;
            v.LocationId = AddCity();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Hospital>().Find(v.ID);
                
                Assert.AreEqual(data.HostpitalName, "OXUmO");
                Assert.AreEqual(data.HostpitalLevel, VirusPro.Model.HospitalLevelEnum.Class3);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Hospital v = new Hospital();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.HostpitalName = "OXUmO";
                v.HostpitalLevel = VirusPro.Model.HospitalLevelEnum.Class3;
                v.LocationId = AddCity();
                context.Set<Hospital>().Add(v);
                context.SaveChanges();
            }

            HospitalVM vm = _controller.Wtm.CreateVM<HospitalVM>();
            var oldID = v.ID;
            v = new Hospital();
            v.ID = oldID;
       		
            v.HostpitalName = "eAYx7nP9jyE";
            v.HostpitalLevel = VirusPro.Model.HospitalLevelEnum.Class3;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.HostpitalName", "");
            vm.FC.Add("Entity.HostpitalLevel", "");
            vm.FC.Add("Entity.LocationId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Hospital>().Find(v.ID);
 				
                Assert.AreEqual(data.HostpitalName, "eAYx7nP9jyE");
                Assert.AreEqual(data.HostpitalLevel, VirusPro.Model.HospitalLevelEnum.Class3);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Hospital v = new Hospital();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.HostpitalName = "OXUmO";
                v.HostpitalLevel = VirusPro.Model.HospitalLevelEnum.Class3;
                v.LocationId = AddCity();
                context.Set<Hospital>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Hospital v1 = new Hospital();
            Hospital v2 = new Hospital();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.HostpitalName = "OXUmO";
                v1.HostpitalLevel = VirusPro.Model.HospitalLevelEnum.Class3;
                v1.LocationId = AddCity();
                v2.HostpitalName = "eAYx7nP9jyE";
                v2.HostpitalLevel = VirusPro.Model.HospitalLevelEnum.Class3;
                v2.LocationId = v1.LocationId; 
                context.Set<Hospital>().Add(v1);
                context.Set<Hospital>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Hospital>().Find(v1.ID);
                var data2 = context.Set<Hospital>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Guid AddCity()
        {
            City v = new City();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.CityName = "KpSi";
                context.Set<City>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
