using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using Npgsql;
using System.Net.Http;
using System.Net;


namespace Survey
{
  [Produces("application/json")]
  [Route("api")]

  public class QuestionnaireController
  {

    GetQuestionnairesGateway gateway;
    FetchQuestionnaires fetchQuestionnaires;

    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    [HttpGet("topics")]
    public Topic[] ListQuestoinnaireTopics()
    {
      Topic[] topics = new Topic[]
        {
            new Topic { topicText="Infrastructure"},
            new Topic { topicText= "Compliance"},
        };
      return topics;
    }

    [HttpGet("questionnaire")]
    public IEnumerable<Questionnaire> ShowQuestionniare()
    {
      //[FromBody] string[] topics
      NpgsqlConnection conn = new NpgsqlConnection($"Server=127.0.0.1; Port=5432; User Id={Environment.GetEnvironmentVariable("DB_USER")}; Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}; Database=surveys");
      //string[] choices = new string[] { };
      String[] choices = new string[2] { "Infrastructure", "Compliancy" };
      gateway = new GetQuestionnairesGateway(choices, conn);
      fetchQuestionnaires = new FetchQuestionnaires(gateway);
      return fetchQuestionnaires.Execute();
    }


  }
}