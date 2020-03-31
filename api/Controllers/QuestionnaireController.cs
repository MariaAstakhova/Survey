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
      gateway = new GetQuestionnairesGateway();
      fetchQuestionnaires = new FetchQuestionnaires(gateway);
      return fetchQuestionnaires.Execute();
    }
  }
}