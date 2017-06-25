using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Cookie.API.Game.World.Pathfinding
{
    public class Dofus1Line
    {
        // Methods
        public static ArrayList GetLine(int x1, int y1, int x2, int y2)
        {
            var num = 0;
            Point3D pointd = null;
            Point point = null;
            var num2 = 0;
            var num3 = 0;
            double d = 0;
            double a = 0;
            double num6 = 0;
            double num7 = 0;
            double num8 = 0;
            double num9 = 0;
            double num10 = 0;
            double num11 = 0;
            uint num12 = 0;
            uint num13 = 0;
            var list = new ArrayList();
            var pointd2 = new Point3D(Convert.ToDouble(x1), Convert.ToDouble(y1), 0);
            var pointd3 = new Point3D(Convert.ToDouble(x2), Convert.ToDouble(y2), 0);
            pointd = new Point3D(pointd2.X + 0.5, pointd2.Y + 0.5, pointd2.Z);
            var pointd4 = new Point3D(pointd3.X + 0.5, pointd3.Y + 0.5, pointd3.Z);
            double num14 = 0;
            double num15 = 0;
            double num16 = 0;
            var list2 = new ArrayList();
            var list3 = new ArrayList();
            uint num17 = 0;
            if (Math.Abs(Convert.ToDouble(pointd.X - pointd4.X)) == Math.Abs(Convert.ToDouble(pointd.Y - pointd4.Y)))
            {
                num16 = Math.Abs(Convert.ToDouble(pointd.X - pointd4.X));
                num14 = pointd4.X > pointd.X ? Convert.ToDouble(1) : Convert.ToDouble(-1);
                num15 = pointd4.Y > pointd.Y ? Convert.ToDouble(1) : Convert.ToDouble(-1);
                var num1 = num16 == 0 ? 0 : (pointd3.Z - pointd2.Z) / num16;
                num17 = 1;
            }
            else if (Math.Abs(Convert.ToDouble(pointd.X - pointd4.X)) >
                     Math.Abs(Convert.ToDouble(pointd.Y - pointd4.Y)))
            {
                num16 = Math.Abs(Convert.ToDouble(pointd.X - pointd4.X));
                num14 = pointd4.X > pointd.X ? Convert.ToDouble(1) : Convert.ToDouble(-1);
                num15 = pointd4.Y > pointd.Y
                    ? Math.Abs(Convert.ToDouble(pointd.Y - pointd4.Y)) == 0
                        ? 0
                        : Math.Abs(Convert.ToDouble(pointd.Y - pointd4.Y)) / num16
                    : -Math.Abs(Convert.ToDouble(pointd.Y - pointd4.Y)) / num16;
                num15 = num15 * 100;
                num15 = Math.Ceiling(num15) / 100;
                var num18 = num16 == 0 ? 0 : (pointd3.Z - pointd2.Z) / num16;
                num17 = 2;
            }
            else
            {
                num16 = Math.Abs(Convert.ToDouble(pointd.Y - pointd4.Y));
                num14 = pointd4.X > pointd.X
                    ? Math.Abs(Convert.ToDouble(pointd.X - pointd4.X)) == 0
                        ? 0
                        : Math.Abs(Convert.ToDouble(pointd.X - pointd4.X)) / num16
                    : -Math.Abs(Convert.ToDouble(pointd.X - pointd4.X)) / num16;
                num14 = num14 * 100;
                num14 = Math.Ceiling(num14) / 100;
                num15 = pointd4.Y > pointd.Y ? Convert.ToDouble(1) : Convert.ToDouble(-1);
                var num19 = num16 == 0 ? 0 : (pointd3.Z - pointd2.Z) / num16;
                num17 = 3;
            }
            for (num = 0; num <= num16 - 1; num++)
            {
                num2 = Convert.ToInt32(Math.Round(Math.Floor(Convert.ToDouble(3 + num16 / 2))));
                num3 = Convert.ToInt32(Math.Round(Math.Floor(Convert.ToDouble(97 - num16 / 2))));
                switch (num17)
                {
                    case 2:
                        d = Math.Ceiling(Convert.ToDouble(pointd.Y * 100 + num15 * 50)) / 100;
                        a = Math.Floor(Convert.ToDouble(pointd.Y * 100 + num15 * 150)) / 100;
                        num6 = Math.Floor(Math.Abs(Convert.ToDouble(Math.Floor(d) * 100 - d * 100))) / 100;
                        num7 = Math.Ceiling(Math.Abs(Convert.ToDouble(Math.Ceiling(a) * 100 - a * 100))) / 100;
                        if (Math.Floor(d) == Math.Floor(a))
                        {
                            list3 = smethod_0(new object[] {Math.Floor(Convert.ToDouble(pointd.Y + num15))});
                            if (d == (double) list3[0] && a < (double) list3[0])
                                list3 = smethod_0(new object[] {Math.Ceiling(Convert.ToDouble(pointd.Y + num15))});
                            else if (d == (double) list3[0] && a > (double) list3[0])
                                list3 = smethod_0(new object[] {Math.Floor(Convert.ToDouble(pointd.Y + num15))});
                            else if (a == (double) list3[0] && d < (double) list3[0])
                                list3 = smethod_0(new object[] {Math.Ceiling(Convert.ToDouble(pointd.Y + num15))});
                            else if (a == (double) list3[0] && d > (double) list3[0])
                                list3 = smethod_0(new object[] {Math.Floor(Convert.ToDouble(pointd.Y + num15))});
                        }
                        else if (Math.Ceiling(d) == Math.Ceiling(a))
                        {
                            list3 = smethod_0(new object[] {Math.Ceiling(Convert.ToDouble(pointd.Y + num15))});
                            if (d == (double) list3[0] && a < (double) list3[0])
                                list3 = smethod_0(new object[] {Math.Floor(Convert.ToDouble(pointd.Y + num15))});
                            else if (d == (double) list3[0] && a > (double) list3[0])
                                list3 = smethod_0(new object[] {Math.Ceiling(Convert.ToDouble(pointd.Y + num15))});
                            else if (a == (double) list3[0] && d < (double) list3[0])
                                list3 = smethod_0(new object[] {Math.Floor(Convert.ToDouble(pointd.Y + num15))});
                            else if (a == (double) list3[0] && d > (double) list3[0])
                                list3 = smethod_0(new object[] {Math.Ceiling(Convert.ToDouble(pointd.Y + num15))});
                        }
                        else if (Math.Floor(Convert.ToDouble(num6 * 100)) <= num2)
                        {
                            var list4 = new ArrayList();
                            list4.Add(Math.Floor(a));
                            list3 = list4;
                        }
                        else if (Math.Floor(Convert.ToDouble(num7 * 100)) >= num3)
                        {
                            var list5 = new ArrayList();
                            list5.Add(Math.Floor(d));
                            list3 = list5;
                        }
                        else
                        {
                            var list6 = new ArrayList();
                            list6.Add(Math.Floor(d));
                            list6.Add(Math.Floor(a));
                            list3 = list6;
                        }
                        break; // TODO: might not be correct. Was : Exit Select
                    case 3:
                        num8 = Math.Ceiling(Convert.ToDouble(pointd.X * 100 + num14 * 50)) / 100;
                        num9 = Math.Floor(Convert.ToDouble(pointd.X * 100 + num14 * 150)) / 100;
                        num10 = Math.Floor(Math.Abs(Convert.ToDouble(Math.Floor(num8) * 100 - num8 * 100))) / 100;
                        num11 = Math.Ceiling(Math.Abs(Convert.ToDouble(Math.Ceiling(num9) * 100 - num9 * 100))) / 100;
                        if (Math.Floor(num8) == Math.Floor(num9))
                        {
                            list2 = smethod_0(new object[] {Math.Floor(Convert.ToDouble(pointd.X + num14))});
                            if (num8 == (double) list2[0] && num9 < (double) list2[0])
                                list2 = smethod_0(new object[] {Math.Ceiling(Convert.ToDouble(pointd.X + num14))});
                            else if (num8 == (double) list2[0] && num9 > (double) list2[0])
                                list2 = smethod_0(new object[] {Math.Floor(Convert.ToDouble(pointd.X + num14))});
                            else if (num9 == (double) list2[0] && num8 < (double) list2[0])
                                list2 = smethod_0(new object[] {Math.Ceiling(Convert.ToDouble(pointd.X + num14))});
                            else if (num9 == (double) list2[0] && num8 > (double) list2[0])
                                list2 = smethod_0(new object[] {Math.Floor(Convert.ToDouble(pointd.X + num14))});
                        }
                        else if (Math.Ceiling(num8) == Math.Ceiling(num9))
                        {
                            list2 = smethod_0(new object[] {Math.Ceiling(Convert.ToDouble(pointd.X + num14))});
                            if (num8 == (double) list2[0] && num9 < (double) list2[0])
                                list2 = smethod_0(new object[] {Math.Floor(Convert.ToDouble(pointd.X + num14))});
                            else if (num8 == (double) list2[0] && num9 > (double) list2[0])
                                list2 = smethod_0(new object[] {Math.Ceiling(Convert.ToDouble(pointd.X + num14))});
                            else if (num9 == (double) list2[0] && num8 < (double) list2[0])
                                list2 = smethod_0(new object[] {Math.Floor(Convert.ToDouble(pointd.X + num14))});
                            else if (num9 == (double) list2[0] && num8 > (double) list2[0])
                                list2 = smethod_0(new object[] {Math.Ceiling(Convert.ToDouble(pointd.X + num14))});
                        }
                        else if (Math.Floor(Convert.ToDouble(num10 * 100)) <= num2)
                        {
                            list2 = smethod_0(new object[] {num9});
                        }
                        else if (Math.Floor(Convert.ToDouble(num11 * 100)) >= num3)
                        {
                            list2 = smethod_0(new object[] {num8});
                        }
                        else
                        {
                            list2 = smethod_0(new object[]
                            {
                                num8,
                                num9
                            });
                        }
                        break; // TODO: might not be correct. Was : Exit Select
                }
                if (list3.Count > 0)
                {
                    num12 = 0;
                    while (num12 < list3.Count)
                    {
                        point = new Point(Math.Floor(Convert.ToDouble(pointd.X + num14)),
                            Convert.ToDouble(list3[Convert.ToInt32(num12)]));
                        list.Add(point);
                        num12 = num12 + 1;
                    }
                }
                else if (list2.Count > 0)
                {
                    num13 = 0;
                    while (num13 < list2.Count)
                    {
                        point = new Point(Convert.ToDouble(list2[Convert.ToInt32(num13)]),
                            Math.Floor(Convert.ToDouble(pointd.Y + num15)));
                        list.Add(point);
                        num13 = num13 + 1;
                    }
                }
                else if (num17 == 1)
                {
                    point = new Point(Math.Floor(Convert.ToDouble(pointd.X + num14)),
                        Math.Floor(Convert.ToDouble(pointd.Y + num15)));
                    list.Add(point);
                }
                pointd.X = (pointd.X * 100 + num14 * 100) / 100;
                pointd.Y = (pointd.Y * 100 + num15 * 100) / 100;
            }
            return list;
        }

        private static ArrayList smethod_0(object[] object_0)
        {
            var list = new ArrayList();
            list.AddRange(object_0);
            return list;
        }


        // Nested Types
        public class Point
        {
            // Fields
            [CompilerGenerated] private double double_0;

            [CompilerGenerated] private double double_1;

            // Methods
            public Point(double X, double Y)
            {
                this.X = X;
                this.Y = Y;
            }


            // Properties
            public double X
            {
                get => double_0;
                set => double_0 = value;
            }

            public double Y
            {
                get => double_1;
                set => double_1 = value;
            }
        }

        public class Point3D
        {
            // Fields
            [CompilerGenerated] private double double_0;

            [CompilerGenerated] private double double_1;

            [CompilerGenerated] private double double_2;

            // Methods
            public Point3D(double X, double Y, double Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }


            // Properties
            public double X
            {
                get => double_0;
                set => double_0 = value;
            }

            public double Y
            {
                get => double_1;
                set => double_1 = value;
            }

            public double Z
            {
                get => double_2;
                set => double_2 = value;
            }
        }
    }
}