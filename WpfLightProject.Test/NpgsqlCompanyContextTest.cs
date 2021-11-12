using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLightProject.DataAccess;
using WpfLightProject.Models;
using WpfLightProject.ViewModels;
using WpfLightProject.Models.Validations;

namespace WpfLightProject.Test
{
    [TestFixture]
    public class NpgsqlCompanyContextTest
    {
        private ICompanyDataContext _npgsql;
        private Mock<IValidateCompany> _mock;
        private ICompany _companyValid;

        [SetUp]
        public void Init()
        {
            _npgsql = new NpgsqlCompanyContext();
            _mock = new Mock<IValidateCompany>();
            _companyValid = new Company();
        }

        [TearDown]
        public void CleanUp()
        {

        }

        [Test]
        public void Insert_ShouldInsertIfCompanyIsValid()
        {
            //Arrange
            _mock.Setup(x => x.IsCompanyValid(_companyValid)).Returns(true);
            Mock<ICompanyDataContext> mock = new Mock<ICompanyDataContext>();
            mock.Setup(x => x.Insert(_companyValid)).Returns(_companyValid).Verifiable();
            //Act
            bool result = _mock.Object.IsCompanyValid(_companyValid);
            //Assert
            Assert.That(result);
        }

        [Test]
        public void Insert_ShouldNotInsertIfCompanyIsInvalid()
        {
            _mock.Setup(x => x.IsCompanyValid(_companyValid)).Returns(false);
            Mock<ICompanyDataContext> mock = new Mock<ICompanyDataContext>();
            mock.Setup(x => x.Insert(_companyValid)).Returns(_companyValid).Verifiable();

            bool result = _mock.Object.IsCompanyValid(_companyValid);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Delete_ShouldDeleteIfCompanyIsValid()
        {
            _mock.Setup(x => x.IsCompanyValid(_companyValid)).Returns(true);
            Mock<ICompanyDataContext> mock = new Mock<ICompanyDataContext>();
            mock.Setup(x => x.Delete(_companyValid)).Returns(_companyValid).Verifiable();

            bool result = _mock.Object.IsCompanyValid(_companyValid);

            Assert.That(result);
        }

        [Test]
        public void Delete_ShouldNotDeleteIfCompanyIsInvalid()
        {
            _mock.Setup(x => x.IsCompanyValid(_companyValid)).Returns(false);
            Mock<ICompanyDataContext> mock = new Mock<ICompanyDataContext>();
            mock.Setup(x => x.Delete(_companyValid)).Returns(_companyValid).Verifiable();

            bool result = _mock.Object.IsCompanyValid(_companyValid);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Update_ShouldUpdateIfCompanyIsValid()
        {
            _mock.Setup(x => x.IsCompanyValid(_companyValid)).Returns(true);
            Mock<ICompanyDataContext> mock = new Mock<ICompanyDataContext>();
            mock.Setup(x => x.Update(_companyValid)).Returns(_companyValid).Verifiable();

            bool result = _mock.Object.IsCompanyValid(_companyValid);

            Assert.That(result);
        }

        [Test]
        public void Update_ShouldNotUpdateIfCompanyIsInvalid()
        {
            _mock.Setup(x => x.IsCompanyValid(_companyValid)).Returns(false);
            Mock<ICompanyDataContext> mock = new Mock<ICompanyDataContext>();
            mock.Setup(x => x.Update(_companyValid)).Returns(_companyValid).Verifiable();

            bool result = _mock.Object.IsCompanyValid(_companyValid);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Select_ShouldReturnListIfItsNull()
        {
            List<ICompany> list = new List<ICompany>();
            list = null;

            Mock<ICompanyDataContext> mock = new Mock<ICompanyDataContext>();
            mock.Setup(x => x.CompaniesList);

            var result = mock.Object.CompaniesList.Count;

            Assert.AreEqual(list.Count, result);
        }
    }
}
