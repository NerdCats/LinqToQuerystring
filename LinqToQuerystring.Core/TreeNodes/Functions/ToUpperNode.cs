﻿namespace LinqToQuerystring.Core.TreeNodes.Functions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.Core.TreeNodes.Base;

    public class ToUpperNode : SingleChildNode
    {
        public ToUpperNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var childexpression = this.ChildNode.BuildLinqExpression(query, expression, item);

            if (!typeof(string).IsAssignableFrom(childexpression.Type))
            {
                childexpression = Expression.Convert(childexpression, typeof(string));
            }
            
            return Expression.Call(childexpression, "ToUpper", null, null);
        }
    }
}