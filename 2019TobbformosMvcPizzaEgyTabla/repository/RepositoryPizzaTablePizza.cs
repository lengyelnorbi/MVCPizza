﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TobbbformosPizzaAlkalmazasEgyTabla.Model;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using _2019TobbformosMvcPizzaEgyTabla.model;

namespace TobbbformosPizzaAlkalmazasEgyTabla.Repository
{
    partial class RepositoryDatabaseTablePizza
    {
        private readonly string connectionStringCreate;
        private readonly string connectionString;

        /// <summary>
        /// Konstruktor - kezdőértékadások
        /// </summary>
        public RepositoryDatabaseTablePizza()
        {
            connectionStringCreate =
                "SERVER=\"localhost\";"
                + "DATABASE=\"test\";"
                + "UID=\"root\";"
                + "PASSWORD=\"\";"
                + "PORT=\"3306\";";
            connectionString =
                "SERVER=\"localhost\";"
                + "DATABASE=\"csarp\";"
                + "UID=\"root\";"
                + "PASSWORD=\"\";"
                + "PORT=\"3306\";";
        }

        /// <summary>
        /// csarp adatbázisban pizza tábla létrehozása
        /// </summary>
        public void createTablePizza()
        {
            string queryUSE = "USE csarp;";
            string queryCreateTable =
                "CREATE TABLE `ppizza` ( " +
                "   `pazon` int(3) NOT NULL DEFAULT '0', " +
                "   `pnev` varchar(15) COLLATE latin2_hungarian_ci NOT NULL DEFAULT '', " +
                "   `par` int(4) NOT NULL DEFAULT '0' " +
            ")ENGINE = InnoDB; ";
            string queryPrimaryKey =
                "ALTER TABLE `ppizza` ADD PRIMARY KEY(`pazon`); ";

            MySqlConnection connection =
                new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();
                MySqlCommand cmdCreateTable = new MySqlCommand(queryCreateTable, connection);
                cmdCreateTable.ExecuteNonQuery();
                MySqlCommand cmdPrimaryKey = new MySqlCommand(queryPrimaryKey, connection);
                cmdPrimaryKey.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tábla lérehozása sikertelen.");
            }
        }
     
        /// <summary>
        /// pizza tábla törlése csarp adatbázisból
        /// </summary>
        public void deleteTablePizza()
        {
            string query =
                "USE csarp; " +
                "DROP TABLE ppizza;";

            MySqlConnection connection =
                new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tábla törlése nem sikerült.");
            }
        }

        public void deleteDataFromTable()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Pizza.getSQLCommandDeleteAllRecord();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tesztadatok törlése sikertelen.");
            }
        }

        public void createTableFutar()
        {
            string queryUSE = "USE csarp;";
            string queryCreateTable =
                "CREATE TABLE `futarok` ( " +
                "   `futarazon` int(3) NOT NULL DEFAULT '0', " +
                "   `futarnev` varchar(30) COLLATE latin2_hungarian_ci NOT NULL DEFAULT '', " +
                "   `futarlakcim` varchar(100) COLLATE latin2_hungarian_ci NOT NULL DEFAULT '', " +
                "   `futartelszam` varchar(15) COLLATE latin2_hungarian_ci NOT NULL DEFAULT '', " +
                "   `futaremail` varchar(30) COLLATE latin2_hungarian_ci NOT NULL DEFAULT ''" +
            ")ENGINE = InnoDB; ";
            string queryPrimaryKey =
                "ALTER TABLE `futarok` ADD PRIMARY KEY(`futarazon`); ";

            MySqlConnection connection =
                new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();
                MySqlCommand cmdCreateTable = new MySqlCommand(queryCreateTable, connection);
                cmdCreateTable.ExecuteNonQuery();
                MySqlCommand cmdPrimaryKey = new MySqlCommand(queryPrimaryKey, connection);
                cmdPrimaryKey.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tábla lérehozása sikertelen.");
            }
        }

        /// <summary>
        /// pizza tábla törlése csarp adatbázisból
        /// </summary>
        public void deleteTableFutar()
        {
            string query =
                "USE csarp; " +
                "DROP TABLE futarok;";

            MySqlConnection connection =
                new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tábla törlése nem sikerült.");
            }
        }

        public void deleteDataFromFutarTable()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Futar.getSQLCommandFutarDeleteAllRecord();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tesztadatok törlése sikertelen.");
            }
        }
    }
}
