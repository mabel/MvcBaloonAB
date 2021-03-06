using System;
using NUnit.Framework;
using Baloon_AB.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;    

namespace tests
{

    [TestFixture]
    public class CheckProject
    {
        [TestCase("")]
        [TestCase("a")]
        [TestCase("ab")]
        public void ProjectModelSouldNotBeCorrect(string projName)
        {
            CheckPropertyValidation cpv = new CheckPropertyValidation();    
            var proj = new Project();    
            proj.Name = projName;
            var errorcount = cpv.myValidation(proj).Count;    
            Assert.AreEqual(1, errorcount);
        }
        
        [TestCase("abc")]
        public void ProjectModelSouldBeCorrect(string projName)
        {
            CheckPropertyValidation cpv = new CheckPropertyValidation();    
            var proj = new Project();    
            proj.Name = projName;
            var errList = cpv.myValidation(proj);    
            var errorcount = errList.Count;    
            Assert.AreEqual(0, errorcount);
        }
    }
}
