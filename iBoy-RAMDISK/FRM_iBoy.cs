using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using LibUsbDotNet.DeviceNotify;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Renci.SshNet;
using Renci.SshNet.Common;

// Token: 0x02000018 RID: 24
public partial class FRM_iBoy : MetroForm
{
	// Token: 0x06000083 RID: 131 RVA: 0x000092F8 File Offset: 0x000074F8
	public FRM_iBoy()
	{
		this.InitializeComponent();
		this.method_0();
		this.txt_info.Text = "Welcome to iBoy Ramdisk | Version " + Application.ProductVersion;
		this.method_3("");
		this.method_8();
		this.method_1();
	}

	// Token: 0x06000084 RID: 132 RVA: 0x000093E0 File Offset: 0x000075E0
	private string method_0()
	{
		string text3;
		try
		{
			string text = "https://api.ipify.org/";
			HttpWebRequest httpWebRequest = WebRequest.CreateHttp(text);
			httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			httpWebRequest.Timeout = -1;
			string text2;
			using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
			{
				using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
				{
					text2 = (GClass0.string_5 = streamReader.ReadToEnd());
				}
			}
			text3 = text2;
		}
		catch
		{
			text3 = "ERROR";
		}
		return text3;
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00009484 File Offset: 0x00007684
	private void method_1()
	{
		string text = "";
		try
		{
			string text2 = "http://pentaboy.my.id/ramdisk/update.php?version=" + Application.ProductVersion;
			HttpWebRequest httpWebRequest = WebRequest.CreateHttp(text2);
			httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			httpWebRequest.Timeout = -1;
			using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
			{
				using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
				{
					text = streamReader.ReadToEnd();
				}
			}
			if (Application.ProductVersion != text)
			{
				MessageBox.Show("Your App Version " + Application.ProductVersion + " Expired!\nPlease update From Server !", "Server Version is " + text + " !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Process.Start("https://mega.nz/folder/QF9hBCYS#H-HehoQskWVjYm_r9Sf-3w");
				Process.GetCurrentProcess().Kill();
			}
		}
		catch
		{
		}
		this.txt_vers.Text = "V " + text;
	}

	// Token: 0x06000086 RID: 134 RVA: 0x0000958C File Offset: 0x0000778C
	private void btn_checkdev_Click(object sender, EventArgs e)
	{
		this.method_2();
	}

	// Token: 0x06000087 RID: 135 RVA: 0x000095A0 File Offset: 0x000077A0
	private void copyBox_Click(object sender, EventArgs e)
	{
		try
		{
			Clipboard.SetText(Class19.string_2);
			MessageBox.Show("ECID: " + Class19.string_2 + " SUCCESSFULLY COPY", "iBoy Ramdisk", MessageBoxButtons.OK);
		}
		catch
		{
		}
	}

	// Token: 0x06000088 RID: 136 RVA: 0x000095F0 File Offset: 0x000077F0
	public void method_2()
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		if (Interlocked.Exchange(ref FRM_iBoy.int_3, 1) == 0)
		{
			if (this.method_3(""))
			{
				this.btn_boot1.Enabled = true;
				this.txt_info.Text = Class19.string_1 + " Connected";
			}
			else
			{
				this.txt_ECID.Text = "-";
				Class19.string_2 = "";
				Class19.string_9 = "";
				this.txt_model.Text = "-";
				this.txt_Type.Text = "-";
				this.txt_mode.Text = "-";
				this.lbl_pwned.Text = "-";
				this.btn_boot1.Enabled = false;
				this.txt_info.Text = "No device Detected";
			}
		}
		else
		{
			Console.WriteLine("   {0} was denied the lock", Thread.CurrentThread.Name);
		}
	}

	// Token: 0x06000089 RID: 137 RVA: 0x000096E8 File Offset: 0x000078E8
	private bool method_3(string string_5 = "")
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		Process process = new Process();
		process.StartInfo.FileName = Environment.CurrentDirectory + "/files/irecovery.exe";
		process.StartInfo.Arguments = "-q";
		process.StartInfo.UseShellExecute = false;
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.CreateNoWindow = true;
		process.Start();
		int num = 0;
		while (!process.StandardOutput.EndOfStream)
		{
			num++;
			string text = process.StandardOutput.ReadLine();
			string text2 = text.Replace("\r", "");
			if (text2.StartsWith("ECID: "))
			{
				string text3 = text2.Replace("ECID: ", "");
				Class19.string_2 = text3.Trim();
			}
			else if (text2.StartsWith("MODEL: "))
			{
				Class19.string_0 = text2.Replace("MODEL: ", "");
			}
			else if (text2.StartsWith("PRODUCT: "))
			{
				Class19.model = text2.Replace("PRODUCT: ", "");
			}
			else if (!text2.StartsWith("NAME: "))
			{
				if (!text2.StartsWith("CPID: "))
				{
					if (!text2.StartsWith("MODE: "))
					{
						if (text2.StartsWith("PWND: "))
						{
							string text4 = (Class19.string_3 = text2.Replace("PWND: ", ""));
							this.lbl_pwned.Text = text4;
							string text5 = Class19.string_3;
							this.btn_changeSN.Enabled = true;
							string text6 = text5;
							if (!(text6 == "CHECKM8") && !(text6 == "GASTER"))
							{
								this.lbl_pwned.ForeColor = Color.OrangeRed;
							}
							else
							{
								this.lbl_pwned.ForeColor = Color.SpringGreen;
							}
						}
					}
					else
					{
						Class19.string_5 = text2.Replace("MODE: ", "");
					}
				}
				else
				{
					Class19.string_9 = text2.Replace("CPID: ", "").Trim();
				}
			}
			else
			{
				Class19.string_1 = text2.Replace("NAME: ", "");
			}
			text.Split(new char[] { ':' });
		}
		this.txt_ECID.Text = Class19.string_2.ToUpper();
		this.txt_mode.Text = Class19.string_5;
		this.txt_model.Text = Class19.string_1;
		this.txt_Type.Text = Class19.model + "-" + Class19.string_0;
		Class19.string_12 = Class19.model + "-" + Class19.string_0 + ".zip";
		this.method_4();
		Interlocked.Exchange(ref FRM_iBoy.int_3, 0);
		return num > 2;
	}

