using NUnit.Framework;
using System;
using WpfLightProject.Models.Validations;
using WpfLightProject.Models;

namespace WpfLightProject.Test
{
    [TestFixture]
    public class ValidateCompanyTest
    {
        private IValidateCompany _validateCompany;
        
        static Company[] ValidCompanies = new Company[]
            {
                new Company() { Address = "Rua Alberto Gomes, n 42, Apto 201, Alto Umuarama, Uberlândia-MG", Id = 2, BirthDate = DateTime.Parse("07/03/1996"), Business = BusinessBranch.HumanResource, CompanySize = Models.Enums.CompanySize.Large, Name = "Empresa do Victor", RegisterNumber = "28317258000135", Status = Status.Active },
                new Company() { Address = "Av. Floriano Peixoto, n 5322, Apto 302, Alto Umuarama, Uberlândia-MG", Id = 5, BirthDate = DateTime.Parse("10/01/1958"), Business = BusinessBranch.IT, CompanySize = Models.Enums.CompanySize.Small, Name = "Empresa do Antonio", RegisterNumber = "68673115000180", Status = Status.Active },
                new Company() { Address = "Rua Maria das Dores Dias, n 96, Apto 101, Santa Mônica, Uberlândia-MG", Id = 102, BirthDate = DateTime.Parse("02/02/2020"), Business = BusinessBranch.Innovation, CompanySize = Models.Enums.CompanySize.Medium, Name = "Empresa dos Garotos", RegisterNumber = "40864583000113", Status = Status.Active }
            };

        static Company[] InvalidCompanies = new Company[]
            {
                new Company() { Address = "", Id = -1, BirthDate = DateTime.Now, Business = BusinessBranch.Marketing, CompanySize = Models.Enums.CompanySize.Small, RegisterNumber = "12345678945", Status = Status.Active, Name = "Empresa fictícia"},
                new Company() { Address = "Rua não nomeada", Id = 0, BirthDate = DateTime.Parse("06/10/1999"), Business = BusinessBranch.Facility, CompanySize = Models.Enums.CompanySize.Large, RegisterNumber = "51199220000127", Status = Status.Active, Name = ""},
                new Company() { Address = "Rua fake", Id = 23, BirthDate = DateTime.Parse("01/01/2022"), Business = BusinessBranch.Engeneering, CompanySize = Models.Enums.CompanySize.Medium, RegisterNumber = "91490708000123", Status = Status.Active, Name = "Empresa fake"},
            };

        [SetUp]
        public void Init()
        {
            _validateCompany = new ValidateCompany();
        }

        [TearDown]
        public void CleanUp()
        {
            ValidCompanies = null;
            InvalidCompanies = null;
        }

        [Test]
        [TestCase("", false)]
        [TestCase("   ", false)]
        [TestCase("ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, A", false)]
        [TestCase("    a ", true)]
        [TestCase("Rua José Guimarães Lima de Melo, n 1432, Bairro Granja Marileusa, Uberlândia-MG", true)]
        [TestCase("Rua José Guimarães Lima de Melo, n 1432, Bairro Granja Marileusa, Uberlândia do Estado de Minas Gerais Localizado no País Brasil e o resto do texto é.", true)]
        public void ValidateAddress_ShouldReturnFalseIfIsNullOrWhiteSpace_ReturnTrueIfValid(string address, bool expected)
        {
            bool actual = _validateCompany.ValidateAddress(address);
            Assert.AreEqual(actual, expected);
        }


        [Test]
        public void ValidateBirthDate_ShouldReturnFalseIfNowOrFuture()
        {
            //Arrange

            //Act
            bool actual = _validateCompany.ValidateBirthDate(DateTime.Now.Date);
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

            //Act
            bool actual = _validateCompany.ValidateId(id);
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
            //Act
            bool actual = _validateCompany.ValidateName(name);
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

            //Act
            bool actual = _validateCompany.ValidateRegisterNumber(number);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(nameof(ValidCompanies))]
        public void IsCompanyValid_ReturnsTrueForValidCompanies(ICompany company)
        {
            //Arrange

            //Act
            bool actual = _validateCompany.IsCompanyValid(company);
            //Assert
            Assert.AreEqual(actual, true);
        }

        [TestCaseSource(nameof(InvalidCompanies))]
        public void IsCompanyValid_ReturnsFalseForInvalidCompanies(Company company)
        {
            //Arrange
            //Act
            bool actual = _validateCompany.IsCompanyValid(company);
            //Assert
            Assert.AreEqual(actual, false);
        } 
    }
}
