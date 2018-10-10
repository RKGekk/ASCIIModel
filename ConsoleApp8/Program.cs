using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//домашнее задание Архангельского Олег Анатольевича
//Задание №3 доп
//3. Прочитать из файла точки и вывести в консоль
namespace ReadMS3D {
    class Program {

        static void print(Char c, int x, int y) {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        static void print(Char c, int x, int y, ConsoleColor color) {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }

        static void print(Char c, int x, int y, Color8 color) {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = Color8.FromColor(color);
            Console.Write(c);
        }

        static void print(Char c, float x, float y, Color8 color) {
            Console.SetCursorPosition((int)x, (int)y);
            Console.ForegroundColor = Color8.FromColor(color);
            Console.Write(c);
        }

        static void render(Color8[,] buf, float[,] zbuff) {
            for (int y = 25; y != 0; --y) {
                for (int x = 80; x != 0; --x) {
                    print('*', x - 1, y - 1, buf[x - 1, y - 1]);
                }
            }
        }

        static void printLine(Color8 color, int x0, int y0, int x1, int y1) {

            int dx = Math.Abs(x1 - x0);
            int sx = x0 < x1 ? 1 : -1;

            int dy = Math.Abs(y1 - y0);
            int sy = y0 < y1 ? 1 : -1;

            int err = (dx > dy ? dx : -dy) / 2;
            int e2;

            for (; ; ) {

                print('*', x0, y0, color);
                if (x0 == x1 && y0 == y1) {
                    break;
                }
                e2 = err;
                if (e2 > -dx) {
                    err -= dy;
                    x0 += sx;
                }
                if (e2 < dy) {
                    err += dx;
                    y0 += sy;
                }
            }
        }

        static void printLine(Color8[,] buf, float[,] zbuff, int x0, int y0, int x1, int y1, Color8 color) {

            int dx = Math.Abs(x1 - x0);
            int sx = x0 < x1 ? 1 : -1;

            int dy = Math.Abs(y1 - y0);
            int sy = y0 < y1 ? 1 : -1;

            int err = (dx > dy ? dx : -dy) / 2;
            int e2;

            for (; ; ) {
                if (x0 >= buf.GetLength(0) || y0 >= buf.GetLength(1) || x0 < 0 || y0 < 0)
                    break;

                buf[x0, y0] = color;

                if (x0 == x1 && y0 == y1) {
                    break;
                }
                e2 = err;
                if (e2 > -dx) {
                    err -= dy;
                    x0 += sx;
                }
                if (e2 < dy) {
                    err += dx;
                    y0 += sy;
                }
            }
        }

        static void clearScreen(Color8[,] buf, float[,] zbuff) {
            for (int y = 25; y != 0; --y) {
                for (int x = 80; x != 0; --x) {
                    buf[x - 1, y - 1] = new Color8(0, 0, 0);
                }
            }
        }

        static void Main(string[] args) {

            MilkShapeObject obj = new MilkShapeObject();
            //obj.LoadFromFile("triangle.ms3d");
            //obj.LoadFromFile("cube.ms3d");
            obj.LoadFromFile("tree.ms3d");
            //obj.LoadFromFile("doom.ms3d");

            Color8[,] screen = new Color8[80, 25];
            float[,] zbuffer = new float[80, 25];

            float angle = 0.0f;

            while (true) {
                clearScreen(screen, zbuffer);

                Mat4 model = new Mat4(
                    new Vec4(1.0f, 0.0f, 0.0f, 0.0f),
                    new Vec4(0.0f, 1.0f, 0.0f, 0.0f),
                    new Vec4(0.0f, 0.0f, 1.0f, 0.0f),
                    new Vec4(0.0f, 0.0f, 0.0f, 1.0f)
                );

                model = model * Mat4.RotationYMatrix(angle);

                Mat4 view = new Mat4(
                    new Vec4(1.0f, 0.0f, 0.0f, 0.0f),
                    new Vec4(0.0f, 1.0f, 0.0f, 0.0f),
                    new Vec4(0.0f, 0.0f, 1.0f, 0.0f),
                    new Vec4(0.0f, -30.0f, 70.0f, 1.0f)
                );

                Mat4 modelView = model * view;

                Mat4 proj = Mat4.ProjectionMatrix4(60.0f, 0.1f, 1000.0f);

                int numTriangles = obj.arrTriangles.Count;

                for (int i = 0; i < numTriangles; ++i) {

                    float x1 = obj.arrVertices[obj.arrTriangles[i].vertexIndices[0]].vertex[0];
                    float y1 = obj.arrVertices[obj.arrTriangles[i].vertexIndices[0]].vertex[1];
                    float z1 = obj.arrVertices[obj.arrTriangles[i].vertexIndices[0]].vertex[2];

                    Vec4 point1 = modelView * new Vec4(x1, y1, z1, 0.0f);
                    point1 = proj * point1;
                    point1.x = (point1.x + 1.0f) / 2.0f * 80.0f;
                    point1.y = (point1.y + 1.0f) / 2.0f * 25.0f;

                    float x2 = obj.arrVertices[obj.arrTriangles[i].vertexIndices[1]].vertex[0];
                    float y2 = obj.arrVertices[obj.arrTriangles[i].vertexIndices[1]].vertex[1];
                    float z2 = obj.arrVertices[obj.arrTriangles[i].vertexIndices[1]].vertex[2];

                    Vec4 point2 = modelView * new Vec4(x2, y2, z2, 0.0f);
                    point2 = proj * point2;
                    point2.x = (point2.x + 1.0f) / 2.0f * 80.0f;
                    point2.y = (point2.y + 1.0f) / 2.0f * 25.0f;

                    float x3 = obj.arrVertices[obj.arrTriangles[i].vertexIndices[2]].vertex[0];
                    float y3 = obj.arrVertices[obj.arrTriangles[i].vertexIndices[2]].vertex[1];
                    float z3 = obj.arrVertices[obj.arrTriangles[i].vertexIndices[2]].vertex[2];

                    Vec4 point3 = modelView * new Vec4(x3, y3, z3, 0.0f);
                    point3 = proj * point3;
                    point3.x = (point3.x + 1.0f) / 2.0f * 80.0f;
                    point3.y = (point3.y + 1.0f) / 2.0f * 25.0f;


                    printLine(screen, zbuffer,
                        (int)point1.x,
                        (int)point1.y,
                        (int)point2.x,
                        (int)point2.y,
                        new Color8(255, 255, 255)
                    );

                    printLine(screen, zbuffer,
                        (int)point2.x,
                        (int)point2.y,
                        (int)point3.x,
                        (int)point3.y,
                        new Color8(255, 255, 255)
                    );

                    printLine(screen, zbuffer,
                        (int)point3.x,
                        (int)point3.y,
                        (int)point1.x,
                        (int)point1.y,
                        new Color8(255, 255, 255)
                    );
                }

                render(screen, zbuffer);

                angle += (float)(Math.PI / 32.0f);
            }

            Console.ReadKey();
        }
    }
}
