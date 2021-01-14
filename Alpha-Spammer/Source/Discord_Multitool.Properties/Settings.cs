using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Discord_Multitool.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)(object)SettingsBase.Synchronized((SettingsBase)(object)new Settings());

		public static Settings Default => defaultInstance;

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Code
		{
			get
			{
				return (string)((SettingsBase)this).get_Item("Code");
			}
			set
			{
				((SettingsBase)this).set_Item("Code", (object)value);
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		public bool Authorised
		{
			get
			{
				try
				{
					return (bool)((SettingsBase)this).get_Item("Authorised");
				}
				catch
				{
					((SettingsBase)this).set_Item("Authorised", (object)false);
					return (bool)((SettingsBase)this).get_Item("Authorised");
				}
			}
			set
			{
				((SettingsBase)this).set_Item("Authorised", (object)value);
			}
		}

		public Settings()
			: this()
		{
		}

		private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
		{
		}

		private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
		{
		}
	}
}
