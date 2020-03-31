using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;


namespace Survey
{
  public class GetQuestionnairesGateway : IGetQuestionnairesGateway
  {
    //User ID=maria;Password=me;Host=localhost;Port=5432
    NpgsqlConnection conn;
    String[] topics = new String[2];
    String[] paths = new String[2];
    public GetQuestionnairesGateway(NpgsqlConnection conn)
    {
      this.conn = conn;
    }
    public IEnumerable<Questionnaire> getQuestionnaires()
    {

      using (conn)
      {
        conn.Open();
        string sql = "SELECT * FROM survey ";

        using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
        {
          NpgsqlDataReader reader = command.ExecuteReader();
          var i = 0;
          while (reader.Read())
          {
            // val = Int32.Parse(reader[0].ToString());
            //do whatever you like
            string topic = reader.GetString(reader.GetOrdinal("topic"));
            //output = reader[1].ToString();
            string path = reader.GetString(reader.GetOrdinal("path"));

            topics[i] = topic;
            paths[i] = path;
            i++;
          }

          conn.Close(); //close the current connection
        }

      }


      Questionnaire[] questionnaires = new Questionnaire[]
        {
            new Questionnaire { Topic=topics[0]},
            new Questionnaire { Topic=topics[1]},
        };

      return questionnaires;
    }
  }
}