using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;
using Tyuiu.PankovaPAA.Sprint7.Lib;

namespace Tyuiu.PankovaPAA.Sprint7.Test
    //убрать
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Models_Create_Works()
        {
            var actor = new Actor
            {
                ActorId = 1,
                LastName = "Иванова",
                FirstName = "Анна",
                MiddleName = "Сергеевна",
                RoleType = "Вокал"
            };

            var clip = new VideoClip
            {
                Code = "CL-001",
                RecordDate = new DateTime(2025, 12, 17),
                DurationSec = 210,
                Theme = "Поп",
                Cost = 199.99m,
                ActorId = 1
            };

            Assert.AreEqual(1, actor.ActorId);
            Assert.AreEqual("CL-001", clip.Code);
            Assert.AreEqual(210, clip.DurationSec);
        }
    }
}