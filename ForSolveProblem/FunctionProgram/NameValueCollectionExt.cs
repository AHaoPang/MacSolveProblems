using System;
using System.Collections.Specialized;

namespace ForSolveProblem.FunctionProgram
{
    public static class NameValueCollectionExt
    {
        public static Option<string> Lookup(this NameValueCollection nc, string key)
            => nc[key];
    }
}
