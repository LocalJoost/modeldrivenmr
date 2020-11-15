using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ReactNativeDemo.State;
using UniRx;

namespace Tests
{
    public class ModelTest
    {
        [Test]
        public void TestAddModel()
        {
            var list = new ObjectListModel();
            var model = new SimpleDemoModel();
            list.Shapes.Add(model);
            Assert.Contains(model, list.Shapes.ToList());
        }

        [Test]
        public void TestAddModelEvent()
        {
            SimpleDemoModel addedModel = null;
            var list = new ObjectListModel();
            var subscription = list.Shapes.ObserveAdd().Subscribe(p => addedModel = p.Value);
            var model = new SimpleDemoModel();
            list.Shapes.Add(model);
            subscription.Dispose();
            Assert.AreEqual(model, addedModel);
        }

        [Test]
        public void TestRemoveModel()
        {
            SimpleDemoModel removeModel = null;
            var list = new ObjectListModel();
            var subscription = list.Shapes.ObserveRemove().Subscribe(p => removeModel = p.Value);
            var model = new SimpleDemoModel();
            list.Shapes.Add(model);
            Assert.IsTrue(list.Shapes.Contains(model));
            model.Delete();
            subscription.Dispose();
            Assert.AreEqual(model, removeModel);
            Assert.IsFalse(list.Shapes.Contains(model));
        }
    }
}