using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Discord_Raider_By_Stanley.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.6.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)(object)SettingsBase.Synchronized((SettingsBase)(object)new Settings());

		public static Settings Default => defaultInstance;

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("null")]
		public string Token
		{
			get
			{
				return (string)((SettingsBase)this).get_Item("Token");
			}
			set
			{
				((SettingsBase)this).set_Item("Token", (object)value);
			}
		}

		public Settings()
			: this()
		{
		}
	}
}
