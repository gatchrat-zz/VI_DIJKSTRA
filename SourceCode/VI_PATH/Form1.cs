using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VI_PATH
{
    public partial class Form1 : Form
    {
        bool working = false;
        bool backtracking = false;
        Knoten[,] Daten;
        Knoten actuell = new Knoten(0, 0);
        List<Knoten> unvisited = new List<Knoten>();
        // 0 = nothing 1 = Obstacle 2 = Start 3 = Finish 
        int editModus;

        public Form1()
        {
            editModus = 0;
            Daten = new Knoten[15, 30];

            InitializeComponent();
            Feld.ReadOnly = true;
            Feld.ColumnCount = 30;
            Feld.RowCount = 15;
            Feld.AllowUserToResizeRows = false;
            Feld.AllowUserToResizeColumns = false;
            for (int i = 0; i < Feld.ColumnCount; i++)
            {
                Feld.Columns[i].Width = 20;
               
            }
            for (int a = 0; a < 15; a++)
            {
                for (int b = 0; b < 30; b++)
                {
                    Daten[a, b] = new Knoten(a,b);
                   

                }
            }
        }
        //search
        private void button4_Click(object sender, EventArgs e)
        {
            //preparing
            
            
            for (int a = 0; a <15; a++)
            {
                for (int b = 0; b < 30; b++)
                {
                    if (Daten[a,b].state != 1)
                    {
                        unvisited.Add( Daten[a, b]);
                    }
                     
                }
            }
            working = true;
            //work

           
            //Backtrack
            
           
        }


        //Colours in the fields when editing
        private void selectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in Feld.SelectedCells)
            {
                int x = cell.RowIndex;
                int y = cell.ColumnIndex;
                switch (editModus)
                {
                    case 0:
                        Daten[x, y].distance = 999;
                        cell.Style.BackColor = Color.White;
                        Daten[x, y].visited = false;

                        break;
                    case 1:
                        Daten[x, y].distance = 9999;
                        cell.Style.BackColor = Color.Red;
                        break;
                    case 2:
                        Daten[x, y].distance = 0;
                        cell.Style.BackColor = Color.Green;
                        break;
                    case 3:
                        Daten[x, y].distance = 999;
                        cell.Style.BackColor = Color.Blue;
                        break;

                }
                Daten[x, y].state = editModus;
            }
        }
        

        private void Feld_MouseUp(object sender, MouseEventArgs e)
        {
            Feld.ClearSelection();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Start
        private void button3_Click(object sender, EventArgs e)
        {
            editModus = 2;
        }
        //Finish
        private void button1_Click(object sender, EventArgs e)
        {
            editModus = 3;
        }
        //Obstacle
        private void button2_Click(object sender, EventArgs e)
        {
            editModus = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            editModus = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region working
            if (working == true) { 
                //find smallest distance
                int min = unvisited.ElementAt(0).distance;
                actuell = unvisited.ElementAt(0);
                for (int i = 0; i < unvisited.Count; i++)
                {
                    if (unvisited.ElementAt(i).distance <= min)
                    {
                        min = unvisited.ElementAt(i).distance;
                        actuell = unvisited.ElementAt(i);

                    }
                }
                if (actuell.state == 3)
                {
                    working = false;
                    backtracking = true;
                }
                unvisited.Remove(actuell);
                Daten[actuell.pos[0], actuell.pos[1]].visited = true;
                //scan neighbours
                //right
                if (actuell.pos[0] + 1 < 15
                    && Daten[actuell.pos[0] + 1, actuell.pos[1]].visited == false
                    && Daten[actuell.pos[0] + 1, actuell.pos[1]].distance > (actuell.distance + 1)
                    && Daten[actuell.pos[0] + 1, actuell.pos[1]].state != 1)
                {
                    Daten[actuell.pos[0] + 1, actuell.pos[1]].dad[0] = actuell.pos[0];
                    Daten[actuell.pos[0] + 1, actuell.pos[1]].dad[1] = actuell.pos[1];
                    Daten[actuell.pos[0] + 1, actuell.pos[1]].distance = actuell.distance + 1;
                    if (Daten[actuell.pos[0] + 1, actuell.pos[1]].state == 0)
                    {
                        Feld[actuell.pos[1], actuell.pos[0] + 1].Style.BackColor = Color.LightSalmon;
                    }
                }
                //left
                if (actuell.pos[0] - 1 > -1
                    && Daten[actuell.pos[0] - 1, actuell.pos[1]].visited == false
                    && Daten[actuell.pos[0] - 1, actuell.pos[1]].distance > (actuell.distance + 1)
                    && Daten[actuell.pos[0] - 1, actuell.pos[1]].state != 1)
                {
                    Daten[actuell.pos[0] - 1, actuell.pos[1]].dad[0] = actuell.pos[0];
                    Daten[actuell.pos[0] - 1, actuell.pos[1]].dad[1] = actuell.pos[1];
                    Daten[actuell.pos[0] - 1, actuell.pos[1]].distance = actuell.distance + 1;
                    if (Daten[actuell.pos[0] - 1, actuell.pos[1]].state == 0)
                    {
                        Feld[actuell.pos[1], actuell.pos[0] - 1].Style.BackColor = Color.LightSalmon;
                    }
                }
                //up
                if (actuell.pos[1] + 1 < 30
                    && Daten[actuell.pos[0], actuell.pos[1] + 1].visited == false
                    && Daten[actuell.pos[0], actuell.pos[1] + 1].distance > (actuell.distance + 1)
                    && Daten[actuell.pos[0], actuell.pos[1] + 1].state != 1)
                {
                    Daten[actuell.pos[0], actuell.pos[1] + 1].dad[0] = actuell.pos[0];
                    Daten[actuell.pos[0], actuell.pos[1] + 1].dad[1] = actuell.pos[1];
                    Daten[actuell.pos[0], actuell.pos[1] + 1].distance = actuell.distance + 1;
                    if (Daten[actuell.pos[0], actuell.pos[1] + 1].state == 0)
                    {
                        Feld[actuell.pos[1] + 1, actuell.pos[0]].Style.BackColor = Color.LightSalmon;
                    }
                }
                //down
                if (actuell.pos[1] - 1 > -1
                    && Daten[actuell.pos[0], actuell.pos[1] - 1].visited == false
                    && Daten[actuell.pos[0], actuell.pos[1] - 1].distance > (actuell.distance + 1)
                    && Daten[actuell.pos[0], actuell.pos[1] - 1].state != 1)
                {
                    Daten[actuell.pos[0], actuell.pos[1] - 1].dad[0] = actuell.pos[0];
                    Daten[actuell.pos[0], actuell.pos[1] - 1].dad[1] = actuell.pos[1];
                    Daten[actuell.pos[0], actuell.pos[1] - 1].distance = actuell.distance + 1;
                    if (Daten[actuell.pos[0], actuell.pos[1] - 1].state == 0)
                    {
                        Feld[actuell.pos[1] - 1, actuell.pos[0]].Style.BackColor = Color.LightSalmon;
                    }

                }
                //refresh unvisited
                unvisited.Clear();
                for (int a = 0; a < 15; a++)
                {
                    for (int b = 0; b < 30; b++)
                    {
                        if (Daten[a, b].state != 1 && Daten[a, b].visited == false)
                        {
                            unvisited.Add(Daten[a, b]);
                        }

                    }
                }
            }
            #endregion
            #region backtracking
            if (backtracking)
            {
                actuell = Daten[actuell.dad[0], actuell.dad[1]];
                if (actuell.state == 2)
                {
                    backtracking = false;
                    
                }
                else
                {
                   
                    Feld[actuell.pos[1], actuell.pos[0]].Style.BackColor = Color.Yellow;
                }
            }
            #endregion
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "MainMenu")
                {
                    form.Show();
                }
            }
            this.Close();
        }
    }
}
