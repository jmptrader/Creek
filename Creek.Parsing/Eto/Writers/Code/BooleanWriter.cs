using System.Linq;
using Lib.Parsing.Eto.Parsers;

namespace Lib.Parsing.Eto.Writers.Code
{
	public class BooleanWriter : global::Lib.Parsing.Eto.Writers.Code.ParserWriter<BooleanTerminal>
	{
		public override void WriteContents(TextParserWriterArgs args, BooleanTerminal parser, string name)
		{
			base.WriteContents(args, parser, name);
			if (parser.CaseSensitive != null)
				args.Output.WriteLine("{0}.CaseSensitive = {1};", name, parser.CaseSensitive.HasValue ? parser.CaseSensitive.ToString().ToLowerInvariant() : "null");
			args.Output.WriteLine("{0}.TrueValues = new string[] {{ {1} }};", name, ValueString(parser.TrueValues));
			args.Output.WriteLine("{0}.FalseValues = new string[] {{ {1} }};", name, ValueString(parser.FalseValues));
		}

		string ValueString(string[] values)
		{
			return string.Join(", ", values.Select(r => "\"" + r.Replace("\"", "\\\"") + "\""));
		}
	}
}

