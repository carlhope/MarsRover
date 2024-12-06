using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Tests
{
    internal class PlateauTests
    {

        [Test]
        public void TestGridSize()
        {
            //arrange
            PlateauSize size = new PlateauSize(6, 3);
            Plateau plateau = new Plateau(size);
            var grid = plateau.Grid;
            int[] expected = [6, 3];
            //act
            int x  = grid.GetLength(0);
            int y = grid.GetLength(1);
            int[] actual = [x, y];
            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1, 1, false)]
        [TestCase(3, 3, true)]
        public void IsEmpty(int x, int y, bool expected)
        {
            //Arrange
            PlateauSize size = new PlateauSize(4,4);
            Plateau plateau = new Plateau(size);
            plateau.Grid[1, 1] = "X";
            plateau.Grid[2, 1] = "X";
            plateau.Grid[1, 2] = "X";
            //Act
            var actual = plateau.IsPositionEmpty(x, y);
            //Assert
            Assert.AreEqual(expected, actual);



        }
    }
}
