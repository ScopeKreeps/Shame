using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shame.ShamefulLogic
{
    public class FineModel
    {
        private readonly Regex _shamefullRegex = new Regex(@"#(?i)shame(?-i)");
        private readonly Regex _fineNomineeRegex = new Regex(@"(@[\w]*)[\s]*?");


        public string RawTweet { get; set; }
        public bool IsValid
        {
            get { return IsShamefull() && HasNominee(); }
        }

        public List<string> Nominees
        {
            get { return GetNominees(); }
        }

        public string Reason
        {
            get { return GetFineReason(); }
        }

        public FineModel(string tweet)
        {
            RawTweet = tweet;
        }

        private bool IsShamefull()
        {
            return _shamefullRegex.IsMatch(RawTweet);
        }

        private bool HasNominee()
        {
            return _fineNomineeRegex.IsMatch(RawTweet);
        }

        private List<string> GetNominees()
        {
            return (from Match match in _fineNomineeRegex.Matches(RawTweet) select match.Value.Trim()).ToList();
        }

        private string GetFineReason()
        {
            var removedShameTag = _shamefullRegex.Replace(RawTweet, string.Empty);
            var removedShameTagAndNominee = _fineNomineeRegex.Replace(removedShameTag, string.Empty);

            return removedShameTagAndNominee.Trim();
        }
    }
}
