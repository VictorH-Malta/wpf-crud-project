using NUnit.Framework;
using Moq;
using WpfLightProject.Models;
using WpfLightProject.Models.Enums;
using WpfLightProject.DataAccess;
using System;
using WpfLightProject.ViewModels;

namespace WpfLightProject.Test
{
    [TestFixture]
    public class NpgsqlCompanyContextTest
    {
        private ICompany _company;

        [SetUp]
        public void Init()
        {
            _company = new Company() { Id = 3, Address = "Rua dos Bobos, 0", BirthDate = DateTime.Parse("03/07/1999"), Business = BusinessBranch.Financial, CompanySize = CompanySize.Small, Name = "Empresa dos Bobos", RegisterNumber = "69348097000124", Status = Status.Active };
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
            mock.Setup(ins => ins.Insert(_company)).Verifiable();
            //Assert
        }
    }
}
