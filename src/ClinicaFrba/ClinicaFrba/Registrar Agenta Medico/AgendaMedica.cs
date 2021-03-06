﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Conexiones;
using ClinicaFrba.DAOs;

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class AgendaMedica : Form
    {
        private int _idUsuario;
        private string _idProfesional;

        private DateTime _lunes;
        private DateTime _martes;
        private DateTime _miercoles;
        private DateTime _jueves;
        private DateTime _viernes;
        private DateTime _sabado;

        public AgendaMedica(int idUsuario)
        {
            InitializeComponent();

            this._idUsuario = idUsuario;
            _idProfesional = ProfesionalDAO.GetIdProfesional(_idUsuario.ToString());
            FillEspecialidad();

            this.CLB_Lunes.DataSource = TablaHorariosLV();
            this.CLB_Lunes.ValueMember = "Valor";
            this.CLB_Lunes.DisplayMember = "Hora";
            this.CLB_Martes.DataSource = TablaHorariosLV();
            this.CLB_Martes.ValueMember = "Valor";
            this.CLB_Martes.DisplayMember = "Hora";
            this.CLB_Miercoles.DataSource = TablaHorariosLV();
            this.CLB_Miercoles.ValueMember = "Valor";
            this.CLB_Miercoles.DisplayMember = "Hora";
            this.CLB_Jueves.DataSource = TablaHorariosLV();
            this.CLB_Jueves.ValueMember = "Valor";
            this.CLB_Jueves.DisplayMember = "Hora";
            this.CLB_Viernes.DataSource = TablaHorariosLV();
            this.CLB_Viernes.ValueMember = "Valor";
            this.CLB_Viernes.DisplayMember = "Hora";
            this.CLB_Sabado.DataSource = TablaHorariosS();
            this.CLB_Sabado.ValueMember = "Valor";
            this.CLB_Sabado.DisplayMember = "Hora";

            DTP_Fecha_ValueChanged(this, EventArgs.Empty);

        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (this.Validar() == true)
            {
                string idEspecialidad = CBX_Especialidad.SelectedValue.ToString();
                
                CargarAgenda(idEspecialidad, CLB_Lunes, _lunes);
                CargarAgenda(idEspecialidad, CLB_Martes, _martes);
                CargarAgenda(idEspecialidad, CLB_Miercoles, _miercoles);
                CargarAgenda(idEspecialidad, CLB_Jueves, _jueves);
                CargarAgenda(idEspecialidad, CLB_Viernes, _viernes);
                CargarAgenda(idEspecialidad, CLB_Sabado, _sabado);

                MessageBox.Show("Se guardo los registros de la agenda");
                
            }
        }

        private void DTP_Fecha_ValueChanged(object sender, EventArgs e)
        {
            DateTime semanaTime = DTP_Fecha.Value.Date;

            switch ((int)semanaTime.DayOfWeek)
            {
                case 0:
                    semanaTime = semanaTime.AddDays(1);
                    break;
                case 1:
                    break;
                case 2:
                    semanaTime = semanaTime.AddDays(-1);
                    break;
                case 3:
                    semanaTime = semanaTime.AddDays(-2);
                    break;
                case 4:
                    semanaTime = semanaTime.AddDays(-3);
                    break;
                case 5:
                    semanaTime = semanaTime.AddDays(-4);
                    break;
                case 6:
                    semanaTime = semanaTime.AddDays(-5);
                    break;
                default:
                    break;
            }

            Lbl_Lunes.Text = "Lunes " + semanaTime.Day.ToString();
            _lunes = semanaTime.Date;
            Lbl_Martes.Text = "Martes " + semanaTime.AddDays(1).Day.ToString();
            _martes = semanaTime.Date.AddDays(1);
            Lbl_Miercoles.Text = "Miercoles " + semanaTime.AddDays(2).Day.ToString();
            _miercoles = semanaTime.Date.AddDays(2);
            Lbl_Jueves.Text = "Jueves " + semanaTime.AddDays(3).Day.ToString();
            _jueves = semanaTime.Date.AddDays(3);
            Lbl_Viernes.Text = "Viernes " + semanaTime.AddDays(4).Day.ToString();
            _viernes = semanaTime.Date.AddDays(4);
            Lbl_Sabado.Text = "Sabado " + semanaTime.AddDays(5).Day.ToString();
            _sabado = semanaTime.Date.AddDays(5);

            LimpiarCLB();
            GetAgenda();
        }

        private DataTable TablaHorariosLV()
        {
            DataTable dataTable = new DataTable("Horarios");
            dataTable.Columns.Add("Hora");
            dataTable.Columns.Add("Valor");

            DateTime horaInicial = new DateTime(2016,1,1,7,0,0);

            for (int i = 0; i < 26; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = horaInicial.ToString("HH:mm");
                dataRow[1] = horaInicial;
                dataTable.Rows.Add(dataRow);

                horaInicial = horaInicial.AddMinutes(30);
            }
            return dataTable;
        }

        private DataTable TablaHorariosS()
        {
            DataTable dataTable = new DataTable("Horarios");
            dataTable.Columns.Add("Hora");
            dataTable.Columns.Add("Valor");

            DateTime horaInicial = new DateTime(2016, 1, 1, 10, 0, 0);

            for (int i = 0; i < 10; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = horaInicial.ToString("HH:mm");
                dataRow[1] = horaInicial;
                dataTable.Rows.Add(dataRow);

                horaInicial = horaInicial.AddMinutes(30);
            }
            return dataTable;
        }

        private bool Validar()
        {
            int cantHoras = CLB_Lunes.CheckedItems.Count + CLB_Martes.CheckedItems.Count +
                            CLB_Miercoles.CheckedItems.Count + CLB_Jueves.CheckedItems.Count +
                            CLB_Viernes.CheckedItems.Count + CLB_Sabado.CheckedItems.Count;
            if (cantHoras > 96)
            {
                MessageBox.Show("No puede trabajar mas de 48hs por semana");
                return false;
            }

            return true;
        }

        private void FillEspecialidad()
        {
            CBX_Especialidad.DataSource = ProfesionalDAO.EspecialidadesById(_idProfesional);
            CBX_Especialidad.DisplayMember = "Descripcion";
            CBX_Especialidad.ValueMember = "ID_Especialidad";
        }

        private void CargarAgenda(string idEspecialidad, CheckedListBox diaListBox, DateTime diaTime)
        {
            SqlServer sql = new SqlServer();

            foreach (var item in diaListBox.CheckedItems)
            {
                Parametros parametros = new Parametros();

                parametros.AgregarParametro("idProfesional", _idProfesional);
                parametros.AgregarParametro("idEspecialidad", idEspecialidad);
                

                var row = (item as DataRowView).Row;
                DateTime horaTime = Convert.ToDateTime(row["Valor"]);
                DateTime fechaAIngresar = diaTime.AddHours(horaTime.Hour).AddMinutes(horaTime.Minute);
                parametros.AgregarParametro("fecha", fechaAIngresar.ToString("yyyy-MM-dd HH:mm:ss"));

                DataTable table = sql.EjecutarSp("SP_Insert_Disponibilidad_Profesional", parametros);
                if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
                }

            }
        }

        private void LimpiarCLB()
        {
            for (int i = 0; i < CLB_Lunes.Items.Count; i++)
            {
                CLB_Lunes.SetItemChecked(i, false);
                CLB_Martes.SetItemChecked(i, false);
                CLB_Miercoles.SetItemChecked(i, false);
                CLB_Jueves.SetItemChecked(i, false);
                CLB_Viernes.SetItemChecked(i, false);
            }

            for (int i = 0; i < CLB_Sabado.Items.Count; i++)
            {
                CLB_Sabado.SetItemChecked(i, false);
            }
        }

        private void GetAgenda()
        {
            //Primer turno de la semana
            DateTime primerTurnoTime = _lunes.AddHours(7).AddMinutes(0);
            //Ultimo turno de la semana
            DateTime ultimoTurnoTime = _sabado.AddHours(14).AddMinutes(30);

            string idEspecialidad = CBX_Especialidad.SelectedValue.ToString();

            //Recibo la tabla con la disponibilidad profesional
            SqlServer sql = new SqlServer();
            Parametros parametros = new Parametros();
            parametros.AgregarParametro("idProfesional", _idProfesional);
            parametros.AgregarParametro("idEspecialidad", idEspecialidad);
            parametros.AgregarParametro("fechaInicio", primerTurnoTime.ToString("yyyy-MM-dd HH:mm:ss"));
            parametros.AgregarParametro("fechaFin", ultimoTurnoTime.ToString("yyyy-MM-dd HH:mm:ss"));

            DataTable table = sql.EjecutarSp("SP_Get_AgendaProfesional", parametros);

            if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
                return;
            }

            //Tomo un dato de la tabla, comparo la fecha del dato con la fecha del dia, luego comparo la hora, 
            //Si es igual, CHECKED.
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //MessageBox.Show(table.Rows[i].ItemArray[2].ToString());
                DateTime fechaTime = Convert.ToDateTime(table.Rows[i].ItemArray[2]);
                if (fechaTime.Day == _lunes.Day)
                {
                    for (int j = 0; j < CLB_Lunes.Items.Count; j++)
                    {
                        DataRowView itemBox = (DataRowView)CLB_Lunes.Items[j];
                        DateTime horaTurno = Convert.ToDateTime(itemBox["Valor"]);

                        if (fechaTime.ToString("HH:mm") == horaTurno.ToString("HH:mm"))
                        {
                            CLB_Lunes.SetItemChecked(j, true);
                            CLB_Lunes.SetItemCheckState(j, CheckState.Indeterminate);
                        }

                    }
                }
                else if (fechaTime.Day == _martes.Day)
                {
                    for (int j = 0; j < CLB_Martes.Items.Count; j++)
                    {
                        DataRowView itemBox = (DataRowView)CLB_Martes.Items[j];
                        DateTime horaTurno = Convert.ToDateTime(itemBox["Valor"]);

                        if (fechaTime.ToString("HH:mm") == horaTurno.ToString("HH:mm"))
                        {
                            CLB_Martes.SetItemChecked(j, true);
                            CLB_Martes.SetItemCheckState(j, CheckState.Indeterminate);
                        }

                    }
                }
                else if (fechaTime.Day == _miercoles.Day)
                {
                    for (int j = 0; j < CLB_Miercoles.Items.Count; j++)
                    {
                        DataRowView itemBox = (DataRowView)CLB_Miercoles.Items[j];
                        DateTime horaTurno = Convert.ToDateTime(itemBox["Valor"]);

                        if (fechaTime.ToString("HH:mm") == horaTurno.ToString("HH:mm"))
                        {
                            CLB_Miercoles.SetItemChecked(j, true);
                            CLB_Miercoles.SetItemCheckState(j, CheckState.Indeterminate);
                        }

                    }
                }
                else if (fechaTime.Day == _jueves.Day)
                {
                    for (int j = 0; j < CLB_Jueves.Items.Count; j++)
                    {
                        DataRowView itemBox = (DataRowView)CLB_Jueves.Items[j];
                        DateTime horaTurno = Convert.ToDateTime(itemBox["Valor"]);

                        if (fechaTime.ToString("HH:mm") == horaTurno.ToString("HH:mm"))
                        {
                            CLB_Jueves.SetItemChecked(j, true);
                            CLB_Jueves.SetItemCheckState(j, CheckState.Indeterminate);
                        }

                    }
                }
                else if (fechaTime.Day == _viernes.Day)
                {
                    for (int j = 0; j < CLB_Viernes.Items.Count; j++)
                    {
                        DataRowView itemBox = (DataRowView)CLB_Viernes.Items[j];
                        DateTime horaTurno = Convert.ToDateTime(itemBox["Valor"]);

                        if (fechaTime.ToString("HH:mm") == horaTurno.ToString("HH:mm"))
                        {
                            CLB_Viernes.SetItemChecked(j, true);
                            CLB_Viernes.SetItemCheckState(j, CheckState.Indeterminate);
                        }

                    }
                }
                else if (fechaTime.Day == _sabado.Day)
                {
                    for (int j = 0; j < CLB_Sabado.Items.Count; j++)
                    {
                        DataRowView itemBox = (DataRowView)CLB_Sabado.Items[j];
                        DateTime horaTurno = Convert.ToDateTime(itemBox["Valor"]);

                        if (fechaTime.ToString("HH:mm") == horaTurno.ToString("HH:mm"))
                        {
                            CLB_Sabado.SetItemChecked(j, true);
                            CLB_Sabado.SetItemCheckState(j, CheckState.Indeterminate);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar la agenda");
                }
            }
        }

        private void CBX_Especialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarCLB();
            GetAgenda();
        }
    }
}
