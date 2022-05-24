using System;
using System.Data.SqlClient;

namespace csharp_db_connection // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string stringaDiConnessione = "Data Source=localhost;Initial Catalog=biblioteca;Integrated Security=True;Pooling=False";

            using (SqlConnection conn = new SqlConnection(stringaDiConnessione))
            { 

                conn.Open();  // apre la connessione al database


                using (SqlCommand insert = new SqlCommand(@"insert into clienti (Id, Nome, Cognome, Codice_cliente)
                value (1,'nome', 'cognome', 154)", conn))
                { 
                    var numrows =insert.ExecuteNonQuery();
                    Console.WriteLine(numrows);
                
                }



                string query = "select * from clienti";

                using (SqlCommand queryCommand = new SqlCommand(query, conn))
                {

                    using (SqlDataReader reader = queryCommand.ExecuteReader())
                    {
                        Console.WriteLine(reader.FieldCount);

                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; ++i)
                                Console.Write("{0}, ", reader[i]);
                                Console.WriteLine();
                        }
                    }
                }

            }

        }
    }
}