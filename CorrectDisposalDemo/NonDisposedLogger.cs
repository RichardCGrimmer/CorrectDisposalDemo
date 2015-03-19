namespace CorrectDisposalDemo
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	class NonDisposedLogger : BaseLogger, IDisposable
	{

		public void Dispose()
		{
			this.tw.Flush();
			this.tw.Close();
			this.tw.Dispose();
		}
	}

}
