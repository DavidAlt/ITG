using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITG.Desktop.Tests.ViewModels
{
    using NUnit.Framework;

    [TestFixture]
    public class TemplateVM_Tests
    {
        #region SETUP / BREAKDOWN

        // global data

        // performed once before all tests
        [TestFixtureSetUp]
        protected void InitFixture() { }

        // performed once after all tests
        [TestFixtureTearDown]
        protected void CleanUpFixture() { }

        // performed before each test
        [SetUp]
        protected void InitTest() { }

        // performed after each test
        [TearDown]
        protected void CleanUpTest() { }

        #endregion

        /* TemplateVM is responsible for the overall template structure,
         * including template-specific properties and subcomponents.
         * 
         * It interacts externally with the DesignerView.
         * It interacts internally with TemplatePageVM and TemplateItems.
         * 
         * RESPONSIBILITIES
         * Template construction (initializes to safe defaults)
         * Template I/O (save, load, import, export)
         * Template tab operations (add, remove, reorder, retrieve)
         * 
         * PUBLIC
         *   PROPERTIES
         *     string TemplateName, TemplateOwner
         *     double Height, Width
         *     bool IsBusy, IsDirty
         * 
         * 
         *     TemplateItemBaseVM[] Items
         *     TemplateItemBaseVM SelectedItem
         *     TemplateItemBaseVM[] SelectedItems
         * 
         *   COMMANDS
         *     AddPage, RemovePage, MovePage
         *     SelectItem, SelectItems
         *     MoveSelectedItemsUp, MoveSelectedItemsDown, MoveSelectedItemsLeft, MoveSelectedItemsRight
         *     RemoveSelectedItems
         * 
         * PRIVATE
         *   FIELDS
         *     string templateOwnerType, templateDesignerVersion
         *     SizeConstraint templateSize (min/max/def for width and height)
         *     TemplatePageVM currentPage
         *     TemplatePageVM[] pages
         * 
         *   METHODS
         *     AddItem, RemoveItem
         * 
         * 
         */

        public class Fields_Tests : TemplateVM_Tests
        {
            [Test]
            public void Field_RetrievesData_FromAppSettings()
            {
                Assert.Fail();
            }
        }

        



        
    }
}
