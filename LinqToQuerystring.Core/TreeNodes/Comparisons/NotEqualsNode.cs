﻿namespace LinqToQuerystring.Core.TreeNodes.Comparisons
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.Core.TreeNodes.Base;

    public class NotEqualsNode : TwoChildNode
    {
        public NotEqualsNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var leftExpression = this.LeftNode.BuildLinqExpression(query, expression, item);
            var rightExpression = this.RightNode.BuildLinqExpressionWithComparison(query, expression, item, leftExpression);

            NormalizeTypes(ref leftExpression, ref rightExpression);

            return ApplyWithNullAsValidAlternative(Expression.NotEqual, leftExpression, rightExpression);
        }
    }
}