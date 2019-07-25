using System.Collections.Generic;
using System.Linq;
using Seagull.AST.Statements.Definitions;
using Seagull.Errors;
using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class StructType : AbstractType
    {

        public IEnumerable<IDefinition> Fields => _fields;
        
        private readonly List<IDefinition> _fields;
        
        public StructType(int line, int column, IEnumerable<VariableDefinition> fields)
            : base(line, column)
        {
            _fields = new List<IDefinition>();
            if (fields != null)
                _fields.AddRange(fields);
        }

        
        
        

        public override IType TypeCheckNew()
        {
            return this;
        }
        
        
        public override IType TypeCheckAttributeAccess(string attribute)
        {
            IDefinition def = _fields.FirstOrDefault(f => f.Name.Equals(attribute));
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
            string str = "struct { ";

            if (_fields.Count > 0)
            {
                str += _fields[0].ToString();
                for (int i = 1; i < _fields.Count; i ++)
                    str += ", " + _fields[i].ToString();
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