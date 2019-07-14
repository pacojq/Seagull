using System.Collections.Generic;
using System.Linq;
using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.AST.Types.Namespaces;
using Seagull.Logging;
using Seagull.Visitor;
using Void = Seagull.Visitor.Void;

namespace Seagull.CodeGeneration.Mapl
{
    public class OffsetVisitor : AbstractVisitor<Visitor.Void, Visitor.Void>
    {
        private int _globalOffset;
	
	
        public OffsetVisitor() {
            _globalOffset = 0;
        }
	
		
        public override Void Visit(StructType structType, Void p)
        {
            //base.Visit(structType, p);
            int sum = 0;
		
            foreach (IDefinition vd in structType.Definitions) {
                vd.Accept(this, p);
                vd.CgOffset = sum;
                sum += vd.Type.CgNumberOfBytes;
            }
            return null;
        }
	
	
	
        public override Void Visit(VariableDefinition variableDefinition, Void p)
        {
            base.Visit(variableDefinition, p);
		
            // Global variable
            if (variableDefinition.Scope == 0)
            {
                variableDefinition.CgOffset = _globalOffset;
                _globalOffset += variableDefinition.Type.CgNumberOfBytes;
                Logger.Instance.LogDebug(
                    string.Format("Global variable {0} with offset {1}", variableDefinition.Name,
                        variableDefinition.CgOffset)
                );
            }
		
            return null;
        }
	
	
	
        public override Void Visit(FunctionDefinition functionDefinition, Void p)
        {
		
            functionDefinition.Type.Accept(this, p);
		
            int localBytesSum = 0;
		
            foreach (IStatement st in functionDefinition.Statements)
            {
                st.Accept(this, p);
			
                if (st is VariableDefinition)
                {
                    VariableDefinition vd = (VariableDefinition) st;
                    localBytesSum += vd.Type.CgNumberOfBytes;
                    vd.CgOffset = -localBytesSum;
                    functionDefinition.CgLocalBytesSum = localBytesSum;
                }
            }
		
            return null;
        }
	
	
        public override Void Visit(FunctionType functionType, Void p)
        {
            //base.Visit(functionType, p);
		
            List<VariableDefinition> parameters = functionType.Parameters.ToList();
		
            int localParamsSum = 4;
            for (int i = parameters.Count-1; i >= 0; i --)
            {
                VariableDefinition vd = parameters[i];
                vd.Accept(this, p);
                vd.CgOffset = localParamsSum;
                localParamsSum += vd.Type.CgNumberOfBytes;
            }
		
            return null;
        }
    }
}