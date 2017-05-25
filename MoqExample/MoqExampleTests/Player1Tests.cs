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
        }

        [TestMethod()]
        public void JumpTestFalse()
        {
            var mockMovement = new Moq.Mock<IMovable>();
            mockMovement.Setup(move => move.Jump(It.IsAny<double>())).Returns(false);

            IPlayer player = new Player1() { ID = 101, Name = "Jugador 10", JumpElevation = 6.2 };
            var result = player.Jump(mockMovement.Object);

            Assert.IsFalse(result);

            //verify if Jump method is called exactly once when parameter is passed
            mockMovement.Verify(move => move.Jump(It.IsAny<double>()), Times.Once);
        }

        [TestMethod()]
        public void JumpTestException()
        {
            try
            {
                var mockMovement = new Moq.Mock<IMovable>();
                mockMovement.Setup(move => move.Jump(It.IsAny<double>())).Throws(new DivideByZeroException());

                IPlayer player = new Player1() { ID = 101, Name = "Jugador 10", JumpElevation = 6.2 };
                var result = player.Jump(mockMovement.Object);

                //Assert.Fail("An exception should have been thrown");
                //Assert.IsFalse(result);

                //verify if Jump method is called exactly once when parameter is passed
                // mockMovement.Verify(move => move.Jump(It.IsAny<double>()), Times.Once);
            }
            catch (DivideByZeroException ex)
            {
                var message = ex.Message;
                //Assert.AreEqual("")
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Exception of type {0} cought: {1}", ex.GetType(), ex.Message));
                
            }
            
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void JumpTestExceptionByAttribute()
        {
            var mockMovement = new Moq.Mock<IMovable>();
            mockMovement.Setup(move => move.Jump(It.IsAny<double>())).Throws(new DivideByZeroException());

            IPlayer player = new Player1() { ID = 101, Name = "Jugador 10", JumpElevation = 6.2 };
            var result = player.Jump(mockMovement.Object);

            Assert.IsFalse(result);

            //verify if Jump method is called exactly once when parameter is passed
            mockMovement.Verify(move => move.Jump(It.IsAny<double>()), Times.Once);


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