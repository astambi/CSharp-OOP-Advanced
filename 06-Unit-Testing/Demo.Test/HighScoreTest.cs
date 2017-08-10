using Demo.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Test
{
    [TestClass]
    public class HighScoreTest
    {
        private HighScore highscore;

        [TestInitialize]
        public void PreparePlayers()
        {
            var fileProviderMock = new Mock<IFileProvider>();
            var data = new List<Player>();

            fileProviderMock
                .Setup(f => f.ReadAllText(It.IsAny<string>()))
                .Returns(() => string.Join(",",
                                data.Select(p => $"{p.Name},{p.Points}")));
            fileProviderMock
                .Setup(f => f.WriteAllText(It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string>((filePath, content) =>
                {
                    data = Player.Parse(content).ToList();
                });

            this.highscore = new HighScore(fileProviderMock.Object);

            for (int i = 0; i < HighScore.MaxPlayers + 10; i++)
            {
                this.highscore.AddPlayer(new Player(i.ToString(), i + 100));
            }
        }

        [TestMethod]
        public void AddPlayerShouldHaveNoMoreThanTenPlayers()
        {
            Assert.AreEqual(HighScore.MaxPlayers, this.highscore.Load().Count());
        }

        [TestMethod]
        public void AddPlayerShouldHaveOrderedByDescPlayerPoints()
        {
            var points = this.highscore
                .Load()
                .Select(p => p.Points)
                .ToList();
            Assert.IsTrue(points.Any(), "Highscore should have at least one player");

            var max = points.First();

            for (int i = 1; i < points.Count; i++)
            {
                var current = points[i];
                Assert.IsTrue(max >= current);
            }
        }
    }
}
