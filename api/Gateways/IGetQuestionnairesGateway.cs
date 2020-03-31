using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Survey
{
  public interface IGetQuestionnairesGateway
  {
    public IEnumerable<Questionnaire> getQuestionnaires();
  }
}