﻿using NUnit.Framework;
using Seagull.AST.Statements.Definitions;
using Seagull.Semantics;

namespace Seagull.Tests.Semantics
{
    [TestFixture]
    public class SymbolTableTests
    {
        [Test]
        public void TestInsert()
        {
            SymbolTable st = new SymbolTable();
            VariableDefinition definition = new VariableDefinition(0, 0, "a", null);
            Assert.True(st.Insert(definition));
            Assert.AreEqual(definition.Scope, 0);
            Assert.False(st.Insert(definition));
            st.Set();
            VariableDefinition definition2 = new VariableDefinition(0, 0, "a", null);
            Assert.True(st.Insert(definition2));
            Assert.AreEqual(definition2.Scope, 1);
            Assert.False(st.Insert(definition2));
            st.Reset();
            Assert.False(st.Insert(definition));
        }
    }
}