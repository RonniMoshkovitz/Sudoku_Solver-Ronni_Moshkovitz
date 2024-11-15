﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku_Solver___Ronni_Moshkovitz.SudokuHandling;
using System.Collections.Generic;


namespace UnitTesting
{
    // This class, SudokuSolvingTesting, preforms unit testing for different given sudoku situations.
    [TestClass]
    public class SudokuSolvingTesting
    {

        // 4x4 boards test samples.
        private readonly Dictionary<string, string> _sudokuBoards4 = new Dictionary<string, string>()
        {
            // Empty board
            {"0000000000000000",
             "1234341221434321"},

            // Easy board
            {"1302000101230214",
             "1342243141233214"},

            // Medium board
            {"4003010023001402",
             "4213312423411432"},

            // Hard board
            {"0010000200042001",
             "4213134231242431"},

            // Extreme board
            {"1000020000300000",
             "1324421324313142"},

        };

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

            // Easy board
            {"E0I20080<100:6C0=0;00570080<1000A:60@F0B>05002HE0000:6CB;@007G0D0000041300<;@F0007G0DE002H00000000A0700D5H00008?<1006C00000@0@>=0000I050<00000000C0A00G0D0004<000:1380C9A0B0@0=4000E8?000AF600=B;005700D0:10000F0C@>=B;D570IHE0020F6000@>=0G0D072HE0038000<00E4?0630F0C0A0;0>D0000506380A00C9>00;05700204<1H0=C0A00DB;I200GH000000:00>00;0GI057010E4080069A0=C0057000100:0300C0A000@>0B0C00:0=B0005;@>7G0204010E000AF>050@2000I040130:60000000I200G0304<80060A0=B90H00I<13E46C000000000005;10E40:0C80=000F00000G020750@>D0HE00084010:009F=B0000GI21380<00?:00F=00>D50@080000C00:0;000@>D07I0HEG00?:0=000F07@>DGI0H001380B0AF=007@>0EG0000038:609?",
             "E4I2H38?<19A:6CF=B;@D57G>8?<13C9A:6;@F=B>D57G2HE4I9A:6CB;@F=7G>D5I2HE4138?<;@F=B57G>DE4I2H<138?6C9A:7G>D5HE4I28?<13:6C9A=B;@F@>=B;7GID54<2HE138?:C9AF6GID57E4<2H?:1386C9AFB;@>=4<2HE8?:13AF6C9=B;@>57GID?:1389AF6C@>=B;D57GIHE4<2AF6C9;@>=BGID572HE4<38?:1<1HE4?:638F=C9AB;@>D7GI25:638?AF=C9>DB;@57GI2E4<1HF=C9A@>DB;I257GHE4<18?:63>DB;@GI257<1HE438?:69AF=CI257G4<1HE:638?C9AF=;@>DB6C8?:F=B9AD5;@>7GI2H4<13E=B9AF>D5;@2H7GIE4<13?:6C8D5;@>I2H7G13E4<8?:6CAF=B92H7GI<13E46C8?:9AF=B@>D5;13E4<:6C8?=B9AF;@>D5GI2H757@>D2HEGI384<1?:6C9F=B;AHEGI21384<C9?:6AF=B;>D57@384<16C9?:B;AF=@>D57I2HEGC9?:6=B;AF57@>DGI2HE<1384B;AF=D57@>HEGI24<138:6C9?"},

