using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PatientInformationAPI.Controllers;
using PatientInformationAPI.Data;
using PatientInformationAPI.Model;
using PatientInformationAPI.PatientProvider;
using PatientInformationAPI.PatientRepository;
using System;
using System.Collections.Generic;

namespace TestPatientInfo
{
    [TestFixture]
    public class UnittestPatientInfo
    {
        Patient p1;
        [SetUp]
        public void Initmethod()
        {
            DateTime d = Convert.ToDateTime("21 / 09 / 1999");
            p1 = new Patient(1, "Sanjay","sivan" ,"Male",22,d,"9345091940");
            Mock<IPatientProvider> mockpatientprovider = new Mock<IPatientProvider>();
            Mock<IPatientRepo> mockpatientrepo = new Mock<IPatientRepo>();
            PatientProvider p = new PatientProvider(mockpatientrepo.Object);
            PatientsController c = new PatientsController(mockpatientprovider.Object);
            mockpatientrepo.Setup(r => r.GetPatientById(1)).Returns(p1);
            mockpatientprovider.Setup(n => n.GetPatientById(1)).Returns(p1);


        }
        [Test]

        public void getallpatientdetailstest()
        {


            List<Patient> patients = new List<Patient>();
           DateTime d = Convert.ToDateTime("21/ 09 / 1999");
           Patient p1 = new Patient(1, "Sanjay", "sivan", "Male", 22,d, "9345091940");
            Mock<IPatientProvider> mockpatientprovider = new Mock<IPatientProvider>();
            Mock<IPatientRepo> mockpatientrepo = new Mock<IPatientRepo>();
            PatientProvider p = new PatientProvider(mockpatientrepo.Object);
            PatientsController c = new PatientsController(mockpatientprovider.Object);
            mockpatientrepo.Setup(r => r.GetPatientsdetails()).Returns(patients);
            mockpatientprovider.Setup(n => n.GetPatientsdetails()).Returns(patients);
         //  var obj = c.GetPatientDetails() as OkObjectResult;
         //  Assert.AreEqual(200, obj.StatusCode);

        }


        [Test]

        public void getpatientdetailstest()
        {

            Mock<IPatientProvider> mockpatientprovider = new Mock<IPatientProvider>();
            Mock<IPatientRepo> mockpatientrepo = new Mock<IPatientRepo>();
            PatientProvider p = new PatientProvider(mockpatientrepo.Object);
            PatientsController c = new PatientsController(mockpatientprovider.Object);
            mockpatientrepo.Setup(r => r.GetPatientById(1)).Returns(p1);
            mockpatientprovider.Setup(n => n.GetPatientById(1)).Returns(p1);
        //   var obj = c.GetPatientDetails(1) as OkObjectResult;
         //  Assert.AreEqual(200, obj.StatusCode);

        }
        [Test]
        public void insertpatientdetailtest()
        {

            Mock<IPatientProvider> mockpatientprovider = new Mock<IPatientProvider>();
            Mock<IPatientRepo> mockpatientrepo = new Mock<IPatientRepo>();
            PatientProvider p = new PatientProvider(mockpatientrepo.Object);
            PatientsController c = new PatientsController(mockpatientprovider.Object);
            mockpatientrepo.Setup(r => r.AddNewPatient(p1));
            mockpatientprovider.Setup(n => n.AddNewPatient(p1));
         //  var obj = c.PostPatient(p1) as CreatedAtActionResult;
        //   Assert.AreEqual(201, obj.StatusCode);

        }
        [Test]
        public void updatepatientdetailstest()
        {
            Patient p2;
            DateTime d = Convert.ToDateTime("21/ 09 / 1999");
            p2 = new Patient(1, "Sam", "sivan", "Male", 22, d, "9345091940");
            Mock<IPatientProvider> mockpatientprovider = new Mock<IPatientProvider>();
            Mock<IPatientRepo> mockpatientrepo = new Mock<IPatientRepo>();
            PatientProvider p = new PatientProvider(mockpatientrepo.Object);
            PatientsController c = new PatientsController(mockpatientprovider.Object);
            mockpatientrepo.Setup(r => r.UpdatePatientdetail(1, p2));
            mockpatientprovider.Setup(n => n.UpdatePatientdetail(1, p2));
            var obj = c.PutPatient(1, p2) as NoContentResult;
            Assert.AreEqual(204, obj.StatusCode);

        }
        [Test]
        public void deletepatienttest()
        {

            Mock<IPatientProvider> mockpatientprovider = new Mock<IPatientProvider>();
            Mock<IPatientRepo> mockpatientrepo = new Mock<IPatientRepo>();
            PatientProvider p = new PatientProvider(mockpatientrepo.Object);
            PatientsController c = new PatientsController(mockpatientprovider.Object);
            mockpatientrepo.Setup(r => r.DeletePatientdetail(1));
            mockpatientprovider.Setup(n => n.DeletePatientdetail(1));
            var obj = c.DeletePatient(1) as NoContentResult;
            Assert.AreEqual(204, obj.StatusCode);
        }

