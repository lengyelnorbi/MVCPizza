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
using _2019TobbformosMvcPizzaEgyTabla.model;

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
        private void buttonUjFutar_Click(object sender, EventArgs e)
        {
            ujFutarAdatfelvitel = true;
            beallitGombokatTextboxokatUjFutarnal();
            int ujFutarAzonosito = futarRepo.getNextFutarId();
            textBoxFutarAzonosito.Text = ujFutarAzonosito.ToString();
        }

        private void beallitGombokatTextboxokatUjFutarnal()
        {
            panelFutar.Visible = true;
            panelFutarModositTorol.Visible = false;
            textBoxFutarNev.Text = string.Empty;
            textBoxFutarLakcim.Text = string.Empty;
            textBoxFutarTelszam.Text = string.Empty;
            textBoxFutarEmail.Text = string.Empty;
        }

        private void buttonFutarMentese_Click(object sender, EventArgs e)
        {
            torolHibauzenetet();
            errorProviderFutarNev.Clear();
            errorProviderFutarLakcim.Clear();
            errorProviderFutarTelszam.Clear();
            errorProviderFutarEmail.Clear();
            try
            {
                Futar ujFutar = new Futar(
                    Convert.ToInt32(textBoxFutarAzonosito.Text),
                    textBoxFutarNev.Text,
                    textBoxFutarLakcim.Text,
                    textBoxFutarTelszam.Text,
                    textBoxFutarEmail.Text
                    );
                int azonosito = Convert.ToInt32(textBoxFutarAzonosito.Text);
                //1. Hozzáadni a listához
                try
                {
                    futarRepo.addFutarToList(ujFutar);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                    return;
                }
                //2. Hozzáadni az adatbázishoz
                RepositoryDatabaseTablePizza rdtp = new RepositoryDatabaseTablePizza();
                try
                {
                    rdtp.insertFutarToDatabase(ujFutar);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }
                //3. Frissíteni a DataGridView-t
                beallitGombokatUjFutarMegsemEsMentes();
                frissitFutarAdatokkalDataGriedViewt();
                if (dataGridViewFutar.SelectedRows.Count == 1)
                {
                    beallitFutarDataGriViewt();
                }

            }
            catch (ModelFutarNotValidNameExeption nvn)
            {
                errorProviderFutarNev.SetError(textBoxFutarNev, nvn.Message);
            }
            catch (ModelFutarNotValidAddressExeption nvp)
            {
                errorProviderFutarLakcim.SetError(textBoxFutarLakcim, nvp.Message);
            }
            catch (ModelFutarNotValidPhonenumberExeption nvp)
            {
                errorProviderFutarTelszam.SetError(textBoxFutarTelszam, nvp.Message);
            }
            catch (ModelFutarNotValidEmailExeption nvp)
            {
                errorProviderFutarEmail.SetError(textBoxFutarEmail, nvp.Message);
            }
            catch (Exception ex)
            {
            }
        }
        private void buttonFutarModosit_Click(object sender, EventArgs e)
        {
            torolHibauzenetet();
            errorProviderFutarNev.Clear();
            errorProviderFutarLakcim.Clear();
            errorProviderFutarTelszam.Clear();
            errorProviderFutarEmail.Clear();
            try
            {
                Futar modosult = new Futar(
                    Convert.ToInt32(textBoxFutarAzonosito.Text),
                    textBoxFutarNev.Text,
                    textBoxFutarLakcim.Text,
                    textBoxFutarTelszam.Text,
                    textBoxFutarEmail.Text
                    );
                int azonosito = Convert.ToInt32(textBoxFutarAzonosito.Text);
                //1. módosítani a listába
                try
                {
                    futarRepo.updateFutarInList(azonosito, modosult);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                    return;
                }
                //2. módosítani az adatbáziba
                RepositoryDatabaseTablePizza rdtp = new RepositoryDatabaseTablePizza();
                try
                {
                    rdtp.updateFutarInDatabase(azonosito, modosult);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }
                //3. módosítani a DataGridView-ban           
                frissitFutarAdatokkalDataGriedViewt();
            }
            catch (ModelFutarNotValidNameExeption nvn)
            {
                errorProviderFutarNev.SetError(textBoxFutarNev, nvn.Message);
            }
            catch (ModelFutarNotValidAddressExeption nvp)
            {
                errorProviderFutarLakcim.SetError(textBoxFutarLakcim, nvp.Message);
            }
            catch (ModelFutarNotValidPhonenumberExeption nvp)
            {
                errorProviderFutarTelszam.SetError(textBoxFutarTelszam, nvp.Message);
            }
            catch (ModelFutarNotValidEmailExeption nvp)
            {
                errorProviderFutarEmail.SetError(textBoxFutarEmail, nvp.Message);
            }
            catch (RepositoryExceptionCantModified recm)
            {
                kiirHibauzenetet(recm.Message);
                Debug.WriteLine("Módosítás nem sikerült, a futár nincs a listába!");
            }
            catch (Exception ex)
            { 
            }
        }

        private void buttonFutarTorol_Click(object sender, EventArgs e)
        {
            torolHibauzenetet();
            if ((dataGridViewFutar.Rows == null) ||
                (dataGridViewFutar.Rows.Count == 0))
                return;
            //A felhasználó által kiválasztott sor a DataGridView-ban            
            int sor = dataGridViewFutar.SelectedRows[0].Index;
            if (MessageBox.Show(
                "Valóban törölni akarja a sort?",
                "Törlés",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                //1. törölni kell a listából
                int id = -1;
                if (!int.TryParse(
                         dataGridViewFutar.SelectedRows[0].Cells[0].Value.ToString(),
                         out id))
                    return;
                try
                {
                    futarRepo.deleteFutarFromList(id);
                }
                catch (RepositoryExceptionCantDelete recd)
                {
                    kiirHibauzenetet(recd.Message);
                    Debug.WriteLine("A futár törlés nem sikerült, nincs a listába!");
                }
                //2. törölni kell az adatbázisból
                RepositoryDatabaseTablePizza rdtp = new RepositoryDatabaseTablePizza();
                try
                {
                    rdtp.deleteFutarFromDatabase(id);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }
                //3. frissíteni kell a DataGridView-t  
                frissitFutarAdatokkalDataGriedViewt();
                if (dataGridViewFutar.SelectedRows.Count <= 0)
                {
                    buttonUjFutar.Visible = true;
                }
                beallitFutarDataGriViewt();
            }
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

        private void beallitFutarGombokatKattintaskor()
        {
            ujFutarAdatfelvitel = false;
            buttonFutarMentese.Visible = false;
            buttonFutarMegse.Visible = false;
            panelFutarModositTorol.Visible = true;
            errorProviderFutarNev.Clear();
            errorProviderFutarLakcim.Clear();
            errorProviderFutarTelszam.Clear();
            errorProviderFutarEmail.Clear();
        }
        private void buttonFutarMegse_Click(object sender, EventArgs e)
        {
            beallitGombokatUjFutarMegsemEsMentes();
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

        private void beallitGombokatUjFutarMegsemEsMentes()
        {
            if ((dataGridViewFutar.Rows != null) &&
                (dataGridViewFutar.Rows.Count > 0))
                dataGridViewFutar.Rows[0].Selected = true;
            buttonFutarMentese.Visible = false;
            buttonFutarMegse.Visible = false;
            panelFutarModositTorol.Visible = true;
            ujFutarAdatfelvitel = false;

            textBoxFutarNev.Text = string.Empty;
            textBoxFutarLakcim.Text = string.Empty;
            textBoxFutarTelszam.Text = string.Empty;
            textBoxFutarEmail.Text = string.Empty;
        }
        private void textBoxFutarNev_TextChanged(object sender, EventArgs e)
        {
            kezelFutarUjMegsemGombokat();
        }

        private void textBoxFutarLakcim_TextChanged(object sender, EventArgs e)
        {
            kezelFutarUjMegsemGombokat();
        }
        private void textBoxFutarTelszam_TextChanged(object sender, EventArgs e)
        {
            kezelFutarUjMegsemGombokat();
        }
        private void textBoxFutarEmail_TextChanged(object sender, EventArgs e)
        {
            kezelFutarUjMegsemGombokat();
        }
        private void kezelFutarUjMegsemGombokat()
        {
            if (ujFutarAdatfelvitel == false)
                return;
            if ((textBoxFutarNev.Text != string.Empty) ||
                (textBoxFutarLakcim.Text != string.Empty) ||
                (textBoxFutarTelszam.Text != string.Empty) ||
                (textBoxFutarEmail.Text != string.Empty))
            {
                buttonFutarMentese.Visible = true;
                buttonFutarMegse.Visible = true;
            }
            else
            {
                buttonFutarMentese.Visible = false;
                buttonFutarMegse.Visible = false;
            }
        }
    }
}
