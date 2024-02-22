﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Shop_Management_System
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\leoca\Documents\Mobile MS.mdf"";Integrated Security=True;Connect Timeout=30");

        private void FetchCus()
        {
            try
            {
                Con.Open();
                string query = "select * from CTBL WHERE CId= '" + textBox1.Text + "'";
                SqlCommand sql = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sql);
                sda.Fill(dt); 
                foreach (DataRow dr in dt.Rows)
                {
                    label9.Text = dr["CId"].ToString();
                    label10.Text = dr["CName"].ToString();
                    label11.Text = dr["Gender"].ToString();
                    label12.Text = dr["Address"].ToString();
                    label13.Text = dr["ItemPurchased"].ToString();
                    label14.Text = dr["Bill"].ToString();
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label14.Visible = true;
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally 
            {
                Con.Close();
            }
        }
        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            FetchCus();
        }
    }
}