        //provider unit test
        [Test]
        public void PatientdetailsExists()
        {
            
            Mock<IPatientProvider> mockpatientprovider = new Mock<IPatientProvider>();
            Mock<IPatientRepo> mockpatientrepo = new Mock<IPatientRepo>();
            PatientProvider p = new PatientProvider(mockpatientrepo.Object);
            PatientsController c = new PatientsController(mockpatientprovider.Object);
            mockpatientrepo.Setup(r => r.PatientdetailExists(1)).Returns(true);
            mockpatientprovider.Setup(n => n.PatientdetailExists(1)).Returns(true);
            bool obj = p.PatientdetailExists(1);
            Assert.AreEqual(true, obj);

        }
        [Test]
           public void getpatientdetailsTestp()
           {
           
            Mock<IPatientProvider> mockpatientprovider = new Mock<IPatientProvider>();
            Mock<IPatientRepo> mockpatientrepo = new Mock<IPatientRepo>();
            PatientProvider p = new PatientProvider(mockpatientrepo.Object);
            mockpatientrepo.Setup(r => r.GetPatientById(1)).Returns(p1);
            mockpatientprovider.Setup(n => n.GetPatientById(1)).Returns(p1);
            PatientsController c = new PatientsController(mockpatientprovider.Object);

                Patient obj = p.GetPatientById(1);
               Assert.AreEqual("Sanjay",obj.FirstName);

           }
        [Test]
        public void getallpatientdetailsTestp()
        {
            List<Patient> patients = new List<Patient>();
            DateTime d = Convert.ToDateTime("21 / 09 / 1999");
            Patient p1 = new Patient(1, "Sanjay", "sivan", "Male", 22,d, "9345091940");
            patients.Add(p1);
            Mock<IPatientProvider> mockpatientprovider = new Mock<IPatientProvider>();
            Mock<IPatientRepo> mockpatientrepo = new Mock<IPatientRepo>();
            PatientProvider p = new PatientProvider(mockpatientrepo.Object);
            PatientsController c = new PatientsController(mockpatientprovider.Object);
            mockpatientrepo.Setup(r => r.GetPatientsdetails()).Returns(patients);
            mockpatientprovider.Setup(n => n.GetPatientsdetails()).Returns(patients);
            var obj = p.GetPatientsdetails();
            Assert.AreEqual(1, obj.Count);

        }
        [Test]
        public void insertpatientdetailtestp()
        {

            Mock<IPatientProvider> mockpatientprovider = new Mock<IPatientProvider>();
            Mock<IPatientRepo> mockpatientrepo = new Mock<IPatientRepo>();
            PatientProvider p = new PatientProvider(mockpatientrepo.Object);
            PatientsController c = new PatientsController(mockpatientprovider.Object);
            mockpatientrepo.Setup(r => r.AddNewPatient(p1));
            mockpatientprovider.Setup(n => n.AddNewPatient(p1));
            var obj = p.AddNewPatient(p1);
            Assert.AreEqual("Sanjay", obj.FirstName);

        }
        [Test]
        public void updatepatientdetailstestp()
        {
            Patient p2;
            DateTime d = Convert.ToDateTime("21/ 09 / 1999");
            p2 = new Patient(1, "Sam", "sivan", "Male", 22, d, "9345091940");
            Mock<IPatientProvider> mockpatientprovider = new Mock<IPatientProvider>();
            Mock<IPatientRepo> mockpatientrepo = new Mock<IPatientRepo>();
            PatientProvider p = new PatientProvider(mockpatientrepo.Object);
            PatientsController c = new PatientsController(mockpatientprovider.Object);
            mockpatientrepo.Setup(r => r.UpdatePatientdetail(1, p2)).Returns(p2);
            mockpatientprovider.Setup(n => n.UpdatePatientdetail(1, p2)).Returns(p2);
            var obj = p.UpdatePatientdetail(1, p2);
            Assert.AreEqual("Sam", obj.FirstName);


        }
        [Test]
        public void deletepatienttestp()
        {

            Mock<IPatientProvider> mockpatientprovider = new Mock<IPatientProvider>();
            Mock<IPatientRepo> mockpatientrepo = new Mock<IPatientRepo>();
            PatientProvider p = new PatientProvider(mockpatientrepo.Object);
            PatientsController c = new PatientsController(mockpatientprovider.Object);
            mockpatientrepo.Setup(r => r.DeletePatientdetail(1));
            mockpatientprovider.Setup(n => n.DeletePatientdetail(1));
            p.DeletePatientdetail(1);
          
         }
      
       
       
    }
}
