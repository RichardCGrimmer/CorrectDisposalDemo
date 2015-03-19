using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectDisposalDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleKeyInfo s = Console.ReadKey();
			do
			{
				switch (s.Key)
				{
					case ConsoleKey.B:
						UseBaseLogger();
						break;
					case ConsoleKey.N:
						UseNonDisposedLogger();
						break;
					case ConsoleKey.D:
						UseDisposedLogger();
						break;
					case ConsoleKey.O:
						LeakNonDisposedLogger();
						break;
					case ConsoleKey.P:
						LeakDisposedLogger();
						break;
				}

				// Log Memory usage...
				var currentProcess = Process.GetCurrentProcess();
				string message = string.Format("Current Memory Usage: {0}", currentProcess.WorkingSet64);
				Console.WriteLine(message);

				s = Console.ReadKey();

			} while (s.Key != ConsoleKey.Q);
		}

		private static void LeakNonDisposedLogger()
		{
			var logger = new NonDisposedLogger();
			logger.Log("Dropped out of scope");
		}

		private static void LeakDisposedLogger()
		{
			var logger = new DisposedLogger();
			logger.Log("Dropped out of scope");
		}

		private static void UseDisposedLogger()
		{
			using (DisposedLogger dLogger = new DisposedLogger())
			{
				dLogger.Log("Disposed Logger");
			}
		}

		private static void UseNonDisposedLogger()
		{
			using (NonDisposedLogger ndLogger = new NonDisposedLogger())
			{
				ndLogger.Log("Non Disposed Logger");
			}
		}

		private static void UseBaseLogger()
		{
			// Not disposed of in any way - underlying StreamWriter remains open and so the next call fails since it is holding it despite having dropped out of scope...
			var logger = new BaseLogger();
			logger.Log("Base Logger");
		}
	}
}
