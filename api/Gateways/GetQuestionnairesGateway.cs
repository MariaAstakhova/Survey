using System;
using System.Collections.Generic;
using System.IO;
using Npgsql;
using Newtonsoft.Json;

namespace Survey
{
  public class GetQuestionnairesGateway : IGetQuestionnairesGateway
  {
    string[] choices = new string[] { };
    NpgsqlConnection conn;
    String[] topics = new String[2];
    String[] paths = new String[2];
    public GetQuestionnairesGateway(string[] choices, NpgsqlConnection conn)
    {
      this.conn = conn;
    }
    public IEnumerable<Questionnaire> getQuestionnaires()
    {

      using (conn)
      {
        conn.Open();
        string query = "SELECT * FROM survey WHERE topic = ANY('{Compliance, Infrastructure}')";
        using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
        {
          NpgsqlDataReader reader = command.ExecuteReader();
          var i = 0;
          while (reader.Read())
          {
            string topic = reader.GetString(reader.GetOrdinal("topic"));
            string path = reader.GetString(reader.GetOrdinal("path"));

            topics[i] = topic;
            paths[i] = path;
            i++;
          }

          conn.Close(); //close the current connection
        }

      }

      List<Questionnaire> questionnaires = new List<Questionnaire>();

      for (int i = 0; i < paths.Length; i++)
      {
        using (StreamReader r = new StreamReader(paths[i]))
        {
          string json = r.ReadToEnd();
          Questionnaire questionnaire = JsonConvert.DeserializeObject<Questionnaire>(json);
          questionnaires.Add(questionnaire);
        }
      }

      return questionnaires;
    }
  }
}