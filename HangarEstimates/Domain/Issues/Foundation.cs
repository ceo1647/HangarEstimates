using System.Collections.Generic;
using System.Linq;
using HangarEstimates.Domain.CostIssues;
using HangarEstimates.Domain.Costs;
using PropertyChanged;

namespace HangarEstimates.Domain.HangarIssues
{
    [ImplementPropertyChanged]
    public class Foundation : IssueBase
    {
        public Foundation()
        {
            MaterialIssues = new List<MaterialIssue>();
            JobIssues = new List<JobIssue>();
        }
        
        public virtual IList<MaterialIssue> MaterialIssues { get; set; }
        public virtual IEnumerable<JobIssue> JobIssues { get; set; }

        #region Privates
        private IList<JobIssue> _jobIssues;
        private IList<MaterialIssue> _materialIssues;

        #endregion

        public override double GetPrice()
        {
            return _materialIssues.Cast<CostIssueBase>().Union(_jobIssues.Cast<CostIssueBase>()).Sum()
        }
    }
}