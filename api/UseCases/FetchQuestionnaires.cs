using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Survey
{
  public class FetchQuestionnaires
  {
    private IGetQuestionnairesGateway gateway;
    public FetchQuestionnaires(IGetQuestionnairesGateway gateway)
    {
      this.gateway = gateway;
    }

    public IEnumerable<Questionnaire> Execute()
    {
      return gateway.getQuestionnaires();
    }
  }
}