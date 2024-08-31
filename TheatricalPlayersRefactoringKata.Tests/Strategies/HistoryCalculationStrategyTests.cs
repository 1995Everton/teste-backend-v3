using System;
using TheatricalPlayersRefactoringKata.Application.Models;
using TheatricalPlayersRefactoringKata.Application.Strategies;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests.Strategies
{
    public class HistoryCalculationStrategyTests
    {
        [Fact]
        public void CalculateAmount_ShouldReturnSumOfTragedyAndComedyAmounts()
        {
            // Configura um cen�rio onde a pe�a � do tipo "history" e a audi�ncia � de 25 pessoas.
            // Verifica se o valor calculado � a soma dos valores de trag�dia e com�dia.

            // Arrange
            var strategyFactory = new CalculationStrategyFactory();
            var strategy = new HistoryCalculationStrategy(strategyFactory);
            var play = new Play("History Play", 3000, "history");
            var performance = new Performance("1", 25);

            // Mock das estrat�gias de trag�dia e com�dia
            var tragedyStrategy = new TragedyCalculationStrategy();
            var comedyStrategy = new ComedyCalculationStrategy();

            // Act
            var amount = strategy.CalculateAmount(performance, play);

            // Assert
            Assert.Equal(tragedyStrategy.CalculateAmount(performance, play) + comedyStrategy.CalculateAmount(performance, play), amount);
        }

        [Fact]
        public void CalculateCredits_ShouldReturnCorrectCredits()
        {
            // Configura um cen�rio onde a pe�a � do tipo "history" e a audi�ncia � de 35 pessoas.
            // Verifica se os cr�ditos calculados est�o corretos.

            // Arrange
            var strategyFactory = new CalculationStrategyFactory();
            var strategy = new HistoryCalculationStrategy(strategyFactory);
            var play = new Play("History Play", 3000, "history");
            var performance = new Performance("1", 35);

            // Act
            var credits = strategy.CalculateCredits(performance, play);

            // Assert
            Assert.Equal(5, credits);
        }
    }
}
