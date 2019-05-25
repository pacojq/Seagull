using System;
using System.Collections.Generic;
using System.Linq;
using Seagull.AST.Statements.Definitions;
using Seagull.Errors;
using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class EnumType : AbstractType
    {
        public override int NumberOfBytes => _elements.Count * TypeOf.NumberOfBytes;
        
        public IType TypeOf { get; }
        public IEnumerable<EnumElementDefinition> Elements => _elements;
        

        private readonly List<EnumElementDefinition> _elements;
        
        public EnumType(int line, int column, IType typeOf, IEnumerable<EnumElementDefinition> elements)
            : base(line, column)
        {
            TypeOf = typeOf;
            _elements = new List<EnumElementDefinition>(elements);
        }

        
        public EnumElementDefinition FindElement(string name)
        {
            foreach (var element in _elements)
                if (element.Name.Equals(name))
                    return element;
            return null;
        }
        

        
        public override IType TypeCheckAttributeAccess(string name)
        {
            EnumElementDefinition element = FindElement(name);
            if (element == null)
            {
                return ErrorHandler.Instance.RaiseError(
                        Line, 
                        Column,
                        $"Unknown enum element: {name} ."
                    );
            }		
            return element.Type;
        }
        
        

        public override string ToString()
        {
            return "enum"; // TODO
        }


        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            throw new NotImplementedException();
        }
    }
}