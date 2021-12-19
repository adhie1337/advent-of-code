namespace AdventOfCode2021.Tests.Days.Day19
{
    using AdventOfCode2021.Days.Day19;

    public static class Example
    {
        public static readonly Scanner[] Simpler = new[]
        {
            new Scanner()
            {
                Id = 0,
                VisibleBeacons = new[]
                {
                    Beacon.At(1, 2, 0),
                    Beacon.At(8, 15, 0),
                    Beacon.At(10, 10, 0),
                    Beacon.At(12, 8, 0),
                }
            },
            new Scanner()
            {
                Id = 1,
                VisibleBeacons = new[]
                {
                    Beacon.At(1, 0, -1),
                    Beacon.At(-10, 0, 0),
                    Beacon.At(-8, 0, 5),
                    Beacon.At(-6, 0, 7),
                }
            },
            new Scanner()
            {
                Id = 3,
                VisibleBeacons = new[]
                {
                    Beacon.At(0, -10, -1),
                    Beacon.At(0, -5, -3),
                    Beacon.At(0, -4, 8),
                    Beacon.At(0, 0, -10),
                }
            },
        };

        public static readonly Scanner[] Scanners = new[]
        {
            new Scanner()
            {
                Id = 0,
                VisibleBeacons = new[]
                {
                    Beacon.At(404, -588, -901),
                    Beacon.At(528, -643, 409),
                    Beacon.At(-838, 591, 734),
                    Beacon.At(390, -675, -793),
                    Beacon.At(-537, -823, -458),
                    Beacon.At(-485, -357, 347),
                    Beacon.At(-345, -311, 381),
                    Beacon.At(-661, -816, -575),
                    Beacon.At(-876, 649, 763),
                    Beacon.At(-618, -824, -621),
                    Beacon.At(553, 345, -567),
                    Beacon.At(474, 580, 667),
                    Beacon.At(-447, -329, 318),
                    Beacon.At(-584, 868, -557),
                    Beacon.At(544, -627, -890),
                    Beacon.At(564, 392, -477),
                    Beacon.At(455, 729, 728),
                    Beacon.At(-892, 524, 684),
                    Beacon.At(-689, 845, -530),
                    Beacon.At(423, -701, 434),
                    Beacon.At(7, -33, -71),
                    Beacon.At(630, 319, -379),
                    Beacon.At(443, 580, 662),
                    Beacon.At(-789, 900, -551),
                    Beacon.At(459, -707, 401),
                }
            },
            new Scanner()
            {
                Id = 1,
                VisibleBeacons = new[]
                {
                    Beacon.At(686, 422, 578),
                    Beacon.At(605, 423, 415),
                    Beacon.At(515, 917, -361),
                    Beacon.At(-336, 658, 858),
                    Beacon.At(95, 138, 22),
                    Beacon.At(-476, 619, 847),
                    Beacon.At(-340, -569, -846),
                    Beacon.At(567, -361, 727),
                    Beacon.At(-460, 603, -452),
                    Beacon.At(669, -402, 600),
                    Beacon.At(729, 430, 532),
                    Beacon.At(-500, -761, 534),
                    Beacon.At(-322, 571, 750),
                    Beacon.At(-466, -666, -811),
                    Beacon.At(-429, -592, 574),
                    Beacon.At(-355, 545, -477),
                    Beacon.At(703, -491, -529),
                    Beacon.At(-328, -685, 520),
                    Beacon.At(413, 935, -424),
                    Beacon.At(-391, 539, -444),
                    Beacon.At(586, -435, 557),
                    Beacon.At(-364, -763, -893),
                    Beacon.At(807, -499, -711),
                    Beacon.At(755, -354, -619),
                    Beacon.At(553, 889, -390),
                }
            },
            new Scanner()
            {
                Id = 2,
                VisibleBeacons = new[]
                {
                    Beacon.At(649, 640, 665),
                    Beacon.At(682, -795, 504),
                    Beacon.At(-784, 533, -524),
                    Beacon.At(-644, 584, -595),
                    Beacon.At(-588, -843, 648),
                    Beacon.At(-30, 6, 44),
                    Beacon.At(-674, 560, 763),
                    Beacon.At(500, 723, -460),
                    Beacon.At(609, 671, -379),
                    Beacon.At(-555, -800, 653),
                    Beacon.At(-675, -892, -343),
                    Beacon.At(697, -426, -610),
                    Beacon.At(578, 704, 681),
                    Beacon.At(493, 664, -388),
                    Beacon.At(-671, -858, 530),
                    Beacon.At(-667, 343, 800),
                    Beacon.At(571, -461, -707),
                    Beacon.At(-138, -166, 112),
                    Beacon.At(-889, 563, -600),
                    Beacon.At(646, -828, 498),
                    Beacon.At(640, 759, 510),
                    Beacon.At(-630, 509, 768),
                    Beacon.At(-681, -892, -333),
                    Beacon.At(673, -379, -804),
                    Beacon.At(-742, -814, -386),
                    Beacon.At(577, -820, 562),
                }
            },
            new Scanner()
            {
                Id = 3,
                VisibleBeacons = new[]
                {
                    Beacon.At(-589, 542, 597),
                    Beacon.At(605, -692, 669),
                    Beacon.At(-500, 565, -823),
                    Beacon.At(-660, 373, 557),
                    Beacon.At(-458, -679, -417),
                    Beacon.At(-488, 449, 543),
                    Beacon.At(-626, 468, -788),
                    Beacon.At(338, -750, -386),
                    Beacon.At(528, -832, -391),
                    Beacon.At(562, -778, 733),
                    Beacon.At(-938, -730, 414),
                    Beacon.At(543, 643, -506),
                    Beacon.At(-524, 371, -870),
                    Beacon.At(407, 773, 750),
                    Beacon.At(-104, 29, 83),
                    Beacon.At(378, -903, -323),
                    Beacon.At(-778, -728, 485),
                    Beacon.At(426, 699, 580),
                    Beacon.At(-438, -605, -362),
                    Beacon.At(-469, -447, -387),
                    Beacon.At(509, 732, 623),
                    Beacon.At(647, 635, -688),
                    Beacon.At(-868, -804, 481),
                    Beacon.At(614, -800, 639),
                    Beacon.At(595, 780, -596),
                }
            },
            new Scanner()
            {
                Id = 4,
                VisibleBeacons = new[]
                {
                    Beacon.At(727, 592, 562),
                    Beacon.At(-293, -554, 779),
                    Beacon.At(441, 611, -461),
                    Beacon.At(-714, 465, -776),
                    Beacon.At(-743, 427, -804),
                    Beacon.At(-660, -479, -426),
                    Beacon.At(832, -632, 460),
                    Beacon.At(927, -485, -438),
                    Beacon.At(408, 393, -506),
                    Beacon.At(466, 436, -512),
                    Beacon.At(110, 16, 151),
                    Beacon.At(-258, -428, 682),
                    Beacon.At(-393, 719, 612),
                    Beacon.At(-211, -452, 876),
                    Beacon.At(808, -476, -593),
                    Beacon.At(-575, 615, 604),
                    Beacon.At(-485, 667, 467),
                    Beacon.At(-680, 325, -822),
                    Beacon.At(-627, -443, -432),
                    Beacon.At(872, -547, -609),
                    Beacon.At(833, 512, 582),
                    Beacon.At(807, 604, 487),
                    Beacon.At(839, -516, 451),
                    Beacon.At(891, -625, 532),
                    Beacon.At(-652, -548, -490),
                    Beacon.At(30, -46, -14),
                }
            },
        };
    }
}
