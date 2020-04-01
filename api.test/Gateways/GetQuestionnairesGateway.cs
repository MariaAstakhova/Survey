using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using Npgsql;

namespace Survey
{
  public class GetQuestionnairesGatewayUnitTest
  {

    public class MockConnection
    {
      public bool Opened { get; set; }

      public MockConnection()
      {
        Opened = false;
      }

      public void Open()
      {
        Opened = true;
      }

    }

    public class MockCommand
    {

      public MockCommand(string query)
      {

      }

    }

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
    public void itOpensAConnection()
    {
      MockConnection conn = new MockConnection();
      NpgsqlCommand command = new NpgsqlCommand();
      string choices = "choices array";
      gateway = new GetQuestionnairesGateway(choices, command, conn);

      // mockDb.Verify(mockDb => mockDb.Open(), Times.Once());
      //.Setup(foo => foo.DoSomething("ping")).Returns(true);

    }

    [Test]
    public void itQueriesDbForOneTopic()
    {


    }
  }
}