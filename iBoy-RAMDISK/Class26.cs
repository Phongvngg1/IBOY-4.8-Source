using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

// Token: 0x02000029 RID: 41
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Class26
{
	// Token: 0x06000123 RID: 291 RVA: 0x00005368 File Offset: 0x00003568
	internal Class26()
	{
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000124 RID: 292 RVA: 0x00011F38 File Offset: 0x00010138
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager_0
	{
		get
		{
			if (Class26.resourceManager_0 == null)
			{
				ResourceManager resourceManager = new ResourceManager("Class26", typeof(Class26).Assembly);
				Class26.resourceManager_0 = resourceManager;
			}
			return Class26.resourceManager_0;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000125 RID: 293 RVA: 0x00011F78 File Offset: 0x00010178
	// (set) Token: 0x06000126 RID: 294 RVA: 0x00011F8C File Offset: 0x0001018C
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo CultureInfo_0
	{
		get
		{
			return Class26.cultureInfo_0;
		}
		set
		{
			Class26.cultureInfo_0 = value;
		}
	}

	// Token: 0x040000C0 RID: 192
	private static ResourceManager resourceManager_0;

	// Token: 0x040000C1 RID: 193
	private static CultureInfo cultureInfo_0;
}
