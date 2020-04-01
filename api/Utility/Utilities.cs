using System;
using System.Collections.Generic;

namespace Survey
{
  public class Utility
  {
    public string makeQuery(string[] topics)
    {
      string topicQuery = "ANY('{";
      for (int i = 0; i < topics.Length; i++)
      {
        topicQuery += topics[i];
      }
      topicQuery += "}')";
      return topicQuery;
    }
  }
}