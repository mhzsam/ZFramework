using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helper
{
	public static class PermissionHashHelper
	{
		public static ulong ComputeHash(string input)
		{
			// الگوریتم FNV-1a 64bit
			const ulong fnvOffsetBasis = 14695981039346656037;
			const ulong fnvPrime = 1099511628211;
			ulong hash = fnvOffsetBasis;

			foreach (var c in input)
			{
				hash ^= c;
				hash *= fnvPrime;
			}
			return hash;
		}
	}

}
