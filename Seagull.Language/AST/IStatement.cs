namespace Seagull.Language.AST
{
    public interface IStatement : IAstNode
    {
        
        // Code Generation
        
        /// <summary>
        /// Code Generation: code to execute a statement.
        /// </summary>
        string CgExecute { get; set; }
    }
}