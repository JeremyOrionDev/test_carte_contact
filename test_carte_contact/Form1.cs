using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.IO;
using System.IO.Ports;


namespace test_carte_contact
{
    public partial class Form1 : Form
    {
        private SerialPort SP = new SerialPort();
        public enum LogMsType { Incoming, Outgoing, Normal, Warning, Error};
        private Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };

        public Form1()
        {
            InitializeComponent();
            SP.BaudRate = 115200;
            SP.Parity = Parity.None;
            SP.StopBits = StopBits.One;
            SP.DataBits = 8;
            SP.Handshake = Handshake.None;
            SP.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool erreur = false;

            //si le port est deja ouvert on le ferme
            if (SP.IsOpen) SP.Close();
            else
            {
                //Réglages paramètres du port
                SP.PortName = cBxPortName.Text;

                try
                {
                    //Ouverture du port
                    SP.Open();
                }
                catch (UnauthorizedAccessException) { erreur = true; }
                catch (IOException) { erreur = true; }
                catch (ArgumentException) { erreur = true; }

                if (erreur)
                {
                    MessageBox.Show("Impossible d'ouvrir le por COM.\n Il est vraisemblablement déja utilisé, supprimé ou indisponible", "Port COM indisponible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Connexion réussi", "Port disponible");
                }
            }

        }

        //Connexion au terminal
        private void Log(LogMsType msgtype, string msg)
        {
            Console.Write(new EventHandler(delegate
            {
                
            }))
        }
    }
}
