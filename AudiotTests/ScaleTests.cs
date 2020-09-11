using AudiotLogic.TheoryLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AudiotTests
{
    [TestClass]
    public class ScaleTests
    {
        [TestMethod]
        public void ScaleNameReflection()
        {
            var x = Scales.GetScaleNames();
            Assert.IsNotNull(x);
            Assert.IsTrue(x.Count > 0);
        }

        [TestMethod]
        public void StaticScaleConstruction()
        {
            var majorScale = Scales.Major;

            Assert.IsNotNull(majorScale);
            Assert.IsNotNull(majorScale.Steps);
            Assert.IsTrue(majorScale.Steps.Count > 0);
            Assert.IsNotNull(majorScale.Divisions);
            Assert.IsTrue(majorScale.Divisions > 0);
            Assert.IsNotNull(majorScale.Name);
            Assert.IsTrue(majorScale.Name != "");
        }

        [TestMethod]
        public void ConstructScaleFromString()
        {
            var scaleName = "Major";
            var scale = Scales.ConstructScaleFromName(scaleName);

            Assert.IsNotNull(scale);
            Assert.IsTrue(scale.Steps.Count > 0);
            Assert.IsTrue(scale.Divisions > 0);
            Assert.AreEqual(scaleName, scale.Name);
        }
    }
}
