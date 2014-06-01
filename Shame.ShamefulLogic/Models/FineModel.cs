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
        private const int _maxFineLength = 140;
        private readonly Regex _shamefullRegex = new Regex(@"#(?i)shame(?-i)");
        private readonly Regex _fineNomineeRegex = new Regex(@"(@[\w]*)[\s]*?");
        private readonly Regex _removeFineNomineeRegex = new Regex(@"((@[\w]*)[\s]*?[\s,-]*)");
        
        public string RawTweet { get; set; }
        public bool IsValid
        {
            get { return IsShamefull() && HasNominee() && IsWithInCharacterLimit(); }
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

        public FineModel(string reason, List<string> nominees)
        {
            ConstructRawTweet(reason, nominees);
        }

        private void ConstructRawTweet(string reason, List<string> nominees)
        {
            var buildRawTweet = new StringBuilder();
            buildRawTweet.Append(string.Format("{0} ", reason));

            buildRawTweet.Append(nominees[0]);
            for (int index = 1; index < nominees.Count(); index++)
            {
                buildRawTweet.Append(string.Format(", {0}", nominees[index]));
            }

            RawTweet = string.Format("#Shame {0}", _shamefullRegex.Replace(buildRawTweet.ToString(), string.Empty));
        }

        private bool IsShamefull()
        {
            return _shamefullRegex.IsMatch(RawTweet);
        }

        private bool HasNominee()
        {
            return _fineNomineeRegex.IsMatch(RawTweet);
        }

        private bool IsWithInCharacterLimit()
        {
            return RawTweet.Length <= _maxFineLength;
        }

        private List<string> GetNominees()
        {
            return (from Match match in _fineNomineeRegex.Matches(RawTweet) select match.Value.Trim()).ToList();
        }

        private string GetFineReason()
        {
            var removedShameTag = _shamefullRegex.Replace(RawTweet, string.Empty);
            var removedShameTagAndNominee = _removeFineNomineeRegex.Replace(removedShameTag, string.Empty);

            return removedShameTagAndNominee.Trim();
        }
    }
}
