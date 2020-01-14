using NUnit.Framework;
using Baloon_AB.Controllers;

namespace tests
{
    [TestFixture]
    public class CheckProject
    {
        [TestCase("user@server.com", "ab")]
        [TestCase("user.server.com", "abc")]
        [TestCase("u", "a")]
        public void ProjectNameAndUserSouldBeCorrect(string user, string name)
        {
            var obj = new ProjectController();
            var actResult = obj.Add() as ViewResult;
            Assert.That(actResult.ViewName, Is.EqualTo("Bad"));
            //Assert.Pass();
        }
    }
}
