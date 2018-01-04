using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using log4net;

namespace EntityComponentModel {
	internal static class NativeMethods {
		[DllImport("kernel32.dll")]
		internal static extern Boolean AllocConsole();
	}

	public static class Log {
		static ILog log;
		static Log() {
			NativeMethods.AllocConsole();
			log4net.Layout.PatternLayout pl = new log4net.Layout.PatternLayout("[MySite] %level %date{HH:mm:ss,fff} - %message%n");
			log4net.Appender.ConsoleAppender ca = new log4net.Appender.ConsoleAppender();
			ca.Layout = pl;
			ca.Target = "Console.Out";
			ca.ActivateOptions();
			log4net.Config.BasicConfigurator.Configure(ca);
			log = LogManager.GetLogger("Debug");
		}

		/// <summary>
		/// Display message according to the requested logging level.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="level">0 - Info, 1 - Debug, 2 - Warn, 3 - Error</param>
		public static void LogLevel(string message, int level = 0) {
			switch (level) {
				case 1:
					log.Debug(message);
					break;
				case 2:
					log.Warn(message);
					break;
				case 3:
					log.Error(message);
					break;
				default:
					log.Info(message);
					break;
			}
		}
	}

}
