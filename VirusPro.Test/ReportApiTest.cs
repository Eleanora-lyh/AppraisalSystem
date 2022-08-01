using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using VirusPro.Controllers;
using VirusPro.ViewModel.Patients.ReportVMs;
using VirusPro.Model;
using VirusPro.DataAccess;


namespace VirusPro.Test
{
    [TestClass]
    public class ReportApiTest
    {
        private ReportController _controller;
        private string _seed;

        public ReportApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<ReportController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new ReportSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            ReportVM vm = _controller.Wtm.CreateVM<ReportVM>();
            Report v = new Report();
            
            v.Temparature = 34;
            v.Remark = "dXUKfH02288";
            v.PatientID = AddPatient();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Report>().Find(v.ID);
                
                Assert.AreEqual(data.Temparature, 34);
                Assert.AreEqual(data.Remark, "dXUKfH02288");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Report v = new Report();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Temparature = 34;
                v.Remark = "dXUKfH02288";
                v.PatientID = AddPatient();
                context.Set<Report>().Add(v);
                context.SaveChanges();
            }

            ReportVM vm = _controller.Wtm.CreateVM<ReportVM>();
            var oldID = v.ID;
            v = new Report();
            v.ID = oldID;
       		
            v.Temparature = 40;
            v.Remark = "APl8o";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Temparature", "");
            vm.FC.Add("Entity.Remark", "");
            vm.FC.Add("Entity.PatientID", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Report>().Find(v.ID);
 				
                Assert.AreEqual(data.Temparature, 40);
                Assert.AreEqual(data.Remark, "APl8o");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Report v = new Report();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Temparature = 34;
                v.Remark = "dXUKfH02288";
                v.PatientID = AddPatient();
                context.Set<Report>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Report v1 = new Report();
            Report v2 = new Report();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Temparature = 34;
                v1.Remark = "dXUKfH02288";
                v1.PatientID = AddPatient();
                v2.Temparature = 40;
                v2.Remark = "APl8o";
                v2.PatientID = v1.PatientID; 
                context.Set<Report>().Add(v1);
                context.Set<Report>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Report>().Find(v1.ID);
                var data2 = context.Set<Report>().Find(v2.ID);
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

                v.CityName = "WrnZKip0sgCqT";
                context.Set<City>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddHospital()
        {
            Hospital v = new Hospital();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.HostpitalName = "3cX1Vjpf2qI";
                v.HostpitalLevel = VirusPro.Model.HospitalLevelEnum.Class3;
                v.LocationId = AddCity();
                context.Set<Hospital>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddFileAttachment()
        {
            FileAttachment v = new FileAttachment();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.FileName = "kpJ";
                v.FileExt = "Sn4y0rs0";
                v.Path = "3qBWFD";
                v.Length = 76;
                v.UploadTime = DateTime.Parse("2023-06-04 18:00:46");
                v.SaveMode = "PUUFaSdJFahc";
                v.ExtraInfo = "RHu7Vxh1h3CDc";
                v.HandlerInfo = "5hh5qpTASt9CI";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddPatient()
        {
            Patient v = new Patient();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.PatientName = "WPkQ";
                v.IdNumber = "1R2OVA5k";
                v.Gender = VirusPro.Model.GenderEnums.Female;
                v.status = VirusPro.Model.PatientStatusEnum.confirmed;
                v.Birthday = DateTime.Parse("2023-03-03 18:00:46");
                v.LocationId = AddCity();
                v.HospitalId = AddHospital();
                v.PhotoId = AddFileAttachment();
                context.Set<Patient>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
