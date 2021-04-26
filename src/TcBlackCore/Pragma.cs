namespace TcBlackCore
{
	/// <summary>
	/// Format a pragma. A pragma can be on it's own line or placed after a decleration
	/// </summary>
	public class Pragma : CodeLineBase
	{
        public Pragma(string unformattedCode) : base(unformattedCode)
		{
		}

		public override string Format(ref uint indents)
		{
			string formattedCode =
				Global.indentation.Repeat(indents) + _unformattedCode.Trim();
			return formattedCode;
		}
	}
}