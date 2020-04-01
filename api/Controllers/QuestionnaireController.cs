using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Survey
{
  [Produces("application/json")]
  [Route("api")]

  public class QuestionnaireController
  {

    GetQuestionnairesGateway gateway;
    FetchQuestionnaires fetchQuestionnaires;

    [HttpGet("topics")]
    public string[] ListQuestoinnaireTopics()
    {
      String[] topics = new String[] { "Infrastructure", "Compliance" };
      return topics;
    }

    [HttpGet("questionnaire")]
    public IEnumerable<Questionnaire> ShowQuestionniare()
    {
      NpgsqlConnection conn = new NpgsqlConnection($"Server=127.0.0.1; Port=5432; User Id={Environment.GetEnvironmentVariable("DB_USER")}; Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}; Database=surveys");
      NpgsqlCommand command = new NpgsqlCommand();
      string choices = " ";
      gateway = new GetQuestionnairesGateway(choices, command, conn);
      fetchQuestionnaires = new FetchQuestionnaires(gateway);
      IEnumerable<Questionnaire> results = fetchQuestionnaires.Execute();
      return results;
    }

  }
}