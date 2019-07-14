namespace Seagull.AST.Expressions.Increments
{
	// Increments can be expressions and statements, just like functions
	public interface IIncrement : IExpression, IStatement
	{
		bool IsPrefixIncrement { get; }
		
		IExpression Operand { get; }
	}
}