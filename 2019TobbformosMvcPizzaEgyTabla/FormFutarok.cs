using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TobbbformosPizzaAlkalmazasEgyTabla.Repository;
using TobbbformosPizzaAlkalmazasEgyTabla.Model;
using System.Diagnostics;

namespace _2019TobbformosMvcPizzaEgyTabla
{
    public partial class FormPizzaFutarKft : Form
    {
        private DataTable futarDT = new DataTable();
        
        private Repository futarRepo = new Repository();

        bool ujFutarAdatfelvitel = false;

        private void buttonFutarBetoltes_Click(object sender, EventArgs e)
        {
            //Adatbázisban pizza tábla kezelése
            RepositoryDatabaseTablePizza rtp = new RepositoryDatabaseTablePizza();
            //A repo-ba lévő pizza listát feltölti az adatbázisból
            futarRepo.setFutarok(rtp.getFutarokFromDatabaseTable());
            frissitFutarAdatokkalDataGriedViewt();
            beallitFutarDataGriViewt();
            beallitFutarGombokatIndulaskor();

            dataGridViewFutar.SelectionChanged += DataGridViewFutar_SelectionChanged;
        }

        private void DataGridViewFutar_SelectionChanged(object sender, EventArgs e)
        {
            if (ujFutarAdatfelvitel)
            {
                beallitFutarGombokatKattintaskor();
            }
            if (dataGridViewFutar.SelectedRows.Count == 1)
            {
                panelFutar.Visible = true;
                panelFutarModositTorol.Visible = true;
                buttonUjFutar.Visible = true;
                textBoxFutarAzonosito.Text =
                    dataGridViewFutar.SelectedRows[0].Cells[0].Value.ToString();
                textBoxFutarNev.Text =
                    dataGridViewFutar.SelectedRows[0].Cells[1].Value.ToString();
                textBoxFutarLakcim.Text =
                    dataGridViewFutar.SelectedRows[0].Cells[2].Value.ToString();
                textBoxFutarTelszam.Text =
                    dataGridViewFutar.SelectedRows[0].Cells[3].Value.ToString();
                textBoxFutarEmail.Text =
                    dataGridViewFutar.SelectedRows[0].Cells[4].Value.ToString();
            }
            else
            {
                panelFutar.Visible = false;
                panelFutarModositTorol.Visible = false;
                buttonUjFutar.Visible = false;
            }
        }

        private void buttonFutarMentese_Click(object sender, EventArgs e)
        {

        }

        private void beallitFutarGombokatKattintaskor()
        {
            ujFutarAdatfelvitel = false;
            buttonFutarMentese.Visible = false;
            buttonFutarMegse.Visible = false;
            panelFutarModositTorol.Visible = true;
            //errorProviderPizzaName.Clear();
            //errorProviderPizzaPrice.Clear();
        }

        private void beallitFutarGombokatIndulaskor()
        {
            panelFutar.Visible = false;
            panelFutarModositTorol.Visible = false;
            if (dataGridViewFutar.SelectedRows.Count != 0)
                buttonUjFutar.Visible = false;
            else
                buttonUjFutar.Visible = true;
        }

        private void beallitFutarDataGriViewt()
        {
            futarDT.Columns[0].ColumnName = "Azonosító";
            futarDT.Columns[0].Caption = "Futár azonosító";
            futarDT.Columns[1].ColumnName = "Név";
            futarDT.Columns[1].Caption = "Futár név";
            futarDT.Columns[2].ColumnName = "Lakcim";
            futarDT.Columns[2].Caption = "Futár lakcim";
            futarDT.Columns[3].ColumnName = "Telefonszám";
            futarDT.Columns[3].Caption = "Futár telefonszám";
            futarDT.Columns[4].ColumnName = "Email";
            futarDT.Columns[4].Caption = "Futár email";

            dataGridViewFutar.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFutar.ReadOnly = true;
            dataGridViewFutar.AllowUserToDeleteRows = false;
            dataGridViewFutar.AllowUserToAddRows = false;
            dataGridViewFutar.MultiSelect = false;
        }

        private void frissitFutarAdatokkalDataGriedViewt()
        {
            //Adattáblát feltölti a repoba lévő pizza listából
            futarDT = futarRepo.getFutarDataTableFromList();
            //Pizza DataGridView-nak a forrása a pizza adattábla
            dataGridViewFutar.DataSource = null;
            dataGridViewFutar.DataSource = futarDT; 
        }
    }
}
