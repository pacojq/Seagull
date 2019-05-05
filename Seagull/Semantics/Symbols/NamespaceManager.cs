using System;
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


		private readonly NamespaceDefinition _defaultNamespace;
		public static NamespaceDefinition DefaultNamespace => Instance._defaultNamespace;


		private readonly IDictionary<string, NamespaceType> _namespaces;



		private NamespaceManager()
		{
			_namespaces = new Dictionary<string, NamespaceType>();
			_defaultNamespace = Define(0, 0, "", null);
		}


		public NamespaceDefinition Define(int line, int column, string id, NamespaceDefinition parent)
		{
			string key = "";
			if (parent != null)
				key += parent.Name + ".";
			key += id;

			Console.WriteLine("New namespace defined: '{0}'", key);

			NamespaceType type;
			if (!_namespaces.ContainsKey(key))
				_namespaces.Add(key, new NamespaceType(line, column));
			type = _namespaces[key];
			
			NamespaceDefinition result = new NamespaceDefinition(line, column, key, type);

			if (parent != null)
				((NamespaceType) parent.Type).AddSubNamespace(id);
			
			return result;
		}


	}
}