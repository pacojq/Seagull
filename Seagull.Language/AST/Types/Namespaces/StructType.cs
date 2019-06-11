using System;
using System.Collections.Generic;
using System.Linq;
using Seagull.Language.AST.Statements.Definitions;
using Seagull.Language.Errors;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Types.Namespaces
{
    public class StructType : AbstractNamespaceType
    {

        public override int CgNumberOfBytes => Definitions
            .Select(f => f.Type)
            .Sum(t => t.CgNumberOfBytes);
        


        public sealed override string Name { get; set; }
        
        
        public StructType(int line, int column, IEnumerable<VariableDefinition> fields)
            : base(line, column)
        {
            foreach (var f in fields)
                AddDefinition(f);
            Name = this.ToString();
        }

        
        
        

        public override IType TypeCheckNew()
        {
            return this;
        }
        
        
        public override IType TypeCheckAttributeAccess(string attribute)
        {
            IDefinition def = FindDefinition(attribute);
            if (def == null)
            {
                return ErrorHandler.Instance.RaiseError(
                        Line, 
                        Column,
                        $"Trying to access a non-existent struct field: {attribute} ."
                    );
            }		
            return def.Type;
        }
        
        
        


        public override string ToString()
        {
            string str = Name;
            str += " { ";

            var defs = Definitions.ToList();
            if (defs.Count > 0)
            {
                str += defs[0].ToString();
                for (int i = 1; i < defs.Count; i ++)
                    str += ", " + defs[i].ToString();
            }
            str += " }";
            return str;
        }
        
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }


    }
}