	// Token: 0x0600008A RID: 138 RVA: 0x000099BC File Offset: 0x00007BBC
	public void method_4()
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		try
		{
			Class25 @class = new Class25();
			string text = @class.method_2();
			text = text.ToString().Replace("\n", "").Replace("\r", "")
				.Replace("\t", "");
			string text2 = text;
			string text3 = text2;
			if (text3 == "AUTHORIZED")
			{
				if (!FRM_iBoy.bool_0)
				{
					this.txt_RegStatus.ForeColor = Color.SpringGreen;
					this.txt_RegStatus.Text = "Already Registered";
				}
			}
			else if (text3 == "NOT_AUTHORIZED")
			{
				this.txt_RegStatus.ForeColor = Color.IndianRed;
				this.txt_RegStatus.Text = "No Registered";
				goto IL_E7;
			}
			if (text == "AUTHORIZED" && FRM_iBoy.bool_0)
			{
				this.txt_RegStatus.ForeColor = Color.SpringGreen;
				this.txt_RegStatus.Text = "Already Registered";
			}
			IL_E7:;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
		}
	}

	// Token: 0x0600008B RID: 139 RVA: 0x00009AD0 File Offset: 0x00007CD0
	private void btn_changeSN_Click(object sender, EventArgs e)
	{
		FRM_Purple frm_Purple = new FRM_Purple();
		if (!(this.lbl_pwned.Text == "CHECKM8"))
		{
			if (this.lbl_pwned.Text == "ECLIPSA")
			{
				frm_Purple.ShowDialog();
			}
			else if (this.lbl_pwned.Text == "GASTER")
			{
				frm_Purple.ShowDialog();
			}
			else if (this.lbl_pwned.Text == "GASDTER")
			{
				frm_Purple.ShowDialog();
			}
			else if (!(this.lbl_pwned.Text == "IPWNDER"))
			{
				if (this.txt_mode.Text == "Recovery")
				{
					MessageBox.Show("Your device in Recovery Mode \nPlease Connect in PWNDFU MODE", "iBoy Ramdisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("iPWNDFU Not Detected! \nPlease Connect Your Device With iPWNDFU Done!", "iBoy Ramdisk", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				frm_Purple.ShowDialog();
			}
		}
		else
		{
			frm_Purple.ShowDialog();
		}
	}

	// Token: 0x0600008C RID: 140 RVA: 0x00009BCC File Offset: 0x00007DCC
	private void btn_boot1_Click(object sender, EventArgs e)
	{
		if (this.cBox.Checked)
		{
			this.string_4 = "boot2";
			Class19.string_11 = "16";
			this.backgroundWorker_2.RunWorkerAsync();
		}
		else
		{
			Class19.string_11 = "15";
			this.string_4 = "boot";
			this.backgroundWorker_2.RunWorkerAsync();
		}
	}

	// Token: 0x0600008D RID: 141 RVA: 0x00009C28 File Offset: 0x00007E28
	private void method_5()
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		try
		{
			this.method_8();
		}
		catch
		{
		}
		try
		{
			Class25 @class = new Class25();
			if (!@class.method_0(this.string_4, Class19.string_2))
			{
				FRM_iBoy.Class12 class2 = new FRM_iBoy.Class12();
				class2.string_0 = "";
				if (this.string_4 == "boot")
				{
					class2.string_0 = "Bypass Passcode iOS 15";
				}
				if (this.string_4 == "activatebackup")
				{
					class2.string_0 = "Bypass Passcode iOS 15";
				}
				if (this.string_4 == "backup")
				{
					class2.string_0 = "Bypass Passcode iOS 15";
				}
				if (this.string_4 == "boot_purple")
				{
					class2.string_0 = "Bypass Hello iOS 15";
				}
				if (this.string_4 == "eraser")
				{
					class2.string_0 = "Bypass Passcode iOS 15";
				}
				base.Invoke(new MethodInvoker(class2.method_0));
			}
			else
			{
				if (this.string_4 == "boot")
				{
					Class17 class3 = new Class17();
					class3.method_3();
				}
				if (this.string_4 == "boot2")
				{
					Class17 class4 = new Class17();
					class4.method_5();
				}
				if (this.string_4 == "backup")
				{
					Class20 class5 = new Class20();
					class5.method_0();
				}
				if (this.string_4 == "activatebackup")
				{
					Class20 class6 = new Class20();
					class6.method_5();
				}
				if (this.string_4 == "boot_purple")
				{
					Class17 class7 = new Class17();
					class7.method_1();
				}
				if (this.string_4 == "eraser")
				{
					Class8 class8 = new Class8();
					class8.method_1();
				}
			}
		}
		catch
		{
			base.Invoke(new MethodInvoker(FRM_iBoy.Class11.<>9.method_0));
		}
		finally
		{
			base.Invoke(new MethodInvoker(this.method_27));
		}
	}

	// Token: 0x0600008E RID: 142 RVA: 0x00009E74 File Offset: 0x00008074
	public void method_6(string string_5)
	{
		this.txt_info.Text = string_5;
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00009E90 File Offset: 0x00008090
	public void method_7(int int_4, string string_5)
	{
		this.progressBar1.Value = int_4;
	}

	// Token: 0x06000090 RID: 144 RVA: 0x00009EAC File Offset: 0x000080AC
	private void btn_register_Click(object sender, EventArgs e)
	{
		Process.Start("http://t.me/pentaboy_bot/");
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00009EC4 File Offset: 0x000080C4
	private void btn_readHello_Click(object sender, EventArgs e)
	{
		Class15 @class = new Class15();
		File.WriteAllText("ssl\\serial.pl", @class.method_14("SerialNumber").Trim());
		File.WriteAllText("ssl\\udid.pl", @class.method_14("UniqueDeviceID").Trim());
		File.WriteAllText("ssl\\model.pl", @class.method_14("ProductType").Trim());
		File.WriteAllText("ssl\\version.pl", @class.method_14("ProductVersion").Trim());
		Class19.SN = File.ReadAllText("ssl/serial.pl");
		Class19.model = File.ReadAllText("ssl/model.pl");
		Class19.ios_version = File.ReadAllText("ssl/version.pl");
		this.txt_info.Text = string.Concat(new string[]
		{
			Class19.model,
			" | SN : ",
			Class19.SN,
			" | iOS : ",
			Class19.ios_version
		});
	}

	// Token: 0x06000092 RID: 146 RVA: 0x00009FAC File Offset: 0x000081AC
	private void btn_get_activation_Click(object sender, EventArgs e)
	{
		this.string_4 = "generate_activation";
		this.method_8();
		Class15 @class = new Class15();
		File.WriteAllText("ssl\\udid.pl", @class.method_14("UniqueDeviceID").Trim());
		@class.method_7();
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00009FF0 File Offset: 0x000081F0
	public void method_8()
	{
		this.btn_activate.Enabled = false;
		this.btn_backup.Enabled = false;
		this.btn_boot1.Enabled = false;
		this.btn_eraser.Enabled = false;
		this.btn_checkSSH.Enabled = false;
		this.btn_get_activation.Enabled = false;
		this.btn_act_hello.Enabled = false;
		this.btn_changeSN.Enabled = false;
	}

	// Token: 0x06000094 RID: 148 RVA: 0x0000A060 File Offset: 0x00008260
	private void btn_act_hello_Click(object sender, EventArgs e)
	{
		this.method_8();
		Class15 @class = new Class15();
		@class.method_15();
		this.method_9();
	}

	// Token: 0x06000095 RID: 149 RVA: 0x0000A088 File Offset: 0x00008288
	public void method_9()
	{
		this.btn_activate.Enabled = true;
		this.btn_backup.Enabled = true;
		this.btn_boot1.Enabled = true;
		this.btn_eraser.Enabled = true;
		this.btn_get_activation.Enabled = true;
		this.btn_act_hello.Enabled = true;
		this.btn_changeSN.Enabled = true;
		this.btn_checkdev.Enabled = true;
		this.btn_checkSSH.Enabled = true;
	}

	// Token: 0x06000096 RID: 150 RVA: 0x0000A104 File Offset: 0x00008304
	private void btn_checkSSH_Click(object sender, EventArgs e)
	{
		this.method_8();
		if (!this.cBox.Checked)
		{
			Class19.string_11 = "15";
			this.method_11();
		}
		else
		{
			Class19.string_11 = "16";
			this.method_12();
		}
		this.method_9();
	}

	// Token: 0x06000097 RID: 151 RVA: 0x0000A14C File Offset: 0x0000834C
	private bool method_10()
	{
		bool flag;
		try
		{
			this.method_17(this.int_1, 22);
			this.method_16("127.0.0.1", this.int_1, "alpine");
			this.method_14();
			if (!this.sshClient_0.IsConnected)
			{
				this.sshClient_0.Connect();
			}
			flag = true;
		}
		catch
		{
			flag = false;
		}
		return flag;
	}

	// Token: 0x06000098 RID: 152 RVA: 0x0000A1BC File Offset: 0x000083BC
	public void method_11()
	{
		if (!this.method_10())
		{
			this.method_20();
		}
		else
		{
			this.progressBar1.Value = 100;
			Class20 @class = new Class20();
			@class.method_10();
			MessageBox.Show("Successfully SSH Connected!", "iBoy Ramdisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	// Token: 0x06000099 RID: 153 RVA: 0x0000A208 File Offset: 0x00008408
	public void method_12()
	{
		if (!this.method_13())
		{
			this.method_20();
		}
		else
		{
			this.progressBar1.Value = 100;
			MessageBox.Show("Successfully SSH Connected!", "iBoy Ramdisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	// Token: 0x0600009A RID: 154 RVA: 0x0000A248 File Offset: 0x00008448
	private bool method_13()
	{
		bool flag;
		try
		{
			this.method_17(this.int_1, 86);
			this.method_16("127.0.0.1", this.int_1, "TgRam2022");
			this.method_15();
			if (!this.sshClient_0.IsConnected)
			{
				this.sshClient_0.Connect();
			}
			flag = true;
		}
		catch
		{
			flag = false;
		}
		return flag;
	}

	// Token: 0x0600009B RID: 155 RVA: 0x0000A2B8 File Offset: 0x000084B8
	public void method_14()
	{
		this.method_20();
		Thread.Sleep(2000);
		using (Process process = new Process())
		{
			process.StartInfo.FileName = FRM_iBoy.string_0 + "\\files\\iproxy.exe";
			process.StartInfo.Arguments = this.int_0.ToString() + " 22";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
		}
		try
		{
			this.method_18();
		}
		catch
		{
		}
	}

	// Token: 0x0600009C RID: 156 RVA: 0x0000A380 File Offset: 0x00008580
	public void method_15()
	{
		this.method_20();
		Thread.Sleep(2000);
		using (Process process = new Process())
		{
			process.StartInfo.FileName = FRM_iBoy.string_0 + "\\files\\iproxy.exe";
			process.StartInfo.Arguments = this.int_0.ToString() + " 86";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
		}
		try
		{
			this.method_19();
		}
		catch
		{
		}
	}

	// Token: 0x0600009D RID: 157 RVA: 0x0000A448 File Offset: 0x00008648
	public void method_16(string string_5, int int_4, string string_6)
	{
		AuthenticationMethod[] array = new AuthenticationMethod[]
		{
			new PasswordAuthenticationMethod("root", string_6)
		};
		ConnectionInfo connectionInfo = new ConnectionInfo(string_5, int_4, "root", array);
		SshClient sshClient = new SshClient(connectionInfo);
		sshClient.Connect();
		sshClient.Disconnect();
	}

	// Token: 0x0600009E RID: 158 RVA: 0x0000A48C File Offset: 0x0000868C
	public void method_17(int int_4, int int_5)
	{
		string text = FRM_iBoy.string_0 + "/files/iproxy.exe";
		if ((this.process_0 == null && File.Exists(text)) || this.process_0.HasExited)
		{
			this.process_0 = new Process();
			this.process_0.StartInfo.FileName = text;
			this.process_0.StartInfo.Arguments = int_4.ToString() + " " + int_5.ToString();
			this.process_0.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			this.process_0.Start();
		}
		else if (!File.Exists(text))
		{
		}
	}

	// Token: 0x0600009F RID: 159 RVA: 0x0000A534 File Offset: 0x00008734
	public void method_18()
	{
		AuthenticationMethod[] array = new AuthenticationMethod[]
		{
			new PasswordAuthenticationMethod("root", "alpine")
		};
		ConnectionInfo connectionInfo = new ConnectionInfo(this.string_1, this.int_0, "root", array);
		connectionInfo.Timeout = TimeSpan.FromSeconds(20.0);
		this.sshClient_0 = new SshClient(connectionInfo);
		this.scpClient_1 = new ScpClient(connectionInfo);
		if (!this.sshClient_0.IsConnected)
		{
			this.sshClient_0.Connect();
		}
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x0000A5BC File Offset: 0x000087BC
	public void method_19()
	{
		AuthenticationMethod[] array = new AuthenticationMethod[]
		{
			new PasswordAuthenticationMethod("root", "TgRam2022")
		};
		ConnectionInfo connectionInfo = new ConnectionInfo(this.string_1, this.int_0, "root", array);
		connectionInfo.Timeout = TimeSpan.FromSeconds(20.0);
		this.sshClient_0 = new SshClient(connectionInfo);
		this.scpClient_1 = new ScpClient(connectionInfo);
		if (!this.sshClient_0.IsConnected)
		{
			this.sshClient_0.Connect();
		}
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x0000A644 File Offset: 0x00008844
	public void method_20()
	{
		Process[] processesByName = Process.GetProcessesByName("iproxy");
		for (int i = 0; i < processesByName.Length; i++)
		{
			processesByName[i].Kill();
		}
		if (File.Exists("%USERPROFILE%\\.ssh\\known_hosts"))
		{
			File.Delete("%USERPROFILE%\\.ssh\\known_hosts");
		}
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x0000A68C File Offset: 0x0000888C
	private void btn_eraser_Click(object sender, EventArgs e)
	{
		if (this.lbl_pwned.Text != "-")
		{
			this.string_4 = "eraser";
			this.backgroundWorker_2.RunWorkerAsync();
		}
		else if (!(this.txt_mode.Text == "Recovery"))
		{
			MessageBox.Show("iPWNDFU Not Detected Please Connect Your Device With iPWNDFU Done!", "iBoy Ramdisk", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else
		{
			MessageBox.Show("Connect Your Device in DFU MODE and With iPWNDFU !!!", "iBoy Ramdisk", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x0000A708 File Offset: 0x00008908
	private void FRM_iBoy_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (MessageBox.Show("Are you sure you want to close?\n\niBoy Ramdisk was Helpful for you? \nSupport the developer with donate", "Terminate Program?", MessageBoxButtons.YesNo) == DialogResult.No)
		{
			e.Cancel = true;
		}
		else
		{
			Process.Start("https://www.buymeacoffee.com/plankton21");
			Process.GetCurrentProcess().Kill();
		}
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x0000A748 File Offset: 0x00008948
	private void btn_backup_Click(object sender, EventArgs e)
	{
		this.string_4 = "backup";
		this.backgroundWorker_2.RunWorkerAsync();
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x0000A76C File Offset: 0x0000896C
	private void metroButton1_Click(object sender, EventArgs e)
	{
		Process.Start("https://www.youtube.com/channel/UCi4ArIArzpuKZZC6Utf4CSg");
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x0000A784 File Offset: 0x00008984
	private void btn_activate_Click(object sender, EventArgs e)
	{
		this.string_4 = "activatebackup";
		this.backgroundWorker_2.RunWorkerAsync();
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x0000A7A8 File Offset: 0x000089A8
	private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
	{
		GClass1 gclass = new GClass1();
		try
		{
			Class25 @class = new Class25();
			if (!@class.method_0(this.string_4, Class19.string_2))
			{
				MessageBox.Show("ECID Not Registered \nPlease Contact Reseller or Administrator To Register Your ECID\nThanks for Using [\ud83d\udca0 - Kratius Ramdisk - \ud83d\udca0]", "\ud83d\udca0Device Not Registerd\ud83d\udca0", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				gclass.method_6();
				gclass.method_4("-q");
				if (gclass.method_2("-q"))
				{
					this.method_2();
					MessageBox.Show("Please click BOOT 1 or BOOT 2 Button", "Already in PWNDFU MODE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					gclass.method_5();
					this.method_22();
					gclass.method_6();
					gclass.method_4("-q");
					gclass.method_3("-q");
					this.method_2();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x0000A87C File Offset: 0x00008A7C
	private void method_21()
	{
		GClass1 gclass = new GClass1();
		int num = 0;
		while (this.backgroundWorker_1.IsBusy)
		{
			num++;
			Thread.Sleep(100);
			if (num == 20)
			{
				gclass.method_5();
			}
			if (num == 50)
			{
				break;
			}
		}
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x0000A8C0 File Offset: 0x00008AC0
	private void method_22()
	{
		this.backgroundWorker_1 = new BackgroundWorker();
		this.backgroundWorker_1.DoWork += this.backgroundWorker_1_DoWork;
		this.backgroundWorker_1.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
		this.backgroundWorker_1.RunWorkerAsync();
	}

	// Token: 0x060000AA RID: 170 RVA: 0x0000A914 File Offset: 0x00008B14
	private void backgroundWorker_1_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			this.gclass3_0.method_6();
			this.gclass3_0.method_5();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	// Token: 0x060000AB RID: 171 RVA: 0x0000A964 File Offset: 0x00008B64
	private void btn_driver_Click(object sender, EventArgs e)
	{
		this.string_4 = "gaster";
		this.backgroundWorker_0 = new BackgroundWorker();
		this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
		this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
		this.backgroundWorker_0.RunWorkerAsync();
	}

	// Token: 0x060000AC RID: 172 RVA: 0x0000A9C0 File Offset: 0x00008BC0
	private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		this.method_9();
	}

	// Token: 0x060000AD RID: 173 RVA: 0x0000A9D4 File Offset: 0x00008BD4
	private void FRM_iBoy_Load(object sender, EventArgs e)
	{
		FRM_iBoy.ideviceNotifier_0.OnDeviceNotify += this.method_23;
		Console.WriteLine("");
	}

	// Token: 0x060000AE RID: 174 RVA: 0x0000AA04 File Offset: 0x00008C04
	private void method_23(object sender, DeviceNotifyEventArgs e)
	{
		if (!(e.EventType.ToString() == "DeviceArrival"))
		{
			if (e.EventType.ToString() == "DeviceRemoveComplete")
			{
				this.txt_info.Text = "Device Disconnected";
				this.method_8();
			}
		}
		else
		{
			string text = e.Device.IdVendor.ToString();
			string text2 = e.Device.IdProduct.ToString();
			if (text2 == "4647" && text == "1452")
			{
				this.method_3("");
				this.btn_boot1.Enabled = true;
				this.btn_eraser.Enabled = true;
				this.btn_get_activation.Enabled = false;
				this.btn_readHello.Enabled = false;
				this.btn_changeSN.Enabled = true;
				this.btn_checkdev.Enabled = true;
				this.txt_info.Text = Class19.string_1 + " in DFU Mode";
			}
			else if (text2 == "4737" && text == "1452")
			{
				this.method_3("");
				this.txt_info.Text = Class19.string_1 + " in Recovery Mode";
			}
			else if (text2 == "4776" || text2 == "4779")
			{
				this.method_24();
				this.btn_boot1.Enabled = false;
				this.btn_eraser.Enabled = false;
				this.btn_get_activation.Enabled = true;
				this.btn_readHello.Enabled = true;
				this.btn_changeSN.Enabled = false;
				this.btn_checkdev.Enabled = false;
			}
		}
	}

	// Token: 0x060000AF RID: 175 RVA: 0x0000ABD4 File Offset: 0x00008DD4
	public void method_24()
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		if (Interlocked.Exchange(ref FRM_iBoy.int_3, 1) == 0)
		{
			if (!this.method_25(""))
			{
			}
		}
		else
		{
			Console.WriteLine("   {0} was denied the lock", Thread.CurrentThread.Name);
			MessageBox.Show("Please Press Trust in Device");
		}
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x0000AC28 File Offset: 0x00008E28
	private bool method_25(string string_5 = "")
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		Process process = new Process();
		process.StartInfo.FileName = Environment.CurrentDirectory + "/files/ideviceinfo.exe";
		process.StartInfo.Arguments = string_5;
		process.StartInfo.UseShellExecute = false;
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.CreateNoWindow = true;
		process.Start();
		int num = 0;
		while (!process.StandardOutput.EndOfStream)
		{
			num++;
			string text = process.StandardOutput.ReadLine();
			string text2 = text.Replace("\r", "");
			if (!text2.StartsWith("UniqueDeviceID: "))
			{
				if (text2.StartsWith("ProductVersion: "))
				{
					string text3 = text2.Replace("ProductVersion: ", "");
					Class19.ios_version = text3;
					File.WriteAllText("ssl\\version.pl", text3.Trim());
				}
				else if (text2.StartsWith("ProductType: "))
				{
					string text4 = text2.Replace("ProductType: ", "");
					Class19.model = text4;
					File.WriteAllText("ssl\\model.pl", text4.Trim());
				}
				else if (!text2.StartsWith("HardwareModel: "))
				{
					if (text2.StartsWith("UniqueChipID: "))
					{
						string text5 = text2.Replace("UniqueChipID: ", "");
						string text6 = text5.Trim();
						string text7 = string.Empty;
						string text8 = this.method_26(text6.ToString());
						text7 += string.Format("{0}", text8);
						Class19.string_2 = "0x00" + text7.ToLower();
					}
				}
				else
				{
					string text9 = text2.Replace("HardwareModel: ", "");
					Class19.string_0 = text9.ToLower();
				}
			}
			else
			{
				string text10 = text2.Replace("UniqueDeviceID: ", "");
				File.WriteAllText("ssl\\udid.pl", text10.Trim());
			}
			string[] array = text.Split(new char[] { ':' });
			if (array[0] == "SerialNumber")
			{
				File.WriteAllText("ssl\\serial.pl", array[1].Trim());
				Class19.SN = array[1].Trim();
				this.txt_info.Text = string.Concat(new string[]
				{
					Class19.model,
					" | SN : ",
					Class19.SN,
					" | iOS : ",
					Class19.ios_version
				});
				this.txt_mode.Text = "NORMAL";
			}
		}
		this.txt_Type.Text = Class19.model + "-" + Class19.string_0;
		this.txt_ECID.Text = Class19.string_2.ToUpper();
		Interlocked.Exchange(ref FRM_iBoy.int_3, 0);
		return num > 2;
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x0000AEF8 File Offset: 0x000090F8
	public string method_26(string string_5)
	{
		string text;
		try
		{
			BigInteger bigInteger = 0;
			text = BigInteger.Parse(string_5).ToString("X");
		}
		catch
		{
			text = string.Empty;
		}
		return text;
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x0000AF40 File Offset: 0x00009140
	private void backgroundWorker_2_DoWork(object sender, DoWorkEventArgs e)
	{
		Control.CheckForIllegalCrossThreadCalls = false;
		try
		{
			this.method_8();
		}
		catch
		{
		}
		try
		{
			Class25 @class = new Class25();
			if (@class.method_0(this.string_4, Class19.string_2))
			{
				if (this.string_4 == "boot")
				{
					Class17 class2 = new Class17();
					class2.method_3();
				}
				if (this.string_4 == "boot2")
				{
					Class17 class3 = new Class17();
					class3.method_5();
				}
				if (this.string_4 == "backup")
				{
					Class20 class4 = new Class20();
					class4.method_0();
				}
				if (this.string_4 == "activatebackup")
				{
					Class20 class5 = new Class20();
					class5.method_5();
				}
				if (this.string_4 == "boot_purple")
				{
					Class17 class6 = new Class17();
					class6.method_1();
				}
				if (this.string_4 == "eraser")
				{
					Class8 class7 = new Class8();
					class7.method_1();
				}
			}
			else
			{
				FRM_iBoy.Class13 class8 = new FRM_iBoy.Class13();
				class8.string_0 = "";
				if (this.string_4 == "boot")
				{
					class8.string_0 = "Bypass Passcode iOS 15";
				}
				if (this.string_4 == "activatebackup")
				{
					class8.string_0 = "Bypass Passcode iOS 15";
				}
				if (this.string_4 == "backup")
				{
					class8.string_0 = "Bypass Passcode iOS 15";
				}
				if (this.string_4 == "boot_purple")
				{
					class8.string_0 = "Bypass Hello iOS 15";
				}
				if (this.string_4 == "eraser")
				{
					class8.string_0 = "Bypass Passcode iOS 15";
				}
				base.Invoke(new MethodInvoker(class8.method_0));
			}
		}
		catch
		{
			base.Invoke(new MethodInvoker(FRM_iBoy.Class11.<>9.method_1));
		}
		finally
		{
			base.Invoke(new MethodInvoker(this.method_28));
		}
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x0000B18C File Offset: 0x0000938C
	private void metroButton2_Click(object sender, EventArgs e)
	{
		Class20 @class = new Class20();
		@class.method_2();
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x0000B1A8 File Offset: 0x000093A8
	private void metroButton3_Click(object sender, EventArgs e)
	{
		Class15 @class = new Class15();
		@class.method_8();
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x0000B1C4 File Offset: 0x000093C4
	protected virtual void MetroFramework.Forms.MetroForm.Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x0000A9C0 File Offset: 0x00008BC0
	[CompilerGenerated]
	private void method_27()
	{
		this.method_9();
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x0000A9C0 File Offset: 0x00008BC0
	[CompilerGenerated]
	private void method_28()
	{
		this.method_9();
	}

	// Token: 0x060000BA RID: 186 RVA: 0x0000CC54 File Offset: 0x0000AE54
	void method_29(MetroColorStyle metroColorStyle_0)
	{
		base.Style = metroColorStyle_0;
	}

	// Token: 0x060000BB RID: 187 RVA: 0x000092AC File Offset: 0x000074AC
	void method_30(MetroThemeStyle metroThemeStyle_0)
	{
		base.Theme = metroThemeStyle_0;
	}

	// Token: 0x04000050 RID: 80
	public static string string_0 = Environment.CurrentDirectory;

	// Token: 0x04000051 RID: 81
	public int int_0 = 22;

	// Token: 0x04000052 RID: 82
	public string string_1 = "127.0.0.1";

	// Token: 0x04000053 RID: 83
	public string string_2 = "alpine";

	// Token: 0x04000054 RID: 84
	private SshClient sshClient_0;

	// Token: 0x04000055 RID: 85
	public SshClient sshClient_1 = new SshClient("127.0.0.1", "root", "alpine");

	// Token: 0x04000056 RID: 86
	public ScpClient scpClient_0 = new ScpClient("127.0.0.1", "root", "alpine");

	// Token: 0x04000057 RID: 87
	private ScpClient scpClient_1;

	// Token: 0x04000058 RID: 88
	public int int_1 = 2222;

	// Token: 0x04000059 RID: 89
	public int int_2 = 22;

	// Token: 0x0400005A RID: 90
	private Process process_0 = null;

	// Token: 0x0400005B RID: 91
	public static string string_3 = FRM_iBoy.string_0 + "\\files\\tmp\\";

	// Token: 0x0400005C RID: 92
	private string string_4;

	// Token: 0x0400005D RID: 93
	public static bool bool_0 = true;

	// Token: 0x0400005E RID: 94
	public static IDeviceNotifier ideviceNotifier_0 = DeviceNotifier.OpenDeviceNotifier();

	// Token: 0x0400005F RID: 95
	private static int int_3 = 0;

	// Token: 0x04000060 RID: 96
	private BackgroundWorker backgroundWorker_0 = new BackgroundWorker();

	// Token: 0x04000061 RID: 97
	private BackgroundWorker backgroundWorker_1 = new BackgroundWorker();

	// Token: 0x04000062 RID: 98
	private GClass3 gclass3_0 = new GClass3();

	// Token: 0x04000063 RID: 99
	private IContainer icontainer_0 = null;

	// Token: 0x02000019 RID: 25
	[CompilerGenerated]
	[Serializable]
	private sealed class Class11
	{
		// Token: 0x060000BE RID: 190 RVA: 0x0000CC80 File Offset: 0x0000AE80
		internal void method_0()
		{
			MessageBox.Show("Check Your Internet Connection and Try Again.", "NOTIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000CC80 File Offset: 0x0000AE80
		internal void method_1()
		{
			MessageBox.Show("Check Your Internet Connection and Try Again.", "NOTIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x04000089 RID: 137
		public static readonly FRM_iBoy.Class11 <>9 = new FRM_iBoy.Class11();

		// Token: 0x0400008A RID: 138
		public static MethodInvoker <>9__26_0;

		// Token: 0x0400008B RID: 139
		public static MethodInvoker <>9__66_0;
	}

	// Token: 0x0200001A RID: 26
	[CompilerGenerated]
	private sealed class Class12
	{
		// Token: 0x060000C1 RID: 193 RVA: 0x0000CCA0 File Offset: 0x0000AEA0
		internal void method_0()
		{
			MessageBox.Show("ECID : " + Class19.string_2 + " is Not Authorized !\nPlease Register ECID as " + this.string_0, "NOT REGISTERED", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0400008C RID: 140
		public string string_0;
	}

	// Token: 0x0200001B RID: 27
	[CompilerGenerated]
	private sealed class Class13
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x0000CCD8 File Offset: 0x0000AED8
		internal void method_0()
		{
			MessageBox.Show("ECID : " + Class19.string_2 + " is Not Authorized !\nPlease Register ECID as " + this.string_0, "NOT REGISTERED", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0400008D RID: 141
		public string string_0;
	}
}
