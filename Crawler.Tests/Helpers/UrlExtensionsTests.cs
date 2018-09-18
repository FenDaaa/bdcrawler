// <copyright file="UrlExtensionsTests.cs" company="pactera.com">
//     pactera.com. All rights reserved.
// </copyright>

namespace Crawler.Helpers.Tests
{
    using Xunit;

    public class UrlExtensionsTests
    {
        [Fact]
        public void ToAbsoluteUrlTest_WhenTakeRelativePath_ShouldGetCorrectUrl()
        {
            string baseUrl = "http://www.pactera.com/first/second/default.htm";
            string relativeUrl = "../";

            string actual = relativeUrl.ToAbsoluteUrl(baseUrl);

            Assert.Equal("http://www.pactera.com/first/", actual);
        }

        [Fact]
        public void ToAbsoluteUrlTest_WhenTakeAbsolutePath_ShouldGetCorrectUrl()
        {
            string baseUrl = "http://www.pactera.com/first/second.htm";
            string absoluteUrl = "http://www.baidu.com/";

            string actual = absoluteUrl.ToAbsoluteUrl(baseUrl);

            Assert.Equal(absoluteUrl, actual);
        }
    }
}