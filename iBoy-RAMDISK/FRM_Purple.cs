using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

// Token: 0x02000016 RID: 22
public partial class FRM_Purple : MetroForm
{
	// Token: 0x06000072 RID: 114 RVA: 0x00008434 File Offset: 0x00006634
	public FRM_Purple()
	{
		this.InitializeComponent();
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00008454 File Offset: 0x00006654
	private void metroButton3_Click(object sender, EventArgs e)
	{
		this.string_0 = "boot_purple";
		this.backgroundWorker_0.RunWorkerAsync();
	}

	// Token: 0x06000074 RID: 116 RVA: 0x00008478 File Offset: 0x00006678
	private void FRM_Purple_Load(object sender, EventArgs e)
	{
		string[] portNames = SerialPort.GetPortNames();
		ComboBox.ObjectCollection items = this.cBoxPORT.Items;
		object[] array = portNames;
		items.AddRange(array);
		this.metroButton1.Enabled = false;
		this.btn_Reboot.Enabled = false;
	}

	// Token: 0x06000075 RID: 117 RVA: 0x000084B8 File Offset: 0x000066B8
	private void btn_connect_Click(object sender, EventArgs e)
	{
		if (this.serialPort_0.IsOpen)
		{
			this.method_0();
		}
		else
		{
			try
			{
				this.serialPort_0.PortName = this.cBoxPORT.Text;
				this.serialPort_0.BaudRate = 115200;
				this.serialPort_0.DataBits = 8;
				this.serialPort_0.Open();
				this.btn_connect.Text = "CLOSE PORT";
				this.metroButton1.Enabled = true;
				this.btn_Reboot.Enabled = true;
				this.metroButton4.Enabled = false;
				this.cBoxPORT.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00008584 File Offset: 0x00006784
	public void method_0()
	{
		this.serialPort_0.Close();
		this.btn_connect.Text = "OPEN PORT";
		this.metroButton4.Enabled = true;
		this.cBoxPORT.Enabled = true;
		this.metroButton1.Enabled = false;
		this.btn_Reboot.Enabled = false;
	}

	// Token: 0x06000077 RID: 119 RVA: 0x000085DC File Offset: 0x000067DC
	private void metroButton4_Click(object sender, EventArgs e)
	{
		string[] portNames = SerialPort.GetPortNames();
		this.cBoxPORT.Items.Clear();
		ComboBox.ObjectCollection items = this.cBoxPORT.Items;
		object[] array = portNames;
		items.AddRange(array);
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00008614 File Offset: 0x00006814
	private void btn_Reboot_Click(object sender, EventArgs e)
	{
		if (this.serialPort_0.IsOpen)
		{
			try
			{
				this.serialPort_0.WriteLine("reset");
				this.method_0();
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		MessageBox.Show("No COM-PORT Open", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00008684 File Offset: 0x00006884
	private void metroButton1_Click(object sender, EventArgs e)
	{
		if (this.serialPort_0.IsOpen)
		{
			try
			{
				this.serialPort_0.WriteLine("Syscfg add SrNm " + this.metroTextBox1.Text);
				MessageBox.Show("Successfull Change Serial to " + this.metroTextBox1.Text, "Success !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.serialPort_0.WriteLine("reset");
				this.method_0();
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		MessageBox.Show("No COM-PORT Open \nPlease open port first!!", "Error No SerialPort Open!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	// Token: 0x0600007A RID: 122 RVA: 0x00008734 File Offset: 0x00006934
	private void metroButton5_Click(object sender, EventArgs e)
	{
		if (this.serialPort_0.IsOpen)
		{
			try
			{
				this.serialPort_0.WriteLine("Syscfg print SrNm");
				string text = this.serialPort_0.ReadExisting();
				MessageBox.Show("Successfull Change Serial to " + text, "Success !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		MessageBox.Show("No COM-PORT Open \nPlease open port first!!", "Error No SerialPort Open!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	// Token: 0x0600007B RID: 123 RVA: 0x000087C0 File Offset: 0x000069C0
	private void metroButton2_Click(object sender, EventArgs e)
	{
		if (this.serialPort_0.IsOpen)
		{
			try
			{
				this.serialPort_0.WriteLine("Syscfg add Regn PA/A");
				this.serialPort_0.ReadExisting();
				MessageBox.Show("Successfull Change Serial to PA/A", "Success !!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		MessageBox.Show("No COM-PORT Open \nPlease open port first!!", "Error No SerialPort Open!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00008848 File Offset: 0x00006A48
	private void method_1(object sender, DoWorkEventArgs e)
	{
	}

	// Token: 0x0600007D RID: 125 RVA: 0x00008858 File Offset: 0x00006A58
	private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
	{
		Class25 @class = new Class25();
		if (@class.method_0(this.string_0, Class19.string_2))
		{
			if (this.string_0 == "boot_purple")
			{
				Class17 class2 = new Class17();
				class2.method_0();
			}
		}
		else
		{
			FRM_Purple.Class10 class3 = new FRM_Purple.Class10();
			class3.string_0 = "";
			if (this.string_0 == "boot_purple")
			{
				class3.string_0 = "Bypass Hello iOS 15";
			}
			base.Invoke(new MethodInvoker(class3.method_0));
		}
	}

	// Token: 0x0600007E RID: 126 RVA: 0x000088E4 File Offset: 0x00006AE4
	protected virtual void MetroFramework.Forms.MetroForm.Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000080 RID: 128 RVA: 0x000092AC File Offset: 0x000074AC
	void method_2(MetroThemeStyle metroThemeStyle_0)
	{
		base.Theme = metroThemeStyle_0;
	}

	// Token: 0x0400003E RID: 62
	private string string_0;

	// Token: 0x0400003F RID: 63
	public string string_1;

	// Token: 0x02000017 RID: 23
	[CompilerGenerated]
	private sealed class Class10
	{
		// Token: 0x06000082 RID: 130 RVA: 0x000092C0 File Offset: 0x000074C0
		internal void method_0()
		{
			MessageBox.Show("ECID : " + Class19.string_2 + " is Not Authorized !\nPlease Register ECID as " + this.string_0, "NOT REGISTERED", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0400004F RID: 79
		public string string_0;
	}
}
