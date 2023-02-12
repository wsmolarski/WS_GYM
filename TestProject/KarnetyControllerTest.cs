using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.EntityFrameworkCore;
using WS_GYM.Controllers;
using WS_GYM.Data;
using WS_GYM.Models;

namespace TestProject
{
    [TestClass]
    public class KarnetyControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            Mock<FitnessContext> context = new Mock<FitnessContext>();

            var karnety = new List<Karnet>()
            {
                new Karnet()
                {
                    Id = 1,
                    Start = DateTime.Now.AddDays(-10),
                    End = DateTime.Now.AddDays(20),
                    UserId = "123"
                }
            };

            context.Setup(c => c.Karnety).ReturnsDbSet(karnety);

            KarnetyController controller = new KarnetyController(context.Object);

            var result = controller.Index();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateTest()
        {
            Mock<FitnessContext> context = new Mock<FitnessContext>();

            var karnety = new List<Karnet>();

            context.Setup(c => c.Karnety).ReturnsDbSet(karnety);

            KarnetyController controller = new KarnetyController(context.Object);

            var result = controller.Create();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreatePostTest1()
        {
            Mock<FitnessContext> context = new Mock<FitnessContext>();

            var karnety = new List<Karnet>();

            context.Setup(c => c.Karnety).ReturnsDbSet(karnety);

            KarnetyController controller = new KarnetyController(context.Object);

            var k = new Karnet()
            {
                Id = 1,
                Start = DateTime.Now.AddDays(-10),
                End = DateTime.Now.AddDays(20),
                UserId = "123"
            };

            var result = controller.Create(k).GetAwaiter().GetResult();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void CreatePostTest2()
        {
            Mock<FitnessContext> context = new Mock<FitnessContext>();

            var karnety = new List<Karnet>();

            context.Setup(c => c.Karnety).ReturnsDbSet(karnety);

            KarnetyController controller = new KarnetyController(context.Object);

            var k = new Karnet()
            {
                Id = 1,
                UserId = null
            };

            var result = controller.Create(k).GetAwaiter().GetResult();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IActionResult));
        }


    }


}