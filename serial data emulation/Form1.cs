using MaterialSkin;
using MaterialSkin.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;

namespace serial_data_emulation
{
    public partial class Form1 : MaterialForm
    {
        private readonly SerialPort ComPort0 = new SerialPort();
        private readonly SerialPort ComPort1 = new SerialPort();
        private readonly SerialPort ComPort2 = new SerialPort();
        private readonly SerialPort ComPort3 = new SerialPort();

        private bool myWorker1, myWorker2, myWorker3, myWorker4;
        private bool mySerial0, mySerial1, mySerial2, mySerial3, MyAllSerial = false;


        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            Form1 Form1 = this;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue900,
                Primary.Blue800,
                Primary.Blue500,
                Accent.Green400,
                TextShade.WHITE
            );

            try
            {
                ComPort0.PortName = "COM30";       // Name of your COM port 
                ComPort0.BaudRate = 115200;           // Baudrate
                ComPort0.Parity = Parity.None;          // Parity bits = none  
                ComPort0.DataBits = 8;                  // No of Data bits = 8
                ComPort0.StopBits = StopBits.One;       // No of Stop bits = 1

                // Set the read/write timeouts
                ComPort0.ReadTimeout = 1500;
                ComPort0.WriteTimeout = 1500;
                ComPort0.Open();
            }
            catch { }
            try
            {
                ComPort1.PortName = "COM32";       // Name of your COM port 
                ComPort1.BaudRate = 115200;           // Baudrate
                ComPort1.Parity = Parity.None;          // Parity bits = none  
                ComPort1.DataBits = 8;                  // No of Data bits = 8
                ComPort1.StopBits = StopBits.One;       // No of Stop bits = 1

                // Set the read/write timeouts
                ComPort1.ReadTimeout = 1500;
                ComPort1.WriteTimeout = 1500;
                ComPort1.Open();
            }
            catch { }
            try
            {
                ComPort2.PortName = "COM34";       // Name of your COM port 
                ComPort2.BaudRate = 115200;           // Baudrate
                ComPort2.Parity = Parity.None;          // Parity bits = none  
                ComPort2.DataBits = 8;                  // No of Data bits = 8
                ComPort2.StopBits = StopBits.One;       // No of Stop bits = 1

                // Set the read/write timeouts
                ComPort2.ReadTimeout = 1500;
                ComPort2.WriteTimeout = 1500;
                ComPort2.Open();
            }
            catch { }
            try
            {
                ComPort3.PortName = "COM36";       // Name of your COM port 
                ComPort3.BaudRate = 115200;           // Baudrate
                ComPort3.Parity = Parity.None;          // Parity bits = none  
                ComPort3.DataBits = 8;                  // No of Data bits = 8
                ComPort3.StopBits = StopBits.One;       // No of Stop bits = 1

                // Set the read/write timeouts
                ComPort3.ReadTimeout = 1500;
                ComPort3.WriteTimeout = 1500;
                ComPort3.Open();
            }
            catch { }

            
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(materialTextBox1.Text);
        }

        

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (!backgroundWorker1.CancellationPending)
            {
                for (float i = 0f; i <= 100f; i += 0.1f)
                {
                    if ((backgroundWorker1.CancellationPending == true))
                    {
                        e.Cancel = true;
                        return;
                    }
                    //Debug.WriteLine(i.ToString("0.0"));
                    value1.Invoke((Delegate)(() =>
                    {
                        value1.Text = i.ToString("0.0");
                    }));
                    ComPort0.WriteLine(i.ToString("0.0"));
                    Thread.Sleep(timer1.Interval);
                }
                for (float i = 100f; i >= 0f; i -= 0.1f)
                {
                    if ((backgroundWorker1.CancellationPending == true))
                    {
                        e.Cancel = true;
                        return;
                    }
                    //Debug.WriteLine(i.ToString("0.0"));
                    ComPort0.WriteLine(i.ToString("0.0"));
                    value1.Invoke((Delegate)(() =>
                    {
                        value1.Text = i.ToString("0.0");
                    }));
                    Thread.Sleep(timer1.Interval);
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (!backgroundWorker2.CancellationPending)
            {
                for (float i = 100f; i <= 200f; i += 0.1f)
                {
                    if ((backgroundWorker2.CancellationPending == true))
                    {
                        e.Cancel = true;
                        return;
                    }
                    value2.Invoke((Delegate)(() =>
                    {
                        value2.Text = i.ToString("0.0");
                    }));
                    ComPort1.WriteLine(i.ToString("0.0"));
                    Thread.Sleep(timer1.Interval);
                }
                for (float i = 200f; i >= 100f; i -= 0.1f)
                {
                    if ((backgroundWorker2.CancellationPending == true))
                    {
                        e.Cancel = true;
                        return;
                    }
                    value2.Invoke((Delegate)(() =>
                    {
                        value2.Text = i.ToString("0.0");
                    }));
                    ComPort1.WriteLine(i.ToString("0.0"));
                    Thread.Sleep(timer1.Interval);
                }
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker3_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (!backgroundWorker3.CancellationPending)
            {
                for (float i = 200f; i <= 300f; i += 0.1f)
                    
                {
                    
                    if ((backgroundWorker3.CancellationPending == true))
                    {
                        e.Cancel = true;
                        return;
                    }
                    value3.Invoke((Delegate)(() =>
                    {
                        value3.Text = i.ToString("0.0");
                    }));
                    ComPort2.WriteLine(i.ToString("0.0"));
                    Thread.Sleep(timer1.Interval);
                }
                for (float i = 300f; i >= 200f; i -= 0.1f)
                    
                {
                    if ((backgroundWorker3.CancellationPending == true))
                    {
                        e.Cancel = true;
                        return;
                    }
                    value3.Invoke((Delegate)(() =>
                    {
                        value3.Text = i.ToString("0.0");
                    }));
                    ComPort2.WriteLine(i.ToString("0.0"));
                    Thread.Sleep(timer1.Interval);
                }
            }
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //backgroundWorker3.RunWorkerAsync();
        }

        private void backgroundWorker4_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (!backgroundWorker4.CancellationPending)
            {
                for (float i = 300f; i <= 400f; i += 0.1f)
                {
                    if ((backgroundWorker4.CancellationPending == true))
                    {
                        e.Cancel = true;
                        return;
                    }
                    
                    value4.Invoke((Delegate)(() =>
                    {
                        value4.Text = i.ToString("0.0");
                    }));
                    
                    ComPort3.WriteLine(i.ToString("0.0"));
                    Thread.Sleep(timer1.Interval);
                }
                for (float i = 400f; i >= 300f; i -= 0.1f)
                {
                    if ((backgroundWorker4.CancellationPending == true))
                    {
                        e.Cancel = true;
                        return;
                    }
                    
                    value4.Invoke((Delegate)(() =>
                    {
                        value4.Text = i.ToString("0.0");
                    }));
                    
                    ComPort3.WriteLine(i.ToString("0.0"));
                    Thread.Sleep(timer1.Interval);
                }
            }
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //backgroundWorker4.RunWorkerAsync();
        }

        private void materialButtonPlayPause1_Click(object sender, EventArgs e)
        {
            
                if (mySerial0 is true)
                {
                    myWorker1 = false;
                    mySerial0 = false;
                    materialCheckbox0.Checked = false;
                    backgroundWorker1.CancelAsync();

                }
                else
                {
                    myWorker1 = true;
                    MyAllSerial = true;
                    mySerial0 = true;
                    materialCheckbox0.Checked = true;
                    backgroundWorker1.RunWorkerAsync();
                }
            
        }

        private void materialButtonPlayPause2_Click(object sender, EventArgs e)
        {
            if (mySerial1 is true)
            {
                myWorker2 = false;
                mySerial1 = false;
                materialCheckbox1.Checked = false;
                backgroundWorker2.CancelAsync();
            }
            else
            {
                myWorker2 = true;
                timer1.Enabled = true;
                MyAllSerial = true;
                mySerial1 = true;
                materialCheckbox1.Checked = true;
                backgroundWorker2.RunWorkerAsync();
                
            }
        }


        private void materialButtonPlayPause3_Click(object sender, EventArgs e)
        {
            if (mySerial2 is true)
            {
                myWorker3 = false;
                mySerial2 = false;
                materialCheckbox2.Checked = false;
                backgroundWorker3.CancelAsync();
            }
            else
            {
                myWorker3 = true;
                timer1.Enabled = true;
                MyAllSerial = true;
                mySerial2 = true;
                materialCheckbox2.Checked = true;
                backgroundWorker3.RunWorkerAsync();
            }
        }


        private void materialButtonPlayPause4_Click(object sender, EventArgs e)
        {
            if (mySerial3 is true)
            {
                myWorker4 = false;
                mySerial3 = false;
                materialCheckbox3.Checked = false;
                backgroundWorker4.CancelAsync();
            }
            else
            {
                myWorker4 = true;
                timer1.Enabled = true;
                MyAllSerial = true;
                mySerial3 = true;
                materialCheckbox3.Checked = true;
                backgroundWorker4.RunWorkerAsync();
            }
        }


        private void materialButtonPlayPauseAll_Click_1(object sender, EventArgs e)
        {
            if (MyAllSerial is true)
            {
                MyAllSerial = false;

                mySerial0 = false;
                mySerial1 = false;
                mySerial2 = false;
                mySerial3 = false;

                timer1.Enabled = false;

                materialCheckbox0.Checked = false;
                materialCheckbox1.Checked = false;
                materialCheckbox2.Checked = false;
                materialCheckbox3.Checked = false;

                backgroundWorker1.CancelAsync();
                backgroundWorker2.CancelAsync();
                backgroundWorker3.CancelAsync();
                backgroundWorker4.CancelAsync();

            }
            else
            {
                MyAllSerial = true;

                timer1.Enabled = true;

                mySerial0 = true;
                mySerial1 = true;
                mySerial2 = true;
                mySerial3 = true;

                materialCheckbox0.Checked = true;
                materialCheckbox1.Checked = true;
                materialCheckbox2.Checked = true;
                materialCheckbox3.Checked = true;

                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.RunWorkerAsync();
                backgroundWorker3.RunWorkerAsync();
                backgroundWorker4.RunWorkerAsync();
            }
        }

    }
}