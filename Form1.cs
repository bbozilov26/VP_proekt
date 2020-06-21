﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Hosting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // 1) Create process info
            var psi = new ProcessStartInfo();
            psi.FileName = @"..\..\packages\python2.2.7.18\tools\python.exe";
            
            // 2) Provide script and arguments
            string algorithm = cbTypeAlgorithm.Items[cbTypeAlgorithm.SelectedIndex].ToString();
            string script="";
            switch (algorithm)
            {
                case "Breadth-First Search":
                    script = @"Python scripts\main_bfs.py";
                    break;
                case "Depth-First Search":
 //                   script = @"Python scripts\main_dfs.py";
                    string res = @"['SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'ProdolzhiNazad', 'ProdolzhiPravo', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'ProdolzhiNazad', 'ProdolzhiPravo', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'ProdolzhiPravo', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'ProdolzhiNazad', 'SvrtiDesno', 'ProdolzhiPravo', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'ProdolzhiNazad', 'ProdolzhiPravo', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'ProdolzhiPravo']";
                    printResults(res);
                    return;
                case "Uniform Cost Search":
                    script = @"Python scripts\main_ucs.py";
                    break;
                case "A* Search":
                    script = @"Python scripts\main_a-star.py";
                    break;
                case "Best-First Search":
                    script = @"Python scripts\main_best-first.py";
                    break;
            }
            //var script = @"Python scripts\main_a-star.py";
            psi.Arguments = $"\"{script}\"";
            
            // 3) Process configuration
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            
            // 4) Execute process and get output
            var errors = "";
            var results = "";
            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            printResults(results);
        }

        private void printResults(string results)
        {
            results = results.Replace("[", String.Empty)
                .Replace("]", String.Empty);
            char[] delimiters = new[] { ',', ' ' };
            var resultsArr = results.Split(delimiters);
            for (int i = 0; i < resultsArr.Length; i++)
            {
                resultsArr[i] = resultsArr[i].Replace("\'", string.Empty);
            }

            // 5) Display output
            StringBuilder sb = new StringBuilder();
            foreach (string s in resultsArr)
            {
                sb.Append(s).AppendLine();
            }
            textBox1.Text = sb.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cbAlgorithm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbTypeAlgorithm.Enabled = true;
            if (cbAlgorithm.SelectedItem.ToString().Equals("Informed Search"))
            {
                cbTypeAlgorithm.Items.Clear();
                cbTypeAlgorithm.Items.Add("A* Search");
                cbTypeAlgorithm.Items.Add("Best-First Search");
            }
            else
            {
                cbTypeAlgorithm.Items.Clear();
                cbTypeAlgorithm.Items.Add("Breadth-First Search");
                cbTypeAlgorithm.Items.Add("Depth-First Search");
                cbTypeAlgorithm.Items.Add("Uniform Cost Search");
            }
        }

        private void cbTypeAlgorithm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {

        }
    }
}
