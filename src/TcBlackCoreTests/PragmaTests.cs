using Xunit;
using TcBlackCore;

namespace TcBlackTests
{
    [Collection("Sequential")]
    public class PragmaTests
	{
        [Theory]
        [InlineData("       {text 'This is text'}", 0, "{text 'This is text'}", 0)]
        [InlineData("   {attribute 'qualified_only'}      ",
            2, "        {attribute 'qualified_only'}", 2)]
        public void DifferentIndents(
            string originalCode,
            uint indents,
            string expectedCode,
            uint expectedIndents
        )
        {
            Global.indentation = "    ";
            Global.lineEnding = "\n";
            Pragma var = new Pragma(originalCode);
            Assert.Equal(expectedCode, var.Format(ref indents));
            Assert.Equal(expectedIndents, indents);
        }

        [Theory]
        [InlineData("{text  'This is text'}", "{text 'This is text'}")]
        [InlineData("{attribute    'qualified_only'  }", "{attribute 'qualified_only'}")]
        public void RemoveDoubleSpaces(
            string originalCode,
            string expectedCode
        )
        {
            Global.indentation = "    ";
            Global.lineEnding = "\n";

            Pragma var = new Pragma(originalCode);
            uint indents = 0;
            Assert.Equal(expectedCode, var.Format(ref indents));
        }
    }
}