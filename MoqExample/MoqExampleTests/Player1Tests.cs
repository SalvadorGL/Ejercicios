using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExample.Tests
{
    [TestClass()]
    public class Player1Tests
    {
        [TestMethod()]
        public void JumpTest()
        {
            var mockMovement = new Moq.Mock<IMovable>();

            mockMovement.Setup(move => move.Jump(It.IsAny<double>())).Returns(true);

            IPlayer player = new Player1() { ID = 101, Name = "Jugador 10", JumpElevation = 6.2 };

            var result = player.Jump(mockMovement.Object);

            Assert.IsTrue(result);

            //verify if Jump method is called exactly once when parameter is passed

            mockMovement.Verify(move => move.Jump(It.IsAny<double>()), Times.Once);

            //Assert.Fail();
        }

        //[TestMethod()]
        //public void JumpTest()
        //{
        //    IPlayer player = new Player1();
        //    player.ID = 100;
        //    player.Name = "Jugador 1";
        //    player.JumpElevation = 3.8;

        //    //move player
        //    IMovable moves = new Movements();
        //    var result = moves.Jump(player.JumpElevation);

        //    Assert.AreEqual(true, result);
        //}
    }
}