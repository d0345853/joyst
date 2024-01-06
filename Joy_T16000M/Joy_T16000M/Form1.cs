using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using SharpDX.DirectInput;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

using System.IO.Ports;


namespace Joy_T16000M
{
    public partial class Form1 : Form
    {
        private static Dictionary<string, string> SupportedDevices = new Dictionary<string, string>();
        private ConcurrentDictionary<string, Joystick> connectedJoysticks = new ConcurrentDictionary<string, Joystick>();
        private Socket sock;
        private IPEndPoint endPoint;
        private DirectInput di = new DirectInput();

        double x, y, z, s;

        const double x_scale = 20.0;  // scale
        const double y_scale = 7.5;
        const double z_scale = 90.0;  //rotate
        const double s_scale = 20.0;

        public Form1()
        {
            InitializeComponent();

            SupportedDevices.Add("044f:b10a", "T.16000M");

            serialPort1.BaudRate = 115200;
            serialPort1.Parity = Parity.None;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;

            comboBox1.Items.AddRange(SerialPort.GetPortNames());



            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            System.Timers.Timer deviceFinderTimer = new System.Timers.Timer(2000);
            deviceFinderTimer.Elapsed += DeviceFinderTimer_Elapsed;
            deviceFinderTimer.Enabled = true;

        }
        private void bad(object send,SerialDataReceivedEventArgs e)//副執行序
        {
            try { 
            this.Invoke((MethodInvoker)delegate ()//主執行序
            {
                label8.Text = serialPort1.ReadLine();
            });
            }
            catch (System.IO.IOException ex) { MessageBox.Show(ex.ToString()); }
        }
        private void DeviceFinderTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ScanJoysticks();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                foreach (Joystick joystick in connectedJoysticks.Values)
                {
                    try
                    {
                        joystick.Poll();
                        JoystickUpdate[] updates = joystick.GetBufferedData();

                        if (updates.Length > 0)
                        {
                            string usbID = GetUsbId(joystick);
                            List<string> events = new List<string>();

                            foreach (var state in updates)
                            {
                                string offset = state.Offset.ToString();

                                switch (offset)
                                {
                                    case ("X"):
                                        {
                                            int x_temp = state.Value;
                                            x = Math.Round((x_temp - 32767) / 32767.0 * x_scale, 2);
                                            if (x < x_scale * 0.02 && x > -x_scale * 0.02) x = 0.0;
                                            SHOW(textBox_X, x.ToString());
                                        }

                                        break;
                                    case ("Y"):
                                        {
                                            int y_temp = state.Value;
                                            y = -Math.Round((y_temp - 32767) / 32767.0 * y_scale, 2);
                                            if (y < y_scale * 0.02 && y > -y_scale * 0.02) y = 0.0;
                                            SHOW(textBox_Y, y.ToString());
                                        }
                                        break;
                                    case ("RotationZ"):
                                        {
                                            int z_temp = state.Value;
                                            z = Math.Round((z_temp - 32767) / 32767.0 * z_scale, 2);
                                            if (z < z_scale * 0.05 && z > -z_scale * 0.05) z = 0.0;
                                            SHOW(textBox_Z, z.ToString());
                                        }
                                        break;
                                    case ("Sliders0"):
                                        {
                                            int s_temp = state.Value;
                                            s = Math.Round(s_temp / 65535.0 * s_scale, 2);

                                            SHOW(textBox_S, s.ToString());
                                        }
                                        break;
                                    case ("Buttons0"):
                                        {
                                            int B_temp = state.Value;
                                            if (B_temp == 128) Send_packet(1);
                                        }

                                        break;
                                    default:
                                        break;

                                }

                            }

                        }
                    }
                    catch (SharpDX.SharpDXException)
                    { }
                }

            }
        }

        private void SHOW(TextBox textbox, string data)
        {
            textbox.InvokeIfRequired(() =>
            {
                textbox.Text = data;
            });

        }

        private string GuidToUsbID(Guid guid)
        {
            return Regex.Replace(guid.ToString(), @"(^....)(....).*$", "$2:$1");
        }

        private string GetUsbId(Joystick joystick)
        {
            return GuidToUsbID(joystick.Information.ProductGuid);
        }

        private void ScanJoysticks()
        {
            Dictionary<string, Joystick> foundJoysticks = new Dictionary<string, Joystick>();

            foreach (DeviceInstance device in di.GetDevices())
            {
                string usbId = GuidToUsbID(device.ProductGuid);

                if (SupportedDevices.ContainsKey(usbId))
                {
                    foundJoysticks.Add(usbId, new Joystick(di, device.ProductGuid));
                }
            }

            // Find removed devices
            //foreach(string removed in connectedJoysticks.Keys.Except(foundJoysticks.Keys))

            //    connectedJoysticks[removed].Unacquire();


            //    Console.WriteLine(SupportedDevices[removed] + " disconnected");
            //    List<string> events = new List<string>();
            //    events.Add("Connected=0");
            //    //SendEvent(sock, endPoint, removed, events);
            //}

            // Find added devices

            foreach (string added in foundJoysticks.Keys.Except(connectedJoysticks.Keys))
            {
                foundJoysticks[added].Properties.BufferSize = 32;
                foundJoysticks[added].Acquire();

                if (connectedJoysticks.TryAdd(added, foundJoysticks[added]))
                {

                    label_joy.InvokeIfRequired(() =>
                    {
                        label_joy.Text = "Connect";

                    });



                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.Open();
                    if (label_joy.Text == "Connect") timer1.Enabled = true;
                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(bad);
                }
                catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.ToString()); }
            }
            else
            {
                serialPort1.Close();
            }

        }

        private void textBox_X_TextChanged(object sender, EventArgs e)
        {

        }

        private void Send_packet(int catch_data)
        {

            double x_temp = x;
            double y_temp = y;
            double z_temp = z;
            double s_temp = s;


            byte[] array = new byte[11];
            int x_1 = (Convert.ToInt32(x_temp * 100.0) + 3000) / 256;
            int x_2 = (Convert.ToInt32(x_temp * 100.0) + 3000) % 256;
            int y_1 = (Convert.ToInt32(y_temp * 100.0) + 3000) / 256;
            int y_2 = (Convert.ToInt32(y_temp * 100.0) + 3000) % 256;
            int z_1 = (Convert.ToInt32(z_temp * 100.0) + 9000) / 256;
            int z_2 = (Convert.ToInt32(z_temp * 100.0) + 9000) % 256;
            int s_1 = (Convert.ToInt32(s_temp * 100.0) + 2000) / 256;
            int s_2 = (Convert.ToInt32(s_temp * 100.0) + 2000) % 256;




            array[0] = 255;
            array[1] = (byte)x_1;
            array[2] = (byte)x_2;
            array[3] = (byte)y_1;
            array[4] = (byte)y_2;
            array[5] = (byte)z_1;
            array[6] = (byte)z_2;
            array[7] = (byte)s_1;
            array[8] = (byte)s_2;
            array[9] = (byte)catch_data;
            array[10] = 254;

            try
            {
                serialPort1.Write(array, 0, array.Length);
            }
            catch (System.IO.IOException ex) { MessageBox.Show(ex.ToString()); }
        }

        private void label_joy_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Send_packet(100);
        }

        private void Send_packet2(int catch_data)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Send_packet(0);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Send_packet(0);
        }

    }



    public static class Extension
    {
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);

            }
            else
            {
                action();
            }
        }
    }

}
