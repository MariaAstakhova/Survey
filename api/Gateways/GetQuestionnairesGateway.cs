using System;
using System.Collections.Generic;
using System.IO;
using Npgsql;
using Newtonsoft.Json;

namespace Survey
{
  public class GetQuestionnairesGateway : IGetQuestionnairesGateway
  {
    string choices;
    NpgsqlConnection conn;
    NpgsqlCommand command;
    String[] topics = new String[2];
    String[] paths = new String[2];


    public GetQuestionnairesGateway(string choices, NpgsqlCommand command, NpgsqlConnection conn)
    {
      this.choices = choices;
      this.conn = conn;
      this.command = command;
    }
    public IEnumerable<Questionnaire> getQuestionnaires()
    {

      string query = "SELECT * FROM survey WHERE topic = ANY('{Compliance, Infrastructure}')";
      conn.Open();
      command.CommandText = query;
      command.Connection = conn;

      using (command)
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
      }
      conn.Close();

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