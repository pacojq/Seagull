using System;
using System.Collections.Generic;
using Seagull.AST.Statements.Definitions.Namespaces;
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
			NamespaceType defType = new NamespaceType(0, 0, "", null);
			_namespaceTypes.Add("", defType);
			_defaultNamespace = new NamespaceDefinition(0, 0, "", defType);
		}

		
		
		
		public INamespaceType AddType(int line, int column, string id, INamespaceType parent)
		{
			if (parent == null)
				parent = (NamespaceType) DefaultNamespace.Type;

			NamespaceType candidate = new NamespaceType(line, column, id, (NamespaceType) parent);
			string key = candidate.Fullname;
			
			Logger.Instance.LogDebug("Namespace type found: [{0}:{1}] '{2}'", line, column, key);

			// We already have it
			if (_namespaceTypes.ContainsKey(key))
				return _namespaceTypes[key];
				
			// Otherwise, we add it
			_namespaceTypes.Add(key, candidate);
			return candidate;
		}
		
		
		
		
		public NamespaceDefinition Define(int line, int column, INamespaceType type)
		{
			string key = type.Fullname;
			Logger.Instance.LogDebug("Defining namespace: [{0}:{1}] '{2}'", line, column, key);

			if (!_namespaceTypes.ContainsKey(key))
				throw new InvalidOperationException("Cannot define a type that's not been added to the NamespaceManager.");

			NamespaceDefinition result = new NamespaceDefinition(line, column, type.Fullname, type);

			INamespaceType parentType = type.ParentNamespace;
			parentType.AddDefinition(result);

			return result;
		}


	}
}