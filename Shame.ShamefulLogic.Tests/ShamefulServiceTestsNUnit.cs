using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ninject;

namespace Shame.ShamefulLogic.Tests
{
    [TestFixture]
    public class ShamefulServiceTestsNUnit
    {
        [Test]
        public void NominateFine()
        {
            //Given
            var kernel = new StandardKernel(new ShamefulModuleBindings());
            var shamefulService = kernel.Get<IShamefulService>();

            //get random string 
            const string baseResource = "abcdefghigklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var fine = new StringBuilder(32);
            var random = new Random();
            for (int index = 0; index < 32; index++)
            {
                fine.Append(baseResource[random.Next(0, 31)]);
            }

            //When 
            shamefulService.NominateFine(fine.ToString());
            
            //Then
            var fines = shamefulService.GetFines(1, "PietPompiesDev");
            var finePosted = fines.FirstOrDefault() == fine.ToString();

            Assert.True(finePosted);
        }


        [Test]
        public void GetFines()
        {
            //Given
            var kernel = new StandardKernel(new ShamefulModuleBindings());
            var shamefulService = kernel.Get<IShamefulService>();

            //When 
            var fines = shamefulService.GetFines(10, "PietPompiesDev");

            //Then
            var hasFines = fines.Any();

            Assert.True(hasFines);
        }
    }
}
