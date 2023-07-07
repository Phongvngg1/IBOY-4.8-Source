using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

// Token: 0x02000010 RID: 16
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Class6
{
	// Token: 0x0600004C RID: 76 RVA: 0x00005368 File Offset: 0x00003568
	internal Class6()
	{
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x0600004D RID: 77 RVA: 0x00007420 File Offset: 0x00005620
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager_0
	{
		get
		{
			if (Class6.resourceManager_0 == null)
			{
				ResourceManager resourceManager = new ResourceManager("Class6", typeof(Class6).Assembly);
				Class6.resourceManager_0 = resourceManager;
			}
			return Class6.resourceManager_0;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x0600004E RID: 78 RVA: 0x00007460 File Offset: 0x00005660
	// (set) Token: 0x0600004F RID: 79 RVA: 0x00007474 File Offset: 0x00005674
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo CultureInfo_0
	{
		get
		{
			return Class6.cultureInfo_0;
		}
		set
		{
			Class6.cultureInfo_0 = value;
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000050 RID: 80 RVA: 0x00007488 File Offset: 0x00005688
	internal static byte[] Byte_0
	{
		get
		{
			object @object = Class6.ResourceManager_0.GetObject("gaster", Class6.cultureInfo_0);
			return (byte[])@object;
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000051 RID: 81 RVA: 0x000074B4 File Offset: 0x000056B4
	internal static byte[] Byte_1
	{
		get
		{
			object @object = Class6.ResourceManager_0.GetObject("libcrypto_1_1_x64", Class6.cultureInfo_0);
			return (byte[])@object;
		}
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000052 RID: 82 RVA: 0x000074E0 File Offset: 0x000056E0
	internal static byte[] Byte_2
	{
		get
		{
			object @object = Class6.ResourceManager_0.GetObject("libssl_1_1_x64", Class6.cultureInfo_0);
			return (byte[])@object;
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000053 RID: 83 RVA: 0x0000750C File Offset: 0x0000570C
	internal static byte[] Byte_3
	{
		get
		{
			object @object = Class6.ResourceManager_0.GetObject("libusb_1_0", Class6.cultureInfo_0);
			return (byte[])@object;
		}
	}

	// Token: 0x04000036 RID: 54
	private static ResourceManager resourceManager_0;

	// Token: 0x04000037 RID: 55
	private static CultureInfo cultureInfo_0;
}
