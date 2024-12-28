//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Grammar.g4 by ANTLR 4.13.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="GrammarParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.2")]
[System.CLSCompliant(false)]
public interface IGrammarListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] GrammarParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] GrammarParser.ProgramContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] GrammarParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] GrammarParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.doWhileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDoWhileStatement([NotNull] GrammarParser.DoWhileStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.doWhileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDoWhileStatement([NotNull] GrammarParser.DoWhileStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfStatement([NotNull] GrammarParser.IfStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfStatement([NotNull] GrammarParser.IfStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCondition([NotNull] GrammarParser.ConditionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCondition([NotNull] GrammarParser.ConditionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.singleCondition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSingleCondition([NotNull] GrammarParser.SingleConditionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.singleCondition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSingleCondition([NotNull] GrammarParser.SingleConditionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.variableDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariableDeclaration([NotNull] GrammarParser.VariableDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.variableDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariableDeclaration([NotNull] GrammarParser.VariableDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] GrammarParser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] GrammarParser.AssignmentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.printStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrintStatement([NotNull] GrammarParser.PrintStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.printStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrintStatement([NotNull] GrammarParser.PrintStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.printLineStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrintLineStatement([NotNull] GrammarParser.PrintLineStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.printLineStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrintLineStatement([NotNull] GrammarParser.PrintLineStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.foreachStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForeachStatement([NotNull] GrammarParser.ForeachStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.foreachStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForeachStatement([NotNull] GrammarParser.ForeachStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.arrayLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayLiteral([NotNull] GrammarParser.ArrayLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.arrayLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayLiteral([NotNull] GrammarParser.ArrayLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] GrammarParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] GrammarParser.ExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterType([NotNull] GrammarParser.TypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitType([NotNull] GrammarParser.TypeContext context);
}
