using System;
using System.Collections.Generic;
using System.IO;
using Npgsql;
using Newtonsoft.Json;

namespace Survey
{
  public class GetQuestionnairesGateway : IGetQuestionnairesGateway
  {
    string query;
    NpgsqlConnection conn;
    String[] topics = new String[2];
    String[] paths = new String[2];
    public GetQuestionnairesGateway(string query, NpgsqlConnection conn)
    {
      this.query = query;
      this.conn = conn;
    }
    public IEnumerable<Questionnaire> getQuestionnaires()
    {

      using (conn)
      {
        conn.Open();

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

      Questionnaire questionnaire;
      using (StreamReader r = new StreamReader(paths[0]))
      {
        string json = r.ReadToEnd();
        questionnaire = JsonConvert.DeserializeObject<Questionnaire>(json);
      }


      Questionnaire[] questionnaires = new Questionnaire[]
        {
            questionnaire,
        };

      return questionnaires;
    }
  }
}