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
    public IEnumerable<Questionnaire> ShowQuestionniare([FromBody] string[] topics)
    {
      NpgsqlConnection conn = new NpgsqlConnection($"Server=127.0.0.1; Port=5432; User Id={Environment.GetEnvironmentVariable("DB_USER")}; Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}; Database=surveys");
      string[] choices = new string[] { };
      gateway = new GetQuestionnairesGateway(choices, conn);
      fetchQuestionnaires = new FetchQuestionnaires(gateway);
      return fetchQuestionnaires.Execute();
    }


  }
}