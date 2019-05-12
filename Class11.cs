using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

// Token: 0x02000019 RID: 25
internal class Class11
{
	// Token: 0x06000167 RID: 359
	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	private static extern bool GetVolumeInformation(string string_0, StringBuilder stringBuilder_0, uint uint_1, out uint uint_2, out uint uint_3, out uint uint_4, StringBuilder stringBuilder_1, uint uint_5);

	// Token: 0x06000168 RID: 360
	[DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
	private static extern uint SHEmptyRecycleBin(IntPtr intptr_0, string string_0, Class11.Enum3 enum3_0);

	// Token: 0x06000169 RID: 361 RVA: 0x00014FC8 File Offset: 0x000131C8
	public void method_0()
	{
		Class10 @class = new Class10();
		try
		{
			StringBuilder stringBuilder_ = Class11.smethod_0(1024);
			StringBuilder stringBuilder = Class11.smethod_0(1024);
			uint num;
			uint num2;
			if (!Class11.GetVolumeInformation(Class11.smethod_2(Class11.smethod_1(), 0, 3), stringBuilder_, (uint)(Class11.smethod_3(stringBuilder_) - 1), out Class11.uint_0, out num, out num2, stringBuilder, (uint)(Class11.smethod_3(stringBuilder) - 1)))
			{
				Class11.smethod_4(@class.method_0("Unable to get volume information."), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Class11.smethod_6(Class11.smethod_5());
			}
			if (Class11.smethod_8(Class11.smethod_7(stringBuilder), "NTFS"))
			{
				Class11.smethod_4(@class.method_0("Please run the LEAGUEMODE client from a removable FAT, FAT32 or exFAT drive."), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Class11.smethod_6(Class11.smethod_5());
			}
			Class11.smethod_9(stringBuilder_);
			Class11.smethod_9(stringBuilder);
		}
		catch (Exception)
		{
			Class11.smethod_4(@class.method_0("Unable to verify volume FS type."), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Class11.smethod_6(Class11.smethod_5());
		}
	}

	// Token: 0x0600016A RID: 362 RVA: 0x000150C0 File Offset: 0x000132C0
	public void method_1()
	{
		if (Class11.smethod_11(Class11.smethod_10("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Windows", "ErrorMode", 0)) == 0)
		{
			Class11.smethod_12("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Windows", "ErrorMode", 2);
			Class11.smethod_13(1000);
			Class11.smethod_4("A reboot is required to apply changes to your computer.", Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			Class11.smethod_14("shutdown", "-r -f -t 120");
			Class11.smethod_13(1000);
			Class11.smethod_6(Class11.smethod_5());
		}
	}

	// Token: 0x0600016B RID: 363 RVA: 0x00015140 File Offset: 0x00013340
	public bool method_2()
	{
		bool result;
		try
		{
			Class23 @class = new Class23();
			if (Class11.smethod_16(Class11.smethod_15(Class11.smethod_1(), "\\Builder.exe")))
			{
				@class.method_0(Class11.smethod_15(Class11.smethod_1(), "\\Builder.exe"), 5);
				result = true;
			}
			else if (Class11.smethod_16(Class11.smethod_15(Class11.smethod_1(), "\\Client.exe")))
			{
				@class.method_0(Class11.smethod_15(Class11.smethod_1(), "\\Client.exe"), 5);
				result = true;
			}
			else
			{
				result = false;
			}
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600016C RID: 364 RVA: 0x000151D0 File Offset: 0x000133D0
	public void method_3()
	{
		Class10 @class = new Class10();
		try
		{
			string[] array = Class11.smethod_18(Class11.smethod_17(Environment.SpecialFolder.Desktop));
			int i = 0;
			while (i < array.Length)
			{
				string string_ = array[i];
				string string_2 = Class11.smethod_19(string_);
				if (Class11.smethod_21(Class11.smethod_20(string_), "leaguemode") != -1)
				{
					goto IL_E2;
				}
				if (Class11.smethod_21(Class11.smethod_20(string_), "cheat") != -1)
				{
					goto IL_E2;
				}
				if (Class11.smethod_21(Class11.smethod_20(string_), "hack") != -1)
				{
					goto IL_E2;
				}
				if (Class11.smethod_21(Class11.smethod_20(string_), "oracle") != -1)
				{
					goto IL_E2;
				}
				if (Class11.smethod_21(Class11.smethod_20(string_), "xstrike") != -1)
				{
					goto IL_E2;
				}
				if (Class11.smethod_8(Class11.smethod_20(string_), "xs.ini") || Class11.smethod_8(Class11.smethod_20(string_), "or.ini") || Class11.smethod_8(Class11.smethod_20(string_), Class11.smethod_22("SetupXS.cfg")) || Class11.smethod_8(Class11.smethod_20(string_), Class11.smethod_22("SetupOR.cfg")))
				{
					goto IL_E2;
				}
				IL_111:
				i++;
				continue;
				IL_E2:
				Class11.smethod_4(@class.method_0(Class11.smethod_23("Please delete the file '", string_2, "' from your Desktop before running the client.")), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Class11.smethod_6(Class11.smethod_5());
				goto IL_111;
			}
		}
		catch (Exception)
		{
			Class11.smethod_4(@class.method_0("Unable to do desktop filename safety check due to an exception."), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	// Token: 0x0600016D RID: 365 RVA: 0x00015338 File Offset: 0x00013538
	public void method_4()
	{
		Class10 @class = new Class10();
		try
		{
			if (Class11.smethod_24(Class11.smethod_15(Class11.smethod_17(Environment.SpecialFolder.UserProfile), "\\Downloads")))
			{
				string[] array = Class11.smethod_18(Class11.smethod_15(Class11.smethod_17(Environment.SpecialFolder.UserProfile), "\\Downloads"));
				int i = 0;
				while (i < array.Length)
				{
					string string_ = array[i];
					string string_2 = Class11.smethod_19(string_);
					if (Class11.smethod_21(Class11.smethod_20(string_), "leaguemode") != -1)
					{
						goto IL_117;
					}
					if (Class11.smethod_21(Class11.smethod_20(string_), "cheat") != -1)
					{
						goto IL_117;
					}
					if (Class11.smethod_21(Class11.smethod_20(string_), "hack") != -1)
					{
						goto IL_117;
					}
					if (Class11.smethod_21(Class11.smethod_20(string_), "oracle") != -1)
					{
						goto IL_117;
					}
					if (Class11.smethod_21(Class11.smethod_20(string_), "xstrike") != -1)
					{
						goto IL_117;
					}
					if (Class11.smethod_8(Class11.smethod_20(string_), "xs.ini") || Class11.smethod_8(Class11.smethod_20(string_), "or.ini") || Class11.smethod_8(Class11.smethod_20(string_), Class11.smethod_22("SetupXS.cfg")) || Class11.smethod_8(Class11.smethod_20(string_), Class11.smethod_22("SetupOR.cfg")))
					{
						goto IL_117;
					}
					IL_145:
					i++;
					continue;
					IL_117:
					Class11.smethod_4(@class.method_0(Class11.smethod_23("Please delete the file '", string_2, "' from your Downloads folder before running the client.")), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Class11.smethod_6(Class11.smethod_5());
					goto IL_145;
				}
			}
		}
		catch (Exception)
		{
			Class11.smethod_4(@class.method_0("Unable to do downloads filename safety check due to an exception."), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00002B9A File Offset: 0x00000D9A
	public void method_5()
	{
		Class11.SHEmptyRecycleBin(IntPtr.Zero, null, (Class11.Enum3)7u);
	}

	// Token: 0x0600016F RID: 367 RVA: 0x000154D4 File Offset: 0x000136D4
	public void method_6()
	{
		Class23 @class = new Class23();
		foreach (string string_ in Class11.smethod_25(Class11.smethod_17(Environment.SpecialFolder.History), "*", SearchOption.AllDirectories))
		{
			try
			{
				@class.method_0(string_, 5);
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000170 RID: 368 RVA: 0x0001552C File Offset: 0x0001372C
	public void method_7()
	{
		Class23 @class = new Class23();
		foreach (string string_ in Class11.smethod_25(Class11.smethod_17(Environment.SpecialFolder.Cookies), "*", SearchOption.AllDirectories))
		{
			try
			{
				@class.method_0(string_, 5);
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000171 RID: 369 RVA: 0x00015584 File Offset: 0x00013784
	public void method_8()
	{
		if (Class11.smethod_24(Class11.smethod_15(Class11.smethod_17(Environment.SpecialFolder.UserProfile), "\\AppData\\Local\\Microsoft\\Windows\\WebCache\\")))
		{
			Class23 @class = new Class23();
			foreach (string string_ in Class11.smethod_25(Class11.smethod_15(Class11.smethod_17(Environment.SpecialFolder.UserProfile), "\\AppData\\Local\\Microsoft\\Windows\\WebCache\\"), "*", SearchOption.AllDirectories))
			{
				try
				{
					if (Class11.smethod_26(string_, "V01") && Class11.smethod_26(string_, ".log"))
					{
						@class.method_0(string_, 5);
					}
				}
				catch (Exception)
				{
				}
			}
		}
	}

	// Token: 0x06000172 RID: 370 RVA: 0x00015618 File Offset: 0x00013818
	public void method_9()
	{
		if (Class11.smethod_24(Class11.smethod_15(Class11.smethod_17(Environment.SpecialFolder.UserProfile), "\\AppData\\Local\\Microsoft\\CLR_v4.0\\UsageLogs")))
		{
			Class23 @class = new Class23();
			foreach (string string_ in Class11.smethod_25(Class11.smethod_15(Class11.smethod_17(Environment.SpecialFolder.UserProfile), "\\AppData\\Local\\Microsoft\\CLR_v4.0\\UsageLogs"), "*", SearchOption.AllDirectories))
			{
				try
				{
					if (Class11.smethod_26(string_, ".log"))
					{
						@class.method_0(string_, 5);
					}
				}
				catch (Exception)
				{
				}
			}
		}
	}

	// Token: 0x06000173 RID: 371 RVA: 0x000156A0 File Offset: 0x000138A0
	public void method_10()
	{
		try
		{
			Class23 @class = new Class23();
			foreach (string string_ in Class11.smethod_25(Class11.smethod_17(Environment.SpecialFolder.InternetCache), "*", SearchOption.AllDirectories))
			{
				try
				{
					@class.method_0(string_, 5);
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000174 RID: 372 RVA: 0x00015708 File Offset: 0x00013908
	public void method_11()
	{
		try
		{
			Class11.smethod_14("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 4351");
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000175 RID: 373 RVA: 0x0001573C File Offset: 0x0001393C
	public void method_12()
	{
		Class23 @class = new Class23();
		foreach (string string_ in Class11.smethod_25(Class11.smethod_17(Environment.SpecialFolder.Recent), "*", SearchOption.AllDirectories))
		{
			try
			{
				@class.method_0(string_, 5);
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000176 RID: 374 RVA: 0x00002BA9 File Offset: 0x00000DA9
	public void method_13()
	{
		Class11.smethod_27();
	}

	// Token: 0x06000177 RID: 375 RVA: 0x00015794 File Offset: 0x00013994
	public void method_14()
	{
		if (Class11.smethod_8(Class13.string_12, "OSPREY"))
		{
			return;
		}
		Class23 @class = new Class23();
		foreach (string string_ in Class11.smethod_25(Class11.smethod_28(), "*", SearchOption.AllDirectories))
		{
			try
			{
				@class.method_0(string_, 5);
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000178 RID: 376 RVA: 0x000157FC File Offset: 0x000139FC
	public void method_15()
	{
		if (Class11.smethod_24(Class11.smethod_15(Class11.smethod_17(Environment.SpecialFolder.Windows), "\\Prefetch")))
		{
			Class23 @class = new Class23();
			foreach (string string_ in Class11.smethod_25(Class11.smethod_15(Class11.smethod_17(Environment.SpecialFolder.Windows), "\\Prefetch"), "*", SearchOption.AllDirectories))
			{
				try
				{
					@class.method_0(string_, 5);
				}
				catch (Exception)
				{
				}
			}
		}
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00015874 File Offset: 0x00013A74
	public void method_16()
	{
		Class10 @class = new Class10();
		try
		{
			if (Class11.smethod_21(Class11.smethod_20(Class11.smethod_1()), "cheat") == -1 && Class11.smethod_21(Class11.smethod_20(Class11.smethod_1()), "leaguemode") == -1 && Class11.smethod_21(Class11.smethod_20(Class11.smethod_1()), "hack") == -1)
			{
				if (Class11.smethod_21(Class11.smethod_20(Class11.smethod_1()), "xstrike") == -1)
				{
					if (Class11.smethod_21(Class11.smethod_20(Class11.smethod_1()), "oracle") == -1)
					{
						goto IL_AF;
					}
				}
			}
			Class11.smethod_4(@class.method_0(Class11.smethod_23("Please change the name of the folder the LEAGUEMODE Client is stored in from ", Class11.smethod_1(), " to something less suspicious.")), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Class11.smethod_6(Class11.smethod_5());
			IL_AF:;
		}
		catch (Exception)
		{
			Class11.smethod_4(@class.method_0("Unable to do startup path filename safety check due to an exception."), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	// Token: 0x0600017A RID: 378 RVA: 0x00015960 File Offset: 0x00013B60
	public void method_17()
	{
		Class10 @class = new Class10();
		try
		{
			Process process = Class11.smethod_5();
			if (Class11.smethod_21(Class11.smethod_20(Class11.smethod_29(process)), "leaguemode") != -1 || Class11.smethod_21(Class11.smethod_20(Class11.smethod_29(process)), "cheat") != -1 || Class11.smethod_21(Class11.smethod_20(Class11.smethod_29(process)), "hack") != -1 || Class11.smethod_21(Class11.smethod_20(Class11.smethod_29(process)), "xstrike") != -1 || Class11.smethod_21(Class11.smethod_20(Class11.smethod_29(process)), "oracle") != -1)
			{
				Class11.smethod_4(@class.method_0(Class11.smethod_23("Please change the LEAGUEMODE Client filename to something other than ", Class11.smethod_29(process), " for safety reasons.")), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Class11.smethod_6(Class11.smethod_5());
			}
			Class11.smethod_30(process);
			Class11.smethod_31(process);
		}
		catch (Exception)
		{
			Class11.smethod_4(@class.method_0("Unable to do process name safety check due to an exception."), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00015A60 File Offset: 0x00013C60
	public void method_18()
	{
		Class23 @class = new Class23();
		string[] array = Class11.smethod_18(Class11.smethod_15(Class11.smethod_1(), "\\"));
		if (Class11.smethod_16("C:\\settings.ini"))
		{
			@class.method_0("C:\\settings.ini", 5);
		}
		foreach (string text in array)
		{
			try
			{
				if (Class11.smethod_21(text, "-") == -1 && Class11.smethod_21(text, "_") == -1 && Class11.smethod_21(text, ".") == -1)
				{
					try
					{
						if (Class11.smethod_32(text) >= 1 && Class11.smethod_32(text) <= 32)
						{
							string string_ = text;
							@class.method_0(string_, 2);
						}
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x0600017C RID: 380 RVA: 0x00015B24 File Offset: 0x00013D24
	public void method_19()
	{
		new Class23();
		foreach (string string_ in Class11.smethod_33(Class11.smethod_1()))
		{
			try
			{
				string[] array2 = Class11.smethod_35(string_, new char[]
				{
					Class11.smethod_34("\\")
				});
				FileAttributes fileAttributes = Class11.smethod_36(string_);
				for (int j = 0; j < array2.Length; j++)
				{
					if ((Class11.smethod_32(array2[j]) >= 1 || Class11.smethod_32(array2[j]) <= 32) && Class11.smethod_21(array2[j], ".") == -1 && Class11.smethod_21(array2[j], " ") == -1 && Class11.smethod_21(array2[j], "_") == -1 && Class11.smethod_21(array2[j], "-") == -1 && Class11.smethod_37(fileAttributes, FileAttributes.Hidden) && Class11.smethod_37(fileAttributes, FileAttributes.System) && Class11.smethod_37(fileAttributes, FileAttributes.Directory) && !Class11.smethod_37(fileAttributes, FileAttributes.ReparsePoint) && !Class11.smethod_37(fileAttributes, FileAttributes.NotContentIndexed))
					{
						try
						{
							string[] array3 = Class11.smethod_18(string_);
							if (array3.Length != 0)
							{
								if (array3.Length != 1)
								{
									goto IL_159;
								}
								if (Class11.smethod_21(array3[0], ".dll") == -1)
								{
									goto IL_159;
								}
							}
							Class11.smethod_38(string_, true);
							IL_159:;
						}
						catch (Exception)
						{
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x0600017D RID: 381 RVA: 0x00015CDC File Offset: 0x00013EDC
	public void method_20()
	{
		Class10 @class = new Class10();
		try
		{
			string[] array = Class11.smethod_33(Class11.smethod_17(Environment.SpecialFolder.Desktop));
			int i = 0;
			while (i < array.Length)
			{
				string text = array[i];
				if (Class11.smethod_21(Class11.smethod_20(text), "leaguemode") != -1)
				{
					goto IL_101;
				}
				if (Class11.smethod_21(Class11.smethod_20(text), "cheat") != -1)
				{
					goto IL_101;
				}
				if (Class11.smethod_21(Class11.smethod_20(text), "hack") != -1)
				{
					goto IL_101;
				}
				if (Class11.smethod_21(Class11.smethod_20(text), "xstrike") != -1 || Class11.smethod_21(Class11.smethod_20(text), "oracle") != -1 || Class11.smethod_8(Class11.smethod_20(text), Class11.smethod_15(Class11.smethod_20(Class11.smethod_17(Environment.SpecialFolder.Desktop)), Class11.smethod_22("\\Client"))) || Class11.smethod_8(Class11.smethod_20(text), Class11.smethod_15(Class11.smethod_20(Class11.smethod_17(Environment.SpecialFolder.Desktop)), Class11.smethod_22("\\Client-slim"))) || Class11.smethod_8(Class11.smethod_20(text), Class11.smethod_15(Class11.smethod_20(Class11.smethod_17(Environment.SpecialFolder.Desktop)), Class11.smethod_22("\\Config"))))
				{
					goto IL_101;
				}
				IL_12F:
				i++;
				continue;
				IL_101:
				Class11.smethod_4(@class.method_0(Class11.smethod_23("Please delete the folder '", text, "' from your Desktop before running the client.")), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Class11.smethod_6(Class11.smethod_5());
				goto IL_12F;
			}
		}
		catch (Exception)
		{
			Class11.smethod_4(@class.method_0("Unable to do desktop directory name safety check due to an exception."), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	// Token: 0x0600017E RID: 382 RVA: 0x00015E60 File Offset: 0x00014060
	public void method_21()
	{
		try
		{
			RegistryKey registryKey_ = Class11.smethod_39(RegistryHive.CurrentUser, RegistryView.Registry64);
			Class11.smethod_40(registryKey_, "Software\\WinRAR\\ArcHistory");
			Class11.smethod_41(registryKey_);
			Class11.smethod_42(registryKey_);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600017F RID: 383 RVA: 0x00015EA8 File Offset: 0x000140A8
	public void method_22()
	{
		new Class10();
		try
		{
			string string_ = "SYSTEM\\CurrentControlSet\\services";
			RegistryKey registryKey = Class11.smethod_43(Class11.smethod_39(RegistryHive.LocalMachine, RegistryView.Registry64), string_, true);
			try
			{
				foreach (string text in Class11.smethod_44(registryKey))
				{
					RegistryKey registryKey2 = Class11.smethod_45(registryKey, text);
					try
					{
						try
						{
							if (Class11.smethod_21(Class11.smethod_47(Class11.smethod_46(registryKey2, "ImagePath")), Class11.smethod_2(Class11.smethod_1(), 0, 3)) != -1 && Class11.smethod_21(Class11.smethod_47(Class11.smethod_46(registryKey2, "ImagePath")), ".sys") != -1 && Class11.smethod_11(Class11.smethod_46(registryKey2, "Type")) == 1 && Class11.smethod_8(Class11.smethod_47(Class11.smethod_46(registryKey2, "FlowControlDisable")), "x"))
							{
								try
								{
									Class11.smethod_48(Registry.LocalMachine, Class11.smethod_15("SYSTEM\\CurrentControlSet\\services\\", text));
									ProcessStartInfo processStartInfo_ = Class11.smethod_49();
									Class11.smethod_51(processStartInfo_, Class11.smethod_50(Environment.SpecialFolder.Windows, "\\System32\\"));
									Class11.smethod_52(processStartInfo_, "sc.exe");
									Class11.smethod_53(processStartInfo_, Class11.smethod_15("delete ", text));
									Class11.smethod_54(processStartInfo_, ProcessWindowStyle.Hidden);
									Class11.smethod_55(processStartInfo_, true);
									Class11.smethod_56(processStartInfo_);
									goto IL_1ED;
								}
								catch (Exception)
								{
									goto IL_1ED;
								}
							}
							if (Class11.smethod_21(Class11.smethod_47(Class11.smethod_46(registryKey2, "ImagePath")), Class11.smethod_2(Class11.smethod_1(), 0, 3)) != -1 && Class11.smethod_21(Class11.smethod_47(Class11.smethod_46(registryKey2, "ImagePath")), ".sys") != -1 && Class11.smethod_11(Class11.smethod_46(registryKey2, "Type")) == 1)
							{
								try
								{
									Class11.smethod_48(Registry.LocalMachine, Class11.smethod_15("SYSTEM\\CurrentControlSet\\services\\", text));
									ProcessStartInfo processStartInfo_2 = Class11.smethod_49();
									Class11.smethod_51(processStartInfo_2, Class11.smethod_50(Environment.SpecialFolder.Windows, "\\System32\\"));
									Class11.smethod_52(processStartInfo_2, "sc.exe");
									Class11.smethod_53(processStartInfo_2, Class11.smethod_15("delete ", text));
									Class11.smethod_54(processStartInfo_2, ProcessWindowStyle.Hidden);
									Class11.smethod_55(processStartInfo_2, true);
									Class11.smethod_56(processStartInfo_2);
								}
								catch (Exception)
								{
								}
							}
							IL_1ED:;
						}
						catch (Exception)
						{
						}
						Class11.smethod_41(registryKey2);
						Class11.smethod_42(registryKey2);
					}
					finally
					{
						if (registryKey2 != null)
						{
							Class11.smethod_57(registryKey2);
						}
					}
				}
				Class11.smethod_41(registryKey);
				Class11.smethod_42(registryKey);
			}
			finally
			{
				if (registryKey != null)
				{
					Class11.smethod_57(registryKey);
				}
			}
		}
		catch (Exception)
		{
		}
		try
		{
			RegistryKey registryKey_ = Class11.smethod_39(RegistryHive.LocalMachine, RegistryView.Registry64);
			Class11.smethod_48(registryKey_, "SOFTWARE\\Microsoft\\DRM\\PROTECTION\\");
			Class11.smethod_41(registryKey_);
			Class11.smethod_42(registryKey_);
		}
		catch (Exception)
		{
		}
		if (Class11.smethod_58(Class13.string_12, "OSPREY"))
		{
			try
			{
				RegistryKey registryKey_2 = Class11.smethod_39(RegistryHive.LocalMachine, RegistryView.Registry64);
				Class11.smethod_48(registryKey_2, "SOFTWARE\\Microsoft\\DRM\\CUSTOMEXE\\");
				Class11.smethod_41(registryKey_2);
				Class11.smethod_42(registryKey_2);
			}
			catch (Exception)
			{
			}
			try
			{
				RegistryKey registryKey_3 = Class11.smethod_39(RegistryHive.LocalMachine, RegistryView.Registry64);
				Class11.smethod_59(Class11.smethod_43(registryKey_3, "SOFTWARE\\Microsoft\\DRM\\", true), "DLL");
				Class11.smethod_41(registryKey_3);
				Class11.smethod_42(registryKey_3);
			}
			catch (Exception)
			{
			}
			try
			{
				RegistryKey registryKey_4 = Class11.smethod_39(RegistryHive.LocalMachine, RegistryView.Registry64);
				Class11.smethod_59(Class11.smethod_43(registryKey_4, "SOFTWARE\\Microsoft\\DRM\\", true), "DELETE");
				Class11.smethod_41(registryKey_4);
				Class11.smethod_42(registryKey_4);
			}
			catch (Exception)
			{
			}
			try
			{
				RegistryKey registryKey_5 = Class11.smethod_39(RegistryHive.LocalMachine, RegistryView.Registry64);
				Class11.smethod_59(Class11.smethod_43(registryKey_5, "SOFTWARE\\Microsoft\\DRM\\", true), "DRVDEL");
				Class11.smethod_41(registryKey_5);
				Class11.smethod_42(registryKey_5);
			}
			catch (Exception)
			{
			}
		}
		try
		{
			RegistryKey registryKey_6 = Class11.smethod_39(RegistryHive.LocalMachine, RegistryView.Registry64);
			Class11.smethod_59(Class11.smethod_43(registryKey_6, "SOFTWARE\\Microsoft\\DRM\\", true), "CFG");
			Class11.smethod_41(registryKey_6);
			Class11.smethod_42(registryKey_6);
		}
		catch (Exception)
		{
		}
		try
		{
			RegistryKey registryKey_7 = Class11.smethod_39(RegistryHive.LocalMachine, RegistryView.Registry32);
			Class11.smethod_59(Class11.smethod_43(registryKey_7, "", true), "0");
			Class11.smethod_41(registryKey_7);
			Class11.smethod_42(registryKey_7);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000180 RID: 384 RVA: 0x000163A0 File Offset: 0x000145A0
	public void method_23()
	{
		Class7 @class = new Class7();
		Class10 class2 = new Class10();
		int num = 0;
		ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = Class11.smethod_62(Class11.smethod_61(Class11.smethod_60("SELECT * FROM Win32_Processor")));
		try
		{
			while (Class11.smethod_65(managementObjectEnumerator))
			{
				ManagementBaseObject managementBaseObject_ = Class11.smethod_63(managementObjectEnumerator);
				num += int.Parse(Class11.smethod_7(Class11.smethod_64(managementBaseObject_, "NumberOfCores")));
			}
		}
		finally
		{
			if (managementObjectEnumerator != null)
			{
				Class11.smethod_57(managementObjectEnumerator);
			}
		}
		if (num <= 1)
		{
			@class.method_1();
			class2.method_1("api.aspx", Class11.smethod_69(new string[]
			{
				"id=6&1=",
				Class11.smethod_66(Class13.string_2),
				"&2=",
				Class11.smethod_67(),
				"&3=",
				Class11.smethod_68(),
				"&4=LOW_CORES_POSSIBLE_VM&5=",
				Class13.string_3
			}), false);
			this.method_24();
			Class11.smethod_6(Class11.smethod_5());
		}
	}

	// Token: 0x06000181 RID: 385 RVA: 0x00016490 File Offset: 0x00014690
	public void method_24()
	{
		if (Class11.smethod_24(Class11.smethod_15(Class11.smethod_1(), "\\Config")))
		{
			Class11.smethod_38(Class11.smethod_15(Class11.smethod_1(), "\\Config"), true);
		}
		if (Class11.smethod_24(Class11.smethod_15(Class11.smethod_1(), "\\Redist")))
		{
			Class11.smethod_38(Class11.smethod_15(Class11.smethod_1(), "\\Redist"), true);
		}
		string text = Class11.smethod_71(Class11.smethod_70(Class11.smethod_5()));
		string string_ = Class11.smethod_69(new string[]
		{
			"@echo off",
			Class11.smethod_72(),
			":dele",
			Class11.smethod_72(),
			"del \"",
			text,
			"\"",
			Class11.smethod_72(),
			"if Exist \"",
			text,
			"\" GOTO dele",
			Class11.smethod_72(),
			"del %0"
		});
		string string_2 = Class11.smethod_15(Class11.smethod_73(), ".bat");
		StreamWriter textWriter_ = Class11.smethod_74(Class11.smethod_23(Class11.smethod_1(), "\\", string_2));
		Class11.smethod_75(textWriter_, string_);
		Class11.smethod_76(textWriter_);
		Class11.smethod_77(Class11.smethod_23(Class11.smethod_1(), "\\", string_2), FileAttributes.Hidden);
		Process process_ = Class11.smethod_78();
		Class11.smethod_52(Class11.smethod_79(process_), Class11.smethod_23(Class11.smethod_1(), "\\", string_2));
		Class11.smethod_55(Class11.smethod_79(process_), true);
		Class11.smethod_54(Class11.smethod_79(process_), ProcessWindowStyle.Hidden);
		Class11.smethod_80(Class11.smethod_79(process_), true);
		Class11.smethod_81(process_);
		Class11.smethod_82(process_, ProcessPriorityClass.AboveNormal);
	}

	// Token: 0x06000182 RID: 386 RVA: 0x00016610 File Offset: 0x00014810
	public string method_25()
	{
		ManagementObjectSearcher managementObjectSearcher = Class11.smethod_60("SELECT * FROM Win32_ComputerSystem");
		try
		{
			ManagementObjectCollection managementObjectCollection = Class11.smethod_83(managementObjectSearcher);
			try
			{
				ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = Class11.smethod_62(managementObjectCollection);
				try
				{
					while (Class11.smethod_65(managementObjectEnumerator))
					{
						ManagementBaseObject managementBaseObject_ = Class11.smethod_63(managementObjectEnumerator);
						string text = Class11.smethod_20(Class11.smethod_7(Class11.smethod_64(managementBaseObject_, "Manufacturer")));
						string string_ = Class11.smethod_7(Class11.smethod_64(managementBaseObject_, "Model"));
						if ((Class11.smethod_8(text, "microsoft corporation") && Class11.smethod_26(Class11.smethod_84(string_), "VIRTUAL")) || Class11.smethod_26(text, "vmware") || Class11.smethod_26(text, "qemu") || Class11.smethod_26(text, "vbox") || Class11.smethod_26(text, "red hat") || Class11.smethod_26(text, "innotek gmbh") || Class11.smethod_26(Class11.smethod_20(string_), "qemu") || Class11.smethod_26(Class11.smethod_20(string_), "vbox") || Class11.smethod_26(Class11.smethod_20(string_), "vmware") || Class11.smethod_26(Class11.smethod_20(string_), "innotek gmbh") || Class11.smethod_26(Class11.smethod_20(string_), "red hat") || Class11.smethod_8(Class11.smethod_20(string_), Class11.smethod_22("Virtual Machine")) || Class11.smethod_8(Class11.smethod_20(string_), Class11.smethod_22("VMware Virtual Platform")) || Class11.smethod_8(Class11.smethod_20(string_), Class11.smethod_22("KVM")) || Class11.smethod_8(Class11.smethod_20(string_), Class11.smethod_22("VirtualBox")))
						{
							return Class11.smethod_23(string_, "_", text);
						}
						PropertyData propertyData = Class11.smethod_85(managementBaseObject_).OfType<PropertyData>().FirstOrDefault(new Func<PropertyData, bool>(Class11.Class12.<>9.method_0));
						bool? flag = (bool?)((propertyData != null) ? Class11.smethod_86(propertyData) : null);
						if (flag.GetValueOrDefault() & flag != null)
						{
							return "HypervisorPresent";
						}
					}
				}
				finally
				{
					if (managementObjectEnumerator != null)
					{
						Class11.smethod_57(managementObjectEnumerator);
					}
				}
			}
			finally
			{
				if (managementObjectCollection != null)
				{
					Class11.smethod_57(managementObjectCollection);
				}
			}
		}
		finally
		{
			if (managementObjectSearcher != null)
			{
				Class11.smethod_57(managementObjectSearcher);
			}
		}
		return string.Empty;
	}

	// Token: 0x06000183 RID: 387 RVA: 0x000168A8 File Offset: 0x00014AA8
	public void method_26()
	{
		try
		{
			Process[] array = Class11.smethod_87();
			bool flag = false;
			foreach (Process process in array)
			{
				if (Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("Steam")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("csgo")) || Class11.smethod_26(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("GCLauncher")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("ChallengeMeClient")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("GameOverlayUI")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("steamwebhelper")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("SteamService")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("EasyAntiCheat")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("eseaclient")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("wire")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("CEVOClient")) || Class11.smethod_26(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("CelavimusClientHelper")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("GfinityClient")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("B5AntiCheat")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("B5esportsMain")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("aac")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("LeagueAntiCheat")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("cgac")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("faceitclient")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("FACEIT")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("5EClient")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("SoStronk")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("RAC")) || Class11.smethod_26(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("esportal")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("WireHelperSvc")) || Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("GamersClub-AC")))
				{
					Class11.smethod_6(process);
					flag = true;
					if (Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("EasyAntiCheat")))
					{
						goto IL_47C;
					}
					if (Class11.smethod_8(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("WireHelperSvc")))
					{
						try
						{
							ServiceController serviceController = Class11.smethod_88("ESLWireAC");
							if (Class11.smethod_89(serviceController) == ServiceControllerStatus.Running)
							{
								Class11.smethod_90(serviceController);
							}
							Class11.smethod_91(serviceController);
							Class11.smethod_31(serviceController);
							goto IL_4B2;
						}
						catch (Exception)
						{
							goto IL_4B2;
						}
					}
					if (Class11.smethod_26(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("GCLauncher")))
					{
						try
						{
							ServiceController serviceController2 = Class11.smethod_88("GCService");
							if (Class11.smethod_89(serviceController2) == ServiceControllerStatus.Running)
							{
								Class11.smethod_90(serviceController2);
							}
							Class11.smethod_91(serviceController2);
							Class11.smethod_31(serviceController2);
							goto IL_4B2;
						}
						catch (Exception)
						{
							goto IL_4B2;
						}
					}
					if (Class11.smethod_26(Class11.smethod_20(Class11.smethod_29(process)), Class11.smethod_22("SoStronk")))
					{
						try
						{
							ServiceController serviceController3 = Class11.smethod_88("SoStronkOdinService");
							if (Class11.smethod_89(serviceController3) == ServiceControllerStatus.Running)
							{
								Class11.smethod_90(serviceController3);
							}
							Class11.smethod_91(serviceController3);
							Class11.smethod_31(serviceController3);
						}
						catch (Exception)
						{
						}
						try
						{
							ServiceController serviceController4 = Class11.smethod_88("SoStronkOdinDriver");
							if (Class11.smethod_89(serviceController4) == ServiceControllerStatus.Running)
							{
								Class11.smethod_90(serviceController4);
							}
							Class11.smethod_91(serviceController4);
							Class11.smethod_31(serviceController4);
							goto IL_4B2;
						}
						catch (Exception)
						{
							goto IL_4B2;
						}
						goto IL_47C;
					}
					IL_4B2:
					Class11.smethod_30(process);
					Class11.smethod_31(process);
					goto IL_4A9;
					IL_47C:
					ServiceController serviceController5 = Class11.smethod_88("EasyAntiCheatSys");
					if (Class11.smethod_89(serviceController5) == ServiceControllerStatus.Running)
					{
						Class11.smethod_90(serviceController5);
					}
					Class11.smethod_91(serviceController5);
					Class11.smethod_31(serviceController5);
					goto IL_4B2;
				}
				IL_4A9:;
			}
			Class10 @class = new Class10();
			if (flag)
			{
				Class11.smethod_4(@class.method_0("Please ensure Steam and all game processes or anti-cheat software are closed before loading the client."), Class8.smethod_0(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000185 RID: 389 RVA: 0x000029CD File Offset: 0x00000BCD
	static StringBuilder smethod_0(int int_0)
	{
		return new StringBuilder(int_0);
	}

	// Token: 0x06000186 RID: 390 RVA: 0x0000288B File Offset: 0x00000A8B
	static string smethod_1()
	{
		return Application.StartupPath;
	}

	// Token: 0x06000187 RID: 391 RVA: 0x0000281D File Offset: 0x00000A1D
	static string smethod_2(string string_0, int int_0, int int_1)
	{
		return string_0.Substring(int_0, int_1);
	}

	// Token: 0x06000188 RID: 392 RVA: 0x000029D5 File Offset: 0x00000BD5
	static int smethod_3(StringBuilder stringBuilder_0)
	{
		return stringBuilder_0.Capacity;
	}

	// Token: 0x06000189 RID: 393 RVA: 0x000026B1 File Offset: 0x000008B1
	static DialogResult smethod_4(string string_0, string string_1, MessageBoxButtons messageBoxButtons_0, MessageBoxIcon messageBoxIcon_0)
	{
		return MessageBox.Show(string_0, string_1, messageBoxButtons_0, messageBoxIcon_0);
	}

	// Token: 0x0600018A RID: 394 RVA: 0x000026C3 File Offset: 0x000008C3
	static Process smethod_5()
	{
		return Process.GetCurrentProcess();
	}

	// Token: 0x0600018B RID: 395 RVA: 0x000026CA File Offset: 0x000008CA
	static void smethod_6(Process process_0)
	{
		process_0.Kill();
	}

	// Token: 0x0600018C RID: 396 RVA: 0x0000260D File Offset: 0x0000080D
	static string smethod_7(object object_0)
	{
		return object_0.ToString();
	}

	// Token: 0x0600018D RID: 397 RVA: 0x00002758 File Offset: 0x00000958
	static bool smethod_8(string string_0, string string_1)
	{
		return string_0 == string_1;
	}

	// Token: 0x0600018E RID: 398 RVA: 0x000029DD File Offset: 0x00000BDD
	static StringBuilder smethod_9(StringBuilder stringBuilder_0)
	{
		return stringBuilder_0.Clear();
	}

	// Token: 0x0600018F RID: 399 RVA: 0x00002BB0 File Offset: 0x00000DB0
	static object smethod_10(string string_0, string string_1, object object_0)
	{
		return Registry.GetValue(string_0, string_1, object_0);
	}

	// Token: 0x06000190 RID: 400 RVA: 0x000026FE File Offset: 0x000008FE
	static int smethod_11(object object_0)
	{
		return Convert.ToInt32(object_0);
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00002BBA File Offset: 0x00000DBA
	static void smethod_12(string string_0, string string_1, object object_0)
	{
		Registry.SetValue(string_0, string_1, object_0);
	}

	// Token: 0x06000192 RID: 402 RVA: 0x00002271 File Offset: 0x00000471
	static void smethod_13(int int_0)
	{
		Thread.Sleep(int_0);
	}

	// Token: 0x06000193 RID: 403 RVA: 0x000029A3 File Offset: 0x00000BA3
	static Process smethod_14(string string_0, string string_1)
	{
		return Process.Start(string_0, string_1);
	}

	// Token: 0x06000194 RID: 404 RVA: 0x0000222C File Offset: 0x0000042C
	static string smethod_15(string string_0, string string_1)
	{
		return string_0 + string_1;
	}

	// Token: 0x06000195 RID: 405 RVA: 0x0000284F File Offset: 0x00000A4F
	static bool smethod_16(string string_0)
	{
		return File.Exists(string_0);
	}

	// Token: 0x06000196 RID: 406 RVA: 0x00002993 File Offset: 0x00000B93
	static string smethod_17(Environment.SpecialFolder specialFolder_0)
	{
		return Environment.GetFolderPath(specialFolder_0);
	}

	// Token: 0x06000197 RID: 407 RVA: 0x0000282E File Offset: 0x00000A2E
	static string[] smethod_18(string string_0)
	{
		return Directory.GetFiles(string_0);
	}

	// Token: 0x06000198 RID: 408 RVA: 0x00002BC4 File Offset: 0x00000DC4
	static string smethod_19(string string_0)
	{
		return Path.GetFileNameWithoutExtension(string_0);
	}

	// Token: 0x06000199 RID: 409 RVA: 0x00002647 File Offset: 0x00000847
	static string smethod_20(string string_0)
	{
		return string_0.ToLower();
	}

	// Token: 0x0600019A RID: 410 RVA: 0x00002686 File Offset: 0x00000886
	static int smethod_21(string string_0, string string_1)
	{
		return string_0.IndexOf(string_1);
	}

	// Token: 0x0600019B RID: 411 RVA: 0x0000293C File Offset: 0x00000B3C
	static string smethod_22(string string_0)
	{
		return string_0.ToLower();
	}

	// Token: 0x0600019C RID: 412 RVA: 0x000026A7 File Offset: 0x000008A7
	static string smethod_23(string string_0, string string_1, string string_2)
	{
		return string_0 + string_1 + string_2;
	}

	// Token: 0x0600019D RID: 413 RVA: 0x00002857 File Offset: 0x00000A57
	static bool smethod_24(string string_0)
	{
		return Directory.Exists(string_0);
	}

	// Token: 0x0600019E RID: 414 RVA: 0x00002BCC File Offset: 0x00000DCC
	static string[] smethod_25(string string_0, string string_1, SearchOption searchOption_0)
	{
		return Directory.GetFiles(string_0, string_1, searchOption_0);
	}

	// Token: 0x0600019F RID: 415 RVA: 0x00002836 File Offset: 0x00000A36
	static bool smethod_26(string string_0, string string_1)
	{
		return string_0.Contains(string_1);
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x00002BD6 File Offset: 0x00000DD6
	static void smethod_27()
	{
		Clipboard.Clear();
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x00002827 File Offset: 0x00000A27
	static string smethod_28()
	{
		return Path.GetTempPath();
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x00002915 File Offset: 0x00000B15
	static string smethod_29(Process process_0)
	{
		return process_0.ProcessName;
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x000028DE File Offset: 0x00000ADE
	static void smethod_30(Process process_0)
	{
		process_0.Close();
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x000028E6 File Offset: 0x00000AE6
	static void smethod_31(Component component_0)
	{
		component_0.Dispose();
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x000025FC File Offset: 0x000007FC
	static int smethod_32(string string_0)
	{
		return string_0.Length;
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x00002BDD File Offset: 0x00000DDD
	static string[] smethod_33(string string_0)
	{
		return Directory.GetDirectories(string_0);
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x00002B89 File Offset: 0x00000D89
	static char smethod_34(string string_0)
	{
		return Convert.ToChar(string_0);
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x00002B91 File Offset: 0x00000D91
	static string[] smethod_35(string string_0, char[] char_0)
	{
		return string_0.Split(char_0);
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x00002BE5 File Offset: 0x00000DE5
	static FileAttributes smethod_36(string string_0)
	{
		return File.GetAttributes(string_0);
	}

	// Token: 0x060001AA RID: 426 RVA: 0x00002BED File Offset: 0x00000DED
	static bool smethod_37(Enum enum_0, Enum enum_1)
	{
		return enum_0.HasFlag(enum_1);
	}

	// Token: 0x060001AB RID: 427 RVA: 0x0000289D File Offset: 0x00000A9D
	static void smethod_38(string string_0, bool bool_0)
	{
		Directory.Delete(string_0, bool_0);
	}

	// Token: 0x060001AC RID: 428 RVA: 0x000026E2 File Offset: 0x000008E2
	static RegistryKey smethod_39(RegistryHive registryHive_0, RegistryView registryView_0)
	{
		return RegistryKey.OpenBaseKey(registryHive_0, registryView_0);
	}

	// Token: 0x060001AD RID: 429 RVA: 0x00002BF6 File Offset: 0x00000DF6
	static void smethod_40(RegistryKey registryKey_0, string string_0)
	{
		registryKey_0.DeleteSubKey(string_0);
	}

	// Token: 0x060001AE RID: 430 RVA: 0x00002711 File Offset: 0x00000911
	static void smethod_41(RegistryKey registryKey_0)
	{
		registryKey_0.Close();
	}

	// Token: 0x060001AF RID: 431 RVA: 0x00002719 File Offset: 0x00000919
	static void smethod_42(RegistryKey registryKey_0)
	{
		registryKey_0.Dispose();
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x000026EB File Offset: 0x000008EB
	static RegistryKey smethod_43(RegistryKey registryKey_0, string string_0, bool bool_0)
	{
		return registryKey_0.OpenSubKey(string_0, bool_0);
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x0000272A File Offset: 0x0000092A
	static string[] smethod_44(RegistryKey registryKey_0)
	{
		return registryKey_0.GetSubKeyNames();
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00002721 File Offset: 0x00000921
	static RegistryKey smethod_45(RegistryKey registryKey_0, string string_0)
	{
		return registryKey_0.OpenSubKey(string_0);
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x000026F5 File Offset: 0x000008F5
	static object smethod_46(RegistryKey registryKey_0, string string_0)
	{
		return registryKey_0.GetValue(string_0);
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x00002732 File Offset: 0x00000932
	static string smethod_47(object object_0)
	{
		return Convert.ToString(object_0);
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x00002BFF File Offset: 0x00000DFF
	static void smethod_48(RegistryKey registryKey_0, string string_0)
	{
		registryKey_0.DeleteSubKeyTree(string_0);
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x00002C08 File Offset: 0x00000E08
	static ProcessStartInfo smethod_49()
	{
		return new ProcessStartInfo();
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00002C0F File Offset: 0x00000E0F
	static string smethod_50(object object_0, object object_1)
	{
		return object_0 + object_1;
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x00002C18 File Offset: 0x00000E18
	static void smethod_51(ProcessStartInfo processStartInfo_0, string string_0)
	{
		processStartInfo_0.WorkingDirectory = string_0;
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x00002C21 File Offset: 0x00000E21
	static void smethod_52(ProcessStartInfo processStartInfo_0, string string_0)
	{
		processStartInfo_0.FileName = string_0;
	}

	// Token: 0x060001BA RID: 442 RVA: 0x00002C2A File Offset: 0x00000E2A
	static void smethod_53(ProcessStartInfo processStartInfo_0, string string_0)
	{
		processStartInfo_0.Arguments = string_0;
	}

	// Token: 0x060001BB RID: 443 RVA: 0x00002C33 File Offset: 0x00000E33
	static void smethod_54(ProcessStartInfo processStartInfo_0, ProcessWindowStyle processWindowStyle_0)
	{
		processStartInfo_0.WindowStyle = processWindowStyle_0;
	}

	// Token: 0x060001BC RID: 444 RVA: 0x00002879 File Offset: 0x00000A79
	static void smethod_55(ProcessStartInfo processStartInfo_0, bool bool_0)
	{
		processStartInfo_0.CreateNoWindow = bool_0;
	}

	// Token: 0x060001BD RID: 445 RVA: 0x000028A6 File Offset: 0x00000AA6
	static Process smethod_56(ProcessStartInfo processStartInfo_0)
	{
		return Process.Start(processStartInfo_0);
	}

	// Token: 0x060001BE RID: 446 RVA: 0x00002697 File Offset: 0x00000897
	static void smethod_57(IDisposable idisposable_0)
	{
		idisposable_0.Dispose();
	}

	// Token: 0x060001BF RID: 447 RVA: 0x00002867 File Offset: 0x00000A67
	static bool smethod_58(string string_0, string string_1)
	{
		return string_0 != string_1;
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x00002C3C File Offset: 0x00000E3C
	static void smethod_59(RegistryKey registryKey_0, string string_0)
	{
		registryKey_0.DeleteValue(string_0);
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x0000265D File Offset: 0x0000085D
	static ManagementObjectSearcher smethod_60(string string_0)
	{
		return new ManagementObjectSearcher(string_0);
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x00002C45 File Offset: 0x00000E45
	static ManagementObjectCollection smethod_61(ManagementObjectSearcher managementObjectSearcher_0)
	{
		return managementObjectSearcher_0.Get();
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x0000266D File Offset: 0x0000086D
	static ManagementObjectCollection.ManagementObjectEnumerator smethod_62(ManagementObjectCollection managementObjectCollection_0)
	{
		return managementObjectCollection_0.GetEnumerator();
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x00002675 File Offset: 0x00000875
	static ManagementBaseObject smethod_63(ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator_0)
	{
		return managementObjectEnumerator_0.Current;
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x0000267D File Offset: 0x0000087D
	static object smethod_64(ManagementBaseObject managementBaseObject_0, string string_0)
	{
		return managementBaseObject_0[string_0];
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x0000268F File Offset: 0x0000088F
	static bool smethod_65(ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator_0)
	{
		return managementObjectEnumerator_0.MoveNext();
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x0000273A File Offset: 0x0000093A
	static string smethod_66(string string_0)
	{
		return string_0.Trim();
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x00002742 File Offset: 0x00000942
	static string smethod_67()
	{
		return Environment.UserName;
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x00002749 File Offset: 0x00000949
	static string smethod_68()
	{
		return Environment.MachineName;
	}

	// Token: 0x060001CA RID: 458 RVA: 0x00002750 File Offset: 0x00000950
	static string smethod_69(string[] string_0)
	{
		return string.Concat(string_0);
	}

	// Token: 0x060001CB RID: 459 RVA: 0x000028CE File Offset: 0x00000ACE
	static ProcessModule smethod_70(Process process_0)
	{
		return process_0.MainModule;
	}

	// Token: 0x060001CC RID: 460 RVA: 0x00002C4D File Offset: 0x00000E4D
	static string smethod_71(ProcessModule processModule_0)
	{
		return processModule_0.FileName;
	}

	// Token: 0x060001CD RID: 461 RVA: 0x00002C55 File Offset: 0x00000E55
	static string smethod_72()
	{
		return Environment.NewLine;
	}

	// Token: 0x060001CE RID: 462 RVA: 0x00002C5C File Offset: 0x00000E5C
	static string smethod_73()
	{
		return Path.GetRandomFileName();
	}

	// Token: 0x060001CF RID: 463 RVA: 0x00002C63 File Offset: 0x00000E63
	static StreamWriter smethod_74(string string_0)
	{
		return new StreamWriter(string_0);
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x00002C6B File Offset: 0x00000E6B
	static void smethod_75(TextWriter textWriter_0, string string_0)
	{
		textWriter_0.Write(string_0);
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x00002C74 File Offset: 0x00000E74
	static void smethod_76(TextWriter textWriter_0)
	{
		textWriter_0.Close();
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x00002C7C File Offset: 0x00000E7C
	static void smethod_77(string string_0, FileAttributes fileAttributes_0)
	{
		File.SetAttributes(string_0, fileAttributes_0);
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x00002C85 File Offset: 0x00000E85
	static Process smethod_78()
	{
		return new Process();
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x00002C8C File Offset: 0x00000E8C
	static ProcessStartInfo smethod_79(Process process_0)
	{
		return process_0.StartInfo;
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x00002882 File Offset: 0x00000A82
	static void smethod_80(ProcessStartInfo processStartInfo_0, bool bool_0)
	{
		processStartInfo_0.UseShellExecute = bool_0;
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x00002C94 File Offset: 0x00000E94
	static bool smethod_81(Process process_0)
	{
		return process_0.Start();
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x00002C9C File Offset: 0x00000E9C
	static void smethod_82(Process process_0, ProcessPriorityClass processPriorityClass_0)
	{
		process_0.PriorityClass = processPriorityClass_0;
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x00002665 File Offset: 0x00000865
	static ManagementObjectCollection smethod_83(ManagementObjectSearcher managementObjectSearcher_0)
	{
		return managementObjectSearcher_0.Get();
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x00002CA5 File Offset: 0x00000EA5
	static string smethod_84(string string_0)
	{
		return string_0.ToUpperInvariant();
	}

	// Token: 0x060001DA RID: 474 RVA: 0x00002CAD File Offset: 0x00000EAD
	static PropertyDataCollection smethod_85(ManagementBaseObject managementBaseObject_0)
	{
		return managementBaseObject_0.Properties;
	}

	// Token: 0x060001DB RID: 475 RVA: 0x00002CB5 File Offset: 0x00000EB5
	static object smethod_86(PropertyData propertyData_0)
	{
		return propertyData_0.Value;
	}

	// Token: 0x060001DC RID: 476 RVA: 0x000028EE File Offset: 0x00000AEE
	static Process[] smethod_87()
	{
		return Process.GetProcesses();
	}

	// Token: 0x060001DD RID: 477 RVA: 0x000029AC File Offset: 0x00000BAC
	static ServiceController smethod_88(string string_0)
	{
		return new ServiceController(string_0);
	}

	// Token: 0x060001DE RID: 478 RVA: 0x000029B4 File Offset: 0x00000BB4
	static ServiceControllerStatus smethod_89(ServiceController serviceController_0)
	{
		return serviceController_0.Status;
	}

	// Token: 0x060001DF RID: 479 RVA: 0x00002CBD File Offset: 0x00000EBD
	static void smethod_90(ServiceController serviceController_0)
	{
		serviceController_0.Stop();
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x00002CC5 File Offset: 0x00000EC5
	static void smethod_91(ServiceController serviceController_0)
	{
		serviceController_0.Close();
	}

	// Token: 0x040001AF RID: 431
	public static uint uint_0;

	// Token: 0x0200001A RID: 26
	private enum Enum3 : uint
	{
		// Token: 0x040001B1 RID: 433
		SHRB_NOCONFIRMATION = 1u,
		// Token: 0x040001B2 RID: 434
		SHRB_NOPROGRESSUI,
		// Token: 0x040001B3 RID: 435
		SHRB_NOSOUND = 4u
	}

	// Token: 0x0200001B RID: 27
	[CompilerGenerated]
	[Serializable]
	private sealed class Class12
	{
		// Token: 0x060001E3 RID: 483 RVA: 0x00002CD9 File Offset: 0x00000ED9
		internal bool method_0(PropertyData propertyData_0)
		{
			return Class11.Class12.smethod_1(Class11.Class12.smethod_0(propertyData_0), "HypervisorPresent");
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00002CEB File Offset: 0x00000EEB
		static string smethod_0(PropertyData propertyData_0)
		{
			return propertyData_0.Name;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00002758 File Offset: 0x00000958
		static bool smethod_1(string string_0, string string_1)
		{
			return string_0 == string_1;
		}

		// Token: 0x040001B4 RID: 436
		public static readonly Class11.Class12 <>9 = new Class11.Class12();

		// Token: 0x040001B5 RID: 437
		public static Func<PropertyData, bool> <>9__29_0;
	}
}
