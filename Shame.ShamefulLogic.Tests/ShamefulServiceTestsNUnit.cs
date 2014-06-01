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
            var fine = string.Format("#Shame random {0} text @nominee", Guid.NewGuid());
            var fineModel = new FineModel(fine);
            
            //When 
            shamefulService.NominateFine(fineModel);
            
            //Then
            var fines = shamefulService.GetFines(1, "PietPompiesDev");
            var finePosted = fines.First().RawTweet == fine;

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
            const string unshamefullyLongFine = "#Shame  @nominee random text wShame random text wShame random text w Shame random text w Shame random text w Shame random text w Shame random text w Shame random text w ";

            //When
            var unshamefullFineModel = new FineModel(unshamefullFine);
            var unnominatedFineModel = new FineModel(unnominatedFine);
            var unshamefullyLongFineFineModel = new FineModel(unshamefullyLongFine);
            
            //Then
            var bothAreInvalid = unshamefullFineModel.IsValid && unnominatedFineModel.IsValid && unshamefullyLongFineFineModel.IsValid;

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
            const string nominees = "@nominee3, @nominee2";

            var shamefullFine = string.Format("#Shame {0} {1}", fineReason, nominees);

            //When
            var shamefullFineModel = new FineModel(shamefullFine);

            //Then
            var hasShamingReason = shamefullFineModel.Reason.Equals(fineReason);

            Assert.True(hasShamingReason);
        }

        [Test]
        public void CreateFine()
        {
            //Given
            const string fineReason = "random text";
            var nominees = (new[] { "@nominee1", "@nominee2", "@nominee3" }).ToList();

            //When
            var shamefullFineModel = new FineModel(fineReason, nominees);

            //Then
            var rawTweetIsCorrect = shamefullFineModel.RawTweet.Equals("#Shame random text @nominee1, @nominee2, @nominee3");

            Assert.True(rawTweetIsCorrect && shamefullFineModel.IsValid);
        }
    }
}
