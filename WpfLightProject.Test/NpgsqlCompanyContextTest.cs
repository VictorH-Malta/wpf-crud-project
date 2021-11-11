using NUnit.Framework;
using Moq;
using WpfLightProject.Models;
using WpfLightProject.Models.Enums;
using WpfLightProject.DataAccess;
using System;
using WpfLightProject.ViewModels;
using System.Collections.Generic;

namespace WpfLightProject.Test
{
    [TestFixture]
    public class NpgsqlCompanyContextTest
    {
        private ICompany _companyValid;
        private ICompany _companyInvalid;
        private NpgsqlCompanyContext _npgsqlCompanyContext;

        [SetUp]
        public void Init()
        {
            _companyValid = new Company() { Address = "Rua Alberto Gomes, n 42, Apto 201, Alto Umuarama, Uberlândia-MG", Id = 2, BirthDate = DateTime.Parse("07/03/1996"), Business = BusinessBranch.HumanResource, CompanySize = CompanySize.Large, Name = "Empresa do Victor", RegisterNumber = "28317258000135", Status = Status.Active };
            _companyInvalid = new Company() { Address = "", Id = -1, BirthDate = DateTime.Now, Business = BusinessBranch.Marketing, CompanySize = CompanySize.Small, RegisterNumber = "12345678945", Status = Status.Active, Name = "Empresa fictícia" };
            _npgsqlCompanyContext = new NpgsqlCompanyContext();
        }

        [TearDown] 
        public void CleanUp()
        {

        }

        [Test]
        public void Insert_ShouldBeValidIfCompanyIsValid()
        {
            //Arrange

            Mock<ICompanyDataContext> mock = new Mock<ICompanyDataContext>();
            //Act
            mock.Setup(x => x.Insert(_companyValid)).Verifiable();

            //Assert
        }

        [Test]
        public void Insert_ShouldNotBeValidIfCompanyInvalid()
        {
            Mock<ICompanyDataContext> mock = new Mock<ICompanyDataContext>();

            mock.Setup(x => x.Insert(_companyInvalid)).Verifiable();
        }

        [Test]
        public void Select_ShouldReturnListOfCompanies()
        {
            Mock<ICompanyDataContext> mock = new Mock<ICompanyDataContext>();
            //Act
            var companies = _npgsqlCompanyContext.Select();
            Assert.AreEqual(_companyValid, companies);
        }
    }
}
