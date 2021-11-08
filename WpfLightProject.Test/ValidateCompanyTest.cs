using NUnit.Framework;
using System;
using WpfLightProject.Models.Validations;

namespace WpfLightProject.Test
{
    public class ValidateCompanyTest
    {
        private DateTime _dateTime1 = DateTime.UtcNow;

        [Test]
        [TestCase("")]
        [TestCase("ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, ESTE É UM NOME FICTÍCIO, A")]
        public void ValidateAddress_IsNullOrEmpty_Or_HasMoreThan150Char_ReturnsFalse(string address)
        {
            ValidateCompany validate = new ValidateCompany();
            Assert.AreEqual(false, validate.ValidateAdress(address));
        }

        [Test]
        [TestCase("Rua José Guimarães Lima de Melo, n 1432, Bairro Granja Marileusa, Uberlândia-MG")]
        [TestCase("Rua José Guimarães Lima de Melo, n 1432, Bairro Granja Marileusa, Uberlândia do Estado de Minas Gerais Localizado no País Brasil e o resto do texto é.")]
        public void ValidateAddress_AddressShouldBeValid_ReturnsTrue(string address)
        {
            ValidateCompany validate = new ValidateCompany();
            Assert.AreEqual(true, validate.ValidateAdress(address));
        }

        [Test]
        public void ValidateBirthDate_DateTimeIsFuture_ReturnsFalse()
        {
            DateTime dateTime = DateTime.Now.AddHours(1);
            ValidateCompany validate = new ValidateCompany();
            Assert.AreEqual(false, validate.ValidateBirthDate(dateTime));
        }
    }
}
