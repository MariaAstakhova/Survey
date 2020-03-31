using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Survey
{
  public class Questionnaire
  {
    public string Topic { get; set; }

    public Question[] questions { get; set; }
  }
}
