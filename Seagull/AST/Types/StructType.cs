using System;
using System.Collections.Generic;
using System.Linq;
using Seagull.AST.Statements.Definitions;
using Seagull.Errors;
using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class StructType : AbstractType
    {

        public override int NumberOfBytes => Fields
            .Select(f => f.Type)
            .Sum(t => t.NumberOfBytes);
        

        public string StructName { get; internal set; }
        

        public IEnumerable<VariableDefinition> Fields => _fields;

        private readonly List<VariableDefinition> _fields;
        
        public StructType(int line, int column, IEnumerable<VariableDefinition> fields)
            : base(line, column)
        {
            _fields = new List<VariableDefinition>(fields);
            
            
            StructName = "struct ";
            StructName += "{ ";
            if (_fields.Count > 0)
            {
                StructName += _fields[0].ToString();
                for (int i = 1; i < _fields.Count; i ++)
                    StructName += ", " + _fields[i].ToString();
            }
            StructName += " }";
        }

        
        
        
        public VariableDefinition FindField(string name)
        {
            foreach (var def in _fields)
                if (def.Name.Equals(name))
                    return def;
            return null;
        }
        



        public override IType TypeCheckNew()
        {
            return this;
        }
        
        
        public override IType TypeCheckAttributeAccess(string attribute)
        {
            VariableDefinition def = FindField(attribute);
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
            return StructName;
        }
        
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}