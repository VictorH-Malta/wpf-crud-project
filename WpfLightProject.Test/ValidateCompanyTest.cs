using NUnit.Framework;
using System;
using Moq;
using WpfLightProject.Models.Validations;
using WpfLightProject.Models;

namespace WpfLightProject.Test
{
    public class ValidateCompanyTest
    {
        private ICompany _company;

        [Test]
        [TestCase("", false)]
        [TestCase("   ", false)]
        [TestCase("ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, A", false)]
        [TestCase("    a ", true)]
        [TestCase("Rua José Guimarães Lima de Melo, n 1432, Bairro Granja Marileusa, Uberlândia-MG", true)]
        [TestCase("Rua José Guimarães Lima de Melo, n 1432, Bairro Granja Marileusa, Uberlândia do Estado de Minas Gerais Localizado no País Brasil e o resto do texto é.", true)]
        public void ValidateAddress_ShouldReturnFalseIfIsNullOrWhiteSpace_ReturnTrueIfValid(string address, bool expected)
        {
            ValidateCompany validate = new ValidateCompany();
            bool actual = validate.ValidateAddress(address);
            Assert.AreEqual(actual, expected);
        }


        [Test]
        public void ValidateBirthDate_ShouldReturnFalseIfNowOrFuture()
        {
            //Arrange
            ValidateCompany validate = new ValidateCompany();

            //Act
            bool actual = validate.ValidateBirthDate(DateTime.Now.Date);
            bool expected = false;

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase(0, true)]
        [TestCase(12540, true)]
        [TestCase(-1, false)]
        [TestCase(Int32.MaxValue, false)]
        public void ValidateId_ShouldReturnFalseIfNegativeOrMaxValue(int id, bool expected)
        {
            //Arrange
            ValidateCompany validateCompany = new ValidateCompany();
            //Act
            bool actual = validateCompany.ValidateId(id);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase("", false)]
        [TestCase("    ", false)]
        [TestCase("Estou escrevendo um nome que deve ter mais de 50 char", false)]
        [TestCase("Estou escrevendo um nome que deve ter mais de 50 c", true)]
        [TestCase("Victor Henrique Malta", true)]
        public void ValidateName_ShouldReturnFalseIfNullOrWhiteSpaceOrMoreThan50Char(string name, bool expected)
        {
            //Arrange
            ValidateCompany validateCompany = new ValidateCompany();
            //Act
            bool actual = validateCompany.ValidateName(name);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase("65204704000121", true)]
        [TestCase("90933627000198", true)]
        [TestCase("66032131000169", true)]
        [TestCase("", false)]
        [TestCase("2764978900016", false)]
        [TestCase("276497894", false)]
        [TestCase("49627827000120", false)]
        [TestCase("4662782700012043", false)]
        public void ValidateRegisterNumber_ShouldReturnTrueIfValid(string number, bool expected)
        {
            //Arrange
            ValidateCompany validateCompany = new ValidateCompany();
            //Act
            bool actual = validateCompany.ValidateRegisterNumber(number);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void IsCompanyValid_ReturnsTrueIfAllTrue()
        {
            //Arrange
            ValidateCompany validateCompany = new ValidateCompany();
            //Act
            bool actual = validateCompany.IsCompanyValid(ReturnCompanyMocked());

            //Assert
            Assert.AreEqual(actual, true);
        }

        private ICompany ReturnCompanyMocked()
        {
            _company = new Company() { Address = "Rua Alberto Gomes, n 42, Apto 201, Alto Umuarama, Uberlândia-MG", Id = 2, BirthDate = DateTime.Parse("07/03/1996"), Business = BusinessBranch.HumanResource, CompanySize = Models.Enums.CompanySize.Large, Name = "Empresa do Victor", RegisterNumber = "28317258000135", Status = Status.Active };

            return _company;
        }
    }
}
