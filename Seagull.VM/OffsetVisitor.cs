using System;
using System.Collections.Generic;
using System.Linq;
using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Visitor;
using Void = Seagull.Visitor.Void;

namespace Seagull.VM
{
	public class OffsetVisitor : AbstractVisitor<Void, Void>
	{
		
		private int _globalOffset;
	
		public OffsetVisitor()
		{
			_globalOffset = 0;
		}
	
		
		public override Void Visit(StructType structType, Void p)
		{
			//base.Visit(structType, p);
			int sum = 0;
		
			foreach (VariableDefinition vd in structType.Fields)
			{
				vd.Accept(this, p);
				vd.Offset = sum;
				sum += vd.Type.NumberOfBytes;
			}
			return null;
		}
	
	
	
		public override Void Visit(VariableDefinition variableDefinition, Void p)
		{
			base.Visit(variableDefinition, p);
		
			// Global variable
			if (variableDefinition.Scope == 0)
			{
				variableDefinition.Offset = _globalOffset;
				_globalOffset += variableDefinition.Type.NumberOfBytes;
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
			
				// TODO maybe find a cleaner way to do this
				if (st is VariableDefinition)
				{
					VariableDefinition vd = (VariableDefinition) st;
					localBytesSum += vd.Type.NumberOfBytes;
					vd.Offset = -localBytesSum;
					functionDefinition.LocalBytesSum = localBytesSum;
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
				vd.Offset = localParamsSum;
				localParamsSum += vd.Type.NumberOfBytes;
			}
		
			return null;
		}
		
		
		
	}
}