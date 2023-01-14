﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku_Solver___Ronni_Moshkovitz.SudokuHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    // This class, SudokuSolvingTesting, preforms unit testing for different given sudoku situations.
    [TestClass]
    public class SudokuSolvingTesting
    {
        // 9x9 boards test samples.
        private readonly Dictionary<string, string> _sudokuBoards9 = new Dictionary<string, string>()
        {
            // Empty board
            {"000000000000000000000000000000000000000000000000000000000000000000000000000000000",
             "123456789789123456456789123312845967697312845845697312231574698968231574574968231"},

            // Easy board
            {"500600709800072360740031800180006507950387000367000098090063105070819023401000980",
             "523648719819572364746931852184296537952387641367154298298463175675819423431725986"},

            // Medium board
            {"001050630300078050005460700250000047010007000706004000142800500637040810008010020",
             "871952634364178952925463781259681347413597268786324195142839576637245819598716423"},

            // Hard board
            {"012400907000600002500092004008000019405800000700000000003100800000504020000700300",
             "312485967849671532567392184638257419495816273721943658273169845986534721154728396"},

            // Extreme board
            {"000000300010093406009010000001039800200040000070200500000000200040000035723000060",
             "482675391517893426369412758651739842238541679974286513195364287846127935723958164"},
        };

        // 16x16 boards test samples.
        private readonly Dictionary<string, string> _sudokuBoards16 = new Dictionary<string, string>()
        {
            // Empty board            
            {"0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000",
             "123456789:;<=>?@9:;<1234=>?@56785678=>?@12349:;<=>?@9:;<5678123431427586;9>:?<@=;9>:3142?<@=75867586?<@=3142;9>:?<@=;9>:7586314224136857:?9;<@=>:?9;2413<@=>68576857<@=>2413:?9;<@=>:?9;6857241343218765>;:9@=<?>;:94321@=<?87658765@=<?4321>;:9@=<?>;:987654321"},
            
            // Easy board            
            {"<0053=0020;000>000>000200=009?1;0200100>050@0070@00;4006000<00305000700=0@604<000?9=000200010085000@08>0030?00=030085<00=00000200800000100<9500@0;0080400?50:000=500?000@00067;000?102<0:008000=0<009000>002?0030>00;0=0100:00<0;6:90030070008000700060<00432001",
             "<9853=?:21;7@6>4:3>7<52@4=869?1;?2461;8>953@<=7:@=1;4976?:><853251;2739=8@6>4<:?>?9=@4627<:1;38564<@:8>;532?19=73:785<1?=49;>@26486:=7;13><952?@7;2>8@436?5=:19<=53<?>:9@21467;89@?162<5:;783>4=1<@49:57>8=2?;632>53;?=816@:74<9;6:92134<7?5=8@>87=?>6@<;9432:51"},

            // Medium board
            {"0000000?>009000000@000000<0?00>759>700031000:000002<00054@030=1;600@00;0020:7590700>04@6000000?0000000000406;000000;020:00050340200070906000008008=0002050>0@600@034001;0020>709>709600@0=1;200?40000800<000000000000000;001000:?00:0759@00000080;80<:0205904060",
             "=1;82<:?>75934@634@61;8=2<:?59>759>74@631;8=:?2<:?2<9>754@638=1;634@=1;8?2<:759>759>34@6=1;8<:?2<:?259>734@6;8=18=1;?2<:9>75634@2<:?759>634@1;8=;8=1:?2<59>7@634@6348=1;:?2<>759>759634@8=1;2<:?4@63;8=1<:?29>759>75@634;8=1?2<:?2<:>759@634=1;81;8=<:?2759>4@63"},

            // Hard board
            {"0001000070<;00033000800?040000000000003:0100500=000070000000800?005400@<069300010002=000070<3:0900:0002000000;000;00:0008010000>2000>=00<00090:069000?000054@<;000;70060?0010=000>=00;0000691002021?4>=000;0000:069000?80>=50@<070<090:60?004000000=@0;0000600?0",
             "?82154>=7@<;:6933:69821?54>=;7@<;7@<693:21?854>==54>7@<;693:821?>=54;7@<:693?8211?82=54>;7@<3:6993:6?821=54><;7@<;7@:693821?=54>21?8>=54<;7@93:6693:1?82>=54@<;7@<;73:69?821>=544>=5<;7@3:691?82821?4>=5@<;7693::69321?84>=57@<;7@<;93:61?824>=554>=@<;793:621?8"},

            // Extreme Board
            {"?:060<080050027000040000200@0?010;000000000040000030:0608=<00000054000007002?0<600090@07:060005070@0000:050090000000008=0300001030006270040000>000200?00500=030000?008000@9;71005>0=00;00000:<40>90020306071008:@000?700400<0>0=0000000400000000080<0=0>@0;01007",
             "?:16=<489;5>@2738=<4;5>9273@6?:19;5>73@2?:1648=<273@:16?8=<4>9;5=5483>9;71@2?:<6;3>91@27:<6?8=5471@2<6?:=5489;3>:<6?548=;3>9271@3@9;6271<4?:=5>816274?:<5>8=;3@9<4?:>8=53@9;71625>8=@9;31627:<4?>9=52;3@6?71<48:@2;3?71648:<5>9=6?718:<4>9=53@2;48:<9=5>@2;316?7"},
        };


        // 25x25 boards test samples.
        private readonly Dictionary<string, string> _sudokuBoards25 = new Dictionary<string, string>()
        {
            // Empty board
            {"0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000",
             "123456789:;<=>?@ABCDEFGHI;<=>?12345@ABCDFGEHI6789:6789:HIFEG12345;<=>?@ABCDGFEIH@ABCD6789:12345;<=>?@ABCD;<=>?HEGFI6789:123453152>C@D7;B?EHG8:IF<49A=648:6B31GH2=FI<>9@C;A5?DE7H?I7<459=631@A2BD>EG8:F;C9C;DE8FIA>45:7631?=2BH@<G=GAF@:?EB<89D;C45H7631>I2251?3>=AI8G@C:B<H;D974E6F7@6;42B153<HA8F>EG:=DIC?9<IGE8746;92D153A?FBC>=H:@>DCH9FG:@E746?=2I153<8;ABA:FB=<H?DC>I;E97468@2G153C6412IE;<HDB9G8?>@AF:573=5=937A8214FCHI;:BDGE?6<@>?BDGA5673@:>214C=9<HFEI8;F><@;B:C?=5673EI8214AD9GH:EH8ID9>GF?=<@A5673;CB214B3251?D48IA:F=HG;<@>9C67EI47=693@21CG>D<EF:?8H;5BAD;?<CG>567E3421H9AIB=@:F889@AFECH:BI;567=3421G>?D<EH>:G=;<FA98?B@DC567I3421"},

            // Extreme board
            {"0001?G;00900>0D0400=0000000000@00DH0003=EA00200700>60H04C3=0E005200B0800:<9C00F40I50E0?B7000;:0@060HI500A0B081900:<H@>600C0=07810;>0<9G006000030F052E00<00000DH@403=00B52E;001?60H0CI30040B520?008000<000=F00B52E000780G>000060H@50EA0;0810G>:0900000I000420AB008000>6<9000D000000I810;:6<0G>0000@I50F402E0B<0G>6300@00500400200:81?;DH@000=000002EA;:01?009G0=F00070EA00:81?00<0G300@0E00780000:6D00>000002F0051000009G>630H@C0204000AB090>0D=00C05004I000AB010;00@00=2F0I070EA00<0?00900000I5280A00:<10;000G>00@C30C0=F00I020000700?;:00>604I50E0A078<9?00D0G>0F0000AB0010?00<0H0060F@03E40520;009HG>60=0@C30E0I000070G>0DHF0C302E0I000AB090;:<",
             "B781?G;:<9H@>6DF4C3=AI52E;:<9G@>6DHF4C3=EAI52?B781>6DH@4C3=FEAI521?B78G;:<9C3=F4AI52E1?B789G;:<@>6DHI52EA?B7819G;:<H@>6D4C3=F781?;>:<9G@C6DH4I3=FB52EA:<9G>C6DH@4I3=FAB52E;781?6DH@CI3=F4AB52E?;781>:<9G3=F4IB52EA?;781G>:<9C6DH@52EAB;781?G>:<9@C6DHI3=F42EAB7:81?;>6<9GC3DH@5=F4I81?;:6<9G>C3DH@I5=F472EAB<9G>63DH@CI5=F4B72EA:81?;DH@C35=F4IB72EA;:81?6<9G>=F4I572EAB;:81?>6<9G3DH@CEAB78<1?;:6D9G>3=H@C2F4I51?;:<D9G>63=H@C52F4I8EAB79G>6D=H@C352F4I78EAB<1?;:H@C3=2F4I578EAB:<1?;D9G>6F4I528EAB7:<1?;6D9G>=H@C3@C3=FE4I5281AB7<9?;:HG>6D4I52E1AB78<9?;:DHG>6F@C3=AB7819?;:<DHG>6=F@C3E4I52?;:<9HG>6D=F@C32E4I51AB78G>6DHF@C3=2E4I581AB79?;:<"}
        };

        // Unsolvable boards test samples.
        private readonly List<string> _unsolvableSudokuBoards = new List<string>()
        {                
            // Unsolvable 9x9 board
            "000000000900000000120000034400000003000201000000004010000000000390102000080400000",
                        
            // Unsolvable 16x16 board
            "7090804=05030000=8?00<5000009020@0<070000020?008006;10>2?0=00500800004=00@0<00100000<0@7;016>20000006;00>0000=3?000:0>00000?0000?00000000700000000000006009;28?>0000;:0028?>03<40001>08?=000@0050000000080003<500:0900040<000000420?=005000019000000076010>:0?02"
        };


        // Test for all difficulty levels 9x9 sudokus.
        [TestMethod]
        public void Solvable9x9()
        {
            foreach (string sudokuString in _sudokuBoards9.Keys)
            {
                // Arrange test
                SudokuHandler handler = new SudokuHandler(sudokuString);
                string solvedString = "";

                //Act test
                handler.GetSolvedSudoku(ref solvedString);

                //Assert test
                Assert.AreEqual(_sudokuBoards9[sudokuString], solvedString);
            }
        }

        // Test for all difficulty levels 16x16 sudokus.
        [TestMethod]
        public void Solvable16x16()
        {
            foreach (string sudokuString in _sudokuBoards16.Keys)
            {
                // Arrange test
                SudokuHandler handler = new SudokuHandler(sudokuString);
                string solvedString = "";

                // Act test
                handler.GetSolvedSudoku(ref solvedString);

                // Assert test
                Assert.AreEqual(_sudokuBoards16[sudokuString], solvedString);
            }
        }

        // Test for empty and extreme 25x25 sudokus.
        [TestMethod]
        public void Solvable25x25()
        {
            foreach (string sudokuString in _sudokuBoards25.Keys)
            {
                // Arrange test
                SudokuHandler handler = new SudokuHandler(sudokuString);
                string solvedString = "";

                // Act test
                handler.GetSolvedSudoku(ref solvedString);

                // Assert test
                Assert.AreEqual(_sudokuBoards25[sudokuString], solvedString);
            }
        }

        // Test for unsolable sudokus.
        [TestMethod]
        public void Unsolvable()
        {
            foreach (string sudokuString in _unsolvableSudokuBoards)
            {
                // Arrange test
                SudokuHandler handler = new SudokuHandler(sudokuString);
                string solvedString = "";

                // Act test
                handler.GetSolvedSudoku(ref solvedString);

                // Assert test
                // For unsolvable sudokus, the string result representation is an empty string.
                Assert.AreEqual("", solvedString);
            }
        }

        // Test for already solved sudoku.
        [TestMethod]
        public void AlreadySolvedSudoku()
        {
            // Arrange test
            string sudokuString = "693741852482659731715832649257984163846173925931526478579268314368415297124397586";
            SudokuHandler handler = new SudokuHandler(sudokuString);
            string solvedString = "";

            // Act test
            handler.GetSolvedSudoku(ref solvedString);

            // Assert test
            Assert.AreEqual(sudokuString, solvedString);
        }

    }
}
