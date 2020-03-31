using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Data.SqlClient;
using Npgsql;
using dotenv.net;

namespace Survey
{
  [Produces("application/json")]
  [Route("api/products")]

  public class QuestionnaireController
  {

    GetQuestionnairesGateway gateway;
    FetchQuestionnaires fetchQuestionnaires;

    [HttpGet]
    public IEnumerable<Questionnaire> ListAllProducts()
    {
      NpgsqlConnection conn = new NpgsqlConnection($"Server=127.0.0.1; Port=5432; User Id={Environment.GetEnvironmentVariable("DB_USER")}; Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}; Database=surveys");


      gateway = new GetQuestionnairesGateway(conn);
      fetchQuestionnaires = new FetchQuestionnaires(gateway);
      return fetchQuestionnaires.Execute();
    }
  }
}