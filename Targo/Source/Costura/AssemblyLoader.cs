using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura
{
	[CompilerGenerated]
	internal static class AssemblyLoader
	{
		private static readonly object nullCacheLock = new object();

		private static readonly Dictionary<string, bool> nullCache = new Dictionary<string, bool>();

		private static readonly Dictionary<string, string> assemblyNames = new Dictionary<string, string>();

		private static readonly Dictionary<string, string> symbolNames = new Dictionary<string, string>();

		private static int isAttached = 0;

		private static string CultureToString(CultureInfo culture)
		{
			if (culture == null)
			{
				return "";
			}
			return culture.Name;
		}

		private static Assembly ReadExistingAssembly(AssemblyName name)
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				AssemblyName name2 = assembly.GetName();
				if (string.Equals(name2.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(CultureToString(name2.CultureInfo), CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		private static void CopyTo(Stream source, Stream destination)
		{
			byte[] array = new byte[81920];
			int count;
			while ((count = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, count);
			}
		}

		private static Stream LoadStream(string fullname)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (fullname.EndsWith(".compressed"))
			{
				using (Stream stream = executingAssembly.GetManifestResourceStream(fullname))
				{
					DeflateStream val = (DeflateStream)(object)new DeflateStream(stream, (CompressionMode)0);
					try
					{
						MemoryStream memoryStream = new MemoryStream();
						CopyTo((Stream)(object)val, memoryStream);
						memoryStream.Position = 0L;
						return memoryStream;
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
				}
			}
			return executingAssembly.GetManifestResourceStream(fullname);
		}

		private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
		{
			if (resourceNames.TryGetValue(name, out string value))
			{
				return LoadStream(value);
			}
			return null;
		}

		private static byte[] ReadStream(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		private static Assembly ReadFromEmbeddedResources(Dictionary<string, string> assemblyNames, Dictionary<string, string> symbolNames, AssemblyName requestedAssemblyName)
		{
			string text = requestedAssemblyName.Name!.ToLowerInvariant();
			if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo!.Name))
			{
				text = $"{requestedAssemblyName.CultureInfo!.Name}.{text}";
			}
			byte[] rawAssembly;
			using (Stream stream = LoadStream(assemblyNames, text))
			{
				if (stream == null)
				{
					return null;
				}
				rawAssembly = ReadStream(stream);
			}
			using (Stream stream2 = LoadStream(symbolNames, text))
			{
				if (stream2 != null)
				{
					byte[] rawSymbolStore = ReadStream(stream2);
					return Assembly.Load(rawAssembly, rawSymbolStore);
				}
			}
			return Assembly.Load(rawAssembly);
		}

		public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			lock (nullCacheLock)
			{
				if (nullCache.ContainsKey(e.Name))
				{
					return null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(e.Name);
			Assembly assembly = ReadExistingAssembly(assemblyName);
			if ((object)assembly != null)
			{
				return assembly;
			}
			assembly = ReadFromEmbeddedResources(assemblyNames, symbolNames, assemblyName);
			if ((object)assembly == null)
			{
				lock (nullCacheLock)
				{
					nullCache[e.Name] = true;
				}
				if (assemblyName.Flags == AssemblyNameFlags.Retargetable)
				{
					assembly = Assembly.Load(assemblyName);
				}
			}
			return assembly;
		}

		static AssemblyLoader()
		{
			assemblyNames.Add("discord.net.commands", "costura.discord.net.commands.dll.compressed");
			assemblyNames.Add("discord.net.core", "costura.discord.net.core.dll.compressed");
			assemblyNames.Add("discord.net.rest", "costura.discord.net.rest.dll.compressed");
			assemblyNames.Add("discord.net.rpc", "costura.discord.net.rpc.dll.compressed");
			assemblyNames.Add("discord.net.webhook", "costura.discord.net.webhook.dll.compressed");
			assemblyNames.Add("discord.net.websocket", "costura.discord.net.websocket.dll.compressed");
			assemblyNames.Add("microsoft.extensions.dependencyinjection.abstractions", "costura.microsoft.extensions.dependencyinjection.abstractions.dll.compressed");
			assemblyNames.Add("microsoft.extensions.dependencyinjection", "costura.microsoft.extensions.dependencyinjection.dll.compressed");
			assemblyNames.Add("microsoft.win32.primitives", "costura.microsoft.win32.primitives.dll.compressed");
			assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
			assemblyNames.Add("system.appcontext", "costura.system.appcontext.dll.compressed");
			assemblyNames.Add("system.collections.immutable", "costura.system.collections.immutable.dll.compressed");
			assemblyNames.Add("system.console", "costura.system.console.dll.compressed");
			assemblyNames.Add("system.diagnostics.diagnosticsource", "costura.system.diagnostics.diagnosticsource.dll.compressed");
			assemblyNames.Add("system.globalization.calendars", "costura.system.globalization.calendars.dll.compressed");
			assemblyNames.Add("system.interactive.async", "costura.system.interactive.async.dll.compressed");
			assemblyNames.Add("system.io.compression", "costura.system.io.compression.dll.compressed");
			assemblyNames.Add("system.io.compression.zipfile", "costura.system.io.compression.zipfile.dll.compressed");
			assemblyNames.Add("system.io.filesystem", "costura.system.io.filesystem.dll.compressed");
			assemblyNames.Add("system.io.filesystem.primitives", "costura.system.io.filesystem.primitives.dll.compressed");
			assemblyNames.Add("system.net.http", "costura.system.net.http.dll.compressed");
			assemblyNames.Add("system.net.sockets", "costura.system.net.sockets.dll.compressed");
			assemblyNames.Add("system.runtime.interopservices.runtimeinformation", "costura.system.runtime.interopservices.runtimeinformation.dll.compressed");
			assemblyNames.Add("system.security.cryptography.algorithms", "costura.system.security.cryptography.algorithms.dll.compressed");
			assemblyNames.Add("system.security.cryptography.encoding", "costura.system.security.cryptography.encoding.dll.compressed");
			assemblyNames.Add("system.security.cryptography.primitives", "costura.system.security.cryptography.primitives.dll.compressed");
			assemblyNames.Add("system.security.cryptography.x509certificates", "costura.system.security.cryptography.x509certificates.dll.compressed");
			assemblyNames.Add("system.xml.readerwriter", "costura.system.xml.readerwriter.dll.compressed");
		}

		public static void Attach()
		{
			if (Interlocked.Exchange(ref isAttached, 1) == 1)
			{
				return;
			}
			AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs e)
			{
				lock (nullCacheLock)
				{
					if (nullCache.ContainsKey(e.Name))
					{
						return null;
					}
				}
				AssemblyName assemblyName = new AssemblyName(e.Name);
				Assembly assembly = ReadExistingAssembly(assemblyName);
				if ((object)assembly != null)
				{
					return assembly;
				}
				assembly = ReadFromEmbeddedResources(assemblyNames, symbolNames, assemblyName);
				if ((object)assembly == null)
				{
					lock (nullCacheLock)
					{
						nullCache[e.Name] = true;
					}
					if (assemblyName.Flags == AssemblyNameFlags.Retargetable)
					{
						assembly = Assembly.Load(assemblyName);
					}
				}
				return assembly;
			};
		}
	}
}
