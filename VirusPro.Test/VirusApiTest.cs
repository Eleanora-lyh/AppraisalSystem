using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using VirusPro.Controllers;
using VirusPro.ViewModel.BasicData.VirusVMs;
using VirusPro.Model;
using VirusPro.DataAccess;


namespace VirusPro.Test
{
    [TestClass]
    public class VirusApiTest
    {
        private VirusController _controller;
        private string _seed;

        public VirusApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<VirusController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new VirusSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            VirusVM vm = _controller.Wtm.CreateVM<VirusVM>();
            Virus v = new Virus();
            
            v.VirusName = "Ad";
            v.VirusCode = "ungs4U5z";
            v.VirusRemark = "1VQVelCB";
            v.VirusType = VirusPro.Model.VirusTypeEnum.RNA;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Virus>().Find(v.ID);
                
                Assert.AreEqual(data.VirusName, "Ad");
                Assert.AreEqual(data.VirusCode, "ungs4U5z");
                Assert.AreEqual(data.VirusRemark, "1VQVelCB");
                Assert.AreEqual(data.VirusType, VirusPro.Model.VirusTypeEnum.RNA);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Virus v = new Virus();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.VirusName = "Ad";
                v.VirusCode = "ungs4U5z";
                v.VirusRemark = "1VQVelCB";
                v.VirusType = VirusPro.Model.VirusTypeEnum.RNA;
                context.Set<Virus>().Add(v);
                context.SaveChanges();
            }

            VirusVM vm = _controller.Wtm.CreateVM<VirusVM>();
            var oldID = v.ID;
            v = new Virus();
            v.ID = oldID;
       		
            v.VirusName = "8txJYf4AU79WAMaw";
            v.VirusCode = "j5dP";
            v.VirusRemark = "8DgJf";
            v.VirusType = VirusPro.Model.VirusTypeEnum.DNA;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.VirusName", "");
            vm.FC.Add("Entity.VirusCode", "");
            vm.FC.Add("Entity.VirusRemark", "");
            vm.FC.Add("Entity.VirusType", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Virus>().Find(v.ID);
 				
                Assert.AreEqual(data.VirusName, "8txJYf4AU79WAMaw");
                Assert.AreEqual(data.VirusCode, "j5dP");
                Assert.AreEqual(data.VirusRemark, "8DgJf");
                Assert.AreEqual(data.VirusType, VirusPro.Model.VirusTypeEnum.DNA);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Virus v = new Virus();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.VirusName = "Ad";
                v.VirusCode = "ungs4U5z";
                v.VirusRemark = "1VQVelCB";
                v.VirusType = VirusPro.Model.VirusTypeEnum.RNA;
                context.Set<Virus>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Virus v1 = new Virus();
            Virus v2 = new Virus();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.VirusName = "Ad";
                v1.VirusCode = "ungs4U5z";
                v1.VirusRemark = "1VQVelCB";
                v1.VirusType = VirusPro.Model.VirusTypeEnum.RNA;
                v2.VirusName = "8txJYf4AU79WAMaw";
                v2.VirusCode = "j5dP";
                v2.VirusRemark = "8DgJf";
                v2.VirusType = VirusPro.Model.VirusTypeEnum.DNA;
                context.Set<Virus>().Add(v1);
                context.Set<Virus>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Virus>().Find(v1.ID);
                var data2 = context.Set<Virus>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
