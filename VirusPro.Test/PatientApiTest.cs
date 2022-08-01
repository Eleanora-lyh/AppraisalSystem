using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using VirusPro.Controllers;
using VirusPro.ViewModel.Patients.PatientVMs;
using VirusPro.Model;
using VirusPro.DataAccess;


namespace VirusPro.Test
{
    [TestClass]
    public class PatientApiTest
    {
        private PatientController _controller;
        private string _seed;

        public PatientApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<PatientController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new PatientSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            PatientVM vm = _controller.Wtm.CreateVM<PatientVM>();
            Patient v = new Patient();
            
            v.PatientName = "WYobFGk2fh2X";
            v.IdNumber = "sDn3IxKir";
            v.Gender = VirusPro.Model.GenderEnums.Male;
            v.status = VirusPro.Model.PatientStatusEnum.confirmed;
            v.Birthday = DateTime.Parse("2023-04-21 17:50:44");
            v.LocationId = AddCity();
            v.HospitalId = AddHospital();
            v.PhotoId = AddFileAttachment();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Patient>().Find(v.ID);
                
                Assert.AreEqual(data.PatientName, "WYobFGk2fh2X");
                Assert.AreEqual(data.IdNumber, "sDn3IxKir");
                Assert.AreEqual(data.Gender, VirusPro.Model.GenderEnums.Male);
                Assert.AreEqual(data.status, VirusPro.Model.PatientStatusEnum.confirmed);
                Assert.AreEqual(data.Birthday, DateTime.Parse("2023-04-21 17:50:44"));
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Patient v = new Patient();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.PatientName = "WYobFGk2fh2X";
                v.IdNumber = "sDn3IxKir";
                v.Gender = VirusPro.Model.GenderEnums.Male;
                v.status = VirusPro.Model.PatientStatusEnum.confirmed;
                v.Birthday = DateTime.Parse("2023-04-21 17:50:44");
                v.LocationId = AddCity();
                v.HospitalId = AddHospital();
                v.PhotoId = AddFileAttachment();
                context.Set<Patient>().Add(v);
                context.SaveChanges();
            }

            PatientVM vm = _controller.Wtm.CreateVM<PatientVM>();
            var oldID = v.ID;
            v = new Patient();
            v.ID = oldID;
       		
            v.PatientName = "xYGLaPFVs";
            v.IdNumber = "Xo7w3EMQ6XIM";
            v.Gender = VirusPro.Model.GenderEnums.Male;
            v.status = VirusPro.Model.PatientStatusEnum.asymptomatic;
            v.Birthday = DateTime.Parse("2023-06-19 17:50:44");
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.PatientName", "");
            vm.FC.Add("Entity.IdNumber", "");
            vm.FC.Add("Entity.Gender", "");
            vm.FC.Add("Entity.status", "");
            vm.FC.Add("Entity.Birthday", "");
            vm.FC.Add("Entity.LocationId", "");
            vm.FC.Add("Entity.HospitalId", "");
            vm.FC.Add("Entity.PhotoId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Patient>().Find(v.ID);
 				
                Assert.AreEqual(data.PatientName, "xYGLaPFVs");
                Assert.AreEqual(data.IdNumber, "Xo7w3EMQ6XIM");
                Assert.AreEqual(data.Gender, VirusPro.Model.GenderEnums.Male);
                Assert.AreEqual(data.status, VirusPro.Model.PatientStatusEnum.asymptomatic);
                Assert.AreEqual(data.Birthday, DateTime.Parse("2023-06-19 17:50:44"));
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Patient v = new Patient();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.PatientName = "WYobFGk2fh2X";
                v.IdNumber = "sDn3IxKir";
                v.Gender = VirusPro.Model.GenderEnums.Male;
                v.status = VirusPro.Model.PatientStatusEnum.confirmed;
                v.Birthday = DateTime.Parse("2023-04-21 17:50:44");
                v.LocationId = AddCity();
                v.HospitalId = AddHospital();
                v.PhotoId = AddFileAttachment();
                context.Set<Patient>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Patient v1 = new Patient();
            Patient v2 = new Patient();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.PatientName = "WYobFGk2fh2X";
                v1.IdNumber = "sDn3IxKir";
                v1.Gender = VirusPro.Model.GenderEnums.Male;
                v1.status = VirusPro.Model.PatientStatusEnum.confirmed;
                v1.Birthday = DateTime.Parse("2023-04-21 17:50:44");
                v1.LocationId = AddCity();
                v1.HospitalId = AddHospital();
                v1.PhotoId = AddFileAttachment();
                v2.PatientName = "xYGLaPFVs";
                v2.IdNumber = "Xo7w3EMQ6XIM";
                v2.Gender = VirusPro.Model.GenderEnums.Male;
                v2.status = VirusPro.Model.PatientStatusEnum.asymptomatic;
                v2.Birthday = DateTime.Parse("2023-06-19 17:50:44");
                v2.LocationId = v1.LocationId; 
                v2.HospitalId = v1.HospitalId; 
                v2.PhotoId = v1.PhotoId; 
                context.Set<Patient>().Add(v1);
                context.Set<Patient>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Patient>().Find(v1.ID);
                var data2 = context.Set<Patient>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
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

                v.CityName = "v";
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

                v.HostpitalName = "lJEWebOWUBBHbyfv";
                v.HostpitalLevel = VirusPro.Model.HospitalLevelEnum.Class2;
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

                v.FileName = "sQxZ";
                v.FileExt = "j";
                v.Path = "ZclLcbBRFewQ";
                v.Length = 90;
                v.UploadTime = DateTime.Parse("2023-10-18 17:50:44");
                v.SaveMode = "0MW3FlNvDL703";
                v.ExtraInfo = "gQnNdVGDxFO";
                v.HandlerInfo = "UydNAmCwD";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
