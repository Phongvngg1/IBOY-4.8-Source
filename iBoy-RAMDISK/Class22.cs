using System;
using System.IO;
using System.IO.Compression;

// Token: 0x02000025 RID: 37
internal class Class22
{
	// Token: 0x06000118 RID: 280 RVA: 0x00011BA4 File Offset: 0x0000FDA4
	public void method_0()
	{
		ZipFile.ExtractToDirectory(Class22.string_1, this.string_2);
	}

	// Token: 0x040000BC RID: 188
	public static string string_0 = Directory.GetCurrentDirectory();

	// Token: 0x040000BD RID: 189
	public static string string_1 = ".\\Backups\\0x00164966102b003a.zip";

	// Token: 0x040000BE RID: 190
	private string string_2 = Environment.CurrentDirectory + "\\Backups\\0x00164966102b003a";
}
