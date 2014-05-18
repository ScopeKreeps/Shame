using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shame.Web.Models.Fine
{
    public class FineNominationModel
    {
        public string Title { get; set; }

        public string Nominee { get; set; }

        public string Offence { get; set; }

        public List<string> Followers { get; set; }
    }
}