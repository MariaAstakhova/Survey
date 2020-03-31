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
    string output;
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
          while (reader.Read())
          {
            // val = Int32.Parse(reader[0].ToString());
            //do whatever you like
            output = reader[1].ToString();
          }

          conn.Close(); //close the current connection
        }

      }

      Questionnaire[] questionnaires = new Questionnaire[]
        {
            new Questionnaire { Topic=output},
            new Questionnaire { },
        };

      return questionnaires;
    }
  }
}