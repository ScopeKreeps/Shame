using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shame.ShamefulLogic
{
    public class CustomShamefulService : IShamefulService
    {
        public void NominateFine(string fine)
        {
            throw new NotImplementedException();
        }

        public string[] GetFines(int count, string screenName) 
        {
            throw new NotImplementedException();
        }

        public List<string> GetFollowers(string screenName)
        {
            throw new NotImplementedException();
        }   
    }
}
