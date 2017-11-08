using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace test_carte_contact
{
    class LiaisonSerie
    {
        string name;
        string Message;
        Thread readThread;
        bool _continue;
        SerialPort _serialPort;

        public LiaisonSerie()
        {
            // Création du port de communication serialport avec les différents paramètres.
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM1";
            _serialPort.BaudRate = 115000;//Vitesse de dialogue avec le Millenium.
            _serialPort.Parity = Parity.Even;//Parité paire (fixé par le Millenium).
            _serialPort.DataBits = 7;//Format de la trame 7 bits (lui aussi fixé par le Millenium).
            _serialPort.StopBits = StopBits.One;////1 bit de Stop(fixé par le Millenium).        
        }

        public void Read()
        {
            byte[] buffer = new byte[100];
            while (true)
            {
                try
                {
                    //Lecture sur le port serie.
                    Message = _serialPort.ReadLine();
                    Console.WriteLine(Message);
                    //string message = _serialPort.ReadLine();
                    //_serialPort.ReadChar();
                }
                catch (TimeoutException) { }
            }
        }
        public void Write()
        {
            try
            {
                //Ecriture sur le port serie.  
                _serialPort.WriteLine("test");
                System.Windows.Forms.MessageBox.Show("Ecriture Reussi .");
            }
            catch (TimeoutException) { }

        }
        public string message
        {
            get
            {
                return this.Message;
            }
        }
        public bool Continue
        {
            get
            {
                return this._continue;
            }
            set
            {
                _continue = value;
            }
        }
        public void Open()
        {
            _serialPort.Open();
        }
        public void Close()
        {
            _serialPort.Close();
        }
        ~LiaisonSerie()
        {
            _serialPort.Close();
        }
    }
}
