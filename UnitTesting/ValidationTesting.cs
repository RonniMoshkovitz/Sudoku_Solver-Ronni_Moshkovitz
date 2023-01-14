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
    // This class, ValidationTesting, preforms unit testing for the validation process for given sudoku strings.
    [TestClass]
    public class ValidationTesting
    {
        // Missing characters sudoku strings test samples.
        private readonly List<string> _invalidSudokuStringSize = new List<string>()
        {
            // 2 characters long string.
            "12",

            // 4 characters long string.
            "1234", 

            // 6 characters long string.
            "123456",

            // 15 characters long string.
            "123456789:;<=>?", 

            // 35 charcters long string.
            "123456789:;<=>?@ABCDEFGHIJKLMNOPQR" 
        };

        // Unsupported cell values test samples.
        private readonly List<string> _invalidSudokuStringValues = new List<string>()
        {
            // 1x1 board with '2'.
            "2", 

            // 4x4 board with '5'.
            "1000300000500000", 

            // 9x9 board with ':'.
            "00000010000000080000007000000000000009000000000000:000000000023000000000000000000", 

            // 4x4 board with '+' (bellow '0' in ascii table).
            "102000004000+000", 
        };

        // Same value in row test samples.
        private readonly List<string> _illegalRowSudoku = new List<string>()
        {
            // Multiple '1' in row 0.
            "0110002300014000", 

            // Multiple '5' in row 8.
            "004060000900784300007023049073040620090000030085030190350470900006592003000015500", 

            // Multiple '7' in row 17.
            "15:2349;<@6>?=78>@8=5?7<43000:6;0<47:@618=?;35>236;?0=8005:94@0100>387;:00261?@98;76412@9:>?<35=<91:=5?634@8>2;7@?259<>31;7=:68462@>;94=?1<007:37=91?235008:@<46000000<7264@=9?>?:<4>6@8=0000;15235000:?6704;1=@:7=<0009>8;1640000?96004@0507>0:4>6@7;12:?=7009<"
        };

        // Same value in column test samples.
        private readonly List<string> _illegalColumnSudoku = new List<string>()
        {
            // Multiple '3' in column 1.
            "3000300000000000", 

            // Multiple '4' in column 3.
            "004050000904730600003021049035090480090000030076010920310970200009182003000060100",

            // Multiple ':' in column 10.
            "8<000407000=00007@00100002?0:00<=10500000:;0490@00200000@09005=00400000@0:0103>0060000=1000>;004005=0?0>400007060:?340000000000200805006001200:06070?000;3008<002000030090040@00003>90<40000000?00<00060300?0:;05=@600208000<007000200000000@00=00000000=@0010?3"
        };

        // Same value in box test samples.
        private readonly List<string> _illegalBoxSudoku = new List<string>()
        {
            // Multiple '1' in box 0.
            "3100410000200003", 

            // Multiple '2' in box 1
            "040020178198200600007150043074000031260037800805900007310005020400700006006043009", 

            // Multiple '<' in box 0.
            "<9003=?:21;7@6>4:<>7<50@40069?0000461;8>9000<=7:@=1;4076?:00053251;0000=8@6>4<:?>?9=@4627<00000064<@:800532?19=73:700<1?=49;>@26486:=7;13><952?@7;2>8@436?5=:19<=53<?>:9@21467;89@?16200:;783>0010@49:5008=0?;632>53;?=816@:74<0;6:00034<7?5=8@>87=?>6@<;9432:51"
        };


        // Test for invalid sudoku strings, due to missing characters.
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

        // Test for invalid sudoku strings, due to too many characters.
        [TestMethod]
        public void SudokuStringTooLong()
        {
            // Arrange test
            string sudokuString = "123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZA0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";

            // Act test + Assert test
            Assert.ThrowsException<StringTooLongException>(() => new SudokuHandler(sudokuString));
        }

        // Test for invalid sudoku strings, due to unsupported values.
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

        // Test for invalid sudoku, due to multipte appearences of the same value in the same row.
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

        // Test for invalid sudoku, due to multipte appearences of the same value in the same column.
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

        // Test for invalid sudoku, due to multipte appearences of the same value in the same box.
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

        // Test for valid sudoku.
        [TestMethod]
        public void ValidSudoku()
        {
            // Arrange test
            string sudokuString = "000740850082000731000002640250004100006170025000520000000200014368005290124000086";
            
            // Act test             
            SudokuHandler handler = new SudokuHandler(sudokuString);

            // A special case when no "Assert test" is needed:
            // The test will fail if an exception will accure. In this case, we "assert" that no exception will be thrown, meaning nothing will happen).             
        }
    }
}
