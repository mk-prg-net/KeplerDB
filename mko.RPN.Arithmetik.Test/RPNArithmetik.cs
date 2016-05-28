using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using System.Linq;

namespace mko.RPN.Arithmetik.Test
{
    [TestClass]
    public class RPNArithmetik
    {
        Dictionary<string, IEval> Functions = new Dictionary<string,IEval>{
                                                  {"ADD", new Arithmetik.Add()},
                                                  {"SUB", new Arithmetik.Sub()},
                                                  {"MUL", new Arithmetik.Mul()},
                                                  {"DIV", new Arithmetik.Div()}
                                              };

        Parser Parser = new Parser();

        System.IO.MemoryStream memStream = new System.IO.MemoryStream();
        System.IO.StreamWriter TermWriter;
        System.IO.StreamReader TermReader;

        ITokenizer Tokenizer;

        public RPNArithmetik()
        {
            TermWriter = new System.IO.StreamWriter(memStream);
            TermReader = new System.IO.StreamReader(memStream);

            Tokenizer = new Tokenizer(TermReader);
        }

        [TestInitialize]
        void Init()
        {
            // Streams leeren
            TermWriter.Flush();
            TermReader.ReadToEnd();               
        }

        [TestMethod]
        public void RPNArithmetik_ADD()
        {
            //TermWriter.Write();
            //TermWriter.Flush();
            //memStream.Seek(0, System.IO.SeekOrigin.Begin);

            var myTokenizer = new Tokenizer("2.3 4.7 ADD");

            Parser.Parse(myTokenizer, Functions);

            Assert.IsTrue(Parser.Succsessful);
            Assert.AreEqual(1, Parser.Stack.Count);
            Assert.IsInstanceOfType(Parser.Stack.Peek(), typeof(DoubleToken));
            Assert.AreEqual(7.0, (Parser.Stack.Peek() as DoubleToken).ValueAsDouble);
        }

        [TestMethod]
        public void RPNArithmetik_ADD_MUL()
        {
            TermWriter.Write("2.3 4.7 ADD 3 MUL");
            TermWriter.Flush();
            memStream.Seek(0, System.IO.SeekOrigin.Begin);

            Parser.Parse(Tokenizer, Functions);

            Assert.IsTrue(Parser.Succsessful);
            Assert.AreEqual(1, Parser.Stack.Count);
            Assert.IsInstanceOfType(Parser.Stack.Peek(), typeof(DoubleToken));
            Assert.AreEqual(21.0, (Parser.Stack.Peek() as DoubleToken).ValueAsDouble);
        }

        [TestMethod]
        public void RPNArithmetik_ADD_MUL_DIV()
        {
            TermWriter.Write("2.3 4.7 ADD 3 MUL 2 DIV");
            TermWriter.Flush();
            memStream.Seek(0, System.IO.SeekOrigin.Begin);

            Parser.Parse(Tokenizer, Functions);

            Assert.IsTrue(Parser.Succsessful);
            Assert.AreEqual(1, Parser.Stack.Count);
            Assert.IsInstanceOfType(Parser.Stack.Peek(), typeof(DoubleToken));
            Assert.AreEqual(10.5, (Parser.Stack.Peek() as DoubleToken).ValueAsDouble);
        }

        [TestMethod]
        public void RPNArithmetik_ADD_SUB_ADD()
        {
            TermWriter.Write("2.3 4.7 ADD 7.5 2.5 SUB ADD");
            TermWriter.Flush();
            memStream.Seek(0, System.IO.SeekOrigin.Begin);

            Parser.Parse(Tokenizer, Functions);

            Assert.IsTrue(Parser.Succsessful);
            Assert.AreEqual(1, Parser.Stack.Count);
            Assert.IsInstanceOfType(Parser.Stack.Peek(), typeof(DoubleToken));
            Assert.AreEqual(12, (Parser.Stack.Peek() as DoubleToken).ValueAsDouble);
        }

        [TestMethod]
        public void RPNArithmetik_ADD_SUB_ADD_DIV()
        {
            TermWriter.Write("2.3 4.7 ADD 7.5 2.5 SUB ADD 2 DIV");
            TermWriter.Flush();
            memStream.Seek(0, System.IO.SeekOrigin.Begin);

            Parser.Parse(Tokenizer, Functions);

            Assert.IsTrue(Parser.Succsessful);
            Assert.AreEqual(1, Parser.Stack.Count);
            Assert.IsInstanceOfType(Parser.Stack.Peek(), typeof(DoubleToken));
            Assert.AreEqual(6, (Parser.Stack.Peek() as DoubleToken).ValueAsDouble);
        }



    }
}
