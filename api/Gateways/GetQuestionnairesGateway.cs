using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Survey
{
  public class GetQuestionnairesGateway : IGetQuestionnairesGateway
  {

    public GetQuestionnairesGateway()
    {

    }
    public IEnumerable<Questionnaire> getQuestionnaires()
    {
      Questionnaire[] questionnaires = new Questionnaire[]
        {
            new Questionnaire { },
            new Questionnaire { },
        };

      return questionnaires;
    }
  }
}