            // Medium board
            {"GF2=00013@0H000A4BE?9<>;8<>;89=5GF2@CD13I0000BE?A4B0000;800>02=0003@00:H67I:H000?A00E<>0005GF2000CD130CD000000BE?00000>;002=000000007I:4B0000000000F2=00000@CD0000H67?000000<>;000002=5G000000000H64000A4BE?A>;89<00005D03@0I:007I0007E004B90008=5GF213@000I:H0000A4000>;0=500D1000D10000H67IA4B0000000=5GF2=5GF23@0007I:H00004B;89<0000000000G1300000I:H04BE004BE?<>0005GF2=0000@7I:H6?00000000005GF2@000000I:H67I:0000?A;89<>F00000013@C003@I0H600A4000>;800=5GF00000000CD67I:HB000000000089<>GF2=5D1000067I:?A00002=50D1300H67I:000000>;890;89<0000=CD13@:00000000BE?A4000<>;2=0003@001H6700007I0A400?>;09<G00=5@00130001370000E?A009<>;002=5G",
             "GF2=5CD13@:H67IA4BE?9<>;8<>;89=5GF2@CD13I:H67BE?A4BE?A4;89<>F2=5G13@CD:H67I:H67I?A4BE<>;895GF2=3@CD13@CD167I:HBE?4A89<>;GF2=513@CDH67I:4BEA?;89<>5GF2=2=5GF@CD13I:H67?B4AE89<>;89<>;2=5GF3@CD17I:H64BE?A4BE?A>;89<GF2=5D13@CI:H67I:H67E?A4B9<>;8=5GF213@CD7I:H6BE?A489<>;2=5GFD13@CD13@C:H67IA4B?E>;89<=5GF2=5GF23@CD17I:H6E?A4B;89<>9<>;8F2=5G13@CD67I:HA4BE?A4BE?<>;895GF2=CD13@7I:H6?A4BE9<>;8=5GF2@CD1367I:H67I:H4BE?A;89<>F2=5GCD13@CD13@I:H67?A4EB<>;892=5GF5GF2=13@CD67I:HBAE?4>;89<;89<>GF2=5D13@CH67I:?A4BE@2=5GD13ECH67I:4F?BA<>;89>;89<5GF2=CD13@:H67IE?A4BE?A4B89<>;2=5GF3@CD1H67I:F67I:A4BH?>;89<GE2=5@CD13HCD137I:@6E?AB49<>;8F2=5G"},

            // Hard board
            {"0E0?0000050FI009>04G200:A0A0B@0001?57086H00=0409>00C00000020?000150006=0HF00I=009>00GB00000<0000007;0080000I=000>04B@:A0E10<350;0600F0=4000C2B00000000<000007;060HF00G90000000:0:02B0<300600000H0I000G0>9>040B@00000<00050;0I=000HF000G90002B@0010030;0607G9>C4000:A01?<3800700I0DH0HF0=0000C02000E10<000800650080DH00C0G00A0B@0<3E00?03E065708=D00000900002B0B00000?0000607;=00FI004091?03E80000I=D0000G00@:02B20@:000003006570=00F0004G000>CA000:001?<;86070F000=000IC0G000A0B@3000<50;0086070I0DHF000G0002000030100003;8000000D0>0409B0002000@:3E0?07;000FI00009>C000G00:00B000E1?000000000=0=0H0>C0090:00B<300?05700;0007F00DH000400:A0010030",
             "3E1?<7;865HFI=D9>C4G2B@:A:A2B@<3E1?57;86HFI=D4G9>C>C4G9@:A2B?<3E157;86=DHFIFI=DH9>C4GB@:A2?<3E18657;7;865HFI=DG9>C4B@:A2E1?<357;86DHFI=4G9>C2B@:A3E1?<<3E1?57;86DHFI=G9>C4A2B@:@:A2B?<3E1657;8DHFI=C4G9>9>C4GB@:A21?<3E657;8I=DHFHFI=DG9>C42B@:A1?<3E;8657G9>C42B@:AE1?<38657;FI=DHDHFI=4G9>CA2B@:E1?<37;865657;8=DHFIC4G9>A2B@:<3E1??<3E1657;8=DHFI4G9>C:A2B@B@:A21?<3E8657;=DHFI>C4G91?<3E8657;I=DHFC4G9>@:A2B2B@:AE1?<3;8657I=DHF9>C4G4G9>CA2B@:3E1?<;8657HFI=D=DHFIC4G9>:A2B@3E1?<57;868657;I=DHF>C4G9:A2B@?<3E1E1?<3;8657FI=DH>C4G9B@:A2A2B@:3E1?<7;865FI=DHG9>C4C4G9>:A2B@<3E1?7;865DHFI=I=DHF>C4G9@:A2B<3E1?657;8;8657FI=DH9>C4G@:A2B1?<3E"},

