using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku_Solver___Ronni_Moshkovitz.Exceptions;
using Sudoku_Solver___Ronni_Moshkovitz.SudokuHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class ValidationTesting
    {
        // Missing chars sudoku strings to test
        private readonly List<string> _invalidSudokuStringSize = new List<string>()
        {
            "1234", // string with length 4
            "123456", // string with length 6
            "123456789:;<=>?", // string with length 15
            "123456789:;<=>?@ABCDEFGHIJKLMNOPQRS", // string with length 36
        };

        // Unsupported cell values to test
        private readonly List<string> _invalidSudokuStringValues = new List<string>()
        {
            "2", // 1x1 board with 2
            "1000300000500000", // 4x4 board with 5
            "00000010000000080000007000000000000009000000000000:000000000023000000000000000000", // 9*9 board with :
            "102000004000+000", // 4x4 board with + (bellow '0' in ascii table)
        };

        // Same value in row to test
        private readonly List<string> _illegalRowSudoku = new List<string>()
        {
            "0110002300014000", // double 1 in row 0
            "004060000900784300007023049073040620090000030085030190350470900006592003000015500", // double 5 in row 8
            "15:2349;<@6>?=78>@8=5?7<43000:6;0<47:@618=?;35>236;?0=8005:94@0100>387;:00261?@98;76412@9:>?<35=<91:=5?634@8>2;7@?259<>31;7=:68462@>;94=?1<007:37=91?235008:@<46000000<7264@=9?>?:<4>6@8=0000;15235000:?6704;1=@:7=<0009>8;1640000?96004@0507>0:4>6@7;12:?=7009<" // double 7 in row 17
        };

        // Same value in column to test
        private readonly List<string> _illegalColumnSudoku = new List<string>()
        {
            "3000300000000000", // double 3 in row column 1
            "004050000904730600003021049035090480090000030076010920310970200009182003000060100", // double 4 in row column 3
            "8<000407000=00007@00100002?0:00<=10500000:;0490@00200000@09005=00400000@0:0103>0060000=1000>;004005=0?0>400007060:?340000000000200805006001200:06070?000;3008<002000030090040@00003>90<40000000?00<00060300?0:;05=@600208000<007000200000000@00=00000000=@0010?3" // double : in column 10
        };

        // Same value in box to test
        private readonly List<string> _illegalBoxSudoku = new List<string>()
        {
            "3100410000200003", // double 1 in box 0
            "040020178198200600007150043074000031260037800805900007310005020400700006006043009", // double 2 in box 1
            "<9003=?:21;7@6>4:<>7<50@40069?0000461;8>9000<=7:@=1;4076?:00053251;0000=8@6>4<:?>?9=@4627<00000064<@:800532?19=73:700<1?=49;>@26486:=7;13><952?@7;2>8@436?5=:19<=53<?>:9@21467;89@?16200:;783>0010@49:5008=0?;632>53;?=816@:74<0;6:00034<7?5=8@>87=?>6@<;9432:51" // double < in box 0
        };


        [TestMethod]
        public void InvalidSudokuStringSizes()
        {
            //Arrange test
            foreach (string sudokuString in _invalidSudokuStringSize)
            {
                // Act test + Assert test
                Assert.ThrowsException<InvalidSideException>(() => new SudokuHandler(sudokuString));
            }
        }

        [TestMethod]
        public void SudokuStringTooLong()
        {
            //Arrange test
            string sudokuString = "123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZA0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";

            //Act test + Assert test
            Assert.ThrowsException<StringTooLongException>(() => new SudokuHandler(sudokuString));
        }

        [TestMethod]
        public void InvalidSudokuStringValues()
        {
            //Arrange test
            foreach (string sudokuString in _invalidSudokuStringValues)
            {
                // Act test + Assert test
                Assert.ThrowsException<UnsupportedValueException>(() => new SudokuHandler(sudokuString));
            }
        }

        [TestMethod]
        public void IllegalRowSudoku()
        {
            //Arrange test
            foreach (string sudokuString in _illegalRowSudoku)
            {
                // Act test + Assert test
                Assert.ThrowsException<IllegalRowException>(() => new SudokuHandler(sudokuString));
            }
        }

        [TestMethod]
        public void IllegalColumnSudoku()
        {
            //Arrange test
            foreach (string sudokuString in _illegalColumnSudoku)
            {
                // Act test + Assert test
                Assert.ThrowsException<IllegalColumnException>(() => new SudokuHandler(sudokuString));
            }
        }

        [TestMethod]
        public void IllegalBoxSudoku()
        {
            //Arrange test
            foreach (string sudokuString in _illegalBoxSudoku)
            {
                // Act test + Assert test
                Assert.ThrowsException<IllegalBoxException>(() => new SudokuHandler(sudokuString));
            }
        }
    }
}
