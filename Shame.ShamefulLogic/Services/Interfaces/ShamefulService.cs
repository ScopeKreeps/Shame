using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shame.ShamefulLogic
{
    public interface IShamefulService
    {
        void NominateFine(FineModel fine);

        List<FineModel> GetFines(int count, string screenName);

        List<string> GetFollowers(string screenName);
    }
}
