using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALT.ITG.Models;
using DALT.ITG.ViewModels;

namespace DALT.ITG.Tests
{
    using NUnit.Framework;
    // initialize any test objects you need
    // execute the method you want to test
    // check the state of your test objects

    [TestFixture]
    public class TemplateItemVMTests
    {
        // 1,630,37,720,55,115033,8449," |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||","N=68|K=16777215|T=T","HPI~ ~Here for well-child check."

        /*
        string _prefix = "\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\"";
        string _itemdata = "\"N=68|K=16777215|T=T\"";
        string _caption = "HPI";
        string _content = "Here for well-child check.";
        */ 
        
        public class ImportExportTests : TemplateItemVMTests
        {
            [Test]
            public void PageTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.Import("1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"");
                int expected = 1;
                int actual = item.Page;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void LeftTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.Import("1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"");
                double expected = 630;
                double actual = item.Left;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void TopTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.Import("1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"");
                double expected = 37;
                double actual = item.Top;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void RightTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.Import("1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"");
                double expected = 720;
                double actual = item.Right;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void BottomTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.Import("1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"");
                double expected = 55;
                double actual = item.Bottom;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void WidthTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.Import("1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"");
                double expected = 91;
                double actual = item.Width;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void HeightTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.Import("1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"");
                double expected = 19;
                double actual = item.Height;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void MedcinIdTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.Import("1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"");
                int expected = 115033;
                int actual = item.MedcinId;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ControlFlagTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.Import("1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"");
                int expected = 8449;
                int actual = item.ControlFlag;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void PrefixTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.Import("1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"");
                string expected = "\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\"";
                string actual = item.Prefix.ToString();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ItemDataTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.ItemData.Add(new ObjectIdOption(68), new BackColorOption(16777215), new FrameDrawOnlyOption(true));
                string expected = "\"N=68|K=16777215|T=T\"";
                string actual = item.ItemData.ToString();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void CaptionTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.Import("1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"");
                string expected = "HPI";
                string actual = item.Caption;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ContentTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.Import("1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"");
                string expected = " ~Here for well-child check.";
                string actual = item.Content;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ExportItemTest()
            {
                TemplateItemVM item = new TemplateItemVM();
                item.Import("1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"");
                item.ItemData.Add(new ObjectIdOption(68), new BackColorOption(16777215), new FrameDrawOnlyOption(true));
                string expected = "1,630,37,720,55,115033,8449,\" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||\",\"N=68|K=16777215|T=T\",\"HPI~ ~Here for well-child check.\"";
                string actual = item.Export();
                Assert.AreEqual(expected, actual);
            }

        }

        

    }
}