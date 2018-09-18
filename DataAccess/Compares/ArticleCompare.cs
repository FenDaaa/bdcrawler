using DataAccess.Models;
using System;
// <copyright file="Article.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace DataAccess.Compares
{
    using System.Collections.Generic;

    public class ArticleCompare : IEqualityComparer<Article>
    {
        public bool Equals(Article x, Article y)
        {
            return x.Url.Equals(y.Url, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(Article obj)
        {
            return obj.Url.GetHashCode();
        }
    }
}
