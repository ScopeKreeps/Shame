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
            var fine = new Guid().ToString();

            //When 
            shamefulService.NominateFine(fine);
            
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

        [Test]
        public void DependencyInjection()
        {
            //Given
            var kernel = new StandardKernel(new ShamefulModuleBindings());
            var shamefulService = kernel.Get<IShamefulService>();

            //Then
            var wasInitialized = shamefulService != null;

            Assert.True(wasInitialized);
        }

        [Test]
        public void IsFine()
        {
            //Given
            const string shamefullFine = "#Shame random text @nominee";

            //When
            var shamefullFineModel = new FineModel(shamefullFine);

            //Then
            Assert.True(shamefullFineModel.IsValid);
        }

        [Test]
        public void IsNotAFine()
        {
            //Given
            const string unshamefullFine = " random text @nominee";
            const string unnominatedFine = "#Shame random text";

            //When
            var unshamefullFineModel = new FineModel(unshamefullFine);
            var unnominatedFineModel = new FineModel(unnominatedFine);

            //Then
            var bothAreInvalid = unshamefullFineModel.IsValid && unnominatedFineModel.IsValid;

            Assert.False(bothAreInvalid);
        }

        [Test]
        public void GetNominees()
        {
            //Given
            var nominees = (new[] {"@nominee1", "@nominee2", "@nominee3"}).ToList();

            var shamefullFine = string.Format("#Shame random text {0}, {1}, {2}", nominees[0],nominees[1],nominees[2]);

            //When
            var shamefullFineModel = new FineModel(shamefullFine);

            //Then
            bool allNomineesReturned = true;
            foreach (var nominee in nominees)
            {
                allNomineesReturned = shamefullFineModel.Nominees.Contains(nominee);
            }

            Assert.True(allNomineesReturned);
        }

        [Test]
        public void GetFineReason()
        {
            //Given
            const string fineReason = "random text";

            var shamefullFine = string.Format("#Shame {0} @nominee3", fineReason);

            //When
            var shamefullFineModel = new FineModel(shamefullFine);

            //Then
            var hasShamingReason = shamefullFineModel.Reason.Equals(fineReason);

            Assert.True(hasShamingReason);
        }
    }
}
