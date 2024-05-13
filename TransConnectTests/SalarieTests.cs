using Xunit;
using TransConnectLib;
using System;
using System.Collections.Generic;


namespace TransConnectTests
{
    public class SalarieTests
    {
        [Fact]
        public void AjouterSalarie_SupprimerSalarie_ListerSalarieTest()
        {
            // Arrange
            var salarie1 = new Salarie("1234", "Mark-Killian", "Zinenberg", new DateTime(2003, 10, 10), "Rue abcd","abcd@test.com", "1234567890", new DateTime(2020, 1, 1), "Poste", 1000.0);
            var salarie2 = new Salarie("1234", "Gaspard", "Tournadre", new DateTime(2003, 10, 07), "Rue abcd","abcd1@test.com", "1234567890",new DateTime(2019, 1, 1), "Poste", 1100.0);

            // Act
            Salarie.AjouterSalarie(salarie1);
            Salarie.AjouterSalarie(salarie2);

            // Assert  
            Assert.Equal(2, Salarie.NbSalaries); 

            // Act
            Salarie.SupprimerSalarie(salarie1);

            // Assert
            Assert.Equal(1, Salarie.NbSalaries);
            Assert.Contains(salarie1, Salarie.EmployeTC);
            Assert.Contains(salarie2, Salarie.EmployeTC);
        }
        
    }
}