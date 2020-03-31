using System.Collections.Generic;


namespace Survey
{
  public class GetQuestionnairesGateway : IGetQuestionnairesGateway
  {
    //User ID=maria;Password=me;Host=localhost;Port=5432

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