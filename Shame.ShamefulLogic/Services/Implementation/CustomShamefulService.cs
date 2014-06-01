using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shame.ShamefulLogic
{
    public class CustomShamefulService : IShamefulService
    {
        public void NominateFine(FineModel fine)
        {
            throw new NotImplementedException();
        }

        public List<FineModel> GetFines(int count, string screenName) 
        {
            throw new NotImplementedException();
        }

        public List<string> GetFollowers(string screenName)
        {
            throw new NotImplementedException();
        }   
    }
}
