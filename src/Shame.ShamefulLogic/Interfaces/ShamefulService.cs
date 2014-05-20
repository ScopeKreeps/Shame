using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shame.ShamefulLogic
{
    public interface IShamefulService
    {
        void NominateFine(string fine);

        string[] GetFines(int count, string screenName);
    }
}
