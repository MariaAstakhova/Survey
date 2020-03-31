using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using Npgsql;

namespace Survey
{
  public class GetQuestionnairesGatewayUnitTest
  {
    GetQuestionnairesGateway gateway;




    Questionnaire[] questionnaires = new Questionnaire[]
    {
            new Questionnaire { },
            new Questionnaire { },
    };




    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void itGetsQuestionnaires()
    {
      var mockDb = new Mock<NpgsqlConnection>();
      mockDb.Verify(mockDb => mockDb.Open(), Times.Once());
      //conn.Open();
      // gateway = new GetQuestionnairesGateway();
    }
  }
}