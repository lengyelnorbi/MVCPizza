﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TobbbformosPizzaAlkalmazasEgyTabla.Model;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace TobbbformosPizzaAlkalmazasEgyTabla.Repository
{
    partial class RepositoryDatabaseTablePizza
    {
   /*     public void fillPizzasWithTestDataFromTestData(List<Pizza> pizzas)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                foreach (Pizza p in pizzas)
                {
                    string query = p.getInsert();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tesztadatok feltöltése sikertelen.");
            }
        }*/

        public void fillPizzasWithTestDataFromSQLCommand()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();

                string query =
                    "INSERT INTO `ppizza` (`pazon`, `pnev`, `par`) VALUES " +
                            " (1, 'Capricciosa', 900), " +
                            " (2, 'Frutti di Mare', 1100), " +
                            " (3, 'Hawaii', 780), " +
                            " (4, 'Vesuvio', 890), " +
                            " (5, 'Sorrento', 990); ";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tesztadatok feltöltése sikertelen.");
            }
        }
        public void fillFutarokWithTestDataFromSQLCommand()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();

                string query =
                    "INSERT INTO `futarok` (`futarazon`, `futarnev`, `futarlakcim`, `futartelszam`, `futaremail`) VALUES " +
                            " (1,'Dani','Szeged Sztriha Kálmán utca 18', '06200000000', 'lengyelnorbi5@gmail.com'), " +
                            " (2,'Dani','Szeged Sztriha Kálmán utca 18', '06200000000', 'lengyelnorbi5@gmail.com'), " +
                            " (3,'Dani','Szeged Sztriha Kálmán utca 18', '06200000000', 'lengyelnorbi5@gmail.com'), " +
                            " (4,'Dani','Szeged Sztriha Kálmán utca 18', '06200000000', 'lengyelnorbi5@gmail.com'), " +
                            " (5,'Dani','Szeged Sztriha Kálmán utca 18', '06200000000', 'lengyelnorbi5@gmail.com'); ";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tesztadatok feltöltése sikertelen.");
            }
        }
    }
}
