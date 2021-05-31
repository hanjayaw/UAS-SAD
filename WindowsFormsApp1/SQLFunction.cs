﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class SqlFunction
    {
        private string tableName;
        private MySqlConnection connSql;
        public SqlFunction(string connString)
        {
            connSql = new MySqlConnection(connString);
        }
        public DataTable selectQuery(string queryString)
        {

            string query = queryString;
            MySqlCommand sqlCommand = new MySqlCommand(query, connSql);
            if(connSql.State == ConnectionState.Open)
            {
                connSql.Close();
            }
            connSql.Open();
            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();
            sqlAdapter.SelectCommand = sqlCommand;
            DataTable dt = new DataTable();
            sqlAdapter.Fill(dt);
            connSql.Close();
            return dt;


        }
        public void insertQuery(string queryString)
        {
            string query = queryString;
            MySqlCommand sqlCommand = new MySqlCommand(query, connSql);
            MySqlDataReader sqlReader;
            connSql.Open();
            sqlCommand.ExecuteNonQuery();
            connSql.Close();
        }
        public void updateQuery(string queryString)
        {
            string query = queryString;
            MySqlCommand sqlCommand = new MySqlCommand(query, connSql);
            MySqlDataReader sqlReader;
            connSql.Open();
            sqlCommand.ExecuteNonQuery();
            connSql.Close();
        }
        public void deleteQuery(string queryString)
        {
            string query = queryString;
            MySqlCommand sqlCommand = new MySqlCommand(query, connSql);
            MySqlDataReader sqlReader;
            connSql.Open();
            sqlCommand.ExecuteNonQuery();
            connSql.Close();
        }
        public void runFunctions(string queryString)
        {
            string query = queryString;
            MySqlCommand sqlCommand = new MySqlCommand(query, connSql);
            MySqlDataReader sqlReader;
            connSql.Open();
            sqlCommand.ExecuteNonQuery();
            connSql.Close();
        }
    }
}
