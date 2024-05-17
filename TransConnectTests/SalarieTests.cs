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
            var salarie2 = new Salarie("5678", "Gaspard", "Tournadre", new DateTime(2003, 10, 07), "Rue abcd","abcd1@test.com", "1234567890", new DateTime(2019, 1, 1), "Poste", 1100.0);

            // Act
            GestionSalaries.AjouterSalarie(salarie1);
            GestionSalaries.AjouterSalarie(salarie2);

            // Assert  
            Assert.Equal(2, GestionSalaries.GetSalariesCount());

            // Act
            GestionSalaries.SupprimerSalarie(salarie1.NumSecu);

            // Assert
            Assert.Equal(1, GestionSalaries.GetSalariesCount());
        }

        [Fact]
        public void TestDisponibiliteChauffeur()
        {
            // Arrange
            var chauffeur = new Chauffeur("1234", "John", "Doe", new DateTime(1990, 1, 1), "Rue abcd", "john.doe@test.com", "1234567890", new DateTime(2020, 1, 1), "Chauffeur", 1000.0);
            DateTime jourNonDisponible = new DateTime(2024, 5, 17);

            // Act
            chauffeur.AjouterJourNonDisponible(jourNonDisponible);

            // Assert
            Assert.False(chauffeur.EstDisponible(jourNonDisponible));
        }
    }
}
