using HangarEstimates.Domain.CostIssues;
using HangarEstimates.Domain.HangarIssues;
using HangarEstimates.Infrastructure.Interfaces.Dal;

namespace HangarEstimates.Bll
{
    public class FoundationCostIssueService
    {
        private readonly IRepository _repository;

        public FoundationCostIssueService(IRepository repository)
        {
            _repository = repository;
        }

        //public void AddJobIssue(FoundationCostIssue issue, JobCostIssue jobCostIssue, int count)
        //{
        //    var countableJobIssue = new JobCountableIssue
        //    {
        //        CostIssue = jobCostIssue, 
        //        Count = count
        //    };

        //    issue.JobIssues.Add(jobCostIssue);
        //}
    }
}
