using System.Collections;
using System.Collections.Generic;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;

namespace Seagull.Semantics.Symbols
{
	public class NamespaceManager
	{

		private static NamespaceManager _instance;
		public static NamespaceManager Instance
		{
			get
			{
				if (_instance == null)
					_instance = new NamespaceManager();
				return _instance;
			}
		}



		private readonly IDictionary<string, NamespaceType> _namespaces;



		private NamespaceManager()
		{
			_namespaces = new Dictionary<string, NamespaceType>();
		}


		public NamespaceDefinition Define(int line, int column, string id, NamespaceDefinition parent)
		{
			string key = "";
			if (parent != null)
				key += parent.Name + ".";
			key += id;

			NamespaceType type;
			if (!_namespaces.ContainsKey(key))
				_namespaces.Add(key, new NamespaceType(line, column));
			type = _namespaces[key];
			
			NamespaceDefinition result = new NamespaceDefinition(line, column, id, type);

			if (parent != null)
			{
				((NamespaceType) parent.Type).AddSubNamespace(id);
			}
			
			return result;
		}


		
	}
}