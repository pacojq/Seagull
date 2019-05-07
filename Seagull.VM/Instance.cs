using System.Collections.Generic;

namespace Seagull.VM
{
	internal class Instance
	{
		public int this[string key]
		{
			get => _attributes[key];
			set
			{
				if (!_attributes.ContainsKey(key))
					_attributes.Add(key, value);
				else _attributes[key] = value;
			}
		}

		private readonly Dictionary<string, dynamic> _attributes;

		public Instance()
		{
			_attributes = new Dictionary<string, dynamic>();
		}
	}
}