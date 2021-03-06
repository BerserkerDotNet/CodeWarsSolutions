﻿using Solutions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Solutions.PathFinder
{
    public class PathFinder:ISolution
    {
        public string DisplayName => "Path Finder";

        public bool CanYouExit(string mazeString)
        {
            var maze = new Maze(mazeString);
            return maze.Solve(0, 0);
        }

        public int ShortestPath(string mazeString)
        {
            var maze = new Maze(mazeString);
            return maze.ShortestPath((0, 0));
        }

        public void Execute(IHost host)
        {

            var mazeString = ".....W\n" +
           "....W.\n" +
           ".W.W..\n" +
           ".W..W.\n" +
           "..WWWW\n" +
           "......";
            Console.Clear();
            Console.CursorVisible = false;
            // var mazeString = host.Read<string>("Enter maze:");
            var maze = new Maze(mazeString);
            maze.OnMove += Maze_OnMove;
            maze.OnExitFound += Maze_OnExitFound;
            var result = maze.ShortestPath((0, 0));
            host.Show($"Result: {result}");
            Console.CursorVisible = true;
        }

        private void Maze_OnExitFound(object sender, OnExitFoundEventArgs e)
        {
            var node = e.Route;
            var pos = (left: Console.CursorLeft, top: Console.CursorTop);
            var color = Console.ForegroundColor;
            while (node != null)
            {
                Console.SetCursorPosition(node.X, node.Y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("X");
                node = node.Parent;
            }
            Console.ForegroundColor = color;
            Console.SetCursorPosition(pos.left, pos.top);
        }

        private void Maze_OnMove(object sender, OnMoveEventArgs args)
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < args.Maze.GetLength(1); y++)
            {
                for (int x= 0; x < args.Maze.GetLength(0); x++)
                {
                    var visited = args.Map[x, y];
                    var c = args.Maze[x, y];
                    Console.Write(visited ? 'X' : c);
                    Thread.Sleep(10);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Step #" + args.Step);
        }
    }

    public class Maze
    {
        private char[,] _mazeArray;
        private bool[,] _mazeMap;

        public Maze(string maze)
        {
            var mazeLines = maze.Split('\n');
            _mazeArray = new char[mazeLines[0].Length, mazeLines.Length];
            _mazeMap = new bool[mazeLines[0].Length, mazeLines.Length];
            for (int y = 0; y < mazeLines.Length; y++)
            {
                var line = mazeLines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    _mazeArray[x, y] = line[x];
                }
            }
        }

        public bool IsAtExit(int x, int y) => x == _mazeArray.GetLength(0) - 1 && y == _mazeArray.GetLength(1) - 1;

        public bool Solve(int x, int y)
        {
            if (IsWall(x, y) || IsAlreadyVisited(x, y))
                return false;

            _mazeMap[x, y] = true;

            OnMove?.Invoke(this, new OnMoveEventArgs(_mazeMap, _mazeArray));
            if (IsAtExit(x, y))
                return true;

            if (x != 0 && Solve(x - 1, y))
            {
                return true;
            }

            if (x != _mazeArray.GetLength(0) - 1 && Solve(x + 1, y))
            {
                return true;
            }

            if (y != 0 && Solve(x, y - 1))
            {
                return true;
            }

            if (y != _mazeArray.GetLength(1) - 1 && Solve(x, y + 1))
            {
                    return true;
            }

            return false;
        }

        public int ShortestPath((int x, int y) start)
        {
            var steps = 0;
            var itemsToVisit = new Queue<(int x, int y, Node parent)>(_mazeArray.Length);
            itemsToVisit.Enqueue((start.x, start.y, null));
            _mazeMap[start.x, start.y] = true;

            // north, east, south, west
            var dc = new[] { 0, 1, 0, -1 };
            var dr = new[] { -1, 0, 1, 0 };

            var nodesInLayer = 1;
            var nodesInNextLayer = 0;
            var currentNode = new Node(start.x, start.y, parent: null);
            while (itemsToVisit.Count > 0)
            {
                var item = itemsToVisit.Dequeue();
                currentNode = new Node(item.x, item.y, item.parent);
                if (IsAtExit(item.x, item.y))
                {
                    OnExitFound?.Invoke(this, new OnExitFoundEventArgs(currentNode));
                    return steps;
                }
                
                // Visit every direction
                for (int i = 0; i < 4; i++)
                {
                    var newX = item.x + dc[i];
                    var newY = item.y + dr[i];
                     
                    if (newX < 0 || newX == _mazeArray.GetLength(0)) continue;
                    if (newY < 0 || newY == _mazeArray.GetLength(1)) continue;
                    if (IsAlreadyVisited(newX, newY) || IsWall(newX, newY)) continue;

                    itemsToVisit.Enqueue((newX, newY, currentNode));
                    _mazeMap[newX, newY] = true;
                    nodesInNextLayer++;
                    OnMove?.Invoke(this, new OnMoveEventArgs(_mazeMap, _mazeArray, steps));
                }

                nodesInLayer--;
                if (nodesInLayer == 0)
                {
                    nodesInLayer = nodesInNextLayer;
                    nodesInNextLayer = 0;
                    steps++;
                }
            }

            return -1;
        }

        public event EventHandler<OnMoveEventArgs> OnMove;

        public event EventHandler<OnExitFoundEventArgs> OnExitFound;

        private bool IsAlreadyVisited(int x, int y)
        {
            return _mazeMap[x, y];
        }

        private bool IsWall(int x, int y)
        {
            return _mazeArray[x, y] == 'W';
        }
    }

    public class OnMoveEventArgs : EventArgs
    {
        public OnMoveEventArgs(bool[,] map, char[,] maze, int step = 0)
        {
            Map = map;
            Maze = maze;
            Step = step;
        }

        public int Step { get; set; }

        public bool[,] Map { get; set; }

        public char[,] Maze { get; set; }
    }

    public class OnExitFoundEventArgs : EventArgs
    {
        public OnExitFoundEventArgs(Node route)
        {
            Route = route;
        }

        public Node Route { get; }
    }

    public class Node
    {
        public Node(int x, int y, Node parent)
        {
            X = x;
            Y = y;
            Parent = parent;
            Children = new List<Node>();
        }

        public int X { get; set; }

        public int Y { get; set; }

        public List<Node> Children { get; set; }

        public Node Parent { get; set; }
    }
}
