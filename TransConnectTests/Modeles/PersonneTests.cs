using Xunit;
using TransConnectLib;
using System;

namespace TransConnectTests.Modeles
{
    public class PersonneTests
    {
        [Fact]
        public void MailValideTest()
        {
            // Arrange
            //(string numSecu, string nom, string prenom, DateTime dateNaissance, string adressePostale, string adresseMail, string telephone, DateTime dateEntree, string poste, double salaire)
            var personne1 = new Salarie("123456789", "John", "John", new DateTime(1990, 1, 1), "Rue abcd","exempletest.com", "1234567890", new DateTime(2020, 1, 1), "Poste", 1000.0);
            //(string numSecu, string nom, string prenom, DateTime dateNaissance, string adressePostale, string adresseMail, string telephone, string clientId)
            var personne2 = new Client("123456789", "John", "John", new DateTime(1990, 1, 1), "Rue abcd","exemple@test.com", "1234567890", "1");


            // Act
            var result1 = personne1.MailValide();
            var result2 = personne2.MailValide();

            // Assert
            Assert.False(result1);
            Assert.True(result2);
        }

        [Fact]
        public void AgeTest()
        {
            // Arrange
            var personne1 = new Salarie("123456789", "John", "John", new DateTime(2000, 1, 1), "Rue abcd","exempletest.com", "1234567890", new DateTime(2020, 1, 1), "Poste", 1000.0);

            // Act
            var result = personne1.CalculAge();

            // Assert
            Assert.Equal(24, result);
        }

        [Fact]
        public void ChangeAdresseTest()
        {
            // Arrange
            var personne1 = new Salarie("123456789", "John", "John", new DateTime(2000, 1, 1), "Rue abcd","exempletest.com", "1234567890", new DateTime(2020, 1, 1), "Poste", 1000.0);

            // Act
            personne1.ChangeAddresse("Rue efgh");

            // Assert
            Assert.Equal("Rue efgh", personne1.AdressePostale);
        }
    }
}