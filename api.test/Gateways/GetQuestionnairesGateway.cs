using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace Survey
{
  public class GetQuestionnairesGatewayUnitTest
  {
    GetQuestionnairesGateway gateway;

    public class db
    {
      public db()
      {
      }

      public IEnumerable<Questionnaire> request()
      {
        Questionnaire[] questionnaires = new Questionnaire[]
        {
            new Questionnaire { },
            new Questionnaire { },
        };
        return questionnaires;
      }
    }

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void itGetsQuestionnaires()
    {
      // gateway = new GetQuestionnairesGateway();
    }
  }
}