            // Extreme board
            {"0001?G;00900>0D0400=0000000000@00DH0003=EA00200700>60H04C3=0E005200B0800:<9C00F40I50E0?B7000;:0@060HI500A0B081900:<H@>600C0=07810;>0<9G006000030F052E00<00000DH@403=00B52E;001?60H0CI30040B520?008000<000=F00B52E000780G>000060H@50EA0;0810G>:0900000I000420AB008000>6<9000D000000I810;:6<0G>0000@I50F402E0B<0G>6300@00500400200:81?;DH@000=000002EA;:01?009G0=F00070EA00:81?00<0G300@0E00780000:6D00>000002F0051000009G>630H@C0204000AB090>0D=00C05004I000AB010;00@00=2F0I070EA00<0?00900000I5280A00:<10;000G>00@C30C0=F00I020000700?;:00>604I50E0A078<9?00D0G>0F0000AB0010?00<0H0060F@03E40520;009HG>60=0@C30E0I000070G>0DHF0C302E0I000AB090;:<",
             "B781?G;:<9H@>6DF4C3=AI52E;:<9G@>6DHF4C3=EAI52?B781>6DH@4C3=FEAI521?B78G;:<9C3=F4AI52E1?B789G;:<@>6DHI52EA?B7819G;:<H@>6D4C3=F781?;>:<9G@C6DH4I3=FB52EA:<9G>C6DH@4I3=FAB52E;781?6DH@CI3=F4AB52E?;781>:<9G3=F4IB52EA?;781G>:<9C6DH@52EAB;781?G>:<9@C6DHI3=F42EAB7:81?;>6<9GC3DH@5=F4I81?;:6<9G>C3DH@I5=F472EAB<9G>63DH@CI5=F4B72EA:81?;DH@C35=F4IB72EA;:81?6<9G>=F4I572EAB;:81?>6<9G3DH@CEAB78<1?;:6D9G>3=H@C2F4I51?;:<D9G>63=H@C52F4I8EAB79G>6D=H@C352F4I78EAB<1?;:H@C3=2F4I578EAB:<1?;D9G>6F4I528EAB7:<1?;6D9G>=H@C3@C3=FE4I5281AB7<9?;:HG>6D4I52E1AB78<9?;:DHG>6F@C3=AB7819?;:<DHG>6=F@C3E4I52?;:<9HG>6D=F@C32E4I51AB78G>6DHF@C3=2E4I581AB79?;:<"}
        };

        // Unsolvable boards test samples.
        private readonly List<string> _unsolvableSudokuBoards = new List<string>()
        {            
            // Unsolvable 4x4 board
            "3040012320000012",

            // Unsolvable 9x9 board
            "000000000900000000120000034400000003000201000000004010000000000390102000080400000",
                        
            // Unsolvable 16x16 board
            "7090804=05030000=8?00<5000009020@0<070000020?008006;10>2?0=00500800004=00@0<00100000<0@7;016>20000006;00>0000=3?000:0>00000?0000?00000000700000000000006009;28?>0000;:0028?>03<40001>08?=000@0050000000080003<500:0900040<000000420?=005000019000000076010>:0?02",

            // Unsolvable 25x25 board
            "0000020000000>I?07D=050A495H000F0<C0200G080I30D0007000BH0495000:0200G0>03E803E0>?B00=00400F0<00G600@060;0E0>0000070A4000<010:B0D0?500490000:620@G8>00E00000=00700HA000F0<00002;0000;300>I0=00700000:0C00:<00000;@000E80=?000005H0405H00100<060003080IB7D008>I30D000095H00C100<00G000@062030800000B50A40F00C0F:<01000;0003E0D0?B7A090H0000H001F0@G62;030800000=0B70095000:<C0FG6200E0>I000B0D090HA0:<C10G60000000000I07D00B095HA<C10:0000000@060I000B0D0000H0000:0C0F:000060;0>0307D00000090H00900001F0000200008=0070C10000@G02E8>I3B0D005004000A000:<000;0G00>0000=0B00=?07A09000F000;000000E000080IB700?0405H0<C0F00;@G020@000I0E?00D0405HA00700"
        };


        // Test for 1x1 empty sudoku.
        [TestMethod]
        public void Solvable1x1()
        {
            // Arrange test
            string sudokuString = "0";
            SudokuHandler handler = new SudokuHandler(sudokuString);
            string solvedString = "";

            // Act test
            handler.GetSolvedSudoku(ref solvedString);

            // Assert test
            Assert.AreEqual("1", solvedString);
        }

        // Test for all difficulty levels 4x4 sudokus.
        [TestMethod]
        public void Solvable4x4()
        {
            foreach (string sudokuString in _sudokuBoards4.Keys)
            {
                // Arrange test
                SudokuHandler handler = new SudokuHandler(sudokuString);
                string solvedString = "";

                //Act test
                handler.GetSolvedSudoku(ref solvedString);

                //Assert test
                Assert.AreEqual(_sudokuBoards4[sudokuString], solvedString);
            }
        }

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
