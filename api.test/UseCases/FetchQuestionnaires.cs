using NUnit.Framework;
using Moq;

namespace Survey
{
  public class Tests
  {

    private FetchQuestionnaires fetchQuestionnaires;

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void itGroupsQuestionnaires()
    {
      var mockGateway = new Mock<IGetQuestionnairesGateway>();
      Questionnaire[] questionnaires = new Questionnaire[]
        {
            new Questionnaire { },
            new Questionnaire { },
        };

      mockGateway.Setup(p => p.getQuestionnaires()).Returns(questionnaires);
      fetchQuestionnaires = new FetchQuestionnaires(mockGateway.Object);
      fetchQuestionnaires.Execute();
      mockGateway.Verify(mockGateway => mockGateway.getQuestionnaires(), Times.Once());
    }
  }
}