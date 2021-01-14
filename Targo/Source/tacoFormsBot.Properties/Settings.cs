using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace tacoFormsBot.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.1.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)(object)SettingsBase.Synchronized((SettingsBase)(object)new Settings());

		public static Settings Default => defaultInstance;

		[DebuggerNonUserCode]
		[UserScopedSetting]
		[DefaultSettingValue("False")]
		public bool isConnected
		{
			get
			{
				return (bool)((SettingsBase)this).get_Item("isConnected");
			}
			set
			{
				((SettingsBase)this).set_Item("isConnected", (object)value);
			}
		}

		public Settings()
			: this()
		{
		}
	}
}
