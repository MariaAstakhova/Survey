using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Data.SqlClient;
using Npgsql;

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
      bool boolfound = false;
      using (NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432; User Id=maria; Password=me; Database=surveyApplication"))
      {
        conn.Open();

        NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM survey", conn);
        NpgsqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
          boolfound = true;


          Console.WriteLine("connection established");
        }
        if (boolfound == false)
        {
          Console.WriteLine("Data does not exist");
        }
        dr.Close();
      }

      gateway = new GetQuestionnairesGateway();
      fetchQuestionnaires = new FetchQuestionnaires(gateway);
      return fetchQuestionnaires.Execute();
    }
  }
}