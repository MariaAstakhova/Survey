using System.Collections.Generic;


namespace Survey
{
  public interface IGetQuestionnairesGateway
  {
    public IEnumerable<Questionnaire> getQuestionnaires();
  }
}