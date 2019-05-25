using System;
using System.Collections;
using System.Collections.Generic;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Statements.Definitions.Namespaces;
using Seagull.AST.Types;
using Seagull.AST.Types.Namespaces;
using Seagull.Logging;

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


		/// <summary>
		/// We're gonna represent namespaces as a tree of INamespaceDefinitions.
		/// The root node will be the DefaultNamespace.
		/// </summary>
		private readonly NamespaceDefinition _defaultNamespace;
		public static NamespaceDefinition DefaultNamespace => Instance._defaultNamespace;


		/// <summary>
		/// We'll store them all in a dictionary, so we can get to them
		/// as fast and easy as possible.
		/// </summary>
		private readonly IDictionary<string, INamespaceType> _namespaceTypes;

		
		

		private NamespaceManager()
		{
			_namespaceTypes = new Dictionary<string, INamespaceType>();
			
			
			// Default namespace
			NamespaceType defType = new NamespaceType(0, 0, "");
			_namespaceTypes.Add("", defType);
			_defaultNamespace = new NamespaceDefinition(0, 0, "", defType);
		}


		
		public NamespaceDefinition Define(int line, int column, string id, NamespaceDefinition parent)
		{
			if (parent == null)
				throw new ArgumentException("A namespace cannot have a null parent.");
			
			string key = "";
			if (parent != DefaultNamespace)
				key += parent.Name + ".";
			key += id;

			Logger.Instance.LogDebug("New namespace defined: '{0}'", key);

			if (!_namespaceTypes.ContainsKey(key))
				_namespaceTypes.Add(key, new NamespaceType(line, column, id));
			INamespaceType type = _namespaceTypes[key];
			
			NamespaceDefinition result = new NamespaceDefinition(line, column, id, type);

			// The parent MUST be a namespace
			INamespaceType parentType = (INamespaceType) parent.Type;
			parentType.AddDefinition(result);
			type.ParentNamespace = parentType;
			result.Namespace = parent;

			return result;
		}


	}
}