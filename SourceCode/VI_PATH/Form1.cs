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
        
        Knoten[,] Daten;
        
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
            List<Knoten> unvisited = new List<Knoten>();
            Knoten actuell  =new Knoten(0,0);
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
            //work
            while (unvisited.Count>1)
            {
                //find smallest distance
                int min = unvisited.ElementAt(0).distance;
                actuell = unvisited.ElementAt(0);
                for (int i = 0; i < unvisited.Count; i++)
                {
                    if (unvisited.ElementAt(i).distance <= min )
                    {
                        min = unvisited.ElementAt(i).distance;
                        actuell = unvisited.ElementAt(i);
                        
                    }
                }
                if (actuell.state == 3)
                {
                    Console.WriteLine("Finish found");
                    break;
                }
                unvisited.Remove(actuell);
                Daten[actuell.pos[0], actuell.pos[1]].visited = true;
                //scan neighbours
                //right
                if (actuell.pos[0] + 1 < 15
                    && Daten[actuell.pos[0]+1, actuell.pos[1]].visited == false 
                    && Daten[actuell.pos[0]+1, actuell.pos[1]].distance > (actuell.distance + 1)
                    && Daten[actuell.pos[0] + 1, actuell.pos[1]].state != 1)
                {
                    Daten[actuell.pos[0] + 1, actuell.pos[1]].dad[0] = actuell.pos[0];
                    Daten[actuell.pos[0] + 1, actuell.pos[1]].dad[1] = actuell.pos[1];
                    Daten[actuell.pos[0] + 1, actuell.pos[1]].distance = actuell.distance + 1;
                    if (Daten[actuell.pos[0] +1, actuell.pos[1] ].state == 0)
                    {
                        Feld[actuell.pos[1] , actuell.pos[0]+1].Style.BackColor = Color.Beige;
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
                    if (Daten[actuell.pos[0] -1 , actuell.pos[1] ].state == 0)
                    {
                        Feld[actuell.pos[1], actuell.pos[0] -1].Style.BackColor = Color.Beige;
                    }
                }
                //up
                if (actuell.pos[1] + 1 < 30
                    && Daten[actuell.pos[0] , actuell.pos[1] + 1].visited == false
                    && Daten[actuell.pos[0] , actuell.pos[1] + 1].distance > (actuell.distance + 1)
                    && Daten[actuell.pos[0] , actuell.pos[1] + 1].state != 1)
                {
                    Daten[actuell.pos[0] , actuell.pos[1] + 1].dad[0] = actuell.pos[0];
                    Daten[actuell.pos[0] , actuell.pos[1] + 1].dad[1] = actuell.pos[1];
                    Daten[actuell.pos[0] , actuell.pos[1] + 1].distance = actuell.distance + 1;
                    if (Daten[actuell.pos[0], actuell.pos[1] + 1].state == 0)
                    {
                        Feld[actuell.pos[1] + 1, actuell.pos[0]].Style.BackColor = Color.Beige;
                    }
                }
                //down
                if (actuell.pos[1] - 1 > -1
                    && Daten[actuell.pos[0] , actuell.pos[1] - 1].visited == false
                    && Daten[actuell.pos[0] , actuell.pos[1] - 1].distance > (actuell.distance + 1)
                    && Daten[actuell.pos[0] , actuell.pos[1] - 1].state != 1)
                {
                    Daten[actuell.pos[0] , actuell.pos[1] - 1].dad[0] = actuell.pos[0];
                    Daten[actuell.pos[0] , actuell.pos[1] - 1].dad[1] = actuell.pos[1];
                    Daten[actuell.pos[0] , actuell.pos[1] - 1].distance = actuell.distance + 1;
                    if (Daten[actuell.pos[0], actuell.pos[1] - 1].state == 0)
                    {
                        Feld[actuell.pos[1] - 1, actuell.pos[0]].Style.BackColor = Color.Beige;
                    }
                    
                }
                //refresh unvisited
                unvisited.Clear();
                for (int a = 0; a < 15; a++)
                {
                    for (int b = 0; b < 30; b++)
                    {
                        if (Daten[a, b].state != 1 && Daten[a,b].visited ==false)
                        {
                            unvisited.Add(Daten[a, b]);
                        }

                    }
                }
                
            }
            //Backtrack
            actuell = Daten[actuell.dad[0], actuell.dad[1]];
            while (actuell.state != 2)
            {

                Feld[actuell.pos[1], actuell.pos[0]].Style.BackColor = Color.Yellow;
                actuell = Daten[actuell.dad[0], actuell.dad[1]];
            }
           
        }



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
    }
}
