using System;
using NUnit.Framework;
using Baloon_AB.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;    

namespace tests
{

    [TestFixture]
    public class CheckOrder
    {
        [TestCase(0)]
        [TestCase(-5)]
        public void OrderModelSouldNotHaveZeroOrNegativeNumber(int amount)
        {
            CheckPropertyValidation cpv = new CheckPropertyValidation();    
            var order = new Order();    
            order.Amount = amount;
            var errorcount = cpv.myValidation(order).Count;    
            Assert.AreEqual(1, errorcount);
        }
        
        [TestCase(1)]
        public void ProjectModelSouldBeCorrect(int amount)
        {
            CheckPropertyValidation cpv = new CheckPropertyValidation();    
            var order = new Order();    
            order.Amount = amount;
            var errList = cpv.myValidation(order);    
            var errorcount = errList.Count;    
            Assert.AreEqual(0, errorcount);
        }
    }
}
